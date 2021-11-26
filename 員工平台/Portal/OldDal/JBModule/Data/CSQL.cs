using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JBModule.Data
{
    public class CSQL
    {
        private SqlConnection sqlConn = null;

        private CSQL() { }

        public CSQL(string ConnectionStringsSection)
        {
            ConfigSetting conf = new ConfigSetting();
            sqlConn = new SqlConnection(conf.GetConnValue(ConnectionStringsSection));
        }

        public CSQL(SqlConnection Connection)
        {
            sqlConn = Connection;
        }

        public DataTable GetDataTable(string selectCommandText)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommandText, sqlConn);
            DataTable dataTable = new DataTable();
            try
            {
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ExecuteNonQuery(string cmdText)
        {
            int ret = 0;

            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConn);
            try
            {
                if (sqlConn.State == ConnectionState.Closed) sqlConn.Open();
                ret = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConn.Close();
            }

            return ret;
        }
    }
}
