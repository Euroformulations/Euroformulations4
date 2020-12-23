using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library.Data.Dispositivi
{
    public abstract class DispositivoBase
    {
        protected bool bReadReflectance = false;

        public event DatiRicevutiEventHandler DatiRicevuti = null;
        public delegate void DatiRicevutiEventHandler(string s);

        public event ErroreDispositivoEventHandler ErroreDispositivo = null;
        public delegate void ErroreDispositivoEventHandler(string s);

        #region CHIAMATI DA SUPER
        protected virtual void OnDatiRicevuti(string s)
        {
            if (DatiRicevuti != null)
            {
                DatiRicevuti(s);
            }
        }
        protected virtual void OnErroreDispositivo(string error)
        {
            if (ErroreDispositivo != null)
            {
                ErroreDispositivo(error);
            }
        }
        #endregion

        #region SERVICE MANAGEMENT
        public abstract void StartService();
        public abstract void StopService();
        public abstract bool IsServiceRunning();
        #endregion

        #region DATA MANAGEMENT
        public bool ReflectanceReader { get { return bReadReflectance; } }
        public bool CIELabReader { get { return !bReadReflectance; } }
        public abstract void ReadRequest();
        public abstract bool Calibrato();
        public abstract System.Windows.Forms.Form GetWindowManager(bool bTopLevel, bool bShowConnect);
        #endregion
    }
}
