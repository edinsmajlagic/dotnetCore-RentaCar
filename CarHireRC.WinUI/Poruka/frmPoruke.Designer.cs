namespace CarHireRC.WinUI.Poruka
{
    partial class frmPoruke
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPrimljenePoruke = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchPrezimePosiljaoc = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.chbDoPrimljene = new System.Windows.Forms.CheckBox();
            this.chBOdPrimljene = new System.Windows.Forms.CheckBox();
            this.dtpDoPrimljene = new System.Windows.Forms.DateTimePicker();
            this.dtpOdPrimljene = new System.Windows.Forms.DateTimePicker();
            this.txtSearchUsernamePosiljaoc = new System.Windows.Forms.TextBox();
            this.txtSearchImePosiljaoc = new System.Windows.Forms.TextBox();
            this.btnPrikaziPrimljene = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPoruka = new MetroFramework.Controls.MetroButton();
            this.lblspp = new System.Windows.Forms.Label();
            this.lblnp = new System.Windows.Forms.Label();
            this.lblNaslovPrimljene = new System.Windows.Forms.Label();
            this.lblDatumVrijemePrimljene = new System.Windows.Forms.Label();
            this.lblPosiljaoc = new System.Windows.Forms.Label();
            this.lbldvp = new System.Windows.Forms.Label();
            this.lblpp = new System.Windows.Forms.Label();
            this.rtxtSadrzajPrimljene = new System.Windows.Forms.RichTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtSearchPrezimePrimaoc = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.cbDoPoslane = new System.Windows.Forms.CheckBox();
            this.cbOdPoslane = new System.Windows.Forms.CheckBox();
            this.dtpDoPoslane = new System.Windows.Forms.DateTimePicker();
            this.dtpOdPoslane = new System.Windows.Forms.DateTimePicker();
            this.txtSearchUsernamePrimaoc = new System.Windows.Forms.TextBox();
            this.txtSearchImePrimaoc = new System.Windows.Forms.TextBox();
            this.btnPrikaziPoslane = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblsppo = new System.Windows.Forms.Label();
            this.lblnpo = new System.Windows.Forms.Label();
            this.lblNaslovPoslane = new System.Windows.Forms.Label();
            this.lblDatumVrijemePoslane = new System.Windows.Forms.Label();
            this.lblPrimaoc = new System.Windows.Forms.Label();
            this.lbldvpo = new System.Windows.Forms.Label();
            this.lblppo = new System.Windows.Forms.Label();
            this.rtxtSadrzajPoslane = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvPoslanePoruke = new System.Windows.Forms.DataGridView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.PorukaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Primaoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimljenePoruke)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslanePoruke)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(1, 1);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1054, 812);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.groupBox1);
            this.metroTabPage1.Controls.Add(this.metroLabel4);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txtSearchPrezimePosiljaoc);
            this.metroTabPage1.Controls.Add(this.groupBox3);
            this.metroTabPage1.Controls.Add(this.txtSearchUsernamePosiljaoc);
            this.metroTabPage1.Controls.Add(this.txtSearchImePosiljaoc);
            this.metroTabPage1.Controls.Add(this.btnPrikaziPrimljene);
            this.metroTabPage1.Controls.Add(this.groupBox2);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1046, 770);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Primljene poruke";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPrimljenePoruke);
            this.groupBox1.Location = new System.Drawing.Point(9, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 427);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Poruke";
            // 
            // dgvPrimljenePoruke
            // 
            this.dgvPrimljenePoruke.AllowUserToAddRows = false;
            this.dgvPrimljenePoruke.AllowUserToDeleteRows = false;
            this.dgvPrimljenePoruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrimljenePoruke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvPrimljenePoruke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrimljenePoruke.Location = new System.Drawing.Point(3, 22);
            this.dgvPrimljenePoruke.Name = "dgvPrimljenePoruke";
            this.dgvPrimljenePoruke.ReadOnly = true;
            this.dgvPrimljenePoruke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrimljenePoruke.Size = new System.Drawing.Size(504, 402);
            this.dgvPrimljenePoruke.TabIndex = 0;
            this.dgvPrimljenePoruke.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPrimljenePoruke_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PorukaId";
            this.dataGridViewTextBoxColumn1.HeaderText = "PorukaId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PosiljaocInfo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Pošiljaoc";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Naslov";
            this.dataGridViewTextBoxColumn3.HeaderText = "Naslov";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 260;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(230, 15);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(100, 15);
            this.metroLabel4.TabIndex = 121;
            this.metroLabel4.Text = "Prezime pošiljaoca";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(30, 102);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(110, 15);
            this.metroLabel2.TabIndex = 120;
            this.metroLabel2.Text = "Username pošiljaoca";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(30, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 15);
            this.metroLabel1.TabIndex = 119;
            this.metroLabel1.Text = "Ime pošiljaoca";
            // 
            // txtSearchPrezimePosiljaoc
            // 
            this.txtSearchPrezimePosiljaoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchPrezimePosiljaoc.Location = new System.Drawing.Point(230, 40);
            this.txtSearchPrezimePosiljaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchPrezimePosiljaoc.MaxLength = 50;
            this.txtSearchPrezimePosiljaoc.Name = "txtSearchPrezimePosiljaoc";
            this.txtSearchPrezimePosiljaoc.Size = new System.Drawing.Size(160, 26);
            this.txtSearchPrezimePosiljaoc.TabIndex = 117;
            this.txtSearchPrezimePosiljaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPrezimePosiljaoc_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.metroLabel6);
            this.groupBox3.Controls.Add(this.metroLabel5);
            this.groupBox3.Controls.Add(this.chbDoPrimljene);
            this.groupBox3.Controls.Add(this.chBOdPrimljene);
            this.groupBox3.Controls.Add(this.dtpDoPrimljene);
            this.groupBox3.Controls.Add(this.dtpOdPrimljene);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(490, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(373, 174);
            this.groupBox3.TabIndex = 116;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datum slanja";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.Location = new System.Drawing.Point(22, 107);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(22, 15);
            this.metroLabel6.TabIndex = 116;
            this.metroLabel6.Text = "Do";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(22, 40);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(23, 15);
            this.metroLabel5.TabIndex = 115;
            this.metroLabel5.Text = "Od";
            // 
            // chbDoPrimljene
            // 
            this.chbDoPrimljene.Location = new System.Drawing.Point(331, 130);
            this.chbDoPrimljene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbDoPrimljene.Name = "chbDoPrimljene";
            this.chbDoPrimljene.Size = new System.Drawing.Size(30, 31);
            this.chbDoPrimljene.TabIndex = 107;
            this.chbDoPrimljene.UseVisualStyleBackColor = true;
            this.chbDoPrimljene.CheckedChanged += new System.EventHandler(this.chbDoPrimljene_CheckedChanged);
            // 
            // chBOdPrimljene
            // 
            this.chBOdPrimljene.Location = new System.Drawing.Point(331, 64);
            this.chBOdPrimljene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chBOdPrimljene.Name = "chBOdPrimljene";
            this.chBOdPrimljene.Size = new System.Drawing.Size(30, 29);
            this.chBOdPrimljene.TabIndex = 108;
            this.chBOdPrimljene.UseVisualStyleBackColor = true;
            this.chBOdPrimljene.CheckedChanged += new System.EventHandler(this.chBOdPrimljene_CheckedChanged);
            // 
            // dtpDoPrimljene
            // 
            this.dtpDoPrimljene.Enabled = false;
            this.dtpDoPrimljene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDoPrimljene.Location = new System.Drawing.Point(22, 136);
            this.dtpDoPrimljene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDoPrimljene.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpDoPrimljene.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpDoPrimljene.Name = "dtpDoPrimljene";
            this.dtpDoPrimljene.Size = new System.Drawing.Size(300, 26);
            this.dtpDoPrimljene.TabIndex = 67;
            this.dtpDoPrimljene.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // dtpOdPrimljene
            // 
            this.dtpOdPrimljene.Enabled = false;
            this.dtpOdPrimljene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOdPrimljene.Location = new System.Drawing.Point(22, 65);
            this.dtpOdPrimljene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpOdPrimljene.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpOdPrimljene.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpOdPrimljene.Name = "dtpOdPrimljene";
            this.dtpOdPrimljene.Size = new System.Drawing.Size(300, 26);
            this.dtpOdPrimljene.TabIndex = 64;
            this.dtpOdPrimljene.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // txtSearchUsernamePosiljaoc
            // 
            this.txtSearchUsernamePosiljaoc.Location = new System.Drawing.Point(30, 127);
            this.txtSearchUsernamePosiljaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchUsernamePosiljaoc.MaxLength = 50;
            this.txtSearchUsernamePosiljaoc.Name = "txtSearchUsernamePosiljaoc";
            this.txtSearchUsernamePosiljaoc.Size = new System.Drawing.Size(360, 26);
            this.txtSearchUsernamePosiljaoc.TabIndex = 118;
            this.txtSearchUsernamePosiljaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchUsernamePosiljaoc_KeyPress);
            // 
            // txtSearchImePosiljaoc
            // 
            this.txtSearchImePosiljaoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchImePosiljaoc.Location = new System.Drawing.Point(31, 40);
            this.txtSearchImePosiljaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchImePosiljaoc.MaxLength = 50;
            this.txtSearchImePosiljaoc.Name = "txtSearchImePosiljaoc";
            this.txtSearchImePosiljaoc.Size = new System.Drawing.Size(160, 26);
            this.txtSearchImePosiljaoc.TabIndex = 115;
            this.txtSearchImePosiljaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchImePosiljaoc_KeyPress);
            // 
            // btnPrikaziPrimljene
            // 
            this.btnPrikaziPrimljene.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPrikaziPrimljene.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrikaziPrimljene.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrikaziPrimljene.Location = new System.Drawing.Point(923, 141);
            this.btnPrikaziPrimljene.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrikaziPrimljene.Name = "btnPrikaziPrimljene";
            this.btnPrikaziPrimljene.Size = new System.Drawing.Size(115, 42);
            this.btnPrikaziPrimljene.TabIndex = 114;
            this.btnPrikaziPrimljene.Text = "Filtriraj";
            this.btnPrikaziPrimljene.UseVisualStyleBackColor = false;
            this.btnPrikaziPrimljene.Click += new System.EventHandler(this.btnPrikaziPrimljene_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroButton1);
            this.groupBox2.Controls.Add(this.btnPoruka);
            this.groupBox2.Controls.Add(this.lblspp);
            this.groupBox2.Controls.Add(this.lblnp);
            this.groupBox2.Controls.Add(this.lblNaslovPrimljene);
            this.groupBox2.Controls.Add(this.lblDatumVrijemePrimljene);
            this.groupBox2.Controls.Add(this.lblPosiljaoc);
            this.groupBox2.Controls.Add(this.lbldvp);
            this.groupBox2.Controls.Add(this.lblpp);
            this.groupBox2.Controls.Add(this.rtxtSadrzajPrimljene);
            this.groupBox2.Location = new System.Drawing.Point(525, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 427);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // btnPoruka
            // 
            this.btnPoruka.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPoruka.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPoruka.Location = new System.Drawing.Point(350, 387);
            this.btnPoruka.Name = "btnPoruka";
            this.btnPoruka.Size = new System.Drawing.Size(129, 32);
            this.btnPoruka.TabIndex = 178;
            this.btnPoruka.Text = "Odgovori";
            this.btnPoruka.UseSelectable = true;
            this.btnPoruka.Visible = false;
            this.btnPoruka.Click += new System.EventHandler(this.btnPoruka_Click);
            // 
            // lblspp
            // 
            this.lblspp.AutoSize = true;
            this.lblspp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblspp.Location = new System.Drawing.Point(37, 190);
            this.lblspp.Name = "lblspp";
            this.lblspp.Size = new System.Drawing.Size(140, 20);
            this.lblspp.TabIndex = 27;
            this.lblspp.Text = "Sadržaj poruke :";
            this.lblspp.Visible = false;
            // 
            // lblnp
            // 
            this.lblnp.AutoSize = true;
            this.lblnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblnp.Location = new System.Drawing.Point(37, 148);
            this.lblnp.Name = "lblnp";
            this.lblnp.Size = new System.Drawing.Size(72, 20);
            this.lblnp.TabIndex = 26;
            this.lblnp.Text = "Naslov :";
            this.lblnp.Visible = false;
            // 
            // lblNaslovPrimljene
            // 
            this.lblNaslovPrimljene.AutoSize = true;
            this.lblNaslovPrimljene.Location = new System.Drawing.Point(123, 148);
            this.lblNaslovPrimljene.Name = "lblNaslovPrimljene";
            this.lblNaslovPrimljene.Size = new System.Drawing.Size(51, 20);
            this.lblNaslovPrimljene.TabIndex = 25;
            this.lblNaslovPrimljene.Text = "Klijent";
            this.lblNaslovPrimljene.Visible = false;
            // 
            // lblDatumVrijemePrimljene
            // 
            this.lblDatumVrijemePrimljene.AutoSize = true;
            this.lblDatumVrijemePrimljene.Location = new System.Drawing.Point(243, 53);
            this.lblDatumVrijemePrimljene.Name = "lblDatumVrijemePrimljene";
            this.lblDatumVrijemePrimljene.Size = new System.Drawing.Size(117, 20);
            this.lblDatumVrijemePrimljene.TabIndex = 24;
            this.lblDatumVrijemePrimljene.Text = "Datum i vrijeme";
            this.lblDatumVrijemePrimljene.Visible = false;
            // 
            // lblPosiljaoc
            // 
            this.lblPosiljaoc.AutoSize = true;
            this.lblPosiljaoc.Location = new System.Drawing.Point(243, 95);
            this.lblPosiljaoc.Name = "lblPosiljaoc";
            this.lblPosiljaoc.Size = new System.Drawing.Size(51, 20);
            this.lblPosiljaoc.TabIndex = 23;
            this.lblPosiljaoc.Text = "Klijent";
            this.lblPosiljaoc.Visible = false;
            // 
            // lbldvp
            // 
            this.lbldvp.AutoSize = true;
            this.lbldvp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbldvp.Location = new System.Drawing.Point(37, 53);
            this.lbldvp.Name = "lbldvp";
            this.lbldvp.Size = new System.Drawing.Size(194, 20);
            this.lbldvp.TabIndex = 22;
            this.lbldvp.Text = "Datum i vrijeme slanja :";
            this.lbldvp.Visible = false;
            // 
            // lblpp
            // 
            this.lblpp.AutoSize = true;
            this.lblpp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblpp.Location = new System.Drawing.Point(37, 95);
            this.lblpp.Name = "lblpp";
            this.lblpp.Size = new System.Drawing.Size(90, 20);
            this.lblpp.TabIndex = 21;
            this.lblpp.Text = "Pošiljaoc :";
            this.lblpp.Visible = false;
            // 
            // rtxtSadrzajPrimljene
            // 
            this.rtxtSadrzajPrimljene.BackColor = System.Drawing.Color.White;
            this.rtxtSadrzajPrimljene.Location = new System.Drawing.Point(38, 213);
            this.rtxtSadrzajPrimljene.Name = "rtxtSadrzajPrimljene";
            this.rtxtSadrzajPrimljene.ReadOnly = true;
            this.rtxtSadrzajPrimljene.Size = new System.Drawing.Size(441, 168);
            this.rtxtSadrzajPrimljene.TabIndex = 20;
            this.rtxtSadrzajPrimljene.Text = "";
            this.rtxtSadrzajPrimljene.Visible = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.metroLabel7);
            this.metroTabPage2.Controls.Add(this.metroLabel8);
            this.metroTabPage2.Controls.Add(this.txtSearchPrezimePrimaoc);
            this.metroTabPage2.Controls.Add(this.groupBox4);
            this.metroTabPage2.Controls.Add(this.txtSearchUsernamePrimaoc);
            this.metroTabPage2.Controls.Add(this.txtSearchImePrimaoc);
            this.metroTabPage2.Controls.Add(this.btnPrikaziPoslane);
            this.metroTabPage2.Controls.Add(this.groupBox5);
            this.metroTabPage2.Controls.Add(this.groupBox6);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1046, 770);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Poslane poruke";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(230, 15);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 15);
            this.metroLabel3.TabIndex = 131;
            this.metroLabel3.Text = "Prezime primaoca";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(30, 103);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(108, 15);
            this.metroLabel7.TabIndex = 130;
            this.metroLabel7.Text = "Username primaoca";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Location = new System.Drawing.Point(31, 15);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(76, 15);
            this.metroLabel8.TabIndex = 129;
            this.metroLabel8.Text = "Ime primaoca";
            // 
            // txtSearchPrezimePrimaoc
            // 
            this.txtSearchPrezimePrimaoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchPrezimePrimaoc.Location = new System.Drawing.Point(230, 40);
            this.txtSearchPrezimePrimaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchPrezimePrimaoc.MaxLength = 50;
            this.txtSearchPrezimePrimaoc.Name = "txtSearchPrezimePrimaoc";
            this.txtSearchPrezimePrimaoc.Size = new System.Drawing.Size(160, 26);
            this.txtSearchPrezimePrimaoc.TabIndex = 127;
            this.txtSearchPrezimePrimaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPrezimePrimaoc_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.metroLabel9);
            this.groupBox4.Controls.Add(this.metroLabel10);
            this.groupBox4.Controls.Add(this.cbDoPoslane);
            this.groupBox4.Controls.Add(this.cbOdPoslane);
            this.groupBox4.Controls.Add(this.dtpDoPoslane);
            this.groupBox4.Controls.Add(this.dtpOdPoslane);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox4.Location = new System.Drawing.Point(490, 10);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(373, 174);
            this.groupBox4.TabIndex = 126;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datum slanja";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Location = new System.Drawing.Point(22, 110);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(22, 15);
            this.metroLabel9.TabIndex = 116;
            this.metroLabel9.Text = "Do";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Location = new System.Drawing.Point(22, 43);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(23, 15);
            this.metroLabel10.TabIndex = 115;
            this.metroLabel10.Text = "Od";
            // 
            // cbDoPoslane
            // 
            this.cbDoPoslane.Location = new System.Drawing.Point(331, 137);
            this.cbDoPoslane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDoPoslane.Name = "cbDoPoslane";
            this.cbDoPoslane.Size = new System.Drawing.Size(30, 31);
            this.cbDoPoslane.TabIndex = 107;
            this.cbDoPoslane.UseVisualStyleBackColor = true;
            this.cbDoPoslane.CheckedChanged += new System.EventHandler(this.cbDoPoslane_CheckedChanged);
            // 
            // cbOdPoslane
            // 
            this.cbOdPoslane.Location = new System.Drawing.Point(331, 67);
            this.cbOdPoslane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOdPoslane.Name = "cbOdPoslane";
            this.cbOdPoslane.Size = new System.Drawing.Size(30, 29);
            this.cbOdPoslane.TabIndex = 108;
            this.cbOdPoslane.UseVisualStyleBackColor = true;
            this.cbOdPoslane.CheckedChanged += new System.EventHandler(this.cbOdPoslane_CheckedChanged);
            // 
            // dtpDoPoslane
            // 
            this.dtpDoPoslane.Enabled = false;
            this.dtpDoPoslane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDoPoslane.Location = new System.Drawing.Point(22, 138);
            this.dtpDoPoslane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDoPoslane.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpDoPoslane.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpDoPoslane.Name = "dtpDoPoslane";
            this.dtpDoPoslane.Size = new System.Drawing.Size(300, 26);
            this.dtpDoPoslane.TabIndex = 67;
            this.dtpDoPoslane.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // dtpOdPoslane
            // 
            this.dtpOdPoslane.Enabled = false;
            this.dtpOdPoslane.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpOdPoslane.Location = new System.Drawing.Point(22, 68);
            this.dtpOdPoslane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpOdPoslane.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.dtpOdPoslane.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtpOdPoslane.Name = "dtpOdPoslane";
            this.dtpOdPoslane.Size = new System.Drawing.Size(300, 26);
            this.dtpOdPoslane.TabIndex = 64;
            this.dtpOdPoslane.Value = new System.DateTime(2019, 5, 10, 0, 0, 0, 0);
            // 
            // txtSearchUsernamePrimaoc
            // 
            this.txtSearchUsernamePrimaoc.Location = new System.Drawing.Point(30, 128);
            this.txtSearchUsernamePrimaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchUsernamePrimaoc.MaxLength = 50;
            this.txtSearchUsernamePrimaoc.Name = "txtSearchUsernamePrimaoc";
            this.txtSearchUsernamePrimaoc.Size = new System.Drawing.Size(360, 26);
            this.txtSearchUsernamePrimaoc.TabIndex = 128;
            this.txtSearchUsernamePrimaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchUsernamePrimaoc_KeyPress);
            // 
            // txtSearchImePrimaoc
            // 
            this.txtSearchImePrimaoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchImePrimaoc.Location = new System.Drawing.Point(31, 40);
            this.txtSearchImePrimaoc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchImePrimaoc.MaxLength = 50;
            this.txtSearchImePrimaoc.Name = "txtSearchImePrimaoc";
            this.txtSearchImePrimaoc.Size = new System.Drawing.Size(160, 26);
            this.txtSearchImePrimaoc.TabIndex = 125;
            this.txtSearchImePrimaoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchImePrimaoc_KeyPress);
            // 
            // btnPrikaziPoslane
            // 
            this.btnPrikaziPoslane.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPrikaziPoslane.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrikaziPoslane.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrikaziPoslane.Location = new System.Drawing.Point(923, 142);
            this.btnPrikaziPoslane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrikaziPoslane.Name = "btnPrikaziPoslane";
            this.btnPrikaziPoslane.Size = new System.Drawing.Size(115, 42);
            this.btnPrikaziPoslane.TabIndex = 124;
            this.btnPrikaziPoslane.Text = "Filtriraj";
            this.btnPrikaziPoslane.UseVisualStyleBackColor = false;
            this.btnPrikaziPoslane.Click += new System.EventHandler(this.btnPrikaziPoslane_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblsppo);
            this.groupBox5.Controls.Add(this.lblnpo);
            this.groupBox5.Controls.Add(this.lblNaslovPoslane);
            this.groupBox5.Controls.Add(this.lblDatumVrijemePoslane);
            this.groupBox5.Controls.Add(this.lblPrimaoc);
            this.groupBox5.Controls.Add(this.lbldvpo);
            this.groupBox5.Controls.Add(this.lblppo);
            this.groupBox5.Controls.Add(this.rtxtSadrzajPoslane);
            this.groupBox5.Location = new System.Drawing.Point(525, 200);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(513, 475);
            this.groupBox5.TabIndex = 123;
            this.groupBox5.TabStop = false;
            // 
            // lblsppo
            // 
            this.lblsppo.AutoSize = true;
            this.lblsppo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblsppo.Location = new System.Drawing.Point(37, 190);
            this.lblsppo.Name = "lblsppo";
            this.lblsppo.Size = new System.Drawing.Size(140, 20);
            this.lblsppo.TabIndex = 19;
            this.lblsppo.Text = "Sadržaj poruke :";
            this.lblsppo.Visible = false;
            // 
            // lblnpo
            // 
            this.lblnpo.AutoSize = true;
            this.lblnpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblnpo.Location = new System.Drawing.Point(37, 148);
            this.lblnpo.Name = "lblnpo";
            this.lblnpo.Size = new System.Drawing.Size(72, 20);
            this.lblnpo.TabIndex = 18;
            this.lblnpo.Text = "Naslov :";
            this.lblnpo.Visible = false;
            // 
            // lblNaslovPoslane
            // 
            this.lblNaslovPoslane.AutoSize = true;
            this.lblNaslovPoslane.Location = new System.Drawing.Point(132, 148);
            this.lblNaslovPoslane.Name = "lblNaslovPoslane";
            this.lblNaslovPoslane.Size = new System.Drawing.Size(51, 20);
            this.lblNaslovPoslane.TabIndex = 17;
            this.lblNaslovPoslane.Text = "Klijent";
            this.lblNaslovPoslane.Visible = false;
            // 
            // lblDatumVrijemePoslane
            // 
            this.lblDatumVrijemePoslane.AutoSize = true;
            this.lblDatumVrijemePoslane.Location = new System.Drawing.Point(249, 52);
            this.lblDatumVrijemePoslane.Name = "lblDatumVrijemePoslane";
            this.lblDatumVrijemePoslane.Size = new System.Drawing.Size(117, 20);
            this.lblDatumVrijemePoslane.TabIndex = 14;
            this.lblDatumVrijemePoslane.Text = "Datum i vrijeme";
            this.lblDatumVrijemePoslane.Visible = false;
            // 
            // lblPrimaoc
            // 
            this.lblPrimaoc.AutoSize = true;
            this.lblPrimaoc.Location = new System.Drawing.Point(249, 94);
            this.lblPrimaoc.Name = "lblPrimaoc";
            this.lblPrimaoc.Size = new System.Drawing.Size(51, 20);
            this.lblPrimaoc.TabIndex = 13;
            this.lblPrimaoc.Text = "Klijent";
            this.lblPrimaoc.Visible = false;
            // 
            // lbldvpo
            // 
            this.lbldvpo.AutoSize = true;
            this.lbldvpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbldvpo.Location = new System.Drawing.Point(37, 52);
            this.lbldvpo.Name = "lbldvpo";
            this.lbldvpo.Size = new System.Drawing.Size(194, 20);
            this.lbldvpo.TabIndex = 12;
            this.lbldvpo.Text = "Datum i vrijeme slanja :";
            this.lbldvpo.Visible = false;
            // 
            // lblppo
            // 
            this.lblppo.AutoSize = true;
            this.lblppo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblppo.Location = new System.Drawing.Point(37, 94);
            this.lblppo.Name = "lblppo";
            this.lblppo.Size = new System.Drawing.Size(83, 20);
            this.lblppo.TabIndex = 11;
            this.lblppo.Text = "Primaoc :";
            this.lblppo.Visible = false;
            // 
            // rtxtSadrzajPoslane
            // 
            this.rtxtSadrzajPoslane.BackColor = System.Drawing.Color.White;
            this.rtxtSadrzajPoslane.Location = new System.Drawing.Point(38, 213);
            this.rtxtSadrzajPoslane.Name = "rtxtSadrzajPoslane";
            this.rtxtSadrzajPoslane.ReadOnly = true;
            this.rtxtSadrzajPoslane.Size = new System.Drawing.Size(441, 168);
            this.rtxtSadrzajPoslane.TabIndex = 9;
            this.rtxtSadrzajPoslane.Text = "";
            this.rtxtSadrzajPoslane.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgvPoslanePoruke);
            this.groupBox6.Location = new System.Drawing.Point(9, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(510, 476);
            this.groupBox6.TabIndex = 122;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Poruke";
            // 
            // dgvPoslanePoruke
            // 
            this.dgvPoslanePoruke.AllowUserToAddRows = false;
            this.dgvPoslanePoruke.AllowUserToDeleteRows = false;
            this.dgvPoslanePoruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoslanePoruke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PorukaId,
            this.Primaoc,
            this.Naslov});
            this.dgvPoslanePoruke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoslanePoruke.Location = new System.Drawing.Point(3, 22);
            this.dgvPoslanePoruke.Name = "dgvPoslanePoruke";
            this.dgvPoslanePoruke.ReadOnly = true;
            this.dgvPoslanePoruke.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoslanePoruke.Size = new System.Drawing.Size(504, 451);
            this.dgvPoslanePoruke.TabIndex = 0;
            this.dgvPoslanePoruke.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPoslanePoruke_MouseDoubleClick);
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.metroButton1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.metroButton1.Location = new System.Drawing.Point(192, 633);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(129, 26);
            this.metroButton1.TabIndex = 179;
            this.metroButton1.Text = "Odgovori";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Visible = false;
            // 
            // PorukaId
            // 
            this.PorukaId.DataPropertyName = "PorukaId";
            this.PorukaId.HeaderText = "PorukaId";
            this.PorukaId.Name = "PorukaId";
            this.PorukaId.ReadOnly = true;
            this.PorukaId.Visible = false;
            // 
            // Primaoc
            // 
            this.Primaoc.DataPropertyName = "PrimaocInfo";
            this.Primaoc.HeaderText = "Primaoc";
            this.Primaoc.Name = "Primaoc";
            this.Primaoc.ReadOnly = true;
            this.Primaoc.Width = 160;
            // 
            // Naslov
            // 
            this.Naslov.DataPropertyName = "Naslov";
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.Name = "Naslov";
            this.Naslov.ReadOnly = true;
            this.Naslov.Width = 260;
            // 
            // frmPoruke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 814);
            this.Controls.Add(this.metroTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPoruke";
            this.Text = "frmPoruke";
            this.Load += new System.EventHandler(this.frmPoruke_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimljenePoruke)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslanePoruke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txtSearchPrezimePosiljaoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private System.Windows.Forms.CheckBox chbDoPrimljene;
        private System.Windows.Forms.CheckBox chBOdPrimljene;
        private System.Windows.Forms.DateTimePicker dtpDoPrimljene;
        private System.Windows.Forms.DateTimePicker dtpOdPrimljene;
        private System.Windows.Forms.TextBox txtSearchUsernamePosiljaoc;
        private System.Windows.Forms.TextBox txtSearchImePosiljaoc;
        private System.Windows.Forms.Button btnPrikaziPrimljene;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.TextBox txtSearchPrezimePrimaoc;
        private System.Windows.Forms.GroupBox groupBox4;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private System.Windows.Forms.CheckBox cbDoPoslane;
        private System.Windows.Forms.CheckBox cbOdPoslane;
        private System.Windows.Forms.DateTimePicker dtpDoPoslane;
        private System.Windows.Forms.DateTimePicker dtpOdPoslane;
        private System.Windows.Forms.TextBox txtSearchUsernamePrimaoc;
        private System.Windows.Forms.TextBox txtSearchImePrimaoc;
        private System.Windows.Forms.Button btnPrikaziPoslane;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvPoslanePoruke;
        private System.Windows.Forms.Label lblspp;
        private System.Windows.Forms.Label lblnp;
        private System.Windows.Forms.Label lblNaslovPrimljene;
        private System.Windows.Forms.Label lblDatumVrijemePrimljene;
        private System.Windows.Forms.Label lblPosiljaoc;
        private System.Windows.Forms.Label lbldvp;
        private System.Windows.Forms.Label lblpp;
        private System.Windows.Forms.RichTextBox rtxtSadrzajPrimljene;
        private System.Windows.Forms.Label lblsppo;
        private System.Windows.Forms.Label lblnpo;
        private System.Windows.Forms.Label lblNaslovPoslane;
        private System.Windows.Forms.Label lblDatumVrijemePoslane;
        private System.Windows.Forms.Label lblPrimaoc;
        private System.Windows.Forms.Label lbldvpo;
        private System.Windows.Forms.Label lblppo;
        private System.Windows.Forms.RichTextBox rtxtSadrzajPoslane;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPrimljenePoruke;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private MetroFramework.Controls.MetroButton btnPoruka;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorukaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Primaoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naslov;
    }
}