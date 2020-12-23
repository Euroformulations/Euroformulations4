using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Euroformulations4.Library.Data.Dispositivi
{
    class DispositivoColorCatch3 : IDispositivo
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private static int maxWait = 4000; //milliseconds
        /*
                                                                                  StreamReader streamReader = new StreamReader(Application.StartupPath + "\\" + "colorcatch3.txt");
                string text = streamReader.ReadToEnd();
                MessageBox.Show(text);
                streamReader.Close();
         **/
        public double[] Read_XYZLab()
        {

            double[] lab = new double[6];
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Application.StartupPath + "/include/ColorCatch3.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;
            int exitCode;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
                exitCode = proc.ExitCode;
            }

            StreamReader streamReader = new StreamReader(Application.StartupPath + "/include/colorcatch3.txt");
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            string[] items = text.Split(';');
            double[] RGB_XYZ = Colore.RGB_XYZ(Convert.ToDouble(items[0]), Convert.ToDouble(items[1]), Convert.ToDouble(items[2]));
            double[] XYZ_LAB = Colore.XYZ_LAB(Convert.ToDouble(RGB_XYZ[0].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(RGB_XYZ[1].ToString().Replace(',', '.'), CultureInfo.InvariantCulture), Convert.ToDouble(RGB_XYZ[2].ToString().Replace(',', '.'), CultureInfo.InvariantCulture));

            lab[0] = RGB_XYZ[0];
            lab[1] = RGB_XYZ[1];
            lab[2] = RGB_XYZ[2];
            lab[3] = Convert.ToDouble(XYZ_LAB[0].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
            lab[4] = Convert.ToDouble(XYZ_LAB[1].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
            lab[5] = Convert.ToDouble(XYZ_LAB[2].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

            return lab;
        }

        public bool CanRead()
        {

            return true;
        }

        public static void CalibrateWhite()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Application.StartupPath + "/include/CalibratorWhite.exe";
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //start.Arguments = "parameters";

            using (Process process__1 = Process.Start(start))
            {
                if (!process__1.WaitForExit(maxWait))
                {
                    throw new Exception(lang.GetWord("spettro02"));
                }
                using (System.IO.StreamReader reader = process__1.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    if (result == "<<data>>OK")
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception(result);
                    }
                }
            }
        }

        public static void CalibrateBlack()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Application.StartupPath + "/include/CalibratorBlack.exe";
            start.CreateNoWindow = true;
            start.UseShellExecute = false;
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            //start.Arguments = "parameters";

            using (Process process__1 = Process.Start(start))
            {
                if (!process__1.WaitForExit(maxWait))
                {
                    throw new Exception(lang.GetWord("spettro02"));
                }
                using (System.IO.StreamReader reader = process__1.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    if (result == "<<data>>OK")
                    {
                        return;
                    }
                    else
                    {
                        throw new Exception(result);
                    }
                }
            }
        }

        public static void SetCalibratedNow()
        {
            Data.Settings settings = new Data.Settings();
            settings.SetValue("LastCalibration", DateTime.Now.ToString());
        }

        public static DateTime GetLastCalibration()
        {
            Data.Settings settings = new Data.Settings();
            if (!settings.HasKey("LastCalibration"))
            {
                settings.SetValue("LastCalibration", DateTime.MinValue.ToString());
            }
            return DateTime.Parse(settings.GetValue("LastCalibration"));
        }

        public System.Windows.Forms.Form GetWindowManager()
        {
            SubWindows.frmCalibraStrumento frm = new SubWindows.frmCalibraStrumento();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            return frm;
        }


    }
}
