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
using System.IO;

namespace Euroformulations4.SubWindows.WindowMain
{
    public partial class frmDemo : Form
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private bool bOKDemo = false;
        private bool bAttivato = false;
        private int iDaysLeft = 0;

        public frmDemo(int iDaysLeft)
        {
            InitializeComponent();
            this.iDaysLeft = iDaysLeft;
        }

        public bool Attivato { get { return bAttivato; } }
        
        private void frmLicense_Load(object sender, EventArgs e)
        {
            lblDemo01.Text = lang.GetWord("demo01");
            lblDemo02.Text = lang.GetWord("demo02");
            lblDemo03.Text = lang.GetWord("demo03");
            lblDemo04.Text = lang.GetWord("demo04");
            lblDemo05.Text = lang.GetWord("demo07");
            btnActivateNow.Text = lang.GetWord("demo05");
            btnActivateLater.Text = lang.GetWord("demo06");
            
            txtLK.TextAlign = HorizontalAlignment.Center;
            lblDays.Text = iDaysLeft.ToString();
        }

        private void btnLeggiColore_Click(object sender, EventArgs e)
        {
            bOKDemo = true;
            this.Close();
        }

        private void frmDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bOKDemo && !bAttivato)
            {
                System.Environment.Exit(0);
            }
        }

        private void btnActivateNow_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Activation File|*.eflic";
                
                
                if (openFileDialog1.ShowDialog() == DialogResult.OK) // Test result.
                {
                    string file = openFileDialog1.FileName;

                    //read data
                    string data = File.ReadAllText(file);

                    //write key
                    RegistryKey regKey = Registry.CurrentUser;
                    regKey = regKey.OpenSubKey(@"Software\\EuroFormulations\\4");
                    if (regKey != null)
                    {
                        Registry.CurrentUser.DeleteSubKeyTree(@"Software\\EuroFormulations\\4");
                    }

                    regKey = Registry.CurrentUser.CreateSubKey(@"Software\\EuroFormulations\\4");
                    regKey.SetValue("Key", data);
                    regKey.Close();

                    bAttivato = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblDemo05_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.eurocolori.com/en/contacts");
        }
    }
}
