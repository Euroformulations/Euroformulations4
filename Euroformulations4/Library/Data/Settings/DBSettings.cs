using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library.Data
{
    class DBSettings
    {
        private static Language lang = Language.GetInstance();
        private static Dictionary<string, string> _data = null;
        private static Dictionary<string, byte[]> value_data = null;
        private static List<string> _keyMod = new List<string>();
        private static string _errorSave = "";
        private static Library.Data.Database.DBConnector db;

        public DBSettings()
        {
            if (_data == null)
            {
                 db = new Database.DBConnector();
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
                Ensure_Key_Presence("dbmanufacturername", "ef_base");
                Ensure_Key_Presence("personalized_logo", "");
                Ensure_Key_Presence("personalized_logoLoading", "");
                Ensure_Key_Presence("personalized_logoCenter", "");
                Ensure_Key_Presence("dt_database_creation", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Ensure_Key_Presence("ListinoDefault", "");
                Ensure_Key_Presence("drivermachine", "");
                Ensure_Key_Presence("resizemainwindow", "1");
                Ensure_Key_Presence("IDMachineOunceEdit", "-1");
                Ensure_Key_Presence("DEFormulaLimit", "3");
                Ensure_Key_Presence("sync_clienti", DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss"));
                Ensure_Key_Presence("sync_groups", "");
                Ensure_Key_Presence("showlabelemail", "");
                Ensure_Key_Presence("dbcode", "");
            }

            DataTable dt = db.SQLQuerySelect("SELECT * FROM settings");
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
                DataTable dt = db.SQLQuerySelect("SELECT * FROM settings WHERE key = '" + key + "'");
                if (dt.Rows.Count == 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("key", "'" + key + "'");
                    data.Add("value", "'" + defaultValue + "'");
                    db.QueryInsert("settings", data);
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
                Dictionary<string, string> data;
                Dictionary<string, object> data2;
                foreach (string sKeyMod in _keyMod)
                {
                    if (currentDBData.ContainsKey(sKeyMod))
                    {
                        //update value
                        data2 = new Dictionary<string, object>();
                        data2.Add("value", "'" + _data[sKeyMod] + "'");
                        db.QueryUpdate("settings", data2, "key = '" + sKeyMod + "'");
                    }
                    else
                    {
                        //new key + value
                        data = new Dictionary<string, string>();
                        data.Add("value", "'" + _data[sKeyMod] + "'");
                        db.QueryInsert("settings", data);
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
