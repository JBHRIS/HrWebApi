using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Bas
{
    public class SalbasdFixDdateDao
    {
        DbConnection _conn;
        public SalbasdFixDdateDao(DbConnection conn)
        {
            SqlConnection sqlconnection=new SqlConnection(conn.ConnectionString);
            _conn = sqlconnection;
        }
        public List<SalbasdCheck> GetConflictData()
        {
            //using (_conn)
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct NOBR,SAL_CODE from SALBASD a where exists(select * from SALBASD b where a.nobr=b.NOBR and a.SAL_CODE=b.SAL_CODE and a.ADATE!=b.ADATE and a.ADATE<=b.DDATE and a.DDATE>=b.ADATE)", _conn as SqlConnection);
                var dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                var results = new List<SalbasdCheck>();
                foreach (DataRow r in data.Rows)
                    results.Add(new SalbasdCheck { EmployeeId = r[0].ToString(), SalaryCode = r[1].ToString() });
                _conn.Close();
                return results;
            }
        }
        public List<SalbasdCheck> GetInterruptData()
        {
            //using (_conn)
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct nobr,SAL_CODE from salbasd a where (SELECT MAX(DDATE) FROM SALBASD B WHERE A.NOBR=B.NOBR AND A.SAL_CODE=B.SAL_CODE)<'9999/12/31'", _conn as SqlConnection);
                var dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                var results = new List<SalbasdCheck>();
                foreach (DataRow r in data.Rows)
                    results.Add(new SalbasdCheck { EmployeeId = r[0].ToString(), SalaryCode = r[1].ToString() });
                _conn.Close();
                return results;
            }
        }
        public bool FixData(string EmployeeId,string Salcode)
        {
            try
            {
                //using (_conn)
                {
                    if (_conn.State != ConnectionState.Open)
                        _conn.Open();
                    SqlDataAdapter sa = new SqlDataAdapter("SELECT * FROM SALBASD WHERE NOBR=@NOBR AND SAL_CODE=@SALCODE ORDER BY ADATE DESC", _conn as SqlConnection);
                    var parameterNOBR = new SqlParameter("NOBR", EmployeeId);
                    var parameterSALCODE = new SqlParameter("SALCODE", Salcode);
                    sa.SelectCommand.Parameters.Add(parameterNOBR);
                    sa.SelectCommand.Parameters.Add(parameterSALCODE);
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
    public class SalbasdCheck
    {
        public string EmployeeId { get; set; }
        public string SalaryCode { get; set; }
    }
}
