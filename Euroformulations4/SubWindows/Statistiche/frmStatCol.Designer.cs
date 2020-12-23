namespace Euroformulations4.SubWindows.Statistiche
{
    partial class frmStatCol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatCol));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabImage16 = new System.Windows.Forms.ImageList(this.components);
            this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnPrintColoranti = new System.Windows.Forms.Button();
            this.gbUse = new System.Windows.Forms.GroupBox();
            this.FilterUse = new System.Windows.Forms.ComboBox();
            this.btnGraphColoranti = new System.Windows.Forms.Button();
            this.inelaborazione = new System.Windows.Forms.Label();
            this.gbChart = new System.Windows.Forms.GroupBox();
            this.FilterColorCharts = new System.Windows.Forms.ComboBox();
            this.gbPaints = new System.Windows.Forms.GroupBox();
            this.FilterBase = new System.Windows.Forms.ComboBox();
            this.exeFilter = new System.Windows.Forms.Button();
            this.gbTo = new System.Windows.Forms.GroupBox();
            this.AlDate = new System.Windows.Forms.DateTimePicker();
            this.gbFrom = new System.Windows.Forms.GroupBox();
            this.DalDate = new System.Windows.Forms.DateTimePicker();
            this.dgColoranti = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel3.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.gbUse.SuspendLayout();
            this.gbChart.SuspendLayout();
            this.gbPaints.SuspendLayout();
            this.gbTo.SuspendLayout();
            this.gbFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgColoranti)).BeginInit();
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
            // TableLayoutPanel3
            // 
            this.TableLayoutPanel3.ColumnCount = 1;
            this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Controls.Add(this.Panel3, 0, 0);
            this.TableLayoutPanel3.Controls.Add(this.dgColoranti, 0, 1);
            this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel3.Name = "TableLayoutPanel3";
            this.TableLayoutPanel3.RowCount = 2;
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel3.Size = new System.Drawing.Size(695, 581);
            this.TableLayoutPanel3.TabIndex = 11;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.Controls.Add(this.btnPrintColoranti);
            this.Panel3.Controls.Add(this.gbUse);
            this.Panel3.Controls.Add(this.btnGraphColoranti);
            this.Panel3.Controls.Add(this.inelaborazione);
            this.Panel3.Controls.Add(this.gbChart);
            this.Panel3.Controls.Add(this.gbPaints);
            this.Panel3.Controls.Add(this.exeFilter);
            this.Panel3.Controls.Add(this.gbTo);
            this.Panel3.Controls.Add(this.gbFrom);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(689, 256);
            this.Panel3.TabIndex = 0;
            
            // 
            // gbUse
            // 
            this.gbUse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUse.Controls.Add(this.FilterUse);
            this.gbUse.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbUse.Location = new System.Drawing.Point(9, 181);
            this.gbUse.Name = "gbUse";
            this.gbUse.Size = new System.Drawing.Size(257, 60);
            this.gbUse.TabIndex = 19;
            this.gbUse.TabStop = false;
            this.gbUse.Text = "Use";
            // 
            // FilterUse
            // 
            this.FilterUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterUse.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterUse.FormattingEnabled = true;
            this.FilterUse.Location = new System.Drawing.Point(3, 20);
            this.FilterUse.Name = "FilterUse";
            this.FilterUse.Size = new System.Drawing.Size(251, 26);
            this.FilterUse.TabIndex = 5;
            // 
            // btnGraphColoranti
            // 
            this.btnGraphColoranti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraphColoranti.BackColor = System.Drawing.Color.White;
            this.btnGraphColoranti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGraphColoranti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraphColoranti.Enabled = false;
            this.btnGraphColoranti.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnGraphColoranti.FlatAppearance.BorderSize = 2;
            this.btnGraphColoranti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraphColoranti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraphColoranti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraphColoranti.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraphColoranti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnGraphColoranti.Image = ((System.Drawing.Image)(resources.GetObject("btnGraphColoranti.Image")));
            this.btnGraphColoranti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGraphColoranti.Location = new System.Drawing.Point(480, 47);
            this.btnGraphColoranti.Name = "btnGraphColoranti";
            this.btnGraphColoranti.Size = new System.Drawing.Size(206, 38);
            this.btnGraphColoranti.TabIndex = 7;
            this.btnGraphColoranti.Text = "View Graph";
            this.btnGraphColoranti.UseVisualStyleBackColor = false;
            this.btnGraphColoranti.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnGraphColoranti.Click += new System.EventHandler(this.btnColorantsGraph_Click);
            // 
            // inelaborazione
            // 
            this.inelaborazione.AutoSize = true;
            this.inelaborazione.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inelaborazione.ForeColor = System.Drawing.Color.Blue;
            this.inelaborazione.Location = new System.Drawing.Point(427, 238);
            this.inelaborazione.Name = "inelaborazione";
            this.inelaborazione.Size = new System.Drawing.Size(253, 18);
            this.inelaborazione.TabIndex = 4;
            this.inelaborazione.Text = ". . PROCESSING . . PLEASE WAIT . .";
            this.inelaborazione.Visible = false;
            // 
            // gbChart
            // 
            this.gbChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChart.Controls.Add(this.FilterColorCharts);
            this.gbChart.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbChart.Location = new System.Drawing.Point(9, 124);
            this.gbChart.Name = "gbChart";
            this.gbChart.Size = new System.Drawing.Size(257, 51);
            this.gbChart.TabIndex = 18;
            this.gbChart.TabStop = false;
            this.gbChart.Text = "Color Charts";
            // 
            // FilterColorCharts
            // 
            this.FilterColorCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterColorCharts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterColorCharts.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterColorCharts.FormattingEnabled = true;
            this.FilterColorCharts.Location = new System.Drawing.Point(3, 20);
            this.FilterColorCharts.Name = "FilterColorCharts";
            this.FilterColorCharts.Size = new System.Drawing.Size(251, 26);
            this.FilterColorCharts.TabIndex = 4;
            // 
            // gbPaints
            // 
            this.gbPaints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPaints.Controls.Add(this.FilterBase);
            this.gbPaints.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPaints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbPaints.Location = new System.Drawing.Point(9, 66);
            this.gbPaints.Name = "gbPaints";
            this.gbPaints.Size = new System.Drawing.Size(257, 52);
            this.gbPaints.TabIndex = 17;
            this.gbPaints.TabStop = false;
            this.gbPaints.Text = "Base Paints";
            // 
            // FilterBase
            // 
            this.FilterBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterBase.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterBase.FormattingEnabled = true;
            this.FilterBase.Location = new System.Drawing.Point(3, 20);
            this.FilterBase.Name = "FilterBase";
            this.FilterBase.Size = new System.Drawing.Size(251, 26);
            this.FilterBase.TabIndex = 3;
            // 
            // exeFilter
            // 
            this.exeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exeFilter.BackColor = System.Drawing.Color.White;
            this.exeFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exeFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exeFilter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.exeFilter.FlatAppearance.BorderSize = 2;
            this.exeFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.exeFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.exeFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exeFilter.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exeFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.exeFilter.Image = ((System.Drawing.Image)(resources.GetObject("exeFilter.Image")));
            this.exeFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exeFilter.Location = new System.Drawing.Point(480, 3);
            this.exeFilter.Name = "exeFilter";
            this.exeFilter.Size = new System.Drawing.Size(206, 38);
            this.exeFilter.TabIndex = 6;
            this.exeFilter.Text = "Search";
            this.exeFilter.UseVisualStyleBackColor = false;
            this.exeFilter.Click += new System.EventHandler(this.exeFilter_Click);
            // 
            // gbTo
            // 
            this.gbTo.Controls.Add(this.AlDate);
            this.gbTo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbTo.Location = new System.Drawing.Point(158, 7);
            this.gbTo.Name = "gbTo";
            this.gbTo.Size = new System.Drawing.Size(124, 53);
            this.gbTo.TabIndex = 16;
            this.gbTo.TabStop = false;
            this.gbTo.Text = "To";
            // 
            // AlDate
            // 
            this.AlDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlDate.CustomFormat = "";
            this.AlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlDate.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.AlDate.Location = new System.Drawing.Point(3, 20);
            this.AlDate.Name = "AlDate";
            this.AlDate.Size = new System.Drawing.Size(118, 24);
            this.AlDate.TabIndex = 2;
            // 
            // gbFrom
            // 
            this.gbFrom.Controls.Add(this.DalDate);
            this.gbFrom.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbFrom.Location = new System.Drawing.Point(9, 7);
            this.gbFrom.Name = "gbFrom";
            this.gbFrom.Size = new System.Drawing.Size(127, 53);
            this.gbFrom.TabIndex = 15;
            this.gbFrom.TabStop = false;
            this.gbFrom.Text = "From";
            // 
            // DalDate
            // 
            this.DalDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DalDate.CustomFormat = "";
            this.DalDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DalDate.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DalDate.Location = new System.Drawing.Point(3, 20);
            this.DalDate.Name = "DalDate";
            this.DalDate.Size = new System.Drawing.Size(121, 24);
            this.DalDate.TabIndex = 1;
            this.DalDate.Value = new System.DateTime(2014, 11, 5, 0, 0, 0, 0);
            // 
            // dgColoranti
            // 
            this.dgColoranti.AllowUserToAddRows = false;
            this.dgColoranti.AllowUserToDeleteRows = false;
            this.dgColoranti.AllowUserToOrderColumns = true;
            this.dgColoranti.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgColoranti.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgColoranti.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgColoranti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgColoranti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColoranti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn3,
            this.Quantity});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgColoranti.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgColoranti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgColoranti.EnableHeadersVisualStyles = false;
            this.dgColoranti.Location = new System.Drawing.Point(3, 265);
            this.dgColoranti.Name = "dgColoranti";
            this.dgColoranti.ReadOnly = true;
            this.dgColoranti.RowHeadersVisible = false;
            this.dgColoranti.Size = new System.Drawing.Size(689, 313);
            this.dgColoranti.TabIndex = 9;
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "ID";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            this.DataGridViewTextBoxColumn1.Visible = false;
            this.DataGridViewTextBoxColumn1.Width = 5;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumn2.HeaderText = "Colorant name";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewTextBoxColumn3.HeaderText = "Usage ( % )";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            this.DataGridViewTextBoxColumn3.Width = 150;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 150;
            // 
            // frmStatCol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 581);
            this.Controls.Add(this.TableLayoutPanel3);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStatCol";
            this.Text = "Statistic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStatCol_FormClosing);
            this.Load += new System.EventHandler(this.frmStatistiche_Load);
            this.TableLayoutPanel3.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.gbUse.ResumeLayout(false);
            this.gbChart.ResumeLayout(false);
            this.gbPaints.ResumeLayout(false);
            this.gbTo.ResumeLayout(false);
            this.gbFrom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgColoranti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList TabImage16;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel3;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button exeFilter;
        internal System.Windows.Forms.DateTimePicker DalDate;
        internal System.Windows.Forms.DateTimePicker AlDate;
        internal System.Windows.Forms.Label inelaborazione;
        internal System.Windows.Forms.ComboBox FilterBase;
        internal System.Windows.Forms.Button btnPrintColoranti;
        internal System.Windows.Forms.Button btnGraphColoranti;
        internal System.Windows.Forms.DataGridView dgColoranti;
        internal System.Windows.Forms.ComboBox FilterUse;
        internal System.Windows.Forms.ComboBox FilterColorCharts;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.GroupBox gbFrom;
        private System.Windows.Forms.GroupBox gbTo;
        private System.Windows.Forms.GroupBox gbUse;
        private System.Windows.Forms.GroupBox gbChart;
        private System.Windows.Forms.GroupBox gbPaints;

    }
}