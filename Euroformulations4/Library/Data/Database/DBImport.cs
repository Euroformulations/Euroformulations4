using Ionic.Zip;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Euroformulations4.Library.Data.Database
{
    class DBImport
    {
        private string sZipPath;
        private static Library.Language lang = Library.Language.GetInstance();
        private Dispatcher disp;
        private Label lblPercentage = null;
        private ProgressBar pBar = null;
        private Label lblInfo = null;
        private bool sLastExecuteSuccess = false;
        private bool bEraseIfExists = false;
        private List<string> lstProgressInfo = new List<string>();

        public DBImport(string sZipPath)
        {
            this.sZipPath = sZipPath;
            lstProgressInfo.Add("1/3 " + lang.GetWord("dbimport01"));
            lstProgressInfo.Add("2/3 " + lang.GetWord("dbimport02"));
            lstProgressInfo.Add("3/3 " + lang.GetWord("dbimport03"));
        }

        public List<string> LabelInfoText { set { this.lstProgressInfo = value; } }

        public Label LabelPercentage
        {
            set
            {
                this.lblPercentage = value;
            }
        }
        public Label LabelInfo
        {
            set { this.lblInfo = value; }
        }  
        public Dispatcher DispatcherSet { set { this.disp = value; } }
        public ProgressBar ProgressBar
        {
            set { this.pBar = value; }
        }
        public bool ExecutedWithSuccess { get { return sLastExecuteSuccess; } }
        public bool EraseIfExists { set { this.bEraseIfExists = value; } }

        /*                                        TUTORIAL NOMI DATABASE
         * 
         * DBRealName: nome database sul DBMS
         * DBNameByUser: nome database assegnato dall'utente
         * DBNameByManufacturer: nome database assegnato dal costruttore del database (MyStudio, Eurocolori, ...)
         * 
         */
        public void ExecuteImport(string DBNameByUser, string DBRealName = "")
        {
            string sErrors = "";
            string pathFormule = System.IO.Path.GetTempPath() + "formule.sql";
            string pathFormulePrev = System.IO.Path.GetTempPath() + "formule_prev.sql";
            string pathBasi = System.IO.Path.GetTempPath() + "base.sql";
            string pathPigmenti = System.IO.Path.GetTempPath() + "pigmenti.sql";
            string pathInfo = System.IO.Path.GetTempPath() + "info.txt";
            string pathLogo = System.IO.Path.GetTempPath() + "logo.png";
            string pathLogoLoading = System.IO.Path.GetTempPath() + "loading.png";
            string pathLogoCenter = System.IO.Path.GetTempPath() + "center.png";
            string pathListiniDef = System.IO.Path.GetTempPath() + "listini.sql";
            string pathListiniLatt = System.IO.Path.GetTempPath() + "lattaggi.sql";
            string pathListiniCol = System.IO.Path.GetTempPath() + "costicoloranti.sql";
            string pathListiniBas = System.IO.Path.GetTempPath() + "costibase.sql";
            string pathSqlCube = System.IO.Path.GetTempPath() + "sqlcube.sql";
            try
            {
                UpdateInfo(lstProgressInfo[0]);
                sLastExecuteSuccess = false;
                string path = sZipPath;

                //open connection
                Library.IniFile conf = new Library.IniFile();
                string ip = conf.IniReadValue("DATABASE", "ServerIP");
                Library.Data.Database.DBConnector dbRoot = new Library.Data.Database.DBConnector(ip, "postgres");

                if (!System.IO.File.Exists(path))
                {
                    throw new Exception(lang.GetWord("db07"));
                }

                using (var zip = ZipFile.Read(path))
                {
                    zip.Password = Library.Licenze.Internal_DB_ZIP_Password();

                    ZipFile zipCube = ZipFile.Read(Application.StartupPath + "\\sqlcube.zip");
                    zipCube.Password = Library.Licenze.Internal_DB_ZIP_Password();

                    //delete temporary files
                    if (System.IO.File.Exists(pathFormule)) { System.IO.File.Delete(pathFormule); }
                    if (System.IO.File.Exists(pathFormulePrev)) { System.IO.File.Delete(pathFormulePrev); }
                    if (System.IO.File.Exists(pathBasi)) { System.IO.File.Delete(pathBasi); }
                    if (System.IO.File.Exists(pathPigmenti)) { System.IO.File.Delete(pathPigmenti); }
                    if (System.IO.File.Exists(pathInfo)) { System.IO.File.Delete(pathInfo); }
                    if (System.IO.File.Exists(pathLogo)) { System.IO.File.Delete(pathLogo); }
                    if (System.IO.File.Exists(pathLogoLoading)) { System.IO.File.Delete(pathLogoLoading); }
                    if (System.IO.File.Exists(pathLogoCenter)) { System.IO.File.Delete(pathLogoCenter); }
                    if (System.IO.File.Exists(pathListiniDef)) { System.IO.File.Delete(pathListiniDef); }
                    if (System.IO.File.Exists(pathListiniLatt)) { System.IO.File.Delete(pathListiniLatt); }
                    if (System.IO.File.Exists(pathListiniCol)) { System.IO.File.Delete(pathListiniCol); }
                    if (System.IO.File.Exists(pathListiniBas)) { System.IO.File.Delete(pathListiniBas); }
                    if (System.IO.File.Exists(pathSqlCube)) { System.IO.File.Delete(pathSqlCube); }

                    //UpdateProgressBar(1);

                    //move files
                    ExtractZIPFile(zip["formule.sql"], System.IO.Path.GetTempPath());
                    ExtractZIPFile(zip["base.sql"], System.IO.Path.GetTempPath());
                    ExtractZIPFile(zip["pigmenti.sql"], System.IO.Path.GetTempPath());
                    ExtractZIPFile(zip["info.txt"], System.IO.Path.GetTempPath());
                    ExtractZIPFile(zipCube["sqlcube.sql"], System.IO.Path.GetTempPath());
                    if (zip["logo.png"] != null) { ExtractZIPFile(zip["logo.png"], System.IO.Path.GetTempPath()); } else { pathLogo = ""; }
                    if (zip["loading.png"] != null) { ExtractZIPFile(zip["loading.png"], System.IO.Path.GetTempPath()); } else { pathLogoLoading = ""; }
                    if (zip["center.png"] != null) { ExtractZIPFile(zip["center.png"], System.IO.Path.GetTempPath()); } else { pathLogoCenter = ""; }
                    if (zip["listini.sql"] != null) { ExtractZIPFile(zip["listini.sql"], System.IO.Path.GetTempPath()); } else { pathListiniDef = ""; }
                    if (zip["lattaggi.sql"] != null) { ExtractZIPFile(zip["lattaggi.sql"], System.IO.Path.GetTempPath()); } else { pathListiniLatt = ""; }
                    if (zip["costicoloranti.sql"] != null) { ExtractZIPFile(zip["costicoloranti.sql"], System.IO.Path.GetTempPath()); } else { pathListiniCol = ""; }
                    if (zip["costibase.sql"] != null) { ExtractZIPFile(zip["costibase.sql"], System.IO.Path.GetTempPath()); } else { pathListiniBas = ""; }
                    if (zip["formule_prev.sql"] != null) { ExtractZIPFile(zip["formule_prev.sql"], System.IO.Path.GetTempPath()); } else { pathFormulePrev = ""; }
                }

                //header zip file
                string[] infoData = System.IO.File.ReadAllLines(pathInfo);
                string DBNameByManufacturer = "ef_" + ReadInfoValue(infoData, "name");  //nome del progetto
                int versioneImport = Convert.ToInt32(ReadInfoValue(infoData, "version"));  //versione database
                string showLabelEmail = ReadInfoValue(infoData, "showlabelemail"); //may be null value
                string dbcode = ReadInfoValue(infoData, "dbcode");  //may be null value

                //total query
                int totalQuery = System.IO.File.ReadLines(pathFormule).Count() +
                    System.IO.File.ReadLines(pathBasi).Count() +
                    System.IO.File.ReadLines(pathPigmenti).Count();
                if (pathListiniDef != "")
                {
                    totalQuery += System.IO.File.ReadLines(pathListiniDef).Count() +
                        System.IO.File.ReadLines(pathListiniLatt).Count() +
                        System.IO.File.ReadLines(pathListiniCol).Count() +
                        System.IO.File.ReadLines(pathListiniBas).Count();
                }
                if (pathFormulePrev != "")
                {
                    totalQuery += System.IO.File.ReadLines(pathFormulePrev).Count();
                }

                int currentQueryDone = 0;

                string query;

                Dictionary<string, string> dicPrevSettingsSave = new Dictionary<string, string>();

                //get database name
                if (DBRealName.Trim() == "")
                {
                    //nuovo database, nuovo nome su postgres
                    int dbCounter = 1;
                    bool bDBOccupato = true;

                    while (bDBOccupato)
                    {
                        DBRealName = "ef_" + dbCounter.ToString("00000");
                        query = "SELECT 1 AS result FROM pg_database WHERE datname='" + DBRealName + "'";
                        DataTable dtExist = dbRoot.SQLQuerySelect(query);
                        bDBOccupato = dtExist.Rows.Count > 0;
                        dbCounter++;
                    }

                    query = "CREATE DATABASE " + DBRealName;
                    dbRoot.SQLQuery_AffectedRows(query);
                }
                else
                {
                    //check if db already exists
                    query = "SELECT 1 AS result FROM pg_database WHERE datname='" + DBRealName + "'";
                    DataTable dtExist = dbRoot.SQLQuerySelect(query);
                    bool DBExists = dtExist.Rows.Count > 0;
                    if (!DBExists)
                    {
                        // nuovo DB
                        query = "CREATE DATABASE " + DBRealName;
                        dbRoot.SQLQuery_AffectedRows(query);
                    }
                    else
                    {
                        Library.Data.Database.DBConnector dbDrop = new Library.Data.Database.DBConnector(ip, DBRealName);

                        //check/save previously settings
                        DataTable dt = dbDrop.SQLQuerySelect("SELECT * FROM settings");
                        foreach (DataRow dr in dt.Rows)
                        {
                            switch (dr["key"].ToString())
                            {
                                case "dbmanufacturername":
                                    {
                                        if (DBNameByManufacturer != dr["value"].ToString() && !bEraseIfExists)
                                        {
                                            DialogResult dConfirm = MessageBox.Show(lang.GetWord("db15"), lang.GetWord("settings43"), MessageBoxButtons.YesNo);
                                            if (dConfirm == DialogResult.Yes)
                                            {
                                                bEraseIfExists = true;
                                            }
                                            else
                                            {
                                                throw new Exception(lang.GetWord("dblib05"));
                                            }
                                        }
                                        dicPrevSettingsSave.Add("dbmanufacturername", DBNameByManufacturer);
                                        break;
                                    }
                                case "dt_database_creation":
                                    {
                                        dicPrevSettingsSave.Add("dt_database_creation", dr["value"].ToString());
                                        break;
                                    }
                            }
                        }

                        if (bEraseIfExists)
                        {
                            List<string> querySequences = new List<string>();
                            List<string> tabelle = new List<string>();

                            //init lista sequences
                            DataTable dtDrop = dbDrop.SQLQuerySelect("SELECT 'drop sequence if exists ' || c.relname || ';' AS query FROM pg_class AS c WHERE (c.relkind = 'S');");
                            foreach (DataRow dr in dtDrop.Rows)
                            {
                                querySequences.Add(dr["query"].ToString());
                            }

                            //init lista tabelle
                            dtDrop = dbDrop.SQLQuerySelect("SELECT table_name AS tabella FROM information_schema.tables WHERE table_schema = 'public';");
                            foreach (DataRow dr in dtDrop.Rows)
                            {
                                tabelle.Add(dr["tabella"].ToString());
                            }

                            //remove tables
                            foreach (string sTabella in tabelle)
                            {
                                dbDrop.SQLQuery_AffectedRows("DROP TABLE IF EXISTS " + sTabella);
                            }

                            //remove sequences
                            foreach (string sDelSeq in querySequences)
                            {
                                dbDrop.SQLQuery_AffectedRows(sDelSeq);
                            }

                            dbDrop.CloseConnection();
                        }
                    }
                }
                //POST: DBRealName assegnato



                //parameters
                Library.GVar.ServerIP = ip;
                Library.GVar.Database = DBRealName;

                //close old connection
                dbRoot.CloseConnection();

                //struttura per settings
                Library.Data.Database.DBStructureManager.ControlloDBSettings();

                //structure as imported version
                Library.Data.Database.DBStructureManager.ControlloVersioneDB(versioneImport);

                //verifica applicabilità database (es: non posso se versione da importare = 19 && versione da codice = 17)
                if (Library.Data.Database.DBStructureManager.VersioneDB < versioneImport)
                {
                    throw new Exception(lang.GetWord("db09") + " (" + versioneImport + ") " + lang.GetWord("db10") + " (" + Library.Data.Database.DBStructureManager.VersioneDB + ")");
                }

                //riconnessione al (nuovo) database
                Library.Data.Database.DBConnector db = new Library.Data.Database.DBConnector(ip, DBRealName);

                //DATABASE SETTINGS
                try
                {
                    ManualUpdateSettings(db, "dbmanufacturername", DBNameByManufacturer);
                    ManualUpdateSettings(db, "showlabelemail", showLabelEmail);
                    ManualUpdateSettings(db, "dbcode", dbcode);

                    #region DATABASE CREATION
                    DataTable dt = db.SQLQuerySelect("SELECT COUNT(*) AS result FROM settings WHERE key = 'dt_database_creation'");
                    bool bDBCreation = Convert.ToInt32(dt.Rows[0]["result"].ToString()) > 0;
                    if (!bDBCreation)
                    {
                        if (dicPrevSettingsSave.ContainsKey("dt_database_creation"))
                        {
                            Dictionary<string, object> data = new Dictionary<string, object>()
                            {
                                {"key", "'dt_database_creation'"},
                                {"value", dicPrevSettingsSave["dt_database_creation"]}
                            };
                            db.QueryInsert("settings", data);
                        }  
                    }
                    #endregion

                    #region PERSONALIZZAZIONE_LOGO
                    if (pathLogo != ""){SetLogo(pathLogo, db, "personalized_logo");}
                    if (pathLogoLoading != "") { SetLogo(pathLogoLoading, db, "personalized_logoLoading"); }
                    if (pathLogoCenter != "") { SetLogo(pathLogoCenter, db, "personalized_logoCenter"); }
                    #endregion
                }
                catch (Exception)
                {
                    //warning: errore during personalization import
                }
                UpdateInfo(lstProgressInfo[1]);
                UpdateProgressBar(1);
                int i = 0;

                //DELETE + ADD TABELLA FORMULE
                query = "DELETE FROM formule";
                db.QueryDelete("formule");
                ReadFileForQueryExecution(db, pathFormule, ref i, ref currentQueryDone, totalQuery);

                //DELETE + ADD TABELLA BASE
                db.QueryDelete("base");
                ReadFileForQueryExecution(db, pathBasi, ref i, ref currentQueryDone, totalQuery);

                //DELETE + ADD TABELLA PIGMENTI
                db.QueryDelete("pigmenti");
                ReadFileForQueryExecution(db, pathPigmenti, ref i, ref currentQueryDone, totalQuery);

                //LISTINI
                if (pathListiniDef != "")
                {
                    db.QueryDelete("listino");
                    db.QueryDelete("base_costi");
                    db.QueryDelete("pig_costi");
                    db.QueryDelete("lattaggi");
                    ReadFileForQueryExecution(db, pathListiniDef, ref i, ref currentQueryDone, totalQuery);
                    ReadFileForQueryExecution(db, pathListiniLatt, ref i, ref currentQueryDone, totalQuery);
                    ReadFileForQueryExecution(db, pathListiniCol, ref i, ref currentQueryDone, totalQuery);
                    ReadFileForQueryExecution(db, pathListiniBas, ref i, ref currentQueryDone, totalQuery);
                }

                //FORMULE PRECEDENTI
                if (pathFormulePrev != "")
                {
                    db.QueryDelete("formule_prev");
                    ReadFileForQueryExecution(db, pathFormulePrev, ref i, ref currentQueryDone, totalQuery);
                }

                Library.Data.Database.DBStructureManager.ControlloVersioneDB();

                UpdateProgressBar(0);
                UpdateInfo(lstProgressInfo[2]); 
                //set total_query e current_query_done
                totalQuery = System.IO.File.ReadLines(pathSqlCube).Count();
                currentQueryDone = 0;
                
                //UPDATE FORMULE FOR SWATCHMATE CUBE CIELab DATA
                ReadFileForQueryExecution(db, pathSqlCube, ref i, ref currentQueryDone, totalQuery);

                //close connection
                db.CloseConnection();

                //database linking to config file
                conf.IniWriteValue("DATABASE", "ActiveDB", DBRealName);
                conf.IniWriteValue("DBLIST", DBRealName, DBNameByUser);

                //set true parameter public for external reading
                sLastExecuteSuccess = true;


            }
            catch (Exception ex)
            {
                sErrors = ex.Message;
            }
            finally 
            {
                //delete temporary files
                if (System.IO.File.Exists(pathFormule)) { System.IO.File.Delete(pathFormule); }
                if (System.IO.File.Exists(pathBasi)) { System.IO.File.Delete(pathBasi); }
                if (System.IO.File.Exists(pathPigmenti)) { System.IO.File.Delete(pathPigmenti); }
                if (System.IO.File.Exists(pathInfo)) { System.IO.File.Delete(pathInfo); }
                if (System.IO.File.Exists(pathLogo)) { System.IO.File.Delete(pathLogo); }
                if (System.IO.File.Exists(pathLogoLoading)) { System.IO.File.Delete(pathLogoLoading); }
                if (System.IO.File.Exists(pathLogoCenter)) { System.IO.File.Delete(pathLogoCenter); }
                if (System.IO.File.Exists(pathSqlCube)) { System.IO.File.Delete(pathSqlCube); }
                if (System.IO.File.Exists(pathFormulePrev)) { System.IO.File.Delete(pathFormulePrev); }
            }

            if (sErrors != "")
            {
                throw new Exception(sErrors);
            }
        }

        #region FUNCTIONS
        private void ManualUpdateSettings(Library.Data.Database.DBConnector db, string key, string value)
        {
            DataTable dt = db.SQLQuerySelect("SELECT COUNT(*) AS result FROM settings WHERE key = '" + key + "'");
            bool bKeyExists = Convert.ToInt32(dt.Rows[0]["result"].ToString()) > 0;

            if (!bKeyExists)
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                            {
                                {"key", "'"+ key +"'"},
                                {"value", "'" + value + "'"}
                            };
                db.QueryInsert("settings", data);
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                            {
                                {"value", "'" + value + "'"}
                            };
                db.QueryUpdate("settings", data, "key = '" + key + "'");
            }
        }


        private void UpdateProgressBar(int value)
        {
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                if (lblPercentage != null) { lblPercentage.Text = value.ToString() + "%"; }
                if (pBar != null) { this.pBar.Value = value; }
            }));
        }
        private void UpdateInfo(string sInfo)
        {
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                if (lblInfo != null) { lblInfo.Text = sInfo; }
            }));
            //lblInfo
        }
        private void UpdateProgressBar(int totalQuery, int queryDone)
        {
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                int value = 1 + ((queryDone * 99) / totalQuery);
                if (value > 100) value = 100;
                if (value < 0) value = 0;
                if (lblPercentage != null) { lblPercentage.Text = value.ToString() + "%"; }
                if (pBar != null) { this.pBar.Value = value; }
            }));
        }
        private static void ExtractZIPFile(ZipEntry entry, string pathDir)
        {
            try
            {
                entry.ExtractWithPassword(pathDir, Library.Licenze.Internal_DB_ZIP_Password());
            }
            catch (Exception)
            {
                throw new Exception(lang.GetWord("dblib06"));
            }
            
        }

        private static string ReadInfoValue(string[] info, string key)
        {
            foreach (string line in info)
            {
                string[] items = line.Split('=');
                if (items[0].Trim() == key) 
                {
                    return items[1].Trim();
                }
            }
            return "";
        }

        private void ReadFileForQueryExecution(Library.Data.Database.DBConnector dbQuery, string path, ref int i, ref int currentQueryDone, int totalQuery)
        {
            System.IO.TextReader reader = new System.IO.StreamReader(path);
            bool bReadAvailable = true;
            StringBuilder buildBatch;
            List<string> buffer = new List<string>();

            while (bReadAvailable)
            {
                string querytemp = "";
                int queryCount = 0;
                buildBatch = new StringBuilder();
                buffer.Clear();
                
                //lettura query
                do
                {
                    querytemp = reader.ReadLine();
                    if (querytemp != null)
                    {
                        buildBatch.Append(querytemp);
                        buffer.Add(querytemp);
                    }
                    else
                    {
                        bReadAvailable = false;
                    }

                    queryCount++;

                } while (queryCount < 100 && bReadAvailable);

                if (queryCount > 0)
                {
                    //esecuzione lotto
                    dbQuery.SQLQuery_AffectedRows(buildBatch.ToString());
                    
                    //in caso di errori esegue 1 query alla volta
                    if (dbQuery.LastQueryError != "") 
                    {
                        foreach (string queryItem in buffer)
                        {
                            dbQuery.SQLQuery_AffectedRows(queryItem);

                            //in caso di errori prova a scrivere un log su file
                            if (dbQuery.LastQueryError != "")
                            {
                                try
                                {
                                    using (StreamWriter w = File.AppendText(System.Windows.Forms.Application.StartupPath + @"\error_query.txt"))
                                    {
                                        w.WriteLine(queryItem);
                                    }
                                }
                                catch (Exception) { }   
                            }
                        }
                    }
                    
                    //report query eseguite
                    currentQueryDone += queryCount;
                    UpdateProgressBar(totalQuery, currentQueryDone);
                    Thread.Sleep(1);
                }
            }

            reader.Close();
        }
        private void SetLogo(string pathLogo, DBConnector db, string fieldName)
        {
            byte[] logoData;

            using (FileStream stream2 = new FileStream(pathLogo, FileMode.Open, FileAccess.Read))
            {
                Image imgLogo = Image.FromStream(stream2);
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
                {
                    imgLogo.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    logoData = stream.ToArray();
                    stream.Close();
                }
                stream2.Close();
            }

            string sql = "SELECT COUNT(*) AS result FROM settings WHERE key = '" + fieldName + "'";
            DataTable dt = db.SQLQuerySelect(sql);
            bool logoExists = Convert.ToInt32(dt.Rows[0]["result"].ToString()) > 0;

            if (!logoExists)
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                            {
                                {"key", "'"+ fieldName +"'"},
                                {"value_data", logoData}
                            };
                db.QueryInsert("settings", data);
            }
            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>()
                            {
                                {"value_data", logoData}
                            };
                db.QueryUpdate("settings", data, "key = '" + fieldName + "'");
            }
        }
        public static bool ListiniIntoZipFile(string zipPath)
        {
            try
            {
                if (!System.IO.File.Exists(zipPath)){throw new Exception(lang.GetWord("db07"));}
                ZipFile zip = ZipFile.Read(zipPath);
                zip.Password = Library.Licenze.Internal_DB_ZIP_Password();
                if (zip["listini.sql"] != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
