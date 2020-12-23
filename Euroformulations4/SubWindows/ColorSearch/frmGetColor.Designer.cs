namespace Euroformulations4.SubWindows.ColorSearch
{
    partial class frmGetColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetColor));
            this.btnRead = new System.Windows.Forms.Button();
            this.lblL = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panPreview = new System.Windows.Forms.Panel();
            this.gbAverage = new System.Windows.Forms.GroupBox();
            this.gbCurrent = new System.Windows.Forms.GroupBox();
            this.lblLCurrent = new System.Windows.Forms.Label();
            this.lblACurrent = new System.Windows.Forms.Label();
            this.lblBCurrent = new System.Windows.Forms.Label();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbAverage.SuspendLayout();
            this.gbCurrent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.White;
            this.btnRead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnRead.FlatAppearance.BorderSize = 2;
            this.btnRead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnRead.Image = ((System.Drawing.Image)(resources.GetObject("btnRead.Image")));
            this.btnRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRead.Location = new System.Drawing.Point(8, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(208, 38);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Read color";
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblL
            // 
            this.lblL.AutoSize = true;
            this.lblL.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblL.ForeColor = System.Drawing.Color.Black;
            this.lblL.Location = new System.Drawing.Point(6, 25);
            this.lblL.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(44, 18);
            this.lblL.TabIndex = 3;
            this.lblL.Text = "CIEL*:";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblA.ForeColor = System.Drawing.Color.Black;
            this.lblA.Location = new System.Drawing.Point(6, 51);
            this.lblA.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(45, 18);
            this.lblA.TabIndex = 4;
            this.lblA.Text = "CIEa*:";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.ForeColor = System.Drawing.Color.Black;
            this.lblB.Location = new System.Drawing.Point(6, 77);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(45, 18);
            this.lblB.TabIndex = 5;
            this.lblB.Text = "CIEb*:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panPreview);
            this.groupBox1.Location = new System.Drawing.Point(222, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 244);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // panPreview
            // 
            this.panPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panPreview.Location = new System.Drawing.Point(6, 13);
            this.panPreview.Name = "panPreview";
            this.panPreview.Size = new System.Drawing.Size(115, 225);
            this.panPreview.TabIndex = 0;
            // 
            // gbAverage
            // 
            this.gbAverage.Controls.Add(this.lblL);
            this.gbAverage.Controls.Add(this.lblA);
            this.gbAverage.Controls.Add(this.lblB);
            this.gbAverage.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbAverage.Location = new System.Drawing.Point(116, 100);
            this.gbAverage.Name = "gbAverage";
            this.gbAverage.Size = new System.Drawing.Size(100, 106);
            this.gbAverage.TabIndex = 8;
            this.gbAverage.TabStop = false;
            this.gbAverage.Text = "Average";
            // 
            // gbCurrent
            // 
            this.gbCurrent.Controls.Add(this.lblLCurrent);
            this.gbCurrent.Controls.Add(this.lblACurrent);
            this.gbCurrent.Controls.Add(this.lblBCurrent);
            this.gbCurrent.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbCurrent.Location = new System.Drawing.Point(8, 100);
            this.gbCurrent.Name = "gbCurrent";
            this.gbCurrent.Size = new System.Drawing.Size(100, 106);
            this.gbCurrent.TabIndex = 9;
            this.gbCurrent.TabStop = false;
            this.gbCurrent.Text = "Current";
            // 
            // lblLCurrent
            // 
            this.lblLCurrent.AutoSize = true;
            this.lblLCurrent.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCurrent.ForeColor = System.Drawing.Color.Black;
            this.lblLCurrent.Location = new System.Drawing.Point(6, 25);
            this.lblLCurrent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblLCurrent.Name = "lblLCurrent";
            this.lblLCurrent.Size = new System.Drawing.Size(44, 18);
            this.lblLCurrent.TabIndex = 3;
            this.lblLCurrent.Text = "CIEL*:";
            // 
            // lblACurrent
            // 
            this.lblACurrent.AutoSize = true;
            this.lblACurrent.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACurrent.ForeColor = System.Drawing.Color.Black;
            this.lblACurrent.Location = new System.Drawing.Point(6, 51);
            this.lblACurrent.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblACurrent.Name = "lblACurrent";
            this.lblACurrent.Size = new System.Drawing.Size(45, 18);
            this.lblACurrent.TabIndex = 4;
            this.lblACurrent.Text = "CIEa*:";
            // 
            // lblBCurrent
            // 
            this.lblBCurrent.AutoSize = true;
            this.lblBCurrent.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBCurrent.ForeColor = System.Drawing.Color.Black;
            this.lblBCurrent.Location = new System.Drawing.Point(6, 77);
            this.lblBCurrent.Name = "lblBCurrent";
            this.lblBCurrent.Size = new System.Drawing.Size(45, 18);
            this.lblBCurrent.TabIndex = 5;
            this.lblBCurrent.Text = "CIEb*:";
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(5, 66);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(17, 18);
            this.lblCounter.TabIndex = 10;
            this.lblCounter.Text = "#";
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.White;
            this.btnEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnEnd.FlatAppearance.BorderSize = 2;
            this.btnEnd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEnd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnd.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnd.Location = new System.Drawing.Point(8, 212);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(208, 38);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.Text = "End";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // frmGetColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.gbCurrent);
            this.Controls.Add(this.gbAverage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGetColor";
            this.Text = "Color reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGetColor_FormClosing);
            this.Load += new System.EventHandler(this.frmGetColor_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbAverage.ResumeLayout(false);
            this.gbAverage.PerformLayout();
            this.gbCurrent.ResumeLayout(false);
            this.gbCurrent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panPreview;
        private System.Windows.Forms.GroupBox gbAverage;
        private System.Windows.Forms.GroupBox gbCurrent;
        private System.Windows.Forms.Label lblLCurrent;
        private System.Windows.Forms.Label lblACurrent;
        private System.Windows.Forms.Label lblBCurrent;
        private System.Windows.Forms.Label lblCounter;
        internal System.Windows.Forms.Button btnEnd;
    }
}