using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message
{
    public class DbLog
    {
        public DbLog()
        {

        }
        public static string key_man = "JB";
        public static void WriteLog(Exception ex, string note)
        {
            WriteLog(ex, note, ex.Source, -1);
        }
        public static void WriteLog(Exception ex, string source, int pid)
        {
            WriteLog(ex, "Error", source, pid);
        }
        public static void WriteLog(Exception ex, string note, string source, int pid)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                Exception err = ex;
                WriteToDB(note + ":" + ex.Message, err.StackTrace, "err", source, pid, key_man, guid);
                int i = 0;
                while (err.InnerException != null)//遞回
                {
                    i++;
                    err = err.InnerException;
                    WriteToDB("Layer" + i.ToString() + ":" + err.Message, err.StackTrace, "err", source, pid, key_man, guid);
                }
                TextLog.LastError = err;

            }
            catch (Exception ex1)
            {
                TextLog.WriteLog(ex1);
            }
        }
        public static void WriteLog(string msg, string note, string source, int pid)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                WriteToDB(msg, note, "msg", source, pid, key_man, guid);
            }
            catch (Exception ex1)
            {
                TextLog.WriteLog(ex1);
            }
        }
        public static void WriteLog(string msg, object DataEntity, string source, int pid)
        {
            try
            {
                string guid = Guid.NewGuid().ToString();
                WriteToDB(msg, Newtonsoft.Json.JsonConvert.SerializeObject(DataEntity), "msg", source, pid, key_man, guid);
            }
            catch (Exception ex1)
            {
                TextLog.WriteLog(ex1, DataEntity);
            }
        }
        public static void WriteToDB(string log, string note, string type, string source, int pid, string key_man, string guid)
        {
            SYSLOG slg = new SYSLOG();
            try
            {
                DBDataContext db = new DBDataContext();
                slg.GUID = guid;
                slg.NOTE = note;
                slg.SID = pid;
                slg.SOURCE = source;
                slg.TITLE = log;
                slg.TYPE = type;
                slg.KEY_DATE = DateTime.Now;
                slg.KEY_MAN = key_man;
                db.SYSLOG.InsertOnSubmit(slg);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                TextLog.WriteLog(ex, slg);
            }
        }
    }
}
