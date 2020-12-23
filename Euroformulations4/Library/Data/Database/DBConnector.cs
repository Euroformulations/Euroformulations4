using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace Euroformulations4.Library.Data.Database
{
    public class DBConnector
    {
        #region STATIC ATTRIBUTES
        private static string errors = "";
        #endregion

        private NpgsqlConnection connection = null;
        private string lastQueryError = "";
        private Library.Data.Database.ClusterGenerator clustergen = Library.Data.Database.ClusterGenerator.GetInstance();

        public enum eSpecialValue
        { 
            NULL = 0
        }

        public DBConnector()
        {
            try
            {
                if (connection == null)
                {
                    int port = 49999;
                    if (!Library.Data.Database.ClusterGenerator.Current_EuroSQL)
                    {
                        port = clustergen.Port;
                    }
                    OpenConnection(GVar.ServerIP, GVar.Database, port);
                }
            }
            catch (Exception ex)
            { 
                errors += ";" + ex.Message;
            }
        }
        public DBConnector(string host, string database)
        {
            try
            {
                if (connection == null)
                {
                    int port = 49999;
                    if (!Library.Data.Database.ClusterGenerator.Current_EuroSQL)
                    {
                        port = clustergen.Port;
                    }
                    OpenConnection(host, database, port);
                }
            }
            catch (Exception ex)
            {
                errors += ";" + ex.Message;
            }
        }
        public DBConnector(string database)
        {
            try
            {
                if (connection == null)
                {
                    int port = 49999;
                    if (!Library.Data.Database.ClusterGenerator.Current_EuroSQL)
                    {
                        port = clustergen.Port;
                    }
                    OpenConnection(GVar.ServerIP, database, port);
                }
            }
            catch (Exception ex)
            {
                errors += ";" + ex.Message;
            }
        }

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
        public void QueryInsert(string tableName, Dictionary<string, string> dicColumnValue)
        {
            lastQueryError = "";

            if (dicColumnValue.Keys.Count == 0) return;

            lock (connection)
            {
                try
                {
                    if (connection == null) { return; }
                    string sql = "INSERT INTO " + tableName + " (";
                    string values = "";
                    foreach (KeyValuePair<string, string> pair in dicColumnValue)
                    {
                        sql += " " + pair.Key + ",";
                        values += " " + ProcessInputValue(pair.Value) + ",";
                    }
                    sql = sql.Substring(0, sql.Length - 1); //remove last ','
                    values = values.Substring(0, values.Length - 1); //remove last ','
                    sql = sql + " ) VALUES (" + values + " )";
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }
            }
        }
        public void QueryInsert(string tableName, Dictionary<string, object> dicColumnValue)
        {
            lastQueryError = "";

            if (dicColumnValue.Keys.Count == 0) return;

            lock (connection)
            {
                try
                {
                    if (connection == null) { return; }
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
                        else if (obj.GetType() == typeof(byte[]))
                        {
                            sql += " " + pair.Key + ",";
                            values += " @data_" + i.ToString() + ",";
                            dataByte.Add("@data_" + i.ToString(), (byte[])pair.Value);
                            i++;
                        }   
                    }
                    sql = sql.Substring(0, sql.Length - 1); //remove last ','
                    values = values.Substring(0, values.Length - 1); //remove last ','
                    sql = sql + " ) VALUES (" + values + " )";
                    
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    foreach (KeyValuePair<string, byte[]> pair in dataByte)
                    {
                        command.Parameters.Add(pair.Key, NpgsqlTypes.NpgsqlDbType.Bytea, pair.Value.Length).Value = pair.Value;
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }
            }
        }
        public object QueryInsert(string tableName, Dictionary<string, string> dicColumnValue, string ReturnedFieldName)
        {
            lastQueryError = "";
            if (dicColumnValue.Keys.Count == 0) return null;

            lock (connection)
            {
                try
                {
                    if (connection == null) { return null; }
                    string sql = "INSERT INTO " + tableName + " (";
                    string values = "";
                    foreach (KeyValuePair<string, string> pair in dicColumnValue)
                    {
                        sql += " " + pair.Key + ",";
                        values += " " + ProcessInputValue(pair.Value) + ",";
                    }
                    sql = sql.Substring(0, sql.Length - 1); //remove last ','
                    values = values.Substring(0, values.Length - 1); //remove last ','
                    sql = sql + " ) VALUES (" + values + " ) RETURNING " + ReturnedFieldName;
                    NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                    return null;
                }
            }
        }
        
        public int QueryUpdate(string tableName, Dictionary<string, object> dicColumnValue, string condition)
        {
            lastQueryError = "";

            if (dicColumnValue.Keys.Count == 0) return -1;

            lock (connection)
            {
                int affectedRows = -1;

                try
                {
                    int i = 0;
                    Dictionary<string, byte[]> dataByte = new Dictionary<string, byte[]>();
                    string query = "UPDATE " + tableName + " SET";

                    foreach (KeyValuePair<string, object> pair in dicColumnValue)
                    {
                        object obj = pair.Value;
                        if (obj.GetType() == typeof(string))
                        {
                            query += " " + pair.Key + " = " + ProcessInputValue(pair.Value.ToString()) + ",";
                        }
                        else if (obj.GetType() == typeof(eSpecialValue))
                        {
                            switch ((eSpecialValue)obj)
                            {
                                case eSpecialValue.NULL:
                                    {
                                        query += " " + pair.Key + " = NULL,";
                                        break;
                                    }
                            }
                        }
                        else if (obj.GetType() == typeof(byte[]))
                        {
                            query += " " + pair.Key + " = @data_" + i.ToString() + ",";
                            dataByte.Add("@data_" + i.ToString(), (byte[])pair.Value);
                            i++;
                        } 
                    }
                    query = query.Substring(0, query.Length - 1); //remove last ','
                    if (condition.Trim() != "")
                    {
                        query += " WHERE " + condition;
                    }

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    foreach (KeyValuePair<string, byte[]> pair in dataByte)
                    {
                        command.Parameters.Add(pair.Key, NpgsqlTypes.NpgsqlDbType.Bytea, pair.Value.Length).Value = pair.Value;
                    }
                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }

                return affectedRows;
            }
        }
        public int QueryDelete(string tableName, string condition = "")
        {
            lastQueryError = "";

            lock (connection)
            {
                int affectedRows = -1;

                try
                {
                    string query = "DELETE FROM " + tableName;
                    if (condition.Trim() != "")
                    {
                        query += " WHERE " + condition;
                    }

                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }

                return affectedRows;
            }
        }
        public DataTable SQLQuerySelect(string query)
        {
            lastQueryError = "";

            lock (connection)
            {
                DataTable dt = null;

                try
                {
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    
                    dt = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }

                return dt;
            }
        }
        public int SQLQuery_AffectedRows(string query)
        {
            lastQueryError = "";

            lock (connection)
            {
                int IDFieldValue = -1;

                try
                {
                    NpgsqlCommand command = new NpgsqlCommand(query, connection);
                    IDFieldValue = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    errors += ";" + ex.Message;
                    lastQueryError = ex.Message;
                }

                return IDFieldValue;
            }
        }
        #endregion

        #region OPEN/CLOSE CONNECTION
        private void OpenConnection(string host, string database, int port)
        {
            try
            {
                connection = GetConnection(host, database, port.ToString());
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

        public static NpgsqlConnection GetConnection(string host, string database, string port)
        {
            NpgsqlConnection connection = null;
            string[] vPassword = Licenze.Internal_DB_Password();
            try
            {
                string connectionString = "Server=" + host + ";Port=" + port.ToString() + ";User Id=postgres;Password=" + vPassword.Last() + ";Database=" + database + ";Pooling=False;CommandTimeout=60";
                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }
            catch (NpgsqlException npgsqlEx)
            {
                //connect with old password, then update with last
                for(int i=0; i< (vPassword.Length - 1); i++)
                {
                    string oldPassword = vPassword[i];
                    try
                    {
                        connection = new NpgsqlConnection("Server=" + host + ";Port=" + port.ToString() + ";User Id=postgres;Password=" + oldPassword + ";Database=" + database + ";Pooling=False;");
                        connection.Open();
                        if(connection.State == ConnectionState.Open)
                        {
                            //change password
                            NpgsqlCommand command = new NpgsqlCommand(
                                "ALTER USER postgres with encrypted password '" + vPassword.Last() + "'", 
                                connection);
                            command.ExecuteNonQuery();

                            //close current connection
                            connection.Close();

                            //open new connection
                            connection = new NpgsqlConnection("Server=" + host + ";Port=" + port.ToString() + ";User Id=postgres;Password=" + vPassword.Last() + ";Database=" + database + ";Pooling=False;");
                            connection.Open();

                            i = vPassword.Length;
                        }
                    }
                    catch(NpgsqlException cnnEx){}
                }
            }
            
            
            return connection;
        }

    }
}
