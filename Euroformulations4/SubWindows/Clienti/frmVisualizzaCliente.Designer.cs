namespace Euroformulations4.SubWindows.Clienti
{
    partial class frmVisualizzaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizzaCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbBarcode = new System.Windows.Forms.GroupBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.TxtCustomerLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbHelp1 = new System.Windows.Forms.PictureBox();
            this.comboPricelist = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgClienti = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomepaese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmSClienti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemEditCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDeleteCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TabImage16 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClienti)).BeginInit();
            this.CmSClienti.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 603);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbBarcode);
            this.panel1.Controls.Add(this.TxtCustomerLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(716, 44);
            this.panel1.TabIndex = 1;
            // 
            // gbBarcode
            // 
            this.gbBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBarcode.Controls.Add(this.txtBarcode);
            this.gbBarcode.Location = new System.Drawing.Point(465, 3);
            this.gbBarcode.Name = "gbBarcode";
            this.gbBarcode.Size = new System.Drawing.Size(248, 38);
            this.gbBarcode.TabIndex = 36;
            this.gbBarcode.TabStop = false;
            this.gbBarcode.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBarcode.Location = new System.Drawing.Point(3, 16);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(242, 20);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // TxtCustomerLabel
            // 
            this.TxtCustomerLabel.AutoSize = true;
            this.TxtCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCustomerLabel.Location = new System.Drawing.Point(41, 7);
            this.TxtCustomerLabel.Name = "TxtCustomerLabel";
            this.TxtCustomerLabel.Size = new System.Drawing.Size(161, 24);
            this.TxtCustomerLabel.TabIndex = 1;
            this.TxtCustomerLabel.Text = "View Customers";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbHelp1);
            this.panel2.Controls.Add(this.comboPricelist);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ComboFilter);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.FilterName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(716, 44);
            this.panel2.TabIndex = 2;
            // 
            // pbHelp1
            // 
            this.pbHelp1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp1.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp1.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp1.Location = new System.Drawing.Point(665, 4);
            this.pbHelp1.Name = "pbHelp1";
            this.pbHelp1.Size = new System.Drawing.Size(42, 37);
            this.pbHelp1.TabIndex = 35;
            this.pbHelp1.TabStop = false;
            // 
            // comboPricelist
            // 
            this.comboPricelist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPricelist.FormattingEnabled = true;
            this.comboPricelist.Location = new System.Drawing.Point(267, 11);
            this.comboPricelist.Name = "comboPricelist";
            this.comboPricelist.Size = new System.Drawing.Size(198, 24);
            this.comboPricelist.TabIndex = 11;
            this.comboPricelist.Visible = false;
            this.comboPricelist.SelectedIndexChanged += new System.EventHandler(this.comboPricelist_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(471, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "( Use \'%\'  for all characters )";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboFilter
            // 
            this.ComboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilter.FormattingEnabled = true;
            this.ComboFilter.Location = new System.Drawing.Point(100, 11);
            this.ComboFilter.Name = "ComboFilter";
            this.ComboFilter.Size = new System.Drawing.Size(161, 24);
            this.ComboFilter.TabIndex = 1;
            this.ComboFilter.SelectedIndexChanged += new System.EventHandler(this.ComboFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter by";
            // 
            // FilterName
            // 
            this.FilterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterName.Location = new System.Drawing.Point(267, 12);
            this.FilterName.Name = "FilterName";
            this.FilterName.Size = new System.Drawing.Size(198, 22);
            this.FilterName.TabIndex = 2;
            this.FilterName.TextChanged += new System.EventHandler(this.FilterName_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 497);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgClienti, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(716, 497);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // dgClienti
            // 
            this.dgClienti.AllowUserToAddRows = false;
            this.dgClienti.AllowUserToDeleteRows = false;
            this.dgClienti.AllowUserToOrderColumns = true;
            this.dgClienti.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClienti.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgClienti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgClienti.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgClienti.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgClienti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClienti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn3,
            this.Quantity,
            this.nomepaese,
            this.email,
            this.PriceList});
            this.dgClienti.ContextMenuStrip = this.CmSClienti;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgClienti.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgClienti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgClienti.EnableHeadersVisualStyles = false;
            this.dgClienti.Location = new System.Drawing.Point(3, 3);
            this.dgClienti.MultiSelect = false;
            this.dgClienti.Name = "dgClienti";
            this.dgClienti.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgClienti.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgClienti.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgClienti.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgClienti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgClienti.Size = new System.Drawing.Size(710, 451);
            this.dgClienti.TabIndex = 3;
            this.dgClienti.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RicercaClienti_CellMouseClick);
            this.dgClienti.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RicercaClienti_CellMouseDoubleClick);
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "ID";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            this.DataGridViewTextBoxColumn1.Visible = false;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.HeaderText = "Name";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewTextBoxColumn3.HeaderText = "Surname";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Company";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // nomepaese
            // 
            this.nomepaese.HeaderText = "Vat";
            this.nomepaese.Name = "nomepaese";
            this.nomepaese.ReadOnly = true;
            // 
            // email
            // 
            this.email.HeaderText = "E-Mail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // PriceList
            // 
            this.PriceList.HeaderText = "Price List";
            this.PriceList.Name = "PriceList";
            this.PriceList.ReadOnly = true;
            // 
            // CmSClienti
            // 
            this.CmSClienti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEditCustomer,
            this.itemDeleteCustomer,
            this.itemNewCustomer});
            this.CmSClienti.Name = "CmSClienti";
            this.CmSClienti.Size = new System.Drawing.Size(154, 70);
            this.CmSClienti.Opening += new System.ComponentModel.CancelEventHandler(this.CmSClienti_Opening);
            // 
            // itemEditCustomer
            // 
            this.itemEditCustomer.Image = ((System.Drawing.Image)(resources.GetObject("itemEditCustomer.Image")));
            this.itemEditCustomer.Name = "itemEditCustomer";
            this.itemEditCustomer.Size = new System.Drawing.Size(153, 22);
            this.itemEditCustomer.Text = "Details";
            this.itemEditCustomer.Click += new System.EventHandler(this.modificaCliente_Click);
            // 
            // itemDeleteCustomer
            // 
            this.itemDeleteCustomer.Image = ((System.Drawing.Image)(resources.GetObject("itemDeleteCustomer.Image")));
            this.itemDeleteCustomer.Name = "itemDeleteCustomer";
            this.itemDeleteCustomer.Size = new System.Drawing.Size(153, 22);
            this.itemDeleteCustomer.Text = "Delete";
            this.itemDeleteCustomer.Click += new System.EventHandler(this.CancellaCliente_Click);
            // 
            // itemNewCustomer
            // 
            this.itemNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("itemNewCustomer.Image")));
            this.itemNewCustomer.Name = "itemNewCustomer";
            this.itemNewCustomer.Size = new System.Drawing.Size(153, 22);
            this.itemNewCustomer.Text = "New Customer";
            this.itemNewCustomer.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 457);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(716, 40);
            this.panel4.TabIndex = 12;
            // 
            // TabImage16
            // 
            this.TabImage16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabImage16.ImageStream")));
            this.TabImage16.TransparentColor = System.Drawing.Color.Transparent;
            this.TabImage16.Images.SetKeyName(0, "wall clock.png");
            this.TabImage16.Images.SetKeyName(1, "documents7.png");
            // 
            // frmVisualizzaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisualizzaCliente";
            this.Text = "View Customers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisualizzaCliente_FormClosing);
            this.Load += new System.EventHandler(this.frmVisualizzaCliente_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbBarcode.ResumeLayout(false);
            this.gbBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClienti)).EndInit();
            this.CmSClienti.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TxtCustomerLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FilterName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ContextMenuStrip CmSClienti;
        private System.Windows.Forms.ToolStripMenuItem itemEditCustomer;
        private System.Windows.Forms.ToolStripMenuItem itemDeleteCustomer;
        internal System.Windows.Forms.DataGridView dgClienti;
        private System.Windows.Forms.ComboBox ComboFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomepaese;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceList;
        private System.Windows.Forms.ComboBox comboPricelist;
        private System.Windows.Forms.ToolStripMenuItem itemNewCustomer;
        internal System.Windows.Forms.ImageList TabImage16;
        private System.Windows.Forms.PictureBox pbHelp1;
        private System.Windows.Forms.GroupBox gbBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
    }
}