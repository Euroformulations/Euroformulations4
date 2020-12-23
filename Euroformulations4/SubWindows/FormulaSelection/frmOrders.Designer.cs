namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrders));
            this.dgEmail = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mittente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOggetto = new System.Windows.Forms.GroupBox();
            this.txtOggetto = new System.Windows.Forms.TextBox();
            this.gbCorpo = new System.Windows.Forms.GroupBox();
            this.txtCorpo = new System.Windows.Forms.TextBox();
            this.dgOrdini = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Utilizzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prodotto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.markAsDispensedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDispense = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gbColorInfo = new System.Windows.Forms.GroupBox();
            this.lblUso = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblCColori = new System.Windows.Forms.Label();
            this.lblProdotto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmail)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.gbOggetto.SuspendLayout();
            this.gbCorpo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdini)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gbColorInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEmail
            // 
            this.dgEmail.AllowUserToAddRows = false;
            this.dgEmail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgEmail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEmail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.mittente,
            this.data});
            this.dgEmail.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgEmail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgEmail.EnableHeadersVisualStyles = false;
            this.dgEmail.Location = new System.Drawing.Point(12, 76);
            this.dgEmail.MultiSelect = false;
            this.dgEmail.Name = "dgEmail";
            this.dgEmail.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgEmail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgEmail.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgEmail.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEmail.Size = new System.Drawing.Size(354, 195);
            this.dgEmail.TabIndex = 0;
            this.dgEmail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgEmail_CellPainting);
            this.dgEmail.SelectionChanged += new System.EventHandler(this.dgEmail_SelectionChanged);
            this.dgEmail.SizeChanged += new System.EventHandler(this.dgEmail_SizeChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // mittente
            // 
            this.mittente.HeaderText = "Mittente";
            this.mittente.Name = "mittente";
            this.mittente.ReadOnly = true;
            this.mittente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // data
            // 
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteEmailToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(139, 26);
            // 
            // deleteEmailToolStripMenuItem
            // 
            this.deleteEmailToolStripMenuItem.Name = "deleteEmailToolStripMenuItem";
            this.deleteEmailToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.deleteEmailToolStripMenuItem.Text = "delete email";
            this.deleteEmailToolStripMenuItem.Click += new System.EventHandler(this.deleteEmailToolStripMenuItem_Click);
            // 
            // gbOggetto
            // 
            this.gbOggetto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOggetto.Controls.Add(this.txtOggetto);
            this.gbOggetto.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOggetto.Location = new System.Drawing.Point(372, 76);
            this.gbOggetto.Name = "gbOggetto";
            this.gbOggetto.Size = new System.Drawing.Size(330, 51);
            this.gbOggetto.TabIndex = 1;
            this.gbOggetto.TabStop = false;
            this.gbOggetto.Text = "Oggetto";
            // 
            // txtOggetto
            // 
            this.txtOggetto.BackColor = System.Drawing.Color.White;
            this.txtOggetto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOggetto.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOggetto.Location = new System.Drawing.Point(3, 20);
            this.txtOggetto.Name = "txtOggetto";
            this.txtOggetto.ReadOnly = true;
            this.txtOggetto.Size = new System.Drawing.Size(324, 24);
            this.txtOggetto.TabIndex = 0;
            // 
            // gbCorpo
            // 
            this.gbCorpo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCorpo.Controls.Add(this.txtCorpo);
            this.gbCorpo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCorpo.Location = new System.Drawing.Point(372, 133);
            this.gbCorpo.Name = "gbCorpo";
            this.gbCorpo.Size = new System.Drawing.Size(330, 138);
            this.gbCorpo.TabIndex = 2;
            this.gbCorpo.TabStop = false;
            this.gbCorpo.Text = "Corpo";
            // 
            // txtCorpo
            // 
            this.txtCorpo.BackColor = System.Drawing.Color.White;
            this.txtCorpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCorpo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorpo.Location = new System.Drawing.Point(3, 20);
            this.txtCorpo.Multiline = true;
            this.txtCorpo.Name = "txtCorpo";
            this.txtCorpo.ReadOnly = true;
            this.txtCorpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCorpo.Size = new System.Drawing.Size(324, 115);
            this.txtCorpo.TabIndex = 0;
            // 
            // dgOrdini
            // 
            this.dgOrdini.AllowUserToAddRows = false;
            this.dgOrdini.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgOrdini.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgOrdini.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrdini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgOrdini.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrdini.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgOrdini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOrdini.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn2,
            this.Utilizzo,
            this.Prodotto});
            this.dgOrdini.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgOrdini.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgOrdini.EnableHeadersVisualStyles = false;
            this.dgOrdini.Location = new System.Drawing.Point(12, 277);
            this.dgOrdini.MultiSelect = false;
            this.dgOrdini.Name = "dgOrdini";
            this.dgOrdini.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgOrdini.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgOrdini.RowHeadersVisible = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgOrdini.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgOrdini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgOrdini.Size = new System.Drawing.Size(690, 210);
            this.dgOrdini.TabIndex = 3;
            this.dgOrdini.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgOrdini_CellDoubleClick);
            this.dgOrdini.SelectionChanged += new System.EventHandler(this.dgOrdini_SelectionChanged);
            this.dgOrdini.SizeChanged += new System.EventHandler(this.dgOrdini_SizeChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Stato";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "CIELab";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Utilizzo
            // 
            this.Utilizzo.HeaderText = "Utilizzo";
            this.Utilizzo.Name = "Utilizzo";
            this.Utilizzo.ReadOnly = true;
            // 
            // Prodotto
            // 
            this.Prodotto.HeaderText = "Anteprima";
            this.Prodotto.Name = "Prodotto";
            this.Prodotto.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.markAsDispensedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // markAsDispensedToolStripMenuItem
            // 
            this.markAsDispensedToolStripMenuItem.Name = "markAsDispensedToolStripMenuItem";
            this.markAsDispensedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.markAsDispensedToolStripMenuItem.Text = "mark as dispensed";
            this.markAsDispensedToolStripMenuItem.Click += new System.EventHandler(this.markAsDispensedToolStripMenuItem_Click);
            // 
            // btnDispense
            // 
            this.btnDispense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDispense.BackColor = System.Drawing.Color.White;
            this.btnDispense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispense.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDispense.FlatAppearance.BorderSize = 2;
            this.btnDispense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDispense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDispense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispense.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDispense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDispense.Image = ((System.Drawing.Image)(resources.GetObject("btnDispense.Image")));
            this.btnDispense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDispense.Location = new System.Drawing.Point(550, 544);
            this.btnDispense.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDispense.Name = "btnDispense";
            this.btnDispense.Size = new System.Drawing.Size(152, 38);
            this.btnDispense.TabIndex = 5;
            this.btnDispense.Text = "MySearch";
            this.btnDispense.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDispense.UseVisualStyleBackColor = false;
            this.btnDispense.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(550, 500);
            this.button1.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Eroga";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // gbColorInfo
            // 
            this.gbColorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbColorInfo.Controls.Add(this.lblUso);
            this.gbColorInfo.Controls.Add(this.lblColor);
            this.gbColorInfo.Controls.Add(this.lblCColori);
            this.gbColorInfo.Controls.Add(this.lblProdotto);
            this.gbColorInfo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbColorInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbColorInfo.Location = new System.Drawing.Point(12, 493);
            this.gbColorInfo.Name = "gbColorInfo";
            this.gbColorInfo.Size = new System.Drawing.Size(344, 89);
            this.gbColorInfo.TabIndex = 11;
            this.gbColorInfo.TabStop = false;
            this.gbColorInfo.Text = "Dettagli";
            // 
            // lblUso
            // 
            this.lblUso.AutoSize = true;
            this.lblUso.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUso.ForeColor = System.Drawing.Color.Black;
            this.lblUso.Location = new System.Drawing.Point(6, 68);
            this.lblUso.Name = "lblUso";
            this.lblUso.Size = new System.Drawing.Size(36, 16);
            this.lblUso.TabIndex = 5;
            this.lblUso.Text = "Use :";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.ForeColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(6, 36);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(48, 16);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color :";
            // 
            // lblCColori
            // 
            this.lblCColori.AutoSize = true;
            this.lblCColori.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCColori.ForeColor = System.Drawing.Color.Black;
            this.lblCColori.Location = new System.Drawing.Point(6, 20);
            this.lblCColori.Name = "lblCColori";
            this.lblCColori.Size = new System.Drawing.Size(81, 16);
            this.lblCColori.TabIndex = 2;
            this.lblCColori.Text = "Colocharts :";
            // 
            // lblProdotto
            // 
            this.lblProdotto.AutoSize = true;
            this.lblProdotto.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdotto.ForeColor = System.Drawing.Color.Black;
            this.lblProdotto.Location = new System.Drawing.Point(6, 52);
            this.lblProdotto.Name = "lblProdotto";
            this.lblProdotto.Size = new System.Drawing.Size(61, 16);
            this.lblProdotto.TabIndex = 3;
            this.lblProdotto.Text = "Product :";
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(714, 603);
            this.Controls.Add(this.gbColorInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDispense);
            this.Controls.Add(this.dgOrdini);
            this.Controls.Add(this.gbCorpo);
            this.Controls.Add(this.gbOggetto);
            this.Controls.Add(this.dgEmail);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrders";
            this.Text = "Orders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrders_FormClosing);
            this.Load += new System.EventHandler(this.frmOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEmail)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.gbOggetto.ResumeLayout(false);
            this.gbOggetto.PerformLayout();
            this.gbCorpo.ResumeLayout(false);
            this.gbCorpo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrdini)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbColorInfo.ResumeLayout(false);
            this.gbColorInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEmail;
        private System.Windows.Forms.GroupBox gbOggetto;
        private System.Windows.Forms.TextBox txtOggetto;
        private System.Windows.Forms.GroupBox gbCorpo;
        private System.Windows.Forms.TextBox txtCorpo;
        private System.Windows.Forms.DataGridView dgOrdini;
        internal System.Windows.Forms.Button btnDispense;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mittente;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.GroupBox gbColorInfo;
        private System.Windows.Forms.Label lblUso;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblCColori;
        private System.Windows.Forms.Label lblProdotto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Utilizzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prodotto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem markAsDispensedToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteEmailToolStripMenuItem;


    }
}