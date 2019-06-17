namespace CarHireRC.WinUI.RezervacijeVozila
{
    partial class frmRezervacije
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.chbAktivan = new MetroFramework.Controls.MetroCheckBox();
            this.chBoxKasko = new MetroFramework.Controls.MetroCheckBox();
            this.chBoxVracanjeUPoslovnicu = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.chBDK = new System.Windows.Forms.CheckBox();
            this.txtSearchUsername = new System.Windows.Forms.TextBox();
            this.txtRegOznaka = new System.Windows.Forms.TextBox();
            this.cmbSearchProizvodjac = new System.Windows.Forms.ComboBox();
            this.cmbSearchModel = new System.Windows.Forms.ComboBox();
            this.dtpDatumKreiranja = new System.Windows.Forms.DateTimePicker();
            this.txtSearchIme = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRezervacije = new System.Windows.Forms.DataGridView();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Od = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klijent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vozilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchPrezime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.chbDo = new System.Windows.Forms.CheckBox();
            this.chBOd = new System.Windows.Forms.CheckBox();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnPoruka = new MetroFramework.Controls.MetroButton();
            this.chbVracanjaUPoslovnicu = new MetroFramework.Controls.MetroCheckBox();
            this.chbKasko = new MetroFramework.Controls.MetroCheckBox();
            this.lblIznosBezPopusta = new MetroFramework.Controls.MetroLabel();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.txtDatumKreiranjaRezervacije = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIznosSaPopustom = new System.Windows.Forms.TextBox();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.txtRegOznake = new System.Windows.Forms.TextBox();
            this.txtVozilo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpDatumVazenjaDo = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumVazenjaOd = new System.Windows.Forms.DateTimePicker();
            this.btnSacuvajUredi = new System.Windows.Forms.Button();
            this.txtLokacijaPreuzimanja = new System.Windows.Forms.TextBox();
            this.txtKlijent = new System.Windows.Forms.TextBox();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(0, 2);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(1055, 810);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.chbAktivan);
            this.metroTabPage1.Controls.Add(this.chBoxKasko);
            this.metroTabPage1.Controls.Add(this.chBoxVracanjeUPoslovnicu);
            this.metroTabPage1.Controls.Add(this.metroLabel7);
            this.metroTabPage1.Controls.Add(this.metroLabel6);
            this.metroTabPage1.Controls.Add(this.metroLabel5);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.chBDK);
            this.metroTabPage1.Controls.Add(this.txtSearchUsername);
            this.metroTabPage1.Controls.Add(this.txtRegOznaka);
            this.metroTabPage1.Controls.Add(this.cmbSearchProizvodjac);
            this.metroTabPage1.Controls.Add(this.cmbSearchModel);
            this.metroTabPage1.Controls.Add(this.dtpDatumKreiranja);
            this.metroTabPage1.Controls.Add(this.txtSearchIme);
            this.metroTabPage1.Controls.Add(this.btnPrikazi);
            this.metroTabPage1.Controls.Add(this.groupBox1);
            this.metroTabPage1.Controls.Add(this.txtSearchPrezime);
            this.metroTabPage1.Controls.Add(this.groupBox2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1047, 768);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Lista rezervacija";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // chbAktivan
            // 
            this.chbAktivan.AutoSize = true;
            this.chbAktivan.Checked = true;
            this.chbAktivan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAktivan.Location = new System.Drawing.Point(362, 337);
            this.chbAktivan.Name = "chbAktivan";
            this.chbAktivan.Size = new System.Drawing.Size(121, 15);
            this.chbAktivan.TabIndex = 136;
            this.chbAktivan.Text = "Aktivne rezervacije";
            this.chbAktivan.UseSelectable = true;
            // 
            // chBoxKasko
            // 
            this.chBoxKasko.AutoSize = true;
            this.chBoxKasko.Checked = true;
            this.chBoxKasko.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxKasko.Location = new System.Drawing.Point(362, 291);
            this.chBoxKasko.Name = "chBoxKasko";
            this.chBoxKasko.Size = new System.Drawing.Size(112, 15);
            this.chBoxKasko.TabIndex = 135;
            this.chBoxKasko.Text = "Kasko osiguranje";
            this.chBoxKasko.UseSelectable = true;
            // 
            // chBoxVracanjeUPoslovnicu
            // 
            this.chBoxVracanjeUPoslovnicu.AutoSize = true;
            this.chBoxVracanjeUPoslovnicu.Checked = true;
            this.chBoxVracanjeUPoslovnicu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxVracanjeUPoslovnicu.Location = new System.Drawing.Point(48, 291);
            this.chBoxVracanjeUPoslovnicu.Name = "chBoxVracanjeUPoslovnicu";
            this.chBoxVracanjeUPoslovnicu.Size = new System.Drawing.Size(139, 15);
            this.chBoxVracanjeUPoslovnicu.TabIndex = 134;
            this.chBoxVracanjeUPoslovnicu.Text = "Vraćanje u poslovnicu";
            this.chBoxVracanjeUPoslovnicu.UseSelectable = true;
            this.chBoxVracanjeUPoslovnicu.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(362, 199);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(39, 15);
            this.metroLabel7.TabIndex = 133;
            this.metroLabel7.Text = "Model";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(46, 199);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(63, 15);
            this.metroLabel6.TabIndex = 132;
            this.metroLabel6.Text = "Proizvođač";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(321, 122);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(141, 15);
            this.metroLabel5.TabIndex = 131;
            this.metroLabel5.Text = "Datum kreiranja rezervacije";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(47, 122);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(100, 15);
            this.metroLabel3.TabIndex = 130;
            this.metroLabel3.Text = "Reg. oznaka vozila";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(243, 37);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(48, 15);
            this.metroLabel4.TabIndex = 129;
            this.metroLabel4.Text = "Prezime";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(431, 37);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 15);
            this.metroLabel2.TabIndex = 128;
            this.metroLabel2.Text = "Username";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(46, 37);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(26, 15);
            this.metroLabel1.TabIndex = 127;
            this.metroLabel1.Text = "Ime";
            // 
            // chBDK
            // 
            this.chBDK.BackColor = System.Drawing.Color.White;
            this.chBDK.Location = new System.Drawing.Point(605, 142);
            this.chBDK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBDK.Name = "chBDK";
            this.chBDK.Size = new System.Drawing.Size(30, 36);
            this.chBDK.TabIndex = 126;
            this.chBDK.UseVisualStyleBackColor = false;
            this.chBDK.CheckedChanged += new System.EventHandler(this.chBDK_CheckedChanged);
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.Location = new System.Drawing.Point(435, 62);
            this.txtSearchUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchUsername.MaxLength = 50;
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.Size = new System.Drawing.Size(163, 26);
            this.txtSearchUsername.TabIndex = 123;
            this.txtSearchUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchUsername_KeyPress);
            // 
            // txtRegOznaka
            // 
            this.txtRegOznaka.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRegOznaka.Location = new System.Drawing.Point(47, 147);
            this.txtRegOznaka.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRegOznaka.MaxLength = 20;
            this.txtRegOznaka.Name = "txtRegOznaka";
            this.txtRegOznaka.Size = new System.Drawing.Size(237, 26);
            this.txtRegOznaka.TabIndex = 121;
            this.txtRegOznaka.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRegOznaka_KeyPress);
            // 
            // cmbSearchProizvodjac
            // 
            this.cmbSearchProizvodjac.FormattingEnabled = true;
            this.cmbSearchProizvodjac.Location = new System.Drawing.Point(48, 224);
            this.cmbSearchProizvodjac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSearchProizvodjac.Name = "cmbSearchProizvodjac";
            this.cmbSearchProizvodjac.Size = new System.Drawing.Size(236, 28);
            this.cmbSearchProizvodjac.TabIndex = 119;
            this.cmbSearchProizvodjac.SelectedIndexChanged += new System.EventHandler(this.cmbSearchProizvodjac_SelectedIndexChanged);
            // 
            // cmbSearchModel
            // 
            this.cmbSearchModel.FormattingEnabled = true;
            this.cmbSearchModel.Location = new System.Drawing.Point(362, 224);
            this.cmbSearchModel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSearchModel.Name = "cmbSearchModel";
            this.cmbSearchModel.Size = new System.Drawing.Size(236, 28);
            this.cmbSearchModel.TabIndex = 117;
            // 
            // dtpDatumKreiranja
            // 
            this.dtpDatumKreiranja.Enabled = false;
            this.dtpDatumKreiranja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDatumKreiranja.Location = new System.Drawing.Point(321, 147);
            this.dtpDatumKreiranja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDatumKreiranja.MaxDate = new System.DateTime(2019, 5, 17, 0, 0, 0, 0);
            this.dtpDatumKreiranja.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpDatumKreiranja.Name = "dtpDatumKreiranja";
            this.dtpDatumKreiranja.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDatumKreiranja.Size = new System.Drawing.Size(277, 26);
            this.dtpDatumKreiranja.TabIndex = 106;
            this.dtpDatumKreiranja.Value = new System.DateTime(2019, 5, 17, 0, 0, 0, 0);
            // 
            // txtSearchIme
            // 
            this.txtSearchIme.Location = new System.Drawing.Point(48, 62);
            this.txtSearchIme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchIme.MaxLength = 50;
            this.txtSearchIme.Name = "txtSearchIme";
            this.txtSearchIme.Size = new System.Drawing.Size(163, 26);
            this.txtSearchIme.TabIndex = 109;
            this.txtSearchIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchIme_KeyPress);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPrikazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrikazi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrikazi.Location = new System.Drawing.Point(926, 310);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(115, 42);
            this.btnPrikazi.TabIndex = 108;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = false;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvRezervacije);
            this.groupBox1.Location = new System.Drawing.Point(3, 366);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1041, 364);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rezervacije";
            // 
            // dgvRezervacije
            // 
            this.dgvRezervacije.AllowUserToAddRows = false;
            this.dgvRezervacije.AllowUserToDeleteRows = false;
            this.dgvRezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRezervacije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.Od,
            this.Do,
            this.Klijent,
            this.Vozilo,
            this.Iznos});
            this.dgvRezervacije.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRezervacije.Location = new System.Drawing.Point(3, 21);
            this.dgvRezervacije.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRezervacije.Name = "dgvRezervacije";
            this.dgvRezervacije.ReadOnly = true;
            this.dgvRezervacije.RowTemplate.Height = 24;
            this.dgvRezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervacije.Size = new System.Drawing.Size(1035, 341);
            this.dgvRezervacije.TabIndex = 0;
            this.dgvRezervacije.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvRezervacije_MouseDoubleClick);
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "RezervacijaRentanjaId";
            this.KorisnikId.HeaderText = "RezervacijaRentanjaId";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            this.KorisnikId.Width = 140;
            // 
            // Od
            // 
            this.Od.DataPropertyName = "RezervacijaOd";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Od.DefaultCellStyle = dataGridViewCellStyle1;
            this.Od.HeaderText = "Od";
            this.Od.Name = "Od";
            this.Od.ReadOnly = true;
            this.Od.ToolTipText = "Od";
            this.Od.Width = 130;
            // 
            // Do
            // 
            this.Do.DataPropertyName = "RezervacijaDo";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Do.DefaultCellStyle = dataGridViewCellStyle2;
            this.Do.HeaderText = "Do";
            this.Do.Name = "Do";
            this.Do.ReadOnly = true;
            this.Do.Width = 130;
            // 
            // Klijent
            // 
            this.Klijent.DataPropertyName = "Klijent";
            this.Klijent.HeaderText = "Klijent";
            this.Klijent.Name = "Klijent";
            this.Klijent.ReadOnly = true;
            this.Klijent.ToolTipText = "Klijent";
            this.Klijent.Width = 150;
            // 
            // Vozilo
            // 
            this.Vozilo.DataPropertyName = "VoziloInformacije";
            this.Vozilo.HeaderText = "Vozilo";
            this.Vozilo.Name = "Vozilo";
            this.Vozilo.ReadOnly = true;
            this.Vozilo.Width = 150;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Iznos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            this.Iznos.ToolTipText = "Iznos";
            this.Iznos.Width = 120;
            // 
            // txtSearchPrezime
            // 
            this.txtSearchPrezime.Location = new System.Drawing.Point(243, 62);
            this.txtSearchPrezime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchPrezime.MaxLength = 50;
            this.txtSearchPrezime.Name = "txtSearchPrezime";
            this.txtSearchPrezime.Size = new System.Drawing.Size(163, 26);
            this.txtSearchPrezime.TabIndex = 114;
            this.txtSearchPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPrezime_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.metroLabel8);
            this.groupBox2.Controls.Add(this.metroLabel9);
            this.groupBox2.Controls.Add(this.chbDo);
            this.groupBox2.Controls.Add(this.chBOd);
            this.groupBox2.Controls.Add(this.dtpDo);
            this.groupBox2.Controls.Add(this.dtpOd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(668, 44);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(369, 190);
            this.groupBox2.TabIndex = 113;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datum važenja rezervacije";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(13, 113);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(22, 15);
            this.metroLabel8.TabIndex = 137;
            this.metroLabel8.Text = "Do";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(12, 46);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(23, 15);
            this.metroLabel9.TabIndex = 138;
            this.metroLabel9.Text = "Od";
            // 
            // chbDo
            // 
            this.chbDo.Location = new System.Drawing.Point(332, 136);
            this.chbDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbDo.Name = "chbDo";
            this.chbDo.Size = new System.Drawing.Size(30, 31);
            this.chbDo.TabIndex = 106;
            this.chbDo.UseVisualStyleBackColor = true;
            this.chbDo.CheckedChanged += new System.EventHandler(this.chbDo_CheckedChanged);
            // 
            // chBOd
            // 
            this.chBOd.Location = new System.Drawing.Point(332, 70);
            this.chBOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBOd.Name = "chBOd";
            this.chBOd.Size = new System.Drawing.Size(30, 29);
            this.chBOd.TabIndex = 106;
            this.chBOd.UseVisualStyleBackColor = true;
            this.chBOd.CheckedChanged += new System.EventHandler(this.chBOd_CheckedChanged);
            // 
            // dtpDo
            // 
            this.dtpDo.Enabled = false;
            this.dtpDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDo.Location = new System.Drawing.Point(12, 138);
            this.dtpDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDo.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.dtpDo.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(300, 26);
            this.dtpDo.TabIndex = 67;
            this.dtpDo.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // dtpOd
            // 
            this.dtpOd.Enabled = false;
            this.dtpOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOd.Location = new System.Drawing.Point(12, 71);
            this.dtpOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpOd.MaxDate = new System.DateTime(2029, 12, 31, 0, 0, 0, 0);
            this.dtpOd.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(300, 26);
            this.dtpOd.TabIndex = 64;
            this.dtpOd.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnPoruka);
            this.metroTabPage2.Controls.Add(this.chbVracanjaUPoslovnicu);
            this.metroTabPage2.Controls.Add(this.chbKasko);
            this.metroTabPage2.Controls.Add(this.lblIznosBezPopusta);
            this.metroTabPage2.Controls.Add(this.metroLabel19);
            this.metroTabPage2.Controls.Add(this.metroLabel18);
            this.metroTabPage2.Controls.Add(this.metroLabel17);
            this.metroTabPage2.Controls.Add(this.metroLabel16);
            this.metroTabPage2.Controls.Add(this.metroLabel15);
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.metroLabel11);
            this.metroTabPage2.Controls.Add(this.metroLabel12);
            this.metroTabPage2.Controls.Add(this.metroLabel13);
            this.metroTabPage2.Controls.Add(this.metroLabel14);
            this.metroTabPage2.Controls.Add(this.txtDatumKreiranjaRezervacije);
            this.metroTabPage2.Controls.Add(this.label2);
            this.metroTabPage2.Controls.Add(this.txtIznosSaPopustom);
            this.metroTabPage2.Controls.Add(this.txtPopust);
            this.metroTabPage2.Controls.Add(this.txtRegOznake);
            this.metroTabPage2.Controls.Add(this.txtVozilo);
            this.metroTabPage2.Controls.Add(this.pictureBox1);
            this.metroTabPage2.Controls.Add(this.dtpDatumVazenjaDo);
            this.metroTabPage2.Controls.Add(this.dtpDatumVazenjaOd);
            this.metroTabPage2.Controls.Add(this.btnSacuvajUredi);
            this.metroTabPage2.Controls.Add(this.txtLokacijaPreuzimanja);
            this.metroTabPage2.Controls.Add(this.txtKlijent);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1047, 768);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Uređivanje rezervacije";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnPoruka
            // 
            this.btnPoruka.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPoruka.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPoruka.Location = new System.Drawing.Point(887, 120);
            this.btnPoruka.Name = "btnPoruka";
            this.btnPoruka.Size = new System.Drawing.Size(129, 26);
            this.btnPoruka.TabIndex = 177;
            this.btnPoruka.Text = "Pošalji poruku";
            this.btnPoruka.UseSelectable = true;
            this.btnPoruka.Click += new System.EventHandler(this.btnPoruka_Click);
            // 
            // chbVracanjaUPoslovnicu
            // 
            this.chbVracanjaUPoslovnicu.AutoSize = true;
            this.chbVracanjaUPoslovnicu.Location = new System.Drawing.Point(707, 404);
            this.chbVracanjaUPoslovnicu.Name = "chbVracanjaUPoslovnicu";
            this.chbVracanjaUPoslovnicu.Size = new System.Drawing.Size(112, 15);
            this.chbVracanjaUPoslovnicu.TabIndex = 176;
            this.chbVracanjaUPoslovnicu.Text = "Kasko osiguranje";
            this.chbVracanjaUPoslovnicu.UseSelectable = true;
            // 
            // chbKasko
            // 
            this.chbKasko.AutoSize = true;
            this.chbKasko.Location = new System.Drawing.Point(707, 367);
            this.chbKasko.Name = "chbKasko";
            this.chbKasko.Size = new System.Drawing.Size(140, 15);
            this.chbKasko.TabIndex = 175;
            this.chbKasko.Text = "Povratak u poslovnicu";
            this.chbKasko.UseSelectable = true;
            // 
            // lblIznosBezPopusta
            // 
            this.lblIznosBezPopusta.AutoSize = true;
            this.lblIznosBezPopusta.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblIznosBezPopusta.Location = new System.Drawing.Point(887, 519);
            this.lblIznosBezPopusta.Name = "lblIznosBezPopusta";
            this.lblIznosBezPopusta.Size = new System.Drawing.Size(44, 15);
            this.lblIznosBezPopusta.TabIndex = 174;
            this.lblIznosBezPopusta.Text = "320 KM";
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel19.Location = new System.Drawing.Point(707, 519);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(107, 15);
            this.metroLabel19.TabIndex = 173;
            this.metroLabel19.Text = "Iznos bez popusta :";
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel18.Location = new System.Drawing.Point(704, 443);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(104, 15);
            this.metroLabel18.TabIndex = 172;
            this.metroLabel18.Text = "Iznos sa popustom";
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel17.Location = new System.Drawing.Point(414, 443);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(42, 15);
            this.metroLabel17.TabIndex = 171;
            this.metroLabel17.Text = "Popust";
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel16.Location = new System.Drawing.Point(414, 264);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(109, 15);
            this.metroLabel16.TabIndex = 170;
            this.metroLabel16.Text = "Lokacija preuzimanja";
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel15.Location = new System.Drawing.Point(74, 520);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(37, 15);
            this.metroLabel15.TabIndex = 169;
            this.metroLabel15.Text = "Vozilo";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(414, 111);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(141, 15);
            this.metroLabel10.TabIndex = 166;
            this.metroLabel10.Text = "Datum kreiranja rezervacije";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(74, 594);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(100, 15);
            this.metroLabel11.TabIndex = 165;
            this.metroLabel11.Text = "Reg. oznaka vozila";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel12.Location = new System.Drawing.Point(705, 263);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(44, 15);
            this.metroLabel12.TabIndex = 167;
            this.metroLabel12.Text = "Važi do";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel13.Location = new System.Drawing.Point(704, 189);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(44, 15);
            this.metroLabel13.TabIndex = 168;
            this.metroLabel13.Text = "Važi od";
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel14.Location = new System.Drawing.Point(414, 189);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(35, 15);
            this.metroLabel14.TabIndex = 164;
            this.metroLabel14.Text = "Klijent";
            // 
            // txtDatumKreiranjaRezervacije
            // 
            this.txtDatumKreiranjaRezervacije.Enabled = false;
            this.txtDatumKreiranjaRezervacije.Location = new System.Drawing.Point(414, 136);
            this.txtDatumKreiranjaRezervacije.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatumKreiranjaRezervacije.Name = "txtDatumKreiranjaRezervacije";
            this.txtDatumKreiranjaRezervacije.Size = new System.Drawing.Size(257, 26);
            this.txtDatumKreiranjaRezervacije.TabIndex = 163;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(869, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 161;
            // 
            // txtIznosSaPopustom
            // 
            this.txtIznosSaPopustom.Enabled = false;
            this.txtIznosSaPopustom.Location = new System.Drawing.Point(704, 468);
            this.txtIznosSaPopustom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIznosSaPopustom.Name = "txtIznosSaPopustom";
            this.txtIznosSaPopustom.Size = new System.Drawing.Size(257, 26);
            this.txtIznosSaPopustom.TabIndex = 160;
            // 
            // txtPopust
            // 
            this.txtPopust.Location = new System.Drawing.Point(414, 468);
            this.txtPopust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPopust.MaxLength = 3;
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.Size = new System.Drawing.Size(257, 26);
            this.txtPopust.TabIndex = 159;
            this.txtPopust.TextChanged += new System.EventHandler(this.txtPopust_TextChanged);
            this.txtPopust.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPopust_KeyPress);
            // 
            // txtRegOznake
            // 
            this.txtRegOznake.Enabled = false;
            this.txtRegOznake.Location = new System.Drawing.Point(74, 619);
            this.txtRegOznake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRegOznake.Name = "txtRegOznake";
            this.txtRegOznake.Size = new System.Drawing.Size(257, 26);
            this.txtRegOznake.TabIndex = 158;
            // 
            // txtVozilo
            // 
            this.txtVozilo.Enabled = false;
            this.txtVozilo.Location = new System.Drawing.Point(74, 545);
            this.txtVozilo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVozilo.Name = "txtVozilo";
            this.txtVozilo.Size = new System.Drawing.Size(257, 26);
            this.txtVozilo.TabIndex = 156;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarHireRC.WinUI.Properties.Resources.no_image;
            this.pictureBox1.Location = new System.Drawing.Point(31, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 406);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 154;
            this.pictureBox1.TabStop = false;
            // 
            // dtpDatumVazenjaDo
            // 
            this.dtpDatumVazenjaDo.Location = new System.Drawing.Point(704, 289);
            this.dtpDatumVazenjaDo.Name = "dtpDatumVazenjaDo";
            this.dtpDatumVazenjaDo.Size = new System.Drawing.Size(312, 26);
            this.dtpDatumVazenjaDo.TabIndex = 151;
            // 
            // dtpDatumVazenjaOd
            // 
            this.dtpDatumVazenjaOd.Location = new System.Drawing.Point(704, 215);
            this.dtpDatumVazenjaOd.Name = "dtpDatumVazenjaOd";
            this.dtpDatumVazenjaOd.Size = new System.Drawing.Size(312, 26);
            this.dtpDatumVazenjaOd.TabIndex = 150;
            // 
            // btnSacuvajUredi
            // 
            this.btnSacuvajUredi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSacuvajUredi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSacuvajUredi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSacuvajUredi.Location = new System.Drawing.Point(870, 643);
            this.btnSacuvajUredi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSacuvajUredi.Name = "btnSacuvajUredi";
            this.btnSacuvajUredi.Size = new System.Drawing.Size(146, 40);
            this.btnSacuvajUredi.TabIndex = 145;
            this.btnSacuvajUredi.Text = "Sačuvaj";
            this.btnSacuvajUredi.UseVisualStyleBackColor = false;
            this.btnSacuvajUredi.Click += new System.EventHandler(this.btnSacuvajUredi_Click);
            // 
            // txtLokacijaPreuzimanja
            // 
            this.txtLokacijaPreuzimanja.Location = new System.Drawing.Point(414, 289);
            this.txtLokacijaPreuzimanja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLokacijaPreuzimanja.Name = "txtLokacijaPreuzimanja";
            this.txtLokacijaPreuzimanja.Size = new System.Drawing.Size(257, 26);
            this.txtLokacijaPreuzimanja.TabIndex = 142;
            // 
            // txtKlijent
            // 
            this.txtKlijent.Enabled = false;
            this.txtKlijent.Location = new System.Drawing.Point(414, 215);
            this.txtKlijent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKlijent.Name = "txtKlijent";
            this.txtKlijent.Size = new System.Drawing.Size(257, 26);
            this.txtKlijent.TabIndex = 140;
            // 
            // frmRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 814);
            this.Controls.Add(this.metroTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRezervacije";
            this.Text = "frmRezervacije";
            this.Load += new System.EventHandler(this.frmRezervacije_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervacije)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.CheckBox chBDK;
        private System.Windows.Forms.TextBox txtSearchUsername;
        private System.Windows.Forms.TextBox txtRegOznaka;
        private System.Windows.Forms.ComboBox cmbSearchProizvodjac;
        private System.Windows.Forms.ComboBox cmbSearchModel;
        private System.Windows.Forms.DateTimePicker dtpDatumKreiranja;
        private System.Windows.Forms.TextBox txtSearchIme;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvRezervacije;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Od;
        private System.Windows.Forms.DataGridViewTextBoxColumn Do;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klijent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vozilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.TextBox txtSearchPrezime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbDo;
        private System.Windows.Forms.CheckBox chBOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox chbAktivan;
        private MetroFramework.Controls.MetroCheckBox chBoxKasko;
        private MetroFramework.Controls.MetroCheckBox chBoxVracanjeUPoslovnicu;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.TextBox txtDatumKreiranjaRezervacije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIznosSaPopustom;
        private System.Windows.Forms.TextBox txtPopust;
        private System.Windows.Forms.TextBox txtRegOznake;
        private System.Windows.Forms.TextBox txtVozilo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpDatumVazenjaDo;
        private System.Windows.Forms.DateTimePicker dtpDatumVazenjaOd;
        private System.Windows.Forms.Button btnSacuvajUredi;
        private System.Windows.Forms.TextBox txtLokacijaPreuzimanja;
        private System.Windows.Forms.TextBox txtKlijent;
        private MetroFramework.Controls.MetroCheckBox chbVracanjaUPoslovnicu;
        private MetroFramework.Controls.MetroCheckBox chbKasko;
        private MetroFramework.Controls.MetroLabel lblIznosBezPopusta;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroButton btnPoruka;
    }
}