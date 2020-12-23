namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmNumErogazioni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNumErogazioni));
            this.gbNumbers = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.gbNumbers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNumbers
            // 
            this.gbNumbers.Controls.Add(this.txtNum);
            this.gbNumbers.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNumbers.Location = new System.Drawing.Point(12, 12);
            this.gbNumbers.Name = "gbNumbers";
            this.gbNumbers.Size = new System.Drawing.Size(208, 53);
            this.gbNumbers.TabIndex = 0;
            this.gbNumbers.TabStop = false;
            this.gbNumbers.Text = "Dispensing numbers";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.FlatAppearance.BorderSize = 2;
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(12, 90);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(208, 38);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnDispense_Click);
            // 
            // txtNum
            // 
            this.txtNum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtNum.Location = new System.Drawing.Point(3, 26);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(202, 24);
            this.txtNum.TabIndex = 0;
            this.txtNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_KeyPress);
            // 
            // frmNumErogazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(231, 137);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbNumbers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumErogazioni";
            this.Load += new System.EventHandler(this.frmNumErogazioni_Load);
            this.gbNumbers.ResumeLayout(false);
            this.gbNumbers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNumbers;
        private System.Windows.Forms.TextBox txtNum;
        internal System.Windows.Forms.Button btnConfirm;
    }
}