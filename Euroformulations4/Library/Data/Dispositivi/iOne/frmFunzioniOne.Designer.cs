namespace Euroformulations4.Library.Data.Dispositivi
{
    partial class frmFunzioniOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunzioniOne));
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pBoxWhite = new System.Windows.Forms.PictureBox();
            this.pBoxConnected = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnected)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnWhite.FlatAppearance.BorderSize = 2;
            this.btnWhite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhite.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnWhite.Location = new System.Drawing.Point(12, 12);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(210, 38);
            this.btnWhite.TabIndex = 0;
            this.btnWhite.Text = "White Calibration";
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.White;
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConnect.FlatAppearance.BorderSize = 2;
            this.btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(12, 121);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(210, 38);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect i1Pro";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pBoxWhite
            // 
            this.pBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.pBoxWhite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxWhite.BackgroundImage")));
            this.pBoxWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBoxWhite.Location = new System.Drawing.Point(332, 12);
            this.pBoxWhite.Name = "pBoxWhite";
            this.pBoxWhite.Size = new System.Drawing.Size(43, 38);
            this.pBoxWhite.TabIndex = 4;
            this.pBoxWhite.TabStop = false;
            this.pBoxWhite.Visible = false;
            // 
            // pBoxConnected
            // 
            this.pBoxConnected.BackColor = System.Drawing.Color.Transparent;
            this.pBoxConnected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxConnected.BackgroundImage")));
            this.pBoxConnected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBoxConnected.Location = new System.Drawing.Point(332, 121);
            this.pBoxConnected.Name = "pBoxConnected";
            this.pBoxConnected.Size = new System.Drawing.Size(43, 38);
            this.pBoxConnected.TabIndex = 6;
            this.pBoxConnected.TabStop = false;
            this.pBoxConnected.Visible = false;
            // 
            // frmFunzioniOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 259);
            this.Controls.Add(this.pBoxConnected);
            this.Controls.Add(this.pBoxWhite);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnWhite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 286);
            this.Name = "frmFunzioniOne";
            this.Text = "XRite i1Pro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.Load += new System.EventHandler(this.frmCalibraStrumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWhite;
        internal System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pBoxWhite;
        private System.Windows.Forms.PictureBox pBoxConnected;
    }
}