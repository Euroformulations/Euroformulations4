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
        iOne = 2,
        Cube = 3,
        SP62 = 4,

    }

    public enum eLetturaTipo
    { 
        Multipla = 0,
        Singola = 1
    }

    public class DispositiviManager
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private static Library.Data.Dispositivi.DispositivoBase dispositivoCurrent;
        private static eDispositiviTipo dispositivoCurrentTipo;
        private static Dictionary<int, string> dicDispositivi;

        public static void StartService()
        {
            dicDispositivi = new Dictionary<int, string>();
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.Spyder, lang.GetWord("device01"));
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.Select, lang.GetWord("device02"));
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.iOne, lang.GetWord("device07"));
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.Cube, lang.GetWord("device10"));
            dicDispositivi.Add((int)Library.Data.Dispositivi.eDispositiviTipo.SP62, lang.GetWord("device16"));

            Library.Data.SharedSettings settings = new Library.Data.SharedSettings();
            dispositivoCurrentTipo = GetDispositivoTipo(settings.GetValue("StrumentoLetturaDefault"));
            SetDispositivo(dispositivoCurrentTipo);
            
            dispositivoCurrent.StartService();
        }

        public static void CloseService()
        {
            if (dispositivoCurrent != null)
            {
                dispositivoCurrent.StopService();
            }
        }

        public static DispositivoBase GetDispositivo()
        {
            return dispositivoCurrent;
        }

        public static Dictionary<int, string> GetDispositiviDic()
        {
            return dicDispositivi;
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

        public static eDispositiviTipo DispositivoCurrentTipo() { return dispositivoCurrentTipo; }

        private static void SetDispositivo(eDispositiviTipo tipodispositivo)
        {
            switch (tipodispositivo)
            {
                case eDispositiviTipo.Select:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSelect(System.Windows.Forms.Application.StartupPath + "\\include\\Select.exe");
                        break;
                    }
                case eDispositiviTipo.Spyder:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSelect(System.Windows.Forms.Application.StartupPath + "\\include\\Select.exe");
                        break;
                    }
                case eDispositiviTipo.iOne:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoOne(System.Windows.Forms.Application.StartupPath + "\\include\\i1Pro.exe");
                        break;
                    }
                case eDispositiviTipo.Cube:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoCube();
                        break;
                    }
                case eDispositiviTipo.SP62:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSP62();
                        break;
                    }
                default:
                    {
                        dispositivoCurrent = new Library.Data.Dispositivi.DispositivoSelect(System.Windows.Forms.Application.StartupPath + "\\include\\Select.exe");
                        break;
                    }
            }
        }
    }

    
}
