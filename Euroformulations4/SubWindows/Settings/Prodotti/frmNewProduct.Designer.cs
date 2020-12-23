namespace Euroformulations4.SubWindows.Settings.Prodotti
{
    partial class frmNewProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewProduct));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lstProdotti = new System.Windows.Forms.ListBox();
            this.btnSalva = new System.Windows.Forms.Button();
            this.txtNomeProdotto = new System.Windows.Forms.TextBox();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.dgDati = new System.Windows.Forms.DataGridView();
            this.originalbasename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).BeginInit();
            this.SuspendLayout();
            // 
            // lstProdotti
            // 
            this.lstProdotti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProdotti.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProdotti.FormattingEnabled = true;
            this.lstProdotti.ItemHeight = 18;
            this.lstProdotti.Location = new System.Drawing.Point(12, 36);
            this.lstProdotti.Name = "lstProdotti";
            this.lstProdotti.Size = new System.Drawing.Size(264, 94);
            this.lstProdotti.TabIndex = 0;
            this.lstProdotti.SelectedIndexChanged += new System.EventHandler(this.lstProdotti_SelectedIndexChanged);
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalva.BackColor = System.Drawing.Color.White;
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSalva.FlatAppearance.BorderSize = 2;
            this.btnSalva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSalva.Image = ((System.Drawing.Image)(resources.GetObject("btnSalva.Image")));
            this.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalva.Location = new System.Drawing.Point(12, 433);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(121, 38);
            this.btnSalva.TabIndex = 20;
            this.btnSalva.Text = "Save";
            this.btnSalva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // txtNomeProdotto
            // 
            this.txtNomeProdotto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeProdotto.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProdotto.Location = new System.Drawing.Point(15, 180);
            this.txtNomeProdotto.Name = "txtNomeProdotto";
            this.txtNomeProdotto.Size = new System.Drawing.Size(388, 24);
            this.txtNomeProdotto.TabIndex = 21;
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep2.Location = new System.Drawing.Point(12, 159);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(221, 18);
            this.lblStep2.TabIndex = 22;
            this.lblStep2.Text = "2 - Insert new product name";
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep1.Location = new System.Drawing.Point(12, 17);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(153, 18);
            this.lblStep1.TabIndex = 23;
            this.lblStep1.Text = "1 - Select a product";
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStep3.Location = new System.Drawing.Point(12, 242);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(306, 18);
            this.lblStep3.TabIndex = 24;
            this.lblStep3.Text = "3 - update base name and type density";
            // 
            // dgDati
            // 
            this.dgDati.AllowUserToAddRows = false;
            this.dgDati.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDati.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDati.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDati.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.originalbasename,
            this.basename,
            this.density});
            this.dgDati.EnableHeadersVisualStyles = false;
            this.dgDati.Location = new System.Drawing.Point(12, 262);
            this.dgDati.Margin = new System.Windows.Forms.Padding(2);
            this.dgDati.MultiSelect = false;
            this.dgDati.Name = "dgDati";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDati.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgDati.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgDati.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDati.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgDati.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDati.Size = new System.Drawing.Size(391, 157);
            this.dgDati.TabIndex = 25;
            this.dgDati.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgDati_EditingControlShowing);
            this.dgDati.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgDati_KeyPress);
            // 
            // originalbasename
            // 
            this.originalbasename.HeaderText = "originalbasename";
            this.originalbasename.Name = "originalbasename";
            this.originalbasename.Visible = false;
            // 
            // basename
            // 
            this.basename.HeaderText = "basename";
            this.basename.Name = "basename";
            // 
            // density
            // 
            this.density.HeaderText = "density";
            this.density.Name = "density";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(282, 36);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 35);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmNewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(417, 483);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgDati);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep1);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.txtNomeProdotto);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.lstProdotti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewProduct";
            this.Text = "Product management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewProduct_FormClosing);
            this.Load += new System.EventHandler(this.frmNewProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDati)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstProdotti;
        internal System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TextBox txtNomeProdotto;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.DataGridView dgDati;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalbasename;
        private System.Windows.Forms.DataGridViewTextBoxColumn basename;
        private System.Windows.Forms.DataGridViewTextBoxColumn density;
        private System.Windows.Forms.Button btnDelete;
    }
}