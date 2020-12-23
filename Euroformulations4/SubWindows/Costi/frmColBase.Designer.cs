namespace Euroformulations4.SubWindows.Costi
{
    partial class frmColBase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListPriceList = new System.Windows.Forms.ListBox();
            this.gbUnit = new System.Windows.Forms.GroupBox();
            this.cmbUnita = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabColoranti = new System.Windows.Forms.TabPage();
            this.dgColoranti = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeBP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitaM = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabBasi = new System.Windows.Forms.TabPage();
            this.dgBasi = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbUnit.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabColoranti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgColoranti)).BeginInit();
            this.tabBasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBasi)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 603);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.gbUnit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 146);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListPriceList);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 144);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select price list :";
            // 
            // ListPriceList
            // 
            this.ListPriceList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPriceList.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPriceList.FormattingEnabled = true;
            this.ListPriceList.ItemHeight = 18;
            this.ListPriceList.Location = new System.Drawing.Point(3, 18);
            this.ListPriceList.Margin = new System.Windows.Forms.Padding(4);
            this.ListPriceList.Name = "ListPriceList";
            this.ListPriceList.Size = new System.Drawing.Size(336, 123);
            this.ListPriceList.TabIndex = 1;
            this.ListPriceList.SelectedIndexChanged += new System.EventHandler(this.ListPriceList_SelectedIndexChanged);
            // 
            // gbUnit
            // 
            this.gbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUnit.Controls.Add(this.cmbUnita);
            this.gbUnit.Enabled = false;
            this.gbUnit.Location = new System.Drawing.Point(559, 3);
            this.gbUnit.Name = "gbUnit";
            this.gbUnit.Size = new System.Drawing.Size(147, 55);
            this.gbUnit.TabIndex = 3;
            this.gbUnit.TabStop = false;
            this.gbUnit.Text = "Unit";
            // 
            // cmbUnita
            // 
            this.cmbUnita.BackColor = System.Drawing.Color.White;
            this.cmbUnita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUnita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnita.FormattingEnabled = true;
            this.cmbUnita.Location = new System.Drawing.Point(3, 18);
            this.cmbUnita.Name = "cmbUnita";
            this.cmbUnita.Size = new System.Drawing.Size(141, 24);
            this.cmbUnita.TabIndex = 0;
            this.cmbUnita.SelectedValueChanged += new System.EventHandler(this.cmbUnita_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 158);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(714, 383);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabColoranti);
            this.tabControl1.Controls.Add(this.tabBasi);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(6, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(714, 383);
            this.tabControl1.TabIndex = 0;
            // 
            // tabColoranti
            // 
            this.tabColoranti.BackColor = System.Drawing.Color.White;
            this.tabColoranti.Controls.Add(this.dgColoranti);
            this.tabColoranti.Location = new System.Drawing.Point(4, 33);
            this.tabColoranti.Margin = new System.Windows.Forms.Padding(4);
            this.tabColoranti.Name = "tabColoranti";
            this.tabColoranti.Padding = new System.Windows.Forms.Padding(4);
            this.tabColoranti.Size = new System.Drawing.Size(706, 346);
            this.tabColoranti.TabIndex = 0;
            this.tabColoranti.Text = "Colorant cost";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgColoranti.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgColoranti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgColoranti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Preview,
            this.NomeBP,
            this.Prezzo,
            this.unitaM});
            this.dgColoranti.EnableHeadersVisualStyles = false;
            this.dgColoranti.Location = new System.Drawing.Point(4, 4);
            this.dgColoranti.Margin = new System.Windows.Forms.Padding(4);
            this.dgColoranti.MultiSelect = false;
            this.dgColoranti.Name = "dgColoranti";
            this.dgColoranti.RowHeadersVisible = false;
            this.dgColoranti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgColoranti.Size = new System.Drawing.Size(698, 338);
            this.dgColoranti.TabIndex = 2;
            this.dgColoranti.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridp_CellEndEdit);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // Preview
            // 
            this.Preview.HeaderText = "Preview";
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            // 
            // NomeBP
            // 
            this.NomeBP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeBP.HeaderText = "Colorant name";
            this.NomeBP.Name = "NomeBP";
            this.NomeBP.ReadOnly = true;
            // 
            // Prezzo
            // 
            dataGridViewCellStyle3.Format = "N6";
            dataGridViewCellStyle3.NullValue = null;
            this.Prezzo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Prezzo.HeaderText = "Price";
            this.Prezzo.Name = "Prezzo";
            // 
            // unitaM
            // 
            this.unitaM.HeaderText = "Unit";
            this.unitaM.Items.AddRange(new object[] {
            "KG",
            "L"});
            this.unitaM.Name = "unitaM";
            // 
            // tabBasi
            // 
            this.tabBasi.BackColor = System.Drawing.Color.White;
            this.tabBasi.Controls.Add(this.dgBasi);
            this.tabBasi.Location = new System.Drawing.Point(4, 33);
            this.tabBasi.Margin = new System.Windows.Forms.Padding(4);
            this.tabBasi.Name = "tabBasi";
            this.tabBasi.Padding = new System.Windows.Forms.Padding(4);
            this.tabBasi.Size = new System.Drawing.Size(706, 346);
            this.tabBasi.TabIndex = 1;
            this.tabBasi.Text = "Base cost";
            // 
            // dgBasi
            // 
            this.dgBasi.AllowUserToAddRows = false;
            this.dgBasi.AllowUserToDeleteRows = false;
            this.dgBasi.AllowUserToOrderColumns = true;
            this.dgBasi.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgBasi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgBasi.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBasi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgBasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewComboBoxColumn1});
            this.dgBasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBasi.EnableHeadersVisualStyles = false;
            this.dgBasi.Location = new System.Drawing.Point(4, 4);
            this.dgBasi.Margin = new System.Windows.Forms.Padding(4);
            this.dgBasi.MultiSelect = false;
            this.dgBasi.Name = "dgBasi";
            this.dgBasi.RowHeadersVisible = false;
            this.dgBasi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgBasi.Size = new System.Drawing.Size(698, 338);
            this.dgBasi.TabIndex = 3;
            this.dgBasi.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridb_CellEndEdit);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Base name:";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn3.HeaderText = "Price:";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Unit:";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "KG",
            "L"});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 549);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(714, 50);
            this.panel3.TabIndex = 2;
            // 
            // frmColBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(722, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmColBase";
            this.Text = "Insert cost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmColBase_FormClosing);
            this.Load += new System.EventHandler(this.frmColBase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbUnit.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabColoranti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgColoranti)).EndInit();
            this.tabBasi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListPriceList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabColoranti;
        private System.Windows.Forms.TabPage tabBasi;
        internal System.Windows.Forms.DataGridView dgColoranti;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.DataGridView dgBasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeBP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezzo;
        private System.Windows.Forms.DataGridViewComboBoxColumn unitaM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbUnit;
        private System.Windows.Forms.ComboBox cmbUnita;
    }
}