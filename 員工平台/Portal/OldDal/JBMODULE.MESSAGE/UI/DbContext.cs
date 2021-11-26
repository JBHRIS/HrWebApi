using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace JBModule.Message.UI
{
    public class DbContext
    {
        public static bool IsTableExists(string TableName)
        {
            string con_str = Properties.Settings.Default.MailConnectionString;
            SqlConnection conn = new SqlConnection(con_str);
            using (conn)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string cmd = string.Format("select count(*) from sysobjects where xtype='U' and name='{0}' ", TableName);
                SqlCommand sqlcmd = new SqlCommand(cmd, conn);
                var dr = sqlcmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    var value = Convert.ToInt32(dt.Rows[0][0]);
                    return value > 0;
                }
            }
            return false;
        }
        public static bool CreateMailQueueTable()
        {
            return RunScript(GetTextFromFile(System.IO.Directory.GetCurrentDirectory() + @"\SQL\MailQueue.sql"));
        }
        public static bool CreateSysLogTable()
        {
            return RunScript(GetTextFromFile(System.IO.Directory.GetCurrentDirectory() + @"\SQL\SysLog.sql"));
        }
        public static bool CreateParameterTable()
        {
            return RunScript(GetTextFromFile(System.IO.Directory.GetCurrentDirectory() + @"\SQL\PARAMETER.sql"));
        }
        public static bool CreateParameterTreeTable()
        {
            return RunScript(GetTextFromFile(System.IO.Directory.GetCurrentDirectory() + @"\SQL\PARAMETER_TREE.sql"));
        }
        public static int InitialParameterTree()
        {
            DBDataContext db = new DBDataContext();
            PARAMETER_TREE pt = new PARAMETER_TREE();
            pt.CODE = "MailSettings";
            pt.DISPLAY = true;
            pt.KEY_DATE = DateTime.Now;
            pt.KEY_MAN = "JB";
            pt.NAME = "郵件設定";
            pt.PID = 0;
            db.PARAMETER_TREE.InsertOnSubmit(pt);
            db.SubmitChanges();
            return pt.AUTO;
        }
        public static void InitialParameter(int GroupID)
        {
            DBDataContext db = new DBDataContext();
            
            PARAMETER parm = new PARAMETER();
            parm.CODE = "JbMail.host";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "郵件主機的位置";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "String";
            parm.VALUE = "";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.IsNeedCredentials";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "驗證";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "0";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.sys_mail";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "帳號";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "String";
            parm.VALUE = "";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.sys_pwd";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "密碼";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "String";
            parm.VALUE = "";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.port";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "連線埠";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "25";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.EnableTestMode";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "啟用測試模式";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "0";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.TestAccount";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "測試帳號";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "String";
            parm.VALUE = "";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.DisableSendMail";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "停止發信";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "0";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.Priority";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "優先權";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "1";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.CredentialsType";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "傳輸模式";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "3";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.MaxRetry";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "最大重試次數";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "3";
            db.PARAMETER.InsertOnSubmit(parm);

            parm = new PARAMETER();
            parm.CODE = "JbMail.Delay";
            parm.DISPLAY = true;
            parm.KEY_DATE = DateTime.Now;
            parm.KEY_MAN = "JB";
            parm.NOTE = "重試延遲(min)";
            parm.PARMGROUP_AUTO = GroupID;
            parm.TYPE = "Int";
            parm.VALUE = "30";
            db.PARAMETER.InsertOnSubmit(parm);
            db.SubmitChanges();
        }
        public static bool RunScript(string script)
        {
            string con_str = ConfigSetting.ConnectionString(ConfigSetting.AppSettingValue("JBModule.Message.ConnectionString"));
            SqlConnection conn = new SqlConnection(con_str);
            try
            {
                using (conn)
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    string cmd = script;
                    SqlCommand sqlcmd = new SqlCommand(cmd, conn);
                    int dr = sqlcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                JBModule.Message.DbLog.WriteLog(ex, "執行產生MAILQUEUE資料表時發生錯誤", "Mail", -1);
                return false;
            }
            return true;
        }
        public static string GetTextFromFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string value = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                fs.Close();
                fs.Dispose();
                return value;
            }
            return "";
        }
    }
}
