using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using Ionic.Zip;
using Microsoft.Win32;

namespace Euroformulations4.Library.Data.Database
{
    class ClusterGenerator
    {
        private static ClusterGenerator cluster = null;
        private static bool bCurrentEuroSQL = false;
        private static string sqlfolder;
        private int port;
        private static string sCreateClusterError = "";
        private string sStartProcessError = "";
        private string sStopProcessError = "";

        private ClusterGenerator(int port)
        {
            sqlfolder = Application.StartupPath + @"\cluster";
            this.port = port;
        }
        private ClusterGenerator() : this(FreeTcpPort()) { }

        public int Port
        {
            set { this.port = value; }
            get { return this.port; }
        }
        public static bool Current_EuroSQL
        {
            get { return bCurrentEuroSQL; }
        }

        private string CreateCluster()
        {
            try
            {
                sCreateClusterError = "";
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = sqlfolder + @"\bin\initdb.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true,
                    Arguments = @"-U ""postgres"" -D """ + sqlfolder + @"\data"" -A md5 --pwfile=""" + sqlfolder + @"\password.txt" + @"""",
                };

                Process p = new Process();
                p.StartInfo = startInfo;
                p.ErrorDataReceived += ProcessErrorDataHandler;
                p.Start();
                p.WaitForExit();
                if (sCreateClusterError.Trim() != "") { return sCreateClusterError; }
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string StartProcess()
        {
            try
            {
                if (!bCurrentEuroSQL)
                {
                    sStartProcessError = "";
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = @"""" + sqlfolder + @"\bin\pg_ctl.exe""",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Arguments = @"-D """ + sqlfolder + @"\data"" -w -l logfile start",
                    };

                    startInfo.EnvironmentVariables["PATH"] = @"""" + sqlfolder + @"\bin""";
                    startInfo.EnvironmentVariables["PGDATA"] = @"""" + sqlfolder + @"\data""";
                    startInfo.EnvironmentVariables["PGDATABASE"] = "postgres";
                    startInfo.EnvironmentVariables["PGUSER"] = "postgres";
                    startInfo.EnvironmentVariables["PGPORT"] = port.ToString();
                    startInfo.EnvironmentVariables["PGLOCALEDIR"] = @"""" + sqlfolder + @"\share\locale""";
                    Process p = new Process();
                    p.StartInfo = startInfo;
                    p.ErrorDataReceived += StartProcessErrorDataHandler;
                    p.Start();
                    p.WaitForExit();

                    if (sStartProcessError.Trim() != "") { return sStartProcessError; }

                    if (p.ExitCode != 0)
                    {
                        return p.ExitCode.ToString();
                    }
                }
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string StopProcess()
        {
            try
            {
                if (!bCurrentEuroSQL)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = sqlfolder + @"\bin\pg_ctl.exe",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        Arguments = @"-D """ + sqlfolder + @"\data"" stop -m fast",
                    };

                    Process p = new Process();
                    p.StartInfo = startInfo;
                    p.ErrorDataReceived += StopProcessErrorDataHandler;
                    p.Start();
                    p.WaitForExit();
                    if (sStopProcessError.Trim() != "") { return sStopProcessError; }
                }
                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #region events
        private static void ProcessErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            sCreateClusterError += outLine.Data;
        }
        private void StartProcessErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            sStartProcessError += outLine.Data;
        }
        private void StopProcessErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            sStopProcessError += outLine.Data;
        }
        #endregion


        static int FreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }

        public static string UpdateDataFromEuroSQL()
        {
            try
            {
                //folder creation
                if (!System.IO.Directory.Exists(Application.StartupPath + @"\cluster"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\cluster");
                }

                //copy all contents
                string sourcePath = Application.StartupPath + @"\postgress";
                string destPath = Application.StartupPath + @"\cluster";
                CopyContent(sourcePath, destPath);

                //comment port line in data/postgresql.conf
                string[] lines = System.IO.File.ReadAllLines(Application.StartupPath + @"\cluster\data\postgresql.conf");
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Trim().ToLower().StartsWith("port ="))
                    {
                        lines[i] = "#port = 49999";
                    }
                    else if (lines[i].Trim().ToLower().StartsWith("dynamic_shared_memory_type"))
                    {
                        lines[i] = "dynamic_shared_memory_type = none";
                    }
                }
                System.IO.File.WriteAllLines(Application.StartupPath + @"\cluster\data\postgresql.conf", lines);

                //write dynamic port to EF config
                IniFile conf = new IniFile(Application.StartupPath + @"\include\config.ef4");
                conf.IniWriteValue("DATABASE", "StaticPort", "-1");

                WriteClusterSet();

                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string InitializeData()
        {
            try
            {
                //folder creation
                if (!System.IO.Directory.Exists(Application.StartupPath + @"\cluster"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + @"\cluster");
                }
                if (System.IO.Directory.Exists(Application.StartupPath + @"\cluster\data"))
                {
                    System.IO.Directory.Delete(Application.StartupPath + @"\cluster\data");
                }
                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\cluster\data");


                //scompatta archivio
                ZipFile zip = ZipFile.Read(Application.StartupPath + @"\postgresql-9.5.1-1-mod.zip");
                foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("symbols")))
                {
                    e.Extract(Application.StartupPath + @"\cluster");
                }
                foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("share")))
                {
                    e.Extract(Application.StartupPath + @"\cluster");
                }
                foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("lib")))
                {
                    e.Extract(Application.StartupPath + @"\cluster");
                }
                foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("include")))
                {
                    e.Extract(Application.StartupPath + @"\cluster");
                }
                foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("bin")))
                {
                    e.Extract(Application.StartupPath + @"\cluster");
                }

                //crea file con password temp
                if (!File.Exists(Application.StartupPath + @"\cluster\password.txt"))
                {
                    File.Delete(Application.StartupPath + @"\cluster\password.txt");
                }
                TextWriter tw = new StreamWriter(Application.StartupPath + @"\cluster\password.txt", true);
                tw.WriteLine("temp");
                tw.Close();

                ClusterGenerator generatorTemp = new ClusterGenerator();

                //crea il cluster
                string response = generatorTemp.CreateCluster();
                if (response != "0") { return response; }

                //start propcess
                generatorTemp.StopProcess();
                generatorTemp.StartProcess();

                //connette con password temp
                string StrConn = "Server=localhost;Port=" + generatorTemp.port + ";User Id=postgres;Password=temp;Database=postgres;Pooling=False;";
                NpgsqlConnection confree = new NpgsqlConnection(StrConn);
                confree.Open();
                if (confree.State != System.Data.ConnectionState.Open) { return "free connection failed"; }

                //change password
                string sql = "ALTER USER postgres with encrypted password '" + Licenze.Internal_DB_Password().Last() + "'";
                NpgsqlCommand command = new NpgsqlCommand(sql, confree);
                object IDFieldValue = command.ExecuteNonQuery();

                //disconnette free conn
                confree.Close();

                //stop process
                generatorTemp.StopProcess();

                //write dynamic port to EF config
                IniFile conf = new IniFile(Application.StartupPath + @"\include\config.ef4");
                conf.IniWriteValue("DATABASE", "StaticPort", "-1");

                //write clusterset to registry
                WriteClusterSet();

                return "0";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static void CopyContent(string rootDirSource, string rootDirDest)
        {
            foreach (string file in System.IO.Directory.GetFiles(rootDirSource))
            {
                string filename = System.IO.Path.GetFileName(file);
                if (System.IO.File.Exists(rootDirDest + @"\" + filename)) { System.IO.File.Delete(rootDirDest + @"\" + filename); }
                System.IO.File.Copy(file, rootDirDest + @"\" + filename);
            }

            foreach (string dir in System.IO.Directory.GetDirectories(rootDirSource))
            {
                string dirName = new DirectoryInfo(dir).Name;

                if (System.IO.Directory.Exists(rootDirDest + @"\" + dirName)) { System.IO.Directory.Delete(rootDirDest + @"\" + dirName); }
                System.IO.Directory.CreateDirectory(rootDirDest + @"\" + dirName);
                CopyContent(rootDirSource + @"\" + dirName, rootDirDest + @"\" + dirName);
            }
        }

        public static ClusterGenerator GetInstance()
        {
            if (cluster == null)
            {
                cluster = new ClusterGenerator();
            }
            return cluster;
        }
        public static bool IsEuroSQLEngine()
        {
            if (cluster == null) { return true; }
            return false;
        }

        public static void WriteClusterSet()
        {
            try
            {
                //write to registry
                RegistryKey regKey = Registry.CurrentUser;
                regKey = regKey.OpenSubKey(@"Software\\EuroFormulations\\cluster");
                if (regKey == null)
                {
                    regKey = Registry.CurrentUser.CreateSubKey(@"Software\\EuroFormulations\\cluster");
                }
                regKey.SetValue("ClusterSet", "1");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
