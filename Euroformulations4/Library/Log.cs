using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net;
using System.Globalization;

namespace Euroformulations4.Library
{
    /*
     CLASSE DEPRECATA - PROBLEMI DI SALVATAGGIO FILE IN CARTELLA PROTETTA DA ACCESSI IN SCRITTURA
     * 
     * 
     * Questa classe gestisce il salvataggio dei messaggi informativi utili all'analisi del comportamento dinamico (tipicamente errori).
     * Se il file di log è più vecchio di 60 giorni: da 60 a 90 giorni tenta di mandarlo in cloud. Se ci riesce: in locale lo svuota (tranne gli ultimi 100-110).
     * In ogni caso, passati 90 giorni il sistema svuota il file di log (tranne gli ultimi 100-110).
     */
    public class Log
    {
        /*
        private static Log log = null;
        private string path;
        private DateTime dtCreation;
        private bool bUsable = false;

        private Log()
        {
            try
            {
                path = System.Windows.Forms.Application.StartupPath + "/ef.log";
                if (!System.IO.File.Exists(this.path))
                {
                    System.IO.File.Create(this.path);
                }
                this.dtCreation = System.IO.File.GetCreationTime(this.path);
                this.bUsable = true;
            }
            catch (Exception) { }
        }
        public static Log GetInstance()
        {
            if (log == null)
            {
                log = new Log();
            }
            return log;
        }
        public void WriteLog(string message)
        {
            if (!bUsable) { return; }
            try
            {
                string sDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

                TextWriter tw = new StreamWriter(this.path, true);
                tw.WriteLine(sDate + ": " + message);
                tw.Close();
            }
            catch (Exception){}
        }
        public void LogFTPCheckUpload()
        {
            DateTime dtNow = DateTime.Now;
            int totalDays = (dtNow - dtCreation).Days;
            if (totalDays > 60)
            {
                if (totalDays <= 90)
                {
                    if (TrySendFTP())
                    {
                        ClearLogFile();
                    }
                }
                else
                {
                    ClearLogFile();
                }
            }
        }  //NOTE: da richiamare 1 sola volta all'avvio del software
        
        #region INTERNAL FUNCTION
        private static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (var stream = client.OpenRead("http://www.euroformulations.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        private bool TrySendFTP()
        {
            if (!CheckForInternetConnection()) { return false; }

            try
            {
                List<string> logs = GetLastHundredLogs();

                //save log-temp file to temp folder
                if (!GVar.appIsRunning) { return false; }
                string tempPath = System.IO.Path.GetTempPath() + "efLog_temp.txt";
                if (File.Exists(tempPath)) { File.Delete(tempPath); }
                File.WriteAllLines(tempPath, logs);

                //send log-temp file via ftp
                string sFTPHost = "ftp://ftp.eurocolori.com";
                string sFTPUser = "dataef4@eurocolori.com";
                string sFTPPassword = "8635026Asd123";
                string sFTPSetup = "/logs";
                string sPathFTP = sFTPHost + sFTPSetup + "/" + GVar.attivazioni.IDEuroFormulationInCloud + ".log";
                
                //check if alredy exists
                if (!GVar.appIsRunning) { return false; }
                bool bFileExists = false;
                var request = (FtpWebRequest)WebRequest.Create(sPathFTP);
                request.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                try
                {
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    bFileExists = true;
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode != FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }

                //if exists, then delete
                if (!GVar.appIsRunning) { return false; }
                if (bFileExists)
                {
                    FtpWebRequest delRequest = (FtpWebRequest)WebRequest.Create(sPathFTP);
                    delRequest.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
                    delRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)delRequest.GetResponse();
                }

                //upload log
                if (!GVar.appIsRunning) { return false; }
                FtpWebRequest uploadRequest = (FtpWebRequest)FtpWebRequest.Create(sPathFTP);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Credentials = new NetworkCredential(sFTPUser, sFTPPassword);
                uploadRequest.UsePassive = true;
                uploadRequest.UseBinary = true;
                uploadRequest.KeepAlive = false;
                FileStream stream = File.OpenRead(tempPath);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();
                Stream reqStream = uploadRequest.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();

                //delete log-temp file
                if (!GVar.appIsRunning) { return false; }
                if (File.Exists(tempPath)) { File.Delete(tempPath); }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private List<string> GetLastHundredLogs()
        {
            try
            {
                List<string> logs = new List<string>();

                //load log data
                string line;
                TextReader reader = new StreamReader(this.path);
                while ((line = reader.ReadLine()) != null)
                {
                    logs.Add(line);
                    if (logs.Count >= 110)
                    {
                        logs.RemoveRange(0, 10);
                    }
                }
                reader.Close();

                return logs;
            }
            catch (Exception) { return new List<string>(); }
        }
        private void ClearLogFile()
        {
            try
            {
                List<string> logs = GetLastHundredLogs();
                if (File.Exists(this.path)) { File.Delete(this.path); }
                File.WriteAllLines(this.path, logs);
            }
            catch (Exception) { }
        }
        #endregion
        */
    }
}