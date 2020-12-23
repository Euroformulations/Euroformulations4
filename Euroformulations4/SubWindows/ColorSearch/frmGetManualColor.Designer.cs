namespace Euroformulations4.SubWindows.ColorSearch
{
    partial class frmGetManualColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetManualColor));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtL = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.gbDefaultDevice = new System.Windows.Forms.GroupBox();
            this.cmbDispositivi = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDefaultDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(192, 76);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(183, 38);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtL);
            this.groupBox1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CIEL*";
            // 
            // txtL
            // 
            this.txtL.Location = new System.Drawing.Point(6, 19);
            this.txtL.Name = "txtL";
            this.txtL.Size = new System.Drawing.Size(134, 24);
            this.txtL.TabIndex = 0;
            this.txtL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtA);
            this.groupBox2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CIEa*";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(6, 19);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(134, 24);
            this.txtA.TabIndex = 0;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtB);
            this.groupBox3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(146, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CIEb*";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(6, 19);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(134, 24);
            this.txtB.TabIndex = 0;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtL_KeyPress);
            // 
            // gbDefaultDevice
            // 
            this.gbDefaultDevice.Controls.Add(this.cmbDispositivi);
            this.gbDefaultDevice.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefaultDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbDefaultDevice.Location = new System.Drawing.Point(192, 12);
            this.gbDefaultDevice.Name = "gbDefaultDevice";
            this.gbDefaultDevice.Size = new System.Drawing.Size(183, 48);
            this.gbDefaultDevice.TabIndex = 23;
            this.gbDefaultDevice.TabStop = false;
            this.gbDefaultDevice.Text = "Device";
            // 
            // cmbDispositivi
            // 
            this.cmbDispositivi.BackColor = System.Drawing.Color.White;
            this.cmbDispositivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispositivi.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDispositivi.FormattingEnabled = true;
            this.cmbDispositivi.Location = new System.Drawing.Point(6, 19);
            this.cmbDispositivi.Name = "cmbDispositivi";
            this.cmbDispositivi.Size = new System.Drawing.Size(171, 26);
            this.cmbDispositivi.TabIndex = 24;
            // 
            // frmGetManualColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 190);
            this.Controls.Add(this.gbDefaultDevice);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfirm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetManualColor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGetManualColor_FormClosed);
            this.Load += new System.EventHandler(this.frmGetManualColor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDefaultDevice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.GroupBox gbDefaultDevice;
        internal System.Windows.Forms.ComboBox cmbDispositivi;
    }
}