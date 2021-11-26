using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Bas
{
    public class InslabCnFixDdateDao
    {
        DbConnection _conn;
        public InslabCnFixDdateDao(DbConnection conn)
        {
            SqlConnection sqlconnection=new SqlConnection(conn.ConnectionString);
            _conn = sqlconnection;
        }
        public List<InslabCnCheck> GetConflictData()
        {
            //using (_conn)
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct NOBR,InsurCnCode from InslabCN a where exists(select * from InslabCN b where a.nobr=b.NOBR and a.InsurCnCode=b.InsurCnCode and a.InDate!=b.InDate and a.InDate<=b.OutDate and a.OutDate>=b.InDate)", _conn as SqlConnection);
                var dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                var results = new List<InslabCnCheck>();
                foreach (DataRow r in data.Rows)
                    results.Add(new InslabCnCheck { EmployeeId = r[0].ToString(),  InsType  = r[1].ToString() });
                _conn.Close();
                return results;
            }
        }
        public List<InslabCnCheck> GetInterruptData()
        {
            //using (_conn)
            {
                if (_conn.State != ConnectionState.Open)
                    _conn.Open();
                SqlCommand cmd = new SqlCommand("select distinct NOBR,InsurCnCode from inslabcn a where (SELECT MAX(outdate) FROM inslabcn B WHERE A.NOBR=B.NOBR AND A.insurcncode=B.insurcncode)<'9999/12/31'", _conn as SqlConnection);
                var dr = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(dr);
                var results = new List<InslabCnCheck>();
                foreach (DataRow r in data.Rows)
                    results.Add(new InslabCnCheck { EmployeeId = r[0].ToString(),  InsType = r[1].ToString() });
                _conn.Close();
                return results;
            }
        }
        public bool FixData(string EmployeeId,string InsType)
        {
            try
            {
                //using (_conn)
                {
                    if (_conn.State != ConnectionState.Open)
                        _conn.Open();
                    SqlDataAdapter sa = new SqlDataAdapter("SELECT * FROM INSLABCN WHERE NOBR=@NOBR AND INSURCNCODE=@INSURCNCODE ORDER BY InDate DESC", _conn as SqlConnection);
                    var parameterNOBR = new SqlParameter("NOBR", EmployeeId);
                    var parameterSALCODE = new SqlParameter("INSURCNCODE", InsType);
                    sa.SelectCommand.Parameters.Add(parameterNOBR);
                    sa.SelectCommand.Parameters.Add(parameterSALCODE);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sa);
                    sa.UpdateCommand = scb.GetUpdateCommand();
                    DataTable data = new DataTable();
                    sa.Fill(data);
                    DateTime ddate = new DateTime(9999, 12, 31);
                    foreach (DataRow r in data.Rows)
                    {
                        r["OutDate"] = ddate;
                        ddate = Convert.ToDateTime(r["InDate"]).AddDays(-1);
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
    public class InslabCnCheck
    {
        public string EmployeeId { get; set; }
        public string InsType { get; set; }
    }
}
