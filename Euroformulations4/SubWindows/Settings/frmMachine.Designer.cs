namespace Euroformulations4.SubWindows.Settings
{
    partial class frmMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMachine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.btnImportExport = new System.Windows.Forms.Button();
            this.btnAutoConfigure = new System.Windows.Forms.Button();
            this.MachineIdentification = new System.Windows.Forms.TextBox();
            this.Save_Modifica = new System.Windows.Forms.Button();
            this.exeFile = new System.Windows.Forms.TextBox();
            this.pathFile = new System.Windows.Forms.TextBox();
            this.cmbDriver = new System.Windows.Forms.ComboBox();
            this.DataMachine = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TintingMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filepath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pathtothedriver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ouncetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machine_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OunceEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbOunceType = new System.Windows.Forms.ComboBox();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.gbIdentification = new System.Windows.Forms.GroupBox();
            this.gbPathFormula = new System.Windows.Forms.GroupBox();
            this.gbPathDriver = new System.Windows.Forms.GroupBox();
            this.gbOunceType = new System.Windows.Forms.GroupBox();
            this.chkOunceEdit = new System.Windows.Forms.CheckBox();
            this.gbOunceEdit = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataMachine)).BeginInit();
            this.dgMenu.SuspendLayout();
            this.gbType.SuspendLayout();
            this.gbIdentification.SuspendLayout();
            this.gbPathFormula.SuspendLayout();
            this.gbPathDriver.SuspendLayout();
            this.gbOunceType.SuspendLayout();
            this.gbOunceEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(658, 134);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 49;
            this.pbHelp.TabStop = false;
            // 
            // btnImportExport
            // 
            this.btnImportExport.BackColor = System.Drawing.Color.White;
            this.btnImportExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImportExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnImportExport.FlatAppearance.BorderSize = 2;
            this.btnImportExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnImportExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnImportExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportExport.Location = new System.Drawing.Point(225, 133);
            this.btnImportExport.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.btnImportExport.Name = "btnImportExport";
            this.btnImportExport.Size = new System.Drawing.Size(195, 38);
            this.btnImportExport.TabIndex = 6;
            this.btnImportExport.Text = "Import / Export";
            this.btnImportExport.UseVisualStyleBackColor = false;
            this.btnImportExport.Click += new System.EventHandler(this.btnImportExport_Click);
            // 
            // btnAutoConfigure
            // 
            this.btnAutoConfigure.BackColor = System.Drawing.Color.White;
            this.btnAutoConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAutoConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoConfigure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnAutoConfigure.FlatAppearance.BorderSize = 2;
            this.btnAutoConfigure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAutoConfigure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAutoConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoConfigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoConfigure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnAutoConfigure.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoConfigure.Location = new System.Drawing.Point(12, 133);
            this.btnAutoConfigure.Name = "btnAutoConfigure";
            this.btnAutoConfigure.Size = new System.Drawing.Size(195, 38);
            this.btnAutoConfigure.TabIndex = 5;
            this.btnAutoConfigure.Text = "Auto configure Driver";
            this.btnAutoConfigure.UseVisualStyleBackColor = false;
            this.btnAutoConfigure.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnAutoConfigure.Click += new System.EventHandler(this.btnAutoConfigure_Click);
            // 
            // MachineIdentification
            // 
            this.MachineIdentification.BackColor = System.Drawing.Color.White;
            this.MachineIdentification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MachineIdentification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MachineIdentification.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineIdentification.Location = new System.Drawing.Point(3, 20);
            this.MachineIdentification.Name = "MachineIdentification";
            this.MachineIdentification.Size = new System.Drawing.Size(189, 24);
            this.MachineIdentification.TabIndex = 1;
            // 
            // Save_Modifica
            // 
            this.Save_Modifica.BackColor = System.Drawing.Color.White;
            this.Save_Modifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Save_Modifica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save_Modifica.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.Save_Modifica.FlatAppearance.BorderSize = 2;
            this.Save_Modifica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.Save_Modifica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.Save_Modifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save_Modifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Modifica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.Save_Modifica.Image = ((System.Drawing.Image)(resources.GetObject("Save_Modifica.Image")));
            this.Save_Modifica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save_Modifica.Location = new System.Drawing.Point(438, 133);
            this.Save_Modifica.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
            this.Save_Modifica.Name = "Save_Modifica";
            this.Save_Modifica.Size = new System.Drawing.Size(195, 38);
            this.Save_Modifica.TabIndex = 7;
            this.Save_Modifica.Text = "Save dispenser";
            this.Save_Modifica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Save_Modifica.UseVisualStyleBackColor = false;
            this.Save_Modifica.Click += new System.EventHandler(this.Save_Modifica_Click);
            // 
            // exeFile
            // 
            this.exeFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exeFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exeFile.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exeFile.Location = new System.Drawing.Point(3, 20);
            this.exeFile.Name = "exeFile";
            this.exeFile.Size = new System.Drawing.Size(309, 24);
            this.exeFile.TabIndex = 4;
            // 
            // pathFile
            // 
            this.pathFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathFile.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathFile.Location = new System.Drawing.Point(3, 20);
            this.pathFile.Name = "pathFile";
            this.pathFile.Size = new System.Drawing.Size(309, 24);
            this.pathFile.TabIndex = 3;
            // 
            // cmbDriver
            // 
            this.cmbDriver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriver.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDriver.FormattingEnabled = true;
            this.cmbDriver.Location = new System.Drawing.Point(3, 20);
            this.cmbDriver.Name = "cmbDriver";
            this.cmbDriver.Size = new System.Drawing.Size(189, 26);
            this.cmbDriver.TabIndex = 0;
            this.cmbDriver.SelectedIndexChanged += new System.EventHandler(this.cmbDriver_SelectedIndexChanged);
            // 
            // DataMachine
            // 
            this.DataMachine.AllowUserToAddRows = false;
            this.DataMachine.AllowUserToDeleteRows = false;
            this.DataMachine.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DataMachine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataMachine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataMachine.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataMachine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataMachine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.identification,
            this.TintingMachine,
            this.Filepath,
            this.Pathtothedriver,
            this.ouncetype,
            this.machine_type,
            this.OunceEdit});
            this.DataMachine.ContextMenuStrip = this.dgMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataMachine.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataMachine.EnableHeadersVisualStyles = false;
            this.DataMachine.Location = new System.Drawing.Point(7, 177);
            this.DataMachine.MultiSelect = false;
            this.DataMachine.Name = "DataMachine";
            this.DataMachine.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataMachine.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataMachine.RowHeadersVisible = false;
            this.DataMachine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataMachine.Size = new System.Drawing.Size(693, 322);
            this.DataMachine.TabIndex = 8;
            this.DataMachine.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataMachine_CellMouseClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // identification
            // 
            this.identification.HeaderText = "Identification";
            this.identification.Name = "identification";
            this.identification.ReadOnly = true;
            // 
            // TintingMachine
            // 
            this.TintingMachine.HeaderText = "Dispenser";
            this.TintingMachine.Name = "TintingMachine";
            this.TintingMachine.ReadOnly = true;
            // 
            // Filepath
            // 
            this.Filepath.HeaderText = "File path of the formula";
            this.Filepath.Name = "Filepath";
            this.Filepath.ReadOnly = true;
            // 
            // Pathtothedriver
            // 
            this.Pathtothedriver.HeaderText = "Path to the driver";
            this.Pathtothedriver.Name = "Pathtothedriver";
            this.Pathtothedriver.ReadOnly = true;
            // 
            // ouncetype
            // 
            this.ouncetype.HeaderText = "Ounce Type";
            this.ouncetype.Name = "ouncetype";
            this.ouncetype.ReadOnly = true;
            // 
            // machine_type
            // 
            this.machine_type.HeaderText = "machine_type";
            this.machine_type.Name = "machine_type";
            this.machine_type.ReadOnly = true;
            this.machine_type.Visible = false;
            // 
            // OunceEdit
            // 
            this.OunceEdit.HeaderText = "OunceEdit";
            this.OunceEdit.Name = "OunceEdit";
            this.OunceEdit.ReadOnly = true;
            // 
            // dgMenu
            // 
            this.dgMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.dgMenu.Name = "dgMenu";
            this.dgMenu.Size = new System.Drawing.Size(157, 48);
            this.dgMenu.Opening += new System.ComponentModel.CancelEventHandler(this.dgMenu_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem1.Text = "Delete machine";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cmbOunceType
            // 
            this.cmbOunceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbOunceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOunceType.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOunceType.FormattingEnabled = true;
            this.cmbOunceType.Location = new System.Drawing.Point(3, 20);
            this.cmbOunceType.Name = "cmbOunceType";
            this.cmbOunceType.Size = new System.Drawing.Size(160, 26);
            this.cmbOunceType.TabIndex = 51;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.cmbDriver);
            this.gbType.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbType.Location = new System.Drawing.Point(12, 12);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(195, 49);
            this.gbType.TabIndex = 52;
            this.gbType.TabStop = false;
            this.gbType.Text = "Select dispenser type";
            // 
            // gbIdentification
            // 
            this.gbIdentification.Controls.Add(this.MachineIdentification);
            this.gbIdentification.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbIdentification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbIdentification.Location = new System.Drawing.Point(12, 67);
            this.gbIdentification.Name = "gbIdentification";
            this.gbIdentification.Size = new System.Drawing.Size(195, 49);
            this.gbIdentification.TabIndex = 53;
            this.gbIdentification.TabStop = false;
            this.gbIdentification.Text = "Identification";
            // 
            // gbPathFormula
            // 
            this.gbPathFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPathFormula.Controls.Add(this.pathFile);
            this.gbPathFormula.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPathFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbPathFormula.Location = new System.Drawing.Point(213, 12);
            this.gbPathFormula.Name = "gbPathFormula";
            this.gbPathFormula.Size = new System.Drawing.Size(315, 49);
            this.gbPathFormula.TabIndex = 54;
            this.gbPathFormula.TabStop = false;
            this.gbPathFormula.Text = "File path of the formula";
            // 
            // gbPathDriver
            // 
            this.gbPathDriver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPathDriver.Controls.Add(this.exeFile);
            this.gbPathDriver.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPathDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbPathDriver.Location = new System.Drawing.Point(213, 67);
            this.gbPathDriver.Name = "gbPathDriver";
            this.gbPathDriver.Size = new System.Drawing.Size(315, 49);
            this.gbPathDriver.TabIndex = 55;
            this.gbPathDriver.TabStop = false;
            this.gbPathDriver.Text = "Path to the driver";
            // 
            // gbOunceType
            // 
            this.gbOunceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOunceType.Controls.Add(this.cmbOunceType);
            this.gbOunceType.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOunceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbOunceType.Location = new System.Drawing.Point(534, 67);
            this.gbOunceType.Name = "gbOunceType";
            this.gbOunceType.Size = new System.Drawing.Size(166, 49);
            this.gbOunceType.TabIndex = 56;
            this.gbOunceType.TabStop = false;
            this.gbOunceType.Text = "Ounce type";
            // 
            // chkOunceEdit
            // 
            this.chkOunceEdit.AutoSize = true;
            this.chkOunceEdit.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOunceEdit.ForeColor = System.Drawing.Color.Black;
            this.chkOunceEdit.Location = new System.Drawing.Point(6, 25);
            this.chkOunceEdit.Name = "chkOunceEdit";
            this.chkOunceEdit.Size = new System.Drawing.Size(118, 19);
            this.chkOunceEdit.TabIndex = 57;
            this.chkOunceEdit.Text = "Default in ounce";
            this.chkOunceEdit.UseVisualStyleBackColor = true;
            // 
            // gbOunceEdit
            // 
            this.gbOunceEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOunceEdit.Controls.Add(this.chkOunceEdit);
            this.gbOunceEdit.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOunceEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbOunceEdit.Location = new System.Drawing.Point(534, 12);
            this.gbOunceEdit.Name = "gbOunceEdit";
            this.gbOunceEdit.Size = new System.Drawing.Size(166, 49);
            this.gbOunceEdit.TabIndex = 58;
            this.gbOunceEdit.TabStop = false;
            this.gbOunceEdit.Text = "Formula edit";
            // 
            // frmMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 511);
            this.Controls.Add(this.gbOunceEdit);
            this.Controls.Add(this.gbOunceType);
            this.Controls.Add(this.gbPathDriver);
            this.Controls.Add(this.gbPathFormula);
            this.Controls.Add(this.gbIdentification);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.btnImportExport);
            this.Controls.Add(this.btnAutoConfigure);
            this.Controls.Add(this.Save_Modifica);
            this.Controls.Add(this.DataMachine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMachine";
            this.Text = "frmMachine";
            this.Load += new System.EventHandler(this.frmMachine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataMachine)).EndInit();
            this.dgMenu.ResumeLayout(false);
            this.gbType.ResumeLayout(false);
            this.gbIdentification.ResumeLayout(false);
            this.gbIdentification.PerformLayout();
            this.gbPathFormula.ResumeLayout(false);
            this.gbPathFormula.PerformLayout();
            this.gbPathDriver.ResumeLayout(false);
            this.gbPathDriver.PerformLayout();
            this.gbOunceType.ResumeLayout(false);
            this.gbOunceEdit.ResumeLayout(false);
            this.gbOunceEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHelp;
        internal System.Windows.Forms.Button btnImportExport;
        internal System.Windows.Forms.Button btnAutoConfigure;
        private System.Windows.Forms.TextBox MachineIdentification;
        internal System.Windows.Forms.Button Save_Modifica;
        private System.Windows.Forms.TextBox exeFile;
        private System.Windows.Forms.TextBox pathFile;
        private System.Windows.Forms.ComboBox cmbDriver;
        private System.Windows.Forms.DataGridView DataMachine;
        private System.Windows.Forms.ContextMenuStrip dgMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ComboBox cmbOunceType;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.GroupBox gbIdentification;
        private System.Windows.Forms.GroupBox gbPathFormula;
        private System.Windows.Forms.GroupBox gbPathDriver;
        private System.Windows.Forms.GroupBox gbOunceType;
        private System.Windows.Forms.CheckBox chkOunceEdit;
        private System.Windows.Forms.GroupBox gbOunceEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn identification;
        private System.Windows.Forms.DataGridViewTextBoxColumn TintingMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filepath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pathtothedriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ouncetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn machine_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn OunceEdit;
    }
}