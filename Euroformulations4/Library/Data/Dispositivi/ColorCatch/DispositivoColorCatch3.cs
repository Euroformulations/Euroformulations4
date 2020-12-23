using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Euroformulations4.Library.Data.Dispositivi
{
    //
    //           WARNING: DEPRECATED!!!
    //
    class DispositivoColorCatch3
    {
        private static Library.Language lang = Library.Language.GetInstance();

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

        public System.Windows.Forms.Form GetWindowManager(bool bTopLevel)
        {

            return null;
        }
    }
}
