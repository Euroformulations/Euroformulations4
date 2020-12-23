using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Euroformulations4.Library;
using System.Management;
using System.IO.Ports;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Net;
using System.Net.Security;
using MySql.Data.MySqlClient;
using System.Net.Cache;
using System.Text.RegularExpressions;

namespace Euroformulations4.SubWindows.Amministrazione
{
    public partial class frmECAdmin : Form
    {
        private Colore coloreSTD = null;
        private string sNomeTintaPrev = "";
        private Library.Data.Database.DBConnector db;

        public frmECAdmin()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();
        }

        private void SetData_ColoreSTD(string Tinta = "NULL")
        {
            double[] rgb = Library.Colore.XYZ_RGB(coloreSTD.X, coloreSTD.Y, coloreSTD.Z);
            string CieL;
            string Ciea;
            string Cieb;
            int R;
            int G;
            int B;
            R = (int)Math.Round(rgb[0], 0);
            G = (int)Math.Round(rgb[1], 0);
            B = (int)Math.Round(rgb[2], 0);
            CieL = Math.Round(coloreSTD.CIEL, 2).ToString();
            Ciea = Math.Round(coloreSTD.CIEa, 2).ToString();
            Cieb = Math.Round(coloreSTD.CIEb, 2).ToString();
            using (StreamWriter tw = new FileInfo(Application.StartupPath + "\\Letture.txt").AppendText())
            {
                tw.WriteLine(Tinta + ";" + CieL + ";" + Ciea + ";" + Cieb);
                tw.Close();

            }
            String textLAB = Tinta + ";" + CieL + ";" + Ciea + ";" + Cieb;
            textBoxLista.Text += textLAB + Environment.NewLine;

            txtColorStandard.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Language lang = Library.Language.GetInstance();
                lang.GenerateAllLanguages();
                MessageBox.Show("file di lingue aggiornato");  //N.B.: non codificare questo testo, riservato ai programamtori (Max & Simone!)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

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

        private void frmECAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                #region FUNCTION_COSTI_FORMULA
                Dictionary<int, string> dicListini = new Dictionary<int, string>();
                dicListini.Add(-1, "");
                DataTable dt = db.SQLQuerySelect("SELECT * FROM listino ORDER BY nome_listino");
                foreach (DataRow dr in dt.Rows)
                {
                    int idlistino = Convert.ToInt32(dr["id_list"].ToString());
                    string nomelistino = dr["nome_listino"].ToString();
                    //string valuta = dr["valuta"].ToString();
                    dicListini.Add(idlistino, nomelistino);
                }
                cmbCostoFormule_Listino.DataSource = new BindingSource(dicListini, null);
                cmbCostoFormule_Listino.DisplayMember = "Value";
                cmbCostoFormule_Listino.ValueMember = "Key";

                //cmbCostoFormule_Prodotto
                dt = db.SQLQuerySelect("select distinct system from formule");
                foreach (DataRow dr in dt.Rows)
                {
                    cmbCostoFormule_Prodotto.Items.Add(dr["system"].ToString());
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmECAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void bkDB_Click(object sender, EventArgs e)
        {
            SaveFile.FileName = "database_ef4.backup";
            SaveFile.Filter = "Postgress backup file (*.backup)|*.backup";
            SaveFile.OverwritePrompt = true;
            if (SaveFile.ShowDialog() != DialogResult.OK) return;

            try
            {
                ProcessStartInfo Postgress = new ProcessStartInfo();
                Postgress.FileName = Application.StartupPath + @"\postgress\bin\pg_dump.exe";
                Postgress.Arguments = "--host localhost --port 49998 --username \"postgres\" --no-password  --format custom --blobs --verbose --file \"" + SaveFile.FileName + "\" \"ef_base\"";
                Process processBK = Process.Start(Postgress);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel processo di Backup: " + ex.Message);
            }
        }

        private void RestoreDB_Click(object sender, EventArgs e)
        {
            Library.Data.Database.DBConnector db = null;

            try
            {
                db = new Library.Data.Database.DBConnector(GVar.ServerIP, "postgres");

                DataTable dt = db.SQLQuerySelect("SELECT * FROM pg_stat_activity WHERE datname = 'ef_base'");
                foreach (DataRow dr in dt.Rows)
                {
                    //usa dr al posto di datareader
                }

                dt = db.SQLQuerySelect("SELECT pg_terminate_backend (pg_stat_activity.pid) FROM pg_stat_activity WHERE pg_stat_activity.datname = 'ef_base'");
                foreach (DataRow dr in dt.Rows)
                {
                    //usa dr al posto di datareader
                }

                db.SQLQuery_AffectedRows("DROP DATABASE ef_base");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pg_stat_activity " + ex.Message);
            }
            finally
            {
                try
                {
                    db.CloseConnection();
                }
                catch (Exception)
                {
                    //LOG HERE
                }
            }

        }

        private void btnRgb2Lab_Click(object sender, EventArgs e)
        {
            Library.Data.Database.DBConnector db = null;

            try
            {
                db = new Library.Data.Database.DBConnector();

                DataTable dt = db.SQLQuerySelect("SELECT * FROM formule WHERE ciel IS NULL or (ciel=100 AND ciea = 0 AND cieb = 0)");
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        double R = Convert.ToDouble(dr["r"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        double G = Convert.ToDouble(dr["g"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        double B = Convert.ToDouble(dr["b"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                        int id = Convert.ToInt32(dr["id"].ToString().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);

                        double[] xyz = Colore.RGB_XYZ(R, G, B);
                        double[] Lab = Colore.XYZ_LAB(xyz[0], xyz[1], xyz[2]);

                        Dictionary<string, object> data = new Dictionary<string, object>();
                        data.Add("ciel", Lab[0].ToString().Replace(",", "."));
                        data.Add("ciea", Lab[1].ToString().Replace(",", "."));
                        data.Add("cieb", Lab[2].ToString().Replace(",", "."));

                        db.QueryUpdate("formule", data, "id=" + id.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                MessageBox.Show("Eseguito");  //don't translate because it's a hidden function!
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                try
                {
                    db.CloseConnection();
                }
                catch (Exception)
                {
                    //LOG HERE
                }
            }
        }
        

        private void License_btnResetDateCounter_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Data.SharedSettings sharedSettings = new Library.Data.SharedSettings();
                sharedSettings.SetValue("dtFirstAppOpened", DateTime.Now.ToString());

                MessageBox.Show("Done. Close Euroformulations now.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutodetectCOMPort();
        }

        private void AutodetectCOMPort()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);
            foreach (string s in SerialPort.GetPortNames())
            {
                MessageBox.Show(s);
            }
            /*try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    if (desc.Contains("Arduino"))
                    {
                        return deviceId;
                    }
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            //}

            //return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtNomeTinta.Text.Length > 0)
            {
                if (txtNomeTinta.Text.Trim() == sNomeTintaPrev)
                {
                    MessageBox.Show("tinta già acquisita!"); return;
                }
                try
                {
                    Library.Data.Dispositivi.DispositivoBase disp = Library.Data.Dispositivi.DispositiviManager.GetDispositivo();

                    if (!disp.Calibrato())
                    {
                        DialogResult dialogResult = MessageBox.Show("Fare la calibrazione?", "Calibrazione", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                        System.Windows.Forms.Form frmDevideDetail = disp.GetWindowManager(true, false);
                        if (frmDevideDetail != null)
                        {
                            frmDevideDetail.ShowDialog();
                        }

                        return;
                    }

                    ColorSearch.frmGetColor frmColor = new ColorSearch.frmGetColor();
                    frmColor.ShowDialog();
                    if (!frmColor.LetturaEseguita) { return; }

                    btnStandard.Enabled = false;

                    double l = frmColor.CIEL;
                    double a = frmColor.CIEa;
                    double b = frmColor.CIEb;
                    double[] xyz = Library.Colore.LAB_XYZ(l, a, b);
                    this.coloreSTD = new Colore(l, a, b, xyz[0], xyz[1], xyz[2]);
                    SetData_ColoreSTD(txtNomeTinta.Text);
                    btnStandard.Enabled = true;

                    textBoxLista.SelectionStart = textBoxLista.TextLength;
                    textBoxLista.ScrollToCaret();

                    sNomeTintaPrev = txtNomeTinta.Text.Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message);
                }
            }
        }

        private void btnConversioneTrasversale_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opentrasversale = new OpenFileDialog();
                opentrasversale.Filter = "CSV |*.csv";
                DialogResult result = opentrasversale.ShowDialog();
                if (result != DialogResult.OK) { return; }
                string file = opentrasversale.FileName;


                string[] columnNames = null;
                string[] lines = File.ReadAllLines(file);
                List<string> output = new List<string>();
                int i = 0;
                foreach (var line in lines)
                {
                    if (i > 0)
                    {
                        if (line.Trim() != "")
                        {
                            string sCompose = "";
                            string[] data = line.Split(';');

                            sCompose += "'" + data[0] + "', '" + data[1] + "', ";

                            int colCount = 0;
                            for (int j = 2; j < data.Length; j++)
                            {
                                if (data[j].Trim() != "")
                                {
                                    sCompose += "'" + columnNames[j] + "', " + data[j].Replace(',', '.') + ", ";
                                    colCount++;
                                }
                            }

                            for (; colCount < 5; colCount++)
                            {
                                sCompose += "NULL, NULL, ";
                            }


                            output.Add(sCompose);
                        }
                    }
                    else
                    {
                        columnNames = line.Split(';');
                    }
                    i++;
                }

                string path = Path.GetDirectoryName(file) + "\\output.csv";

                File.WriteAllLines(path, output.ToArray());
                MessageBox.Show("Done!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNomeTinta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) { return; }

            button2_Click(null, null);
        }

        private void btnCreaQueryUpdateCube_Click(object sender, EventArgs e)
        {
            string chart = txtCubeChart.Text;

            OpenFileDialog opentrasversale = new OpenFileDialog();
            opentrasversale.Filter = "TEXT FILE |*.txt";
            DialogResult result = opentrasversale.ShowDialog();
            if (result != DialogResult.OK) { return; }
            string file = opentrasversale.FileName;

            string[] lines = File.ReadAllLines(file);
            List<string> output = new List<string>();

            foreach (var line in lines)
            {
                string[] items = line.Split(';');

                string cname = items[0].Trim();
                string l = items[1].Trim().Replace(",", ".");
                string a = items[2].Trim().Replace(",", ".");
                string b = items[3].Trim().Replace(",", ".");

                string sQuery = "UPDATE formule SET ciel_cubecc = " + l + ", ciea_cubecc = " + a + ", cieb_cubecc = " + b + " WHERE colorname = '" + cname + "' AND colorcharts = '" + chart + "';";
                output.Add(sQuery);
            }

            string path = Path.GetDirectoryName(file) + "\\" + chart + ".sql";
            File.WriteAllLines(path, output.ToArray());

            MessageBox.Show("Done!");
        }

        private void btnCheckDuplicatiAvvia_Click(object sender, EventArgs e)
        {
            int i = 1;

            try
            {
                OpenFileDialog opentrasversale = new OpenFileDialog();
                opentrasversale.Filter = "TEXT |*.txt";
                DialogResult result = opentrasversale.ShowDialog();
                if (result != DialogResult.OK) { return; }
                string file = opentrasversale.FileName;
                string[] lines = File.ReadAllLines(file);
                Dictionary<string, string> controllo = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    string[] items = line.Split(';');
                    controllo.Add(items[0].Trim(), "");
                    i++;
                }
                MessageBox.Show("Perfect!");
            }
            catch (Exception)
            {
                MessageBox.Show("duplicato riga " + i);
            }



            //string[] columnNames = null;


        }

        private void btnDuplicatiRemove_Click(object sender, EventArgs e)
        {
            int i = 0;


            OpenFileDialog opentrasversale = new OpenFileDialog();
            opentrasversale.Filter = "TEXT |*.txt";
            DialogResult result = opentrasversale.ShowDialog();
            if (result != DialogResult.OK) { return; }
            string file = opentrasversale.FileName;
            string[] lines = File.ReadAllLines(file);
            Dictionary<string, string> controllo = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                string[] items = line.Split(';');
                try { controllo.Add(items[0].Trim(), line); }
                catch (Exception) { i++; }
            }
            string pathoUT = Path.GetDirectoryName(file) + "\\" + Path.GetFileName(file) + "_NEW.txt";
            StreamWriter writetext = new StreamWriter(pathoUT);

            foreach (KeyValuePair<string, string> pair in controllo)
            {
                writetext.WriteLine(pair.Value);
            }
            writetext.Close();

            MessageBox.Show("Eseguito (" + i + " duplicati)");

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int id_formula = -1;
            try
            {
                if (cmbCostoFormule_Listino == null || cmbCostoFormule_Prodotto.Text.Trim() == "")
                {
                    MessageBox.Show("no listino = no export! no prodotto = no export!");
                    return;
                }

                int idlistino = Convert.ToInt32(cmbCostoFormule_Listino.SelectedValue);
                List<string> lstData = new List<string>();

                SaveFile.Filter = "CSV Standard (*.csv)|*.csv| All types (*.*)|*.*";
                if (SaveFile.ShowDialog() != DialogResult.OK) return;

                //recupero di tutte le formule
                DataTable dt = db.SQLQuerySelect("SELECT id FROM formule where system = '" + cmbCostoFormule_Prodotto.Text.Trim() + "'");

                Library.Formulation.Formula formula;
                int ix = 0;
                int total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    id_formula = Convert.ToInt32(dr["id"].ToString());

                    formula = Library.Formulation.Formula.InitFormula_From_formule(id_formula);
                    formula = formula.ChangeBase(1d, Library.Formulation.eUnita.KG, false, "");
                    double dCosto = formula.GetCost_Base(idlistino);
                    string sData = "";
                    try
                    {
                        sData = formula.FormulaName + ";"
                            + formula.BaseName + ";"
                            + formula.BaseUnita + ";"
                            + formula.BaseQta.ToString() + ";"
                            + formula.BaseUnita.ToString() + ";"
                            + formula.ColorChart + ";"
                            + formula.BaseProdotto + ";"
                            + formula.Use + ";"
                            + formula.RGB_R.ToString() + ";"
                            + formula.RGB_G.ToString() + ";"
                            + formula.RGB_B.ToString() + ";";

                        for (int i = 0; i < formula.ColorantsCount; i++)
                        {
                            sData += formula.ColorantName(i) + "(" + formula.ColorantQta(i) + "),";
                            dCosto += formula.GetCost_Colorant(i, idlistino);
                        }
                        sData += ";";
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("errore 1: " + ex1.Message);
                    }

                    try
                    {
                        sData += Math.Round(dCosto, 2).ToString();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("errore 2: " + ex2.Message);
                    }
                    lstData.Add(sData);

                    if (ix % 100 == 0) { lblForecastStatus.Text = ix.ToString() + "/" + total.ToString(); Application.DoEvents(); }
                    ix++;
                }

                //save data
                //SaveFile.FileName
                System.IO.File.WriteAllLines(SaveFile.FileName, lstData);



                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {

                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                MessageBox.Show("Errore: " + ex.Message + " - " + line.ToString() + " - " + id_formula.ToString());
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id_formula = -1;

            try
            {
                if (cmbFConvBase.Text.Trim() == "" || cmbFConvCol.Text.Trim() == "" || txtFConverterBaseQta.Text.Trim() == "" || cmbFConvColName.Text.Trim() == "")
                {
                    throw new Exception("missing data");
                }
                bool bColCode = cmbFConvColName.Text.Trim() == "CODE";
                Library.Formulation.eUnita unitaBase = Library.Formulation.eUnita.KG;
                Library.Formulation.eUnita unitaCol = Library.Formulation.eUnita.gr;
                if (cmbFConvBase.Text == "LT")
                {
                    unitaBase = Library.Formulation.eUnita.LT;
                }
                if (cmbFConvCol.Text == "ML")
                {
                    unitaCol = Library.Formulation.eUnita.ml;
                }

                List<string> lstData = new List<string>();

                SaveFile.Filter = "CSV Standard (*.csv)|*.csv| All types (*.*)|*.*";
                if (SaveFile.ShowDialog() != DialogResult.OK) return;

                //recupero di tutte le formule
                DataTable dt = db.SQLQuerySelect("SELECT * FROM formule");

                Library.Formulation.Formula formula;
                int ix = 0;
                int total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
                    id_formula = Convert.ToInt32(dr["id"].ToString());
                    formula = Library.Formulation.Formula.InitFormula_From_formule(id_formula);
                    formula = formula.ChangeBase(Convert.ToDouble(txtFConverterBaseQta.Text.Replace(",", "."), CultureInfo.InvariantCulture), unitaBase, false, "");
                    string sData = "";
                    try
                    {
                        sData = formula.DeltaE + ";"
                            + formula.NW + ";"
                            + ";"  //NOTE
                            + formula.FormulaName + ";"
                            + formula.BaseName + ";"
                            + (cmbFConvCol.Text == "ML" ? "MILLILITERS" : "GRAMS") + ";"
                            + ";"  //ONCETYPE
                            + txtFConverterBaseQta.Text.Replace(",", ".") + "-" + unitaBase.ToString() + ";";

                        int i = 0;
                        for (; i < formula.ColorantsCount; i++)
                        {
                            double dQta = Library.Formulation.Formula.ConvertValue(formula.ColorantQta(i), formula.ColorantsUnit, unitaCol, formula.ColorantDensita(i));
                            sData += (bColCode ? formula.ColorantCode(i) : formula.ColorantName(i)) + ";" + Math.Round(dQta, 4).ToString().Replace(".", ",") + ";";
                        }

                        while (i <= 5)
                        {
                            sData += ";;";
                            i++;
                        }

                        sData += formula.ColorChart + ";"
                            + formula.BaseProdotto + ";"
                            + formula.Use + ";"
                            + formula.RGB_R.ToString() + ";"
                            + formula.RGB_G.ToString() + ";"
                            + formula.RGB_B.ToString() + ";"
                            + Math.Round(formula.CIEL, 4).ToString() + ";"
                            + Math.Round(formula.CIEa, 4).ToString() + ";"
                            + Math.Round(formula.CIEb, 4).ToString();


                        sData += ";";
                    }
                    catch (Exception ex1)
                    {
                        MessageBox.Show("errore 1: " + ex1.Message);
                    }

                    lstData.Add(sData);

                    if (ix % 100 == 0) { lblConverterStatus.Text = ix.ToString() + "/" + total.ToString(); Application.DoEvents(); }
                    ix++;
                }

                //save data
                System.IO.File.WriteAllLines(SaveFile.FileName, lstData);



                MessageBox.Show("Done!");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        





        private static DateTime GetServerData()
        {
            throw new NotImplementedException();
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = null;
            Library.Data.DBSettings settings = new Library.Data.DBSettings();

            try
            {
                //-1 get dt server, dt now sincronizzata
                DateTime dtserver = GetServerData();
                if (dtserver == DateTime.MinValue) { return; }
                DateTime dtNowSynched = DateTime.Now;
                TimeSpan ts = dtserver - dtNowSynched;
                dtNowSynched = dtNowSynched.Add(ts);

                //0) delete clienti eliminati e non sincronizzati
                db.QueryDelete("clienti", "deleted = 1 AND idcloud IS NULL");


                #region 1) aggiornamento date locali (se necessario)
                DataTable dtlastupdate = db.SQLQuerySelect("SELECT id, lastupdate FROM clienti WHERE servertimesync = 1");
                if (dtlastupdate.Rows.Count > 0)
                {
                    Dictionary<string, object> dicClienti = new Dictionary<string, object>();
                    foreach (DataRow dr in dtlastupdate.Rows)
                    {
                        DateTime dtCliente = DateTime.ParseExact(dr["lastupdate"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        dicClienti.Add("lastupdate", dtCliente.Add(ts).ToString("yyyy-MM-dd HH:mm:ss"));
                        dicClienti.Add("servertimesync", "0");
                        db.QueryUpdate("clienti", dicClienti, "id = " + dr["id"].ToString());
                        dicClienti.Clear();
                    }
                }
                #endregion

                //3) recupero (sul client) data di ultima scrittura
                DateTime dtClient = DateTime.ParseExact(settings.GetValue("sync_clienti"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                #region 4) connessione database remoto
                string connetionString = "server=23.229.188.12;database=euroformulation;uid=simone;pwd=simone85;";
                cnn = new MySqlConnection(connetionString);
                cnn.Open();
                #endregion

                //4.5 start transaction
                MySqlTransaction trans = cnn.BeginTransaction();

                #region 5) recupero ID MyLicense e data ultima sync eseguita sul server
                string sql = "SELECT IDUtente, dt_sync_client FROM utenti WHERE IDUtente = (SELECT utente FROM utenti_licenze WHERE ef = " + GVar.attivazioni.IDEuroFormulationInCloud + ") FOR UPDATE";  //LOCK IN SHARE MODE
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string sIDMYLicense = reader["IDUtente"].ToString();
                DateTime dtServer = DateTime.Parse(reader["dt_sync_client"].ToString());
                reader.Close();
                #endregion

                string sIDServerUpdate = "";

                #region 6) (se necessario) AGGIORNAMENTO CLIENTI IN LOCALE
                if (dtClient < dtServer)
                {
                    sql = "SELECT * FROM clienti WHERE idutente = " + sIDMYLicense;
                    cmd = new MySqlCommand(sql, cnn);
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Dictionary<int, DateTime> dicIDUpdate = new Dictionary<int, DateTime>();
                        DataTable dt = db.SQLQuerySelect("select idcloud, lastupdate from clienti where idcloud is not null");
                        foreach (DataRow dr in dt.Rows)
                        {
                            int iIDCloud = Convert.ToInt32(dr["idcloud"]);
                            if (!dicIDUpdate.ContainsKey(iIDCloud))
                            {
                                dicIDUpdate.Add(iIDCloud, DateTime.ParseExact(dr["lastupdate"].ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
                            }
                        }

                        while (reader.Read())
                        {
                            int idserver = Convert.ToInt32(reader["id"].ToString());
                            if (!dicIDUpdate.ContainsKey(idserver))
                            {
                                //insert
                                DateTime dtLastUpdate = DateTime.Parse(reader["last_update"].ToString());

                                Dictionary<string, string> dicData = new Dictionary<string, string>();
                                dicData.Add("idcloud", idserver.ToString());
                                dicData.Add("deleted", reader["deleted"].ToString());
                                dicData.Add("lastupdate", dtLastUpdate.ToString("yyyy-MM-dd HH:mm:ss"));
                                dicData.Add("tipo", reader["tipo"].ToString());

                                if (reader["nome"] != null) { dicData.Add("nome", reader["nome"].ToString()); }
                                if (reader["cognome"] != null) { dicData.Add("cognome", reader["cognome"].ToString()); }
                                if (reader["azienda"] != null) { dicData.Add("azienda", reader["azienda"].ToString()); }
                                if (reader["indirizzo"] != null) { dicData.Add("indirizzo", reader["indirizzo"].ToString()); }
                                if (reader["nomepaese"] != null) { dicData.Add("nomepaese", reader["nomepaese"].ToString()); }
                                if (reader["codicepaese"] != null) { dicData.Add("codicepaese", reader["codicepaese"].ToString()); }
                                if (reader["tel1"] != null) { dicData.Add("tel1", reader["tel1"].ToString()); }
                                if (reader["tel2"] != null) { dicData.Add("tel2", reader["tel2"].ToString()); }
                                if (reader["fax"] != null) { dicData.Add("fax", reader["fax"].ToString()); }
                                if (reader["email"] != null) { dicData.Add("email", reader["email"].ToString()); }
                                if (reader["partitaiva"] != null) { dicData.Add("partitaiva", reader["partitaiva"].ToString()); }
                                if (reader["note"] != null) { dicData.Add("note", reader["note"].ToString()); }
                                if (reader["city"] != null) { dicData.Add("city", reader["city"].ToString()); }
                                if (reader["cap"] != null) { dicData.Add("cap", reader["cap"].ToString()); }
                                if (reader["country"] != null) { dicData.Add("country", reader["country"].ToString()); }
                                if (reader["barcode"] != null) { dicData.Add("barcode", reader["barcode"].ToString()); }

                                db.QueryInsert("clienti", dicData);
                            }
                            else
                            {
                                DateTime dtOnServer = DateTime.Parse(reader["last_update"].ToString());
                                DateTime dtOnClient = dicIDUpdate[idserver];

                                if (dtOnServer > dtOnClient)
                                {
                                    //update dati in locale
                                    DateTime dtLastUpdate = DateTime.Parse(reader["last_update"].ToString());
                                    Dictionary<string, object> dicData = new Dictionary<string, object>();
                                    dicData.Add("deleted", reader["deleted"].ToString());
                                    dicData.Add("lastupdate", dtLastUpdate.ToString("yyyy-MM-dd HH:mm:ss"));
                                    dicData.Add("tipo", reader["tipo"].ToString());

                                    if (reader["nome"] != null) { dicData.Add("nome", reader["nome"].ToString()); }
                                    if (reader["cognome"] != null) { dicData.Add("cognome", reader["cognome"].ToString()); }
                                    if (reader["azienda"] != null) { dicData.Add("azienda", reader["azienda"].ToString()); }
                                    if (reader["indirizzo"] != null) { dicData.Add("indirizzo", reader["indirizzo"].ToString()); }
                                    if (reader["nomepaese"] != null) { dicData.Add("nomepaese", reader["nomepaese"].ToString()); }
                                    if (reader["codicepaese"] != null) { dicData.Add("codicepaese", reader["codicepaese"].ToString()); }
                                    if (reader["tel1"] != null) { dicData.Add("tel1", reader["tel1"].ToString()); }
                                    if (reader["tel2"] != null) { dicData.Add("tel2", reader["tel2"].ToString()); }
                                    if (reader["fax"] != null) { dicData.Add("fax", reader["fax"].ToString()); }
                                    if (reader["email"] != null) { dicData.Add("email", reader["email"].ToString()); }
                                    if (reader["partitaiva"] != null) { dicData.Add("partitaiva", reader["partitaiva"].ToString()); }
                                    if (reader["note"] != null) { dicData.Add("note", reader["note"].ToString()); }
                                    if (reader["city"] != null) { dicData.Add("city", reader["city"].ToString()); }
                                    if (reader["cap"] != null) { dicData.Add("cap", reader["cap"].ToString()); }
                                    if (reader["country"] != null) { dicData.Add("country", reader["country"].ToString()); }
                                    if (reader["barcode"] != null) { dicData.Add("barcode", reader["barcode"].ToString()); }

                                    db.QueryUpdate("clienti", dicData, "idcloud = " + idserver);
                                }
                                else
                                {
                                    if (dtOnClient > dtOnServer)
                                    {
                                        sIDServerUpdate += idserver + ",";
                                    }
                                }
                            }
                        }
                    }
                    reader.Close();

                    //aggiornamento data server in locale
                    //settings.SetValue("sync_clienti", dtServer.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                #endregion

                #region 7) (se necessario) AGGIORNAMENTO clienti SUL SERVER
                string sqlClientiLocal = "SELECT * FROM clienti WHERE idcloud IS NULL";
                if (sIDServerUpdate != "")
                {
                    sIDServerUpdate = sIDServerUpdate.Substring(0, sIDServerUpdate.Length - 1);
                    sqlClientiLocal += " OR idcloud IN (" + sIDServerUpdate + ")";
                }
                DataTable dt3 = db.SQLQuerySelect(sqlClientiLocal);

                if (dt3.Rows.Count > 0)
                {
                    string sDTNowSynched = dtNowSynched.ToString("yyyy-MM-dd HH:mm:ss");
                    foreach (DataRow dr3 in dt3.Rows)
                    {
                        string sIDCloud = dr3["idcloud"].ToString();
                        if (sIDCloud == "")
                        {
                            //inserimento
                            string sqlNuoviClienti = "INSERT INTO clienti (nome, cognome, azienda, indirizzo, nomepaese, codicepaese, tel1, tel2, fax, email, partitaiva, note, tipo, city, cap, country, barcode, deleted, idutente, last_update)" +
                                " VALUES ('" + dr3["nome"].ToString() +
                                "', '" + dr3["cognome"].ToString() +
                                "', '" + dr3["azienda"].ToString() +
                                "', '" + dr3["indirizzo"].ToString() +
                                "', '" + dr3["nomepaese"].ToString() +
                                "', '" + dr3["codicepaese"].ToString() +
                                "', '" + dr3["tel1"].ToString() +
                                "', '" + dr3["tel2"].ToString() +
                                "', '" + dr3["fax"].ToString() +
                                "', '" + dr3["email"].ToString() +
                                "', '" + dr3["partitaiva"].ToString() +
                                "', '" + dr3["note"].ToString() +
                                "', '" + dr3["tipo"].ToString() +
                                "', '" + dr3["city"].ToString() +
                                "', '" + dr3["cap"].ToString() +
                                "', '" + dr3["country"].ToString() +
                                "', '" + dr3["barcode"].ToString() +
                                "', '" + dr3["deleted"].ToString() +
                                "', '" + sIDMYLicense +
                                "', '" + sDTNowSynched + "' );";
                            string sIDLocal = dr3["id"].ToString();
                            MySqlCommand cmd2 = new MySqlCommand(sqlNuoviClienti, cnn);
                            cmd2.ExecuteNonQuery();
                            long lID = cmd2.LastInsertedId;

                            //update local idcloud + lastupdate
                            Dictionary<string, object> dicInsertion = new Dictionary<string, object>();
                            dicInsertion.Add("idcloud", lID.ToString());
                            dicInsertion.Add("lastupdate", sDTNowSynched);
                            db.QueryUpdate("clienti", dicInsertion, "id = " + sIDLocal);
                        }
                        else
                        {
                            //aggiornamento
                            try
                            {
                                //query
                                string sqlUpdateClienti = "UPDATE clienti SET " +
                                    "nome = '" + dr3["nome"].ToString() + "', " +
                                    "cognome = '" + dr3["cognome"].ToString() + "', " +
                                    "azienda = '" + dr3["azienda"].ToString() + "', " +
                                    "indirizzo = '" + dr3["indirizzo"].ToString() + "', " +
                                    "nomepaese = '" + dr3["nomepaese"].ToString() + "', " +
                                    "codicepaese = '" + dr3["codicepaese"].ToString() + "', " +
                                    "tel1 = '" + dr3["tel1"].ToString() + "', " +
                                    "tel2 = '" + dr3["tel2"].ToString() + "', " +
                                    "fax = '" + dr3["fax"].ToString() + "', " +
                                    "email = '" + dr3["email"].ToString() + "', " +
                                    "partitaiva = '" + dr3["partitaiva"].ToString() + "', " +
                                    "note = '" + dr3["note"].ToString() + "', " +
                                    "tipo = '" + dr3["tipo"].ToString() + "', " +
                                    "city = '" + dr3["city"].ToString() + "', " +
                                    "cap = '" + dr3["cap"].ToString() + "', " +
                                    "country = '" + dr3["country"].ToString() + "', " +
                                    "barcode = '" + dr3["barcode"].ToString() + "', " +
                                    "deleted = '" + dr3["deleted"].ToString() + "', " +
                                    "last_update = '" + dr3["lastupdate"].ToString() + "' " +
                                    "WHERE id = " + sIDCloud;

                                MySqlCommand cmd3 = new MySqlCommand(sqlUpdateClienti, cnn);
                                cmd3.ExecuteNonQuery();
                            }
                            catch (Exception) { }
                        }
                    }

                    //update dt synched nel server (e nel client)
                    string sqlUPDUtente = "UPDATE utenti SET dt_sync_client = '" + sDTNowSynched + "' WHERE IDUtente = " + sIDMYLicense;
                    MySqlCommand cmd4 = new MySqlCommand(sqlUPDUtente, cnn);
                    cmd4.ExecuteNonQuery();

                    settings.SetValue("sync_clienti", sDTNowSynched);
                }
                #endregion



                trans.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (cnn != null) { cnn.Close(); }
                MessageBox.Show("JOB Done!");
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Library.Data.Database.ClusterGenerator clustergen = Library.Data.Database.ClusterGenerator.GetInstance();

                string sData = GVar.Database + "\t" + clustergen.Port.ToString();
                Clipboard.SetText(sData);

                MessageBox.Show("dati copiati negli appunti: " + sData);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        


        private void button6_Click(object sender, EventArgs e)
        {
            dgColPerc.Rows.Clear();

            try
            {
                DataTable dt = db.SQLQuerySelect("SELECT p1 as nome FROM formule WHERE p1 != '' UNION SELECT p2 as nome FROM formule WHERE p2 != '' UNION SELECT p3 as nome FROM formule WHERE p3 != '' UNION SELECT p4 as nome FROM formule WHERE p4 != '' UNION SELECT p5 as nome FROM formule AS nome WHERE p5 != '' ");
                foreach (DataRow dr in dt.Rows)
                {
                    dgColPerc.Rows.Add(dr["nome"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgColPerc.Rows)
                {
                    string colCode = row.Cells[0].Value.ToString();
                    string sPerc = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrEmpty(sPerc))
                    {
                        int perc = Convert.ToInt32(row.Cells[1].Value.ToString());
                        string query_addSubtract = "+";
                        if (perc < 0)
                            query_addSubtract = "-";
                        int iPerc = (int)Math.Abs(Convert.ToInt32(perc));

                        for (int i = 1; i <= 5; i++)
                        {
                            string query = "update formule set q" + i + " = q" + i + " "
                            + query_addSubtract
                            + " ((q" + i + "/ 100) * "
                            + iPerc.ToString()
                            + ") where p" + i + " = '"
                            + colCode + "';";

                            db.SQLQuery_AffectedRows(query);
                        }
                    }
                }

                MessageBox.Show("Done!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblForecastStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
