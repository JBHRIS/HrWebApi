using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Bas
{
    public class BasettsFixDdateDao
    {
        DbConnection _conn;
        public BasettsFixDdateDao(DbConnection conn)
        {
            SqlConnection sqlconnection=new SqlConnection(conn.ConnectionString);
            _conn = sqlconnection;
        }
        public List<string> GetErrorData()
        {
            //using (_conn)
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct nobr from basetts a where exists(select * from basetts b where a.nobr=b.nobr and a.adate!=b.adate and a.adate<=b.ddate and a.ddate>=b.adate)", _conn as SqlConnection);
                var dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                List<string> results = new List<string>();
                foreach (DataRow r in data.Rows)
                    results.Add(r[0].ToString());
                _conn.Close();
                return results;
            }
        }
        public bool FixData(string EmployeeId)
        {
            try
            {
                //using (_conn)
                {
                    if (_conn.State != ConnectionState.Open)
                        _conn.Open();
                    SqlDataAdapter sa = new SqlDataAdapter("SELECT * FROM BASETTS WHERE NOBR=@NOBR ORDER BY ADATE DESC", _conn as SqlConnection);
                    var parameter = new SqlParameter("NOBR", EmployeeId);
                    sa.SelectCommand.Parameters.Add(parameter);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sa);
                    sa.UpdateCommand = scb.GetUpdateCommand();
                    DataTable data = new DataTable();
                    sa.Fill(data);
                    DateTime ddate = new DateTime(9999, 12, 31);
                    foreach (DataRow r in data.Rows)
                    {
                        r["DDATE"] = ddate;
                        ddate = Convert.ToDateTime(r["ADATE"]).AddDays(-1);
                    }
                    sa.Update(data);
                    _conn.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
