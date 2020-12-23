namespace Euroformulations4.SubWindows.Statistiche
{
    partial class frmStatSpace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatSpace));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TabImage16 = new System.Windows.Forms.ImageList(this.components);
            this.TableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Scolor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.filterproductColor = new System.Windows.Forms.ComboBox();
            this.gbTo = new System.Windows.Forms.GroupBox();
            this.ColorAl = new System.Windows.Forms.DateTimePicker();
            this.Label7 = new System.Windows.Forms.Label();
            this.gbFrom = new System.Windows.Forms.GroupBox();
            this.ColorDal = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.TableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scolor)).BeginInit();
            this.Panel4.SuspendLayout();
            this.gbProduct.SuspendLayout();
            this.gbTo.SuspendLayout();
            this.gbFrom.SuspendLayout();
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
            // TableLayoutPanel4
            // 
            this.TableLayoutPanel4.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel4.ColumnCount = 1;
            this.TableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel4.Controls.Add(this.Scolor, 0, 1);
            this.TableLayoutPanel4.Controls.Add(this.Panel4, 0, 0);
            this.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel4.Name = "TableLayoutPanel4";
            this.TableLayoutPanel4.RowCount = 2;
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.TableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel4.Size = new System.Drawing.Size(695, 581);
            this.TableLayoutPanel4.TabIndex = 13;
            // 
            // Scolor
            // 
            this.Scolor.BackColor = System.Drawing.Color.Transparent;
            this.Scolor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Scolor.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            this.Scolor.BackImageTransparentColor = System.Drawing.Color.White;
            this.Scolor.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.IsEndLabelVisible = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Maximum = 360D;
            chartArea1.AxisX.MaximumAutoSize = 0F;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.ScaleBreakStyle.Spacing = 0D;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.Interval = 0D;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Transparent;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Transparent;
            chartArea1.CursorY.Interval = 0D;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Transparent;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "SpazioColore";
            this.Scolor.ChartAreas.Add(chartArea1);
            this.Scolor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scolor.Location = new System.Drawing.Point(0, 152);
            this.Scolor.Margin = new System.Windows.Forms.Padding(0);
            this.Scolor.Name = "Scolor";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series1.BorderWidth = 0;
            series1.ChartArea = "SpazioColore";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
            series1.EmptyPointStyle.IsVisibleInLegend = false;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series1.MarkerBorderWidth = 2;
            series1.MarkerColor = System.Drawing.Color.White;
            series1.MarkerSize = 1;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "SpazioColore";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent;
            series1.SmartLabelStyle.Enabled = false;
            series1.YValuesPerPoint = 2;
            this.Scolor.Series.Add(series1);
            this.Scolor.Size = new System.Drawing.Size(695, 429);
            this.Scolor.TabIndex = 2;
            this.Scolor.Text = "Chart1";
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.White;
            this.Panel4.Controls.Add(this.gbProduct);
            this.Panel4.Controls.Add(this.gbTo);
            this.Panel4.Controls.Add(this.Label7);
            this.Panel4.Controls.Add(this.gbFrom);
            this.Panel4.Controls.Add(this.btnSearch);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(3, 3);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(689, 146);
            this.Panel4.TabIndex = 0;
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.filterproductColor);
            this.gbProduct.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbProduct.Location = new System.Drawing.Point(9, 69);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(276, 54);
            this.gbProduct.TabIndex = 24;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Product";
            // 
            // filterproductColor
            // 
            this.filterproductColor.BackColor = System.Drawing.Color.White;
            this.filterproductColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterproductColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterproductColor.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterproductColor.FormattingEnabled = true;
            this.filterproductColor.Location = new System.Drawing.Point(3, 20);
            this.filterproductColor.Name = "filterproductColor";
            this.filterproductColor.Size = new System.Drawing.Size(270, 26);
            this.filterproductColor.TabIndex = 20;
            // 
            // gbTo
            // 
            this.gbTo.Controls.Add(this.ColorAl);
            this.gbTo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbTo.Location = new System.Drawing.Point(150, 9);
            this.gbTo.Name = "gbTo";
            this.gbTo.Size = new System.Drawing.Size(135, 54);
            this.gbTo.TabIndex = 23;
            this.gbTo.TabStop = false;
            this.gbTo.Text = "To";
            // 
            // ColorAl
            // 
            this.ColorAl.CustomFormat = "";
            this.ColorAl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorAl.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ColorAl.Location = new System.Drawing.Point(3, 20);
            this.ColorAl.Name = "ColorAl";
            this.ColorAl.Size = new System.Drawing.Size(129, 24);
            this.ColorAl.TabIndex = 19;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.Blue;
            this.Label7.Location = new System.Drawing.Point(706, 128);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(253, 18);
            this.Label7.TabIndex = 4;
            this.Label7.Text = ". . PROCESSING . . PLEASE WAIT . .";
            this.Label7.Visible = false;
            // 
            // gbFrom
            // 
            this.gbFrom.Controls.Add(this.ColorDal);
            this.gbFrom.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbFrom.Location = new System.Drawing.Point(9, 9);
            this.gbFrom.Name = "gbFrom";
            this.gbFrom.Size = new System.Drawing.Size(135, 54);
            this.gbFrom.TabIndex = 22;
            this.gbFrom.TabStop = false;
            this.gbFrom.Text = "From";
            // 
            // ColorDal
            // 
            this.ColorDal.CustomFormat = "";
            this.ColorDal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColorDal.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorDal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ColorDal.Location = new System.Drawing.Point(3, 20);
            this.ColorDal.Name = "ColorDal";
            this.ColorDal.Size = new System.Drawing.Size(129, 24);
            this.ColorDal.TabIndex = 18;
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
            this.btnSearch.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(474, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(206, 38);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmStatSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 581);
            this.Controls.Add(this.TableLayoutPanel4);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStatSpace";
            this.Text = "Statistic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStatSpace_FormClosing);
            this.Load += new System.EventHandler(this.frmStatistiche_Load);
            this.TableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Scolor)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.gbProduct.ResumeLayout(false);
            this.gbTo.ResumeLayout(false);
            this.gbFrom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList TabImage16;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel4;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.DateTimePicker ColorDal;
        internal System.Windows.Forms.DateTimePicker ColorAl;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox filterproductColor;
        internal System.Windows.Forms.DataVisualization.Charting.Chart Scolor;
        private System.Windows.Forms.GroupBox gbFrom;
        private System.Windows.Forms.GroupBox gbTo;
        private System.Windows.Forms.GroupBox gbProduct;

    }
}