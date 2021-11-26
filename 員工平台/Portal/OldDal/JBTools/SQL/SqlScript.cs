using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace JBTools.SQL
{
    public class SqlScript
    {
        string _ConnectionString = "";
        public SqlScript(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public bool RunScript(string script)
        {
            string con_str = _ConnectionString;
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
                return false;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return true;
        }
        public bool RunScriptFromFile(string Path)
        {
            return RunScript(GetTextFromFile(Path));
        }
        public string GetTextFromFile(string FileName)
        {
            return GetTextFromFile(FileName, Encoding.GetEncoding("BIG5"));
        }
        public string GetTextFromFile(string FileName, Encoding encode)
        {
            if (File.Exists(FileName))
            {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs, encode);
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
