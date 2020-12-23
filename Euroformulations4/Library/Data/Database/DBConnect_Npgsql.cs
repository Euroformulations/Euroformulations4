using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Npgsql;
using System.Data; 

namespace Euroformulations4.Library.Data.Database
{
    class DBConnect_Npgsql
    {
        private static Library.Language lang = Library.Language.GetInstance();
        private Library.Data.Database.ClusterGenerator clustergen = Library.Data.Database.ClusterGenerator.GetInstance();
        string StrConn;
        NpgsqlConnection connessione;
        NpgsqlCommand command;
        

        public void connect(string Database)
        {
            try
            {
                int port = 49999;
                if (!Library.Data.Database.ClusterGenerator.Current_EuroSQL)
                {
                    port = clustergen.Port;
                }
                connessione = DBConnector.GetConnection(GVar.ServerIP, Database, port.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib01") + " " + ex.Message);
            }
        }

        public void disconnect()
        {
            try
            {
                if (connessione != null)
                { 
                    connessione.Close(); 
                }   
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib02") + " " + ex.Message);
            }
        }

        public void sqlview_ErrorSafe(string sqlview, ref NpgsqlDataReader DataReader)
        {
            try
            {
                command = new NpgsqlCommand(sqlview, connessione);
                DataReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
            }
        }

        public void sqlview_ErrorSafe_Timeout(string sqlview, ref NpgsqlDataReader DataReader, int secondTimeout = 300)
        {
            try
            {
                command = new NpgsqlCommand(sqlview, connessione);
                command.CommandTimeout = secondTimeout;
                DataReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
            }
        }

        public void sqlview(string sqlview, ref NpgsqlDataReader DataReader)
        {
            command = new NpgsqlCommand(sqlview, connessione);
            DataReader = command.ExecuteReader();
        }

        public void SQLExe_ErrorSafe(string sqlexe)
        {
            int qres = 0;
            try
            {
                command = new NpgsqlCommand(sqlexe, connessione);
                qres = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
            }
        }


        public void SQLExe_ErrorSafe_Timeout(string sqlexe, int secondTimeout = 300)
        {
            int qres = 0;
            try
            {
                command = new NpgsqlCommand(sqlexe, connessione);
                command.CommandTimeout = secondTimeout;
                qres = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
            }
        }

        public int SQLExe_ErrorSafe_Int(string sqlexe)
        {
            int qres = 0;
            try
            {
                command = new NpgsqlCommand(sqlexe, connessione);
                qres = command.ExecuteNonQuery();
                return qres;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
                return -1;
            }
        }

        public void SQLExe(string sql)
        {
            int qres = 0;
            command = new NpgsqlCommand(sql, connessione);
            qres = command.ExecuteNonQuery();
        }

        public object SQLExecuteScalar(string sql)
        {
            command = new NpgsqlCommand(sql, connessione);
            object res = command.ExecuteScalar();
            return res;
        }

        public object SQLExecuteScalar_ErrorSafe(string sql)
        {
            try
            {
                command = new NpgsqlCommand(sql, connessione);
                object res = command.ExecuteScalar();
                return res;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(lang.GetWord("dblib03") + " " + ex.Message);
                return null;
            }
        }

        

        

    }
}
