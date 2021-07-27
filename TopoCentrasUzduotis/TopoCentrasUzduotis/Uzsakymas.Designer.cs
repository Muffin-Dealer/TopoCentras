namespace TopoCentrasUzduotis
{
    partial class Uzsakymas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPrekes = new System.Windows.Forms.DataGridView();
            this.dgvUzsakomosPrekes = new System.Windows.Forms.DataGridView();
            this.btnPridetiPreke = new System.Windows.Forms.Button();
            this.btnIsimtiPreke = new System.Windows.Forms.Button();
            this.btnUzsakyti = new System.Windows.Forms.Button();
            this.btnAtsaukti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKlientas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrekes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUzsakomosPrekes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrekes
            // 
            this.dgvPrekes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrekes.Location = new System.Drawing.Point(30, 287);
            this.dgvPrekes.MultiSelect = false;
            this.dgvPrekes.Name = "dgvPrekes";
            this.dgvPrekes.ReadOnly = true;
            this.dgvPrekes.RowHeadersVisible = false;
            this.dgvPrekes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrekes.Size = new System.Drawing.Size(453, 210);
            this.dgvPrekes.TabIndex = 2;
            // 
            // dgvUzsakomosPrekes
            // 
            this.dgvUzsakomosPrekes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUzsakomosPrekes.Location = new System.Drawing.Point(606, 287);
            this.dgvUzsakomosPrekes.MultiSelect = false;
            this.dgvUzsakomosPrekes.Name = "dgvUzsakomosPrekes";
            this.dgvUzsakomosPrekes.ReadOnly = true;
            this.dgvUzsakomosPrekes.RowHeadersVisible = false;
            this.dgvUzsakomosPrekes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUzsakomosPrekes.Size = new System.Drawing.Size(453, 210);
            this.dgvUzsakomosPrekes.TabIndex = 4;
            // 
            // btnPridetiPreke
            // 
            this.btnPridetiPreke.Location = new System.Drawing.Point(511, 341);
            this.btnPridetiPreke.Name = "btnPridetiPreke";
            this.btnPridetiPreke.Size = new System.Drawing.Size(69, 31);
            this.btnPridetiPreke.TabIndex = 5;
            this.btnPridetiPreke.Text = "Prideti";
            this.btnPridetiPreke.UseVisualStyleBackColor = true;
            this.btnPridetiPreke.Click += new System.EventHandler(this.btnPridetiPreke_Click);
            // 
            // btnIsimtiPreke
            // 
            this.btnIsimtiPreke.Location = new System.Drawing.Point(511, 409);
            this.btnIsimtiPreke.Name = "btnIsimtiPreke";
            this.btnIsimtiPreke.Size = new System.Drawing.Size(69, 32);
            this.btnIsimtiPreke.TabIndex = 9;
            this.btnIsimtiPreke.Text = "isimti";
            this.btnIsimtiPreke.UseVisualStyleBackColor = true;
            this.btnIsimtiPreke.Click += new System.EventHandler(this.btnIsimtiPreke_Click);
            // 
            // btnUzsakyti
            // 
            this.btnUzsakyti.Location = new System.Drawing.Point(603, 124);
            this.btnUzsakyti.Name = "btnUzsakyti";
            this.btnUzsakyti.Size = new System.Drawing.Size(107, 42);
            this.btnUzsakyti.TabIndex = 10;
            this.btnUzsakyti.Text = "Uzsakyti";
            this.btnUzsakyti.UseVisualStyleBackColor = true;
            this.btnUzsakyti.Click += new System.EventHandler(this.btnUzsakyti_Click);
            // 
            // btnAtsaukti
            // 
            this.btnAtsaukti.Location = new System.Drawing.Point(12, 12);
            this.btnAtsaukti.Name = "btnAtsaukti";
            this.btnAtsaukti.Size = new System.Drawing.Size(107, 42);
            this.btnAtsaukti.TabIndex = 11;
            this.btnAtsaukti.Text = "Atsaukti";
            this.btnAtsaukti.UseVisualStyleBackColor = true;
            this.btnAtsaukti.Click += new System.EventHandler(this.btnAtsaukti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(401, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Klientai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Prekes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Pasirinktos Prekes";
            // 
            // cmbKlientas
            // 
            this.cmbKlientas.FormattingEnabled = true;
            this.cmbKlientas.Location = new System.Drawing.Point(404, 133);
            this.cmbKlientas.Name = "cmbKlientas";
            this.cmbKlientas.Size = new System.Drawing.Size(176, 21);
            this.cmbKlientas.TabIndex = 15;
            // 
            // Uzsakymas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 532);
            this.Controls.Add(this.cmbKlientas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtsaukti);
            this.Controls.Add(this.btnUzsakyti);
            this.Controls.Add(this.btnIsimtiPreke);
            this.Controls.Add(this.btnPridetiPreke);
            this.Controls.Add(this.dgvUzsakomosPrekes);
            this.Controls.Add(this.dgvPrekes);
            this.Name = "Uzsakymas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uzsakymas";
            this.Load += new System.EventHandler(this.Uzsakymas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrekes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUzsakomosPrekes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrekes;
        private System.Windows.Forms.DataGridView dgvUzsakomosPrekes;
        private System.Windows.Forms.Button btnPridetiPreke;
        private System.Windows.Forms.Button btnIsimtiPreke;
        private System.Windows.Forms.Button btnUzsakyti;
        private System.Windows.Forms.Button btnAtsaukti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKlientas;
    }
}