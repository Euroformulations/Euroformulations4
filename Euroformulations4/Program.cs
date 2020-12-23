using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using System.Diagnostics;
using System.ServiceProcess;
using System.Net;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Threading;


namespace Euroformulations4
{
    static class Program
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private static SubWindows.WindowMain.frmDBUpdater frmDBUpd = null;
        private static bool bLoadingStop = false;

        /// <summary>
        /// The main entry point for the application
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                #region PARAMS
                bool bAdminMode = false;
                #endregion

                //verifica processo singolo
                if (IsProcessOpened("Euroformulations4"))
                {
                    throw new Exception(lang.GetWord("program03"));
                }

                Library.IniFile conf = new Library.IniFile();
                string database = conf.IniReadValue("DATABASE", "ActiveDB");
                string sPort = conf.IniReadValue("DATABASE", "StaticPort").Trim();
                string sDebug = conf.IniReadValue("DATABASE", "Debug").Trim();
                if (sPort == "49999") { throw new Exception("Please don't use port 49999 for connection"); }

                Library.Data.Database.ClusterGenerator clustergen;
                bool bDebug = false;


                if (!bDebug)
                {
                    //UPDATE EUROSQL -> CLUSTER
                    bool bInitedCluster = false;
                    RegistryKey regKey = Registry.CurrentUser;
                    regKey = regKey.OpenSubKey(@"Software\\EuroFormulations\\cluster");
                    if (regKey != null)
                    {
                        if (regKey.GetValue("ClusterSet").ToString().Trim() == "1") { bInitedCluster = true; }
                        regKey.Close();
                    }

                    if (!bInitedCluster) { InitPostGreSQL(database.Trim() == "", sPort); }

                    //connect to CLUSTER
                    clustergen = Library.Data.Database.ClusterGenerator.GetInstance();
                    if (bInitedCluster)
                    {
                        if (sPort == "") { throw new Exception("missing port number in EF config file (use -1 for dynamic)"); }
                        if (sPort != "-1")
                        {
                            clustergen.Port = Convert.ToInt32(sPort);
                        }
                    }
                    clustergen.StopProcess();
                    string res = clustergen.StartProcess();
                }
                else
                {
                    clustergen = Library.Data.Database.ClusterGenerator.GetInstance();
                    clustergen.Port = 5432;
                }

                bool bShowDemoWindow = true;

                if (System.IO.File.Exists(Application.StartupPath + "\\auto_password.txt"))
                {
                    SubWindows.WindowMain.frmAutoInstaller frmAutoInstall = new SubWindows.WindowMain.frmAutoInstaller(sPort);
                    Application.Run(frmAutoInstall);
                    database = conf.IniReadValue("DATABASE", "ActiveDB");

                    if (File.Exists(Application.StartupPath + "\\auto_password_old.txt"))
                        File.Delete(Application.StartupPath + "\\auto_password_old.txt");
                    System.IO.File.Move(Application.StartupPath + "\\auto_password.txt", Application.StartupPath + "\\auto_password_old.txt");


                    if (System.IO.File.Exists(Application.StartupPath + "\\auto_db.zip"))
                    {
                        if (System.IO.File.Exists(Application.StartupPath + "\\auto_db_old.zip"))
                            File.Delete(Application.StartupPath + "\\auto_db_old.zip");
                        System.IO.File.Move(Application.StartupPath + "\\auto_db.zip", Application.StartupPath + "\\auto_db_old.zip");
                    }
                    bShowDemoWindow = false;
                }

                //start EF Window
                bool bStartEnabled = true;
                if (database.Trim() == "")
                {
                    SubWindows.WindowMain.frmDBImport importDB = new SubWindows.WindowMain.frmDBImport();
                    Application.Run(importDB);
                    bStartEnabled = importDB.ReadyOpenEuroFormulations;
                }
                while (bStartEnabled)
                {
                    SubWindows.WindowMain.frmEuroFormulationsNew frmMain = new SubWindows.WindowMain.frmEuroFormulationsNew(bAdminMode);
                    Application.Run(frmMain);
                    bStartEnabled = frmMain.RebootNow;
                    Library.GVar.Flush();
                }

