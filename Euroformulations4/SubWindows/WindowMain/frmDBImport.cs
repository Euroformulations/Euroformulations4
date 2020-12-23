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

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmDBImport : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private static bool _readyOpenEuroFormulations = false;
        private BackgroundWorker importDB = null;
        private static ProgressBar pBarStatic;
        private Dispatcher disp = Dispatcher.CurrentDispatcher;
        private Library.Data.Database.DBImport importatore;

        public frmDBImport()
        {
            InitializeComponent();
            pBarStatic = pBar;
        }

        #region EVENT/PROPERTY
        public bool ReadyOpenEuroFormulations
        {
            get { return _readyOpenEuroFormulations; }
        }
        private void LicenseClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("https://www.euroformulations.com/MyLicense");
                Process.Start(sInfo);
            }
            catch (Exception ){}
        }
        private void frmLicense_Load(object sender, EventArgs e)
        {
            label3.Text = lang.GetWord("db02");
            label2.Text = lang.GetWord("db03");
            lblInfoActivation.Text = lang.GetWord("db06");
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (importDB != null)
                {
                    if (importDB.IsBusy)
                    {
                        throw new Exception(lang.GetWord("db01"));
                    }
                }

                openFileDialog1.Filter = lang.GetWord("db13") + " (*.zip)|*.zip|" + lang.GetWord("db14") + " (*.*)|*.*";
                openFileDialog1.Title = lang.GetWord("db12");
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result != DialogResult.OK) return;

                string path = openFileDialog1.FileName;
                if (path == String.Empty) return;

                UpdateProgressBar(0);
                importDB = new BackgroundWorker();
                importDB.DoWork += new DoWorkEventHandler(ImportDataBaseExecute);
                importDB.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ImportDataBaseCompleted);

                importDB.RunWorkerAsync(path);
            }
            catch (Exception ex) 
            {
                UpdateProgressBar(0);
                MessageBox.Show(ex.Message);
            }
        }
        private void ImportDataBaseCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateProgressBar(0);
            if (importatore != null)
            {
                if (importatore.ExecutedWithSuccess) { this.Close(); }
            } 
        }
        public void ImportDataBaseExecute(object sender, DoWorkEventArgs e)
        {
            try
            {
                string path = e.Argument.ToString();
                string fileName = Path.GetFileName(path);
                importatore = new Library.Data.Database.DBImport(path);
                importatore.DispatcherSet = disp;
                importatore.LabelPercentage = lblPercentage;
                importatore.ProgressBar = pBar;
                importatore.ExecuteImport(fileName.Replace(".zip", ""));
                _readyOpenEuroFormulations = true;
                MessageBox.Show(lang.GetWord("db11"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProgressBar(int value)
        {
            disp.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
            {
                lblPercentage.Text = value.ToString() + "%";
                this.pBar.Value = value;
            }));
        }
    }
}
