using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Message
{
    public class TextLog
    {
        public static Exception LastError = null;
        /// <summary>
        /// 是否啟用Log
        /// </summary>
        public static bool LogEnable
        {
            get
            {
                try
                {
                    bool enable = ConfigSetting.AppSettingValue("Message.EnableLog") == "1";
                    return enable;
                }
                catch
                {
                    return true;//預設為true
                }
            }
        }
        /// <summary>
        /// Log目錄
        /// </summary>
        public static string LogDirectory
        {
            get
            {
                try
                {
                    string dir = ConfigSetting.AppSettingValue("Message.LogDir");
                    return dir;
                }
                catch
                {
                    return "log";//預設為log
                }
            }
        }
        public static void WriteLog(Exception ex , string note)
        {
            try
            {
                Exception err = ex;
                while ( err.InnerException != null )//遞回
                    err = err.InnerException;
                TextLog.LastError = err;
                WriteToText(err.StackTrace , note + ":" + ex.Message , "err");
            }
            catch
            {

            }
        }
        public static void WriteLog(Exception ex)
        {
            try
            {
                WriteLog(ex , "Error");
            }
            catch
            {

            }
        }
        public static void WriteLog(string msg , string note)
        {
            try
            {
                WriteToText(msg , note , "msg");
            }
            catch
            {

            }
        }
        public static void WriteLog(string msg)
        {
            try
            {
                WriteToText(msg , "" , "msg");
            }
            catch
            {

            }
        }
        static void WriteToText(string log , string note , string type)
        {
            if ( !LogEnable )
                return;//如果設定為false，就不動作
            string SaveDate = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");//取得年月日
            string path = System.IO.Directory.GetCurrentDirectory();
            string dir = "\\" + LogDirectory + "\\";
            string file = type + SaveDate + ".log";
            string fullpath = path + dir;
            string fullname = fullpath + file;
            if ( !System.IO.Directory.Exists(fullpath) )//檢查目錄是否存在，不存在就建立新目錄
                System.IO.Directory.CreateDirectory(fullpath);
            using ( System.IO.FileStream ds = new System.IO.FileStream(fullname , System.IO.FileMode.Append) )//寫入error\er200979.log
            {
                using ( System.IO.StreamWriter sw = new System.IO.StreamWriter(ds , Encoding.Default) )
                {
                    StringBuilder builder = new StringBuilder();

                    builder.Append(DateTime.Now.ToString());

                    builder.Append("\u0009");

                    if ( note != null && note.Trim().Length > 0 )
                    {
                        builder.Append(note);
                        builder.Append("\u0009");
                    }

                    builder.Append(log);

                    builder.Append("\u0009");

                    sw.WriteLine(builder);
                    Console.WriteLine(builder);
                    sw.Flush();

                    sw.Close();

                }

                ds.Close();

            }
        }

    }
}
