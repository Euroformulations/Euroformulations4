namespace Euroformulations4.SubWindows.WindowMain
{
    partial class frmUpdatedInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdatedInfo));
            this.chkDontShow = new System.Windows.Forms.CheckBox();
            this.lbl01 = new System.Windows.Forms.Label();
            this.lbl02 = new System.Windows.Forms.Label();
            this.lbl03 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkDontShow
            // 
            this.chkDontShow.AutoSize = true;
            this.chkDontShow.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDontShow.Location = new System.Drawing.Point(11, 411);
            this.chkDontShow.Name = "chkDontShow";
            this.chkDontShow.Size = new System.Drawing.Size(231, 22);
            this.chkDontShow.TabIndex = 0;
            this.chkDontShow.Text = "Don\'t show this message again";
            this.chkDontShow.UseVisualStyleBackColor = true;
            // 
            // lbl01
            // 
            this.lbl01.AutoSize = true;
            this.lbl01.Font = new System.Drawing.Font("Comfortaa", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl01.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.lbl01.Location = new System.Drawing.Point(143, 25);
            this.lbl01.Name = "lbl01";
            this.lbl01.Size = new System.Drawing.Size(203, 27);
            this.lbl01.TabIndex = 1;
            this.lbl01.Text = "Congratulations!";
            // 
            // lbl02
            // 
            this.lbl02.AutoSize = true;
            this.lbl02.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl02.Location = new System.Drawing.Point(7, 90);
            this.lbl02.Name = "lbl02";
            this.lbl02.Size = new System.Drawing.Size(447, 20);
            this.lbl02.TabIndex = 2;
            this.lbl02.Text = "Euroformulations4 has been updated to the latest version.";
            // 
            // lbl03
            // 
            this.lbl03.AutoSize = true;
            this.lbl03.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl03.Location = new System.Drawing.Point(8, 122);
            this.lbl03.Name = "lbl03";
            this.lbl03.Size = new System.Drawing.Size(242, 20);
            this.lbl03.TabIndex = 3;
            this.lbl03.Text = "See the latest news here below:";
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(46, 183);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(391, 174);
            this.txtData.TabIndex = 4;
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinue.BackColor = System.Drawing.Color.White;
            this.btnContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnContinue.FlatAppearance.BorderSize = 2;
            this.btnContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinue.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Location = new System.Drawing.Point(308, 402);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(171, 38);
            this.btnContinue.TabIndex = 5;
            this.btnContinue.Text = "Continue";
            this.btnContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // frmUpdatedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 449);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.lbl03);
            this.Controls.Add(this.lbl02);
            this.Controls.Add(this.lbl01);
            this.Controls.Add(this.chkDontShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdatedInfo";
            this.Text = "Software update";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdatedInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmUpdatedInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDontShow;
        private System.Windows.Forms.Label lbl01;
        private System.Windows.Forms.Label lbl02;
        private System.Windows.Forms.Label lbl03;
        private System.Windows.Forms.TextBox txtData;
        internal System.Windows.Forms.Button btnContinue;
    }
}