namespace Euroformulations4.SubWindows.Statistiche
{
    partial class frmGrafico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGrafico));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PrintGrafico = new System.Windows.Forms.Button();
            this.chartPB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.anteprimaDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.stampaDialog = new System.Windows.Forms.PrintDialog();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPB)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.chartPB, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(917, 561);
            this.TableLayoutPanel1.TabIndex = 5;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.PrintGrafico);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 514);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(911, 44);
            this.Panel1.TabIndex = 2;
            // 
            // PrintGrafico
            // 
            this.PrintGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintGrafico.BackColor = System.Drawing.Color.White;
            this.PrintGrafico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrintGrafico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintGrafico.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.PrintGrafico.FlatAppearance.BorderSize = 2;
            this.PrintGrafico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.PrintGrafico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.PrintGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintGrafico.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.PrintGrafico.Image = ((System.Drawing.Image)(resources.GetObject("PrintGrafico.Image")));
            this.PrintGrafico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintGrafico.Location = new System.Drawing.Point(696, 3);
            this.PrintGrafico.Name = "PrintGrafico";
            this.PrintGrafico.Size = new System.Drawing.Size(206, 38);
            this.PrintGrafico.TabIndex = 3;
            this.PrintGrafico.Text = "Print";
            this.PrintGrafico.UseVisualStyleBackColor = false;
            this.PrintGrafico.Click += new System.EventHandler(this.PrintGrafico_Click);
            // 
            // chartPB
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chartPB.ChartAreas.Add(chartArea1);
            this.chartPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPB.Location = new System.Drawing.Point(3, 3);
            this.chartPB.Name = "chartPB";
            this.chartPB.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Emboss";
            series1.Name = "Series1";
            this.chartPB.Series.Add(series1);
            this.chartPB.Size = new System.Drawing.Size(911, 505);
            this.chartPB.TabIndex = 3;
            this.chartPB.Text = "chart";
            title1.Name = "Basiutilizzate";
            this.chartPB.Titles.Add(title1);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // anteprimaDialog
            // 
            this.anteprimaDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.anteprimaDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.anteprimaDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.anteprimaDialog.Enabled = true;
            this.anteprimaDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("anteprimaDialog.Icon")));
            this.anteprimaDialog.Name = "PrintPreviewDialog1";
            this.anteprimaDialog.Visible = false;
            // 
            // stampaDialog
            // 
            this.stampaDialog.UseEXDialog = true;
            // 
            // frmGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 561);
            this.Controls.Add(this.TableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(925, 588);
            this.Name = "frmGrafico";
            this.Text = "Charts";
            this.Load += new System.EventHandler(this.frmGrafico_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPB;
        internal System.Windows.Forms.Button PrintGrafico;
        internal System.Drawing.Printing.PrintDocument printDocument;
        internal System.Windows.Forms.PrintPreviewDialog anteprimaDialog;
        private System.Windows.Forms.PrintDialog stampaDialog;
    }
}