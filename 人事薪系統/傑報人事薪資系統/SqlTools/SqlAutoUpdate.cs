using HR_TOOL.JBQuery;
using JBHR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLController.SqlTools.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLController.SqlTools
{
    public class SqlAutoUpdate
    {
        public string ConnectionString { set; get; }
        SqlAutoUpdateDataContext db;
        string SysIniTable = "_InitialSqlUdateTable.sql";//自動更新檢查表

        public SqlAutoUpdate()
        {
            ConnectionString = string.Empty;
            //db = new SqlAutoUpdateDataContext(ConnectionString);
        }

        public SqlAutoUpdate(string connectionString)
        {
            ConnectionString = connectionString;
            db = new SqlAutoUpdateDataContext(ConnectionString);
        }

        public void SqlUpdateCheck()
        {
            FileStream fs;
            StreamReader sr;
            string FileDic = Application.StartupPath + @"\SqlStorage";
            DirectoryInfo di = new DirectoryInfo(FileDic);
            var sqlfiles = di.GetFileSystemInfos("*.*", SearchOption.AllDirectories).Where(p => p.Extension.ToLower() == ".sql").ToList();
            var jqfiles = di.GetFileSystemInfos("*.*", SearchOption.AllDirectories).Where(p => p.Extension.ToLower() == ".jq").ToList();
            Dictionary<string, string> SqlFiles = new Dictionary<string, string>();
            foreach (var item in sqlfiles.OrderBy(p => p.FullName).Select(p => p.FullName))
                SqlFiles.Add(Path.GetFileName(item), item);
            foreach (var item in jqfiles.OrderBy(p => p.FullName).Select(p => p.FullName))
                SqlFiles.Add(Path.GetFileName(item), item);
            //db = new SqlAutoUpdateDataContext(this.ConnectionString);
            KeyValuePair<string, string> InitialSqlUdateTable = new KeyValuePair<string, string>(SysIniTable, SqlFiles[SysIniTable]);
            string msg = string.Empty;
            launchSqlQuery(out fs, out sr, db, InitialSqlUdateTable, out msg);
            SqlFiles.Remove(InitialSqlUdateTable.Key);
            var SqlUpdateTable = db.SqlUpdateTable.Select(p => p).ToList();
            foreach (var sql in SqlFiles)
            {
                if (!SqlUpdateTable.Where(p => p.FileName == sql.Key).Any())
                {
                    SqlUpdateTable suTable = new SqlUpdateTable();
                    suTable.FileName = sql.Key;
                    suTable.USERID = MainForm.USER_ID;
                    suTable.TIMEB = DateTime.Now;
                    suTable.TIMEE = DateTime.MaxValue;
                    db.SqlUpdateTable.InsertOnSubmit(suTable);
                    db.SubmitChanges();
                    launchSqlQuery(out fs, out sr, db, sql, out msg);
                    var sut = db.SqlUpdateTable.Where(p => p.AutoKey == suTable.AutoKey).First();
                    sut.TIMEE = DateTime.Now;
                    sut.NOTE = msg;
                    db.SubmitChanges();
                    SqlUpdateTable = db.SqlUpdateTable.Select(p => p).ToList();
                }
            }
        }

        //偵測byte[]是否為BIG5編碼
        public static bool IsBig5Encoding(byte[] bytes)
        {
            Encoding big5 = Encoding.GetEncoding(950);
            //將byte[]轉為string再轉回byte[]看位元數是否有變
            return bytes.Length ==
                big5.GetByteCount(big5.GetString(bytes));
        }
        //偵測檔案否為BIG5編碼
        public static bool IsBig5Encoding(string file)
        {
            if (!File.Exists(file)) return false;
            return IsBig5Encoding(File.ReadAllBytes(file));
        }

        private static void launchSqlQuery(out FileStream fs, out StreamReader sr, SqlAutoUpdateDataContext db, KeyValuePair<string, string> sql, out string msg)
        {
            msg = "Success";
            Encoding FileEncoding = Encoding.UTF8;

            if (IsBig5Encoding(sql.Value))
                FileEncoding = Encoding.GetEncoding(950);

            using (fs = new FileStream(sql.Value, FileMode.Open))
            {
                using (sr = new StreamReader(fs, FileEncoding, true))
                {
                    var value = sr.ReadToEnd();
                    if (Path.GetExtension(sql.Value).ToLower() == ".sql")
                    {
                        char[] delimiterString = { '\r', '\n' };
                        //var Sql = value.ToUpper().Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);
                        var Sql = value.Split(delimiterString, StringSplitOptions.RemoveEmptyEntries);

                        List<string> SqlList = new List<string>();
                        string Script = string.Empty;
                        foreach (var item in Sql)
                        {
                            if (Script != string.Empty && item.Trim().ToUpper() == "GO")
                            {
                                SqlList.Add(Script);
                                Script = string.Empty;
                            }
                            else if (item.Trim().ToUpper() != "GO")
                                Script += item + Environment.NewLine;
                        }

                        if (Script != string.Empty)
                            SqlList.Add(Script);

                        foreach (var item in SqlList)
                        {
                            dynamic dyna = new JObject();
                            try
                            {
                                db.ExecuteCommand(item);
                            }
                            catch (Exception ex)
                            {
                                dyna.extime = DateTime.Now;
                                dyna.source = sql.Key;
                                dyna.command = item;
                                dyna.message = ex.Message;
                                //dyna.exception = ex.StackTrace;
                                dyna.state = "Fail";
                                if (msg == "Success")
                                    msg = "Fail : ";
                                msg += string.Format(@"{0} ", ex.Message);
                                Guid guid = new Guid();
                                string dynaStr = dyna.ToString(Formatting.None);
                                JBModule.Message.DbLog.WriteToDB(ex.Message, dynaStr, "err", "SqlAutoUpdate", -1, MainForm.USER_ID, guid.ToString());
                            }
                        }
                    }
                    else if (Path.GetExtension(sql.Value).ToLower() == ".jq")
                    {
                        dynamic dyna = new JObject();
                        try
                        {
                            var setting = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTransfer>(value);
                            JBControls.HrDBDataContext jbdb = new JBControls.HrDBDataContext();
                            var jqsql = jbdb.jqSetting.Where(p => p.QuerySetting == setting.MySetting.QuerySetting);

                            if (!jqsql.Any())
                            {
                                jbdb.jqSetting.InsertOnSubmit(setting.MySetting);
                                jbdb.SubmitChanges();
                                foreach (var it in setting.MyColumns)
                                    it.SettingID = setting.MySetting.ID;
                                jbdb.jqColumn.InsertAllOnSubmit(setting.MyColumns);

                                foreach (var it in setting.MyForeignKey)
                                    it.SettingID = setting.MySetting.ID;
                                jbdb.jqForeignKey.InsertAllOnSubmit(setting.MyForeignKey);

                                foreach (var it in setting.MyPreCondition)
                                    it.SettingID = setting.MySetting.ID;
                                jbdb.jqPreCondition.InsertAllOnSubmit(setting.MyPreCondition);

                                foreach (var it in setting.MyQueryField)
                                    it.SettingID = setting.MySetting.ID;
                                jbdb.jqSqlQueryField.InsertAllOnSubmit(setting.MyQueryField);

                                foreach (var it in setting.MyTable)
                                    it.SettingID = setting.MySetting.ID;
                                jbdb.jqTable.InsertAllOnSubmit(setting.MyTable);
                                jbdb.SubmitChanges();
                                //MessageBox.Show("匯入完成");
                            }
                            else
                            {
                                Exception ex = new Exception(string.Format("{0}-{1}的設定已經存在.", setting.MySetting.QuerySetting, setting.MySetting.QueryName));
                                throw ex;
                            }
                        }
                        catch (Exception ex)
                        {
                            dyna.extime = DateTime.Now;
                            dyna.source = sql.Key;
                            //dyna.command = item;
                            dyna.message = ex.Message;
                            //dyna.exception = ex.StackTrace;
                            dyna.state = "Fail";
                            if (msg == "Success")
                                msg = "Fail : ";
                            msg += string.Format(@"{0} ", ex.Message);
                            Guid guid = new Guid();
                            string dynaStr = dyna.ToString(Formatting.None);
                            JBModule.Message.DbLog.WriteToDB(ex.Message, dynaStr, "err", "SqlAutoUpdate", -1, MainForm.USER_ID, guid.ToString());
                        }
                    }
                }
            }
        }
    }
}
