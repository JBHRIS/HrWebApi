/* ======================================================================================================
 * 功能名稱：其他費用總表
 * 功能代號：ZZ4B
 * 功能路徑：報表列印 > 薪資 > 其他費用總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4BClass.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/15    Daniel Chih    Ver 1.0.01     1. 增加報表內容的控制項：允許選擇全部、退休金提撥表、年終獎金提撥表
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/15
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.SalForm
{
    class ZZ4BClass
    {
        public static void GetWagedb(DataTable DT_cost, DataTable DT_waged, DataTable DT_wagedb)
        {
            int _rowcnt = 0; string str_nobr1 = ""; 
            foreach (DataRow Row in DT_cost.Rows)
            {
                string deptnobr = Row["depts"].ToString() + Row["nobr"].ToString();
                if (Row["nobr"].ToString() == str_nobr1)
                    _rowcnt = 1;
                else
                    _rowcnt = 0;

                DataRow[] row = DT_waged.Select("nobr='" + Row["nobr"].ToString() + "'");
                for (int i = 0; i < row.Length;i++ )
                {
                    DataRow aRow = DT_wagedb.NewRow();
                    aRow["nobr"] = row[i]["nobr"].ToString();
                    aRow["yymm"] = row[i]["yymm"].ToString();
                    aRow["seq"] = row[i]["seq"].ToString();
                    aRow["sal_code"] = row[i]["sal_code"].ToString();
                    aRow["di"] = row[i]["di"].ToString();
                    aRow["name_c"] = row[i]["name_c"].ToString();
                    aRow["indt"] = DateTime.Parse(row[i]["indt"].ToString());
                    aRow["dept"] = Row["depts"].ToString();
                    aRow["comp"] = row[i]["comp"].ToString();
                    aRow["compname"] = row[i]["compname"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["count_ma"] = bool.Parse(row[i]["count_ma"].ToString());
                    aRow["sal_name"] = row[i]["sal_name"].ToString();
                    aRow["flag"] = row[i]["flag"].ToString();
                    aRow["salattr"] = row[i]["salattr"].ToString();
                    aRow["yearpay"] = bool.Parse(row[i]["yearpay"].ToString());
                    aRow["retire"] = bool.Parse(row[i]["retire"].ToString());
                    aRow["amt"] = Math.Round(decimal.Parse(row[0]["amt"].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                    aRow["noret"] = bool.Parse(row[i]["noret"].ToString());
                    if (i == 0)
                        aRow["pno"] = decimal.Parse(Row["rate"].ToString());
                    else
                        aRow["pno"] = 0;
                    aRow["rowcnt"] = _rowcnt;   
                    DT_wagedb.Rows.Add(aRow);
                }
                str_nobr1 = Row["nobr"].ToString();
            }
        }

        public static void GetWagedN(DataTable DT_cost, DataTable DT_waged, DataTable DT_wagedb)
        {
            int _rowcnt = 0; string str_nobr1 = "";
            foreach(DataRow Row in DT_waged.Rows)
            {
                decimal _amt=decimal.Parse(Row["amt"].ToString());
                DataRow[] row = DT_cost.Select("nobr='" + Row["nobr"].ToString() + "'");
                if (row.Length > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        DataRow aRow = DT_wagedb.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["seq"] = Row["seq"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["di"] = Row["di"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["dept"] = row[i]["depts"].ToString();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["d_name"] = row[i]["d_name"].ToString();
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["sal_name"] = Row["sal_name"].ToString();
                        aRow["flag"] = Row["flag"].ToString();
                        aRow["salattr"] = Row["salattr"].ToString();
                        aRow["yearpay"] = bool.Parse(Row["yearpay"].ToString());
                        aRow["retire"] = bool.Parse(Row["retire"].ToString());
                        aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(row[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                        aRow["noret"] = bool.Parse(Row["noret"].ToString());
                        aRow["pno"] = (str_nobr1 == Row["nobr"].ToString()) ? 0 : decimal.Parse(row[i]["rate"].ToString());
                        if (i == row.Length - 1)
                            aRow["amt"] = _amt;
                        else
                        {
                            aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(row[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                            _amt -= Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(row[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                        }

                        aRow["rowcnt"] = _rowcnt;
                        DT_wagedb.Rows.Add(aRow);
                    }                    
                }
                else
                {
                    DataRow aRow = DT_wagedb.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    aRow["flag"] = Row["flag"].ToString();
                    aRow["salattr"] = Row["salattr"].ToString();
                    aRow["yearpay"] = bool.Parse(Row["yearpay"].ToString());
                    aRow["retire"] = bool.Parse(Row["retire"].ToString());
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["noret"] = bool.Parse(Row["noret"].ToString());
                    aRow["pno"] = (str_nobr1 == Row["nobr"].ToString()) ? 0 : 1;
                    DT_wagedb.Rows.Add(aRow);
                }

                str_nobr1 = Row["nobr"].ToString();
            }
            //foreach (DataRow Row in DT_cost.Rows)
            //{
            //    string deptnobr = Row["depts"].ToString() + Row["nobr"].ToString();
            //    if (Row["nobr"].ToString() == str_nobr1)
            //        _rowcnt = 1;
            //    else
            //        _rowcnt = 0;

                
            //}
        }


        public static void GetWagedc(DataTable DT_wageb, DataTable DT_wagedc)
        {
            foreach (DataRow Row in DT_wageb.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["sal_code"].ToString();
                DataRow row = DT_wagedc.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedc.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedc.Rows.Add(aRow);
                }
            }
        }

        public static void GetWaged1(DataTable DT_waged, DataTable DT_wageb, DataTable DT_wagedc)
        {
            DataTable rq_diff = new DataTable();
            rq_diff.Columns.Add("nobr", typeof(string));
            rq_diff.Columns.Add("sal_code", typeof(string));
            rq_diff.Columns.Add("diffamt", typeof(int));
            rq_diff.PrimaryKey = new DataColumn[] { rq_diff.Columns["nobr"], rq_diff.Columns["sal_code"] };
            foreach (DataRow Row in DT_wagedc.Rows)
            {
                int _damt = 0; int _salamt = 0;
                DataRow[] row = DT_waged.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                DataRow[] row1 = DT_wageb.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                if (row.Length > 0 && row1.Length > 0)
                {
                    _damt = int.Parse(row[0]["amt"].ToString()) - int.Parse(row1[0]["amt"].ToString());
                    Row["amt"] = int.Parse(Row["amt"].ToString()) + _damt;
                    for (int i = 0; i < row1.Length; i++)
                    {
                        _salamt = _salamt + int.Parse(row1[i]["amt"].ToString());
                    }
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["sal_code"].ToString();
                    DataRow row2 = rq_diff.Rows.Find(_value);
                    if (row2 == null)
                    {
                        DataRow aRow = rq_diff.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["diffamt"] = int.Parse(row[0]["amt"].ToString()) - _salamt;
                        rq_diff.Rows.Add(aRow);
                    }
                }
            }
            foreach (DataRow Row1 in DT_waged.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row1["nobr"].ToString();
                _value[1] = Row1["sal_code"].ToString();
                DataRow row = DT_wagedc.Rows.Find(_value);
                if (row != null)
                    Row1.Delete();
            }
            DT_waged.AcceptChanges();
            foreach (DataRow Row2 in DT_wageb.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row2["nobr"].ToString();
                _value[1] = Row2["sal_code"].ToString();
                DataRow row2 = rq_diff.Rows.Find(_value);
                if (row2 != null && int.Parse(Row2["rowcnt"].ToString()) == 0)
                    Row2["amt"] = int.Parse(Row2["amt"].ToString()) + int.Parse(row2["diffamt"].ToString());
                DT_waged.ImportRow(Row2);
            }
            rq_diff = null;
        }

        public static void GetZz4bc(DataTable DT_waged, DataTable DT_zz4bc)
        {
            DataColumn [] _key = new DataColumn[3];
            _key[0] = DT_zz4bc.Columns["comp"];
            _key[1] = DT_zz4bc.Columns["dept"];
            _key[2] = DT_zz4bc.Columns["di"];
            DT_zz4bc.PrimaryKey = _key;
            DataTable rq_zzdba = new DataTable();
            rq_zzdba.Columns.Add("nobr", typeof(string));
            rq_zzdba.Columns.Add("dept", typeof(string));
            rq_zzdba.Columns.Add("di", typeof(string));            
            rq_zzdba.Columns.Add("comp", typeof(string));
            rq_zzdba.Columns.Add("count_ma", typeof(bool));
            rq_zzdba.PrimaryKey = new DataColumn[] { rq_zzdba.Columns["nobr"] };
            string str_nobrdept1 = "";
            DataRow[] SRow = DT_waged.Select("", "dept,nobr asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row = rq_zzdba.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = rq_zzdba.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    rq_zzdba.Rows.Add(aRow);
                }
                //string str_nobrdept = Row["nobr"].ToString() + Row["dept"].ToString();
                //if (str_nobrdept != str_nobrdept1)
                //    Row["pno"] = 1;
                //else
                //    Row["pno"] = 0;
                //str_nobrdept1 = Row["nobr"].ToString() + Row["dept"].ToString();
            }
            foreach(DataRow Row1 in rq_zzdba.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row1["comp"].ToString();
                _value[1] = Row1["dept"].ToString();
                _value[2] = Row1["di"].ToString();
                DataRow row = DT_zz4bc.Rows.Find(_value);
                string str_countma= (bool.Parse(Row1["count_ma"].ToString())) ? "1" : "2";
                if (row != null)
                {
                    row["pepo"] = int.Parse(row["pepo"].ToString()) + 1;
                }
                else
                {
                    DataRow aRow = DT_zz4bc.NewRow();
                    aRow["comp"] = Row1["comp"].ToString();
                    aRow["dept"] = Row1["dept"].ToString();
                    aRow["di"] = Row1["di"].ToString();
                    aRow["ma"] = str_countma;
                    aRow["pepo"] = 1;
                    DT_zz4bc.Rows.Add(aRow);
                }
            }
            rq_zzdba = null;
            
        }

        public static void GetZz4b(DataTable DT_waged, DataTable DT_zz4b,DataTable DT_sys4, string report_content)
        {
            decimal ljobper = 0; decimal ljobper1 = 0; decimal retirerate = 0; decimal retirerate1 = 0;
            if (DT_sys4.Rows.Count > 0)
            {
                ljobper = decimal.Parse(DT_sys4.Rows[0]["ljobper"].ToString());
                ljobper1 = decimal.Parse(DT_sys4.Rows[0]["ljobper1"].ToString());
                retirerate = decimal.Parse(DT_sys4.Rows[0]["retirerate"].ToString());
                retirerate1 = decimal.Parse(DT_sys4.Rows[0]["retirerate1"].ToString());
            }
            DataTable rq_zz4ba = new DataTable();
            rq_zz4ba.Columns.Add("comp", typeof(string));
            rq_zz4ba.Columns.Add("compname", typeof(string));
            rq_zz4ba.Columns.Add("dept", typeof(string));
            rq_zz4ba.Columns.Add("d_name", typeof(string));
            rq_zz4ba.Columns.Add("di", typeof(string));
            rq_zz4ba.Columns.Add("sal_name", typeof(string));
            rq_zz4ba.Columns.Add("amt", typeof(int));
            rq_zz4ba.Columns.Add("d_amt", typeof(int));
            rq_zz4ba.Columns.Add("i_amt", typeof(int));
            rq_zz4ba.Columns.Add("iper", typeof(decimal));
            rq_zz4ba.Columns.Add("dper", typeof(decimal));
            rq_zz4ba.Columns.Add("pno", typeof(decimal));
            DataColumn [] _key = new DataColumn[3];
            _key[0] = rq_zz4ba.Columns["comp"];
            _key[1] = rq_zz4ba.Columns["dept"];            
            _key[2] = rq_zz4ba.Columns["sal_name"];
            rq_zz4ba.PrimaryKey = _key;
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_indt = DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd");

                if(report_content=="bonuses" || report_content == "all")
                {

                    if (bool.Parse(Row["yearpay"].ToString()))
                    {
                        object[] _value = new object[3];
                        _value[0] = Row["comp"].ToString();
                        _value[1] = Row["dept"].ToString();
                        _value[2] = "年終獎金提撥";
                        DataRow row = rq_zz4ba.Rows.Find(_value);
                        if (row != null)
                        {
                            row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "D") row["d_amt"] = int.Parse(row["d_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row["i_amt"] = int.Parse(row["i_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row["iper"] = ljobper;
                            if (Row["di"].ToString().Trim() == "D") row["dper"] = ljobper1;
                            row["pno"] = decimal.Parse(row["pno"].ToString()) + decimal.Parse(Row["pno"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_zz4ba.NewRow();
                            aRow["comp"] = Row["comp"].ToString();
                            aRow["compname"] = Row["compname"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["di"] = Row["di"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            aRow["d_amt"] = (Row["di"].ToString().Trim() == "D") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow["i_amt"] = (Row["di"].ToString().Trim() == "I") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow["iper"] = ljobper;
                            aRow["dper"] = ljobper1;
                            aRow["sal_name"] = "年終獎金提撥";
                            aRow["pno"] = decimal.Parse(Row["pno"].ToString());
                            rq_zz4ba.Rows.Add(aRow);
                        }
                    }
                }
                if (report_content == "pension" || report_content == "all")
                {
                    if (bool.Parse(Row["retire"].ToString()) && int.Parse(str_indt) < 20050701 && !bool.Parse(Row["noret"].ToString()))
                    {
                        object[] _value1 = new object[3];
                        _value1[0] = Row["comp"].ToString();
                        _value1[1] = Row["dept"].ToString();
                        _value1[2] = "退休金提撥";
                        DataRow row1 = rq_zz4ba.Rows.Find(_value1);
                        if (row1 != null)
                        {
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "D") row1["d_amt"] = int.Parse(row1["d_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row1["i_amt"] = int.Parse(row1["i_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row1["iper"] = retirerate;
                            if (Row["di"].ToString().Trim() == "D") row1["dper"] = retirerate1;
                            row1["pno"] = decimal.Parse(row1["pno"].ToString()) + decimal.Parse(Row["pno"].ToString());
                        }
                        else
                        {
                            DataRow aRow1 = rq_zz4ba.NewRow();
                            aRow1["comp"] = Row["comp"].ToString();
                            aRow1["compname"] = Row["compname"].ToString();
                            aRow1["dept"] = Row["dept"].ToString();
                            aRow1["d_name"] = Row["d_name"].ToString();
                            aRow1["di"] = Row["di"].ToString();
                            aRow1["amt"] = int.Parse(Row["amt"].ToString());
                            aRow1["d_amt"] = (Row["di"].ToString().Trim() == "D") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow1["i_amt"] = (Row["di"].ToString().Trim() == "I") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow1["iper"] = retirerate;
                            aRow1["dper"] = retirerate1;
                            aRow1["sal_name"] = "退休金提撥";
                            aRow1["pno"] = decimal.Parse(Row["pno"].ToString());
                            rq_zz4ba.Rows.Add(aRow1);
                        }
                    }
                }
            }
            //JBHR.Reports.ReportClass.Export(rq_zz4ba, "zz4b");
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\rq_zz4ba.xls", rq_zz4ba, true);
            //System.Diagnostics.Process.Start("C:\\TEMP\\rq_zz4ba.xls");

            DataRow[] row5 = rq_zz4ba.Select("", "sal_name,comp,dept asc");
            foreach (DataRow Row1 in row5)
            {
                DataRow aRow1 = DT_zz4b.NewRow();
                aRow1["comp"] = Row1["comp"].ToString();
                aRow1["comp"] = Row1["comp"].ToString();
                aRow1["compname"] = Row1["compname"].ToString();
                aRow1["dept"] = Row1["dept"].ToString();
                aRow1["d_name"] = Row1["d_name"].ToString();               
                aRow1["b_amt"] = int.Parse(Row1["amt"].ToString());
                aRow1["d_amt"] = Math.Round(decimal.Parse(Row1["d_amt"].ToString()) * decimal.Parse(Row1["dper"].ToString()), MidpointRounding.AwayFromZero);
                aRow1["i_amt"] = Math.Round(decimal.Parse(Row1["i_amt"].ToString()) * decimal.Parse(Row1["iper"].ToString()), MidpointRounding.AwayFromZero);
                aRow1["iper"] = decimal.Parse(Row1["iper"].ToString());
                aRow1["dper"] = decimal.Parse(Row1["dper"].ToString());
                aRow1["allamt"] = int.Parse(aRow1["i_amt"].ToString()) + int.Parse(aRow1["d_amt"].ToString());
                aRow1["sal_name"] = Row1["sal_name"];
                aRow1["pno"] = decimal.Parse(Row1["pno"].ToString());
                DT_zz4b.Rows.Add(aRow1);
            }
        }

        public static void GetZz4b1(DataTable DT_waged, DataTable DT_zz4b, DataTable DT_sys4, string report_content)
        {
            decimal ljobper = 0; decimal ljobper1 = 0; decimal retirerate = 0; decimal retirerate1 = 0;
            if (DT_sys4.Rows.Count > 0)
            {
                ljobper = decimal.Parse(DT_sys4.Rows[0]["ljobper"].ToString());
                ljobper1 = decimal.Parse(DT_sys4.Rows[0]["ljobper1"].ToString());
                retirerate = decimal.Parse(DT_sys4.Rows[0]["retirerate"].ToString());
                retirerate1 = decimal.Parse(DT_sys4.Rows[0]["retirerate1"].ToString());
            }
            DataTable rq_zz4ba = new DataTable();
            rq_zz4ba.Columns.Add("nobr", typeof(string));
            rq_zz4ba.Columns.Add("name_c", typeof(string));
            rq_zz4ba.Columns.Add("name_e", typeof(string));
            rq_zz4ba.Columns.Add("indt", typeof(DateTime));
            rq_zz4ba.Columns.Add("comp", typeof(string));
            rq_zz4ba.Columns.Add("compname", typeof(string));
            rq_zz4ba.Columns.Add("dept", typeof(string));
            rq_zz4ba.Columns.Add("d_name", typeof(string));
            rq_zz4ba.Columns.Add("di", typeof(string));
            rq_zz4ba.Columns.Add("sal_name", typeof(string));
            rq_zz4ba.Columns.Add("amt", typeof(int));
            rq_zz4ba.Columns.Add("d_amt", typeof(int));
            rq_zz4ba.Columns.Add("i_amt", typeof(int));
            rq_zz4ba.Columns.Add("iper", typeof(decimal));
            rq_zz4ba.Columns.Add("dper", typeof(decimal));
            DataColumn[] _key = new DataColumn[3];
            _key[0] = rq_zz4ba.Columns["nobr"];
            _key[1] = rq_zz4ba.Columns["sal_name"];
            _key[2] = rq_zz4ba.Columns["dept"];
            rq_zz4ba.PrimaryKey = _key;
            DataRow [] Srow = DT_waged.Select("di='D' or di='I'");
            foreach (DataRow Row in Srow)
            {
                int _DDD = int.Parse(Row["amt"].ToString()); ;
                string str_indt = DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd");

                if (report_content == "bonuses" || report_content == "all")
                {

                    if (bool.Parse(Row["yearpay"].ToString()))
                    {
                        object[] _value = new object[3];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = "年終獎金提撥";
                        _value[2] = Row["dept"].ToString();
                        DataRow row = rq_zz4ba.Rows.Find(_value);
                        if (row != null)
                        {
                            row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "D") row["d_amt"] = int.Parse(row["d_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row["i_amt"] = int.Parse(row["i_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row["iper"] = ljobper;
                            if (Row["di"].ToString().Trim() == "D") row["dper"] = ljobper1;
                        }
                        else
                        {
                            DataRow aRow = rq_zz4ba.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                            aRow["comp"] = Row["comp"].ToString();
                            aRow["compname"] = Row["compname"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["di"] = Row["di"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            aRow["d_amt"] = (Row["di"].ToString().Trim() == "D") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow["i_amt"] = (Row["di"].ToString().Trim() == "I") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow["iper"] = ljobper;
                            aRow["dper"] = ljobper1;
                            aRow["sal_name"] = "年終獎金提撥";

                            rq_zz4ba.Rows.Add(aRow);
                        }
                    }
                    //if (Row.IsNull("noret")) 
                    //    ljobper = 23;

                }
                if (report_content == "pension" || report_content == "all")
                {
                    if (bool.Parse(Row["retire"].ToString()) && int.Parse(str_indt) < 20050701 && !bool.Parse(Row["noret"].ToString()))
                    {
                        object[] _value1 = new object[3];
                        _value1[0] = Row["nobr"].ToString();
                        _value1[1] = "退休金提撥";
                        _value1[2] = Row["dept"].ToString();
                        DataRow row1 = rq_zz4ba.Rows.Find(_value1);
                        if (row1 != null)
                        {
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "D") row1["d_amt"] = int.Parse(row1["d_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row1["i_amt"] = int.Parse(row1["i_amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            if (Row["di"].ToString().Trim() == "I") row1["iper"] = retirerate;
                            if (Row["di"].ToString().Trim() == "D") row1["dper"] = retirerate1;
                        }
                        else
                        {
                            DataRow aRow1 = rq_zz4ba.NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["name_c"] = Row["name_c"].ToString();
                            aRow1["indt"] = DateTime.Parse(Row["indt"].ToString());
                            aRow1["comp"] = Row["comp"].ToString();
                            aRow1["compname"] = Row["compname"].ToString();
                            aRow1["dept"] = Row["dept"].ToString();
                            aRow1["d_name"] = Row["d_name"].ToString();
                            aRow1["di"] = Row["di"].ToString();
                            aRow1["amt"] = int.Parse(Row["amt"].ToString());
                            aRow1["d_amt"] = (Row["di"].ToString().Trim() == "D") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow1["i_amt"] = (Row["di"].ToString().Trim() == "I") ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow1["iper"] = retirerate;
                            aRow1["dper"] = retirerate1;
                            aRow1["sal_name"] = "退休金提撥";
                            rq_zz4ba.Rows.Add(aRow1);
                        }
                    }
                }
            }

            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\rq_zz4ba.xls", rq_zz4ba, true);
            //System.Diagnostics.Process.Start("C:\\TEMP\\rq_zz4ba.xls");

            DataRow[] row5 = rq_zz4ba.Select("", "sal_name,comp,dept,di,nobr asc");
            foreach (DataRow Row1 in row5)
            {
                DataRow aRow1 = DT_zz4b.NewRow();
                aRow1["nobr"] = Row1["nobr"].ToString();
                aRow1["name_c"] = Row1["name_c"].ToString();
                aRow1["name_e"] = Row1["name_e"].ToString();
                aRow1["indt"] = DateTime.Parse(Row1["indt"].ToString());
                aRow1["comp"] = Row1["comp"].ToString();
                aRow1["compname"] = Row1["compname"].ToString();
                aRow1["dept"] = Row1["dept"].ToString();
                aRow1["d_name"] = Row1["d_name"].ToString();
                aRow1["b_amt"] = int.Parse(Row1["amt"].ToString());
                aRow1["d_amt"] = Math.Round(decimal.Parse(Row1["d_amt"].ToString()) * decimal.Parse(Row1["dper"].ToString()), MidpointRounding.AwayFromZero);
                aRow1["i_amt"] = Math.Round(decimal.Parse(Row1["i_amt"].ToString()) * decimal.Parse(Row1["iper"].ToString()), MidpointRounding.AwayFromZero);
                aRow1["iper"] = decimal.Parse(Row1["iper"].ToString());
                aRow1["dper"] = decimal.Parse(Row1["dper"].ToString());
                aRow1["allamt"] = int.Parse(aRow1["i_amt"].ToString()) + int.Parse(aRow1["d_amt"].ToString());
                aRow1["sal_name"] = Row1["sal_name"];
                DT_zz4b.Rows.Add(aRow1);
            }
        }

        public static void ExPort1(DataTable DT_zz4b, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("提撥比率", typeof(string));
            ExporDt.Columns.Add("公司別", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(decimal));
            ExporDt.Columns.Add("薪資金額", typeof(int));
            ExporDt.Columns.Add("直接比率", typeof(decimal));
            ExporDt.Columns.Add("間接比率", typeof(decimal));
            ExporDt.Columns.Add("直接金額", typeof(int));
            ExporDt.Columns.Add("間接金額", typeof(int));
            foreach (DataRow Row01 in DT_zz4b.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["提撥比率"] = Row01["sal_name"].ToString();                
                aRow["公司別"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();                
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["人數"] = decimal.Parse(Row01["pno"].ToString());
                aRow["薪資金額"] = int.Parse(Row01["b_amt"].ToString());
                aRow["直接比率"] = decimal.Parse(Row01["dper"].ToString()) * 100;
                aRow["間接比率"] = decimal.Parse(Row01["iper"].ToString()) * 100;
                aRow["直接金額"] = int.Parse(Row01["d_amt"].ToString());
                aRow["間接金額"] = int.Parse(Row01["i_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort2(DataTable DT_zz4b1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("提撥比率", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("薪資金額", typeof(int));
            ExporDt.Columns.Add("直接人員", typeof(int));
            ExporDt.Columns.Add("間接人員", typeof(int));
            foreach (DataRow Row01 in DT_zz4b1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["提撥比率"] = Row01["sal_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["薪資金額"] = int.Parse(Row01["b_amt"].ToString());
                aRow["直接人員"] = int.Parse(Row01["d_amt"].ToString());
                aRow["間接人員"] = int.Parse(Row01["i_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
    }
}

