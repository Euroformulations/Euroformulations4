namespace Euroformulations4.SubWindows.Settings
{
    partial class frmDispositivi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDispositivi));
            this.gbDeviceDetail = new System.Windows.Forms.GroupBox();
            this.panDeviceDetail = new System.Windows.Forms.Panel();
            this.btnSalva = new System.Windows.Forms.Button();
            this.gbDefaultDevice = new System.Windows.Forms.GroupBox();
            this.cmbDispositivi = new System.Windows.Forms.ComboBox();
            this.gbTipoLettura = new System.Windows.Forms.GroupBox();
            this.cmbLetturaTipo = new System.Windows.Forms.ComboBox();
            this.gbDeviceDetail.SuspendLayout();
            this.gbDefaultDevice.SuspendLayout();
            this.gbTipoLettura.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDeviceDetail
            // 
            this.gbDeviceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDeviceDetail.Controls.Add(this.panDeviceDetail);
            this.gbDeviceDetail.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDeviceDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbDeviceDetail.Location = new System.Drawing.Point(12, 112);
            this.gbDeviceDetail.Name = "gbDeviceDetail";
            this.gbDeviceDetail.Size = new System.Drawing.Size(684, 311);
            this.gbDeviceDetail.TabIndex = 24;
            this.gbDeviceDetail.TabStop = false;
            this.gbDeviceDetail.Text = "Device details";
            // 
            // panDeviceDetail
            // 
            this.panDeviceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDeviceDetail.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panDeviceDetail.Location = new System.Drawing.Point(7, 22);
            this.panDeviceDetail.Name = "panDeviceDetail";
            this.panDeviceDetail.Size = new System.Drawing.Size(671, 283);
            this.panDeviceDetail.TabIndex = 0;
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalva.BackColor = System.Drawing.Color.White;
            this.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSalva.FlatAppearance.BorderSize = 2;
            this.btnSalva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalva.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSalva.Image = ((System.Drawing.Image)(resources.GetObject("btnSalva.Image")));
            this.btnSalva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalva.Location = new System.Drawing.Point(12, 461);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(183, 38);
            this.btnSalva.TabIndex = 23;
            this.btnSalva.Text = "Save";
            this.btnSalva.UseVisualStyleBackColor = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // gbDefaultDevice
            // 
            this.gbDefaultDevice.Controls.Add(this.cmbDispositivi);
            this.gbDefaultDevice.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDefaultDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbDefaultDevice.Location = new System.Drawing.Point(12, 12);
            this.gbDefaultDevice.Name = "gbDefaultDevice";
            this.gbDefaultDevice.Size = new System.Drawing.Size(316, 66);
            this.gbDefaultDevice.TabIndex = 22;
            this.gbDefaultDevice.TabStop = false;
            this.gbDefaultDevice.Text = "Default device";
            // 
            // cmbDispositivi
            // 
            this.cmbDispositivi.BackColor = System.Drawing.Color.White;
            this.cmbDispositivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDispositivi.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDispositivi.FormattingEnabled = true;
            this.cmbDispositivi.Location = new System.Drawing.Point(6, 31);
            this.cmbDispositivi.Name = "cmbDispositivi";
            this.cmbDispositivi.Size = new System.Drawing.Size(304, 26);
            this.cmbDispositivi.TabIndex = 24;
            // 
            // gbTipoLettura
            // 
            this.gbTipoLettura.Controls.Add(this.cmbLetturaTipo);
            this.gbTipoLettura.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoLettura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbTipoLettura.Location = new System.Drawing.Point(334, 12);
            this.gbTipoLettura.Name = "gbTipoLettura";
            this.gbTipoLettura.Size = new System.Drawing.Size(246, 66);
            this.gbTipoLettura.TabIndex = 25;
            this.gbTipoLettura.TabStop = false;
            this.gbTipoLettura.Text = "Read Type";
            // 
            // cmbLetturaTipo
            // 
            this.cmbLetturaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLetturaTipo.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLetturaTipo.FormattingEnabled = true;
            this.cmbLetturaTipo.Location = new System.Drawing.Point(6, 31);
            this.cmbLetturaTipo.Name = "cmbLetturaTipo";
            this.cmbLetturaTipo.Size = new System.Drawing.Size(234, 26);
            this.cmbLetturaTipo.TabIndex = 24;
            // 
            // frmDispositivi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 511);
            this.Controls.Add(this.gbTipoLettura);
            this.Controls.Add(this.gbDeviceDetail);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.gbDefaultDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDispositivi";
            this.Text = "Devices";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDispositivi_FormClosing);
            this.Load += new System.EventHandler(this.frmDispositivi_Load);
            this.gbDeviceDetail.ResumeLayout(false);
            this.gbDefaultDevice.ResumeLayout(false);
            this.gbTipoLettura.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDeviceDetail;
        private System.Windows.Forms.Panel panDeviceDetail;
        internal System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.GroupBox gbDefaultDevice;
        internal System.Windows.Forms.ComboBox cmbDispositivi;
        private System.Windows.Forms.GroupBox gbTipoLettura;
        internal System.Windows.Forms.ComboBox cmbLetturaTipo;
    }
}