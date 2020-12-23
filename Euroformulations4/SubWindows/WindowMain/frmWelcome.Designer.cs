namespace Euroformulations4.SubWindows.WindowMain
{
    partial class frmWelcome
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
            this.pbSfondo = new System.Windows.Forms.PictureBox();
            this.lblSelect2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSfondo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSfondo
            // 
            this.pbSfondo.BackColor = System.Drawing.Color.Transparent;
            this.pbSfondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSfondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSfondo.Location = new System.Drawing.Point(0, 0);
            this.pbSfondo.Margin = new System.Windows.Forms.Padding(0);
            this.pbSfondo.Name = "pbSfondo";
            this.pbSfondo.Size = new System.Drawing.Size(684, 471);
            this.pbSfondo.TabIndex = 3;
            this.pbSfondo.TabStop = false;
            this.pbSfondo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSfondo_Paint);
            // 
            // lblSelect2
            // 
            this.lblSelect2.AutoSize = true;
            this.lblSelect2.Font = new System.Drawing.Font("Comfortaa", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.lblSelect2.Location = new System.Drawing.Point(12, 25);
            this.lblSelect2.Name = "lblSelect2";
            this.lblSelect2.Size = new System.Drawing.Size(560, 37);
            this.lblSelect2.TabIndex = 4;
            this.lblSelect2.Text = "Select a function from the left menu";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.lblInfo.Location = new System.Drawing.Point(15, 441);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(519, 21);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "for informations write to euroformulations@eurocolori.com";
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 471);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblSelect2);
            this.Controls.Add(this.pbSfondo);
            this.DoubleBuffered = true;
            this.Name = "frmWelcome";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.frmLicense_Load);
            this.ResizeBegin += new System.EventHandler(this.frmWelcome_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.frmWelcome_ResizeEnd);
            this.Resize += new System.EventHandler(this.frmWelcome_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbSfondo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSfondo;
        private System.Windows.Forms.Label lblSelect2;
        private System.Windows.Forms.Label lblInfo;




    }
}