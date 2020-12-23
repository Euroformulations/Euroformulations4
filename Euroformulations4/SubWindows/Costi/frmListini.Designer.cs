namespace Euroformulations4.SubWindows.Costi
{
    partial class frmListini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListini));
            this.txtPriceList = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValuta = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstPriceList = new System.Windows.Forms.ListBox();
            this.importExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePriceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePriceListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.importExport.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPriceList
            // 
            this.txtPriceList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPriceList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPriceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPriceList.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceList.Location = new System.Drawing.Point(6, 53);
            this.txtPriceList.Name = "txtPriceList";
            this.txtPriceList.Size = new System.Drawing.Size(225, 24);
            this.txtPriceList.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtValuta);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtPriceList);
            this.groupBox1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Insert new price list ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(237, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Currency";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Price list name";
            // 
            // txtValuta
            // 
            this.txtValuta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtValuta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtValuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValuta.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValuta.Location = new System.Drawing.Point(237, 53);
            this.txtValuta.Name = "txtValuta";
            this.txtValuta.Size = new System.Drawing.Size(77, 24);
            this.txtValuta.TabIndex = 2;
            this.txtValuta.Text = "€";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(58, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(206, 38);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Price List";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.SalvaPriceList_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstPriceList);
            this.groupBox2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 248);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price list created";
            // 
            // lstPriceList
            // 
            this.lstPriceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPriceList.ContextMenuStrip = this.importExport;
            this.lstPriceList.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPriceList.FormattingEnabled = true;
            this.lstPriceList.ItemHeight = 18;
            this.lstPriceList.Location = new System.Drawing.Point(6, 23);
            this.lstPriceList.Name = "lstPriceList";
            this.lstPriceList.Size = new System.Drawing.Size(305, 200);
            this.lstPriceList.TabIndex = 4;
            this.lstPriceList.SelectedIndexChanged += new System.EventHandler(this.ListPriceList_SelectedIndexChanged);
            // 
            // importExport
            // 
            this.importExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.importToExcelToolStripMenuItem,
            this.deletePriceListToolStripMenuItem,
            this.updatePriceListToolStripMenuItem});
            this.importExport.Name = "contextMenuStrip1";
            this.importExport.Size = new System.Drawing.Size(168, 92);
            
            // 
            // deletePriceListToolStripMenuItem
            // 
            this.deletePriceListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deletePriceListToolStripMenuItem.Image")));
            this.deletePriceListToolStripMenuItem.Name = "deletePriceListToolStripMenuItem";
            this.deletePriceListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deletePriceListToolStripMenuItem.Text = "Remove Price List";
            this.deletePriceListToolStripMenuItem.Click += new System.EventHandler(this.deletePriceListToolStripMenuItem_Click);
            // 
            // updatePriceListToolStripMenuItem
            // 
            this.updatePriceListToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updatePriceListToolStripMenuItem.Image")));
            this.updatePriceListToolStripMenuItem.Name = "updatePriceListToolStripMenuItem";
            this.updatePriceListToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.updatePriceListToolStripMenuItem.Text = "Rename Price List";
            this.updatePriceListToolStripMenuItem.Click += new System.EventHandler(this.updatePriceListToolStripMenuItem_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 85);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Copy price list";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.BackColor = System.Drawing.Color.White;
            this.btnCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnCopy.FlatAppearance.BorderSize = 2;
            this.btnCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(58, 32);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(206, 38);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy Price List";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.CopyPriceList_Click);
            // 
            // pbHelp
            // 
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(290, 149);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 34;
            this.pbHelp.TabStop = false;
            // 
            // frmListini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(340, 541);
            this.Controls.Add(this.pbHelp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmListini";
            this.Text = "Price List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListini_FormClosing);
            this.Load += new System.EventHandler(this.frmListini_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.importExport.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPriceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstPriceList;
        internal System.Windows.Forms.TextBox txtValuta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip importExport;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToExcelToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolStripMenuItem deletePriceListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePriceListToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.PictureBox pbHelp;
    }
}