namespace Euroformulations4.SubWindows.Settings
{
    partial class frmDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabase));
            this.TabImage32 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gbCurrentDB = new System.Windows.Forms.GroupBox();
            this.gbSelection = new System.Windows.Forms.GroupBox();
            this.cmbDb = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.gbNuovoDB = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.gbCurrentDB.SuspendLayout();
            this.gbSelection.SuspendLayout();
            this.gbNuovoDB.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabImage32
            // 
            this.TabImage32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabImage32.ImageStream")));
            this.TabImage32.TransparentColor = System.Drawing.Color.Transparent;
            this.TabImage32.Images.SetKeyName(0, "1412883954_setting_tools.png");
            this.TabImage32.Images.SetKeyName(1, "1422106204_Color_balance.png");
            this.TabImage32.Images.SetKeyName(2, "1422106156_barcode.png");
            this.TabImage32.Images.SetKeyName(3, "db.png");
            this.TabImage32.Images.SetKeyName(4, "printer32.png");
            this.TabImage32.Images.SetKeyName(5, "1427214019_Color_filter.png");
            this.TabImage32.Images.SetKeyName(6, "device_color_reader.png");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gbCurrentDB
            // 
            this.gbCurrentDB.Controls.Add(this.gbSelection);
            this.gbCurrentDB.Controls.Add(this.btnDelete);
            this.gbCurrentDB.Controls.Add(this.btnEdit);
            this.gbCurrentDB.Controls.Add(this.btnConfirm);
            this.gbCurrentDB.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCurrentDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbCurrentDB.Location = new System.Drawing.Point(12, 12);
            this.gbCurrentDB.Name = "gbCurrentDB";
            this.gbCurrentDB.Size = new System.Drawing.Size(517, 207);
            this.gbCurrentDB.TabIndex = 34;
            this.gbCurrentDB.TabStop = false;
            this.gbCurrentDB.Text = "Current database";
            // 
            // gbSelection
            // 
            this.gbSelection.Controls.Add(this.cmbDb);
            this.gbSelection.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelection.Location = new System.Drawing.Point(9, 27);
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.Size = new System.Drawing.Size(266, 50);
            this.gbSelection.TabIndex = 38;
            this.gbSelection.TabStop = false;
            this.gbSelection.Text = "Selection";
            // 
            // cmbDb
            // 
            this.cmbDb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDb.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDb.FormattingEnabled = true;
            this.cmbDb.Location = new System.Drawing.Point(3, 20);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Size = new System.Drawing.Size(260, 26);
            this.cmbDb.TabIndex = 28;
            this.cmbDb.SelectedIndexChanged += new System.EventHandler(this.cmbDb_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(348, 150);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(141, 38);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(348, 92);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(141, 38);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Modify";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.btnConfirm.Location = new System.Drawing.Point(348, 34);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(141, 38);
            this.btnConfirm.TabIndex = 35;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // gbNuovoDB
            // 
            this.gbNuovoDB.Controls.Add(this.btnCreate);
            this.gbNuovoDB.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNuovoDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.gbNuovoDB.Location = new System.Drawing.Point(12, 257);
            this.gbNuovoDB.Name = "gbNuovoDB";
            this.gbNuovoDB.Size = new System.Drawing.Size(517, 94);
            this.gbNuovoDB.TabIndex = 37;
            this.gbNuovoDB.TabStop = false;
            this.gbNuovoDB.Text = "New database";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnCreate.FlatAppearance.BorderSize = 2;
            this.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(348, 35);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(141, 38);
            this.btnCreate.TabIndex = 37;
            this.btnCreate.Text = "Import";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(708, 511);
            this.Controls.Add(this.gbNuovoDB);
            this.Controls.Add(this.gbCurrentDB);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(688, 519);
            this.Name = "frmDatabase";
            this.Text = "Database";
            this.Load += new System.EventHandler(this.frmDatabase_Load);
            this.gbCurrentDB.ResumeLayout(false);
            this.gbSelection.ResumeLayout(false);
            this.gbNuovoDB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList TabImage32;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.GroupBox gbCurrentDB;
        private System.Windows.Forms.ComboBox cmbDb;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnConfirm;
        internal System.Windows.Forms.GroupBox gbNuovoDB;
        internal System.Windows.Forms.Button btnCreate;
        internal System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbSelection;

    }
}