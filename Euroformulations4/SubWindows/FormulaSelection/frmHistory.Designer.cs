namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgDati = new System.Windows.Forms.DataGridView();
            this.hist_id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_rgb2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_color2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_formulasize2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_product2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_charts2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hist_use2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutPanel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.TableLayoutPanel2.ColumnCount = 1;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Controls.Add(this.Panel3, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.dgDati, 0, 2);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 3;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(722, 603);
            this.TableLayoutPanel2.TabIndex = 6;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.Controls.Add(this.pbHelp);
            this.Panel3.Controls.Add(this.lblTitolo);
            this.Panel3.Controls.Add(this.PictureBox1);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(3, 3);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(716, 44);
            this.Panel3.TabIndex = 5;
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(665, 4);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 7;
            this.pbHelp.TabStop = false;
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(48, 16);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(151, 21);
            this.lblTitolo.TabIndex = 3;
            this.lblTitolo.Text = "Formula history";
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox1.BackgroundImage")));
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Location = new System.Drawing.Point(7, 6);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(32, 32);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hist_id2,
            this.hist_rgb2,
            this.hist_date2,
            this.hist_color2,
            this.hist_formulasize2,
            this.hist_product2,
            this.hist_charts2,
            this.hist_use2,
            this.fill});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDati.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDati.EnableHeadersVisualStyles = false;
            this.dgDati.Location = new System.Drawing.Point(3, 53);
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
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDati.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgDati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDati.Size = new System.Drawing.Size(716, 547);
            this.dgDati.TabIndex = 17;
            this.dgDati.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDati_CellDoubleClick);
            this.dgDati.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDati_KeyDown);
            // 
            // hist_id2
            // 
            this.hist_id2.HeaderText = "ID";
            this.hist_id2.Name = "hist_id2";
            this.hist_id2.ReadOnly = true;
            this.hist_id2.Visible = false;
            // 
            // hist_rgb2
            // 
            this.hist_rgb2.HeaderText = "Preview";
            this.hist_rgb2.Name = "hist_rgb2";
            this.hist_rgb2.ReadOnly = true;
            // 
            // hist_date2
            // 
            this.hist_date2.HeaderText = "Date";
            this.hist_date2.Name = "hist_date2";
            this.hist_date2.ReadOnly = true;
            // 
            // hist_color2
            // 
            this.hist_color2.HeaderText = "Color";
            this.hist_color2.Name = "hist_color2";
            this.hist_color2.ReadOnly = true;
            // 
            // hist_formulasize2
            // 
            this.hist_formulasize2.HeaderText = "Size";
            this.hist_formulasize2.Name = "hist_formulasize2";
            this.hist_formulasize2.ReadOnly = true;
            // 
            // hist_product2
            // 
            this.hist_product2.HeaderText = "Product";
            this.hist_product2.Name = "hist_product2";
            this.hist_product2.ReadOnly = true;
            // 
            // hist_charts2
            // 
            this.hist_charts2.HeaderText = "Colorcharts";
            this.hist_charts2.Name = "hist_charts2";
            this.hist_charts2.ReadOnly = true;
            // 
            // hist_use2
            // 
            this.hist_use2.HeaderText = "Use";
            this.hist_use2.Name = "hist_use2";
            this.hist_use2.ReadOnly = true;
            // 
            // fill
            // 
            this.fill.HeaderText = "Fill level";
            this.fill.Name = "fill";
            this.fill.ReadOnly = true;
            // 
            // frmHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 603);
            this.Controls.Add(this.TableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Name = "frmHistory";
            this.Text = "History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHistory_FormClosing);
            this.Load += new System.EventHandler(this.frmHistory_Load);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label lblTitolo;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.DataGridView dgDati;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_rgb2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_date2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_color2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_formulasize2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_product2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_charts2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hist_use2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fill;

    }
}