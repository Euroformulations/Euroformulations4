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
using System.IO;

namespace Euroformulations4.SubWindows.Settings
{
    public partial class frmImportExportMachine : Form
    {
        private Library.Data.DBSettings dbSettings = new Library.Data.DBSettings();
        private Library.Language lang = Library.Language.GetInstance();
        private string filter = "";
        private Library.Data.Database.DBConnector db;
        Library.Data.Database.DBConnect_Npgsql dbc;

        public frmImportExportMachine()
        {
            InitializeComponent();
            db = new Library.Data.Database.DBConnector();

            btnImport.Text = lang.GetWord("settings86");
            btnExport.Text = lang.GetWord("settings87");

            filter = lang.GetWord("mac05") + " (*.csv)|*.csv|" + lang.GetWord("db14") + " (*.*)|*.*";
            dbc = new Euroformulations4.Library.Data.Database.DBConnect_Npgsql();
            dbc.connect(Library.GVar.Database);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = filter;
                openFileDialog1.Title = lang.GetWord("mac06");
                openFileDialog1.FileName = "";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result != DialogResult.OK) return;

                string path = openFileDialog1.FileName;
                if (path == String.Empty) return;
                string[] lines = System.IO.File.ReadAllLines(path);

                DialogResult dialogResult = MessageBox.Show(lang.GetWord("mac11"), lang.GetWord("mac12"), MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes) return;

                db.QueryDelete("machine");

                Library.Data.DBSettings settings = new Library.Data.DBSettings();
                settings.SetValue("IDMachineOunceEdit", "-1");

                bool bErrors = false;
                foreach (string line in lines)
                {
                    string[] items = line.Split(';');
                    if (items.Length >= 5)
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>();
                        data.Add("name", items[0]);
                        data.Add("machine_type", items[1]);
                        data.Add("pathfile", items[2]);
                        data.Add("exefile", items[3]);
                        data.Add("oncetype", items[4]);

                        object oIDMachine = db.QueryInsert("machine", data, "id_machine");

                        if (items.Length >= 6)
                        {
                            if (items[5] == "1") { settings.SetValue("IDMachineOunceEdit", oIDMachine.ToString()); }
                        }

                        if (db.LastQueryError != "") { bErrors = true; }
                    }
                    else
                    {
                        bErrors = true;
                    }
                }

                if (bErrors)
                {
                    MessageBox.Show(lang.GetWord("mac07"));
                }
                else
                {
                    MessageBox.Show(lang.GetWord("mac08"));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstMacchine = new List<string>();
                bool bAnyRow = false;
                int IDMachineOunceEdit = Convert.ToInt32(dbSettings.GetValue("IDMachineOunceEdit"));
                DataTable dt = db.SQLQuerySelect("SELECT * FROM machine ORDER BY id_machine");
                foreach (DataRow dr in dt.Rows)
                {
                    bAnyRow = true;
                    string sDefaultOunceEdit = dr["id_machine"].ToString() == IDMachineOunceEdit.ToString()? "1":"0";
                    lstMacchine.Add(dr["name"].ToString() + ";" + dr["machine_type"].ToString() + ";" + dr["pathfile"].ToString() + ";" + dr["exefile"].ToString() + ";" + dr["oncetype"].ToString() + ";" + sDefaultOunceEdit);
                }

                if (bAnyRow)
                {
                    savefile.FileName = "machines.csv";
                    savefile.Filter = filter;
                    savefile.OverwritePrompt = true;
                    if (savefile.ShowDialog() != DialogResult.OK) return;

                    StreamWriter sw = new StreamWriter(savefile.FileName);
                    foreach (string line in lstMacchine)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();

                    MessageBox.Show(lang.GetWord("mac09"));
                    this.Close();
                }
                else
                {
                    MessageBox.Show(lang.GetWord("mac10"));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmImportExportMachine_Load(object sender, EventArgs e)
        {
            this.Text = lang.GetWord("mac01");
            label1.Text = lang.GetWord("mac02") + ":";
            btnImport.Text = lang.GetWord("mac03");
            btnExport.Text = lang.GetWord("mac04");
        }

        private void frmImportExportMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
 
    }
}
