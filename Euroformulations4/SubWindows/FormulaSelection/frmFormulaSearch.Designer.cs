namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmFormulaSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulaSearch));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.groupUse = new System.Windows.Forms.GroupBox();
            this.cmbUse = new System.Windows.Forms.ComboBox();
            this.groupColorcharts = new System.Windows.Forms.GroupBox();
            this.cmbColorCharts = new System.Windows.Forms.ComboBox();
            this.groupProduct = new System.Windows.Forms.GroupBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.groupColorName = new System.Windows.Forms.GroupBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.picWait = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgDati = new System.Windows.Forms.DataGridView();
            this.IDFormula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorcharts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vUso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.g = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.b = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.groupUse.SuspendLayout();
            this.groupColorcharts.SuspendLayout();
            this.groupProduct.SuspendLayout();
            this.groupColorName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.Controls.Add(this.pbHelp);
            this.Panel2.Controls.Add(this.groupUse);
            this.Panel2.Controls.Add(this.groupColorcharts);
            this.Panel2.Controls.Add(this.groupProduct);
            this.Panel2.Controls.Add(this.groupColorName);
            this.Panel2.Controls.Add(this.picWait);
            this.Panel2.Controls.Add(this.btnSearch);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 0);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(714, 114);
            this.Panel2.TabIndex = 7;
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(660, 71);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 5;
            this.pbHelp.TabStop = false;
            // 
            // groupUse
            // 
            this.groupUse.Controls.Add(this.cmbUse);
            this.groupUse.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupUse.Location = new System.Drawing.Point(243, 59);
            this.groupUse.Name = "groupUse";
            this.groupUse.Size = new System.Drawing.Size(225, 44);
            this.groupUse.TabIndex = 3;
            this.groupUse.TabStop = false;
            this.groupUse.Text = "Use";
            // 
            // cmbUse
            // 
            this.cmbUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUse.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUse.FormattingEnabled = true;
            this.cmbUse.Location = new System.Drawing.Point(6, 17);
            this.cmbUse.Name = "cmbUse";
            this.cmbUse.Size = new System.Drawing.Size(212, 23);
            this.cmbUse.TabIndex = 0;
            this.cmbUse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchcolor_KeyPress);
            // 
            // groupColorcharts
            // 
            this.groupColorcharts.Controls.Add(this.cmbColorCharts);
            this.groupColorcharts.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupColorcharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupColorcharts.Location = new System.Drawing.Point(243, 12);
            this.groupColorcharts.Name = "groupColorcharts";
            this.groupColorcharts.Size = new System.Drawing.Size(225, 44);
            this.groupColorcharts.TabIndex = 2;
            this.groupColorcharts.TabStop = false;
            this.groupColorcharts.Text = "Colorcharts";
            // 
            // cmbColorCharts
            // 
            this.cmbColorCharts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColorCharts.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColorCharts.FormattingEnabled = true;
            this.cmbColorCharts.Location = new System.Drawing.Point(6, 17);
            this.cmbColorCharts.Name = "cmbColorCharts";
            this.cmbColorCharts.Size = new System.Drawing.Size(212, 23);
            this.cmbColorCharts.TabIndex = 0;
            this.cmbColorCharts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchcolor_KeyPress);
            // 
            // groupProduct
            // 
            this.groupProduct.Controls.Add(this.cmbProduct);
            this.groupProduct.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupProduct.Location = new System.Drawing.Point(12, 59);
            this.groupProduct.Name = "groupProduct";
            this.groupProduct.Size = new System.Drawing.Size(225, 44);
            this.groupProduct.TabIndex = 1;
            this.groupProduct.TabStop = false;
            this.groupProduct.Text = "Product";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(6, 17);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(212, 23);
            this.cmbProduct.TabIndex = 0;
            this.cmbProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchcolor_KeyPress);
            // 
            // groupColorName
            // 
            this.groupColorName.Controls.Add(this.txtColor);
            this.groupColorName.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupColorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupColorName.Location = new System.Drawing.Point(12, 9);
            this.groupColorName.Name = "groupColorName";
            this.groupColorName.Size = new System.Drawing.Size(225, 44);
            this.groupColorName.TabIndex = 0;
            this.groupColorName.TabStop = false;
            this.groupColorName.Text = "Color name";
            // 
            // txtColor
            // 
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColor.Location = new System.Drawing.Point(7, 15);
            this.txtColor.Multiline = true;
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(212, 24);
            this.txtColor.TabIndex = 0;
            this.txtColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchcolor_KeyPress);
            // 
            // picWait
            // 
            this.picWait.Image = global::Euroformulations4.Properties.Resources.wait;
            this.picWait.Location = new System.Drawing.Point(521, 24);
            this.picWait.Name = "picWait";
            this.picWait.Size = new System.Drawing.Size(16, 16);
            this.picWait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picWait.TabIndex = 3;
            this.picWait.TabStop = false;
            this.picWait.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(543, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(159, 38);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.Search_Click);
            // 
            // dgDati
            // 
            this.dgDati.AllowUserToAddRows = false;
            this.dgDati.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDati.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDati.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDFormula,
            this.preview,
            this.color,
            this.product,
            this.colorcharts,
            this.vUso,
            this.vBase,
            this.r,
            this.g,
            this.b});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDati.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDati.EnableHeadersVisualStyles = false;
            this.dgDati.Location = new System.Drawing.Point(0, 114);
            this.dgDati.MultiSelect = false;
            this.dgDati.Name = "dgDati";
            this.dgDati.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDati.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDati.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDati.Size = new System.Drawing.Size(714, 489);
            this.dgDati.TabIndex = 0;
            this.dgDati.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDati_CellDoubleClick);
            this.dgDati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDati_KeyDown);
            // 
            // IDFormula
            // 
            this.IDFormula.HeaderText = "IDFormula";
            this.IDFormula.Name = "IDFormula";
            this.IDFormula.ReadOnly = true;
            this.IDFormula.Visible = false;
            // 
            // preview
            // 
            this.preview.HeaderText = "preview";
            this.preview.Name = "preview";
            this.preview.ReadOnly = true;
            // 
            // color
            // 
            this.color.HeaderText = "color";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // product
            // 
            this.product.HeaderText = "product";
            this.product.Name = "product";
            this.product.ReadOnly = true;
            // 
            // colorcharts
            // 
            this.colorcharts.HeaderText = "colorcharts";
            this.colorcharts.Name = "colorcharts";
            this.colorcharts.ReadOnly = true;
            // 
            // vUso
            // 
            this.vUso.HeaderText = "Use";
            this.vUso.Name = "vUso";
            this.vUso.ReadOnly = true;
            // 
            // vBase
            // 
            this.vBase.HeaderText = "vBase";
            this.vBase.Name = "vBase";
            this.vBase.ReadOnly = true;
            this.vBase.Visible = false;
            // 
            // r
            // 
            this.r.HeaderText = "r";
            this.r.Name = "r";
            this.r.ReadOnly = true;
            this.r.Visible = false;
            // 
            // g
            // 
            this.g.HeaderText = "g";
            this.g.Name = "g";
            this.g.ReadOnly = true;
            this.g.Visible = false;
            // 
            // b
            // 
            this.b.HeaderText = "b";
            this.b.Name = "b";
            this.b.ReadOnly = true;
            this.b.Visible = false;
            // 
            // frmFormulaSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 603);
            this.Controls.Add(this.dgDati);
            this.Controls.Add(this.Panel2);
            this.DoubleBuffered = true;
            this.Name = "frmFormulaSearch";
            this.Text = "Formula Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFormulaSearch_FormClosing);
            this.Load += new System.EventHandler(this.frmFormulaSearch_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.groupUse.ResumeLayout(false);
            this.groupColorcharts.ResumeLayout(false);
            this.groupProduct.ResumeLayout(false);
            this.groupColorName.ResumeLayout(false);
            this.groupColorName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.PictureBox picWait;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.DataGridView dgDati;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn product;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorcharts;
        private System.Windows.Forms.DataGridViewTextBoxColumn vUso;
        private System.Windows.Forms.DataGridViewTextBoxColumn vBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn r;
        private System.Windows.Forms.DataGridViewTextBoxColumn g;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.GroupBox groupUse;
        private System.Windows.Forms.ComboBox cmbUse;
        private System.Windows.Forms.GroupBox groupColorcharts;
        private System.Windows.Forms.ComboBox cmbColorCharts;
        private System.Windows.Forms.GroupBox groupProduct;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.GroupBox groupColorName;
        private System.Windows.Forms.PictureBox pbHelp;


    }
}