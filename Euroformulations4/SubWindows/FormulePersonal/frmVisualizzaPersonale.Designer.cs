namespace Euroformulations4.SubWindows.FormulePersonal
{
    partial class frmVisualizzaPersonale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizzaPersonale));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtCustomerLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbHelp = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ComboFilter = new System.Windows.Forms.ComboBox();
            this.FilterName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgFormulePersonali = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomepaese = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datacreazione = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmSClienti = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemEditFormula = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDeleteFormula = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormulePersonali)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 600);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtCustomerLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 44);
            this.panel1.TabIndex = 1;
            // 
            // TxtCustomerLabel
            // 
            this.TxtCustomerLabel.AutoSize = true;
            this.TxtCustomerLabel.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCustomerLabel.Location = new System.Drawing.Point(41, 7);
            this.TxtCustomerLabel.Name = "TxtCustomerLabel";
            this.TxtCustomerLabel.Size = new System.Drawing.Size(255, 25);
            this.TxtCustomerLabel.TabIndex = 1;
            this.TxtCustomerLabel.Text = "View Personal Formulas";
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
            this.panel2.Controls.Add(this.pbHelp);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.ComboFilter);
            this.panel2.Controls.Add(this.FilterName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 48);
            this.panel2.TabIndex = 2;
            // 
            // pbHelp
            // 
            this.pbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHelp.BackgroundImage = global::Euroformulations4.Properties.Resources.help;
            this.pbHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.pbHelp.Location = new System.Drawing.Point(645, 8);
            this.pbHelp.Name = "pbHelp";
            this.pbHelp.Size = new System.Drawing.Size(42, 37);
            this.pbHelp.TabIndex = 11;
            this.pbHelp.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(457, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "( Use \'%\'  for all characters )";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // ComboFilter
            // 
            this.ComboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFilter.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboFilter.FormattingEnabled = true;
            this.ComboFilter.Location = new System.Drawing.Point(106, 12);
            this.ComboFilter.Name = "ComboFilter";
            this.ComboFilter.Size = new System.Drawing.Size(141, 26);
            this.ComboFilter.TabIndex = 1;
            // 
            // FilterName
            // 
            this.FilterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterName.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterName.Location = new System.Drawing.Point(253, 12);
            this.FilterName.Name = "FilterName";
            this.FilterName.Size = new System.Drawing.Size(198, 26);
            this.FilterName.TabIndex = 2;
            this.FilterName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilterName_KeyUp);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgFormulePersonali);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(696, 490);
            this.panel3.TabIndex = 3;
            // 
            // dgFormulePersonali
            // 
            this.dgFormulePersonali.AllowUserToAddRows = false;
            this.dgFormulePersonali.AllowUserToDeleteRows = false;
            this.dgFormulePersonali.AllowUserToOrderColumns = true;
            this.dgFormulePersonali.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFormulePersonali.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFormulePersonali.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFormulePersonali.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgFormulePersonali.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormulePersonali.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFormulePersonali.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFormulePersonali.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.nomepaese,
            this.datacreazione,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn3,
            this.Cliente,
            this.createdby,
            this.email,
            this.unit});
            this.dgFormulePersonali.ContextMenuStrip = this.CmSClienti;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgFormulePersonali.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgFormulePersonali.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFormulePersonali.EnableHeadersVisualStyles = false;
            this.dgFormulePersonali.Location = new System.Drawing.Point(0, 0);
            this.dgFormulePersonali.MultiSelect = false;
            this.dgFormulePersonali.Name = "dgFormulePersonali";
            this.dgFormulePersonali.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormulePersonali.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgFormulePersonali.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgFormulePersonali.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgFormulePersonali.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFormulePersonali.Size = new System.Drawing.Size(696, 490);
            this.dgFormulePersonali.TabIndex = 3;
            this.dgFormulePersonali.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RicercaPersonale_CellMouseDoubleClick);
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "ID";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            this.DataGridViewTextBoxColumn1.Visible = false;
            // 
            // nomepaese
            // 
            this.nomepaese.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomepaese.FillWeight = 63.45179F;
            this.nomepaese.HeaderText = "Preview";
            this.nomepaese.Name = "nomepaese";
            this.nomepaese.ReadOnly = true;
            this.nomepaese.Width = 83;
            // 
            // datacreazione
            // 
            this.datacreazione.HeaderText = "Data";
            this.datacreazione.Name = "datacreazione";
            this.datacreazione.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.FillWeight = 109.1371F;
            this.DataGridViewTextBoxColumn2.HeaderText = "Color Name";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.DataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewTextBoxColumn3.FillWeight = 109.1371F;
            this.DataGridViewTextBoxColumn3.HeaderText = "Base";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Customers";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // createdby
            // 
            this.createdby.HeaderText = "Created by";
            this.createdby.Name = "createdby";
            this.createdby.ReadOnly = true;
            // 
            // email
            // 
            this.email.FillWeight = 109.1371F;
            this.email.HeaderText = "Directory";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.HeaderText = "unit";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Visible = false;
            // 
            // CmSClienti
            // 
            this.CmSClienti.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemEditFormula,
            this.itemDeleteFormula});
            this.CmSClienti.Name = "CmSClienti";
            this.CmSClienti.Size = new System.Drawing.Size(153, 70);
            this.CmSClienti.Opening += new System.ComponentModel.CancelEventHandler(this.CmSClienti_Opening);
            // 
            // itemEditFormula
            // 
            this.itemEditFormula.Image = ((System.Drawing.Image)(resources.GetObject("itemEditFormula.Image")));
            this.itemEditFormula.Name = "itemEditFormula";
            this.itemEditFormula.Size = new System.Drawing.Size(152, 22);
            this.itemEditFormula.Text = "Modification";
            this.itemEditFormula.Click += new System.EventHandler(this.modificaFormula_Click);
            // 
            // itemDeleteFormula
            // 
            this.itemDeleteFormula.Image = ((System.Drawing.Image)(resources.GetObject("itemDeleteFormula.Image")));
            this.itemDeleteFormula.Name = "itemDeleteFormula";
            this.itemDeleteFormula.Size = new System.Drawing.Size(152, 22);
            this.itemDeleteFormula.Text = "Delete";
            this.itemDeleteFormula.Click += new System.EventHandler(this.CancellaCliente_Click);
            // 
            // frmVisualizzaPersonale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmVisualizzaPersonale";
            this.Text = "Personal Formulations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVisualizzaPersonale_FormClosing);
            this.Load += new System.EventHandler(this.frmVisualizzaPersonale_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFormulePersonali)).EndInit();
            this.CmSClienti.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TxtCustomerLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilterName;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.DataGridView dgFormulePersonali;
        private System.Windows.Forms.ContextMenuStrip CmSClienti;
        private System.Windows.Forms.ToolStripMenuItem itemEditFormula;
        private System.Windows.Forms.ToolStripMenuItem itemDeleteFormula;
        private System.Windows.Forms.PictureBox pbHelp;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomepaese;
        private System.Windows.Forms.DataGridViewTextBoxColumn datacreazione;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdby;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
    }
}