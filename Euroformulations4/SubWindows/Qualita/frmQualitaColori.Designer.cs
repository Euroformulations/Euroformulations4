namespace Euroformulations4.SubWindows.Qualita
{
    partial class frmQualitaColori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQualitaColori));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCercaColore = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCollapse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.twColori = new System.Windows.Forms.TreeView();
            this.menuTW = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.btnExpand = new System.Windows.Forms.Button();
            this.btnEsegui = new System.Windows.Forms.Button();
            this.lblTitolo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblCIEL2 = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblh = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblX = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblCIEL = new System.Windows.Forms.Label();
            this.lblCIEb = new System.Windows.Forms.Label();
            this.lblCIEa = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblR = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.panColor = new System.Windows.Forms.Panel();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.bkDialog = new System.Windows.Forms.SaveFileDialog();
            this.ofdRestore = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.menuTW.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtCercaColore);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnCollapse);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.twColori);
            this.groupBox3.Controls.Add(this.btnExpand);
            this.groupBox3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox3.Location = new System.Drawing.Point(3, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 436);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Saved Colors";
            // 
            // txtCercaColore
            // 
            this.txtCercaColore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCercaColore.Location = new System.Drawing.Point(102, 24);
            this.txtCercaColore.Name = "txtCercaColore";
            this.txtCercaColore.Size = new System.Drawing.Size(169, 24);
            this.txtCercaColore.TabIndex = 1;
            this.txtCercaColore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCercaColore_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Color Name";
            // 
            // btnCollapse
            // 
            this.btnCollapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapse.BackColor = System.Drawing.Color.White;
            this.btnCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCollapse.FlatAppearance.BorderSize = 2;
            this.btnCollapse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCollapse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapse.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCollapse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnCollapse.Image = global::Euroformulations4.Properties.Resources.collapse_gray;
            this.btnCollapse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCollapse.Location = new System.Drawing.Point(264, 396);
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Size = new System.Drawing.Size(136, 28);
            this.btnCollapse.TabIndex = 46;
            this.btnCollapse.Text = "Collapse all";
            this.btnCollapse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCollapse.UseVisualStyleBackColor = false;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Comfortaa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(295, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 24);
            this.btnSearch.TabIndex = 49;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // twColori
            // 
            this.twColori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.twColori.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.twColori.ContextMenuStrip = this.menuTW;
            this.twColori.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twColori.ImageIndex = 0;
            this.twColori.ImageList = this.imgList;
            this.twColori.Location = new System.Drawing.Point(6, 53);
            this.twColori.Name = "twColori";
            this.twColori.SelectedImageIndex = 0;
            this.twColori.Size = new System.Drawing.Size(394, 337);
            this.twColori.TabIndex = 2;
            this.twColori.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NodeSelected);
            this.twColori.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeMouseClick);
            this.twColori.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.nodeMouseDoubleClick);
            this.twColori.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.twColori_KeyPress);
            // 
            // menuTW
            // 
            this.menuTW.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.deleteFolderToolStripMenuItem,
            this.deleteColorToolStripMenuItem});
            this.menuTW.Name = "menuTW";
            this.menuTW.Size = new System.Drawing.Size(144, 70);
            this.menuTW.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.menuTW_Closed);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFolderToolStripMenuItem.Image")));
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFolderToolStripMenuItem.Image")));
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteFolderToolStripMenuItem.Text = "Delete Folder";
            this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.deleteFolderToolStripMenuItem_Click);
            // 
            // deleteColorToolStripMenuItem
            // 
            this.deleteColorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteColorToolStripMenuItem.Image")));
            this.deleteColorToolStripMenuItem.Name = "deleteColorToolStripMenuItem";
            this.deleteColorToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteColorToolStripMenuItem.Text = "Delete Color";
            this.deleteColorToolStripMenuItem.Click += new System.EventHandler(this.deleteColorToolStripMenuItem_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "1415896521_color_pencil.png");
            this.imgList.Images.SetKeyName(1, "1413916090_gnome-fs-directory.png");
            this.imgList.Images.SetKeyName(2, "1415896583_color-swatch.png");
            // 
            // btnExpand
            // 
            this.btnExpand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExpand.BackColor = System.Drawing.Color.White;
            this.btnExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpand.FlatAppearance.BorderSize = 2;
            this.btnExpand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExpand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.Font = new System.Drawing.Font("Comfortaa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnExpand.Image = global::Euroformulations4.Properties.Resources.expand_gray;
            this.btnExpand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpand.Location = new System.Drawing.Point(6, 396);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(136, 28);
            this.btnExpand.TabIndex = 45;
            this.btnExpand.Text = "Expand all";
            this.btnExpand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnEsegui
            // 
            this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsegui.BackColor = System.Drawing.Color.White;
            this.btnEsegui.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEsegui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEsegui.FlatAppearance.BorderSize = 2;
            this.btnEsegui.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEsegui.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEsegui.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEsegui.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEsegui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnEsegui.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEsegui.Location = new System.Drawing.Point(529, 465);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(192, 38);
            this.btnEsegui.TabIndex = 35;
            this.btnEsegui.Text = "Confirm";
            this.btnEsegui.UseVisualStyleBackColor = false;
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // lblTitolo
            // 
            this.lblTitolo.AutoSize = true;
            this.lblTitolo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitolo.Font = new System.Drawing.Font("Comfortaa", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitolo.Location = new System.Drawing.Point(254, 0);
            this.lblTitolo.Name = "lblTitolo";
            this.lblTitolo.Size = new System.Drawing.Size(329, 44);
            this.lblTitolo.TabIndex = 40;
            this.lblTitolo.Text = "TITLE";
            this.lblTitolo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panColor);
            this.groupBox1.Controls.Add(this.lblSelectedColor);
            this.groupBox1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox1.Location = new System.Drawing.Point(421, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 257);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Color";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.lblCIEL2);
            this.groupBox8.Controls.Add(this.lblC);
            this.groupBox8.Controls.Add(this.lblh);
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(316, 164);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(90, 87);
            this.groupBox8.TabIndex = 51;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "CIELch";
            // 
            // lblCIEL2
            // 
            this.lblCIEL2.AutoSize = true;
            this.lblCIEL2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIEL2.ForeColor = System.Drawing.Color.Black;
            this.lblCIEL2.Location = new System.Drawing.Point(6, 16);
            this.lblCIEL2.Name = "lblCIEL2";
            this.lblCIEL2.Size = new System.Drawing.Size(28, 18);
            this.lblCIEL2.TabIndex = 16;
            this.lblCIEL2.Text = "L* :";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC.ForeColor = System.Drawing.Color.Black;
            this.lblC.Location = new System.Drawing.Point(6, 41);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(29, 18);
            this.lblC.TabIndex = 19;
            this.lblC.Text = "C* :";
            // 
            // lblh
            // 
            this.lblh.AutoSize = true;
            this.lblh.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblh.ForeColor = System.Drawing.Color.Black;
            this.lblh.Location = new System.Drawing.Point(6, 68);
            this.lblh.Name = "lblh";
            this.lblh.Size = new System.Drawing.Size(23, 18);
            this.lblh.TabIndex = 20;
            this.lblh.Text = "h :";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.lblX);
            this.groupBox7.Controls.Add(this.lblZ);
            this.groupBox7.Controls.Add(this.lblY);
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(108, 164);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(86, 87);
            this.groupBox7.TabIndex = 50;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "XYZ";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX.ForeColor = System.Drawing.Color.Black;
            this.lblX.Location = new System.Drawing.Point(6, 16);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(29, 18);
            this.lblX.TabIndex = 16;
            this.lblX.Text = "X* :";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZ.ForeColor = System.Drawing.Color.Black;
            this.lblZ.Location = new System.Drawing.Point(6, 68);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(29, 18);
            this.lblZ.TabIndex = 18;
            this.lblZ.Text = "Z* :";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.ForeColor = System.Drawing.Color.Black;
            this.lblY.Location = new System.Drawing.Point(6, 41);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(28, 18);
            this.lblY.TabIndex = 17;
            this.lblY.Text = "Y* :";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.lblCIEL);
            this.groupBox5.Controls.Add(this.lblCIEb);
            this.groupBox5.Controls.Add(this.lblCIEa);
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(214, 164);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(86, 87);
            this.groupBox5.TabIndex = 49;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CIELab";
            // 
            // lblCIEL
            // 
            this.lblCIEL.AutoSize = true;
            this.lblCIEL.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIEL.ForeColor = System.Drawing.Color.Black;
            this.lblCIEL.Location = new System.Drawing.Point(6, 16);
            this.lblCIEL.Name = "lblCIEL";
            this.lblCIEL.Size = new System.Drawing.Size(28, 18);
            this.lblCIEL.TabIndex = 13;
            this.lblCIEL.Text = "L* :";
            // 
            // lblCIEb
            // 
            this.lblCIEb.AutoSize = true;
            this.lblCIEb.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIEb.ForeColor = System.Drawing.Color.Black;
            this.lblCIEb.Location = new System.Drawing.Point(6, 68);
            this.lblCIEb.Name = "lblCIEb";
            this.lblCIEb.Size = new System.Drawing.Size(28, 18);
            this.lblCIEb.TabIndex = 15;
            this.lblCIEb.Text = "b* :";
            // 
            // lblCIEa
            // 
            this.lblCIEa.AutoSize = true;
            this.lblCIEa.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCIEa.ForeColor = System.Drawing.Color.Black;
            this.lblCIEa.Location = new System.Drawing.Point(6, 41);
            this.lblCIEa.Name = "lblCIEa";
            this.lblCIEa.Size = new System.Drawing.Size(28, 18);
            this.lblCIEa.TabIndex = 14;
            this.lblCIEa.Text = "a* :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lblR);
            this.groupBox2.Controls.Add(this.lblB);
            this.groupBox2.Controls.Add(this.lblG);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(9, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(86, 87);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RGB";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblR.ForeColor = System.Drawing.Color.Black;
            this.lblR.Location = new System.Drawing.Point(6, 16);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(23, 18);
            this.lblR.TabIndex = 2;
            this.lblR.Text = "R :";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblB.ForeColor = System.Drawing.Color.Black;
            this.lblB.Location = new System.Drawing.Point(7, 68);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(22, 18);
            this.lblB.TabIndex = 6;
            this.lblB.Text = "B :";
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblG.ForeColor = System.Drawing.Color.Black;
            this.lblG.Location = new System.Drawing.Point(6, 41);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(25, 18);
            this.lblG.TabIndex = 3;
            this.lblG.Text = "G :";
            // 
            // panColor
            // 
            this.panColor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panColor.Location = new System.Drawing.Point(6, 82);
            this.panColor.Name = "panColor";
            this.panColor.Size = new System.Drawing.Size(409, 76);
            this.panColor.TabIndex = 47;
            // 
            // lblSelectedColor
            // 
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedColor.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedColor.Location = new System.Drawing.Point(6, 23);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(52, 21);
            this.lblSelectedColor.TabIndex = 10;
            this.lblSelectedColor.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitolo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(839, 44);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.btnRestore);
            this.groupBox4.Controls.Add(this.btnBackup);
            this.groupBox4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.groupBox4.Location = new System.Drawing.Point(421, 84);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 74);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Backup / Restore";
            
            // 
            // frmQualitaColori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEsegui);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(852, 538);
            this.Name = "frmQualitaColori";
            this.Text = "Quality Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQualitaColori_FormClosing);
            this.Load += new System.EventHandler(this.frmQualitaColori_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuTW.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Button btnEsegui;
        private System.Windows.Forms.Label lblTitolo;
        private System.Windows.Forms.TreeView twColori;
        private System.Windows.Forms.ImageList imgList;
        internal System.Windows.Forms.Button btnExpand;
        internal System.Windows.Forms.Button btnCollapse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSelectedColor;
        private System.Windows.Forms.ContextMenuStrip menuTW;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCercaColore;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem deleteColorToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panColor;
        private System.Windows.Forms.GroupBox groupBox8;
        internal System.Windows.Forms.Label lblC;
        internal System.Windows.Forms.Label lblh;
        private System.Windows.Forms.GroupBox groupBox7;
        internal System.Windows.Forms.Label lblX;
        internal System.Windows.Forms.Label lblZ;
        internal System.Windows.Forms.Label lblY;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Label lblCIEL;
        internal System.Windows.Forms.Label lblCIEb;
        internal System.Windows.Forms.Label lblCIEa;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label lblR;
        internal System.Windows.Forms.Label lblB;
        internal System.Windows.Forms.Label lblG;
        internal System.Windows.Forms.Label lblCIEL2;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Button btnRestore;
        internal System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.SaveFileDialog bkDialog;
        private System.Windows.Forms.OpenFileDialog ofdRestore;

    }
}