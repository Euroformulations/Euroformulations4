namespace Euroformulations4.SubWindows.ErogazioneLibera
{
    partial class frmFreeDispenser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFreeDispenser));
            this.btnDispense = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbDispenser = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.cmbListino = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDispense
            // 
            this.btnDispense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDispense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDispense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDispense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDispense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDispense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDispense.Image = ((System.Drawing.Image)(resources.GetObject("btnDispense.Image")));
            this.btnDispense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDispense.Location = new System.Drawing.Point(468, 514);
            this.btnDispense.Margin = new System.Windows.Forms.Padding(4);
            this.btnDispense.Name = "btnDispense";
            this.btnDispense.Size = new System.Drawing.Size(241, 43);
            this.btnDispense.TabIndex = 4;
            this.btnDispense.Text = "Dispense";
            this.btnDispense.UseVisualStyleBackColor = false;
            this.btnDispense.Click += new System.EventHandler(this.SendToDispenser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(704, 449);
            this.dataGridView1.TabIndex = 5;
            // 
            // cmbDispenser
            // 
            this.cmbDispenser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDispenser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispenser.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDispenser.FormattingEnabled = true;
            this.cmbDispenser.Location = new System.Drawing.Point(469, 564);
            this.cmbDispenser.Name = "cmbDispenser";
            this.cmbDispenser.Size = new System.Drawing.Size(241, 26);
            this.cmbDispenser.Sorted = true;
            this.cmbDispenser.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("Comfortaa", 9.75F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 506);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Erogazione libera";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 19);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(241, 26);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 7;
            // 
            // cmbListino
            // 
            this.cmbListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbListino.BackColor = System.Drawing.Color.White;
            this.cmbListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListino.Enabled = false;
            this.cmbListino.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbListino.FormattingEnabled = true;
            this.cmbListino.Location = new System.Drawing.Point(0, 25);
            this.cmbListino.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.cmbListino.Name = "cmbListino";
            this.cmbListino.Size = new System.Drawing.Size(716, 26);
            this.cmbListino.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(469, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(241, 36);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.clear_Click);
            // 
            // frmFreeDispenser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(722, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbDispenser);
            this.Controls.Add(this.btnDispense);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFreeDispenser";
            this.Text = "FreeDispenser";
            this.Load += new System.EventHandler(this.frmFreeDispenser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnDispense;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.ComboBox cmbDispenser;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.ComboBox cmbListino;
        private System.Windows.Forms.Button btnClear;
    }
}