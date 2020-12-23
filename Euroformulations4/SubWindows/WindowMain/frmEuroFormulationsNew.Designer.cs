namespace Euroformulations4.SubWindows.WindowMain
{
    partial class frmEuroFormulationsNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEuroFormulationsNew));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pbArea = new System.Windows.Forms.PictureBox();
            this.lblPowered = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressUpdate = new System.Windows.Forms.ProgressBar();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArea)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pbExit);
            this.panel1.Controls.Add(this.pbArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 95);
            this.panel1.TabIndex = 1;
            // 
            // pbExit
            // 
            this.pbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExit.BackgroundImage")));
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Location = new System.Drawing.Point(925, 3);
            this.pbExit.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(22, 22);
            this.pbExit.TabIndex = 2;
            this.pbExit.TabStop = false;
            this.pbExit.Visible = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pbArea
            // 
            this.pbArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbArea.Location = new System.Drawing.Point(3, 3);
            this.pbArea.Margin = new System.Windows.Forms.Padding(0);
            this.pbArea.Name = "pbArea";
            this.pbArea.Size = new System.Drawing.Size(944, 89);
            this.pbArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbArea.TabIndex = 0;
            this.pbArea.TabStop = false;
            this.pbArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pbArea_Paint);
            // 
            // lblPowered
            // 
            this.lblPowered.AutoSize = true;
            this.lblPowered.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowered.Location = new System.Drawing.Point(6, 6);
            this.lblPowered.Name = "lblPowered";
            this.lblPowered.Size = new System.Drawing.Size(196, 18);
            this.lblPowered.TabIndex = 5;
            this.lblPowered.Text = "Powered by Eurocolori (Italy)";
            this.lblPowered.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lblPowered);
            this.panel2.Controls.Add(this.progressUpdate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 689);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 30);
            this.panel2.TabIndex = 2;
            // 
            // progressUpdate
            // 
            this.progressUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.progressUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.progressUpdate.Location = new System.Drawing.Point(234, 0);
            this.progressUpdate.Name = "progressUpdate";
            this.progressUpdate.Size = new System.Drawing.Size(716, 30);
            this.progressUpdate.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressUpdate.TabIndex = 0;
            this.progressUpdate.Visible = false;
            // 
            // menuPanel
            // 
            this.menuPanel.AutoScroll = true;
            this.menuPanel.BackColor = System.Drawing.Color.White;
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(0, 95);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(235, 594);
            this.menuPanel.TabIndex = 5;
            // 
            // frmEuroFormulationsNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 719);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(966, 758);
            this.Name = "frmEuroFormulationsNew";
            this.Text = ".";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEuroFormulationsNew_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosed);
            this.Load += new System.EventHandler(this.frmEuroFormulationsNew_Load);
            this.Shown += new System.EventHandler(this.frmEuroFormulationsNew_Shown);
            this.LocationChanged += new System.EventHandler(this.frmEuroFormulationsNew_LocationChanged);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbArea)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbArea;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.ProgressBar progressUpdate;
        private System.Windows.Forms.Label lblPowered;
    }
}