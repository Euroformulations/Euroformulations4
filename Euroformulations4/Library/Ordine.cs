using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Euroformulations4.Library
{
    class Ordine
    {
        private int _id;
        private int _fkemail;
        private bool _executed;
        private double _ciel, _ciea, _cieb;
        private string _destinazione;
        private string _colorname;
        private string _colorchart;
        private string _prodotto;
        private string _uso;
        private string _codcard;


        public Ordine()
        {
            _id = -1;
            _executed = false;
            _ciel = 0; _ciea = 0; _cieb = 0;
            _destinazione = "";
            _colorname = "";
            _colorchart = "";
            _prodotto = "";
            _uso = "";
            _fkemail = -1;
            _codcard = "";
        }

        public Ordine(int id)
        {
            _id = id;
            Library.Data.Database.DBConnector db = new Data.Database.DBConnector();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM ordine WHERE id = " + id.ToString());
            DataRow dr = dt.Rows[0];
            _executed = dr["executed"].ToString() == "1";
            _ciel = Convert.ToDouble(dr["ciel"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            _ciea = Convert.ToDouble(dr["ciea"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            _cieb = Convert.ToDouble(dr["cieb"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            _destinazione = dr["destinazione"].ToString();
            _colorname = dr["colorname"].ToString();
            _colorchart = dr["colorchart"].ToString();
            _prodotto = dr["system"].ToString();
            _uso = dr["use"].ToString();
            _fkemail = Convert.ToInt32(dr["fkemail"].ToString());
            _codcard = dr["codcard"].ToString();
            db.CloseConnection();
        }

        #region PROPERTIES
        public int ID { get { return _id; } }
        public bool Executed { set { _executed = value; } get { return _executed; } }
        public double CIEL { set { _ciel = value; } get { return _ciel; } }
        public double CIEa { set { _ciea = value; } get { return _ciea; } }
        public double CIEb { set { _cieb = value; } get { return _cieb; } }
        public string Destinazione { set { this._destinazione = value; } get { return _destinazione; } }
        public string Tinta { set { this._colorname = value; } get { return _colorname; } }
        public string CColori { set { this._colorchart = value; } get { return _colorchart; } }
        public string Prodotto { set { this._prodotto = value; } get { return _prodotto; } }
        public string Uso { set { this._uso = value; } get { return _uso; } }
        public int FKEmail { set { this._fkemail = value; } get { return _fkemail; } }
        public string CodCard { set { this._codcard = value; } get { return _codcard; } }
        public bool ReadyToDispense
        { 
            get
            {
                if ((_uso != "") && (_prodotto != "") && (_colorchart != "") && (_colorname != ""))
                {
                    return true;
                }
                return false;
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
                bSaved = Save(db);
            }
            catch(Exception)
            {
            }
            finally
            {
                if (db != null) { db.CloseConnection(); }
            }
            return bSaved;
        }

        public bool Save(Library.Data.Database.DBConnector db)
        {
            bool bSaved = false;
            try
            {
                if (_id == -1)
                {
                    Dictionary<string, string> dicData = new Dictionary<string, string>();
                    dicData.Add("executed", _executed ? "1" : "0");
                    dicData.Add("ciel", _ciel.ToString().Replace(",", "."));
                    dicData.Add("ciea", _ciea.ToString().Replace(",", "."));
                    dicData.Add("cieb", _cieb.ToString().Replace(",", "."));
                    dicData.Add("destinazione", _destinazione);
                    dicData.Add("colorname", _colorname);
                    dicData.Add("colorchart", _colorchart);
                    dicData.Add("system", _prodotto);
                    dicData.Add("use", _uso);
                    dicData.Add("fkemail", _fkemail.ToString());
                    dicData.Add("codcard", _codcard.ToString());

                    object oID = db.QueryInsert("ordine", dicData, "id");
                    _id = Convert.ToInt32(oID.ToString());
                }
                else
                {
                    Dictionary<string, object> dicData = new Dictionary<string, object>();
                    dicData.Add("executed", _executed ? "1" : "0");
                    dicData.Add("ciel", _ciel.ToString().Replace(",", "."));
                    dicData.Add("ciea", _ciea.ToString().Replace(",", "."));
                    dicData.Add("cieb", _cieb.ToString().Replace(",", "."));
                    dicData.Add("destinazione", _destinazione);
                    dicData.Add("colorname", _colorname);
                    dicData.Add("colorchart", _colorchart);
                    dicData.Add("system", _prodotto);
                    dicData.Add("use", _uso);
                    dicData.Add("fkemail", _fkemail.ToString());
                    dicData.Add("codcard", _codcard.ToString());

                    db.QueryUpdate("ordine", dicData, "id = " + _id.ToString());
                }
                bSaved = true;
            }
            catch (Exception){ }
            return bSaved;
        }

        public static List<Ordine> GetOrdini(int IDEmail, Library.Data.Database.DBConnector db)
        {
            List<Ordine> lstOrdini = new List<Ordine>();
            DataTable dt = db.SQLQuerySelect("SELECT * FROM ordine WHERE fkemail = " + IDEmail.ToString());
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Ordine ordine = new Ordine();
                    ordine._id = Convert.ToInt32(dr["id"].ToString());
                    ordine._executed = dr["executed"].ToString() == "1";
                    ordine._ciel = Convert.ToDouble(dr["ciel"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    ordine._ciea = Convert.ToDouble(dr["ciea"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    ordine._cieb = Convert.ToDouble(dr["cieb"].ToString().Replace(",", "."), CultureInfo.InvariantCulture);
                    ordine._destinazione = dr["destinazione"].ToString();
                    ordine._colorname = dr["colorname"].ToString();
                    ordine._colorchart = dr["colorchart"].ToString();
                    ordine._prodotto = dr["system"].ToString();
                    ordine._uso = dr["use"].ToString();
                    ordine._fkemail = Convert.ToInt32(dr["fkemail"].ToString());
                    ordine._codcard = dr["codcard"].ToString();

                    lstOrdini.Add(ordine);
                }
                catch (Exception) { }
            }
            
            return lstOrdini;
        }

        public void Delete(Library.Data.Database.DBConnector db)
        {
            if (_id != -1)
            {
                db.QueryDelete("ordine", "id=" + _id);
            }
        }
    }
}
