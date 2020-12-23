using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Globalization;

namespace Euroformulations4.Library
{
    /*class Spettrofotometro
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private static int maxWait = 4000; //milliseconds

        public static double[] ReadXYZLab()
        {
            double[] lab = new double[6];

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Application.StartupPath + "/include/SpyderReader.exe";
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
                    throw new Exception(lang.GetWord("spettro01"));
                }


                using (System.IO.StreamReader reader = process__1.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    //formato: <<data>>X;Y;Z;L;A;B
                    if (result.StartsWith("<<data>>"))
                    {
                        result = result.Substring(8);
                    }
                    else
                    {
                        throw new Exception(result);
                    }

                    string[] items = result.Split(';');

                    lab[0] = Convert.ToDouble(items[0].Replace(',', '.'), CultureInfo.InvariantCulture);
                    lab[1] = Convert.ToDouble(items[1].Replace(',', '.'), CultureInfo.InvariantCulture);
                    lab[2] = Convert.ToDouble(items[2].Replace(',', '.'), CultureInfo.InvariantCulture);
                    lab[3] = Convert.ToDouble(items[3].Replace(',', '.'), CultureInfo.InvariantCulture);
                    lab[4] = Convert.ToDouble(items[4].Replace(',', '.'), CultureInfo.InvariantCulture);
                    lab[5] = Convert.ToDouble(items[5].Replace(',', '.'), CultureInfo.InvariantCulture);
                }
            }

            return lab;
        }

        public static bool Test_ReaderAvailable() {
            DateTime dtLastCalibration = Library.Spettrofotometro.GetLastCalibration();
            DateTime dtCompare = DateTime.Now.AddHours(-12);
            if (dtLastCalibration < dtCompare)
                return false;
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

    }*/
}