namespace Euroformulations4.SubWindows.ColorSearch
{
    partial class frmRicercaColore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRicercaColore));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLeggiColore = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.tabFiltri = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.gbListino = new System.Windows.Forms.GroupBox();
            this.cmbListino = new System.Windows.Forms.ComboBox();
            this.gbInputType = new System.Windows.Forms.GroupBox();
            this.chkKeyboard = new System.Windows.Forms.CheckBox();
            this.chkDevice = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkInternal = new System.Windows.Forms.CheckBox();
            this.chkExternal = new System.Windows.Forms.CheckBox();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.rblProdotti = new Euroformulations4.Library.Controls.RadioButtonList();
            this.tabColorchart = new System.Windows.Forms.TabPage();
            this.btnNoneCharts = new System.Windows.Forms.Button();
            this.btnAllCharts = new System.Windows.Forms.Button();
            this.clbCColori = new System.Windows.Forms.CheckedListBox();
            this.ListaTabImg = new System.Windows.Forms.ImageList(this.components);
            this.imgTWProdotti = new System.Windows.Forms.ImageList(this.components);
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.dgDati = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fandeck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalvaStandard = new System.Windows.Forms.Button();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.GroupBox3.SuspendLayout();
            this.tabFiltri.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.gbListino.SuspendLayout();
            this.gbInputType.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabProducts.SuspendLayout();
            this.tabColorchart.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeggiColore
            // 
            this.btnLeggiColore.BackColor = System.Drawing.Color.White;
            this.btnLeggiColore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeggiColore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeggiColore.Enabled = false;
            this.btnLeggiColore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnLeggiColore.FlatAppearance.BorderSize = 2;
            this.btnLeggiColore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLeggiColore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLeggiColore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeggiColore.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeggiColore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnLeggiColore.Image = ((System.Drawing.Image)(resources.GetObject("btnLeggiColore.Image")));
            this.btnLeggiColore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeggiColore.Location = new System.Drawing.Point(8, 24);
            this.btnLeggiColore.Name = "btnLeggiColore";
            this.btnLeggiColore.Size = new System.Drawing.Size(206, 38);
            this.btnLeggiColore.TabIndex = 25;
            this.btnLeggiColore.Text = "Search";
            this.btnLeggiColore.UseVisualStyleBackColor = false;
            this.btnLeggiColore.EnabledChanged += new System.EventHandler(this.btnSalvaStandard_EnabledChanged);
            this.btnLeggiColore.Click += new System.EventHandler(this.btnLeggiColore_Click_1);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.tabFiltri);
            this.GroupBox3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.GroupBox3.Location = new System.Drawing.Point(12, 12);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(352, 290);
            this.GroupBox3.TabIndex = 30;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Filters";
            // 
            // tabFiltri
            // 
            this.tabFiltri.Controls.Add(this.tabGeneral);
            this.tabFiltri.Controls.Add(this.tabProducts);
            this.tabFiltri.Controls.Add(this.tabColorchart);
            this.tabFiltri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFiltri.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFiltri.ImageList = this.ListaTabImg;
            this.tabFiltri.ItemSize = new System.Drawing.Size(42, 40);
            this.tabFiltri.Location = new System.Drawing.Point(3, 20);
            this.tabFiltri.Multiline = true;
            this.tabFiltri.Name = "tabFiltri";
            this.tabFiltri.SelectedIndex = 0;
            this.tabFiltri.Size = new System.Drawing.Size(346, 267);
            this.tabFiltri.TabIndex = 33;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.White;
            this.tabGeneral.Controls.Add(this.gbListino);
            this.tabGeneral.Controls.Add(this.gbInputType);
            this.tabGeneral.Controls.Add(this.groupBox4);
            this.tabGeneral.Location = new System.Drawing.Point(4, 44);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(338, 219);
            this.tabGeneral.TabIndex = 3;
            this.tabGeneral.Text = "General";
            // 
            // gbListino
            // 
            this.gbListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbListino.Controls.Add(this.cmbListino);
            this.gbListino.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListino.Location = new System.Drawing.Point(158, 6);
            this.gbListino.MaximumSize = new System.Drawing.Size(300, 82);
            this.gbListino.Name = "gbListino";
            this.gbListino.Size = new System.Drawing.Size(174, 82);
            this.gbListino.TabIndex = 7;
            this.gbListino.TabStop = false;
            this.gbListino.Text = "Price list";
            // 
            // cmbListino
            // 
            this.cmbListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListino.FormattingEnabled = true;
            this.cmbListino.Location = new System.Drawing.Point(6, 23);
            this.cmbListino.Name = "cmbListino";
            this.cmbListino.Size = new System.Drawing.Size(161, 26);
            this.cmbListino.TabIndex = 0;
            // 
            // gbInputType
            // 
            this.gbInputType.Controls.Add(this.chkKeyboard);
            this.gbInputType.Controls.Add(this.chkDevice);
            this.gbInputType.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInputType.Location = new System.Drawing.Point(3, 94);
            this.gbInputType.Name = "gbInputType";
            this.gbInputType.Size = new System.Drawing.Size(151, 82);
            this.gbInputType.TabIndex = 35;
            this.gbInputType.TabStop = false;
            this.gbInputType.Text = "Input type";
            // 
            // chkKeyboard
            // 
            this.chkKeyboard.BackColor = System.Drawing.Color.Transparent;
            this.chkKeyboard.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkKeyboard.ForeColor = System.Drawing.Color.Black;
            this.chkKeyboard.Location = new System.Drawing.Point(6, 47);
            this.chkKeyboard.Name = "chkKeyboard";
            this.chkKeyboard.Size = new System.Drawing.Size(139, 25);
            this.chkKeyboard.TabIndex = 34;
            this.chkKeyboard.Text = "keyboard";
            this.chkKeyboard.UseVisualStyleBackColor = false;
            this.chkKeyboard.CheckedChanged += new System.EventHandler(this.chkKeyboard_CheckedChanged);
            // 
            // chkDevice
            // 
            this.chkDevice.BackColor = System.Drawing.Color.Transparent;
            this.chkDevice.Checked = true;
            this.chkDevice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDevice.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDevice.ForeColor = System.Drawing.Color.Black;
            this.chkDevice.Location = new System.Drawing.Point(6, 21);
            this.chkDevice.Name = "chkDevice";
            this.chkDevice.Size = new System.Drawing.Size(139, 21);
            this.chkDevice.TabIndex = 33;
            this.chkDevice.Text = "Spectro";
            this.chkDevice.UseVisualStyleBackColor = false;
            this.chkDevice.CheckedChanged += new System.EventHandler(this.chkDevice_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkInternal);
            this.groupBox4.Controls.Add(this.chkExternal);
            this.groupBox4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(3, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(149, 82);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Use";
            // 
            // chkInternal
            // 
            this.chkInternal.BackColor = System.Drawing.Color.Transparent;
            this.chkInternal.Checked = true;
            this.chkInternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInternal.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInternal.ForeColor = System.Drawing.Color.Black;
            this.chkInternal.Location = new System.Drawing.Point(6, 21);
            this.chkInternal.Name = "chkInternal";
            this.chkInternal.Size = new System.Drawing.Size(110, 20);
            this.chkInternal.TabIndex = 4;
            this.chkInternal.Text = "Internal";
            this.chkInternal.UseVisualStyleBackColor = false;
            this.chkInternal.CheckedChanged += new System.EventHandler(this.InternalChanged);
            // 
            // chkExternal
            // 
            this.chkExternal.BackColor = System.Drawing.Color.Transparent;
            this.chkExternal.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExternal.ForeColor = System.Drawing.Color.Black;
            this.chkExternal.Location = new System.Drawing.Point(6, 47);
            this.chkExternal.Name = "chkExternal";
            this.chkExternal.Size = new System.Drawing.Size(110, 22);
            this.chkExternal.TabIndex = 5;
            this.chkExternal.Text = "External";
            this.chkExternal.UseVisualStyleBackColor = false;
            this.chkExternal.CheckedChanged += new System.EventHandler(this.ExternalChanged);
            // 
            // tabProducts
            // 
            this.tabProducts.BackColor = System.Drawing.Color.White;
            this.tabProducts.Controls.Add(this.rblProdotti);
            this.tabProducts.Location = new System.Drawing.Point(4, 44);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(338, 219);
            this.tabProducts.TabIndex = 1;
            this.tabProducts.Text = "Products";
            // 
            // rblProdotti
            // 
            this.rblProdotti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rblProdotti.FormattingEnabled = true;
            this.rblProdotti.Location = new System.Drawing.Point(3, 3);
            this.rblProdotti.Name = "rblProdotti";
            this.rblProdotti.Size = new System.Drawing.Size(332, 213);
            this.rblProdotti.TabIndex = 37;
            this.rblProdotti.SelectedIndexChanged += new System.EventHandler(this.rblProdotti_SelectedIndexChanged);
            // 
            // tabColorchart
            // 
            this.tabColorchart.BackColor = System.Drawing.Color.White;
            this.tabColorchart.Controls.Add(this.btnNoneCharts);
            this.tabColorchart.Controls.Add(this.btnAllCharts);
            this.tabColorchart.Controls.Add(this.clbCColori);
            this.tabColorchart.Location = new System.Drawing.Point(4, 44);
            this.tabColorchart.Name = "tabColorchart";
            this.tabColorchart.Padding = new System.Windows.Forms.Padding(3);
            this.tabColorchart.Size = new System.Drawing.Size(338, 219);
            this.tabColorchart.TabIndex = 4;
            this.tabColorchart.Text = "Colorcharts";
            // 
            // btnNoneCharts
            // 
            this.btnNoneCharts.BackColor = System.Drawing.Color.White;
            this.btnNoneCharts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNoneCharts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoneCharts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnNoneCharts.FlatAppearance.BorderSize = 2;
            this.btnNoneCharts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNoneCharts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNoneCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoneCharts.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoneCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnNoneCharts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNoneCharts.Location = new System.Drawing.Point(204, 188);
            this.btnNoneCharts.Name = "btnNoneCharts";
            this.btnNoneCharts.Size = new System.Drawing.Size(128, 27);
            this.btnNoneCharts.TabIndex = 36;
            this.btnNoneCharts.Text = "Unselect all";
            this.btnNoneCharts.UseVisualStyleBackColor = false;
            this.btnNoneCharts.Click += new System.EventHandler(this.btnNoneCharts_Click);
            // 
            // btnAllCharts
            // 
            this.btnAllCharts.BackColor = System.Drawing.Color.White;
            this.btnAllCharts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAllCharts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllCharts.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnAllCharts.FlatAppearance.BorderSize = 2;
            this.btnAllCharts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAllCharts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAllCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllCharts.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnAllCharts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAllCharts.Location = new System.Drawing.Point(7, 189);
            this.btnAllCharts.Name = "btnAllCharts";
            this.btnAllCharts.Size = new System.Drawing.Size(128, 27);
            this.btnAllCharts.TabIndex = 31;
            this.btnAllCharts.Text = "Select all";
            this.btnAllCharts.UseVisualStyleBackColor = false;
            this.btnAllCharts.Click += new System.EventHandler(this.btnAllCharts_Click);
            // 
            // clbCColori
            // 
            this.clbCColori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCColori.CheckOnClick = true;
            this.clbCColori.FormattingEnabled = true;
            this.clbCColori.Location = new System.Drawing.Point(7, 7);
            this.clbCColori.Name = "clbCColori";
            this.clbCColori.Size = new System.Drawing.Size(325, 175);
            this.clbCColori.TabIndex = 35;
            this.clbCColori.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCColori_ItemCheck);
            // 
            // ListaTabImg
            // 
            this.ListaTabImg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListaTabImg.ImageStream")));
            this.ListaTabImg.TransparentColor = System.Drawing.Color.Transparent;
            this.ListaTabImg.Images.SetKeyName(0, "1415895719_25.png");
            this.ListaTabImg.Images.SetKeyName(1, "1415895875_preferences-desktop-color.png");
            this.ListaTabImg.Images.SetKeyName(2, "1301563377_services.ico");
            // 
            // imgTWProdotti
            // 
            this.imgTWProdotti.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTWProdotti.ImageStream")));
            this.imgTWProdotti.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTWProdotti.Images.SetKeyName(0, "1425669196_ic_format_color_fill_48px-16.png");
            // 
            // GroupBox6
            // 
            this.GroupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox6.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox6.Controls.Add(this.dgDati);
            this.GroupBox6.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.GroupBox6.Location = new System.Drawing.Point(12, 331);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(690, 213);
            this.GroupBox6.TabIndex = 31;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Similar Colors";
            // 
            // dgDati
            // 
            this.dgDati.AllowUserToAddRows = false;
            this.dgDati.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgDati.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDati.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Number,
            this.Color,
            this.Delta,
            this.Prod,
            this.Fandeck,
            this.Shade,
            this.price});
            this.dgDati.EnableHeadersVisualStyles = false;
            this.dgDati.Location = new System.Drawing.Point(8, 21);
            this.dgDati.MultiSelect = false;
            this.dgDati.Name = "dgDati";
            this.dgDati.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDati.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgDati.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDati.Size = new System.Drawing.Size(670, 186);
            this.dgDati.TabIndex = 16;
            this.dgDati.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDati_CellDoubleClick);
            this.dgDati.SizeChanged += new System.EventHandler(this.dgDati_SizeChanged);
            this.dgDati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDati_KeyDown);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Number
            // 
            this.Number.HeaderText = "N.";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 165;
            // 
            // Color
            // 
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            this.Color.DefaultCellStyle = dataGridViewCellStyle3;
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 166;
            // 
            // Delta
            // 
            this.Delta.HeaderText = "DE*";
            this.Delta.Name = "Delta";
            this.Delta.ReadOnly = true;
            this.Delta.Width = 165;
            // 
            // Prod
            // 
            this.Prod.HeaderText = "Product";
            this.Prod.Name = "Prod";
            this.Prod.ReadOnly = true;
            // 
            // Fandeck
            // 
            this.Fandeck.HeaderText = "Fandeck";
            this.Fandeck.Name = "Fandeck";
            this.Fandeck.ReadOnly = true;
            this.Fandeck.Width = 166;
            // 
            // Shade
            // 
            this.Shade.HeaderText = "Shade";
            this.Shade.Name = "Shade";
            this.Shade.ReadOnly = true;
            this.Shade.Width = 165;
            // 
            // price
            // 
            this.price.HeaderText = "price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSalvaStandard);
            this.groupBox1.Controls.Add(this.btnLeggiColore);
            this.groupBox1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(370, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 290);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Search";
            // 
            // btnSalvaStandard
            // 
            this.btnSalvaStandard.BackColor = System.Drawing.Color.White;
            this.btnSalvaStandard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalvaStandard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvaStandard.Enabled = false;
            this.btnSalvaStandard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSalvaStandard.FlatAppearance.BorderSize = 2;
            this.btnSalvaStandard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvaStandard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvaStandard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvaStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvaStandard.ForeColor = System.Drawing.Color.Black;
            this.btnSalvaStandard.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvaStandard.Image")));
            this.btnSalvaStandard.Location = new System.Drawing.Point(287, 24);
            this.btnSalvaStandard.Name = "btnSalvaStandard";
            this.btnSalvaStandard.Size = new System.Drawing.Size(34, 36);
            this.btnSalvaStandard.TabIndex = 30;
            this.btnSalvaStandard.UseVisualStyleBackColor = false;
            this.btnSalvaStandard.EnabledChanged += new System.EventHandler(this.btnSalvaStandard_EnabledChanged);
            this.btnSalvaStandard.Click += new System.EventHandler(this.btnSalvaStandard_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(660, 298);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 33;
            this.pbHelp.TabStop = false;
            // 
            // frmRicercaColore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 568);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox6);
            this.Controls.Add(this.GroupBox3);
            this.DoubleBuffered = true;
            this.Name = "frmRicercaColore";
            this.Text = "frmRicercaColore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRicercaColore_FormClosing);
            this.Load += new System.EventHandler(this.frmRicercaColore_Load);
            this.GroupBox3.ResumeLayout(false);
            this.tabFiltri.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.gbListino.ResumeLayout(false);
            this.gbInputType.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabProducts.ResumeLayout(false);
            this.tabColorchart.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnLeggiColore;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.GroupBox GroupBox6;
        private System.Windows.Forms.DataGridView dgDati;
        internal System.Windows.Forms.TabControl tabFiltri;
        internal System.Windows.Forms.TabPage tabGeneral;
        internal System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.CheckBox chkExternal;
        private System.Windows.Forms.CheckBox chkInternal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ImageList ListaTabImg;
        private System.Windows.Forms.TabPage tabColorchart;
        private System.Windows.Forms.ImageList imgTWProdotti;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.GroupBox gbInputType;
        private System.Windows.Forms.CheckBox chkKeyboard;
        private System.Windows.Forms.CheckBox chkDevice;
        internal System.Windows.Forms.Button btnSalvaStandard;
        private System.Windows.Forms.GroupBox gbListino;
        private System.Windows.Forms.ComboBox cmbListino;
        private Library.Controls.RadioButtonList rblProdotti;
        private System.Windows.Forms.CheckedListBox clbCColori;
        internal System.Windows.Forms.Button btnNoneCharts;
        internal System.Windows.Forms.Button btnAllCharts;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fandeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shade;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;

    }
}