using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TopoCentrasUzduotis
{
    public partial class Uzsakymas : Form
    {
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS2017 bandymai\TopoCentras\TopoCentrasUzduotis\TopoCentrasUzduotis\TopoCentrasDB.mdf;Integrated Security=True";
        DataContext db;
        //uzsakymoID pasako ar užsakymas redaguojamas ar naujas
        int uzsakymoID = -1;    
        //KlientoKey pasako koki klienta naudoti jei užsakymas redaguojamas
        int klientoKey = -1;
        List<Prekes> PasirinktosPrekes;
        public Uzsakymas(int uzsakID)
        {
            InitializeComponent();
            db = new DataContext(ConnectionString);
            uzsakymoID = uzsakID;
            PasirinktosPrekes = new List<Prekes>();
        }

        private void Uzsakymas_Load(object sender, EventArgs e)
        {
            if(uzsakymoID!=-1)
                klientoKey = db.GetTable<Uzsakymai>().Where(x => x.UzsakymoId == uzsakymoID).First().Uzsakovas;

            LoadKlientus();
            LoadPrekes();
            LoadUzsakytasPrekes();


        }
        //atnaujina užsakytų prekių sąrasą
        private void LoadUzsakytasPrekes()
        {
            if (uzsakymoID != -1 && PasirinktosPrekes.Count == 0) 
            {
                db = new DataContext(ConnectionString);
                var tbll = db.GetTable<PirkiniuSarasa>().Where(x => x.Uzsakymas == uzsakymoID).Select(x => new { x.Prekes.Id, x.Prekes.Pavadinimass, x.Prekes.Kaina });
                foreach (var item in tbll)
                {
                    Prekes p = new Prekes() { Id = item.Id, Pavadinimass = item.Pavadinimass, Kaina = item.Kaina };
                    PasirinktosPrekes.Add(p);
                }
            }
            db = new DataContext(ConnectionString);
            dgvUzsakomosPrekes.DataSource = new BindingSource(PasirinktosPrekes, null);
            dgvUzsakomosPrekes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUzsakomosPrekes.AutoResizeColumn(0);
        }
        //užkrauna Klientu combobox
        private void LoadKlientus()
        {
            db = new DataContext(ConnectionString);
            var lent = db.GetTable<Klientai>();
            Dictionary<int, string> comb = new Dictionary<int, string>();
            foreach (var item in lent)
            {
                comb.Add(item.Id, item.Pavadinimas);
            }
            cmbKlientas.DisplayMember = "Value";
            cmbKlientas.ValueMember = "Key";
            cmbKlientas.DataSource = new BindingSource(comb, null);
            if (uzsakymoID == -1)
            {
                cmbKlientas.SelectedIndex = 0;
            }
            else
                cmbKlientas.SelectedValue = klientoKey;
        }
        //užkrauna prekiu sąrasą
        private void LoadPrekes()
        {
            db = new DataContext(ConnectionString);

            dgvPrekes.DataSource = db.GetTable<Prekes>();
            dgvPrekes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrekes.AutoResizeColumn(0);
        }
        //ikelia prekę į pirkinių sąrasą
        private void btnPridetiPreke_Click(object sender, EventArgs e)
        {
            int pasirinktaPreke = Convert.ToInt32(dgvPrekes.SelectedRows[0].Cells[0].Value.ToString());

            PasirinktosPrekes.Add(db.GetTable<Prekes>().Where(x => x.Id == pasirinktaPreke).First());
            LoadUzsakytasPrekes();


            string a = "";
        }
        //išema prekia iš užsakytu sąrašo
        private void btnIsimtiPreke_Click(object sender, EventArgs e)
        {
            if (PasirinktosPrekes.Count() > 1 || uzsakymoID < 0)
            {
                PasirinktosPrekes.RemoveAt(dgvUzsakomosPrekes.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Redaguojant uzsakyma turi likti bent viena preke!");
            }
            LoadUzsakytasPrekes();
        }
        //Išsaugo sukurta arba redaguota užsakymą
        private void btnUzsakyti_Click(object sender, EventArgs e)
        {
            //jei užsakymas naujas
            if (uzsakymoID == -1)
            {
                try
                {
                    //sukuria nauja užsakyma
                    Uzsakymai uzsakymas = new Uzsakymai();
                    uzsakymas.Uzsakovas = (int)cmbKlientas.SelectedValue;
                    db.GetTable<Uzsakymai>().InsertOnSubmit(uzsakymas);
                    db.SubmitChanges();

                    db = new DataContext(ConnectionString);
                    var uzsak = db.GetTable<Uzsakymai>().Where(x => x.Uzsakovas == (int)cmbKlientas.SelectedValue);
                    int a = -1;
                    if (uzsak.Count() > 1)
                    {
                        a = uzsak.OrderByDescending(x => x.UzsakymoId).First().UzsakymoId;
                    }
                    else
                        a = uzsak.First().UzsakymoId;
                    //sukurtam užsakymui prideda prekes
                    foreach (var item in PasirinktosPrekes)
                    {
                        Uzsakymai uz = new Uzsakymai();
                        PirkiniuSarasa sarasas = new PirkiniuSarasa();
                        sarasas.Preke = item.Id;
                        sarasas.Uzsakymas = a;
                        db.GetTable<PirkiniuSarasa>().InsertOnSubmit(sarasas);

                    }
                    MessageBox.Show("Uzsakyta sekmingai!");

                    db.SubmitChanges();
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            //jei užsakymas redaguojamas
            else 
            {
                try
                {
                    //suranda seną prekių sąrašą
                    var uzsak = db.GetTable<PirkiniuSarasa>().Where(x => x.Uzsakymas == uzsakymoID);
                    if (db.GetTable<Uzsakymai>().Where(x => x.UzsakymoId == uzsakymoID).First().PirkiniuSarasas.Count() > 0)
                    {
                        if (uzsak.First().Uzsakymai.Uzsakovas != (int)cmbKlientas.SelectedValue)
                        {
                            Uzsakymai uzsakymas = new Uzsakymai();
                            uzsakymas = db.GetTable<Uzsakymai>().Where(x => x.UzsakymoId == uzsakymoID).First();
                            uzsakymas.Uzsakovas = (int)cmbKlientas.SelectedValue;

                        }
                    }
                    db.GetTable<PirkiniuSarasa>().DeleteAllOnSubmit(uzsak);
                    //sukuria naują prekių sąrašą
                    foreach (var item in PasirinktosPrekes)
                    {
                        PirkiniuSarasa sarasas = new PirkiniuSarasa();
                        sarasas.Preke = item.Id;
                        sarasas.Uzsakymas = uzsakymoID;
                        db.GetTable<PirkiniuSarasa>().InsertOnSubmit(sarasas);
                    }
                    var aasfsad = db.GetChangeSet();
                    db.SubmitChanges();
                    MessageBox.Show("Uzsakymas pakeistas sekmingai!");
                    this.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnAtsaukti_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
