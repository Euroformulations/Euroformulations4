using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Euroformulations4.Library;
using Euroformulations4.Library.Formulation;
using Euroformulations4.SubWindows.FormulaSelection;

namespace Euroformulations4.SubWindows.ErogazioneLibera
{

    public partial class frmFreeDispenser : Form
    {
        private Library.Data.Database.DBConnector db;
        private static Language lang = Language.GetInstance();
        private Colore coloreSTD = null, coloreSample = null;
        private int IDSQC_standard = -1, IDSQC_sample = -1;
        private Euroformulations4.Menu.MenuManager menu = null;
        private Bitmap _grafico = null;
        private Bitmap _graficoL = null;
        private Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
        private Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
        public string[,] coloranti;
        int _countCol;

        public frmFreeDispenser()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();           
            btnDispense.Enabled = true;
            SetButtonColor(btnDispense);
            string[] installs = new string[] {"ml", "gr" };
            comboBox2.Items.AddRange(installs);
            comboBox2.Text = "Seleziona unità";
        }

        // Handles the ComboBox1 DropDown event. If the user expands the  
        // drop-down box, a message box will appear, recommending the
        // typical installation.
        private void ComboBox1_DropDown(object sender, System.EventArgs e)
        {
            MessageBox.Show("Seleziona l'unità di erogazione",
            "Dispense information", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #region print formula
       

        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
        private MemoryStream Image2Stream(Image image, System.Drawing.Imaging.ImageFormat formaw)
        {
            MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, formaw);
            stream.Position = 0;
            return stream;
        }
        
        #endregion

        #region STRUCTURES
        class ItemListino
        {
            public int id;
            public string nome;
            public string valuta;
            public ItemListino(int id, string nome, string valuta)
            {
                this.id = id;
                this.nome = nome;
                this.valuta = valuta;
            }
            public override string ToString()
            {
                return nome;
            }
        }

        public class PackagePreProcessor
        {
            public double qtaBase;
            public string subLabel;
            public Library.Formulation.eUnita unitaBase;
            public bool bError = false;

            public PackagePreProcessor(string sData)
            {
                sData = sData.ToUpper();
                if (sData.EndsWith("LT"))
                {
                    sData = sData.Substring(0, sData.Length - 2);
                    unitaBase = Library.Formulation.eUnita.LT;
                    subLabel = "LT";
                }
                else if (sData.EndsWith("L"))
                {
                    sData = sData.Substring(0, sData.Length - 1);
                    unitaBase = Library.Formulation.eUnita.LT;
                    subLabel = "LT";
                }
                else if (sData.EndsWith("KG"))
                {
                    sData = sData.Substring(0, sData.Length - 2);
                    unitaBase = Library.Formulation.eUnita.KG;
                    subLabel = "KG";
                }
                else if (sData.EndsWith("K"))
                {
                    sData = sData.Substring(0, sData.Length - 1);
                    unitaBase = Library.Formulation.eUnita.KG;
                    subLabel = "KG";
                }
                else
                {
                    if (sData != "[ . . . ]")
                    {
                        bError = true;
                    }
                }

                if (!bError)
                {
                    qtaBase = Convert.ToDouble(sData.Trim().Replace(',', '.'), CultureInfo.InvariantCulture);
                }
            }
        }
        #endregion

        public double GetCost_Colorant(int indexColorant, int IDListino)
        {
            eUnita unitDisp = eUnita.ml;
            string unit = comboBox2.SelectedItem.ToString();
            if (unit.Equals("ml")) unitDisp = eUnita.ml;
            if (unit.Equals("gr")) unitDisp = eUnita.gr;
            Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector();
            Library.Formulation.CostCalculator calculator = new CostCalculator(db, IDListino);
            double costo = calculator.GetCostoColorante(coloranti[indexColorant,2],Convert.ToDouble(coloranti[indexColorant,7]), Convert.ToDouble(coloranti[indexColorant,6]), unitDisp );
            db.CloseConnection();
            return costo;
        }

        #region listini
        private void cmbListino_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbSettings.SetValue("ListinoDefault", cmbListino.Text);
        }

