using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Euroformulations4.Library.Data.Database
{
    public class CloudConnector
    {
        public enum eSpecialValue
        { 
            NULL = 0
        }

        private static CloudConnector cloudconnector = null;

        private string connetionString = "oCan8XsicZrDtNsUJICJNn8f7XxsHHdCKNMK/aMbcG23lHPRbxxgChqjbU3/xGil74fhygBLcKd/XLFR5D8EPbkfHUDRGPoBfVy1KED62T4=";  //"server=23.229.188.12;database=euroformulation;uid=efguest;pwd=azyd957c32A;";
        private MySqlConnection cnn;
        private string lastQueryError = "";

        #region INSTANCE MANAGEMENT
        private CloudConnector()
        {
            string connStringDecrypted = Library.Attivazioni.OpenSSLDecrypt(this.connetionString);
            cnn = new MySqlConnection(connetionString);

            for (int i = 0; i < 10; i++)
            {
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    i = 10;
                }
                else
                {
                    System.Threading.Thread.Sleep(5);
                }
            }
        }
        public static CloudConnector GetInstance()
        {
            if (cloudconnector != null)
            {
                return cloudconnector;
            }
            else
            {
                cloudconnector = new CloudConnector();
                if (cloudconnector.cnn.State != ConnectionState.Open) 
                {
                    cloudconnector = null;
                }
                return cloudconnector;
            }
        }
        public void CloseConnection()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception){}

            cnn = null;
        }
        #endregion

        #region PROPERTIES
        public string LastQueryError
        {
            get { return lastQueryError; }
        }
        #endregion

        #region QUERY MANAGEMENT
        private string ProcessInputValue(string valore)
        {
            if (valore.StartsWith("'")) { valore = valore.Substring(1); }
            if (valore.EndsWith("'")) { valore = valore.Substring(0, valore.Length - 1); }
            if (valore.Trim() == "")
            {
                return "NULL";
            }
            valore = valore.Replace("'", "''");
            return "'" + valore + "'";
        }
        private long ExecuteSQLQueryForInsert(string sql, Dictionary<string, byte[]> dataByte)
        {
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            if (dataByte != null)
            {
                foreach (KeyValuePair<string, byte[]> pair in dataByte)
                {
                    MySqlParameter fileContentParameter = new MySqlParameter(pair.Key, MySqlDbType.Blob, pair.Value.Length);
                    fileContentParameter.Value = pair.Value;
                    cmd.Parameters.Add(fileContentParameter);
                }
            }
            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }
        private int ExecuteSQLQueryForUpdate(string sql, Dictionary<string, byte[]> dataByte)
        {
            MySqlCommand cmd = new MySqlCommand(sql, cnn);
            if (dataByte != null)
            {
                foreach (KeyValuePair<string, byte[]> pair in dataByte)
                {
                    MySqlParameter fileContentParameter = new MySqlParameter(pair.Key, MySqlDbType.Blob, pair.Value.Length);
                    fileContentParameter.Value = pair.Value;
                    cmd.Parameters.Add(fileContentParameter);
                }   
            }
            return cmd.ExecuteNonQuery();
        }

        /*
         INSERISCE UN NUOVO RECORD TRAMITE COPPIE CHIAVE/VALORE (anche byte[] o NULL). Return: id riga inserita (o -1 if errors)
         */
        public long QueryInsert(string tableName, Dictionary<string, object> dicColumnValue)
        {
            lastQueryError = "";
            if (dicColumnValue.Keys.Count == 0) return -1;

            lock (cnn)
            {
                try
                {
                    string sql = "INSERT INTO " + tableName + " (";
                    string values = "";
                    int i = 0;
                    Dictionary<string, byte[]> dataByte = new Dictionary<string, byte[]>();

                    foreach (KeyValuePair<string, object> pair in dicColumnValue)
                    {
                        object obj = pair.Value;
                        if (obj.GetType() == typeof(string))
                        {
                            sql += " " + pair.Key + ",";
                            values += " " + ProcessInputValue(pair.Value.ToString()) + ",";
                        }
                        else if (obj.GetType() == typeof(eSpecialValue))
                        {
                            switch ((eSpecialValue)obj)
                            {
                                case eSpecialValue.NULL:
                                    {
                                        sql += " " + pair.Key + " = NULL,";
                                        break;
                                    }
                            }
                        }
                        else if (obj.GetType() == typeof(byte[]))
                        {
                            sql += " " + pair.Key + ",";
                            values += " ?data_" + i.ToString() + ",";
                            dataByte.Add("?data_" + i.ToString(), (byte[])pair.Value);
                        }
                    }
                    sql = sql.Substring(0, sql.Length - 1); //remove last ','
                    values = values.Substring(0, values.Length - 1); //remove last ','
                    sql = sql + " ) VALUES (" + values + " )";

                    long lID = ExecuteSQLQueryForInsert(sql, dataByte);
                    return lID;
                }
                catch (Exception ex)
                {
                    lastQueryError = ex.Message;
                    return -1;
                }
            }
        }

        /*
         * AGGIORNA UN NUOVO RECORD TRAMITE COPPIE CHIAVE/VALORE (anche byte[] o NULL). Return: numero di righe aggiornate (o -1 if errors)
        */
        public int QueryUpdate(string tableName, Dictionary<string, object> dicColumnValue, string condition)
        {
            lastQueryError = "";
            if (dicColumnValue.Keys.Count == 0) return -1;

            lock (cnn)
            {
                int affectedRows = -1;
                try
                {
                    string sql = "UPDATE " + tableName + " SET";
                    Dictionary<string, byte[]> dataByte = new Dictionary<string, byte[]>();
                    int i = 0;

                    foreach (KeyValuePair<string, object> pair in dicColumnValue)
                    {
                        object obj = pair.Value;
                        if (obj.GetType() == typeof(string))
                        {
                            sql += " " + pair.Key + " = " + ProcessInputValue(pair.Value.ToString()) + ",";
                        }
                        else if (obj.GetType() == typeof(eSpecialValue))
                        {
                            switch ((eSpecialValue)obj)
                            {
                                case eSpecialValue.NULL:
                                    {
                                        sql += " " + pair.Key + " = NULL,";
                                        break;
                                    }
                            }
                        }
                        else if (obj.GetType() == typeof(byte[]))
                        {
                            sql += " " + pair.Key + " = ?data_" + i.ToString() + ",";
                            dataByte.Add("?data_" + i.ToString(), (byte[])pair.Value);
                            i++;
                        }
                    }
                    sql = sql.Substring(0, sql.Length - 1); //remove last ','
                    if (condition.Trim() != "")
                    {
                        sql += " WHERE " + condition;
                    }

                    affectedRows = ExecuteSQLQueryForUpdate(sql, null);
                }
                catch (Exception ex)
                {
                    lastQueryError = ex.Message;
                    affectedRows = -1;
                }

                return affectedRows;
            }
        }

        /*
         *  ELIMINA UN INSIEME DI RECORD in base a una condizione. Return: numero di righe aggiornate (o -1 if errors)
         */
        public int QueryDelete(string tableName, string condition = "")
        {
            lastQueryError = "";
            if (condition.Trim() == "")
            {
                lastQueryError = "(custom) condition cannot be null";
                return -1;
            }

            lock (cnn)
            {
                int affectedRows = -1;

                try
                {
                    string sql = "DELETE FROM " + tableName;
                    if (condition.Trim() != "")
                    {
                        sql += " WHERE " + condition;
                    }

                    affectedRows = ExecuteSQLQueryForUpdate(sql, null);
                }
                catch (Exception ex)
                {
                    lastQueryError = ex.Message;
                    affectedRows = -1;
                }

                return affectedRows;
            }
        }

        /*
         * ESEGUE UNA QUERY DI SELEZIONE. Return: DataTable con le righe (o null if errors)
         */
        public DataTable SQLQuerySelect(string query)
        {
            lastQueryError = "";

            lock (cnn)
            {
                DataTable dt = null;
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    lastQueryError = ex.Message;
                    dt = null;
                }

                return dt;
            }
        }
        #endregion








        /*************************************************************************************************************/

        /*
        #region STATIC ATTRIBUTES
        private static string errors = "";
        #endregion

        private NpgsqlConnection connection = null;
        private string lastQueryError = "";
        private string password = "8635026Asd123";
        private Library.Data.Database.ClusterGenerator clustergen = Library.Data.Database.ClusterGenerator.GetInstance();

        
        */

        /*
       
        */

        /*
        #region PROPERTY
        public string Errors
        {
            get { return errors; }
        }
        public string LastQueryError
        {
            get { return lastQueryError; }
        }
        #endregion

        #region QUERY
        private string ProcessInputValue(string valore)
        {
            if (valore.StartsWith("'")) { valore = valore.Substring(1);}
            if (valore.EndsWith("'")) { valore = valore.Substring(0, valore.Length - 1); }
            valore = valore.Replace("'", "''");
            return "'" + valore + "'";
        }
        
        
        
        
        #endregion

        #region OPEN/CLOSE CONNECTION
        private void OpenConnection(string host, string database, int port, string password)
        {
            try
            {
                string connectionString = "Server=" + host + ";Port=" + port.ToString() + ";User Id=postgres;Password=" + password + ";Database=" + database + ";Pooling=False;";
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                errors += ";" + ex.Message;
            }
        }
        public void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                errors += ";" + ex.Message;
            }
            finally
            {
                connection = null;
            }
        }
        #endregion
        */
    }
}
