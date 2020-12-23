namespace Euroformulations4.SubWindows.FormulaSelection
{
    partial class frmFormulaPrev
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormulaPrev));
            this.dgTinte = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prewcolor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nometinta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFormula = new System.Windows.Forms.DataGridView();
            this.preview = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTinte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTinte
            // 
            this.dgTinte.AllowUserToAddRows = false;
            this.dgTinte.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTinte.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTinte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTinte.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTinte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgTinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTinte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.prewcolor,
            this.nometinta});
            this.dgTinte.EnableHeadersVisualStyles = false;
            this.dgTinte.Location = new System.Drawing.Point(17, 64);
            this.dgTinte.Margin = new System.Windows.Forms.Padding(8);
            this.dgTinte.MultiSelect = false;
            this.dgTinte.Name = "dgTinte";
            this.dgTinte.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTinte.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTinte.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTinte.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgTinte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTinte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTinte.Size = new System.Drawing.Size(200, 328);
            this.dgTinte.TabIndex = 2;
            this.dgTinte.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTinte_CellDoubleClick);
            this.dgTinte.SelectionChanged += new System.EventHandler(this.dgTinte_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // prewcolor
            // 
            this.prewcolor.FillWeight = 100.0508F;
            this.prewcolor.HeaderText = "Preview";
            this.prewcolor.Name = "prewcolor";
            this.prewcolor.ReadOnly = true;
            // 
            // nometinta
            // 
            this.nometinta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nometinta.FillWeight = 105.5811F;
            this.nometinta.HeaderText = "Date";
            this.nometinta.Name = "nometinta";
            this.nometinta.ReadOnly = true;
            // 
            // dgFormula
            // 
            this.dgFormula.AllowUserToAddRows = false;
            this.dgFormula.AllowUserToDeleteRows = false;
            this.dgFormula.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgFormula.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgFormula.BackgroundColor = System.Drawing.Color.White;
            this.dgFormula.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgFormula.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormula.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFormula.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.preview,
            this.colorant,
            this.gr,
            this.ml});
            this.dgFormula.Enabled = false;
            this.dgFormula.EnableHeadersVisualStyles = false;
            this.dgFormula.GridColor = System.Drawing.Color.DimGray;
            this.dgFormula.Location = new System.Drawing.Point(232, 114);
            this.dgFormula.Margin = new System.Windows.Forms.Padding(8);
            this.dgFormula.MultiSelect = false;
            this.dgFormula.Name = "dgFormula";
            this.dgFormula.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFormula.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgFormula.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgFormula.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgFormula.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgFormula.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFormula.Size = new System.Drawing.Size(374, 193);
            this.dgFormula.TabIndex = 3;
            // 
            // preview
            // 
            this.preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.preview.HeaderText = "Preview";
            this.preview.Name = "preview";
            this.preview.ReadOnly = true;
            this.preview.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.preview.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.preview.Width = 60;
            // 
            // colorant
            // 
            this.colorant.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colorant.HeaderText = "Colorant";
            this.colorant.Name = "colorant";
            this.colorant.ReadOnly = true;
            this.colorant.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colorant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gr
            // 
            this.gr.HeaderText = "Gr.";
            this.gr.Name = "gr";
            this.gr.ReadOnly = true;
            this.gr.Width = 60;
            // 
            // ml
            // 
            this.ml.HeaderText = "Ml.";
            this.ml.Name = "ml";
            this.ml.ReadOnly = true;
            this.ml.Width = 60;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.White;
            this.btnConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.FlatAppearance.BorderSize = 2;
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Comfortaa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(149)))), ((int)(((byte)(66)))));
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(343, 354);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(151, 38);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Comfortaa", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(17, 25);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(165, 21);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Select formula date";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(233, 64);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // btxt
            // 
            this.btxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btxt.AutoEllipsis = true;
            this.btxt.AutoSize = true;
            this.btxt.Font = new System.Drawing.Font("Comfortaa", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btxt.Location = new System.Drawing.Point(271, 71);
            this.btxt.Name = "btxt";
            this.btxt.Size = new System.Drawing.Size(87, 20);
            this.btxt.TabIndex = 41;
            this.btxt.Text = "Base name";
            // 
            // frmFormulaPrev
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 403);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btxt);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.dgFormula);
            this.Controls.Add(this.dgTinte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFormulaPrev";
            this.Text = "Previous formula";
            this.Load += new System.EventHandler(this.frmFormulaPrev_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTinte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFormula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTinte;
        private System.Windows.Forms.DataGridView dgFormula;
        private System.Windows.Forms.DataGridViewTextBoxColumn preview;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorant;
        private System.Windows.Forms.DataGridViewTextBoxColumn gr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ml;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prewcolor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nometinta;
        internal System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.Label btxt;
    }
}