        private void cmbListino_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                object oItem = cmbListino.SelectedItem;
                if (oItem == null) { return; }
                KeyValuePair<int, ItemListino> kvp = (KeyValuePair<int, ItemListino>)cmbListino.SelectedItem;
                int idlistino = kvp.Key;

        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void frmFreeDispenser_Load(object sender, EventArgs e)
        {
            
            #region POPOLAZIONE DEI DRIVER MACCHINA INSERITI
            DataTable dtmachine = db.SQLQuerySelect("SELECT * FROM machine ORDER BY id_machine");
            foreach (DataRow dr in dtmachine.Rows)
            {
                cmbDispenser.Items.Add(dr["name"].ToString());
            }

            if (dbSettings.HasKey("drivermachine"))
            {
                cmbDispenser.Text = dbSettings.GetValue("drivermachine");
            }
            #endregion

            #region POPOLAZIONE LISTINI INSERITI
            DataTable dtlistini = db.SQLQuerySelect("SELECT * FROM listino LIMIT 3");
            foreach (DataRow dr in dtlistini.Rows)
            {
                cmbListino.Items.Add(dr["nome_listino"].ToString());
            }

            //if (dbSettings.HasKey("ListinoDefault"))
            //{
            //    cmbListino.Text = dbSettings.GetValue("ListinoDefault");
            //}
            #endregion

            //private int GetListinoDefault()
            //{
            //    try
            //    {
            //        string sql = "";
            //        if (GVar.attivazioni.Act_ListiniUnlimited)
            //        {
            //            string sID = dbSettings.GetValue("ListinoDefault");
            //            return Convert.ToInt32(sID);
            //        }
            //        else
            //        {
            //            sql = "SELECT * FROM listino LIMIT 1";
            //        }

            //        DataTable dt = db.SQLQuerySelect(sql);
            //        if (dt.Rows.Count == 0) { return -1; }

            //        return Convert.ToInt32(dt.Rows[0]["id_list"].ToString());
            //    }
            //    catch (Exception)
            //    {
            //        return -1;
            //    }
            //}


            //dataGridView1.Columns[0].HeaderText = "Color";
            //dataGridView1.Columns[1].HeaderText = "id";
            //dataGridView1.Columns[2].HeaderText = "fullname";
            //dataGridView1.Columns[3].HeaderText = "R";
            //dataGridView1.Columns[4].HeaderText = "G";
            //dataGridView1.Columns[5].HeaderText = "B";
            //dataGridView1.Columns;
            //dataGridView1.Columns.Insert(1, dataGridView1.Columns[1]);
            //dataGridView1.Columns.Insert(2, dataGridView1.Columns[2]);
            //dataGridView1.Columns.Insert(3, dataGridView1.Columns[3]);
            //dataGridView1.Columns.Insert(4, dataGridView1.Columns[4]);
            //dataGridView1.Columns[1].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            string sql = "Select id,fullname,code,density,pr,pg,pb From pigmenti ORDER BY id";
            DataTable dt = db.SQLQuerySelect(sql);

            DataGridViewTextBoxColumn colTmp = new DataGridViewTextBoxColumn();
            colTmp.ReadOnly = true;
            colTmp.Tag = "tag";
            colTmp.HeaderText = "Color";
            colTmp.Name = "colCodice";
            colTmp.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(colTmp);

            DataGridViewTextBoxColumn colTmp1 = new DataGridViewTextBoxColumn();
            colTmp1.ReadOnly = true;
            colTmp1.Tag = "tag";
            colTmp1.HeaderText = "ID";
            colTmp1.Name = "colCodice";
            colTmp1.Width = 24;
            colTmp1.Visible = false;
            colTmp1.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns.Add(colTmp1);

            DataGridViewTextBoxColumn colTmp2 = new DataGridViewTextBoxColumn();
            colTmp2.ReadOnly = true;
            colTmp2.Tag = "tag";
            colTmp2.Width = 200;
            colTmp2.HeaderText = "Name";
            colTmp2.Name = "colCodice";
            colTmp2.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns.Add(colTmp2);

            DataGridViewTextBoxColumn colTmp3 = new DataGridViewTextBoxColumn();
            colTmp3.ReadOnly = true;
            colTmp3.Tag = "tag";
            colTmp3.HeaderText = "Densità";
            colTmp3.Name = "colCodice";
            colTmp3.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(colTmp3);

            DataGridViewTextBoxColumn colTmp4 = new DataGridViewTextBoxColumn();
            colTmp4.ReadOnly = true;
            colTmp4.Tag = "tag";
            colTmp4.HeaderText = "R";
            colTmp4.Name = "colCodice";
            colTmp4.Visible = false;
            colTmp4.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(colTmp4);

            DataGridViewTextBoxColumn colTmp5 = new DataGridViewTextBoxColumn();
            colTmp5.ReadOnly = true;
            colTmp5.Tag = "tag";
            colTmp5.HeaderText = "G";
            colTmp5.Name = "colCodice";
            colTmp5.Visible = false;
            colTmp5.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(colTmp5);

            DataGridViewTextBoxColumn colTmp6 = new DataGridViewTextBoxColumn();
            colTmp6.ReadOnly = true;
            colTmp6.Tag = "tag";
            colTmp6.HeaderText = "B";
            colTmp6.Visible = false;
            colTmp6.Name = "colCodice";
            colTmp6.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns.Add(colTmp6);


            DataGridViewTextBoxColumn colTmp7 = new DataGridViewTextBoxColumn();
            colTmp7.Tag = "tag";
            colTmp7.HeaderText = "Qta";
            colTmp7.Name = "colCodice";
            colTmp2.Width =300;
            colTmp7.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            colTmp7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTmp7.ToolTipText.PadRight(5);
            dataGridView1.Columns.Add(colTmp7);


            dataGridView1.Columns["colCodice"].DefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleLeft;


            //DataGridViewTextBoxColumn colTmp6 = new DataGridViewTextBoxColumn();
            //System.Windows.Forms.TextBox txtBox = new System.Windows.Forms.TextBox();
            //colTmp5.Tag = "tag";
            //colTmp5.HeaderText = "B";
            //colTmp5.Name = "colCodice";
            //colTmp5.DataPropertyName = "Codice"; // Impostare uguale alla proprietà dell'oggetto
            //colTmp5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //colTmp5.Width = 100;
            //dataGridView1.Columns.Add(txtBox);

            //TextBox TextBox1 = new TextBox();
            //GridView1.Rows[0].Cells[0].Controls.Add(TextBox1);
            //TextBox txtBox = new TextBox();

            UpdateTable(dt);
            //listView1.View = View.Details;
            //listView1.GridLines = true;
            //listView1.FullRowSelect = true;

            ////Add column header
            //listView1.Columns.Add("Color", 100);
            //listView1.Columns.Add("Id", 70);
            //listView1.Columns.Add("Name", 70);

            ////Add items in the listview
            //string[] arr = new string[6];


            //////Add first item
            ////arr[0] = "product_1";
            ////arr[1] = "100";
            ////arr[2] = "10";
            ////itm = new ListViewItem(arr);
            ////listView1.Items.Add(itm);

            //////Add second item
            ////arr[0] = "product_2";
            ////arr[1] = "200";
            ////arr[2] = "20";
            ////itm = new ListViewItem(arr);
            ////listView1.Items.Add(itm);

            //string sql = "Select id,fullname,code,pr,pg,pb From pigmenti ORDER BY id";
            //DataTable dt = db.SQLQuerySelect(sql);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem();
            //    arr[0] = dr["id"].ToString();
            //    arr[1] = dr["fullname"].ToString();
            //    arr[2] = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["pr"].ToString()), Convert.ToInt32(dr["pg"].ToString()), Convert.ToInt32(dr["pb"].ToString()));
            //    item.Text = id + " - " + name;
            //    item.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["pr"].ToString()), Convert.ToInt32(dr["pg"].ToString()), Convert.ToInt32(dr["pb"].ToString()));
            //    listBox1.Items.Insert(0, "First");
            //    listView1.Items.Add(item);
            //}

        }

