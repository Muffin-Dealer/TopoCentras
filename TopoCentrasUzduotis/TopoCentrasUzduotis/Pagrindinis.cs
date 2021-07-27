using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace TopoCentrasUzduotis
{
    public partial class Pagrindinis : Form
    {
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VS2017 bandymai\TopoCentras\TopoCentrasUzduotis\TopoCentrasUzduotis\TopoCentrasDB.mdf;Integrated Security=True";
        DataContext db;
        int prekesKey = -1;
        int klientoKey = -1;

        public Pagrindinis()
        {
            InitializeComponent();
            db = new DataContext(ConnectionString);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BandymasLOAD();
            tabControl1.SelectedIndex = 2;
            tabControl1.SelectedIndex = 1;
            tabControl1.SelectedIndex = 0;
        }

        // Uzkraunami pasirinkti Tabai reikalinga informacija
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "tabPage1")
            {
                BandymasLOAD();

            }
            else if (e.TabPage.Name == "tabPage2")
            {
                db = new DataContext(ConnectionString);

                dgvKlientai.DataSource = db.GetTable<Klientai>();
                dgvKlientai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKlientai.AutoResizeColumn(0);

            }
            else if (e.TabPage.Name == "tabPage3")
            {
                db = new DataContext(ConnectionString);

                dgvPrekes.DataSource = db.GetTable<Prekes>();
                dgvPrekes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPrekes.AutoResizeColumn(0);

            }
        }


        #region UzsakymuTabas

        //Užkraunamas Užsakymų Tabas
        private void BandymasLOAD()
        {
            TurimiUzsakymai.Rows.Clear();

            db = new DataContext(ConnectionString);

            var uzsakymaiVisi = db.GetTable<Uzsakymai>();
            foreach (var item in uzsakymaiVisi)
            {
                var prekSar = db.GetTable<PirkiniuSarasa>().Where(x => x.Uzsakymas == item.UzsakymoId);
                decimal sum = 0;
                foreach (var preke in prekSar)
                {
                    sum += (decimal)preke.Prekes.Kaina;
                }
                TurimiUzsakymai.Rows.Add(item.UzsakymoId, item.Klientai.Pavadinimas, item.PirkiniuSarasas.Count, sum);
            }
        }
        //Paleidzia užsakymo kurimo langa
        private void btnPridetiUzsakyma_Click(object sender, EventArgs e)
        {
            Uzsakymas uzsakymas = new Uzsakymas(-1);
            uzsakymas.ShowDialog();

            BandymasLOAD();
        }
        //Paleidžia užsakymo redagavimo langą
        private void btnRedaguotiiUzsakyma_Click(object sender, EventArgs e)
        {
            if (TurimiUzsakymai.SelectedRows[0].Cells[0].Value != null)
            {

                Uzsakymas uzsakymas = new Uzsakymas(Convert.ToInt32(TurimiUzsakymai.SelectedRows[0].Cells[0].Value.ToString()));
                uzsakymas.ShowDialog();

                BandymasLOAD();
            }
        }
        //Ištrina pasirinktą užsakymą
        private void btnIstrintiUzsakyma_Click(object sender, EventArgs e)
        {
            //patikrina ar pasirinkta eilute
            if (TurimiUzsakymai.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Pasirinkite norima istrinti uzsakyma!!");
            }
            else
            {
                //Gauna uzsakymo ID
                int uzID = Convert.ToInt32(TurimiUzsakymai.SelectedRows[0].Cells[0].Value.ToString());
                //Paklausia ar tikrai norite ištrinti
                string message = String.Format("Ar tikrai norite istrinti uzsakyma Nr: {0} ?", uzID);
                MessageBoxButtons boxButtons = MessageBoxButtons.YesNo;
                DialogResult dlgResult = MessageBox.Show(message, "Istrinti", MessageBoxButtons.OKCancel);
                if (dlgResult == DialogResult.OK)
                {
                    try
                    {
                        //Suranda uzsakymą kuriam priklauso ID
                        Uzsakymai toDelete = db.GetTable<Uzsakymai>().Where(x => x.UzsakymoId == uzID).First();

                        //Suranda užsakymui priklausančius prekių sąrašus
                        if (toDelete.PirkiniuSarasas.Count != 0)
                        {
                            var priklauso = db.GetTable<PirkiniuSarasa>().Where(x => x.Uzsakymas == toDelete.UzsakymoId);
                            db.GetTable<PirkiniuSarasa>().DeleteAllOnSubmit(priklauso);
                        }
                        db.GetTable<Uzsakymai>().DeleteOnSubmit(toDelete);
                        //Prideda pakeitimus ir atnaujina lentelę
                        db.SubmitChanges();
                        MessageBox.Show("Uzsakymas Istrintas sekmingai!");

                        BandymasLOAD();

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }
        //atnaujina užsakymų taba
        private void button3_Click(object sender, EventArgs e)
        {
            txtIeskomasUzsakymas.Text = "";
            BandymasLOAD();
        }
        //suranda norima užsakymą
        private void btnRastiUzsakyma_Click(object sender, EventArgs e)
        {
            if (txtIeskomasUzsakymas.Text == "")
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    TurimiUzsakymai.Rows.Clear();

                    db = new DataContext(ConnectionString);

                    var ieskomas = db.GetTable<Uzsakymai>().Where(x => x.UzsakymoId == Convert.ToInt32(txtIeskomasUzsakymas.Text)).First();

                    var prekSar = db.GetTable<PirkiniuSarasa>().Where(x => x.Uzsakymas == ieskomas.UzsakymoId);
                    decimal sum = 0;
                    foreach (var preke in prekSar)
                    {
                        sum += (decimal)preke.Prekes.Kaina;
                    }
                    TurimiUzsakymai.Rows.Add(ieskomas.UzsakymoId, ieskomas.Klientai.Pavadinimas, ieskomas.PirkiniuSarasas.Count, sum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Užsakymas nerastas!");
                }

            }
        }
        #endregion

        #region PrekiuTabas
        //Prideda naują prekę
        private void btnPridetiPreke_Click(object sender, EventArgs e)
        {
            if (txtPrekesPavadinimas.Text == "" || txtPrekesKaina.Text == "")
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    Prekes preke = new Prekes();
                    preke.Pavadinimass = txtPrekesPavadinimas.Text;
                    preke.Kaina = decimal.Parse(txtPrekesKaina.Text);
                    db.GetTable<Prekes>().InsertOnSubmit(preke);

                    db.SubmitChanges();
                    MessageBox.Show("Preke prideta sekmingai!");
                    db = new DataContext(ConnectionString);

                    dgvPrekes.DataSource = db.GetTable<Prekes>();
                    prekesKey = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //Pasirinkus prekių sarašo eilutę užkrauna textBoxus
        private void dgvPrekes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPrekesPavadinimas.Text = dgvPrekes.SelectedRows[0].Cells[1].Value.ToString();
            txtPrekesKaina.Text = dgvPrekes.SelectedRows[0].Cells[2].Value.ToString();
            if (txtPrekesPavadinimas.Text == "")
            {
                prekesKey = -1;
            }
            else
            {
                prekesKey = Convert.ToInt32(dgvPrekes.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        //Istrina prekes iš duomenų
        private void btnIstrintiPreke_Click(object sender, EventArgs e)
        {
            //Parikrina ar pasirinkta kokia nors prekė
            if (prekesKey == -1)
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    //Patikrina ar norima ištrinti prekė nėra užsakyta jei užsakyta praneša kuriuose užsakymuose
                    Prekes toDelete = db.GetTable<Prekes>().Where(x => x.Id == prekesKey).First();
                    if (toDelete.PirkiniuSarasas.Count == 0)
                    {
                        db.GetTable<Prekes>().DeleteOnSubmit(toDelete);

                        db.SubmitChanges();
                        MessageBox.Show("Preke Istrinta sekmingai!");
                        db = new DataContext(ConnectionString);

                        dgvPrekes.DataSource = db.GetTable<Prekes>();
                        prekesKey = -1;
                    }
                    else
                    {
                        var priklauso = db.GetTable<PirkiniuSarasa>().Where(x => x.Preke == toDelete.Id);
                        string message = "";
                        foreach (var item in priklauso)
                        {
                            message += item.Uzsakymas.ToString() + "\n";
                        }
                        MessageBox.Show("Prekes istrinti nepavyko ji yea uzsakyta!\nUzsakymu kiekis " + toDelete.PirkiniuSarasas.Count + " : \nUzsakymuId:\n" + message);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        //Pasirinkus prekia ją redaguoja
        private void btnRedaguotiPreke_Click(object sender, EventArgs e)
        {
            if (txtPrekesPavadinimas.Text == "" || txtPrekesKaina.Text == "" || prekesKey == -1)
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    Prekes preke = new Prekes();

                    preke = db.GetTable<Prekes>().Where(x => x.Id == prekesKey).First();
                    preke.Pavadinimass = txtPrekesPavadinimas.Text;
                    preke.Kaina = decimal.Parse(txtPrekesKaina.Text);

                    db.SubmitChanges();
                    MessageBox.Show("Preke Redaguota sekmingai!");
                    db = new DataContext(ConnectionString);
                    dgvPrekes.DataSource = db.GetTable<Prekes>();
                    prekesKey = -1;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void btnAtnaujintiPrekes_Click(object sender, EventArgs e)
        {
            txtPrekesPavadinimas.Text = "";
            txtPrekesKaina.Text = "";
            dgvPrekes.DataSource = db.GetTable<Prekes>();
        }

        private void btnRastiPreke_Click(object sender, EventArgs e)
        {
            if (txtPrekesPavadinimas.Text == "" && txtPrekesKaina.Text == "")
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {

                try
                {
                    db = new DataContext(ConnectionString);

                    if (txtPrekesPavadinimas.Text != "" && txtPrekesKaina.Text != "")
                    {
                        var ieskomas = db.GetTable<Prekes>().Where(x => x.Pavadinimass == txtPrekesPavadinimas.Text && x.Kaina == decimal.Parse(txtPrekesKaina.Text));
                        dgvPrekes.DataSource = ieskomas;
                    }
                    else if (txtPrekesKaina.Text == "")
                    {
                        var ieskomas = db.GetTable<Prekes>().Where(x => x.Pavadinimass == txtPrekesPavadinimas.Text);
                        dgvPrekes.DataSource = ieskomas;
                    }
                    else if (txtPrekesPavadinimas.Text == "")
                    {
                        var ieskomas = db.GetTable<Prekes>().Where(x => x.Kaina == decimal.Parse(txtPrekesKaina.Text));
                        dgvPrekes.DataSource = ieskomas;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Prekė nerasta!");
                }
            }
        }
        #endregion

        #region KlientuTab
        //prideda naują Klientą
        private void btnPridetiKlienta_Click(object sender, EventArgs e)
        {
            if (txtKlientoPavadinimas.Text == "")
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    Klientai klientas = new Klientai();
                    klientas.Pavadinimas = txtKlientoPavadinimas.Text;
                    db.GetTable<Klientai>().InsertOnSubmit(klientas);

                    db.SubmitChanges();
                    MessageBox.Show("Klientas pridetas sekmingai!");
                    db = new DataContext(ConnectionString);

                    dgvKlientai.DataSource = db.GetTable<Klientai>();
                    klientoKey = -1;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        //Pasirinkus Klienta jį redaguoja
        private void btnRedaguotiiKlienta_Click(object sender, EventArgs e)
        {
            if (txtKlientoPavadinimas.Text == "" || klientoKey == -1)
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    Klientai klientas = new Klientai();

                    klientas = db.GetTable<Klientai>().Where(x => x.Id == klientoKey).First();
                    klientas.Pavadinimas = txtKlientoPavadinimas.Text;

                    db.SubmitChanges();
                    MessageBox.Show("Klientas Redaguotas sekmingai!");
                    db = new DataContext(ConnectionString);
                    dgvKlientai.DataSource = db.GetTable<Klientai>();
                    klientoKey = -1;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        //Ištrina pasirinkta klientą
        private void btnIstrintiKlienta_Click(object sender, EventArgs e)
        {
            if (klientoKey == -1)
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    Klientai klientas = new Klientai();

                    klientas.Pavadinimas = txtKlientoPavadinimas.Text;
                    Klientai toDelete = db.GetTable<Klientai>().Where(x => x.Id == klientoKey).First();
                    if (toDelete.Uzsakymais.Count == 0)
                    {
                        db.GetTable<Klientai>().DeleteOnSubmit(toDelete);

                        db.SubmitChanges();
                        MessageBox.Show("Klientas Istrintas sekmingai!");
                        db = new DataContext(ConnectionString);

                        dgvKlientai.DataSource = db.GetTable<Klientai>();
                        klientoKey = -1;
                    }
                    else
                    {
                        var priklauso = db.GetTable<Uzsakymai>().Where(x => x.Uzsakovas == toDelete.Id);
                        string message = "";
                        foreach (var item in priklauso)
                        {
                            message += item.UzsakymoId.ToString() + "\n";
                        }
                        MessageBox.Show("Kliento istrinti nepavyko jis turi uzsakyma!\nUzsakymu kiekis " + toDelete.Uzsakymais.Count + " : \nUzsakymuId:\n" + message);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        //gauna pasirinktos eilutės info
        private void dgvKlientai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKlientoPavadinimas.Text = dgvKlientai.SelectedRows[0].Cells[1].Value.ToString();
            if (txtKlientoPavadinimas.Text == "")
            {
                klientoKey = -1;
            }
            else
            {
                klientoKey = Convert.ToInt32(dgvKlientai.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void btnAtnaujintiKlientus_Click(object sender, EventArgs e)
        {
            txtKlientoPavadinimas.Text = "";
            dgvKlientai.DataSource = db.GetTable<Klientai>();
        }

        private void btnRastiKlienta_Click(object sender, EventArgs e)
        {
            if (txtKlientoPavadinimas.Text == "")
            {
                MessageBox.Show("Truksta Informacijos!!");
            }
            else
            {
                try
                {
                    db = new DataContext(ConnectionString);

                    var ieskomas = db.GetTable<Klientai>().Where(x => x.Pavadinimas == txtKlientoPavadinimas.Text);
                    dgvKlientai.DataSource = ieskomas;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klientas nerastas!");
                }
            }
        }

        #endregion



    }
}
