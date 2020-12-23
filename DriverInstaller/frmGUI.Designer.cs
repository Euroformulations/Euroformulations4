namespace DriverInstaller
{
    partial class frmGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGUI));
            this.label1 = new System.Windows.Forms.Label();
            this.chkCube = new System.Windows.Forms.CheckBox();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.chkSpyder = new System.Windows.Forms.CheckBox();
            this.chkIone = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInstall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Choose device type";
            // 
            // chkCube
            // 
            this.chkCube.AutoSize = true;
            this.chkCube.Location = new System.Drawing.Point(40, 56);
            this.chkCube.Name = "chkCube";
            this.chkCube.Size = new System.Drawing.Size(114, 17);
            this.chkCube.TabIndex = 1;
            this.chkCube.Text = "SwatchMate Cube";
            this.chkCube.UseVisualStyleBackColor = true;
            this.chkCube.CheckedChanged += new System.EventHandler(this.chkCube_CheckedChanged);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(40, 102);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(103, 17);
            this.chkSelect.TabIndex = 2;
            this.chkSelect.Text = "Datacolor select";
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // chkSpyder
            // 
            this.chkSpyder.AutoSize = true;
            this.chkSpyder.Location = new System.Drawing.Point(40, 79);
            this.chkSpyder.Name = "chkSpyder";
            this.chkSpyder.Size = new System.Drawing.Size(106, 17);
            this.chkSpyder.TabIndex = 3;
            this.chkSpyder.Text = "Datacolor spyder";
            this.chkSpyder.UseVisualStyleBackColor = true;
            this.chkSpyder.CheckedChanged += new System.EventHandler(this.chkSpyder_CheckedChanged);
            // 
            // chkIone
            // 
            this.chkIone.AutoSize = true;
            this.chkIone.Location = new System.Drawing.Point(40, 125);
            this.chkIone.Name = "chkIone";
            this.chkIone.Size = new System.Drawing.Size(96, 17);
            this.chkIone.TabIndex = 4;
            this.chkIone.Text = "XRite iOne Pro";
            this.chkIone.UseVisualStyleBackColor = true;
            this.chkIone.CheckedChanged += new System.EventHandler(this.chkIone_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comfortaa", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "2. Press Install button";
            // 
            // btnInstall
            // 
            this.btnInstall.BackColor = System.Drawing.Color.White;
            this.btnInstall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnInstall.FlatAppearance.BorderSize = 2;
            this.btnInstall.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInstall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstall.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnInstall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstall.Location = new System.Drawing.Point(94, 211);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(120, 38);
            this.btnInstall.TabIndex = 6;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // frmGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 261);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkIone);
            this.Controls.Add(this.chkSpyder);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.chkCube);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(372, 300);
            this.Name = "frmGUI";
            this.Text = "EuroFormulations driver installer";
            this.Load += new System.EventHandler(this.frmGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCube;
        private System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.CheckBox chkSpyder;
        private System.Windows.Forms.CheckBox chkIone;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnInstall;
    }
}