using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JBHRModel;

namespace Facade
{
    /// <summary>
    /// AbsFacade 的摘要描述
    /// </summary>
    public class AbsFacade
    {
        public AbsFacade()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }
        
        public DataTable GetByNobrDateRangeYearRest(string nobr,string name_c,string name_e, DateTime selectedDate,DateTime adate,DateTime ddate,string yearRest1,string yearRest2)
        {
            DataTable dt = JBHR.Dll.Att.AbsCal.AbsPersonal(nobr, DateTime.Now.Date, adate, DateTime.Now.Date, "1", "2");
            DataTable rv_absb = new DataTable();
            rv_absb.Columns.Add("nobr" , typeof(string));
            rv_absb.Columns.Add("name_c" , typeof(string));
            rv_absb.Columns.Add("name_e", typeof(string));
            rv_absb.Columns.Add("bdate" , typeof(DateTime));
            rv_absb.Columns.Add("h_code1" , typeof(string));
            rv_absb.Columns.Add("h_name1" , typeof(string));
            rv_absb.Columns.Add("tol_hrs1" , typeof(decimal));
            rv_absb.Columns.Add("h_code2" , typeof(string));
            rv_absb.Columns.Add("h_name2" , typeof(string));
            rv_absb.Columns.Add("tol_hrs2" , typeof(decimal));
            rv_absb.Columns.Add("tolhrs" , typeof(decimal));
            foreach ( DataRow Row in dt.Rows )
            {
                DataRow aRow = rv_absb.NewRow();
                Row["sname"] = name_c;
                aRow["nobr"] = Row["snobr"].ToString();
                aRow["name_c"] = name_c;
                aRow["name_e"] = name_e;
                aRow["bdate"] = DateTime.Parse(Row["dDateB"].ToString());
                aRow["tol_hrs1"] = 0;
                aRow["tol_hrs2"] = 0;
                if ( Row["sCat"].ToString().Trim() == "1" )
                {
                    aRow["h_code1"] = Row["sHoliCode"].ToString();
                    aRow["h_name1"] = Row["sHoliCode"].ToString().Trim() + Row["sHoliName"].ToString();
                    aRow["tol_hrs1"] = decimal.Parse(Row["iUse"].ToString());

                }
                if ( Row["sCat"].ToString().Trim() == "2" )
                {
                    aRow["h_code2"] = Row["sHoliCode"].ToString();
                    aRow["h_name2"] = Row["sHoliCode"].ToString().Trim() + Row["sHoliName"].ToString();
                    aRow["tol_hrs2"] = decimal.Parse(Row["iUse"].ToString());
                }
                aRow["tolhrs"] = decimal.Parse(Row["iBalance"].ToString());
                rv_absb.Rows.Add(aRow);
            }

            return rv_absb;
        }
    }
}