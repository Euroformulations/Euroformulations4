using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public enum eDispositiviTipo
    {
        Spyder = 0,
        Select = 1,
        ColorCatch3 = 2
    }

    public class DispositiviManager
    {
        private static Library.Data.Dispositivi.IDispositivo dispositivoCurrent;
        private static eDispositiviTipo dispositivoCurrentTipo;
        private static Dictionary<int, string> dicDispositivi;

        public static void Init()
        {
            dicDispositivi = new Dictionary<int, string>();
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.Spyder, "(TR) Spyder");
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.Select, "(TR) Select");
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.ColorCatch3, "(TR) Color Catch 3");

            Library.Data.Settings settings = new Library.Data.Settings();
            dispositivoCurrentTipo = GetDispositivoTipo(settings.GetValue("StrumentoLetturaDefault"));
            SetDispositivo(dispositivoCurrentTipo);
        }

        public static double[] ReadXYZLab()
        {
            return dispositivoCurrent.Read_XYZLab();
        }

        public static bool bCanRead()
        {
            return dispositivoCurrent.CanRead();
        }

        public static Dictionary<int, string> GetDispositiviDic()
        {
            return dicDispositivi;
        }

        public static System.Windows.Forms.Form GetCurrentWindowManager()
        {
            return dispositivoCurrent.GetWindowManager();
        }

        public static eDispositiviTipo GetDispositivoTipo(string dispositivoCode)
        {
            foreach (eDispositiviTipo eTipodispositivo in Enum.GetValues(typeof(eDispositiviTipo)))
            {
                if (((int)eTipodispositivo).ToString() == dispositivoCode)
                {
                    return eTipodispositivo;
                }
            }
            return eDispositiviTipo.Spyder;
        }

        private static void SetDispositivo(eDispositiviTipo tipodispositivo)
        {
            switch (tipodispositivo)
            {
                case eDispositiviTipo.Select:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSpyder();
                        break;
                    }
                case eDispositiviTipo.Spyder:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSpyder();
                        break;
                    }
                case eDispositiviTipo.ColorCatch3:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoColorCatch3();
                        break;
                    }
            }
        }

       
    }

    
}
