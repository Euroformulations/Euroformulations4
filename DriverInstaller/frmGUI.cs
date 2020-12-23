using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DriverInstaller
{
    public partial class frmGUI : Form
    {
        private bool bChkEnabled = true;

        public frmGUI()
        {
            InitializeComponent();
        }

        private void chkCube_CheckedChanged(object sender, EventArgs e)
        {
            if (bChkEnabled)
            {
                bChkEnabled = false;
                ChkReset(sender);
                bChkEnabled = true;
            }
            
            //chkCube.Checked = true;
        }

        private void chkSpyder_CheckedChanged(object sender, EventArgs e)
        {
            if (bChkEnabled)
            {
                bChkEnabled = false;
                ChkReset(sender);
                bChkEnabled = true;
            }
            //chkSpyder.Checked = true;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (bChkEnabled)
            {
                bChkEnabled = false;
                ChkReset(sender);
                bChkEnabled = true;
            }
            //chkSelect.Checked = true;
        }

        private void chkIone_CheckedChanged(object sender, EventArgs e)
        {
            if (bChkEnabled)
            {
                bChkEnabled = false;
                ChkReset(sender);
                bChkEnabled = true;
            }
            //chkIone.Checked = true;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            try
            {
                string sArgument = "";
                string sArgument2 = "";

                if (chkCube.Checked)
                {
                    sArgument = @"\cube\ftdibus.inf""";
                    sArgument2 = @"\cube\ftdiport.inf""";
                }
                else if (chkSpyder.Checked || chkSelect.Checked)
                {
                    sArgument = @"\spyder\dcscusb.inf""";
                }
                else if (chkIone.Checked)
                {
                    sArgument = @"\ionepro\i1_pro.inf""";
                }
                Process p;
                if (sArgument != "")
                {
                    p = new Process();
                    p.StartInfo.FileName = "pnputil";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.Verb = "runas";

                    p.StartInfo.Arguments = @"-a """ + Application.StartupPath + sArgument;
                    p.Start();
                    p.WaitForExit();

                    if (sArgument2 != "")
                    {
                        p = new Process();
                        p.StartInfo.FileName = "pnputil";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.Verb = "runas";

                        p.StartInfo.Arguments = @"-a """ + Application.StartupPath + sArgument2;
                        p.Start();
                        p.WaitForExit();
                    }

                    MessageBox.Show("Driver successfully installed. Please remove and re-plug your device.");
                }
                else
                {
                    MessageBox.Show("Please select one device driver to install");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void ChkReset(object sender)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk != chkCube) chkCube.Checked = false;
            if(chk != chkSelect)    chkSelect.Checked = false;
            if (chk != chkSpyder) chkSpyder.Checked = false;
            if (chk != chkIone) chkIone.Checked = false; 
        }

        private void frmGUI_Load(object sender, EventArgs e)
        {
            chkCube.Checked = true;
        }
    }
}
