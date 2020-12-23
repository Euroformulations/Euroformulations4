namespace Euroformulations4.SubWindows.Settings
{
    partial class frmDBImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBImport));
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.lblDeltaWarning = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBar
            // 
            this.pBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBar.Location = new System.Drawing.Point(0, 92);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(540, 23);
            this.pBar.TabIndex = 0;
            // 
            // lblDeltaWarning
            // 
            this.lblDeltaWarning.AutoSize = true;
            this.lblDeltaWarning.Font = new System.Drawing.Font("Comfortaa", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeltaWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.lblDeltaWarning.Location = new System.Drawing.Point(191, 32);
            this.lblDeltaWarning.Name = "lblDeltaWarning";
            this.lblDeltaWarning.Size = new System.Drawing.Size(123, 31);
            this.lblDeltaWarning.TabIndex = 24;
            this.lblDeltaWarning.Text = "Loading ";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Comfortaa", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.lblPercentage.Location = new System.Drawing.Point(320, 32);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(36, 31);
            this.lblPercentage.TabIndex = 25;
            this.lblPercentage.Text = "%";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(12, 9);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(81, 13);
            this.lblStato.TabIndex = 28;
            this.lblStato.Text = "1/3 Initializing...";
            // 
            // frmDBImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(540, 115);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblDeltaWarning);
            this.Controls.Add(this.pBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDBImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EuroFormulations4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBar;
        internal System.Windows.Forms.Label lblDeltaWarning;
        internal System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblStato;
    }
}