        #region GetData
        public int getNumColorant()
        {
            int num = 0;
            for (int i = 0; i <= _countCol; i++)
            {
                string x = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                if (!x.Equals("0"))
                {
                    num++;
                }

            }
            return num;
        }

        public string[,] GetData(string[,] coloranti)
        {
            int num = getNumColorant();
            string[,] app = new string[num,8];
            
            int y = 0;
            int z = 0;
            for (int i = 0; i <= _countCol; i++)
            {
                string x = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                if (!x.Equals("0"))
                {
                    app[y,0] = z.ToString();
                    for (int j = 1; j < 8; j++)
                    {               
                        if(j == 7)
                        {
                            app[y, j] = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(".", ",");
                        }
                        else
                        {
                            app[y, j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                                           
                    }
                    z++;
                    y++;
                }
               
            }

            //eliminare le righe vuote e ritornare la nuova matrice completa
            //for (int i = 0; i < _countCol; i++)
            //{
            //    for (int j = 1; j < 8; j++)
            //    {
            //        if (app[i, j] ==)
            //    }
            //}
            return app;
        }
        #endregion

        private void ComboBox1_DropDown(string message)
        {
            MessageBox.Show(message,
            "Warning!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #region dispense
        private void Dispenser_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbSettings.SetValue("drivermachine", cmbDispenser.Text);
        }

        private void SendToDispenser_Click(object sender, EventArgs e)
        {
            //prendere i dati dalla datagridView1 
            //dove è != da 0
            //popolare coloranti inserendo ciò che serve nella funzione del dispenser
            
            string[,] _colSel = GetData(coloranti);
            if (cmbDispenser.Text.Trim() == "")
            {
                ComboBox1_DropDown("Seleziona il dispensatore");
                return;
            }
            if (comboBox2.Text.Trim() == "")
            {
                ComboBox1_DropDown("Seleziona l'unità di misura");
                return;
            }
            if (getNumColorant() == 0)
            {
                ComboBox1_DropDown("Nessun colorante selezionato");
                return;
            }
            try
            {
                if (cmbDispenser.Text.Trim() == "") {
                    
                    return; }
                btnDispense.Enabled = false;

                //NUMERO EROGAZIONI
                int nErogazioni = 1;
                if (sharedSettings.GetValue("MultiErogazione") != "0")
                {
                    frmNumErogazioni numErogazioni = new frmNumErogazioni();
                    numErogazioni.ShowDialog();
                    nErogazioni = numErogazioni.Erogazioni;
                }

                //GET MACHINE INFO
                DataTable dt = db.SQLQuerySelect("SELECT * FROM machine WHERE name = '" + cmbDispenser.Text.Trim() + "'");
                DataRow dr = dt.Rows[0];
                Library.Data.Machine.eMacchina machine_type = (Library.Data.Machine.eMacchina)dr["machine_type"];
                string pathFile = dr["pathfile"].ToString();
                string exeFile = dr["exefile"].ToString();
                string onceType = dr["oncetype"].ToString().Replace(".", ",");

                eUnita unitDisp = eUnita.ml;
                string unit = comboBox2.SelectedItem.ToString();
                if (unit.Equals("ml")) unitDisp = eUnita.ml;
                if (unit.Equals("gr")) unitDisp = eUnita.gr;
                //Formula formula = new Formula("Erogazione", "", "", "", 1.0, comboboxSceltaMlGRL, false, 1.0, comboboxSceltaMlGRL, "", "", 0, "", "", dR, dG, dB, dCIEL, dCIEA, dCIEB, idformula, tablename, bFormulaSavedInOunce);
                //DISPENSE
                Library.Formulation.StaticDispenser.SendColorant2AutomaticDispenser(_colSel, machine_type, pathFile, exeFile, unitDisp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnDispense.Enabled = true;
            }
        }
        #endregion

        /// <summary>
        /// Pulisce il campo con cui inserisci la quantità di erogazione
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clear_Click(object sender, EventArgs e)
        {
            int iRow = _countCol;
            while (iRow >= 0)
            {
                dataGridView1.Rows[iRow].Cells[7].Value = '0';
                iRow--;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab && dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                e.Handled = true;
                DataGridViewCell cell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = cell;
                dataGridView1.BeginEdit(true);
            }
        }

        /// <summary>
        /// Questa è la funzione che inserisce nella tabella
        /// </summary>
        /// <param name="dt">questa è una datatable</param>
        private void UpdateTable(DataTable dt)
        {
            dataGridView1.Rows.Clear();
            int iRow = 0;

            //foreach (DataRow dr in dt.Rows)
            //{
            //    ListViewItem item = new ListViewItem();
            //    arr[0] = dr["id"].ToString();
            //    arr[1] = dr["fullname"].ToString();
            //    arr[2] = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["pr"].ToString()), Convert.ToInt32(dr["pg"].ToString()), Convert.ToInt32(dr["pb"].ToString()));
            //    item.Text = id + " - " + name;
            //    item.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["pr"].ToString()), Convert.ToInt32(dr["pg"].ToString()), Convert.ToInt32(dr["pb"].ToString()));
            //    listBox1.Items.Insert(0, "First");
            //    listView1.Items.Add(item);

            foreach (DataRow dr in dt.Rows)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[iRow].Cells[0].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(dr["pr"].ToString()), Convert.ToInt32(dr["pg"].ToString()), Convert.ToInt32(dr["pb"].ToString()));
                dataGridView1.Rows[iRow].Cells[1].Value = dr["id"].ToString();
                dataGridView1.Rows[iRow].Cells[2].Value = dr["fullname"].ToString();
                dataGridView1.Rows[iRow].Cells[3].Value = dr["density"].ToString();
                dataGridView1.Rows[iRow].Cells[4].Value = dr["pr"].ToString();
                dataGridView1.Rows[iRow].Cells[5].Value = dr["pg"].ToString();
                dataGridView1.Rows[iRow].Cells[6].Value = dr["pb"].ToString();
                DataGridViewCell cell = dataGridView1.Rows[iRow].Cells[7];
                dataGridView1.Rows[iRow].Cells[7].Value = '0';
                iRow++;
            }
            _countCol = iRow - 1;
            dataGridView1.ClearSelection();
        }
        
        /// <summary>
        /// Setta il colore dei bottoni
        /// </summary>
        /// <param name="btn">bottone</param>
        private void SetButtonColor(Button btn)
        {
            if (!btn.Enabled)
            {
                btn.BackColor = System.Drawing.Color.Gainsboro;
                btn.ForeColor = System.Drawing.Color.Black;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btn.BackColor = System.Drawing.Color.White;
                btn.ForeColor = System.Drawing.Color.FromArgb(0, 149, 66);
                btn.FlatAppearance.BorderSize = 2;
            }
        }
    }
}
