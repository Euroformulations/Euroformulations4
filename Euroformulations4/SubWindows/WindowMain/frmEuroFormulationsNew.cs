using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Euroformulations4.Library;
using System.Threading;
using System.Timers;
using Npgsql;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Management;
using System.Windows.Threading;
using System.Globalization;
using Microsoft.VisualBasic;
using System.Net.Mail;
using S22.Imap;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmEuroFormulationsNew : Form
    {
        Library.Data.Database.DBConnector db = null;
        private Library.Data.DBSettings dbSettings;
        private object oDayLeft = null;
        private bool bRebootRequest = false;
        private System.Windows.Forms.Form currentForm;
        private Dispatcher disp;
        private Library.AnimationMenuManager menuManager;
        private System.Drawing.Color colorMenuMouseEnter = System.Drawing.Color.LightGray;
        private System.Drawing.Color colorMenuSelected = System.Drawing.Color.LightGreen;
        private Euroformulations4.Menu.MenuManager menu;
        ToolTip tp;
        private Thread UpdateHistory;
        private Thread UpdateChecker;
        private Thread UpdateArchivio;
        private string sVersioneRemotaFull = "";
        private Thread LoadFormule;
        private Thread UploadHiddenData;
        //private Thread UploadLog;
        //private Thread SyncClienti;
        private Thread tEmailReceiver;
        private Thread tDownload = null;
        private Thread tLoad = null;
        private bool bLoadingStop = false;
        private frmLoading frmLoader;
        private static string SOFTWARE_UPDATE_PATH = "";
        private bool enabledInstallUpdates = false;
        private static Library.Language lang;
        //private static Library.Log log;
        private bool bAdminMode = false;
        private bool bAdminEnabled = false;
        private bool bSettingsEnabled = false;
        private static int iThreadSleep = 10000;
        private Image imageLogo = null;
        private Image imageSfondo = null;
        private Image imageWelcome = null;
        private Library.Data.Database.DBConnector dbThread_loadFormule = null;
        private Library.Data.Database.DBConnector dbThread_Cloud = null;
        public frmEuroFormulationsNew(bool bAdminMode)
        {
            InitializeComponent();
            
            this.frmLoader = new frmLoading();
            this.bAdminMode = bAdminMode;

            disp = Dispatcher.CurrentDispatcher;
            menuManager = new AnimationMenuManager();
            tp = new ToolTip();
            lang = Library.Language.GetInstance();
            //log = Library.Log.GetInstance();

            tLoad = new Thread(AsyncSoftwareLoad);
            tLoad.IsBackground = true;

            Library.Formulation.Formula.ResetStaticData();
        }

        private void frmEuroFormulationsNew_Load(object sender, EventArgs e)
        {
            try
            {
                IniFile conf = new IniFile();
                GVar.appIsRunning = true;

                //config text file
                GVar.Database = conf.IniReadValue("DATABASE", "ActiveDB");
                if (conf.IniReadValue("DBLIST", GVar.Database).Trim() == "")
                {
                    conf.IniWriteValue("DBLIST", GVar.Database, "Database 01");
                }
                GVar.ServerIP = conf.IniReadValue("DATABASE", "ServerIP");

                //aggiornamento versione DB
                db = new Library.Data.Database.DBConnector();
                Library.Data.Database.DBStructureManager.ControlloDBSettings(); //ControlloDBSettings() PRIMA di ControlloVersioneDB()!!!
                Library.Data.Database.DBStructureManager.ControlloVersioneDB();

                //config + DB
                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                dbSettings = new Library.Data.DBSettings();

                //loghi
                try
                {
                    byte[] imgData = dbSettings.GetValueData("personalized_logo");
                    if (imgData != null)
                    {
                        lblPowered.Visible = true;
                        imageLogo = Image.FromStream(new System.IO.MemoryStream(imgData));
                    }
                    byte[] imgSfondo = dbSettings.GetValueData("personalized_logoCenter");
                    if (imgSfondo != null)
                    {
                        imageSfondo = Image.FromStream(new System.IO.MemoryStream(imgSfondo));
                    }
                    byte[] bWelcome = dbSettings.GetValueData("personalized_logoLoading");
                    if (bWelcome != null)
                    {
                        imageWelcome = Image.FromStream(new System.IO.MemoryStream(bWelcome));
                    }
                }
                catch (Exception) { } //TODO

                //attivazione prodotti con licenza
                AttivaProdotti();

                tLoad.Start();
                iThreadSleep = Convert.ToInt32(settings.GetValue("Timer"));

                //inizializzazione dispositivo
                Library.Data.Dispositivi.DispositiviManager.StartService();

                //inserimento menu
                menu = new Euroformulations4.Menu.MenuManager(this, bAdminMode);
                menu.Draw(menuPanel);
                ActionExecute_Welcome();
               

                #region THREAD/TIMER LOAD
                //UploadHiddenData = new Thread(() => UpHiddenData());
                //UploadHiddenData.IsBackground = true;

                //UpdateHistory = new Thread(() => UpHistory_Thread());
                //UpdateHistory.IsBackground = true;

                UpdateChecker = new Thread(() => UpCheck_Thread());
                UpdateChecker.IsBackground = true;

                LoadFormule = new Thread(AsynchFormuleLoader);
                LoadFormule.IsBackground = true;

                //UpdateArchivio = new Thread(AsynchArchiveUpdater);
                //UpdateArchivio.IsBackground = true;

                /*UploadLog = new Thread(UploadLogExecute);
                UploadLog.IsBackground = true;*/

                /*SyncClienti = new Thread(SyncClientiExecute);
                SyncClienti.IsBackground = true;*/

                //tEmailReceiver = new Thread(EmailReceiver);
                //tEmailReceiver.IsBackground = true;

               
                        //UploadHiddenData.Start();
                        dbThread_Cloud = new Library.Data.Database.DBConnector();
                        //UpdateHistory.Start();
                        UpdateChecker.Start();
                        //UploadLog.Start();
                        //SyncClienti.Start();
                        //UpdateArchivio.Start();
                        //if (GVar.attivazioni.Act_OrderReceiver) { tEmailReceiver.Start(); }
                    
                    if (GVar.attivazioni.Act_ColorSearch)
                    {
                        dbThread_loadFormule = new Library.Data.Database.DBConnector();
                        LoadFormule.Start();
                    }

                
                #endregion

                #region DATA LOAD

                //basi
                DataTable dt_base = db.SQLQuerySelect("SELECT base FROM base");
                foreach (DataRow dr in dt_base.Rows)
                {
                    GVar.ListaBasi.Add(dr["base"].ToString());
                }

                //pigmenti
                DataTable dt_pigmenti = db.SQLQuerySelect("SELECT * FROM pigmenti");
                foreach (DataRow dr in dt_pigmenti.Rows)
                {
                    string key = dr["fullname"].ToString() + "/" + dr["code"].ToString() + "/" + dr["pr"].ToString() + "/" + dr["pg"].ToString() + "/" + dr["pb"].ToString();
                    double value = Convert.ToDouble(dr["density"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                    GVar.ListaPigmenti.Add(key, value);
                    GVar.lstNomiFullColoranti.Add(dr["fullname"].ToString());
                }
                #endregion

                //menuPanel.BackColor = System.Drawing.Color.FromArgb(69, 69, 69);

                switch (settings.GetValue("ModeSave"))
                {
                    case "FULL SCREEN":
                        {
                            this.Location = new Point(0, 0);
                            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                            this.WindowState = FormWindowState.Maximized;
                            pbExit.Visible = true;
                            tp.SetToolTip(pbExit, "Exit");
                            break;
                        }
                    case "YES":
                        {
                            string WindowMaximized = settings.GetValue("WindowMaximized");
                            if (WindowMaximized == "1")
                            {
                                this.WindowState = FormWindowState.Maximized;
                            }
                            else
                            {
                                int x = Convert.ToInt32(settings.GetValue("PosX"));
                                if (x < 0) x = 0;
                                int y = Convert.ToInt32(settings.GetValue("PosY"));
                                if (y < 0) y = 0;
                                int height = Convert.ToInt32(settings.GetValue("Height"));
                                if (height < this.MinimumSize.Height) height = this.MinimumSize.Height;
                                int width = Convert.ToInt32(settings.GetValue("Width"));
                                if (width < this.MinimumSize.Width) width = this.MinimumSize.Width;
                                this.Location = new Point(x, y);
                                this.Size = new Size(width, height);
                            }

                            break;
                        }
                }

                //resize main window
                if (dbSettings.GetValue("resizemainwindow") == "0" && settings.GetValue("ModeSave") != "FULL SCREEN")
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                    this.MaximizeBox = false;
                    this.MinimizeBox = false;
                }

                //sw title
                this.Text = lang.GetWord("main01");
                this.Text = this.Text.Replace("4", "").Trim();

                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                this.Text += " " + fvi.FileVersion;
            }
            catch (Exception ex)
            {
                string lineNumber = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                MessageBox.Show(ex.Message + " (" + lineNumber + ")");
            }

            bLoadingStop = true;
            while (tLoad.IsAlive) { Thread.Sleep(1); }
        }

        private void AttivaProdotti()
        {
            try
            {
                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();

                //get settings data
                if (!settings.HasKey("dtFirstAppOpened"))
                {
                    settings.SetValue("dtFirstAppOpened", DateTime.Now.ToString());
                }
                else
                {
                    if (settings.GetValue("dtFirstAppOpened").Trim() == "")
                    {
                        settings.SetValue("dtFirstAppOpened", DateTime.Now.ToString());
                    }
                }
                if (!settings.HasKey("dtLastAppClosed"))
                {
                    settings.SetValue("dtLastAppClosed", DateTime.MinValue.ToString());
                }
                else
                {
                    if (settings.GetValue("dtLastAppClosed").Trim() == "")
                    {
                        settings.SetValue("dtLastAppClosed", DateTime.MinValue.ToString());
                    }
                }

                DateTime dtFirstAppOpened = DateTime.Parse(settings.GetValue("dtFirstAppOpened"));
                DateTime dtLastAppClosed = DateTime.Parse(settings.GetValue("dtLastAppClosed"));

                string encrypted = "";

                
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey(@"Software\\EuroFormulations\\4");

                if (regKey.GetValue("Key").ToString().Trim() != "")
                {
                    encrypted = regKey.GetValue("Key").ToString();
                }
                else
                {
                    encrypted = "M4FDLt7A2tEMVQQGD00hlZOjRwvPn9e4EgDqv+20S0mZfd3k70S63b26nXBu/eMTKYGcqrTsUSqSdQ513+SHG9VlDcWnl9Zjceoj9udiZ9Dl7c83eO1ogeM6TQXouOmfUVRHjPJapyVNM2HmaPuwOmD4d9ZdSzuNOBge1sX+k8CUysfdoa4epfDpzew1yhy1";
                }


                /*string sLicenza = "DEMO001;FULL;1-2-3-4-5-6-7-8-9-10-11-12-13-14-15-16-17-18-19;2016-01-18 09:00:00;30;-1;EuroFormulations4 DEMO";
                    sLicenza = sLicenza + "|" + Attivazioni.CalculateMD5Hash(sLicenza);
                    sLicenza = Attivazioni.OpenSSLEncrypt(sLicenza);*/


                
                
                GVar.attivazioni = new Attivazioni();



                //product activated info

              
            }
            catch (Exception)
            {
                GVar.attivazioni = new Attivazioni();
                bSettingsEnabled = true;
            }
        }

        

        /*
        public void UpHistory_Thread()
        {
            string codice = Library.Attivazioni.GetInstallationCode();
            //Log logUpHistory = null;
            bool bConnTimeoutNotified = false;
            

            try
            {
                while (GVar.appIsRunning)
                {
                    if (!CheckForInternetConnection())
                    {
                        if (!bConnTimeoutNotified)
                        {
                            //if (logUpHistory != null) { logUpHistory.WriteLog("ERR UPCLOUDHIST CONN OUT"); }
                            bConnTimeoutNotified = true;
                        }
                    }
                    else
                    {
                        bConnTimeoutNotified = false;
                        try
                        {
                            Library.Data.DBSettings dbsettings = new Library.Data.DBSettings();
                            IniFile ini = new IniFile();

                            string dbmanufacturername = dbsettings.GetValue("dbmanufacturername");
                            string dbusername = ini.IniReadValue("DBLIST", GVar.Database).Trim();
                            if (dbusername.StartsWith("'")) { dbusername = dbusername.Substring(1); }
                            if (dbusername.EndsWith("'")) { dbusername = dbusername.Substring(0, dbusername.Length - 1); }
                            dbusername = dbusername.Replace("'", @"""");
                            string dt_database_creation = dbsettings.GetValue("dt_database_creation");

                            DataTable dt = dbThread_Cloud.SQLQuerySelect("SELECT * FROM history WHERE cloud = 'no'");

                            foreach (DataRow dr in dt.Rows)
                            {
                                using (System.Net.WebClient sendto = new System.Net.WebClient())
                                {
                                    System.Collections.Specialized.NameValueCollection param = new System.Collections.Specialized.NameValueCollection();
                                    string sIDHistory = dr["id"].ToString();

                                    #region PARAMETRI
                                    param.Add("IDEuroformulation", GVar.attivazioni.IDEuroFormulationInCloud);
                                    param.Add("de", dr["de"].ToString().Replace(",", "."));
                                    param.Add("decmc", dr["decmc"].ToString().Replace(",", "."));
                                    param.Add("nw", dr["nw"].ToString());
                                    DateTime dtFormula = DateTime.Parse(dr["dateformula"].ToString());
                                    param.Add("dateformula", dtFormula.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
                                    param.Add("notetxt", dr["notetxt"].ToString());
                                    param.Add("colorname", dr["colorname"].ToString());
                                    param.Add("base", dr["base"].ToString());
                                    param.Add("densita", dr["densita"].ToString().Replace(",", "."));
                                    param.Add("unit", dr["unit"].ToString());
                                    param.Add("oncetype", dr["oncetype"].ToString());
                                    param.Add("formulasize", dr["formulasize"].ToString());
                                    param.Add("p1", dr["p1"].ToString());
                                    param.Add("q1", dr["q1"].ToString().Replace(",", "."));
                                    param.Add("p2", dr["p2"].ToString());
                                    param.Add("q2", dr["q2"].ToString().Replace(",", "."));
                                    param.Add("p3", dr["p3"].ToString());
                                    param.Add("q3", dr["q3"].ToString().Replace(",", "."));
                                    param.Add("p4", dr["p4"].ToString());
                                    param.Add("q4", dr["q4"].ToString().Replace(",", "."));
                                    param.Add("p5", dr["p5"].ToString());
                                    param.Add("q5", dr["q5"].ToString().Replace(",", "."));
                                    param.Add("colorcharts", dr["colorcharts"].ToString());
                                    param.Add("system", dr["system"].ToString());
                                    param.Add("use", dr["use"].ToString());
                                    param.Add("r", dr["r"].ToString());
                                    param.Add("g", dr["g"].ToString());
                                    param.Add("b", dr["b"].ToString());
                                    param.Add("ciel", dr["ciel"].ToString().Replace(",", "."));
                                    param.Add("ciea", dr["ciea"].ToString().Replace(",", "."));
                                    param.Add("cieb", dr["cieb"].ToString().Replace(",", "."));
                                    param.Add("dbmanufacturername", dbmanufacturername);
                                    param.Add("dbusername", dbusername);
                                    param.Add("dt_database_creation", dt_database_creation);
                                    param.Add("idcliente", dr["idcloudcliente"].ToString());
                                    #endregion

                                    byte[] response_bytes = sendto.UploadValues(GVar.AddressCloud + "../_remoteFunctions/cloud.php", "POST", param);
                                    string response_body = Encoding.ASCII.GetString(response_bytes);
                                    if (response_body == "ok")
                                    {
                                        string sql = "UPDATE history SET cloud = 'yes' WHERE id = " + sIDHistory;
                                        Dictionary<string, object> data = new Dictionary<string, object>();
                                        data.Add("cloud", "yes");
                                        dbThread_Cloud.QueryUpdate("history", data, "id = " + sIDHistory);
                                        if (dbThread_Cloud.LastQueryError != "")
                                        {
                                            //if (logUpHistory != null) { logUpHistory.WriteLog("ERR UPCLOUDHIST SET YES " + dbThread_Cloud.LastQueryError); }
                                        }
                                    }
                                    else
                                    {
                                        
                                         server response & actions:
                                         * 01: ID Euroformulation non specificato: stop thread
                                         * 02: errore di connessione interno al sito: pause
                                         * 03: query di inserimento dati fallito: pause
                                         * 04: query di recupero abilitazione al cloud fallito: pause
                                         * 05: cloud non abilitato
                                         

                                        
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //if (logUpHistory != null) { logUpHistory.WriteLog("ERR UPCLOUDHIST QUERYUP " + ex.Message); }
                        }
                    }
                    if (GVar.appIsRunning)
                    {
                        try { Thread.Sleep(iThreadSleep); }
                        catch (Exception) { }
                    }
                }
            }
            catch (Exception)
            {
                //if (logUpHistory != null) { logUpHistory.WriteLog("ERR UPCLOUDHIST INITUP " + ex.Message); }
            }
        }
        */

        #region UPLOAD HIDDEN DATA
        //public static void UpHiddenData()
        //{
        //    try
        //    {
        //        if (!CheckForInternetConnection())
        //        {
        //            throw new Exception(lang.GetWord("main08"));
        //        }

        //        if (GVar.appIsRunning)
        //        {
        //            using (System.Net.WebClient sendto = new System.Net.WebClient())
        //            {
        //                System.Collections.Specialized.NameValueCollection param = new System.Collections.Specialized.NameValueCollection();

        //                param.Add("hidden_IDEuroformulation", GVar.attivazioni.IDEuroFormulationInCloud);
        //                Assembly assembly = Assembly.GetExecutingAssembly();
        //                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
        //                param.Add("hidden_versionesw", fvi.FileVersion);
        //                param.Add("hidden_versioneDB", Library.Data.Database.DBStructureManager.VersioneDB.ToString());
        //                string hiddenLicenza = "";
        //                RegistryKey regKey = Registry.CurrentUser;
        //                regKey = regKey.OpenSubKey(@"Software\\EuroFormulations\\4");
        //                if (regKey != null)
        //                {
        //                    hiddenLicenza = regKey.GetValue("Key").ToString();
        //                }
        //                param.Add("hidden_licenza", hiddenLicenza);
        //                Library.Data.DBSettings settings = new Library.Data.DBSettings();
        //                param.Add("hidden_dbcode", settings.GetValue("dbcode"));
        //                //

        //                byte[] response_bytes = sendto.UploadValues("http://www.euroformulations.com/_remoteHTTPFunctions/hidden.php", "POST", param);
        //                string response_body = Encoding.ASCII.GetString(response_bytes);
        //                if (response_body != "ok" && System.Diagnostics.Debugger.IsAttached)
        //                {
        //                    MessageBox.Show("Header data error: " + response_body);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //non gestito
        //    }
        //    finally
        //    {
        //        //non gestito
        //    }
        //}
        #endregion
        /*
        #region UPLOAD LOG
        public static void UploadLogExecute()
        {
            try
            {
                Log log = Log.GetInstance();
                log.LogFTPCheckUpload();
            }
            catch (Exception) { }

        }
        #endregion
        */
        #region SYNCHRONIZE CLIENTI
        public static void SyncClientiExecute()
        {
            return;
            /*Library.Data.Sync.SyncBase syncClienti = null;
            try
            {
                syncClienti = new Library.Data.Sync.SyncBase();

                while (GVar.appIsRunning)
                {
                    int state = syncClienti.DoSync();
                    Thread.Sleep(5000);
                }
            }
            catch (Exception) { }
            finally
            {
                syncClienti.Close();
            }*/
        }
        #endregion

        #region UPDATE SOFTWARE THREAD & FUNCTIONS
        public void UpCheck_Thread()
        {
            try
            {
                if (!CheckForInternetConnection())
                {
                    throw new Exception(lang.GetWord("main08"));
                }

                //current version
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                string[] vNumvers = version.Split('.');
                if (vNumvers.Length < 4) throw new Exception("version lenght < 4");  //don't translate
                double versioneClient = GetVersion(Convert.ToInt32(vNumvers[1]), Convert.ToInt32(vNumvers[2]), Convert.ToInt32(vNumvers[3]));

                //remote version
                System.Net.WebClient versionReader = new System.Net.WebClient();
                System.Collections.Specialized.NameValueCollection param = new System.Collections.Specialized.NameValueCollection();
                param.Add("IDEuroformulation", GVar.attivazioni.IDEuroFormulationInCloud);
                byte[] response_bytes = versionReader.UploadValues("http://www.euroformulations.com/_remoteHTTPFunctions/ef4updaterVersion.php", "POST", param);
                sVersioneRemotaFull = Encoding.ASCII.GetString(response_bytes);
                if (sVersioneRemotaFull == "noupdate" || sVersioneRemotaFull == "") { return; } //non abilitato a ricevere aggiornamenti
                if (sVersioneRemotaFull.StartsWith("err")) { return; } //errore (da gestire). Il seguito rappresenta il codice errore
                string[] vRemoteNumvers = sVersioneRemotaFull.Split('.');
                if (vRemoteNumvers.Length < 4) throw new Exception("Remote version lenght < 4");
                double versioneRemota = GetVersion(Convert.ToInt32(vRemoteNumvers[1]), Convert.ToInt32(vRemoteNumvers[2]), Convert.ToInt32(vRemoteNumvers[3]));

                Library.IniFile conf = new Library.IniFile();
                if (versioneClient >= versioneRemota)
                {
                    if (conf.IniReadValue("UPDATE", "AdviseUpdated") == "1")
                    {
                        MessageBox.Show(lang.GetWord("main14"));
                        conf.IniWriteValue("UPDATE", "AdviseUpdated", "0");
                    }

                    return;
                }

                //ensure
                conf.IniWriteValue("UPDATE", "AdviseUpdated", "0");
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\update"))
                {
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\update");
                }

                //check if i already have last executable
                bool bEseguiDownload = false;
                if (!System.IO.File.Exists("update/setup_" + sVersioneRemotaFull + ".exe"))
                {
                    bEseguiDownload = true;
                }
                else
                {
                    string sFTPHost = "ftp://185.2.5.22";
                    string sFTPUser = "ef4update@euroformulations.com";
                    string sFTPPassword = "EUCftp!2";
                    string sFTPSetup = "/setup.exe";
                    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(sFTPHost + sFTPSetup));
                    request.Proxy = null;
                    request.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
                    request.Method = WebRequestMethods.Ftp.GetFileSize;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    long size = response.ContentLength;
                    response.Close();
                    FileInfo setup = new FileInfo("update/setup_" + sVersioneRemotaFull + ".exe");
                    if (setup.Length < size)
                    {
                        System.IO.File.Delete("update/setup_" + sVersioneRemotaFull + ".exe");
                        bEseguiDownload = true;
                    }
                }

                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                {
                    if (bEseguiDownload)
                    {
                        DialogResult dialogResult = MessageBox.Show(lang.GetWord("main16"), "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                if (tDownload != null) { return; }
                                tDownload = new Thread(() => ExeUpdate());
                                tDownload.IsBackground = true;
                                progressUpdate.Visible = true;
                                tDownload.Start();
                            }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show(lang.GetWord("main15"), "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            conf.IniWriteValue("UPDATE", "AdviseUpdated", "1");
                            SOFTWARE_UPDATE_PATH = "update/setup_" + sVersioneRemotaFull + ".exe";
                            enabledInstallUpdates = true;
                            this.Close();
                        }
                    }

                }));
            }
            catch (Exception ex)
            {
                //non gestita perchè o va tutto bene e segnalo variabile else exception: nessun aggiornamento
            }
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckForInternetConnection()
        {
            int desc;
            return InternetGetConnectedState(out desc, 0);
        }
        private double GetVersion(int functionVersion, int subFunctionVersion, int bugFixVersion)
        {
            double dVersion = 0;
            int[] data = new int[6];

            if (functionVersion > 9)
            {
                data[0] = functionVersion / 10;
                data[1] = functionVersion % 10;
            }
            else
            {
                data[0] = 0;
                data[1] = functionVersion;
            }
            if (subFunctionVersion > 9)
            {
                data[2] = subFunctionVersion / 10;
                data[3] = subFunctionVersion % 10;
            }
            else
            {
                data[2] = 0;
                data[3] = subFunctionVersion;
            }
            if (bugFixVersion > 9)
            {
                data[4] = bugFixVersion / 10;
                data[5] = bugFixVersion % 10;
            }
            else
            {
                data[4] = 0;
                data[5] = bugFixVersion;
            }

            int pos = 5;
            for (int i = 0; i < data.Length; i++)
            {
                int iv = data[i];
                dVersion += (iv * Math.Pow(10, pos));
                pos--;
            }

            return dVersion;
        }
        private void ExeUpdate()
        {
            string sFTPHost = "ftp://185.2.5.22";
            string sFTPUser = "ef4update@euroformulations.com";
            string sFTPPassword = "EUCftp!2";
            string sFTPSetup = "/setup.exe";

            //FILE SIZE
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sFTPHost + sFTPSetup);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
            request.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            int RemoteExeSize = (int)response.ContentLength;
            response.Close();

            //DOWNLOAD
            int bytesRead = 0;
            int totalBytesReaded = 0;
            byte[] buffer = new byte[2048];
            request = (FtpWebRequest)WebRequest.Create(sFTPHost + sFTPSetup);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
            Stream reader = request.GetResponse().GetResponseStream();
            FileStream fileStream = new FileStream("update/setup_" + sVersioneRemotaFull + ".exe", FileMode.Create);
            bool EOF = false;
            while (!EOF)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);
                totalBytesReaded += bytesRead;
                double percentuale = (100 * (double)totalBytesReaded) / (double)RemoteExeSize;
                int percentageDownload = (int)percentuale;
                if (percentageDownload < 0) { percentageDownload = 0; }
                if (percentageDownload > 100) { percentageDownload = 100; }
                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                {
                    progressUpdate.Value = percentageDownload;
                }));
                if (bytesRead != 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
                else
                {
                    EOF = true;
                }
            }
            fileStream.Close();

            //request to user
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
            {
                progressUpdate.Value = 0;
                progressUpdate.Visible = false;
                DialogResult dialogResult = MessageBox.Show(lang.GetWord("main15"), "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Library.IniFile conf = new Library.IniFile();
                    conf.IniWriteValue("UPDATE", "AdviseUpdated", "1");
                    SOFTWARE_UPDATE_PATH = "update/setup_" + sVersioneRemotaFull + ".exe";
                    enabledInstallUpdates = true;
                    this.Close();
                }
            }));
        }
        #endregion

        #region LOAD FORMULE THREAD
        public void AsynchFormuleLoader()
        {
            try
            {
                GVar.lstColoriFull.Clear();
                GVar.dicProducts.Clear();
                GVar.dicColorcharts.Clear();

                Dictionary<string, int> dicProdottiConstructor = new Dictionary<string, int>();
                Dictionary<string, int> dicCartelleConstructor = new Dictionary<string, int>();
                int iProdotto = 0, iCartellacolori = 0;

                DataTable dt = dbThread_loadFormule.SQLQuerySelect("SELECT * FROM formule"); //TODO limit 300sec, rif. dbc.sqlview_ErrorSafe_Timeout("SELECT * FROM formule", ref risultatiole, 300);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            string nomeProdotto = dr["system"].ToString();
                            string nomeCartella = dr["colorcharts"].ToString();

                            if (!dicProdottiConstructor.ContainsKey(nomeProdotto))
                            {
                                dicProdottiConstructor.Add(nomeProdotto, iProdotto);
                                iProdotto++;
                            }
                            if (!dicCartelleConstructor.ContainsKey(nomeCartella))
                            {
                                dicCartelleConstructor.Add(nomeCartella, iCartellacolori);
                                iCartellacolori++;
                            }

                            bool bInterior = true;
                            if (dr["use"].ToString().Trim() == "EXTERIOR")
                            {
                                bInterior = false;
                            }

                            double[] cielab_cubecc = null;
                            if (dr["ciel_cubecc"].ToString().Trim() != "")
                            {
                                cielab_cubecc = new double[3];
                                cielab_cubecc[0] = Convert.ToDouble(dr["ciel_cubecc"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                                cielab_cubecc[1] = Convert.ToDouble(dr["ciea_cubecc"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                                cielab_cubecc[2] = Convert.ToDouble(dr["cieb_cubecc"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
                            }

                            string sDE = dr["de"].ToString();
                            if (sDE.Trim() == "") { sDE = "0"; }

                            Colore c = new Colore(Convert.ToInt32(dr["id"].ToString()), dr["colorname"].ToString(), bInterior, Convert.ToDouble(dr["ciel"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(dr["ciea"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(dr["cieb"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(dr["r"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(dr["g"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(dr["b"].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), dicProdottiConstructor[nomeProdotto], dicCartelleConstructor[nomeCartella], cielab_cubecc, Convert.ToDouble(sDE.Replace(',', '.'), CultureInfo.InvariantCulture));
                            Library.GVar.lstColoriFull.Add(c);
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }
                    if (GVar.appIsRunning)
                    {
                        foreach (KeyValuePair<string, int> pair in dicProdottiConstructor)
                        {
                            GVar.dicProducts.Add(pair.Value, pair.Key);
                        }
                    }
                    if (GVar.appIsRunning)
                    {
                        foreach (KeyValuePair<string, int> pair in dicCartelleConstructor)
                        {
                            GVar.dicColorcharts.Add(pair.Value, pair.Key);
                        }
                    }

                    if (GVar.appIsRunning)
                    {
                        Library.GVar.bLoadFormuleEnded = true;
                        menu.LoadForSearchCompleted();
                    }
                }
                else
                {
                    if (GVar.appIsRunning)
                    {
                        System.Windows.Forms.MessageBox.Show(dbThread_loadFormule.LastQueryError);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region UPDATE ARCHIVIO
        private void AsynchArchiveUpdater()
        {
            /*  RUN ONLY 1 TIME DURING EXECUTION (note: deve funzionare anche al primo avvio)
               1) recupera dal server una serie di <IDArchivio; Nome; dtLastUpdate>
             * 2) recupero lista locale <IDArchivio; dbrealname>
             * 3) per ogni riga dal server trova: <lista db da inserire; lista db da aggiornare>
             * 4) comunicazione aggiornamenti disponibili:procedere? Se no: return;
             * 5) salva su file la lista di database
             * 6) chiusura EF4 e avvio programma di aggiornamento DB (passa come parametro il path al file dati)
             */

            /*
             PROGRAMMA DI AGGIORNAMENTO DB
             * 1) controlla che EF4 si sia arrestato (oltre X secondi andare in timeout comunicando errore)
             * 2) carica le info ricevute su file;
             * 3) per ogni db in lista:
             * {
             *      4) scarica db
             *      5) processa db
             * }
             * 6) al termine libera risorse e avvia EF4
             */
        }
        #endregion

        #region LOAD SOFTWARE
        public void AsyncSoftwareLoad()
        {
            try
            {
                frmLoader.ImageSfondo = imageWelcome;
                frmLoader.Show();

                while (!bLoadingStop)
                {
                    Thread.Sleep(1);
                    Application.DoEvents();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region ORDER RECEIVER
        private void EmailReceiver()
        {
            //References: https://github.com/smiley22/S22.Imap

            #region parametri di connessione
            string sServer = "", saddress = "", sPassword = "";
            int port = -1;
            bool ssl = false;
            try
            {

                string[] emailLines = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + @"\\email.txt");
                foreach (string emailLine in emailLines)
                {
                    string[] items = emailLine.Split('=');
                    switch (items[0].Trim())
                    {
                        case "server":
                            {
                                sServer = items[1].Trim();
                                break;
                            }
                        case "port":
                            {
                                port = Convert.ToInt32(items[1].Trim());
                                break;
                            }
                        case "address":
                            {
                                saddress = items[1].Trim();
                                break;
                            }
                        case "password":
                            {
                                sPassword = items[1].Trim();
                                break;
                            }
                        case "ssl":
                            {
                                ssl = items[1].Trim() == "1";
                                break;
                            }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Email params error. Please check your email config file.");
                return;
            }
            #endregion

            while (GVar.appIsRunning)
            {
                ImapClient client = null;
                try
                {
                    client = new ImapClient(sServer, port, saddress, sPassword, AuthMethod.Login, ssl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }


                IEnumerable<uint> uids = client.Search(SearchCondition.Unseen());
                foreach (uint uid in uids)
                {
                    MailMessage message = client.GetMessage(uid, FetchOptions.HeadersOnly);
                    if (!message.Subject.Contains("[#EF4]"))
                    {
                        client.RemoveMessageFlags(uid, null, MessageFlag.Seen);
                    }
                    else
                    {
                        message = client.GetMessage(uid);

                        try
                        {
                            Library.Email email = new Email();
                            email.Mittente = message.From.Address;
                            email.Oggetto = message.Subject;
                            email.Corpo = message.Body;
                            email.DataOra = DateTime.Now;
                            DateTime? dtnullable = MailMessageExtension.Date(message);
                            if (dtnullable != null) { email.DataOra = dtnullable.Value; }

                            #region ALLEGATI (ORDINI)
                            foreach (System.Net.Mail.Attachment allegato in message.Attachments)
                            {
                                if (allegato.Name.EndsWith(".txt"))
                                {
                                    StreamReader reader = new StreamReader(allegato.ContentStream);
                                    string sData = reader.ReadToEnd();
                                    reader.Close();

                                    int iEnd = sData.IndexOf("\n@END");
                                    while (iEnd != -1)
                                    {
                                        string sOrdine = sData.Substring(0, iEnd);

                                        Library.Ordine ordine = new Ordine();
                                        string[] items = sOrdine.Split('\n');
                                        foreach (string item in items)
                                        {
                                            if (item.StartsWith("@IDC"))
                                            {
                                                ordine.CodCard = item.Substring(4).Trim();
                                            }
                                            else if (item.StartsWith("@PRD"))
                                            {
                                                string prd = item.Substring(4).Trim().Replace(@"""", "");
                                                ordine.Prodotto = prd;
                                            }
                                            else if (item.StartsWith("@CLR"))
                                            {
                                                string sClr = "";

                                                sClr = item.Substring(4).Trim().Replace(@"""", "");
                                                string[] vClr = sClr.Split('|');
                                                if (vClr.Length == 2)
                                                {
                                                    ordine.Destinazione = vClr[0];
                                                    ordine.Uso = vClr[1].ToUpper();
                                                }
                                                else
                                                {
                                                    ordine.Tinta = vClr[0]; ;
                                                    ordine.CColori = vClr[1];
                                                    ordine.Destinazione = vClr[2];
                                                    ordine.Uso = vClr[3].ToUpper();
                                                }
                                            }
                                            else if (item.StartsWith("@LAB"))
                                            {
                                                string[] vLab = item.Substring(4).Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                                ordine.CIEL = Convert.ToDouble(vLab[0].Replace(",", "."), CultureInfo.InvariantCulture);
                                                ordine.CIEa = Convert.ToDouble(vLab[1].Replace(",", "."), CultureInfo.InvariantCulture);
                                                ordine.CIEb = Convert.ToDouble(vLab[2].Replace(",", "."), CultureInfo.InvariantCulture);
                                            }
                                        }
                                        if ((iEnd + 5) < (sData.Length - 1))
                                        {
                                            sData = sData.Substring(iEnd + 5);
                                        }
                                        else
                                        {
                                            sData = "";
                                        }
                                        iEnd = sData.IndexOf("\n@END");

                                        email.Ordini.Add(ordine);
                                    }
                                }
                            }
                            #endregion

                            email.Save();
                        }
                        catch (Exception) { client.RemoveMessageFlags(uid, null, MessageFlag.Seen); }
                    }
                }

                client.Dispose();
                Thread.Sleep(5000);
            }
        }
        #endregion

        #region ACTION MENU
        public void KeyChanged(string key)
        {
            switch (key)
            {
                case "formulaclassic":
                    {
                        ActionExecute_InitFormulazione(1);
                        break;
                    }
                case "formulasearch":
                    {
                        ActionExecute_FormulaSearch();
                        break;
                    }
                case "formulahistory":
                    {
                        ActionExecute_History();
                        break;
                    }

                case "ricercacolore":
                    {
                        ActionExecute_RicercaColore();
                        break;
                    }
                case "statCol":
                    {
                        ActionExecute_StatisticheColoranti();
                        break;
                    }
                case "statBasi":
                    {
                        ActionExecute_StatisticheBasi();
                        break;
                    }
                case "statSpace":
                    {
                        ActionExecute_StatisticheSpazioColore();
                        break;
                    }
                case "impostazioni":
                    {
                        ActionExecute_ImpostazioniGenerali();
                        break;
                    }
                case "qualita":
                    {
                        ActionExecute_Qualita();
                        break;
                    }
                case "nuovaformula":
                    {
                        ActionExecute_NewFormulaPersonale(null, false, true, -1, FormulePersonal.ePage.formule_personali);
                        break;
                    }
                case "nuovocliente":
                    {
                        ActionExecute_NuovoCliente();
                        break;
                    }
                case "viewclient":
                    {
                        ActionExecute_ViewClient();
                        break;
                    }
                case "viewformula":
                    {
                        ActionExecute_ViewFormulaPersonale();
                        break;
                    }
                case "listini":
                    {
                        ActionExecute_Listini();
                        break;
                    }
                case "colorantcost":
                    {
                        ActionExecute_CostoColoranti();
                        break;
                    }
                case "lattaggi":
                    {
                        ActionExecute_Lattaggi();
                        break;
                    }
                case "ecadmin":
                    {
                        ActionExecute_ECAdmin();
                        break;
                    }
                case "dispositivi":
                    {
                        ActionExecute_Dispositivi();
                        break;
                    }
                case "macchine":
                    {
                        ActionExecute_Macchine();
                        break;
                    }
                case "database":
                    {
                        ActionExecute_Database();
                        break;
                    }
                case "orders":
                    {
                        ActionExecute_Orders();
                        break;
                    }
                case "eroga":
                    {
                        ActionExecute_Dispense();
                        break;
                    }
            }
        }
        private void ActionExecute_Formulazione(int IDFormula = -1, bool closeForm = true, FormulaSelection.frmFormula.ePage prevForm = FormulaSelection.frmFormula.ePage.formula_selection, int tabSelection = 0)
        {
            if (currentForm != null)
            {
                if (closeForm)
                {
                    if (currentForm.GetType().Name == "frmFormula") { ((SubWindows.FormulaSelection.frmFormula)currentForm).PageTo = FormulaSelection.frmFormula.ePage.anywhere; }
                    currentForm.Close();
                }
            }
            if (IDFormula == -1 && prevForm == FormulaSelection.frmFormula.ePage.formula_selection)
            {
                currentForm = new SubWindows.FormulaSelection.frmFormula();
            }
            else
            {
                currentForm = new SubWindows.FormulaSelection.frmFormula(IDFormula, prevForm);
            }

            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.FormClosed += new FormClosedEventHandler(Formulazione_closed);
            currentForm.Show();
        }
        private void ActionExecute_InitFormulazione(int iTabSelected)
        {
            ActionExecute_Formulazione(-1, true, SubWindows.FormulaSelection.frmFormula.ePage.formula_selection, iTabSelected);
        }
        private void ActionExecute_FormulaSearch()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.FormulaSelection.frmFormulaSearch();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(FormulaSearch_Closed);
        }
        private void ActionExecute_History()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.FormulaSelection.frmHistory();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(History_Closed);
        }
        private void ActionExecute_RicercaColore()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.ColorSearch.frmRicercaColore();
            ((SubWindows.ColorSearch.frmRicercaColore)currentForm).SetMenu = menu;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(RicercaColore_Closed);
        }
        private void ActionExecute_StatisticheColoranti()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Statistiche.frmStatCol();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_StatisticheBasi()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Statistiche.frmStatBasi();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_StatisticheSpazioColore()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Statistiche.frmStatSpace();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Listini()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Costi.frmListini();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_CostoColoranti()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Costi.frmColBase();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Lattaggi()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Costi.frmLattaggi();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_ImpostazioniGenerali()
        {
            if (!bSettingsEnabled && !System.Diagnostics.Debugger.IsAttached)
            {
                SubWindows.Amministrazione.frmPassword frmPass = new SubWindows.Amministrazione.frmPassword(Amministrazione.frmPassword.eRequestType.settings);
                frmPass.StartPosition = FormStartPosition.Manual;
                frmPass.Location = new Point(GVar.AppLocation_X + 245, GVar.AppLocation_Y + 465);
                frmPass.ShowDialog();
                bSettingsEnabled = frmPass.AdminEnabled;
                if (!bSettingsEnabled) { return; }
            }
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Settings.frmImpostazioniGenerali();
            ((SubWindows.Settings.frmImpostazioniGenerali)currentForm).MAIN_FORM = this;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Qualita()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Qualita.frmQualita();
            ((SubWindows.Qualita.frmQualita)currentForm).SetMenu = menu;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_NewFormulaPersonale(Library.Formulation.Formula formula, bool bEditAsOunce, bool bCloseForm, int idcustomer, FormulePersonal.ePage pageTo)
        {
            if (currentForm != null)
            {
                if (bCloseForm) { currentForm.Close(); }
            }
            SubWindows.FormulePersonal.frmFormulaPersonale frmPersonale = new SubWindows.FormulePersonal.frmFormulaPersonale(formula, pageTo);
            if (idcustomer != -1) { frmPersonale.PreSelected_IDCustomer = idcustomer; }
            frmPersonale.EditAsOunce = bEditAsOunce;
            currentForm = frmPersonale;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(NewFormula_Closed);
        }
        private void ActionExecute_ViewFormulaPersonale(bool bAlreadyClosed = false, int selectedFormula = -1)
        {
            if (currentForm != null && !bAlreadyClosed)
            {
                currentForm.Close();
            }
            SubWindows.FormulePersonal.frmVisualizzaPersonale form = new SubWindows.FormulePersonal.frmVisualizzaPersonale();
            form.SelectedFormulaLoad = selectedFormula;
            currentForm = form;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(FormulazionePersonale_Closed);
        }
        private void ActionExecute_NuovoCliente(bool closeform = true, int idcliente = -1)
        {
            if (currentForm != null)
            {
                if (closeform) currentForm.Close();
            }
            if (idcliente == -1)
            {
                currentForm = new SubWindows.Clienti.frmClienteEdit();
            }
            else
            {
                currentForm = new SubWindows.Clienti.frmClienteEdit(idcliente);
            }
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(NuovoCliente_Closed);
        }
        private void ActionExecute_ViewClient(bool bAlreadyClosed = false)
        {
            if (currentForm != null && !bAlreadyClosed)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Clienti.frmVisualizzaCliente();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(VisualizzaCliente_Closed);
        }
        
        private void ActionExecute_Welcome()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            frmWelcome welcome = new frmWelcome();
            welcome.ImageSfondo = imageSfondo;
            currentForm = welcome;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_ECAdmin()
        {
            if (!bAdminEnabled && !System.Diagnostics.Debugger.IsAttached)
            {
                SubWindows.Amministrazione.frmPassword frmPass = new SubWindows.Amministrazione.frmPassword(Amministrazione.frmPassword.eRequestType.eurocolori_admin);
                frmPass.StartPosition = FormStartPosition.Manual;
                frmPass.Location = new Point(GVar.AppLocation_X + 245, GVar.AppLocation_Y + 465);
                frmPass.ShowDialog();
                bAdminEnabled = frmPass.AdminEnabled;
                if (!bAdminEnabled) { return; }
            }
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = new SubWindows.Amministrazione.frmECAdmin();
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Dispositivi()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            SubWindows.Settings.frmDispositivi frmDevice = new SubWindows.Settings.frmDispositivi();
            frmDevice.MAIN_FORM = this;
            currentForm = frmDevice;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Macchine()
        {
            if (!bSettingsEnabled && !System.Diagnostics.Debugger.IsAttached)
            {
                SubWindows.Amministrazione.frmPassword frmPass = new SubWindows.Amministrazione.frmPassword(Amministrazione.frmPassword.eRequestType.settings);
                frmPass.StartPosition = FormStartPosition.Manual;
                frmPass.Location = new Point(GVar.AppLocation_X + 245, GVar.AppLocation_Y + 465);
                frmPass.ShowDialog();
                bSettingsEnabled = frmPass.AdminEnabled;
                if (!bSettingsEnabled) { return; }
            }
            if (currentForm != null)
            {
                currentForm.Close();
            }
            SubWindows.Settings.frmMachine frmMacchine = new SubWindows.Settings.frmMachine();
            frmMacchine.MAIN_FORM = this;
            currentForm = frmMacchine;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Database()
        {
            if (!bSettingsEnabled && !System.Diagnostics.Debugger.IsAttached)
            {
                SubWindows.Amministrazione.frmPassword frmPass = new SubWindows.Amministrazione.frmPassword(Amministrazione.frmPassword.eRequestType.settings);
                frmPass.StartPosition = FormStartPosition.Manual;
                frmPass.Location = new Point(GVar.AppLocation_X + 245, GVar.AppLocation_Y + 465);
                frmPass.ShowDialog();
                bSettingsEnabled = frmPass.AdminEnabled;
                if (!bSettingsEnabled) { return; }
            }
            if (currentForm != null)
            {
                currentForm.Close();
            }
            SubWindows.Settings.frmDatabase frmDb = new Settings.frmDatabase();
            frmDb.MainForm = this;
            currentForm = frmDb;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        private void ActionExecute_Orders()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            SubWindows.FormulaSelection.frmOrders ordini = new FormulaSelection.frmOrders();
            currentForm = ordini;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
            currentForm.FormClosed += new FormClosedEventHandler(Ordini_Closed);
        }
        private void ActionExecute_Dispense()
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            SubWindows.ErogazioneLibera.frmFreeDispenser eroga = new ErogazioneLibera.frmFreeDispenser();
            currentForm = eroga;
            currentForm.TopLevel = false;
            currentForm.MdiParent = this;
            currentForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.Show();
        }
        #endregion

        #region MENU BUTTON EVENT HANDLER
        void FormulazionePersonale_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IdNuovaFormula = ((SubWindows.FormulePersonal.frmVisualizzaPersonale)currentForm).REQUEST_IDFormula;
                string sDoveFormula = ((SubWindows.FormulePersonal.frmVisualizzaPersonale)currentForm).REQUEST_DvSono;

                if (IdNuovaFormula == -1 && sDoveFormula == "NULL") { return; } // close for reopen that window

                if (IdNuovaFormula != -1 && sDoveFormula == "DBCLICK")
                {
                    menu.SelectedButton("formulaclassic", false);
                    ActionExecute_Formulazione(IdNuovaFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.formula_personale, 1);
                }
                else
                {
                    menu.SelectedButton("nuovaformula", false);
                    ActionExecute_NewFormulaPersonale(Library.Formulation.Formula.InitFormula_From_formulePersonali(IdNuovaFormula), false, false, -1, FormulePersonal.ePage.view_formule_personali);
                }
            }
        }
        void RicercaColore_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IDFormula = ((SubWindows.ColorSearch.frmRicercaColore)currentForm).REQUEST_IDFormula;
                if (IDFormula != -1)
                {
                    menu.SelectedButton("formulaclassic", false);
                    ActionExecute_Formulazione(IDFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.color_search, 1);
                }
            }
        }
        void NewFormula_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                bool bGoViewFormula = ((SubWindows.FormulePersonal.frmFormulaPersonale)currentForm).GoViewSavedFormula;
                if (bGoViewFormula)
                {
                    int IDFormulaShow = ((SubWindows.FormulePersonal.frmFormulaPersonale)currentForm).IDFormulaPersonaleView;
                    menu.SelectedButton("viewformula", false);
                    ActionExecute_ViewFormulaPersonale(true, IDFormulaShow);
                }
            }
        }
        void NuovoCliente_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                SubWindows.Clienti.frmClienteEdit frmEdit = (SubWindows.Clienti.frmClienteEdit)currentForm;
                switch (frmEdit.PageTo)
                {
                    case Clienti.frmClienteEdit.ePage.view_client:
                        {
                            menu.SelectedButton("viewclient", false);
                            ActionExecute_ViewClient(true);
                            break;
                        }
                    case Clienti.frmClienteEdit.ePage.formula_from_history:
                        {
                            int IDFormula = frmEdit.REQUEST_IDFormula;
                            if (IDFormula != -1)
                            {
                                menu.SelectedButton("formulaclassic", false);
                                ActionExecute_Formulazione(IDFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.history, 1);
                            }
                            break;
                        }
                    case Clienti.frmClienteEdit.ePage.formula_from_personali:
                        {
                            int IDFormula = frmEdit.REQUEST_IDFormula;
                            if (IDFormula != -1)
                            {
                                menu.SelectedButton("formulaclassic", false);
                                ActionExecute_Formulazione(IDFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.formula_personale, 1);
                            }
                            break;
                        }
                }
            }
        }
        void VisualizzaCliente_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IDCliente = ((SubWindows.Clienti.frmVisualizzaCliente)currentForm).REQUEST_IDCliente;
                if (IDCliente != -1)
                {
                    menu.SelectedButton("nuovocliente", false);
                    ActionExecute_NuovoCliente(false, IDCliente);
                }
            }
        }
        void Formulazione_closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                SubWindows.FormulaSelection.frmFormula currentSelection = (SubWindows.FormulaSelection.frmFormula)currentForm;
                FormulaSelection.frmFormula.ePage pageTo = currentSelection.PageTo;
                if (pageTo == FormulaSelection.frmFormula.ePage.formula_personale)
                {
                    Library.Formulation.Formula formula = currentSelection.CurrentFormula;
                    bool bEditInOunce = currentSelection.EditFormulaMLAsOunce;
                    int idcustomer = currentSelection.IDCustomer;
                    ActionExecute_NewFormulaPersonale(formula, bEditInOunce, false, idcustomer, FormulePersonal.ePage.formula_selection);
                }
            }
        }
        void History_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IDHistory = ((SubWindows.FormulaSelection.frmHistory)currentForm).IDHistory;
                if (IDHistory != -1)
                {
                    menu.SelectedButton("formulaclassic", false);
                    ActionExecute_Formulazione(IDHistory, false, SubWindows.FormulaSelection.frmFormula.ePage.history, 1);
                }
            }
        }
        void FormulaSearch_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IDFormula = ((SubWindows.FormulaSelection.frmFormulaSearch)currentForm).IDFormulaSelected;
                if (IDFormula != -1)
                {
                    menu.SelectedButton("formulaclassic", false);
                    ActionExecute_Formulazione(IDFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.color_search, 1);
                }
            }
        }
        void Ordini_Closed(object sender, FormClosedEventArgs e)
        {
            if (GVar.appIsRunning)
            {
                int IDFormula = ((SubWindows.FormulaSelection.frmOrders)currentForm).Request_IDFormula;
                if (IDFormula != -1)
                {
                    menu.SelectedButton("formulaclassic", false);
                    ActionExecute_Formulazione(IDFormula, false, SubWindows.FormulaSelection.frmFormula.ePage.color_search, 1);
                }
            }
        }
        #endregion

        private void frmEuroFormulationsNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                GVar.appIsRunning = false;
                Library.Data.Dispositivi.DispositiviManager.CloseService();
                Library.Formulation.Formula.bForceReloadStaticDic = true;

                //update settings
                Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
                settings.SetValue("dtLastAppClosed", DateTime.Now.ToString());

                if (settings.GetValue("ModeSave") == "YES")
                {
                    string WindowMaximized = "0";
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        WindowMaximized = "1";
                    }
                    settings.SetValue("WindowMaximized", WindowMaximized);

                    if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                    {
                        settings.SetValue("PosX", this.Location.X.ToString());
                        settings.SetValue("PosY", this.Location.Y.ToString());
                        settings.SetValue("Width", this.Size.Width.ToString());
                        settings.SetValue("Height", this.Size.Height.ToString());
                    }
                }

                if (!settings.Save())
                {
                    throw new Exception(lang.GetWord("main09") + ": " + settings.ErrorSave);
                }

                dbSettings.Save();

                db.CloseConnection();

                if (dbThread_loadFormule != null) { dbThread_loadFormule.CloseConnection(); }
                if (dbThread_Cloud != null) { dbThread_Cloud.CloseConnection(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (SOFTWARE_UPDATE_PATH != "" && enabledInstallUpdates)
                {
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = Application.StartupPath + "/" + SOFTWARE_UPDATE_PATH;
                    /*start.CreateNoWindow = true;
                    start.UseShellExecute = false;
                    start.WindowStyle = ProcessWindowStyle.Hidden;
                    start.UseShellExecute = false;
                    start.RedirectStandardOutput = true;*/
                    Process updater = Process.Start(start);
                }

            }
            catch (Exception) { }
        }

        public bool EnableMenuPanel
        {
            set
            {
                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                {
                    menuPanel.Visible = !value;
                }));

            }
        }

        public bool RebootNow
        {
            set
            {
                disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate ()
                {
                    bRebootRequest = value;
                    if (bRebootRequest) this.Close();
                }));
            }
            get
            {
                return bRebootRequest;
            }
        }

        public void Menu_suspendLayout()
        {
            // menuPanel.SuspendLayout();
        }

        public void Menu_ResumeLayout()
        {
            // menuPanel.ResumeLayout();
        }

        private void frmEuroFormulationsNew_Shown(object sender, EventArgs e)
        {
            //DEMO message (days left)
            if (this.oDayLeft != null)
            {
                
                if ((int)this.oDayLeft <= 30)  
                {
                    MessageBox.Show(lang.GetWord("program08") + " (" + (int)this.oDayLeft + " " + lang.GetWord("program05") + "). " + lang.GetWord("program07"));
                }
               
                else
                {
                    /*
                    if ((int)this.oDayLeft <= 15) //normal key: notifica da -15 giorni in giu
                    {
                        MessageBox.Show(lang.GetWord("program04") + " (" + (int)this.oDayLeft + " " + lang.GetWord("program05") + "). " + lang.GetWord("program06"));
                    }
                     * */
                }
            }

            //ControlloSoftwareAggiornato();  //DEPRECATED: le news dal 03/10/2016 sono inviate via email
        }
        

        private void pbArea_Paint(object sender, PaintEventArgs e)
        {
            Image img;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            if (imageLogo != null)
            {
                //personalizzato
                img = ResizeImage(imageLogo, pbArea.Width, pbArea.Height);
                e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            else
            {
                //standard ef4
                img = ResizeImage(Properties.Resources.logo_euroformulations4, pbArea.Width, 69);
                e.Graphics.DrawImage(img, 10, 10, img.Width, img.Height);
            }
        }

        private Image ResizeImage(Image img, double maxWidth, double maxHeight)
        {
            double resizeWidth = img.Width;
            double resizeHeight = img.Height;

            double aspect = resizeWidth / resizeHeight;

            if (resizeWidth > maxWidth)
            {
                resizeWidth = maxWidth;
                resizeHeight = resizeWidth / aspect;
            }
            if (resizeHeight > maxHeight)
            {
                aspect = resizeWidth / resizeHeight;
                resizeHeight = maxHeight;
                resizeWidth = resizeHeight * aspect;
            }
            return (Image)(new Bitmap(img, new Size((int)resizeWidth, (int)resizeHeight)));
        }

        private void frmEuroFormulationsNew_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                GVar.AppLocation_X = this.Location.X;
                GVar.AppLocation_Y = this.Location.Y;
            }
            catch (Exception)
            {
                GVar.AppLocation_X = 0;
                GVar.AppLocation_Y = 0;
            }
        }

    }
}
