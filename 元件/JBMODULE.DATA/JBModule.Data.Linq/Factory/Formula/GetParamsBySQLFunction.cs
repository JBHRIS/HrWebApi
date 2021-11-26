using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBModule.Data.Factory.Formula
{
    public class GetParamsBySQLFunction : IFormulaFunction
    {
        public Dictionary<string, object> Parameters { get; set; }
        public string Key { get; set; }
        public string GetKey()
        {
            return Parameters["TableName"].ToString();
        }
        public DataTable GetData()
        {
            Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var cmd = db.Connection.CreateCommand();
            cmd.CommandText = string.Format("select * from {0}", Parameters["SqlFuction"].ToString());
            //cmd.CommandText = string.Format("select * from dbo.Hunya_GetBonusGroup(@EmployeeList,'2021/08/26','2021/09/25')");
            System.Data.SqlClient.SqlParameter sp = new System.Data.SqlClient.SqlParameter();
            foreach (var item in Parameters)
            {
                sp = new System.Data.SqlClient.SqlParameter();
                sp.ParameterName = item.Key;
                switch (Type.GetTypeCode(Parameters[item.Key].GetType()))
                {
                    case TypeCode.Boolean:
                        sp.Value = Convert.ToBoolean(Parameters[item.Key]);
                        break;
                    case TypeCode.Int32:
                        sp.Value = Convert.ToInt32(Parameters[item.Key]);
                        break;
                    case TypeCode.DateTime:
                        sp.Value = Convert.ToDateTime(Parameters[item.Key]);
                        break;
                    case TypeCode.Decimal:
                        sp.Value = Convert.ToDecimal(Parameters[item.Key]);
                        break;
                    default:
                        sp.Value = Parameters[item.Key].ToString();
                        break;
                }
                cmd.Parameters.Add(sp);
            }

            if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt.TableName = Parameters["TableName"].ToString();
            db.Connection.Close();
            return dt;
        }
    }
}