                if (!bDebug) { clustergen.StopProcess(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DeleteTempData();
        }
        private static bool IsProcessOpened(string name)
        {
            int N_instances = 0;
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    N_instances++;
                    if (N_instances > 1) { return true; }
                }
            }
            return false;
        }
        private static bool IsEuroSQLInstalled()
        {
            // get list of Windows services
            ServiceController[] services = ServiceController.GetServices();

            // try to find service name
            foreach (ServiceController service in services)
            {
                if (service.ServiceName == "EuroSQL")
                    return true;
            }
            return false;
        }
        private static void AsyncDBUpdate()
        {
            try
            {
                frmDBUpd.Show();
                Application.DoEvents();
                int i = 0;
                while (!bLoadingStop)
                {
                    frmDBUpd.SetPoint(i);
                    i++;
                    Thread.Sleep(700);
                    Application.DoEvents();
                }

                frmDBUpd.Close();
            }
            catch (Exception) { }
        }
        private static void InitPostGreSQL(bool bInit, string sPort)
        {
            if (bInit)
            {
                Thread t = new Thread(new ThreadStart(AsyncDBUpdate));
                t.IsBackground = true;
                t.Start();

                string sResult = "0";
                if (System.IO.Directory.Exists(Application.StartupPath + @"\cluster")
                    && Directory.GetFiles(Application.StartupPath + @"\cluster", "*.txt").Length > 0)
                {
                    //called with updater
                    Library.Data.Database.ClusterGenerator.WriteClusterSet();
                }
                else
                {
                    if (System.IO.Directory.Exists(Application.StartupPath + @"\cluster"))
                    {
                        System.IO.Directory.Delete(Application.StartupPath + @"\cluster");
                    }
                    sResult = Library.Data.Database.ClusterGenerator.InitializeData();
                }

                bLoadingStop = true;
                while (t.IsAlive) { Thread.Sleep(10); }

                if (sResult != "0") { throw new Exception("Database init error: " + sResult); }
            }
            else
            {
                if (!IsEuroSQLInstalled()) { throw new Exception("EuroSQL service not found."); }
                if (System.IO.Directory.Exists(Application.StartupPath + @"\cluster"))
                {
                    System.IO.Directory.Delete(Application.StartupPath + @"\cluster");
                }
                frmDBUpd = new SubWindows.WindowMain.frmDBUpdater();
                Thread t = new Thread(new ThreadStart(AsyncDBUpdate));
                t.IsBackground = true;
                t.Start();
                string sResult = Library.Data.Database.ClusterGenerator.UpdateDataFromEuroSQL();
                bLoadingStop = true;
                while (t.IsAlive) { Thread.Sleep(10); }
                if (sResult != "0") { throw new Exception("Database update error: " + sResult); }
            }

            Library.Data.Database.ClusterGenerator clustergen = Library.Data.Database.ClusterGenerator.GetInstance();
        }
        private static void DeleteTempData()
        {
            try
            {
                string pathFormule = System.IO.Path.GetTempPath() + "formule.sql";
                string pathBasi = System.IO.Path.GetTempPath() + "base.sql";
                string pathPigmenti = System.IO.Path.GetTempPath() + "pigmenti.sql";
                string pathInfo = System.IO.Path.GetTempPath() + "info.txt";
                if (System.IO.File.Exists(pathFormule)) { System.IO.File.Delete(pathFormule); }
                if (System.IO.File.Exists(pathBasi)) { System.IO.File.Delete(pathBasi); }
                if (System.IO.File.Exists(pathPigmenti)) { System.IO.File.Delete(pathPigmenti); }
                if (System.IO.File.Exists(pathInfo)) { System.IO.File.Delete(pathInfo); }
            }
            catch (Exception) { }
        }
    }
}
