using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library
{
    class Email
    {
        private int _id;
        private string _mittente;
        private DateTime _data;
        private string _oggetto;
        private string _corpo;
        private List<Ordine> _ordini;

        public Email()
        {
            _id = -1;
            _mittente = "";
            _data = DateTime.MinValue;
            _oggetto = "";
            _corpo = "";
            _ordini = new List<Ordine>();
        }
        public Email(int id, bool bLoadOrders = true)
        {
            _id = id;
            Library.Data.Database.DBConnector db = new Data.Database.DBConnector();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM email WHERE id = " + id.ToString());
            DataRow dr = dt.Rows[0];
            _mittente = dr["mittente"].ToString();
            _data = DateTime.Parse(dr["data"].ToString());
            _oggetto = dr["oggetto"].ToString();
            _corpo = dr["corpo"].ToString();
            if (bLoadOrders)
            {
                _ordini = Ordine.GetOrdini(id, db);
            }
            else
            {
                _ordini = new List<Ordine>();
            }

            db.CloseConnection();
        }
        public Email(int id, Library.Data.Database.DBConnector db, bool bLoadOrders = true)
        {
            DataTable dt = db.SQLQuerySelect("SELECT * FROM email WHERE id = " + id.ToString());
            DataRow dr = dt.Rows[0];
            _id = id;
            _mittente = dr["mittente"].ToString();
            _data = DateTime.Parse(dr["data"].ToString());
            _oggetto = dr["oggetto"].ToString();
            _corpo = dr["corpo"].ToString();
            if (bLoadOrders)
            {
                _ordini = Ordine.GetOrdini(id, db);
            }
            else
            {
                _ordini = new List<Ordine>();
            }
        }

        #region PROPERTIES
        public int ID { get { return _id; } }
        public string Mittente { set { _mittente = value; } get { return _mittente; } }
        public DateTime DataOra { set { _data = value; } get { return _data; } }
        public string Oggetto { set { _oggetto = value; } get { return _oggetto; } }
        public string Corpo { set { _corpo = value; } get { return _corpo; } }
        public List<Ordine> Ordini { set { _ordini = value; } get { return _ordini; } }
        public bool Executed
        {
            get
            {
                foreach (Ordine ordine in _ordini)
                {
                    if (!ordine.Executed) { return false; }
                }
                return true;
            }
        }
        #endregion

        public bool Save()
        {
            bool bSaved = false;
            Library.Data.Database.DBConnector db = null;
            try
            {
                db = new Data.Database.DBConnector();
                if (_id == -1)
                {
                    Dictionary<string, string> dicData = new Dictionary<string, string>();
                    dicData.Add("mittente", _mittente);
                    dicData.Add("data", _data.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
                    dicData.Add("oggetto", _oggetto);
                    dicData.Add("corpo", _corpo);

                    object oID = db.QueryInsert("email", dicData, "id");
                    _id = Convert.ToInt32(oID.ToString());

                    foreach (Ordine ordine in _ordini)
                    {
                        ordine.FKEmail = _id;
                        ordine.Save(db); 
                    }
                }
                else
                {
                    Dictionary<string, object> dicData = new Dictionary<string, object>();
                    dicData.Add("mittente", _mittente);
                    dicData.Add("data", _data.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
                    dicData.Add("oggetto", _oggetto);
                    dicData.Add("corpo", _corpo);

                    db.QueryUpdate("email", dicData, "id = " + _id.ToString());

                    foreach (Ordine ordine in _ordini){ ordine.Save(db); }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (db != null) { db.CloseConnection(); }
            }
            return bSaved;
        }

        public void DeleteEmail()
        {
            if (_id == -1) { return; }
            Library.Data.Database.DBConnector db = null;
            try
            {
                db = new Data.Database.DBConnector();

                foreach (Ordine ordine in _ordini)
                {
                    ordine.Delete(db);
                }
                db.QueryDelete("email", "id=" + _id);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (db != null) { db.CloseConnection(); }
            }
        }

        public static List<Email> GetEmail(Library.Data.Database.DBConnector db)
        {
            List<Email> lstEmail = new List<Email>();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM email order by data DESC");
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Email email = new Email(Convert.ToInt32(dr["id"].ToString()), db);
                    lstEmail.Add(email);
                }
                catch (Exception) { }
            }

            return lstEmail;
        }

        public static List<Email> GetEmailNoOrders(Library.Data.Database.DBConnector db)
        {
            List<Email> lstEmail = new List<Email>();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM email order by data DESC");
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Email email = new Email(Convert.ToInt32(dr["id"].ToString()), db, false);
                    lstEmail.Add(email);
                }
                catch (Exception) { }
            }

            return lstEmail;
        }
    }
}
