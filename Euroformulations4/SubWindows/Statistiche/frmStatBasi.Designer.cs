namespace Euroformulations4.SubWindows.Statistiche
{
    partial class frmStatBasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatBasi));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabImage16 = new System.Windows.Forms.ImageList(this.components);
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.gbUse = new System.Windows.Forms.GroupBox();
            this.filterUseBase = new System.Windows.Forms.ComboBox();
            this.gbChart = new System.Windows.Forms.GroupBox();
            this.filterChartsBase = new System.Windows.Forms.ComboBox();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.FilterProduct = new System.Windows.Forms.ComboBox();
            this.gbTo = new System.Windows.Forms.GroupBox();
            this.BaseAl = new System.Windows.Forms.DateTimePicker();
            this.gbFrom = new System.Windows.Forms.GroupBox();
            this.BaseDal = new System.Windows.Forms.DateTimePicker();
            this.exeFilterBase = new System.Windows.Forms.Button();
            this.btnGraphBasi = new System.Windows.Forms.Button();
            this.belaborazione = new System.Windows.Forms.Label();
            this.dgBasi = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityKG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.gbUse.SuspendLayout();
            this.gbChart.SuspendLayout();
            this.gbProduct.SuspendLayout();
            this.gbTo.SuspendLayout();
            this.gbFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBasi)).BeginInit();
            this.SuspendLayout();
            // 
            // TabImage16
            // 
            this.TabImage16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabImage16.ImageStream")));
            this.TabImage16.TransparentColor = System.Drawing.Color.Transparent;
            this.TabImage16.Images.SetKeyName(0, "1413378770_color-fill.png");
            this.TabImage16.Images.SetKeyName(1, "1413378767_color.png");
            this.TabImage16.Images.SetKeyName(2, "1413567424_color_wheel.png");
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Controls.Add(this.Panel2, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.dgBasi, 0, 1);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 2;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(695, 581);
            this.TableLayoutPanel2.TabIndex = 12;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.Controls.Add(this.gbUse);
            this.Panel2.Controls.Add(this.gbChart);
            this.Panel2.Controls.Add(this.gbProduct);
            this.Panel2.Controls.Add(this.gbTo);
            this.Panel2.Controls.Add(this.gbFrom);
            this.Panel2.Controls.Add(this.exeFilterBase);
            this.Panel2.Controls.Add(this.btnGraphBasi);
            this.Panel2.Controls.Add(this.belaborazione);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 3);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(689, 253);
            this.Panel2.TabIndex = 0;
            // 
            // gbUse
            // 
            this.gbUse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUse.Controls.Add(this.filterUseBase);
            this.gbUse.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbUse.Location = new System.Drawing.Point(9, 183);
            this.gbUse.Name = "gbUse";
            this.gbUse.Size = new System.Drawing.Size(257, 60);
            this.gbUse.TabIndex = 24;
            this.gbUse.TabStop = false;
            this.gbUse.Text = "Use";
            // 
            // filterUseBase
            // 
            this.filterUseBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterUseBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterUseBase.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterUseBase.FormattingEnabled = true;
            this.filterUseBase.Location = new System.Drawing.Point(3, 20);
            this.filterUseBase.Name = "filterUseBase";
            this.filterUseBase.Size = new System.Drawing.Size(251, 26);
            this.filterUseBase.TabIndex = 14;
            // 
            // gbChart
            // 
            this.gbChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChart.Controls.Add(this.filterChartsBase);
            this.gbChart.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbChart.Location = new System.Drawing.Point(9, 126);
            this.gbChart.Name = "gbChart";
            this.gbChart.Size = new System.Drawing.Size(257, 51);
            this.gbChart.TabIndex = 23;
            this.gbChart.TabStop = false;
            this.gbChart.Text = "Color Charts";
            // 
            // filterChartsBase
            // 
            this.filterChartsBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterChartsBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterChartsBase.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterChartsBase.FormattingEnabled = true;
            this.filterChartsBase.Location = new System.Drawing.Point(3, 20);
            this.filterChartsBase.Name = "filterChartsBase";
            this.filterChartsBase.Size = new System.Drawing.Size(251, 26);
            this.filterChartsBase.TabIndex = 13;
            // 
            // gbProduct
            // 
            this.gbProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProduct.Controls.Add(this.FilterProduct);
            this.gbProduct.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbProduct.Location = new System.Drawing.Point(9, 68);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(257, 52);
            this.gbProduct.TabIndex = 22;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Product";
            // 
            // FilterProduct
            // 
            this.FilterProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterProduct.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterProduct.FormattingEnabled = true;
            this.FilterProduct.Location = new System.Drawing.Point(3, 20);
            this.FilterProduct.Name = "FilterProduct";
            this.FilterProduct.Size = new System.Drawing.Size(251, 26);
            this.FilterProduct.TabIndex = 12;
            // 
            // gbTo
            // 
            this.gbTo.Controls.Add(this.BaseAl);
            this.gbTo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbTo.Location = new System.Drawing.Point(158, 9);
            this.gbTo.Name = "gbTo";
            this.gbTo.Size = new System.Drawing.Size(124, 53);
            this.gbTo.TabIndex = 21;
            this.gbTo.TabStop = false;
            this.gbTo.Text = "To";
            // 
            // BaseAl
            // 
            this.BaseAl.CustomFormat = "";
            this.BaseAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseAl.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BaseAl.Location = new System.Drawing.Point(3, 20);
            this.BaseAl.Name = "BaseAl";
            this.BaseAl.Size = new System.Drawing.Size(118, 24);
            this.BaseAl.TabIndex = 11;
            // 
            // gbFrom
            // 
            this.gbFrom.Controls.Add(this.BaseDal);
            this.gbFrom.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbFrom.Location = new System.Drawing.Point(9, 9);
            this.gbFrom.Name = "gbFrom";
            this.gbFrom.Size = new System.Drawing.Size(127, 53);
            this.gbFrom.TabIndex = 20;
            this.gbFrom.TabStop = false;
            this.gbFrom.Text = "From";
            // 
            // BaseDal
            // 
            this.BaseDal.CustomFormat = "";
            this.BaseDal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseDal.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaseDal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BaseDal.Location = new System.Drawing.Point(3, 20);
            this.BaseDal.Name = "BaseDal";
            this.BaseDal.Size = new System.Drawing.Size(121, 24);
            this.BaseDal.TabIndex = 10;
            // 
            // exeFilterBase
            // 
            this.exeFilterBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exeFilterBase.BackColor = System.Drawing.Color.White;
            this.exeFilterBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exeFilterBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exeFilterBase.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(66)))));
            this.exeFilterBase.FlatAppearance.BorderSize = 2;
            this.exeFilterBase.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.exeFilterBase.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.exeFilterBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exeFilterBase.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exeFilterBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.exeFilterBase.Image = ((System.Drawing.Image)(resources.GetObject("exeFilterBase.Image")));
            this.exeFilterBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exeFilterBase.Location = new System.Drawing.Point(480, 3);
            this.exeFilterBase.Name = "exeFilterBase";
            this.exeFilterBase.Size = new System.Drawing.Size(206, 38);
            this.exeFilterBase.TabIndex = 15;
            this.exeFilterBase.Text = "Search";
            this.exeFilterBase.UseVisualStyleBackColor = false;
            this.exeFilterBase.Click += new System.EventHandler(this.exeFilterBase_Click);
            // 
            // btnGraphBasi
            // 
            this.btnGraphBasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraphBasi.BackColor = System.Drawing.Color.White;
            this.btnGraphBasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGraphBasi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraphBasi.Enabled = false;
            this.btnGraphBasi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(66)))));
            this.btnGraphBasi.FlatAppearance.BorderSize = 2;
            this.btnGraphBasi.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGraphBasi.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGraphBasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphBasi.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphBasi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnGraphBasi.Image = ((System.Drawing.Image)(resources.GetObject("btnGraphBasi.Image")));
            this.btnGraphBasi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraphBasi.Location = new System.Drawing.Point(480, 47);
            this.btnGraphBasi.Name = "btnGraphBasi";
            this.btnGraphBasi.Size = new System.Drawing.Size(206, 38);
            this.btnGraphBasi.TabIndex = 16;
            this.btnGraphBasi.Text = "View Graph";
            this.btnGraphBasi.UseVisualStyleBackColor = false;
            this.btnGraphBasi.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnGraphBasi.Click += new System.EventHandler(this.btnBasesGraph_Click);
            // 
            // belaborazione
            // 
            this.belaborazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.belaborazione.AutoSize = true;
            this.belaborazione.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.belaborazione.ForeColor = System.Drawing.Color.Blue;
            this.belaborazione.Location = new System.Drawing.Point(433, 235);
            this.belaborazione.Name = "belaborazione";
            this.belaborazione.Size = new System.Drawing.Size(217, 18);
            this.belaborazione.TabIndex = 4;
            this.belaborazione.Text = ". . PROCESSING . . PLEASE WAIT . .";
            this.belaborazione.Visible = false;
            // 
            // dgBasi
            // 
            this.dgBasi.AllowUserToAddRows = false;
            this.dgBasi.AllowUserToDeleteRows = false;
            this.dgBasi.AllowUserToOrderColumns = true;
            this.dgBasi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgBasi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBasi.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBasi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgBasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn7,
            this.DataGridViewTextBoxColumn8,
            this.DataGridViewTextBoxColumn9,
            this.DataGridViewTextBoxColumn10,
            this.QuantityKG});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBasi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgBasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBasi.EnableHeadersVisualStyles = false;
            this.dgBasi.Location = new System.Drawing.Point(3, 262);
            this.dgBasi.Name = "dgBasi";
            this.dgBasi.ReadOnly = true;
            this.dgBasi.RowHeadersVisible = false;
            this.dgBasi.Size = new System.Drawing.Size(689, 316);
            this.dgBasi.TabIndex = 9;
            // 
            // DataGridViewTextBoxColumn7
            // 
            this.DataGridViewTextBoxColumn7.HeaderText = "ID";
            this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            this.DataGridViewTextBoxColumn7.ReadOnly = true;
            this.DataGridViewTextBoxColumn7.Visible = false;
            this.DataGridViewTextBoxColumn7.Width = 5;
            // 
            // DataGridViewTextBoxColumn8
            // 
            this.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumn8.HeaderText = "Base name";
            this.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
            this.DataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewTextBoxColumn9.HeaderText = "Usage ( % )";
            this.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
            this.DataGridViewTextBoxColumn9.ReadOnly = true;
            this.DataGridViewTextBoxColumn9.Width = 150;
            // 
            // DataGridViewTextBoxColumn10
            // 
            this.DataGridViewTextBoxColumn10.HeaderText = "Quantity";
            this.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
            this.DataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // QuantityKG
            // 
            this.QuantityKG.HeaderText = "Quantity";
            this.QuantityKG.Name = "QuantityKG";
            this.QuantityKG.ReadOnly = true;
            // 
            // frmStatBasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 581);
            this.Controls.Add(this.TableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStatBasi";
            this.Text = "Statistic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStatBasi_FormClosing);
            this.Load += new System.EventHandler(this.frmStatistiche_Load);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.gbUse.ResumeLayout(false);
            this.gbChart.ResumeLayout(false);
            this.gbProduct.ResumeLayout(false);
            this.gbTo.ResumeLayout(false);
            this.gbFrom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList TabImage16;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button exeFilterBase;
        internal System.Windows.Forms.DateTimePicker BaseDal;
        internal System.Windows.Forms.DateTimePicker BaseAl;
        internal System.Windows.Forms.Label belaborazione;
        internal System.Windows.Forms.ComboBox FilterProduct;
        internal System.Windows.Forms.Button btnGraphBasi;
        internal System.Windows.Forms.DataGridView dgBasi;
        internal System.Windows.Forms.ComboBox filterUseBase;
        internal System.Windows.Forms.ComboBox filterChartsBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityKG;
        private System.Windows.Forms.GroupBox gbUse;
        private System.Windows.Forms.GroupBox gbChart;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.GroupBox gbTo;
        private System.Windows.Forms.GroupBox gbFrom;

    }
}