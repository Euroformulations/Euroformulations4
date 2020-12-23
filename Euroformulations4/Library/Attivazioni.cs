using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Management;
using System.Windows.Forms;
using System.Security.AccessControl;

namespace Euroformulations4.Library
{
    public class Attivazioni
    {
        
       
        

        #region FUNCTIONS
        private bool _basics = true;
        private bool _history = true;
        private bool _stampaEtichetta = true;
        private bool _macchineAutomatiche = true;
        private bool _customQuantityFormulation = true;
        private bool _formuleG_ML_ONCE = true;
        private bool _formulationRelatedTo = true;
        private bool _personalFormula = true;
        private bool _qualityControl = true;
        private bool _colorSearch = true;
        private bool _complementaryColors = true;
        private bool _clientManagement = true;
        private bool _statistics = true;
        private bool _listiniUnlimited = true;
        private bool _barcode = true;
        private bool _multidatabase = true;
        private bool _refillCustom = true;
        private bool _nuovoProdotto = true;
        private bool _fattoreCorrettivo = true;
        private bool _orderReceiver = true;
        private bool _freeDispense = true;
        #endregion

        #region ACTIVATED DATA
        public string IDEuroFormulationInCloud = "";
        public string CustomerName = "";
        #endregion

        public Attivazioni()
        {
        }

        #region PROPERTY
        public bool Act_Basics { get { return _basics; } }
        public bool Act_History { get { return _history; } }
        public bool Act_StampaEtichetta { get { return _stampaEtichetta; } }
        public bool Act__MacchineAutomatiche { get { return _macchineAutomatiche; } }
        public bool Act_CustomQuantityFormulation { get { return _customQuantityFormulation; } }
        public bool Act_Formule_G_ML_ONCE { get { return _formuleG_ML_ONCE; } }
        public bool Act__formulationRelatedTo { get { return _formulationRelatedTo; } }
        public bool Act_PersonalFormula { get { return _personalFormula; } }
        public bool Act_QualityControl { get { return _qualityControl; } }
        public bool Act_ColorSearch { get { return _colorSearch; } }
        public bool Act_FreeDispense { get { return _freeDispense; } }
        public bool Act_ComplementaryColors { get { return _complementaryColors; } }
        public bool Act_ClientManagement { get { return _clientManagement; } }
        public bool Act_Statistics { get { return _statistics; } }
        public bool Act_ListiniUnlimited { get { return _listiniUnlimited; } }
        public bool Act_Barcode { get { return _barcode; } }
        public bool Act_MultiDB { get { return _multidatabase; } }
        public bool Act_RefillCustom { get { return _refillCustom; } }
        public bool Act_NuovoProdotto { get { return _nuovoProdotto; } }
        public bool Act_FattoreCorrettivo { get { return _fattoreCorrettivo; } }
        public bool Act_OrderReceiver { get { return _orderReceiver; } }
        
        #endregion
        
    }
}
