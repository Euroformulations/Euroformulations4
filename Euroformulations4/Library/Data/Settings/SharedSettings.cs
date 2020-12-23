using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library.Data
{
    class SharedSettings
    {
        private static Language lang = Language.GetInstance();
        private static Dictionary<string, string> _data = null;
        private static Dictionary<string, byte[]> value_data = null;
        private static List<string> _keyMod = new List<string>();
        private static string _errorSave = "";
        private static Library.Data.Database.DBConnector db;

        public SharedSettings()
        {
            if (_data == null)
            {
                db = new Database.DBConnector("ef_settings");
                _data = _LoadData(true);
            }
        }

        private static Dictionary<string, string> _LoadData(bool ensureKeyPresence)
        {
            Dictionary<string, string>  dic = new Dictionary<string, string>();
            value_data = new Dictionary<string, byte[]>();

            //INSERIRE QUI TUTTE LE CHIAVI CON I VALORI DI DEFAULT (per gli altri va controllata l'esistenza della chiave!)
            if (ensureKeyPresence)
            {
                Ensure_Key_Presence("Timer", "10000");
                Ensure_Key_Presence("ModeSave", "NO");
                Ensure_Key_Presence("WindowMaximized", "0");
                Ensure_Key_Presence("PosX", "10");
                Ensure_Key_Presence("PosY", "10");
                Ensure_Key_Presence("Height", "944");
                Ensure_Key_Presence("Width", "1294");
                Ensure_Key_Presence("listinoformulativo", "");  //deprecated
                Ensure_Key_Presence("DecimalNumber", "3");
                Ensure_Key_Presence("HistoryView", "150");
                Ensure_Key_Presence("DeltaWarning", "0");
                Ensure_Key_Presence("BarCodeStatus", "NO");
                Ensure_Key_Presence("Multiformulations", "yes");
                Ensure_Key_Presence("DefaultUnit", "MILLILITER");
                Ensure_Key_Presence("LastCalibration", DateTime.MinValue.ToString());
                Ensure_Key_Presence("ListinoDefault", "");
                Ensure_Key_Presence("stampa", "");
                Ensure_Key_Presence("drivermachine", "");
                Ensure_Key_Presence("OunceDefault", "31.24/384");
                Ensure_Key_Presence("StrumentoLetturaDefault", "0");  //deprecated
                Ensure_Key_Presence("DeviceReadType", "1");
                Ensure_Key_Presence("LastCubeCalibration", DateTime.MinValue.ToString());
                Ensure_Key_Presence("CubeCOMPort", "COM4");
                Ensure_Key_Presence("EF3Path", "");
                Ensure_Key_Presence("SettingsPassword", "admin");
                Ensure_Key_Presence("MultiErogazione", "0");
                Ensure_Key_Presence("LastSP62Calibration", DateTime.MinValue.ToString());
                Ensure_Key_Presence("SP62COMPort", "COM8");
                Ensure_Key_Presence("MetodoLetturaLAB", "0");
                Ensure_Key_Presence("VersioneSW", "5.0.0");
            }

            DataTable dt = db.SQLQuerySelect("SELECT * FROM base_settings");
            foreach (DataRow dr in dt.Rows)
            {
                dic.Add(dr["key"].ToString(), dr["value"].ToString());
                if (dr["value_data"].ToString() == "")
                {
                    value_data.Add(dr["key"].ToString(), null);
                }
                else
                {
                    value_data.Add(dr["key"].ToString(), (Byte[]) dr["value_data"]);
                }
            }

            return dic;
        }

        private static void Ensure_Key_Presence(string key, string defaultValue)
        {
            try
            {
                DataTable dt = db.SQLQuerySelect("SELECT * FROM base_settings WHERE key = '" + key + "'");
                if (dt.Rows.Count == 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("key", "'" + key + "'");
                    data.Add("value", "'" + defaultValue + "'");
                    db.QueryInsert("base_settings", data);
                }
            }
            catch (Exception)
            { 
                
            }
        }

        public string GetValue(string key, bool createIFNotExists = false)
        {
            if (_data.ContainsKey(key))
                return _data[key];
            else
            {
                if (!createIFNotExists) throw new Exception(lang.GetWord("data_not_found"));
                SetValue(key, "");
                return _data[key];
            }
        }

        public byte[] GetValueData(string key)
        {
            if (value_data.ContainsKey(key))
                return value_data[key];
            else
            {
                throw new Exception(lang.GetWord("data_not_found"));
                
            }
        }

        public bool HasKey(string key)
        {
            return _data.ContainsKey(key);
        }

        public void SetValue(string key, string value)
        {
            if (_data.ContainsKey(key))
            {
                _data[key] = value;
                if (!_keyMod.Contains(key)) _keyMod.Add(key);
            }
            else
            {
                _data.Add(key, value);
                _keyMod.Add(key);
            }
        }

        public bool Save()  //actual not for value_data
        {
            if (_data == null) return true;
            if (_keyMod.Count == 0)
            {
                db.CloseConnection();
                _data = null;
                return true;
            } 

            Dictionary<string, string> currentDBData = _LoadData(false);

            try
            {
                Dictionary<string, object> data;
                foreach (string sKeyMod in _keyMod)
                {
                    if (currentDBData.ContainsKey(sKeyMod))
                    {
                        //update value
                        data = new Dictionary<string, object>();
                        data.Add("value", "'" + _data[sKeyMod] + "'");
                        db.QueryUpdate("base_settings", data, "key = '" + sKeyMod + "'");
                    }
                    else
                    { 
                        //new key + value
                        Dictionary<string, string>  data2 = new Dictionary<string, string>();
                        data2.Add("key", "'" + sKeyMod + "'");
                        data2.Add("value", "'" + _data[sKeyMod] + "'");
                        db.QueryInsert("base_settings", data2);
                    }
                }
                _keyMod.Clear();
                _data = null;
            }
            catch (Exception ex)
            {
                _errorSave = ex.Message;
                db.CloseConnection();
                _data = null;
                return false;
            }
            db.CloseConnection();
            _data = null;
            return true;
        }

        public string ErrorSave
        {
            get 
            {
                return _errorSave;
            }
        }

    }
}
