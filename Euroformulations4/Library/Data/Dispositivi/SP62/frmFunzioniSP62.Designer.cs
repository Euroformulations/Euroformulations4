﻿namespace Euroformulations4.Library.Data.Dispositivi
{
    partial class frmFunzioniSP62
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunzioniSP62));
            this.btnConnect = new System.Windows.Forms.Button();
            this.pBoxConnected = new System.Windows.Forms.PictureBox();
            this.txtComPort = new System.Windows.Forms.TextBox();
            this.gbCom = new System.Windows.Forms.GroupBox();
            this.pBoxBlack = new System.Windows.Forms.PictureBox();
            this.pBoxWhite = new System.Windows.Forms.PictureBox();
            this.btnBlack = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnected)).BeginInit();
            this.gbCom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).BeginInit();
            this.SuspendLayout();
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
            this.btnConnect.Location = new System.Drawing.Point(12, 209);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(210, 38);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pBoxConnected
            // 
            this.pBoxConnected.BackColor = System.Drawing.Color.Transparent;
            this.pBoxConnected.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxConnected.BackgroundImage")));
            this.pBoxConnected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBoxConnected.Location = new System.Drawing.Point(283, 209);
            this.pBoxConnected.Name = "pBoxConnected";
            this.pBoxConnected.Size = new System.Drawing.Size(43, 38);
            this.pBoxConnected.TabIndex = 6;
            this.pBoxConnected.TabStop = false;
            this.pBoxConnected.Visible = false;
            // 
            // txtComPort
            // 
            this.txtComPort.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComPort.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComPort.ForeColor = System.Drawing.Color.Black;
            this.txtComPort.Location = new System.Drawing.Point(3, 20);
            this.txtComPort.Name = "txtComPort";
            this.txtComPort.Size = new System.Drawing.Size(204, 17);
            this.txtComPort.TabIndex = 8;
            // 
            // gbCom
            // 
            this.gbCom.Controls.Add(this.txtComPort);
            this.gbCom.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCom.Location = new System.Drawing.Point(12, 155);
            this.gbCom.Name = "gbCom";
            this.gbCom.Size = new System.Drawing.Size(210, 48);
            this.gbCom.TabIndex = 9;
            this.gbCom.TabStop = false;
            this.gbCom.Text = "COM Port";
            // 
            // pBoxBlack
            // 
            this.pBoxBlack.BackColor = System.Drawing.Color.Transparent;
            this.pBoxBlack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxBlack.BackgroundImage")));
            this.pBoxBlack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBoxBlack.Location = new System.Drawing.Point(283, 85);
            this.pBoxBlack.Name = "pBoxBlack";
            this.pBoxBlack.Size = new System.Drawing.Size(43, 38);
            this.pBoxBlack.TabIndex = 13;
            this.pBoxBlack.TabStop = false;
            this.pBoxBlack.Visible = false;
            // 
            // pBoxWhite
            // 
            this.pBoxWhite.BackColor = System.Drawing.Color.Transparent;
            this.pBoxWhite.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBoxWhite.BackgroundImage")));
            this.pBoxWhite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pBoxWhite.Location = new System.Drawing.Point(283, 12);
            this.pBoxWhite.Name = "pBoxWhite";
            this.pBoxWhite.Size = new System.Drawing.Size(43, 38);
            this.pBoxWhite.TabIndex = 12;
            this.pBoxWhite.TabStop = false;
            this.pBoxWhite.Visible = false;
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.White;
            this.btnBlack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnBlack.FlatAppearance.BorderSize = 2;
            this.btnBlack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBlack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlack.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnBlack.Location = new System.Drawing.Point(12, 85);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(210, 38);
            this.btnBlack.TabIndex = 11;
            this.btnBlack.Text = "Black Calibration";
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
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
            this.btnWhite.TabIndex = 10;
            this.btnWhite.Text = "White Calibration";
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // frmFunzioniSP62
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(503, 259);
            this.Controls.Add(this.pBoxBlack);
            this.Controls.Add(this.pBoxWhite);
            this.Controls.Add(this.btnBlack);
            this.Controls.Add(this.btnWhite);
            this.Controls.Add(this.gbCom);
            this.Controls.Add(this.pBoxConnected);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 286);
            this.Name = "frmFunzioniSP62";
            this.Text = "XRite SP62";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.Load += new System.EventHandler(this.frmCalibraStrumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxConnected)).EndInit();
            this.gbCom.ResumeLayout(false);
            this.gbCom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxWhite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.PictureBox pBoxConnected;
        private System.Windows.Forms.TextBox txtComPort;
        private System.Windows.Forms.GroupBox gbCom;
        private System.Windows.Forms.PictureBox pBoxBlack;
        private System.Windows.Forms.PictureBox pBoxWhite;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnWhite;
    }
}