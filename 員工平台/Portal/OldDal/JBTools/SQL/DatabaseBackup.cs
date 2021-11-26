using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JBTools.SQL
{
    public class DatabaseBackup
    {
       System.Data.Common.DbConnection _conn;
       Exception BackException;
       public string ErrorMessage = "";
       public DatabaseBackup(System.Data.Common.DbConnection conn)
        {
            _conn = conn;
        }
        public bool Backup(string DatabaseName, string FilePath)
        {
            bool success = true;
            try
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();

                using (_conn)
                {
                    string BackupCommand = string.Format("BACKUP DATABASE {0} TO DISK='{1}'", new object[] { DatabaseName, FilePath });
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = BackupCommand;
                    cmd.Connection = _conn as SqlConnection;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                success = false;
                ErrorMessage = ex.Message;
                BackException = ex;
            }
            return success;
        }
    }
}
