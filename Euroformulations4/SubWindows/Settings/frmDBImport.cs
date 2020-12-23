using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmDBImport : Form
    {
        private BackgroundWorker importDB = null;
        private string path = "";
        private string dbname = "";
        private string dbrealname = "";
        private bool bEraseIfExists = false;
        Dispatcher disp = Dispatcher.CurrentDispatcher;

        public bool Busy 
        {
            get 
            {
                if (importDB == null) return true;
                return importDB.IsBusy;
            }
        }

        public frmDBImport()
        {
            InitializeComponent();
            importDB = new BackgroundWorker();
            importDB.DoWork += new DoWorkEventHandler(ImportDataBaseExecute);
            importDB.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportDataBaseCompleted);   
        }

        public void ExecuteNewDatabase(string zipPath, string dbName)
        {
            this.path = zipPath;
            this.dbname = dbName;
            this.bEraseIfExists = false;
            this.dbrealname = "";
            importDB.RunWorkerAsync();
        }

        public void ExecuteUpdateDatabase(string zipPath, string dbName, bool eraseIfExist, string dbrealname)
        {
            this.path = zipPath;
            this.dbname = dbName;
            this.bEraseIfExists = eraseIfExist;
            this.dbrealname = dbrealname;
            importDB.RunWorkerAsync();
        }

        public void ImportDataBaseExecute(object sender, DoWorkEventArgs e)
        {
            try
            {
                Library.Data.Database.DBImport importatore = new Library.Data.Database.DBImport(this.path);
                importatore.DispatcherSet = disp;
                importatore.LabelPercentage = lblPercentage;
                importatore.ProgressBar = pBar;
                importatore.LabelInfo = lblStato;
                importatore.EraseIfExists = bEraseIfExists;
                importatore.ExecuteImport(dbname, dbrealname);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        private void ImportDataBaseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

    }
}
