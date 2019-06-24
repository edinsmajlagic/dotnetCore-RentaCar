namespace CarHireRC.WinUI.Klijenti
{
    partial class frmKlijenti
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
            this.components = new System.ComponentModel.Container();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.chbAktivan = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchPrezime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.chbDo = new System.Windows.Forms.CheckBox();
            this.chBOd = new System.Windows.Forms.CheckBox();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.txtSearchUsername = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKlijenti = new System.Windows.Forms.DataGridView();
            this.KorisnikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefonn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivann = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmbSearchGrad = new System.Windows.Forms.ComboBox();
            this.txtSearchIme = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.chBoxAktivan = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtDatumRegistracije = new System.Windows.Forms.TextBox();
            this.btnSacuvajUredi = new System.Windows.Forms.Button();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.txtDatumRodjenja = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(-1, 1);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1054, 812);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.chbAktivan);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.metroLabel3);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txtSearchPrezime);
            this.metroTabPage1.Controls.Add(this.groupBox2);
            this.metroTabPage1.Controls.Add(this.txtSearchUsername);
            this.metroTabPage1.Controls.Add(this.groupBox1);
            this.metroTabPage1.Controls.Add(this.cmbSearchGrad);
            this.metroTabPage1.Controls.Add(this.txtSearchIme);
            this.metroTabPage1.Controls.Add(this.btnPrikazi);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1046, 770);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Lista klijenata";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // chbAktivan
            // 
            this.chbAktivan.AutoSize = true;
            this.chbAktivan.Location = new System.Drawing.Point(331, 212);
            this.chbAktivan.Name = "chbAktivan";
            this.chbAktivan.Size = new System.Drawing.Size(63, 15);
            this.chbAktivan.TabIndex = 114;
            this.chbAktivan.Text = "Aktivan";
            this.chbAktivan.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(247, 34);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(48, 15);
            this.metroLabel4.TabIndex = 113;
            this.metroLabel4.Text = "Prezime";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(48, 174);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(32, 15);
            this.metroLabel3.TabIndex = 112;
            this.metroLabel3.Text = "Grad";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(48, 106);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 15);
            this.metroLabel2.TabIndex = 111;
            this.metroLabel2.Text = "Username";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(48, 36);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(26, 15);
            this.metroLabel1.TabIndex = 110;
            this.metroLabel1.Text = "Ime";
            // 
            // txtSearchPrezime
            // 
            this.txtSearchPrezime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchPrezime.Location = new System.Drawing.Point(247, 59);
            this.txtSearchPrezime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchPrezime.MaxLength = 50;
            this.txtSearchPrezime.Name = "txtSearchPrezime";
            this.txtSearchPrezime.Size = new System.Drawing.Size(160, 26);
            this.txtSearchPrezime.TabIndex = 90;
            this.txtSearchPrezime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPrezime_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.metroLabel6);
            this.groupBox2.Controls.Add(this.metroLabel5);
            this.groupBox2.Controls.Add(this.chbDo);
            this.groupBox2.Controls.Add(this.chBOd);
            this.groupBox2.Controls.Add(this.dtpDo);
            this.groupBox2.Controls.Add(this.dtpOd);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(499, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(373, 174);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datum registracije";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(22, 113);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(22, 15);
            this.metroLabel6.TabIndex = 116;
            this.metroLabel6.Text = "Do";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(22, 46);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(23, 15);
            this.metroLabel5.TabIndex = 115;
            this.metroLabel5.Text = "Od";
            // 
            // chbDo
            // 
            this.chbDo.Location = new System.Drawing.Point(331, 136);
            this.chbDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbDo.Name = "chbDo";
            this.chbDo.Size = new System.Drawing.Size(30, 31);
            this.chbDo.TabIndex = 107;
            this.chbDo.UseVisualStyleBackColor = true;
            this.chbDo.CheckedChanged += new System.EventHandler(this.chbDo_CheckedChanged);
            // 
            // chBOd
            // 
            this.chBOd.Location = new System.Drawing.Point(331, 70);
            this.chBOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBOd.Name = "chBOd";
            this.chBOd.Size = new System.Drawing.Size(30, 29);
            this.chBOd.TabIndex = 108;
            this.chBOd.UseVisualStyleBackColor = true;
            this.chBOd.CheckedChanged += new System.EventHandler(this.chBOd_CheckedChanged);
            // 
            // dtpDo
            // 
            this.dtpDo.Enabled = false;
            this.dtpDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDo.Location = new System.Drawing.Point(22, 138);
            this.dtpDo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDo.MaxDate = new System.DateTime(2019, 5, 21, 0, 0, 0, 0);
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
            this.dtpOd.Location = new System.Drawing.Point(22, 71);
            this.dtpOd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpOd.MaxDate = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            this.dtpOd.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(300, 26);
            this.dtpOd.TabIndex = 64;
            this.dtpOd.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.Location = new System.Drawing.Point(48, 131);
            this.txtSearchUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchUsername.MaxLength = 50;
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.Size = new System.Drawing.Size(360, 26);
            this.txtSearchUsername.TabIndex = 92;
            this.txtSearchUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchUsername_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvKlijenti);
            this.groupBox1.Location = new System.Drawing.Point(3, 256);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1041, 414);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Klijenti";
            // 
            // dgvKlijenti
            // 
            this.dgvKlijenti.AllowUserToAddRows = false;
            this.dgvKlijenti.AllowUserToDeleteRows = false;
            this.dgvKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKlijenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikId,
            this.KorisnickoIme,
            this.Email,
            this.DatumReg,
            this.Telefonn,
            this.Aktivann});
            this.dgvKlijenti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKlijenti.Location = new System.Drawing.Point(3, 21);
            this.dgvKlijenti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvKlijenti.Name = "dgvKlijenti";
            this.dgvKlijenti.ReadOnly = true;
            this.dgvKlijenti.RowTemplate.Height = 24;
            this.dgvKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKlijenti.Size = new System.Drawing.Size(1035, 391);
            this.dgvKlijenti.TabIndex = 0;
            this.dgvKlijenti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvKlijenti_MouseDoubleClick);
            // 
            // KorisnikId
            // 
            this.KorisnikId.DataPropertyName = "KlijentId";
            this.KorisnikId.HeaderText = "KlijentId";
            this.KorisnikId.Name = "KorisnikId";
            this.KorisnikId.ReadOnly = true;
            this.KorisnikId.Visible = false;
            this.KorisnikId.Width = 140;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "UserName";
            this.KorisnickoIme.HeaderText = "Korisničko ime";
            this.KorisnickoIme.Name = "KorisnickoIme";
            this.KorisnickoIme.ReadOnly = true;
            this.KorisnickoIme.ToolTipText = "Korisničko ime";
            this.KorisnickoIme.Width = 130;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.ToolTipText = "Email";
            // 
            // DatumReg
            // 
            this.DatumReg.DataPropertyName = "DatumRegistracije";
            this.DatumReg.HeaderText = "Datum registracije";
            this.DatumReg.Name = "DatumReg";
            this.DatumReg.ReadOnly = true;
            this.DatumReg.ToolTipText = "Datum registracije";
            this.DatumReg.Width = 130;
            // 
            // Telefonn
            // 
            this.Telefonn.DataPropertyName = "Telefon";
            this.Telefonn.HeaderText = "Telefon";
            this.Telefonn.Name = "Telefonn";
            this.Telefonn.ReadOnly = true;
            this.Telefonn.ToolTipText = "Telefon";
            this.Telefonn.Width = 120;
            // 
            // Aktivann
            // 
            this.Aktivann.DataPropertyName = "Status";
            this.Aktivann.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Aktivann.HeaderText = "Aktivan";
            this.Aktivann.Name = "Aktivann";
            this.Aktivann.ReadOnly = true;
            this.Aktivann.ToolTipText = "Aktivan";
            this.Aktivann.Width = 120;
            // 
            // cmbSearchGrad
            // 
            this.cmbSearchGrad.FormattingEnabled = true;
            this.cmbSearchGrad.Location = new System.Drawing.Point(48, 199);
            this.cmbSearchGrad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSearchGrad.Name = "cmbSearchGrad";
            this.cmbSearchGrad.Size = new System.Drawing.Size(224, 28);
            this.cmbSearchGrad.TabIndex = 85;
            // 
            // txtSearchIme
            // 
            this.txtSearchIme.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchIme.Location = new System.Drawing.Point(48, 61);
            this.txtSearchIme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchIme.MaxLength = 50;
            this.txtSearchIme.Name = "txtSearchIme";
            this.txtSearchIme.Size = new System.Drawing.Size(160, 26);
            this.txtSearchIme.TabIndex = 83;
            this.txtSearchIme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchIme_KeyPress);
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPrikazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrikazi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrikazi.Location = new System.Drawing.Point(926, 190);
            this.btnPrikazi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(115, 42);
            this.btnPrikazi.TabIndex = 82;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = false;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.txtGrad);
            this.metroTabPage2.Controls.Add(this.metroLabel15);
            this.metroTabPage2.Controls.Add(this.metroLabel14);
            this.metroTabPage2.Controls.Add(this.metroLabel13);
            this.metroTabPage2.Controls.Add(this.metroLabel12);
            this.metroTabPage2.Controls.Add(this.metroLabel11);
            this.metroTabPage2.Controls.Add(this.chBoxAktivan);
            this.metroTabPage2.Controls.Add(this.metroLabel7);
            this.metroTabPage2.Controls.Add(this.metroLabel8);
            this.metroTabPage2.Controls.Add(this.metroLabel9);
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.txtTelefon);
            this.metroTabPage2.Controls.Add(this.txtDatumRegistracije);
            this.metroTabPage2.Controls.Add(this.btnSacuvajUredi);
            this.metroTabPage2.Controls.Add(this.txtAdresa);
            this.metroTabPage2.Controls.Add(this.txtDatumRodjenja);
            this.metroTabPage2.Controls.Add(this.txtUsername);
            this.metroTabPage2.Controls.Add(this.txtPrezime);
            this.metroTabPage2.Controls.Add(this.txtEmail);
            this.metroTabPage2.Controls.Add(this.txtIme);
            this.metroTabPage2.Controls.Add(this.pictureBox1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1046, 770);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Uređivanje podataka o klijentu";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // txtGrad
            // 
            this.txtGrad.Enabled = false;
            this.txtGrad.Location = new System.Drawing.Point(438, 440);
            this.txtGrad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Size = new System.Drawing.Size(257, 26);
            this.txtGrad.TabIndex = 142;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel15.Location = new System.Drawing.Point(740, 415);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(43, 15);
            this.metroLabel15.TabIndex = 140;
            this.metroLabel15.Text = "Adresa";
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel14.Location = new System.Drawing.Point(438, 334);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(41, 15);
            this.metroLabel14.TabIndex = 139;
            this.metroLabel14.Text = "Telefon";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel13.Location = new System.Drawing.Point(740, 253);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(97, 15);
            this.metroLabel13.TabIndex = 138;
            this.metroLabel13.Text = "Datum registracije";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel12.Location = new System.Drawing.Point(438, 253);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(82, 15);
            this.metroLabel12.TabIndex = 137;
            this.metroLabel12.Text = "Datum rođenja";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(438, 171);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(33, 15);
            this.metroLabel11.TabIndex = 136;
            this.metroLabel11.Text = "Email";
            // 
            // chBoxAktivan
            // 
            this.chBoxAktivan.AutoSize = true;
            this.chBoxAktivan.Location = new System.Drawing.Point(741, 544);
            this.chBoxAktivan.Name = "chBoxAktivan";
            this.chBoxAktivan.Size = new System.Drawing.Size(63, 15);
            this.chBoxAktivan.TabIndex = 135;
            this.chBoxAktivan.Text = "Aktivan";
            this.chBoxAktivan.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(741, 90);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(48, 15);
            this.metroLabel7.TabIndex = 134;
            this.metroLabel7.Text = "Prezime";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(438, 415);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(32, 15);
            this.metroLabel8.TabIndex = 133;
            this.metroLabel8.Text = "Grad";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(740, 171);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(58, 15);
            this.metroLabel9.TabIndex = 132;
            this.metroLabel9.Text = "Username";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(438, 90);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(26, 15);
            this.metroLabel10.TabIndex = 131;
            this.metroLabel10.Text = "Ime";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Enabled = false;
            this.txtTelefon.Location = new System.Drawing.Point(438, 359);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(257, 26);
            this.txtTelefon.TabIndex = 127;
            // 
            // txtDatumRegistracije
            // 
            this.txtDatumRegistracije.Enabled = false;
            this.txtDatumRegistracije.Location = new System.Drawing.Point(741, 278);
            this.txtDatumRegistracije.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatumRegistracije.Name = "txtDatumRegistracije";
            this.txtDatumRegistracije.Size = new System.Drawing.Size(257, 26);
            this.txtDatumRegistracije.TabIndex = 125;
            // 
            // btnSacuvajUredi
            // 
            this.btnSacuvajUredi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSacuvajUredi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSacuvajUredi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSacuvajUredi.Location = new System.Drawing.Point(849, 633);
            this.btnSacuvajUredi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSacuvajUredi.Name = "btnSacuvajUredi";
            this.btnSacuvajUredi.Size = new System.Drawing.Size(146, 40);
            this.btnSacuvajUredi.TabIndex = 122;
            this.btnSacuvajUredi.Text = "Sačuvaj";
            this.btnSacuvajUredi.UseVisualStyleBackColor = false;
            this.btnSacuvajUredi.Click += new System.EventHandler(this.btnSacuvajUredi_Click);
            // 
            // txtAdresa
            // 
            this.txtAdresa.Enabled = false;
            this.txtAdresa.Location = new System.Drawing.Point(740, 440);
            this.txtAdresa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(257, 26);
            this.txtAdresa.TabIndex = 121;
            // 
            // txtDatumRodjenja
            // 
            this.txtDatumRodjenja.Enabled = false;
            this.txtDatumRodjenja.Location = new System.Drawing.Point(438, 278);
            this.txtDatumRodjenja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDatumRodjenja.Name = "txtDatumRodjenja";
            this.txtDatumRodjenja.Size = new System.Drawing.Size(257, 26);
            this.txtDatumRodjenja.TabIndex = 117;
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(741, 196);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(257, 26);
            this.txtUsername.TabIndex = 115;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Enabled = false;
            this.txtPrezime.Location = new System.Drawing.Point(741, 115);
            this.txtPrezime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrezime.MaxLength = 50;
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(257, 26);
            this.txtPrezime.TabIndex = 113;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(438, 196);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(257, 26);
            this.txtEmail.TabIndex = 111;
            // 
            // txtIme
            // 
            this.txtIme.Enabled = false;
            this.txtIme.Location = new System.Drawing.Point(438, 115);
            this.txtIme.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIme.MaxLength = 50;
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(257, 26);
            this.txtIme.TabIndex = 109;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarHireRC.WinUI.Properties.Resources.noImage;
            this.pictureBox1.Location = new System.Drawing.Point(48, 78);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 406);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 123;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmKlijenti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 814);
            this.Controls.Add(this.metroTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKlijenti";
            this.Text = "frmKlijenti";
            this.Load += new System.EventHandler(this.frmKlijenti_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKlijenti)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.TextBox txtSearchPrezime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbDo;
        private System.Windows.Forms.CheckBox chBOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.TextBox txtSearchUsername;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKlijenti;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefonn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivann;
        private System.Windows.Forms.ComboBox cmbSearchGrad;
        private System.Windows.Forms.TextBox txtSearchIme;
        private System.Windows.Forms.Button btnPrikazi;
        private MetroFramework.Controls.MetroCheckBox chbAktivan;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtDatumRegistracije;
        private System.Windows.Forms.Button btnSacuvajUredi;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.TextBox txtDatumRodjenja;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroCheckBox chBoxAktivan;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.TextBox txtGrad;
    }
}