using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DriverInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                frmGUI frm = new frmGUI();
                Application.Run(frm);
            }
            else
            {
                Process p = new Process();
                p.StartInfo.FileName = "pnputil";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.Verb = "runas";

                switch (args[0])
                {
                    case "-cube":
                        {
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\cube\ftdibus.inf""";
                            p.Start();
                            p.WaitForExit();
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\cube\ftdiport.inf""";
                            p.Start();
                            p.WaitForExit();
                            break;
                        }
                    case "-spyder":
                        {
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\spyder\dcscusb.inf""";
                            p.Start();
                            p.WaitForExit();
                            break;
                        }
                    case "-ione":
                        {
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\ionepro\i1_pro.inf""";
                            p.Start();
                            p.WaitForExit();
                            break;
                        }
                    default:
                        {
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\cube\ftdibus.inf""";
                            p.Start();
                            p.WaitForExit();
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\cube\ftdiport.inf""";
                            p.Start();
                            p.WaitForExit();
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\spyder\dcscusb.inf""";
                            p.Start();
                            p.WaitForExit();
                            p.StartInfo.Arguments = @"-a """ + args[0] + @"\ionepro\i1_pro.inf""";
                            p.Start();
                            p.WaitForExit();
                            break;
                        }
                }

            }
        }
    }
}
