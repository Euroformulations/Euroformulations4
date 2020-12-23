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
using Microsoft.Win32;
using System.IO.Compression;
using Ionic.Zip;
using Npgsql;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using Euroformulations4.Library;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmAutoInstaller : Form
    {
        private Library.Language lang = Library.Language.GetInstance();
        private Dispatcher disp = Dispatcher.CurrentDispatcher;
        private BackgroundWorker importDB = null;
        private string sPort;

        public frmAutoInstaller(string sPort)
        {
            InitializeComponent();
            this.sPort = sPort;

            importDB = new BackgroundWorker();
            importDB.DoWork += new DoWorkEventHandler(ImportDataBaseExecute);
            importDB.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportDataBaseCompleted);
        }
        private void frmLicense_Load(object sender, EventArgs e)
        {
            try
            {
                importDB.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ImportDataBaseExecute(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\auto_db.zip"))
                {
                    Library.Data.Database.DBImport importatore = new Library.Data.Database.DBImport(Application.StartupPath + "\\auto_db.zip");
                    importatore.DispatcherSet = disp;
                    importatore.ProgressBar = pBar;
                    importatore.LabelInfo = lblInfo;
                    importatore.LabelPercentage = lblPercentage;
                    importatore.LabelInfoText = new List<string>(new string[]{
                        "1/3 " + lang.GetWord("dbimport01"),
                        "2/3 " + lang.GetWord("dbimport02"),
                        "3/3 " + lang.GetWord("dbimport03"),
                    });
                    importatore.ExecuteImport("Database 01");
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ImportDataBaseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
