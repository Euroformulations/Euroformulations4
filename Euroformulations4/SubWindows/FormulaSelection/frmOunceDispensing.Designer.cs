namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmOunceDispensing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOunceDispensing));
            this.dgDati = new System.Windows.Forms.DataGridView();
            this.preview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Div1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ounce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDati
            // 
            this.dgDati.AllowUserToAddRows = false;
            this.dgDati.AllowUserToDeleteRows = false;
            this.dgDati.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgDati.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDati.BackgroundColor = System.Drawing.Color.White;
            this.dgDati.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDati.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preview,
            this.colorant,
            this.Y,
            this.Div1,
            this.ounce});
            this.dgDati.EnableHeadersVisualStyles = false;
            this.dgDati.Location = new System.Drawing.Point(12, 12);
            this.dgDati.MultiSelect = false;
            this.dgDati.Name = "dgDati";
            this.dgDati.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgDati.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgDati.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDati.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgDati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDati.Size = new System.Drawing.Size(526, 138);
            this.dgDati.TabIndex = 7;
            // 
            // preview
            // 
            this.preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.preview.HeaderText = "Preview";
            this.preview.Name = "preview";
            this.preview.ReadOnly = true;
            this.preview.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.preview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.preview.Width = 60;
            // 
            // colorant
            // 
            this.colorant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colorant.HeaderText = "Colorant";
            this.colorant.Name = "colorant";
            this.colorant.ReadOnly = true;
            this.colorant.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colorant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 60;
            // 
            // Div1
            // 
            this.Div1.HeaderText = "1/XX";
            this.Div1.Name = "Div1";
            this.Div1.ReadOnly = true;
            this.Div1.Width = 60;
            // 
            // ounce
            // 
            this.ounce.HeaderText = "1/XX";
            this.ounce.Name = "ounce";
            this.ounce.ReadOnly = true;
            this.ounce.Width = 60;
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinter.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(12, 199);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(231, 26);
            this.cmbPrinter.Sorted = true;
            this.cmbPrinter.TabIndex = 19;
            this.cmbPrinter.SelectedIndexChanged += new System.EventHandler(this.TypePrint_SelectedIndexChanged);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.UseEXDialog = true;
            // 
            // frmOunceDispensing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 228);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.dgDati);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOunceDispensing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ounce";
            this.Load += new System.EventHandler(this.frmOunceDispensing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDati;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.PrintDialog PrintDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Div1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ounce;
    }
}