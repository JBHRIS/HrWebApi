using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class SqlFuctionCheckRule : ISalCalcBeforeCheckRule
    {
        public Dictionary<string, object> Parameters { get; set; }

        public DataTable Validate()
        {
            //string Nobr_B = Parameters["Nobr_B"].ToString();
            //string Nobr_E = Parameters["Nobr_E"].ToString();
            //string Dept_B = Parameters["Dept_B"].ToString();
            //string Dept_E = Parameters["Dept_E"].ToString();
            //DateTime Bdate = Convert.ToDateTime(Parameters["Bdate"]);
            //DateTime Edate = Convert.ToDateTime(Parameters["Edate"]);
            //DateTime InEdate = Convert.ToDateTime(Parameters["InEdate"]);//異動截止日
            //string User_ID = Parameters["User_ID"].ToString();
            //string Company = Parameters["Company"].ToString();
            //bool Admin = Convert.ToBoolean(Parameters["Admin"]);
            //string SqlFuction = Parameters["SqlFuction"].ToString();
            Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = string.Format("select * from {0}", Parameters["SqlFuction"].ToString());
            System.Data.SqlClient.SqlParameter sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "nobr_b";
            sp.Value = Parameters["Nobr_B"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "nobr_e";
            sp.Value = Parameters["Nobr_E"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "dept_b";
            sp.Value = Parameters["Dept_B"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "dept_e";
            sp.Value = Parameters["Dept_E"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "bdate";
            sp.Value = Convert.ToDateTime(Parameters["Bdate"]);
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "edate";
            sp.Value = Convert.ToDateTime(Parameters["Edate"]);
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "inedate";
            sp.Value = Convert.ToDateTime(Parameters["InEdate"]);
            cmd.Parameters.Add(sp);

            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "userid";
            sp.Value = Parameters["User_ID"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "comp";
            sp.Value = Parameters["Company"].ToString();
            cmd.Parameters.Add(sp);
            sp = new System.Data.SqlClient.SqlParameter();
            sp.ParameterName = "admin";
            sp.Value = Convert.ToBoolean(Parameters["Admin"]);
            cmd.Parameters.Add(sp);

            if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt.TableName = Parameters["TableName"].ToString();
            db.Connection.Close();
            return dt;
        }
    }
}
