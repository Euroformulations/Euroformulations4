using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euroformulations4.Library
{
    using System.Data.OleDb;

    public class DBConnect
    {

        string StrConn;
        OleDbConnection objconnole;
        OleDbCommand objcommole;
        public int Lastid;
        public void connect(string percorso)
        {
            try
            {
                StrConn = "Provider=PostgreSQL OLE DB Provider;Data Source=localhost;location=" + percorso + ";User ID=postgres;password=8635026Asd123;";
                objconnole = new OleDbConnection(StrConn);
                objconnole.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Errore Conn DB: " + ex.Message);
            }
        }
        public void disconnect()
        {
            try
            {
                objconnole.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Si è verificato un errore: " + ex.Message);
            }
        }

        public void sqlview(string sqlview, ref OleDbDataReader DataReader)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand(sqlview, objconnole);
                DataReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Si è verificato un errore: " + ex.Message);
            }
        }

        public void sqlexe(string sqlexe)
        {
            int qres = 0;
            objcommole = new OleDbCommand(sqlexe, objconnole);
            try
            {
                qres = objcommole.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Si è verificato un errore: " + ex.Message);
            }

            //If qres <> 1 Then
            //MsgBox("Errore nell'esecuzione del comando " & sqlexe)
            //End If
        }
    }
}
