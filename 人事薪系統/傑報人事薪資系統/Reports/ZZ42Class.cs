/* ======================================================================================================
 * 功能名稱：發放薪資報表
 * 功能代號：ZZ42
 * 功能路徑：報表列印 > 薪資 > 發放薪資報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ42_Report.cs
 * 功能用途：
 *  用於產出發放薪資報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/05    Daniel Chih    Ver 1.0.01     1. 增加薪資單列印時判斷 loginUser 和當前使用頁面的公司類型
 * 2021/04/27    Daniel Chih    Ver 1.0.02     1. 增加僅【清展】可用的轉帳明細表
 * 2021/04/29    Daniel Chih    Ver 1.0.03     1. 增加【公司別】的篩選欄位對撈取資料內容的控制
 * 2021/05/03    Daniel Chih    Ver 1.0.04     1. 修正【清展轉帳明細表】篩選外勞匯出會出現錯誤的問題
 * 2021/05/13    Daniel Chih    Ver 1.0.05     1. 修改【清展轉帳明細表】產出資料排序
 * 2021/05/14    Daniel Chih    Ver 1.0.06     1. 修改薪資明細表-編制顯示儲蓄金（外籍）
 * 2021/07/07    Daniel Chih    Ver 1.0.07     1. 修改特休代碼與補休代碼的參考來源
 * 2021/08/17    Daniel Chih    Ver 1.0.08     1. 修改請假資料條件篩掉得假部分
 * 2021/09/22    Daniel Chih    Ver 1.0.09     1. 清展轉賬明細表：備註欄位帶畫面上的備註欄位
 * 2021/11/02    Daniel Chih    Ver 1.0.10     1. 修改【Mark】中關於離職狀態和期間有異動狀態的判斷
 * 2021/11/04    Daniel Chih    Ver 1.0.11     1. 判斷的【儲蓄金(外籍)】改成【儲蓄金】
 * 2021/11/10    Daniel Chih    Ver 1.0.12     1. 修改【臨時人數】撈取規則，代碼讀自Appconfig，報表結果增加【公司名稱】欄位
 * 
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/11/10
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;
using JBModule.Data.Linq;

namespace JBHR.Reports
{
    public class ZZ42Class
    {
        public static DataTable Get_base2(string lcstr2, string date_b, string dept_b, string dept_e, string depts_b, string depts_e, string comp_b, string comp_e, string saladr_b, string saladr_e, string nobr_b, string nobr_e, string emp_b, string emp_e, string report_type_item)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "";

            sqlCmd += "select b.nobr,a.name_c,a.idno,a.sex,a.count_ma,a.bbcall,b.di,b.adate,b.indt,b.oudt,b.holi_code,";
            sqlCmd += "b.rotet,b.comp,a.taxno,a.account_ma,k.BANKNAME, a.account_no,l.BANKNAME AS R_BANKNAME,b.ttscode,b.workcd,b.empcd,e.d_no as depts_d_no,e.d_no_disp as depts,e.d_name as ds_name,";
            sqlCmd += "c.d_no_disp as dept,c.d_name,a.email,b.noret,d.job_disp as job,d.job_name,h.jobl_disp as jobl,h.job_name as jobl_name,";
            sqlCmd += "i.compname,i.compid, b.saladr,b.tax_date,b.tax_edate,a.matno,i.account,k.CODE_DISP AS bankno,a.name_e,a.password,";
            sqlCmd += "b.retchoo,b.retdate,b.retdate1,a.account_na,b.jobo,j.job_name as jobo_name,a.country,l.CODE_DISP AS bank_code";
            sqlCmd += string.Format(@",DBO.GETTOTALYEARS(A.NOBR,'{0}') as wk_yrs1", date_b);
            sqlCmd += " from base a inner join basetts b on a.nobr=b.nobr ";
            sqlCmd += " left outer join dept c on b.dept=c.d_no";
            sqlCmd += " left outer join depts e on b.depts=e.d_no";
            sqlCmd += " left outer join job d on b.job=d.job";
            sqlCmd += " left outer join jobl h on b.jobl=h.jobl";
            sqlCmd += " left outer join comp i on b.comp=i.comp";
            sqlCmd += " left outer join jobo j on b.jobo=j.jobo";
            sqlCmd += " left join BANKCODE k on a.BANK_CODE = k.CODE ";
            sqlCmd += " left join BANKCODE l on a.BANKNO = l.CODE ";
            sqlCmd += " where 1 = 1 ";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
            //sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
            sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
            sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
            sqlCmd += string.Format(@" and e.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
            sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
            sqlCmd += lcstr2;

            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_base3(string lcstr2, string date_b, string nobr_b, string nobr_e)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select b.nobr,a.name_c,a.idno,a.sex,a.count_ma,a.bbcall,b.di,b.adate,b.indt,";
            sqlCmd += "b.oudt,b.holi_code,b.rotet,b.comp,a.taxno,a.account_ma,b.ttscode,b.workcd,b.empcd,e.d_no_disp as depts,";
            sqlCmd += "c.d_no_disp as dept,c.d_name,b.noret,d.job_disp as job,d.job_name,h.jobl_disp as jobl,h.job_name as jobl_name,";
            sqlCmd += "i.compname,i.compid,a.matno,i.account,a.bankno,a.name_e,a.password,b.retchoo,b.retdate,b.retdate1";
            sqlCmd += " from base a,basetts b";
            sqlCmd += " left outer join dept c on b.dept=c.d_no";
            sqlCmd += " left outer join job d on b.job=d.job";
            sqlCmd += " left outer join depts e on b.depts=e.d_no";
            sqlCmd += " left outer join jobl h on b.jobl=h.jobl";
            sqlCmd += " left outer join comp i on b.comp=i.comp";
            sqlCmd += " where a.nobr=b.nobr ";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
            sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += lcstr2;
            return Sql.GetDataTable(sqlCmd);
        }

        public static void Get_Report6A(DataTable DT_zz42td, DataTable DT_waged, DataTable DT_base)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                bool str_cash = bool.Parse(Row["cash"].ToString());
                bool str_forcash = bool.Parse(Row["forcash"].ToString());
                string str_nobr = Row["nobr"].ToString();
                if (str_cash || str_forcash || (Row["sal_code"].ToString().Trim() == "R01" && !bool.Parse(Row["count_ma"].ToString()))) //本勞有轉帳代號顯示在現金表裡
                {
                    DataRow row = DT_base.Rows.Find(str_nobr);
                    if (row != null)
                    {
                        object[] _value = new object[2];
                        _value[0] = row["comp"].ToString();
                        _value[1] = row["dept"].ToString();
                        DataRow row1 = DT_zz42td.Rows.Find(_value);
                        if (row1 != null)
                            row1["amt"] = decimal.Parse(row1["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = DT_zz42td.NewRow();
                            aRow["nobr"] = str_nobr;
                            aRow["name_c"] = row1["name_c"].ToString();
                            aRow["idno"] = row1["idno"].ToString();
                            aRow["dept"] = row1["dept"].ToString();
                            aRow["account_no"] = row1["account_no"].ToString();
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow["workcd"] = Row["comp"].ToString();
                            aRow["note"] = Row["note"].ToString();
                            aRow["cash"] = bool.Parse("true");
                            DT_zz42td.Rows.Add(aRow);
                        }
                    }
                }
            }
        }

        public static void Get_Report6B(DataTable DT_zz42td, DataTable DT_waged, DataTable DT_base)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_nobr = Row["nobr"].ToString();
                bool str_forbank = bool.Parse(Row["forbank"].ToString());
                if (str_forbank)
                {
                    DataRow row17 = DT_base.Rows.Find(str_nobr);
                    if (row17 != null)
                    {
                        DataRow aRow = DT_zz42td.NewRow();
                        aRow["nobr"] = str_nobr;
                        aRow["name"] = row17["name_c"].ToString();
                        aRow["dept"] = row17["dept"].ToString();
                        aRow["idno"] = row17["idno"].ToString();
                        aRow["account_no"] = row17["account_no"].ToString();
                        aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                        aRow["cash"] = bool.Parse(Row["cash"].ToString());
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["note"] = Row["note"].ToString();
                        aRow["date_b"] = DateTime.Parse(Row["date_b"].ToString());
                        aRow["date_e"] = DateTime.Parse(Row["date_e"].ToString());
                        DT_zz42td.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void Get_wageds1(DataTable DT_wageds1, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("salattr<='F'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot1"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot1"] = 0;
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_wageds2(DataTable DT_wageds2, DataTable DT_waged, DataTable DT_base, string retirerate)
        {
            DataRow[] row1 = DT_waged.Select("salattr <='L' and sal_code <>'" + retirerate + "'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds2.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds2.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds2.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void Get_wagedsz(DataTable DT_wageds1, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("", "nobr asc");
            // 2014/01/08R01外勞定存要顯示R02不顯示,實發薪資含外勞定存金額
            //DataRow[] row1 = DT_waged.Select("sal_code<>'R01'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["totz"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["totz"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["totz"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["totz"] = 0;
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_wagedup1(DataTable DT_wagedup1, DataTable DT_waged1, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged1.Select("salattr<='F'");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wagedup1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wagedup1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot1"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wagedup1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wagedup1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wagedup1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot1"] = 0;
                    DT_wagedup1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_wagedup2(DataTable DT_wagedup2, DataTable DT_waged1, DataTable DT_base, string retirerate)
        {
            DataRow[] row1 = DT_waged1.Select("salattr <='L' and sal_code <>'" + retirerate + "'");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wagedup2.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wagedup2.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wagedup2.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wagedup2.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wagedup2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wagedup2.Rows.Add(aRow);
                }

            }
        }

        public static void Get_wagedupz(DataTable DT_wagedupz, DataTable DT_waged1, DataTable DT_base)
        {
            foreach (DataRow Row1 in DT_waged1.Rows)
            {
                DataRow row3 = DT_wagedupz.Rows.Find(Row1["nobr"].ToString());
                if (row3 != null)
                {
                    row3["totz"] = decimal.Parse(Row1["amt"].ToString()) + decimal.Parse(row3["totz"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wagedupz.NewRow();
                    aRow["nobr"] = Row1["nobr"].ToString();
                    aRow["totz"] = decimal.Parse(Row1["amt"].ToString());
                    DT_wagedupz.Rows.Add(aRow);
                }
            }


            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wagedupz.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wagedupz.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["totz"] = 0;
                    DT_wagedupz.Rows.Add(aRow);
                }
            }
        }


        public static void Get_zz4aawageds1(DataTable DT_wageds1, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("salattr<='B'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot1"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot1"] = 0;
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz4aawageds2(DataTable DT_wageds2, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("salattr ='D'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                decimal _amt = decimal.Parse(row1[i]["amt"].ToString());
                if (row1[i]["flag"].ToString().Trim() == "-")
                    _amt = decimal.Parse(row1[i]["amt"].ToString()) * (-1);
                DataRow row3 = DT_wageds2.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = _amt + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = _amt;
                    DT_wageds2.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds2.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz4aawageds3(DataTable DT_wageds3, DataTable DT_waged, DataTable DT_base, string taxsalcode)
        {
            DataRow[] row1 = DT_waged.Select("sal_code ='" + taxsalcode + "'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                decimal _amt = decimal.Parse(row1[i]["amt"].ToString());
                if (row1[i]["flag"].ToString().Trim() == "-")
                    _amt = decimal.Parse(row1[i]["amt"].ToString()) * (-1);
                DataRow row3 = DT_wageds3.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = _amt + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds3.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = _amt;
                    DT_wageds3.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds3.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds3.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wageds3.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz4aawageds4(DataTable DT_wageds4, DataTable DT_waged, DataTable DT_base, string taxsalcode)
        {
            DataRow[] row1 = DT_waged.Select("salattr ='N' and sal_code <>'" + taxsalcode + "'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                decimal _amt = decimal.Parse(row1[i]["amt"].ToString());
                if (row1[i]["flag"].ToString().Trim() == "-")
                    _amt = decimal.Parse(row1[i]["amt"].ToString()) * (-1);
                DataRow row3 = DT_wageds4.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = _amt + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds4.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = _amt;
                    DT_wageds4.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds4.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds4.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wageds4.Rows.Add(aRow);
                }
            }
        }


        public static void Get_zz422(DataTable DT_zz422, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_salattr = Row["salattr"].ToString();
                string str_flag = Row["flag"].ToString();
                object[] _value = new object[3];
                _value[0] = "0001";
                _value[1] = str_salattr + str_salcode;
                if (str_flag == "-")
                {
                    _value[2] = "2";
                    DataRow row = DT_zz422.Rows.Find(_value);
                    if (row == null)
                    {
                        DataRow aRow = DT_zz422.NewRow();
                        aRow["code1"] = "0001";
                        aRow["salattr"] = str_salattr + str_salcode;
                        aRow["sal_name"] = "2";
                        DT_zz422.Rows.Add(aRow);
                    }
                }
                else
                {
                    _value[2] = "1";
                    DataRow row1 = DT_zz422.Rows.Find(_value);
                    if (row1 == null)
                    {
                        DataRow aRow = DT_zz422.NewRow();
                        aRow["code1"] = "0001";
                        aRow["salattr"] = str_salattr + str_salcode;
                        aRow["sal_name"] = "1";
                        DT_zz422.Rows.Add(aRow);
                    }
                }
            }

        }

        public static void Get_zz423(DataTable DT_zz423, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_amt = Row["amt"].ToString();
                bool str_tax = bool.Parse(Row["tax"].ToString());
                string str_salattr = Row["salattr"].ToString();
                object[] _value = new object[3];
                _value[0] = "0002";
                _value[1] = str_salattr + str_salcode;

                if (str_tax)
                {
                    _value[2] = "應稅";
                    DataRow row = DT_zz423.Rows.Find(_value);
                    if (row == null)
                    {
                        DataRow aRow = DT_zz423.NewRow();
                        aRow["code1"] = "0002";
                        aRow["salattr"] = str_salattr + str_salcode;
                        aRow["sal_name"] = "應稅";
                        DT_zz423.Rows.Add(aRow);
                    }
                }
                else
                {
                    _value[2] = "免稅";
                    DataRow row1 = DT_zz423.Rows.Find(_value);
                    if (row1 == null)
                    {
                        DataRow aRow = DT_zz423.NewRow();
                        aRow["code1"] = "0002";
                        aRow["salattr"] = str_salattr + str_salcode;
                        aRow["sal_name"] = "免稅";
                        DT_zz423.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void Get_zz421(DataTable DT_zz421, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_ename = Row["sal_ename"].ToString();

                DataRow aRow = DT_zz421.NewRow();
                aRow["code1"] = "0000";
                aRow["salattr"] = Row["salattr"].ToString() + str_salcode;
                aRow["sal_name"] = str_ename;
                DT_zz421.Rows.Add(aRow);
            }
        }

        public static void Get_zz421_a(DataTable DT_zz421, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_name = Row["sal_name"].ToString();
                string str_salattr = Row["salattr"].ToString();
                DataRow aRow = DT_zz421.NewRow();
                aRow["code1"] = "0000";
                aRow["salattr"] = Row["salattr"].ToString() + str_salcode;
                aRow["sal_name"] = str_name;
                DT_zz421.Rows.Add(aRow);
            }
        }

        public static void Get_zz42a(DataTable DT_zz42, DataTable DT_waged)
        {
            DT_zz42.PrimaryKey = new DataColumn[] { DT_zz42.Columns["nobr"], DT_zz42.Columns["ttrcode"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                decimal str_amt = decimal.Parse(Row["amt"].ToString());
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["salattr"].ToString() + str_salcode;
                DataRow row = DT_zz42.Rows.Find(_value);
                if (row != null)
                    row["amt"] = decimal.Parse(row["amt"].ToString()) + str_amt;
                else
                {
                    if (str_amt != 0)
                    {
                        DataRow aRow = DT_zz42.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["ttrcode"] = Row["salattr"].ToString() + str_salcode;
                        aRow["amt"] = str_amt;
                        DT_zz42.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void Get_zz422a(DataTable DT_zz422, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_salattr = Row["salattr"].ToString();
                string str_flag = Row["flag"].ToString();
                decimal str_amt = decimal.Parse(Row["amt"].ToString());
                string str1 = str_salattr + str_salcode;
                object[] _value = new object[3];
                _value[0] = "0001";
                _value[1] = str_salattr + str_salcode;
                if (str_amt != 0)
                {
                    if (str_flag == "-")
                    {
                        _value[2] = "2";
                        DataRow row = DT_zz422.Rows.Find(_value);
                        if (row == null)
                        {
                            //ds.EnforceConstraints = false;
                            DataRow aRow = DT_zz422.NewRow();
                            aRow["code1"] = "0001";
                            aRow["salattr"] = str_salattr + str_salcode;
                            aRow["sal_name"] = "2";
                            DT_zz422.Rows.Add(aRow);
                        }
                    }
                    else
                    {
                        _value[2] = "1";
                        DataRow row1 = DT_zz422.Rows.Find(_value);
                        if (row1 == null)
                        {
                            //ds.EnforceConstraints = false;
                            DataRow aRow = DT_zz422.NewRow();
                            aRow["code1"] = "0001";
                            aRow["salattr"] = str_salattr + str_salcode;
                            aRow["sal_name"] = "1";
                            DT_zz422.Rows.Add(aRow);
                        }
                    }
                }
            }
        }

        public static void Get_zz423a(DataTable DT_zz423, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_salattr = Row["salattr"].ToString();
                string str_flag = Row["flag"].ToString();
                decimal str_amt = decimal.Parse(Row["amt"].ToString());
                string str1 = str_salattr + str_salcode;
                object[] _value = new object[3];
                _value[0] = "0001";
                _value[1] = str_salattr + str_salcode;
                if (str_amt != 0)
                {
                    if (str_flag == "-")
                    {
                        _value[2] = "2";
                        DataRow row = DT_zz423.Rows.Find(_value);
                        if (row == null)
                        {
                            //ds.EnforceConstraints = false;
                            DataRow aRow = DT_zz423.NewRow();
                            aRow["code1"] = "0001";
                            aRow["salattr"] = str_salattr + str_salcode;
                            aRow["sal_name"] = "2";
                            DT_zz423.Rows.Add(aRow);
                        }
                    }
                    else
                    {
                        _value[2] = "1";
                        DataRow row1 = DT_zz423.Rows.Find(_value);
                        if (row1 == null)
                        {
                            //ds.EnforceConstraints = false;
                            DataRow aRow = DT_zz423.NewRow();
                            aRow["code1"] = "0001";
                            aRow["salattr"] = str_salattr + str_salcode;
                            aRow["sal_name"] = "1";
                            DT_zz423.Rows.Add(aRow);
                        }
                    }
                }
            }
        }

        public static void Get_zz421_b(DataTable DT_zz421, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_name = Row["sal_name"].ToString();
                decimal str_amt = decimal.Parse(Row["amt"].ToString());
                if (str_amt != 0)
                {
                    DataRow aRow = DT_zz421.NewRow();
                    aRow["code1"] = "0000";
                    aRow["salattr"] = Row["salattr"].ToString() + str_salcode;
                    aRow["sal_name"] = str_name;
                    DT_zz421.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz421_c(DataTable DT_zz421, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["sal_code"].ToString();
                string str_name = Row["sal_ename"].ToString();
                decimal str_amt = decimal.Parse(Row["amt"].ToString());
                if (str_amt != 0)
                {
                    DataRow aRow = DT_zz421.NewRow();
                    aRow["code1"] = "0000";
                    aRow["salattr"] = Row["salattr"].ToString() + str_salcode;
                    aRow["sal_name"] = str_name;
                    DT_zz421.Rows.Add(aRow);
                }
            }
        }

        public static void Get_appzz421(DataTable DT_zz421, DataTable DT_zz422, DataTable DT_zz423)
        {
            foreach (DataRow Row in DT_zz422.Rows)
            {
                DataRow aRow = DT_zz421.NewRow();
                aRow["code1"] = Row["code1"].ToString();
                aRow["salattr"] = Row["salattr"].ToString();
                aRow["sal_name"] = Row["sal_name"].ToString();
                DT_zz421.Rows.Add(aRow);
            }
            foreach (DataRow Row1 in DT_zz423.Rows)
            {
                DataRow aRow = DT_zz421.NewRow();
                aRow["code1"] = Row1["code1"].ToString();
                aRow["salattr"] = Row1["salattr"].ToString();
                aRow["sal_name"] = Row1["sal_name"].ToString();
                DT_zz421.Rows.Add(aRow);
            }
        }

        public static void Get_zz4211(DataTable DT_zz4211, DataTable DT_zz421)
        {
            DataRow[] row31 = DT_zz421.Select("", "code1,salattr asc");
            foreach (DataRow Row in row31)
            {
                DataRow aRow = DT_zz4211.NewRow();
                aRow["code1"] = Row["code1"].ToString();
                aRow["salattr"] = Row["salattr"].ToString();
                aRow["sal_name"] = Row["sal_name"].ToString();
                DT_zz4211.Rows.Add(aRow);
            }
        }

        public static void Get_zz42gt(DataTable DT_zz42gt, DataTable DT_zz4211)
        {
            DataRow[] row = DT_zz4211.Select("code1='0000'");
            foreach (DataRow Row in row)
            {
                string str_ttrcode = Row["salattr"].ToString();
                DataRow row32 = DT_zz42gt.Rows.Find(str_ttrcode);
                if (row32 == null)
                {
                    DataRow aRow = DT_zz42gt.NewRow();
                    aRow["ttrcode"] = Row["salattr"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    DT_zz42gt.Rows.Add(aRow);
                }
            }
        }



        public static void Get_zz42add(DataTable DT_zz42, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz)
        {
            DataTable P_zz42 = new DataTable("P_zz42");
            P_zz42.Columns.Add("nobr", typeof(string));
            P_zz42.PrimaryKey = new DataColumn[] { P_zz42.Columns["nobr"] };
            foreach (DataRow Row in DT_zz42.Rows)
            {
                DataRow row5 = P_zz42.Rows.Find(Row["nobr"].ToString());
                if (row5 == null)
                {
                    DataRow aRow5 = P_zz42.NewRow();
                    aRow5["nobr"] = Row["nobr"].ToString();
                    P_zz42.Rows.Add(aRow5);
                }
            }

            for (int i = 0; i < DT_wageds1.Rows.Count; i++)
            {
                string str_nobr = DT_wageds1.Rows[i]["nobr"].ToString();
                DataRow row60 = P_zz42.Rows.Find(str_nobr);
                if (row60 != null)
                {
                    DataRow aRow = DT_zz42.NewRow();
                    aRow["nobr"] = str_nobr;
                    aRow["ttrcode"] = "F";
                    aRow["amt"] = decimal.Parse(DT_wageds1.Rows[i]["tot1"].ToString());
                    DT_zz42.Rows.Add(aRow);
                }
            }


            for (int i = 0; i < DT_wageds2.Rows.Count; i++)
            {
                string str_nobr = DT_wageds2.Rows[i]["nobr"].ToString();
                DataRow row61 = P_zz42.Rows.Find(str_nobr);
                if (row61 != null)
                {
                    DataRow aRow1 = DT_zz42.NewRow();
                    aRow1["nobr"] = str_nobr;
                    aRow1["ttrcode"] = "L";
                    aRow1["amt"] = decimal.Parse(DT_wageds2.Rows[i]["tot2"].ToString());
                    DT_zz42.Rows.Add(aRow1);
                }
            }


            //for (int i = 0; i < DT_wagedsy.Rows.Count; i++)
            //{
            //    string str_nobr = DT_wagedsy.Rows[i]["nobr"].ToString();
            //    DataRow row62 = P_zz42.Rows.Find(str_nobr);
            //    if (row62 != null)
            //    {
            //        DataRow aRow2 = DT_zz42.NewRow();
            //        aRow2["nobr"] = str_nobr;
            //        aRow2["ttrcode"] = "O";
            //        aRow2["amt"] = decimal.Parse(DT_wagedsy.Rows[i]["toty"].ToString());
            //        DT_zz42.Rows.Add(aRow2);
            //    }
            //}

            for (int i = 0; i < DT_wagedsz.Rows.Count; i++)
            {
                string str_nobr = DT_wagedsz.Rows[i]["nobr"].ToString();
                DataRow row63 = P_zz42.Rows.Find(str_nobr);
                if (row63 != null)
                {
                    DataRow aRow3 = DT_zz42.NewRow();
                    aRow3["nobr"] = str_nobr;
                    aRow3["ttrcode"] = "O";
                    aRow3["amt"] = decimal.Parse(DT_wagedsz.Rows[i]["totz"].ToString());
                    DT_zz42.Rows.Add(aRow3);
                }
            }
        }


        public static void Get_zz4aaadd(DataTable DT_zz42, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wageds3, DataTable DT_wageds4, DataTable DT_wagedsz)
        {
            DataTable P_zz42 = new DataTable("P_zz42");
            P_zz42.Columns.Add("nobr", typeof(string));
            P_zz42.PrimaryKey = new DataColumn[] { P_zz42.Columns["nobr"] };
            foreach (DataRow Row in DT_zz42.Rows)
            {
                DataRow row5 = P_zz42.Rows.Find(Row["nobr"].ToString());
                if (row5 == null)
                {
                    DataRow aRow5 = P_zz42.NewRow();
                    aRow5["nobr"] = Row["nobr"].ToString();
                    P_zz42.Rows.Add(aRow5);
                }
            }

            for (int i = 0; i < DT_wageds1.Rows.Count; i++)
            {
                string str_nobr = DT_wageds1.Rows[i]["nobr"].ToString();
                DataRow row60 = P_zz42.Rows.Find(str_nobr);
                if (row60 != null)
                {
                    DataRow aRow = DT_zz42.NewRow();
                    aRow["nobr"] = str_nobr;
                    aRow["ttrcode"] = "BZ";
                    aRow["amt"] = decimal.Parse(DT_wageds1.Rows[i]["tot1"].ToString());
                    DT_zz42.Rows.Add(aRow);
                }
            }


            for (int i = 0; i < DT_wageds2.Rows.Count; i++)
            {
                string str_nobr = DT_wageds2.Rows[i]["nobr"].ToString();
                DataRow row61 = P_zz42.Rows.Find(str_nobr);
                if (row61 != null)
                {
                    DataRow aRow1 = DT_zz42.NewRow();
                    aRow1["nobr"] = str_nobr;
                    aRow1["ttrcode"] = "DZ";
                    aRow1["amt"] = decimal.Parse(DT_wageds2.Rows[i]["tot2"].ToString());
                    DT_zz42.Rows.Add(aRow1);
                }
            }

            for (int i = 0; i < DT_wageds3.Rows.Count; i++)
            {
                string str_nobr = DT_wageds3.Rows[i]["nobr"].ToString();
                DataRow row61a = P_zz42.Rows.Find(str_nobr);
                if (row61a != null)
                {
                    DataRow aRowa1 = DT_zz42.NewRow();
                    aRowa1["nobr"] = str_nobr;
                    aRowa1["ttrcode"] = "FZ";
                    aRowa1["amt"] = decimal.Parse(DT_wageds3.Rows[i]["tot2"].ToString());
                    DT_zz42.Rows.Add(aRowa1);
                }
            }
            for (int i = 0; i < DT_wageds4.Rows.Count; i++)
            {
                string str_nobr = DT_wageds4.Rows[i]["nobr"].ToString();
                DataRow row61b = P_zz42.Rows.Find(str_nobr);
                if (row61b != null)
                {
                    DataRow aRow1b = DT_zz42.NewRow();
                    aRow1b["nobr"] = str_nobr;
                    aRow1b["ttrcode"] = "NZ";
                    aRow1b["amt"] = decimal.Parse(DT_wageds4.Rows[i]["tot2"].ToString());
                    DT_zz42.Rows.Add(aRow1b);
                }
            }
            for (int i = 0; i < DT_wagedsz.Rows.Count; i++)
            {
                string str_nobr = DT_wagedsz.Rows[i]["nobr"].ToString();
                DataRow row63 = P_zz42.Rows.Find(str_nobr);
                if (row63 != null)
                {
                    DataRow aRow3 = DT_zz42.NewRow();
                    aRow3["nobr"] = str_nobr;
                    aRow3["ttrcode"] = "OZ";
                    aRow3["amt"] = decimal.Parse(DT_wagedsz.Rows[i]["totz"].ToString());
                    DT_zz42.Rows.Add(aRow3);
                }
            }
        }

        public static void Get_zz42t(DataTable DT_zz42ta, DataTable DT_zz42tb, DataTable DT_zz42gt, DataTable DT_zz42, DataTable DT_rq_base, string report_type_item)
        {
            if (report_type_item == "【清展】轉帳明細表")
            {
                Hashtable ht = new Hashtable();
                DataTable zz42gtt = new DataTable("zz42gtt");
                zz42gtt.Columns.Add("nobr", typeof(string));
                zz42gtt.Columns.Add("bankno", typeof(string));
                zz42gtt.Columns.Add("mark", typeof(string));
                zz42gtt.PrimaryKey = new DataColumn[] { zz42gtt.Columns["nobr"], zz42gtt.Columns["bankno"] };
                for (int i = 0; i < DT_zz42gt.Rows.Count; i++)
                {
                    zz42gtt.Columns.Add(DT_zz42gt.Rows[i][0].ToString().Trim(), typeof(decimal));
                    ht.Add("Fld" + (i + 1), DT_zz42gt.Rows[i][1].ToString());
                }
                for (int i = 0; i < DT_zz42.Rows.Count; i++)
                {
                    if (DT_zz42.Rows[i]["TTRCODE"].ToString().Trim().Substring(0, 1) != "R")
                    {
                        object[] Value = new object[2];
                        Value[0] = DT_zz42.Rows[i]["nobr"].ToString();
                        Value[1] = DT_rq_base.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString())["account_no"].ToString();

                        DataRow dr = zz42gtt.Rows.Find(Value);
                        if (dr == null)
                        {//new
                            DataRow newRow = zz42gtt.NewRow();
                            newRow["nobr"] = DT_zz42.Rows[i]["nobr"].ToString();
                            newRow["bankno"] = DT_rq_base.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString())["account_no"].ToString();
                            newRow["mark"] = "_no";
                            //if(ds.Tables["rq_abs2"].Rows[i]["h_code"].ToString().IndexOf("W")>=0)
                            newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                            zz42gtt.Rows.Add(newRow);
                        }
                        else
                        {//update
                            DataRow newRow = dr;
                            newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());

                        }
                    }
                    else
                    {
                        object[] Value = new object[2];
                        Value[0] = DT_zz42.Rows[i]["nobr"].ToString();
                        Value[1] = DT_rq_base.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString())["account_ma"].ToString();

                        DataRow dr = zz42gtt.Rows.Find(Value);
                        if (dr == null)
                        {//new
                            DataRow newRow = zz42gtt.NewRow();
                            newRow["nobr"] = DT_zz42.Rows[i]["nobr"].ToString();
                            newRow["bankno"] = DT_rq_base.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString())["account_ma"].ToString();
                            newRow["mark"] = "_ma";
                            //if(ds.Tables["rq_abs2"].Rows[i]["h_code"].ToString().IndexOf("W")>=0)
                            newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                            zz42gtt.Rows.Add(newRow);
                        }
                        else
                        {//update
                            DataRow newRow = dr;
                            newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());

                        }
                    }
                }

                DataRow newRow2 = DT_zz42ta.NewRow();
                for (int i = 0; i < ht.Count; i++)
                {
                    newRow2["Fld" + (i + 1)] = ht["Fld" + (i + 1)].ToString();
                }
                DT_zz42ta.Rows.Add(newRow2);


                for (int i = 0; i < zz42gtt.Rows.Count; i++)
                {
                    string str_nobr = zz42gtt.Rows[i]["nobr"].ToString();
                    DataRow row8 = DT_rq_base.Rows.Find(str_nobr);
                    if (row8 != null)
                    {
                        DataRow newRow = DT_zz42tb.NewRow();
                        newRow["Nobr"] = row8["nobr"].ToString();
                        newRow["Name_c"] = row8["name_c"].ToString();
                        newRow["Dept"] = row8["dept"].ToString();
                        newRow["D_name"] = row8["d_name"].ToString();
                        newRow["comp"] = row8["comp"].ToString();
                        newRow["jobl"] = row8["jobl"].ToString();
                        newRow["account_no"] = zz42gtt.Rows[i]["bankno"].ToString();
                        newRow["mark"] = zz42gtt.Rows[i]["mark"].ToString();
                        for (int j = 3; j < zz42gtt.Columns.Count; j++)
                        {
                            //							newRow["Fld"+j] =ds.Tables["zz23d"].Rows[i][ds.Tables["zz23d"].Columns[j].ColumnName].ToString();
                            if (zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString().Length == 0)
                            {
                                newRow["Fld" + (j - 2)] = 0;
                            }
                            else
                            {
                                newRow["Fld" + (j - 2)] = decimal.Parse(zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString());
                            }
                        }

                        DT_zz42tb.Rows.Add(newRow);
                    }
                }
            }
            else
            {

                Hashtable ht = new Hashtable();
                DataTable zz42gtt = new DataTable("zz42gtt");
                zz42gtt.Columns.Add("nobr", typeof(string));
                zz42gtt.PrimaryKey = new DataColumn[] { zz42gtt.Columns["nobr"] };
                for (int i = 0; i < DT_zz42gt.Rows.Count; i++)
                {
                    zz42gtt.Columns.Add(DT_zz42gt.Rows[i][0].ToString().Trim(), typeof(decimal));
                    ht.Add("Fld" + (i + 1), DT_zz42gt.Rows[i][1].ToString());

                }
                for (int i = 0; i < DT_zz42.Rows.Count; i++)
                {
                    DataRow dr = zz42gtt.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString());
                    if (dr == null)
                    {//new
                        DataRow newRow = zz42gtt.NewRow();
                        newRow["nobr"] = DT_zz42.Rows[i]["nobr"].ToString();
                        //if(ds.Tables["rq_abs2"].Rows[i]["h_code"].ToString().IndexOf("W")>=0)
                        newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                        zz42gtt.Rows.Add(newRow);
                    }
                    else
                    {//update
                        DataRow newRow = dr;
                        newRow[DT_zz42.Rows[i]["ttrcode"].ToString()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());

                    }
                }

                DataRow newRow2 = DT_zz42ta.NewRow();
                for (int i = 0; i < ht.Count; i++)
                {
                    newRow2["Fld" + (i + 1)] = ht["Fld" + (i + 1)].ToString();
                }
                DT_zz42ta.Rows.Add(newRow2);


                for (int i = 0; i < zz42gtt.Rows.Count; i++)
                {
                    string str_nobr = zz42gtt.Rows[i]["nobr"].ToString();
                    DataRow row8 = DT_rq_base.Rows.Find(str_nobr);
                    if (row8 != null)
                    {
                        DataRow newRow = DT_zz42tb.NewRow();
                        newRow["Nobr"] = row8["nobr"].ToString();
                        newRow["Name_c"] = row8["name_c"].ToString();
                        newRow["Dept"] = row8["dept"].ToString();
                        newRow["D_name"] = row8["d_name"].ToString();
                        newRow["comp"] = row8["comp"].ToString();
                        newRow["jobl"] = row8["jobl"].ToString();
                        for (int j = 1; j < zz42gtt.Columns.Count; j++)
                        {
                            //							newRow["Fld"+j] =ds.Tables["zz23d"].Rows[i][ds.Tables["zz23d"].Columns[j].ColumnName].ToString();
                            if (zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString().Length == 0)
                            {
                                newRow["Fld" + j] = 0;
                            }
                            else
                            {
                                newRow["Fld" + j] = decimal.Parse(zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString());
                            }
                        }

                        DT_zz42tb.Rows.Add(newRow);
                    }
                }
            }
        }

        public static void Get_Eplab(DataTable DT_explab, DataTable DT_explab1)
        {
            foreach (DataRow Row in DT_explab1.Rows)
            {
                Row["comp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["comp"].ToString()));
                DataRow row1 = DT_explab.Rows.Find(Row["nobr"].ToString());
                if (row1 != null)
                {
                    if (Row["insur_type"].ToString().Trim() == "1")
                        row1["l_amt"] = int.Parse(Row["comp"].ToString());
                    else if (Row["insur_type"].ToString().Trim() == "2")
                        row1["h_amt"] = int.Parse(Row["comp"].ToString());
                    else if (Row["insur_type"].ToString().Trim() == "4")
                        row1["r_amt"] = int.Parse(Row["comp"].ToString());
                }
                else
                {
                    DataRow aRow = DT_explab.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["h_amt"] = 0;
                    aRow["l_amt"] = 0;
                    aRow["r_amt"] = 0;
                    if (Row["insur_type"].ToString().Trim() == "1")
                        aRow["l_amt"] = int.Parse(Row["comp"].ToString());
                    else if (Row["insur_type"].ToString().Trim() == "2")
                        aRow["h_amt"] = int.Parse(Row["comp"].ToString());
                    else if (Row["insur_type"].ToString().Trim() == "4")
                        aRow["r_amt"] = int.Parse(Row["comp"].ToString());
                    DT_explab.Rows.Add(aRow);
                }

            }
        }

        public static void Get_zz42td2(DataTable DT_zz42td, DataTable DT_zz42tb, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz, DataTable DT_base, DataTable DT_explab, DataTable DT_depts, string reporttype, string year, string month, string order, string report_type_item)
        {
            DataTable P_waged = new DataTable("P_waged");
            if (reporttype == "9")
            {
                P_waged.Columns.Add("nobr", typeof(string));
                P_waged.Columns.Add("adate", typeof(DateTime));
                P_waged.Columns.Add("cash", typeof(bool));
                P_waged.Columns.Add("wk_days", typeof(decimal));
                P_waged.Columns.Add("note", typeof(string));
                P_waged.Columns.Add("account_no", typeof(string));
                P_waged.Columns.Add("bankno", typeof(string));
                P_waged.Columns.Add("taxrate", typeof(decimal));
                P_waged.PrimaryKey = new DataColumn[] { P_waged.Columns["nobr"] };
                foreach (DataRow Row in DT_waged.Rows)
                {
                    DataRow rowP = P_waged.Rows.Find(Row["nobr"].ToString());
                    if (rowP == null)
                    {
                        DataRow P_aRow = P_waged.NewRow();
                        P_aRow["nobr"] = Row["nobr"].ToString();
                        P_aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        P_aRow["cash"] = bool.Parse(Row["cash"].ToString());
                        P_aRow["wk_days"] = decimal.Parse(Row["wk_days"].ToString());
                        P_aRow["note"] = Row["note"].ToString();
                        P_aRow["account_no"] = Row["account_no"].ToString();
                        P_aRow["bankno"] = Row["bankno"].ToString();
                        P_aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        P_waged.Rows.Add(P_aRow);
                    }
                }
            }

            if (report_type_item == "【清展】轉帳明細表")
            {
                for (int k = 0; k < DT_zz42tb.Rows.Count; k++)
                {

                    int _count = 1;
                    DataRow[] row = null;
                    if (order == "0")
                        row = DT_zz42tb.Select("", "comp,dept,nobr asc");
                    else if (order == "1")
                        row = DT_zz42tb.Select("", "nobr asc");
                    else if (order == "2")
                        row = DT_zz42tb.Select("", "nobr asc");
                    else if (order == "3")
                        row = DT_zz42tb.Select("", "dept,jobl,nobr asc");
                    else if (order == "4")
                        row = DT_zz42tb.Select("", "jobl,nobr asc");

                    for (int i = 0; i < DT_zz42tb.Columns.Count; i++)
                    {
                        if (row[k][i].ToString().Trim() != "")
                            _count++;
                    }
                    if (reporttype != "9" && reporttype != "18")
                    {
                        DT_waged.PrimaryKey = new DataColumn[] { DT_waged.Columns["nobr"], DT_waged.Columns["account_no"] };
                    }
                    //資料排序,O=公司+部門+員工編號,1=不分公司,2=員工編號,3=部門+職等,4=職等

                    string str_nobr = row[k]["nobr"].ToString();
                    object[] waged_Value = new object[2];
                    waged_Value[0] = row[k]["nobr"].ToString();
                    waged_Value[1] = row[k]["account_no"].ToString();
                    string str_depts = "";
                    string str_detpsname = "";
                    DataRow row40 = DT_wageds1.Rows.Find(str_nobr);
                    DataRow row41 = DT_wageds2.Rows.Find(str_nobr);
                    //DataRow row42 = DT_wagedsy.Rows.Find(str_nobr);
                    DataRow row_waged = (reporttype != "9" && reporttype != "18") ? DT_waged.Rows.Find(waged_Value) : P_waged.Rows.Find(waged_Value);
                    DataRow row44 = DT_wagedsz.Rows.Find(str_nobr);
                    DataRow row45 = DT_base.Rows.Find(str_nobr);
                    DataRow row47 = DT_explab.Rows.Find(str_nobr);
                    if ((row40 != null) && (row41 != null) && (row_waged != null) && (row44 != null) && (row45 != null))
                    {
                        str_depts = row45["depts"].ToString();
                        object[] _value = new object[2];
                        if (reporttype == "2" || reporttype == "4")
                        {
                            _value[0] = row45["depts"].ToString();
                            //DataRow row47 = DT_depts.Rows.Find(row45["depts"].ToString());
                            //if (row47 != null)
                            //    str_detpsname = row47["d_name"].ToString();
                            str_detpsname = row45["ds_name"].ToString();
                        }
                        else
                            _value[0] = row[k]["dept"].ToString();
                        _value[1] = str_nobr;
                        DataRow row46 = DT_zz42td.Rows.Find(_value);

                        DataRow aRow = DT_zz42td.NewRow();
                        aRow["mark"] = "";
                        aRow["checkma"] = row[k]["mark"].ToString().Trim();
                        aRow["nobr"] = row45["nobr"].ToString();
                        aRow["name_c"] = row45["name_c"].ToString();
                        aRow["name_e"] = row45["name_e"].ToString();
                        aRow["idno"] = row45["idno"].ToString();
                        if (reporttype == "2" || reporttype == "4")
                        {
                            aRow["dept"] = row45["depts"];
                            aRow["d_name"] = str_detpsname;
                        }
                        else
                        {
                            aRow["dept"] = row45["dept"];
                            aRow["d_name"] = row45["d_name"].ToString();
                        }
                        aRow["adate"] = DateTime.Parse(row_waged["adate"].ToString());
                        aRow["comp"] = row45["comp"].ToString();
                        aRow["compname"] = row45["compname"].ToString();
                        aRow["compid"] = row45["compid"].ToString();
                        aRow["indt"] = DateTime.Parse(row45["indt"].ToString());
                        if (!row45.IsNull("oudt")) aRow["oudt"] = DateTime.Parse(row45["oudt"].ToString());
                        aRow["di"] = row45["di"].ToString();
                        //aRow["d_name"] = row45["d_name"].ToString();
                        aRow["job"] = row45["job"].ToString();
                        aRow["job_name"] = row45["job_name"].ToString();
                        aRow["jobl"] = row45["jobl"].ToString();
                        aRow["jobl_name"] = row45["jobl_name"].ToString();
                        aRow["jobo_name"] = row45["jobo_name"].ToString();
                        aRow["taxrate"] = decimal.Parse(row_waged["taxrate"].ToString());
                        aRow["tax_date"] = (row45.IsNull("tax_date")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_date"].ToString());
                        aRow["tax_edate"] = (row45.IsNull("tax_edate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_edate"].ToString());
                        if (row45["retchoo"].ToString().Trim() == "0")
                            aRow["retchoo"] = "暫不選擇";
                        else if (row45["retchoo"].ToString().Trim() == "1")
                            aRow["retchoo"] = "舊制";
                        else if (row45["retchoo"].ToString().Trim() == "2")
                            aRow["retchoo"] = "新制";
                        aRow["retdate"] = (row45.IsNull("retdate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["retdate"].ToString());
                        aRow["retdate1"] = (row45.IsNull("retdate1")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["retdate1"].ToString());
                        aRow["indt"] = (row45.IsNull("indt")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["indt"].ToString());
                        aRow["count_ma"] = bool.Parse(row45["count_ma"].ToString());
                        aRow["stay183"] = "";
                        aRow["email"] = row45["email"].ToString();
                        aRow["matno"] = row45["matno"].ToString();
                        aRow["compaccount"] = row45["account"].ToString();
                        aRow["account_no"] = row_waged["account_no"].ToString();
                        aRow["bankno"] = row_waged["bankno"].ToString();
                        aRow["note"] = row_waged["note"].ToString();
                        aRow["aadate"] = DateTime.Parse(row45["adate"].ToString());
                        aRow["wk_days"] = decimal.Parse(row_waged["wk_days"].ToString());
                        aRow["wk_yrs"] = (row45.IsNull("wk_yrs1")) ? 0 : decimal.Round(decimal.Parse(row45["wk_yrs1"].ToString()), 2);
                        aRow["cash"] = bool.Parse(row_waged["cash"].ToString());
                        aRow["saladr"] = row_waged["saladr"].ToString();
                        if (row47 != null)
                        {
                            aRow["comp_lamt"] = int.Parse(row47["l_amt"].ToString());
                            aRow["comp_hamt"] = int.Parse(row47["h_amt"].ToString());
                            aRow["comp_ramt"] = int.Parse(row47["r_amt"].ToString());
                        }
                        else
                        {
                            aRow["comp_lamt"] = 0;
                            aRow["comp_hamt"] = 0;
                            aRow["comp_ramt"] = 0;
                        }
                        for (int j = 1; j < _count - 8; j++)
                        {
                            aRow["Fld" + j] = decimal.Parse(row[k]["Fld" + j].ToString());
                        }
                        DT_zz42td.Rows.Add(aRow);

                    }
                    if (reporttype == "1" || reporttype == "2")
                    {
                        string _dateb = ""; string _datee = "";
                        if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
                        {
                            _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                            _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                            _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                        }
                        DataRow[] adate_row = DT_zz42td.Select("aadate >='" + _dateb + "' and aadate <='" + _datee + "'");
                        foreach (DataRow Row1 in adate_row)
                        {
                            Row1["mark"] = "*";
                        }

                        DataRow[] out_row = DT_zz42td.Select(" oudt <='" + _datee + "'");
                        foreach (DataRow Row2 in out_row)
                        {
                            Row2["mark"] = "離";
                        }

                        //外勞是否滿183天
                        DataRow[] feg_row = DT_zz42td.Select("count_ma=1");
                        foreach (DataRow Row3 in feg_row)
                        {
                            int _adate = Convert.ToInt32(Convert.ToString(DateTime.Parse(Row3["tax_date"].ToString()).Year) + "0702");
                            int _adatee = Convert.ToInt32(Convert.ToString(DateTime.Parse(Row3["tax_edate"].ToString()).Year) + "0702");
                            if (DateTime.Parse(Row3["tax_date"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                            {
                                int _taxdate = Convert.ToInt32(DateTime.Parse(Row3["tax_date"].ToString()).ToString("yyyyMMdd"));
                                if (_taxdate > _adate)
                                    Row3["stay183"] = "N";
                                else
                                    Row3["stay183"] = "Y";
                            }
                            else if (DateTime.Parse(Row3["tax_edate"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                            {
                                int _taxedate = Convert.ToInt32(DateTime.Parse(Row3["tax_edate"].ToString()).ToString("yyyyMMdd"));
                                if (_taxedate < _adatee)
                                    Row3["stay183"] = "N";
                                else
                                    Row3["stay183"] = "Y";
                            }
                            else
                                Row3["stay183"] = "Y";
                        }
                    }
                }
            }

            else
            {

                int _count = 1;
                for (int i = 0; i < DT_zz42tb.Columns.Count; i++)
                {
                    if (DT_zz42tb.Rows[0][i].ToString().Trim() != "")
                        _count++;
                }
                if (reporttype != "9" && reporttype != "18")
                    DT_waged.PrimaryKey = new DataColumn[] { DT_waged.Columns["nobr"] };
                //資料排序,O=公司+部門+員工編號,1=不分公司,2=員工編號,3=部門+職等,4=職等
                DataRow[] row = null;
                if (order == "0")
                    row = DT_zz42tb.Select("", "comp,dept,nobr asc");
                else if (order == "1")
                    row = DT_zz42tb.Select("", "nobr asc");
                else if (order == "2")
                    row = DT_zz42tb.Select("", "nobr asc");
                else if (order == "3")
                    row = DT_zz42tb.Select("", "dept,jobl,nobr asc");
                else if (order == "4")
                    row = DT_zz42tb.Select("", "jobl,nobr asc");

                for (int i = 0; i < row.Length; i++)
                {
                    string str_nobr = row[i]["nobr"].ToString();
                    string str_depts = "";
                    string str_detpsname = "";
                    DataRow row40 = DT_wageds1.Rows.Find(str_nobr);
                    DataRow row41 = DT_wageds2.Rows.Find(str_nobr);
                    //DataRow row42 = DT_wagedsy.Rows.Find(str_nobr);
                    DataRow row_waged = (reporttype != "9" && reporttype != "18") ? DT_waged.Rows.Find(str_nobr) : P_waged.Rows.Find(str_nobr);
                    DataRow row44 = DT_wagedsz.Rows.Find(str_nobr);
                    DataRow row45 = DT_base.Rows.Find(str_nobr);
                    DataRow row47 = DT_explab.Rows.Find(str_nobr);
                    if ((row40 != null) && (row41 != null) && (row_waged != null) && (row44 != null) && (row45 != null))
                    {
                        str_depts = row45["depts"].ToString();
                        object[] _value = new object[2];
                        if (reporttype == "2" || reporttype == "4")
                        {
                            _value[0] = row45["depts"].ToString();
                            //DataRow row47 = DT_depts.Rows.Find(row45["depts"].ToString());
                            //if (row47 != null)
                            //    str_detpsname = row47["d_name"].ToString();
                            str_detpsname = row45["ds_name"].ToString();
                        }
                        else
                            _value[0] = row[i]["dept"].ToString();
                        _value[1] = str_nobr;
                        DataRow row46 = DT_zz42td.Rows.Find(_value);
                        if (row46 == null)
                        {
                            DataRow aRow = DT_zz42td.NewRow();
                            aRow["mark"] = "";
                            aRow["nobr"] = row45["nobr"].ToString();
                            aRow["name_c"] = row45["name_c"].ToString();
                            aRow["name_e"] = row45["name_e"].ToString();
                            aRow["idno"] = row45["idno"].ToString();
                            if (reporttype == "2" || reporttype == "4")
                            {
                                aRow["dept"] = row45["depts"];
                                aRow["d_name"] = str_detpsname;
                            }
                            else
                            {
                                aRow["dept"] = row45["dept"];
                                aRow["d_name"] = row45["d_name"].ToString();
                            }
                            aRow["adate"] = DateTime.Parse(row_waged["adate"].ToString());
                            aRow["comp"] = row45["comp"].ToString();
                            aRow["compname"] = row45["compname"].ToString();
                            aRow["compid"] = row45["compid"].ToString();
                            aRow["indt"] = DateTime.Parse(row45["indt"].ToString());
                            if (!row45.IsNull("oudt")) aRow["oudt"] = DateTime.Parse(row45["oudt"].ToString());
                            aRow["di"] = row45["di"].ToString();
                            //aRow["d_name"] = row45["d_name"].ToString();
                            aRow["job"] = row45["job"].ToString();
                            aRow["job_name"] = row45["job_name"].ToString();
                            aRow["jobl"] = row45["jobl"].ToString();
                            aRow["jobl_name"] = row45["jobl_name"].ToString();
                            aRow["jobo_name"] = row45["jobo_name"].ToString();
                            aRow["taxrate"] = decimal.Parse(row_waged["taxrate"].ToString());
                            aRow["tax_date"] = (row45.IsNull("tax_date")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_date"].ToString());
                            aRow["tax_edate"] = (row45.IsNull("tax_edate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_edate"].ToString());
                            if (row45["retchoo"].ToString().Trim() == "0")
                                aRow["retchoo"] = "暫不選擇";
                            else if (row45["retchoo"].ToString().Trim() == "1")
                                aRow["retchoo"] = "舊制";
                            else if (row45["retchoo"].ToString().Trim() == "2")
                                aRow["retchoo"] = "新制";
                            aRow["retdate"] = (row45.IsNull("retdate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["retdate"].ToString());
                            aRow["retdate1"] = (row45.IsNull("retdate1")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["retdate1"].ToString());
                            aRow["indt"] = (row45.IsNull("indt")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["indt"].ToString());
                            aRow["count_ma"] = bool.Parse(row45["count_ma"].ToString());
                            aRow["stay183"] = "";
                            aRow["email"] = row45["email"].ToString();
                            aRow["matno"] = row45["matno"].ToString();
                            aRow["compaccount"] = row45["account"].ToString();
                            aRow["account_no"] = row_waged["account_no"].ToString();
                            aRow["bankno"] = row_waged["bankno"].ToString();
                            aRow["note"] = row_waged["note"].ToString();
                            aRow["aadate"] = DateTime.Parse(row45["adate"].ToString());
                            aRow["wk_days"] = decimal.Parse(row_waged["wk_days"].ToString());
                            aRow["wk_yrs"] = (row45.IsNull("wk_yrs1")) ? 0 : decimal.Round(decimal.Parse(row45["wk_yrs1"].ToString()), 2);
                            aRow["cash"] = bool.Parse(row_waged["cash"].ToString());
                            aRow["saladr"] = row_waged["saladr"].ToString();
                            if (row47 != null)
                            {
                                aRow["comp_lamt"] = int.Parse(row47["l_amt"].ToString());
                                aRow["comp_hamt"] = int.Parse(row47["h_amt"].ToString());
                                aRow["comp_ramt"] = int.Parse(row47["r_amt"].ToString());
                            }
                            else
                            {
                                aRow["comp_lamt"] = 0;
                                aRow["comp_hamt"] = 0;
                                aRow["comp_ramt"] = 0;
                            }
                            for (int j = 1; j < _count - 6; j++)
                            {
                                aRow["Fld" + j] = decimal.Parse(row[i]["Fld" + j].ToString());
                            }
                            DT_zz42td.Rows.Add(aRow);
                        }
                    }
                }
                if (reporttype == "1" || reporttype == "2")
                {
                    string _dateb = ""; string _datee = "";
                    if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
                    {
                        _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                        _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                        _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                    }
                    DataRow[] adate_row = DT_zz42td.Select("aadate >='" + _dateb + "' and aadate <='" + _datee + "'");
                    foreach (DataRow Row1 in adate_row)
                    {
                        Row1["mark"] = "*";
                    }

                    DataRow[] out_row = DT_zz42td.Select(" oudt <='" + _datee + "'");
                    foreach (DataRow Row2 in out_row)
                    {
                        Row2["mark"] = "離";
                    }

                    //外勞是否滿183天
                    DataRow[] feg_row = DT_zz42td.Select("count_ma=1");
                    foreach (DataRow Row3 in feg_row)
                    {
                        int _adate = Convert.ToInt32(Convert.ToString(DateTime.Parse(Row3["tax_date"].ToString()).Year) + "0702");
                        int _adatee = Convert.ToInt32(Convert.ToString(DateTime.Parse(Row3["tax_edate"].ToString()).Year) + "0702");
                        if (DateTime.Parse(Row3["tax_date"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                        {
                            int _taxdate = Convert.ToInt32(DateTime.Parse(Row3["tax_date"].ToString()).ToString("yyyyMMdd"));
                            if (_taxdate > _adate)
                                Row3["stay183"] = "N";
                            else
                                Row3["stay183"] = "Y";
                        }
                        else if (DateTime.Parse(Row3["tax_edate"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                        {
                            int _taxedate = Convert.ToInt32(DateTime.Parse(Row3["tax_edate"].ToString()).ToString("yyyyMMdd"));
                            if (_taxedate < _adatee)
                                Row3["stay183"] = "N";
                            else
                                Row3["stay183"] = "Y";
                        }
                        else
                            Row3["stay183"] = "Y";
                    }
                }

            }
        }

        public static void Get_zz42td2A(DataTable DT_zz42td, DataTable DT_zz42tb, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz, DataTable DT_base, DataTable DT_depts, DataTable DT_inslab, string reporttype, string year, string month)
        {
            DataTable P_waged = new DataTable("P_waged");
            if (reporttype == "9")
            {
                P_waged.Columns.Add("nobr", typeof(string));
                P_waged.Columns.Add("adate", typeof(DateTime));
                P_waged.Columns.Add("cash", typeof(bool));
                P_waged.Columns.Add("wk_days", typeof(decimal));
                P_waged.Columns.Add("note", typeof(string));
                P_waged.Columns.Add("account_no", typeof(string));
                P_waged.Columns.Add("bankno", typeof(string));
                P_waged.Columns.Add("taxrate", typeof(decimal));
                P_waged.PrimaryKey = new DataColumn[] { P_waged.Columns["nobr"] };
                foreach (DataRow Row in DT_waged.Rows)
                {
                    DataRow rowP = P_waged.Rows.Find(Row["nobr"].ToString());
                    if (rowP == null)
                    {
                        DataRow P_aRow = P_waged.NewRow();
                        P_aRow["nobr"] = Row["nobr"].ToString();
                        P_aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        P_aRow["cash"] = bool.Parse(Row["cash"].ToString());
                        P_aRow["wk_days"] = decimal.Parse(Row["wk_days"].ToString());
                        P_aRow["note"] = Row["note"].ToString();
                        P_aRow["account_no"] = Row["account_no"].ToString();
                        P_aRow["bankno"] = Row["bankno"].ToString();
                        P_aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        P_waged.Rows.Add(P_aRow);
                    }
                }
            }
            int _count = 1;
            for (int i = 0; i < DT_zz42tb.Columns.Count; i++)
            {
                if (DT_zz42tb.Rows[0][i].ToString().Trim() != "")
                    _count++;
            }
            if (reporttype != "9" && reporttype != "18")
                DT_waged.PrimaryKey = new DataColumn[] { DT_waged.Columns["nobr"] };
            DataRow[] row = DT_zz42tb.Select("", "comp,dept,nobr asc");
            for (int i = 0; i < row.Length; i++)
            {
                string str_nobr = row[i]["nobr"].ToString();
                string str_depts = "";
                string str_detpsname = "";
                DataRow row40 = DT_wageds1.Rows.Find(str_nobr);
                DataRow row41 = DT_wageds2.Rows.Find(str_nobr);
                //DataRow row42 = DT_wagedsy.Rows.Find(str_nobr);
                DataRow row43 = (reporttype != "9" && reporttype != "18") ? DT_waged.Rows.Find(str_nobr) : P_waged.Rows.Find(str_nobr);
                DataRow row44 = DT_wagedsz.Rows.Find(str_nobr);
                DataRow row45 = DT_base.Rows.Find(str_nobr);
                DataRow row50 = DT_inslab.Rows.Find(str_nobr);
                if ((row40 != null) && (row41 != null) && (row43 != null) && (row44 != null) && (row45 != null))
                {
                    str_depts = row45["depts"].ToString();
                    object[] _value = new object[2];
                    if (reporttype == "2" || reporttype == "4")
                    {
                        _value[0] = row45["depts"].ToString();
                        DataRow row47 = DT_depts.Rows.Find(row45["depts"].ToString());
                        if (row47 != null)
                            str_detpsname = row47["d_name"].ToString();
                    }
                    else
                        _value[0] = row[i]["dept"].ToString();
                    _value[1] = str_nobr;
                    DataRow row46 = DT_zz42td.Rows.Find(_value);
                    if (row46 == null)
                    {
                        DataRow aRow = DT_zz42td.NewRow();
                        aRow["mark"] = "";
                        aRow["nobr"] = row45["nobr"].ToString();
                        aRow["name_c"] = row45["name_c"].ToString();
                        aRow["idno"] = row45["idno"].ToString();
                        if (reporttype == "2" || reporttype == "4")
                        {
                            aRow["dept"] = row45["depts"];
                            aRow["d_name"] = str_detpsname;
                        }
                        else
                        {
                            aRow["dept"] = row45["dept"];
                            aRow["d_name"] = row45["d_name"].ToString();
                        }
                        aRow["adate"] = DateTime.Parse(row45["adate"].ToString());
                        aRow["comp"] = row45["comp"].ToString();
                        aRow["compname"] = row45["compname"].ToString();
                        aRow["compid"] = row45["compid"].ToString();
                        aRow["taxcnt"] = decimal.Round(decimal.Parse(row45["taxcnt"].ToString()), 0);
                        aRow["indt"] = DateTime.Parse(row45["indt"].ToString());
                        if (!row45.IsNull("oudt")) aRow["oudt"] = DateTime.Parse(row45["oudt"].ToString());
                        aRow["di"] = row45["di"].ToString();
                        aRow["d_name"] = row45["d_name"].ToString();
                        aRow["job"] = row45["job"].ToString();
                        aRow["job_name"] = row45["job_name"].ToString();
                        aRow["jobl"] = row45["jobl"].ToString();
                        aRow["jobl_name"] = row45["jobl_name"].ToString();
                        aRow["taxrate"] = decimal.Parse(row43["taxrate"].ToString());
                        aRow["tax_date"] = (row45.IsNull("tax_date")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_date"].ToString());
                        aRow["tax_edate"] = (row45.IsNull("tax_edate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row45["tax_edate"].ToString());
                        aRow["count_ma"] = bool.Parse(row45["count_ma"].ToString());
                        aRow["stay183"] = "";
                        aRow["email"] = row45["email"].ToString();
                        aRow["matno"] = row45["matno"].ToString();
                        aRow["compaccount"] = row45["account"].ToString();
                        aRow["account_no"] = row43["account_no"].ToString();
                        aRow["bankno"] = row43["bankno"].ToString();
                        aRow["note"] = row43["note"].ToString();
                        aRow["aadate"] = DateTime.Parse(row43["adate"].ToString());
                        aRow["wk_days"] = decimal.Parse(row43["wk_days"].ToString());
                        aRow["cash"] = bool.Parse(row43["cash"].ToString());
                        aRow["saladr"] = row43["saladr"].ToString();
                        if (row50 != null) aRow["helcnt"] = int.Parse(row50["cnt"].ToString());
                        for (int j = 1; j < _count - 5; j++)
                        {
                            aRow["Fld" + j] = decimal.Parse(row[i]["Fld" + j].ToString());
                        }
                        DT_zz42td.Rows.Add(aRow);
                    }
                }
            }
            if (reporttype == "1" || reporttype == "2")
            {
                string _dateb = ""; string _datee = "";
                if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
                {
                    _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                    _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                }
                else
                {
                    _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
                    _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                }
                DataRow[] adate_row = DT_zz42td.Select("aadate >='" + _dateb + "' and aadate <='" + _datee + "'");
                foreach (DataRow Row1 in adate_row)
                {
                    Row1["mark"] = "*";
                }

                DataRow[] out_row = DT_zz42td.Select(" oudt <='" + _datee + "'");
                foreach (DataRow Row2 in out_row)
                {
                    Row2["mark"] = "離";
                }

                //外勞是否滿183天
                DataRow[] feg_row = DT_zz42td.Select("count_ma=1");
                foreach (DataRow Row3 in feg_row)
                {
                    int _adate = Convert.ToInt32(Convert.ToString(DateTime.Parse(Row3["tax_date"].ToString()).Year) + "0702");
                    if (DateTime.Parse(Row3["tax_date"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                    {
                        int _taxdate = Convert.ToInt32(DateTime.Parse(Row3["tax_date"].ToString()).ToString("yyyyMMdd"));
                        if (_taxdate > _adate)
                            Row3["stay183"] = "N";
                        else
                            Row3["stay183"] = "Y";
                    }
                    else if (DateTime.Parse(Row3["tax_edate"].ToString()).Year == DateTime.Parse(Row3["adate"].ToString()).Year)
                    {
                        int _taxedate = Convert.ToInt32(DateTime.Parse(Row3["tax_edate"].ToString()).ToString("yyyyMMdd"));
                        if (_taxedate < _adate)
                            Row3["stay183"] = "N";
                        else
                            Row3["stay183"] = "Y";
                    }
                    else
                        Row3["stay183"] = "Y";
                }
            }
        }

        public static void Get_zz42td3(DataTable DT_zz42td1, DataTable DT_zz42td, DataTable DT_zz42ta, bool sumdi)
        {
            DataRow[] orow;
            if (sumdi)
                orow = DT_zz42td.Select("", "dept,di asc");
            else
                orow = DT_zz42td.Select("", "dept asc");
            foreach (DataRow Row in orow)
            {
                object[] _value;
                if (sumdi)
                {
                    _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["di"].ToString();
                }
                else
                {
                    _value = new object[1];
                    _value[0] = Row["dept"].ToString();
                }
                DataRow row = DT_zz42td1.Rows.Find(_value);
                if (row != null)
                {
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    row["comp_hamt"] = int.Parse(row["comp_hamt"].ToString()) + int.Parse(Row["comp_hamt"].ToString());
                    row["comp_lamt"] = int.Parse(row["comp_lamt"].ToString()) + int.Parse(Row["comp_lamt"].ToString());
                    row["comp_ramt"] = int.Parse(row["comp_ramt"].ToString()) + int.Parse(Row["comp_ramt"].ToString());
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                        else
                            break;
                    }
                }
                else
                {
                    DataRow aRow = DT_zz42td1.NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["di"] = (sumdi) ? Row["di"].ToString() : "";
                    aRow["cnt"] = 1;
                    aRow["comp_hamt"] = int.Parse(Row["comp_hamt"].ToString());
                    aRow["comp_lamt"] = int.Parse(Row["comp_lamt"].ToString());
                    aRow["comp_ramt"] = int.Parse(Row["comp_ramt"].ToString());
                    if (sumdi)
                    {
                        if (Row["di"].ToString().Trim() == "D")
                            aRow["diname"] = "直接";
                        else if (Row["di"].ToString().Trim() == "I")
                            aRow["diname"] = "間接";
                        else if (Row["di"].ToString().Trim() == "S")
                            aRow["diname"] = "研發";
                    }
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                        else
                            break;
                    }
                    DT_zz42td1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz42td4(DataTable DT_zz42tdcu, DataTable DT_zz42tdup, DataTable DT_waged1, DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_wagedup1, DataTable DT_wagedup2, DataTable DT_wagedupz, string yymm_b, string yymm_e)
        {
            DataTable DT_up = new DataTable();
            DT_up.Columns.Add("nobr", typeof(string));
            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {
                if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                    DT_up.Columns.Add("Fld" + (i + 1), typeof(int));
                else
                    break;
            }
            DT_up.PrimaryKey = new DataColumn[] { DT_up.Columns["nobr"] };
            foreach (DataRow Row in DT_waged1.Rows)
            {
                if (Row["flag"].ToString().Trim() == "-")
                    Row["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                DataRow row = DT_wagedup1.Rows.Find(Row["nobr"].ToString());
                DataRow row1 = DT_wagedup2.Rows.Find(Row["nobr"].ToString());
                DataRow row2 = DT_wagedupz.Rows.Find(Row["nobr"].ToString());
                if (row != null && row1 != null && row2 != null)
                {
                    DataRow row3 = DT_up.Rows.Find(Row["nobr"].ToString());
                    if (row3 != null)
                    {
                        for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                        {
                            if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            {
                                if (Row["sal_name"].ToString().Trim() == DT_zz42ta.Rows[0][i].ToString().Trim())
                                    row3["Fld" + (i + 1)] = int.Parse(row3["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        DataRow aRow = DT_up.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                        {
                            if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            {
                                aRow["Fld" + (i + 1)] = 0;
                                if (Row["sal_name"].ToString().Trim() == DT_zz42ta.Rows[0][i].ToString().Trim())
                                    aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                                if (DT_zz42ta.Rows[0][i].ToString().Trim() == "應稅薪資")
                                    aRow["Fld" + (i + 1)] = int.Parse(row["tot1"].ToString());
                                if (DT_zz42ta.Rows[0][i].ToString().Trim() == "應發薪資")
                                    aRow["Fld" + (i + 1)] = int.Parse(row1["tot2"].ToString());
                                if (DT_zz42ta.Rows[0][i].ToString().Trim() == "實發金額")
                                    aRow["Fld" + (i + 1)] = int.Parse(row2["totz"].ToString());
                            }
                            else
                                break;
                        }
                        DT_up.Rows.Add(aRow);
                    }
                }
            }

            foreach (DataRow Row3 in DT_up.Rows)
            {
                DataRow row = DT_zz42tdup.Rows.Find(yymm_b);
                if (row != null)
                {
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row3["Fld" + (i + 1)].ToString());
                        else
                            break;
                    }
                }
                else
                {
                    DataRow aRow = DT_zz42tdup.NewRow();
                    aRow["yymm"] = yymm_b;
                    aRow["cnt"] = DT_up.Rows.Count;
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            aRow["Fld" + (i + 1)] = int.Parse(Row3["Fld" + (i + 1)].ToString());
                        else
                            break;
                    }
                    DT_zz42tdup.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row4 in DT_zz42td.Rows)
            {
                DataRow row = DT_zz42tdcu.Rows.Find(yymm_e);
                if (row != null)
                {
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row4["Fld" + (i + 1)].ToString());
                        else
                            break;
                    }
                }
                else
                {
                    DataRow aRow = DT_zz42tdcu.NewRow();
                    aRow["yymm"] = yymm_e;
                    aRow["cnt"] = DT_zz42td.Rows.Count;
                    aRow["cnt_up"] = DT_up.Rows.Count;
                    aRow["cnt_diff"] = DT_zz42td.Rows.Count - DT_up.Rows.Count;
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        //if (DT_zz42ta.Rows[0][i].ToString().Trim() == "退休金自提" || DT_zz42ta.Rows[0][i].ToString().Trim() == "退休金自提追扣")
                        //    aRow["Fld" + (i + 1)] = (DT_zz42tdup.Rows.Count > 0) ? int.Parse(DT_zz42tdup.Rows[0]["Fld" + (i + 1)].ToString()) + int.Parse(Row4["Fld" + (i + 1)].ToString()) : int.Parse(Row4["Fld" + (i + 1)].ToString());
                        //else if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                        //    aRow["Fld" + (i + 1)] = (DT_zz42tdup.Rows.Count > 0) ? int.Parse(Row4["Fld" + (i + 1)].ToString()) - int.Parse(DT_zz42tdup.Rows[0]["Fld" + (i + 1)].ToString()) : int.Parse(Row4["Fld" + (i + 1)].ToString());
                        //20141124程式修改                      
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                        {
                            aRow["Fld" + (i + 1)] = (DT_zz42tdup.Rows.Count > 0) ? int.Parse(Row4["Fld" + (i + 1)].ToString()) - int.Parse(DT_zz42tdup.Rows[0]["Fld" + (i + 1)].ToString()) : int.Parse(Row4["Fld" + (i + 1)].ToString());
                        }
                        else
                            break;
                    }
                    DT_zz42tdcu.Rows.Add(aRow);
                }
            }
            DT_up = null;

        }

        public static void Get_zz4215(DataTable DT_zz4215, DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_bank, string date_t, string report_type_item, string note1)
        {
            if (report_type_item == "【清展】轉帳明細表")
            {
                DataRow[] row = DT_zz42td.Select("cash=0 and account_no <> '' and adate='" + date_t + "'", "nobr asc");
                for (int i = 0; i < row.Length; i++)
                {
                    string str_t = "";
                    string str_ma = "";
                    for (int j = 0; j < DT_zz42ta.Columns.Count; j++)
                    {

                        if (DT_zz42ta.Rows[0]["Fld" + (j + 1)].ToString() == "實發金額")
                        {
                            str_t = "Fld" + (j + 1);
                        }

                        if (DT_zz42ta.Rows[0]["Fld" + (j + 1)].ToString() == "儲蓄金")
                        {
                            str_ma = "Fld" + (j + 1);
                        }

                    }
                    //if (decimal.Parse(row[i][str_t].ToString()) > 0)
                    //{
                    DataRow aRow = DT_zz4215.NewRow();
                    aRow["type"] = "薪資轉存";
                    aRow["comp"] = "";
                    aRow["nobr"] = row[i]["nobr"].ToString();
                    aRow["name_c"] = row[i]["name_c"].ToString();
                    aRow["bankno"] = row[i]["bankno"].ToString();
                    aRow["ADATE"] = row[i]["ADATE"].ToString();
                    aRow["NOTE"] = note1;
                    aRow["EMAIL"] = row[i]["EMAIL"].ToString();
                    aRow["FAX"] = "";
                    DataRow row1 = DT_bank.Rows.Find(row[i]["bankno"].ToString());
                    //string bankname = (row[i]["bankno"].ToString().Trim() == "") ? "" : row[i]["bankno"].ToString().Trim().Substring(0, 3);
                    //if (bankname == "822")
                    //    aRow["bankname"] = "中國信託";
                    //else if (bankname == "008")
                    //    aRow["bankname"] = "華南";                    
                    //else
                    //    aRow["bankname"] = "";
                    aRow["bankname"] = (row1 != null) ? row1["bankname"].ToString() : "";
                    //判斷是否為外籍賬號
                    if (row[i]["checkma"].ToString().Trim() == "_no")
                    {
                        aRow["tt"] = decimal.Parse(row[i][str_t].ToString());
                    }
                    else if (row[i]["checkma"].ToString().Trim() == "_ma")
                    {
                        aRow["tt"] = decimal.Parse(row[i][str_ma].ToString());
                    }
                    aRow["account_no"] = row[i]["account_no"].ToString();
                    aRow["idno"] = row[i]["idno"].ToString();
                    aRow["compid"] = row[i]["compid"].ToString();
                    if (bool.Parse(row[i]["count_ma"].ToString()))
                        aRow["idno"] = row[i]["matno"].ToString();
                    DT_zz4215.Rows.Add(aRow);
                    //}
                }
            }
            else
            {

                string str_t = "";
                for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                {

                    if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                    {
                        str_t = "Fld" + (i + 1);
                        break;
                    }
                }

                DataRow[] row = DT_zz42td.Select("cash=0 and account_no <> '' and adate='" + date_t + "'", "nobr asc");
                for (int i = 0; i < row.Length; i++)
                {
                    if (decimal.Parse(row[i][str_t].ToString()) > 0)
                    {
                        DataRow aRow = DT_zz4215.NewRow();
                        aRow["type"] = "薪資轉存";
                        aRow["comp"] = "";
                        aRow["nobr"] = row[i]["nobr"].ToString();
                        aRow["name_c"] = row[i]["name_c"].ToString();
                        aRow["bankno"] = row[i]["bankno"].ToString();
                        DataRow row1 = DT_bank.Rows.Find(row[i]["bankno"].ToString());
                        //string bankname = (row[i]["bankno"].ToString().Trim() == "") ? "" : row[i]["bankno"].ToString().Trim().Substring(0, 3);
                        //if (bankname == "822")
                        //    aRow["bankname"] = "中國信託";
                        //else if (bankname == "008")
                        //    aRow["bankname"] = "華南";                    
                        //else
                        //    aRow["bankname"] = "";
                        aRow["bankname"] = (row1 != null) ? row1["bankname"].ToString() : "";
                        aRow["tt"] = decimal.Parse(row[i][str_t].ToString());
                        aRow["account_no"] = row[i]["account_no"].ToString();
                        aRow["idno"] = row[i]["idno"].ToString();
                        aRow["compid"] = row[i]["compid"].ToString();
                        if (bool.Parse(row[i]["count_ma"].ToString()))
                            aRow["idno"] = row[i]["matno"].ToString();
                        DT_zz4215.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void Get_zz4215t(DataTable DT_zz4215t, DataTable DT_zz42ta, DataTable DT_zz42td)
        {
            DT_zz4215t.PrimaryKey = new DataColumn[] { DT_zz4215t.Columns["code"] };
            foreach (DataRow Row in DT_zz42td.Rows)
            {
                string str_code = ""; string str_codename = "";
                if (bool.Parse(Row["count_ma"].ToString()))
                {
                    str_code = "A";
                    str_codename = "外籍員工";
                }
                else
                {
                    str_code = "B";
                    str_codename = "一般員工";
                }
                //if (Row["job"].ToString().Trim().Substring(2, 1) == "A")
                //{
                //    str_code = "C";
                //    str_codename = "主管員工";
                //}
                //if (!bool.Parse(Row["count_ma"].ToString()) && Row["job"].ToString().Trim().Substring(2, 1) != "A")
                //{
                //    str_code = "B";
                //    str_codename = "一般員工";
                //}
                DataRow row = DT_zz4215t.Rows.Find(str_code);
                if (row != null)
                {
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                }
                else
                {
                    DataRow aRow = DT_zz4215t.NewRow();
                    aRow["code"] = str_code;
                    aRow["code_name"] = str_codename;
                    aRow["cnt"] = 1;
                    for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
                    {
                        if (DT_zz42ta.Rows[0][i].ToString().Trim() != "")
                            aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    DT_zz4215t.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz421e(DataTable DT_zz421e, DataTable DT_waged, DataTable DT_base, DataTable DT_sys3)
        {
            string notaxsalcode = ""; string totaxsalcode = "";
            if (DT_sys3.Rows.Count > 0)
            {
                notaxsalcode = DT_sys3.Rows[0]["notaxsalcode"].ToString().Trim();
                totaxsalcode = DT_sys3.Rows[0]["totaxsalcode"].ToString().Trim();
            }
            DataTable rq_zz421e = new DataTable();
            rq_zz421e.Columns.Add("nobr", typeof(string));
            rq_zz421e.Columns.Add("job", typeof(string));
            rq_zz421e.Columns.Add("job_name", typeof(string));
            rq_zz421e.Columns.Add("amt", typeof(int));
            rq_zz421e.PrimaryKey = new DataColumn[] { rq_zz421e.Columns["nobr"] };

            DataTable rq_wageot = new DataTable();
            rq_wageot.Columns.Add("job", typeof(string));
            rq_wageot.Columns.Add("amt", typeof(int));
            rq_wageot.PrimaryKey = new DataColumn[] { rq_wageot.Columns["job"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                int str_amt = int.Parse(Row["amt"].ToString());
                if (Row["flag"].ToString().Trim() == "-")
                    str_amt = str_amt * (-1);
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                DataRow row1 = rq_zz421e.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (Row["type"].ToString().Trim() == "1" || Row["type"].ToString().Trim() == "2")
                    {
                        if (row1 != null)
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + str_amt;
                        else
                        {
                            DataRow aRow = rq_zz421e.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["job"] = row["job"].ToString();
                            aRow["job_name"] = row["job_name"].ToString();
                            aRow["amt"] = str_amt;
                            rq_zz421e.Rows.Add(aRow);
                        }
                    }
                    //if (!bool.Parse(row["count_ma"].ToString()) && (Row["sal_code"].ToString().Trim() == notaxsalcode || Row["sal_code"].ToString().Trim() == totaxsalcode))
                    if ((Row["sal_code"].ToString().Trim() == notaxsalcode || Row["sal_code"].ToString().Trim() == totaxsalcode))
                    {
                        DataRow row2 = rq_wageot.Rows.Find(row["job"].ToString());
                        if (row2 != null)
                            row2["amt"] = int.Parse(row2["amt"].ToString()) + str_amt;
                        else
                        {
                            DataRow aRow1 = rq_wageot.NewRow();
                            aRow1["job"] = row["job"].ToString();
                            aRow1["amt"] = str_amt;
                            rq_wageot.Rows.Add(aRow1);
                        }
                    }
                }
            }

            DataRow[] SRow = rq_zz421e.Select("", "job asc");
            foreach (DataRow Row1 in SRow)
            {
                DataRow row = DT_zz421e.Rows.Find(Row1["job"].ToString());
                if (row != null)
                {
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row1["amt"].ToString());
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                }
                else
                {
                    DataRow row1 = rq_wageot.Rows.Find(Row1["job"].ToString());
                    DataRow aRow = DT_zz421e.NewRow();
                    aRow["job"] = Row1["job"].ToString();
                    aRow["job_name"] = Row1["job_name"].ToString();
                    aRow["amt"] = int.Parse(Row1["amt"].ToString());
                    aRow["cnt"] = 1;
                    aRow["otamt"] = (row1 != null) ? int.Parse(row1["amt"].ToString()) : 0;
                    DT_zz421e.Rows.Add(aRow);
                }
            }
            rq_wageot = null; rq_zz421e = null;
        }

        public static void Get_zz4216(DataTable DT_zz4216, DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_waged, DataTable DT_base, string date_t)
        {
            string str_t = "";
            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {

                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                {
                    str_t = "Fld" + (i + 1);
                    break;
                }
            }

            DataRow[] row1 = DT_waged.Select("type='4'");
            foreach (DataRow Row in row1)
            {
                DataRow row2 = DT_base.Rows.Find(Row["nobr"].ToString());
                if (row2 != null)
                {
                    DataRow aRow = DT_zz4216.NewRow();
                    aRow["dept"] = row2["dept"].ToString();
                    aRow["d_name"] = row2["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["tt"] = int.Parse(Row["amt"].ToString());
                    DT_zz4216.Rows.Add(aRow);
                }
            }

            DataRow[] row3 = DT_zz42td.Select("adate='" + date_t + "'", "dept,nobr asc");
            foreach (DataRow Row1 in row3)
            {
                if (bool.Parse(Row1["cash"].ToString()) || Row1["account_no"].ToString().Trim() == "")
                {
                    DataRow aRow1 = DT_zz4216.NewRow();
                    aRow1["dept"] = Row1["dept"].ToString();
                    aRow1["d_name"] = Row1["d_name"].ToString();
                    aRow1["nobr"] = Row1["nobr"].ToString();
                    aRow1["name_c"] = Row1["name_c"].ToString();
                    aRow1["tt"] = int.Parse(Row1[str_t].ToString());
                    DT_zz4216.Rows.Add(aRow1);
                }
            }
        }

        public static void Get_zz4219(DataTable DT_zz4219, DataTable DT_waged, DataTable DT_base, DataTable DT_abs, DataTable DT_abs3, DataTable Dt_att, DataTable Dt_att1, DataTable DT_ret, DataTable DT_reta, DataTable DT_ret1, DataTable DT_rett, DataTable DT_ot, DataTable DT_PaySlip, decimal nretirerate, bool salary_pa1, string retsalcode, bool prn_noemail)
        {
            DataTable DT_wageds = new DataTable();
            DT_wageds.Columns.Add("nobr", typeof(string));
            DT_wageds.Columns.Add("tot2", typeof(int));
            DT_wageds.PrimaryKey = new DataColumn[] { DT_wageds.Columns["nobr"] };

            DataTable DT_wageds2 = new DataTable();
            DT_wageds2.Columns.Add("nobr", typeof(string));
            DT_wageds2.Columns.Add("tot2", typeof(int));
            DT_wageds2.PrimaryKey = new DataColumn[] { DT_wageds2.Columns["nobr"] };

            DataTable DT_wagedz = new DataTable();
            DT_wagedz.Columns.Add("nobr", typeof(string));
            DT_wagedz.Columns.Add("totz", typeof(int));
            DT_wagedz.PrimaryKey = new DataColumn[] { DT_wagedz.Columns["nobr"] };
            DataRow[] row1 = DT_waged.Select("salattr <='F'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds.Rows.Add(aRow);
                }
            }

            DataRow[] row1a = DT_waged.Select("salattr <='L' and sal_code<> '" + retsalcode + "' ", "nobr asc");
            for (int i = 0; i < row1a.Length; i++)
            {
                DataRow row3a = DT_wageds2.Rows.Find(row1a[i]["nobr"].ToString());
                if (row3a != null)
                {
                    row3a["tot2"] = decimal.Parse(row1a[i]["amt"].ToString()) + decimal.Parse(row3a["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = row1a[i]["nobr"].ToString();
                    aRow["tot2"] = decimal.Parse(row1a[i]["amt"].ToString());
                    DT_wageds2.Rows.Add(aRow);
                }
            }

            DataRow[] SRow = DT_waged.Select("", "dept,nobr asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row0 = DT_base.Rows.Find(Row["nobr"].ToString());
                DataRow row = DT_zz4219.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    if (prn_noemail)
                    {
                        if (row0 != null)
                        {
                            if (row0["email"].ToString().Trim() == "")
                            {
                                DataRow aRow = DT_zz4219.NewRow();
                                aRow["dept"] = row0["dept"].ToString();
                                aRow["d_name"] = row0["d_name"].ToString();
                                aRow["name_c"] = row0["name_c"].ToString();
                                aRow["name_e"] = row0["name_e"].ToString();
                                aRow["idno"] = row0["idno"].ToString();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["account_no"] = Row["account_no"].ToString();
                                aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                                aRow["job_name"] = row0["job_name"].ToString();
                                aRow["jobl_name"] = row0["jobl_name"].ToString();
                                aRow["jobo_name"] = row0["jobo_name"].ToString();
                                aRow["note"] = Row["note"].ToString();
                                aRow["wk_days"] = decimal.Parse(Row["wk_days"].ToString());
                                aRow["attdate_b"] = DateTime.Parse(Row["attdate_b"].ToString());
                                aRow["attdate_e"] = DateTime.Parse(Row["attdate_e"].ToString());
                                aRow["company"] = row0["compname"].ToString();
                                aRow["country"] = row0["country"].ToString();
                                aRow["PaySlipComp"] = Row["PaySlipComp"].ToString();
                                DT_zz4219.Rows.Add(aRow);
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow1 = DT_zz4219.NewRow();
                        if (row0 != null)
                        {
                            aRow1["dept"] = row0["dept"].ToString();
                            aRow1["d_name"] = row0["d_name"].ToString();
                            aRow1["name_c"] = row0["name_c"].ToString();
                            aRow1["name_e"] = row0["name_e"].ToString();
                            aRow1["idno"] = row0["idno"].ToString();
                            aRow1["email"] = row0["email"].ToString();
                            //aRow1["password"] = JBModule.Data.CDecryp.Text(row0["password"].ToString());   
                            aRow1["password"] = row0["password"].ToString();
                        }
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["job_name"] = row0["job_name"].ToString();
                        aRow1["jobl_name"] = row0["jobl_name"].ToString();
                        aRow1["jobo_name"] = row0["jobo_name"].ToString();
                        aRow1["account_no"] = Row["account_no"].ToString();
                        aRow1["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow1["note"] = Row["note"].ToString();
                        aRow1["wk_days"] = decimal.Parse(Row["wk_days"].ToString());
                        aRow1["attdate_b"] = DateTime.Parse(Row["attdate_b"].ToString());
                        aRow1["attdate_e"] = DateTime.Parse(Row["attdate_e"].ToString());
                        aRow1["company"] = row0["compname"].ToString();
                        aRow1["country"] = row0["country"].ToString();
                        aRow1["PaySlipComp"] = Row["PaySlipComp"].ToString();
                        DT_zz4219.Rows.Add(aRow1);
                    }
                }

                //if (Row["sal_code"].ToString().Trim() != "R01")
                //{

                //}

                DataRow row2 = DT_wagedz.Rows.Find(Row["nobr"].ToString());
                if (row2 != null)
                    row2["totz"] = int.Parse(row2["totz"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow1 = DT_wagedz.NewRow();
                    aRow1["nobr"] = Row["nobr"].ToString();
                    aRow1["totz"] = int.Parse(Row["amt"].ToString());
                    DT_wagedz.Rows.Add(aRow1);
                }
            }

            DataTable rq_merge = new DataTable();
            rq_merge.Columns.Add("nobr", typeof(string));
            rq_merge.Columns.Add("sal_code", typeof(string));
            rq_merge.Columns.Add("sal_name", typeof(string));
            rq_merge.Columns.Add("sal_ename", typeof(string));
            rq_merge.Columns.Add("flag", typeof(string));
            rq_merge.Columns.Add("amt", typeof(decimal));
            rq_merge.PrimaryKey = new DataColumn[] { rq_merge.Columns["nobr"], rq_merge.Columns["sal_name"] };
            DataRow[] Mrow = DT_waged.Select("", "nobr,sal_code asc");
            foreach (DataRow Row in Mrow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["sal_name"].ToString();
                DataRow row = rq_merge.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_merge.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    aRow["sal_ename"] = Row["sal_ename"].ToString();
                    aRow["flag"] = Row["flag"].ToString();
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    rq_merge.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row1 in DT_zz4219.Rows)
            {
                //DataRow[] row = DT_waged.Select("nobr='" + Row1["nobr"].ToString() + "' and flag=''", "nobr,sal_code asc");
                //for (int i = 0; i < row.Length; i++)
                //{
                //    if (salary_pa1)
                //        Row1["Fldbt" + (i + 1)] = row[i]["sal_ename"].ToString();
                //    else
                //        Row1["Fldbt" + (i + 1)] = row[i]["sal_name"].ToString();
                //    Row1["Fldb" + (i + 1)] = row[i]["amt"].ToString();
                //}

                //DataRow[] row3 = DT_waged.Select("nobr='" + Row1["nobr"].ToString() + "' and flag='-'", "nobr,sal_code asc");
                //for (int i = 0; i < row3.Length; i++)
                //{
                //    if (salary_pa1)
                //        Row1["Fldct" + (i + 1)] = row3[i]["sal_ename"].ToString();
                //    else
                //        Row1["Fldct" + (i + 1)] = row3[i]["sal_name"].ToString();
                //    Row1["Fldc" + (i + 1)] = int.Parse(row3[i]["amt"].ToString()) * (-1);
                //}
                DataRow[] row = rq_merge.Select("nobr='" + Row1["nobr"].ToString() + "' and flag=''", "sal_code asc");
                for (int i = 0; i < row.Length; i++)
                {
                    if (salary_pa1)
                        Row1["Fldbt" + (i + 1)] = row[i]["sal_ename"].ToString();//+ " " + row[i]["sal_ename"].ToString()
                    else
                        Row1["Fldbt" + (i + 1)] = row[i]["sal_name"].ToString();
                    Row1["Fldb" + (i + 1)] = row[i]["amt"].ToString();
                }

                DataRow[] row3 = rq_merge.Select("nobr='" + Row1["nobr"].ToString() + "' and flag='-'", "sal_code asc");
                for (int i = 0; i < row3.Length; i++)
                {
                    if (salary_pa1)
                        Row1["Fldct" + (i + 1)] = row3[i]["sal_ename"].ToString(); //+ " " + row3[i]["sal_ename"].ToString()
                    else
                        Row1["Fldct" + (i + 1)] = row3[i]["sal_name"].ToString();
                    Row1["Fldc" + (i + 1)] = int.Parse(row3[i]["amt"].ToString()) * (-1);
                }

                if (salary_pa1)
                {
                    DataRow[] row19 = DT_PaySlip.Select("language='" + Row1["country"].ToString() + "' and disp=1");
                    if (row19.Length < 1)
                        row19 = DT_PaySlip.Select("language='EN' and disp=1");
                    for (int i = 0; i < row19.Length; i++)
                    {
                        Row1[row19[i]["code"].ToString()] = row19[i]["description"].ToString();
                    }
                }

                DataRow[] row4 = DT_abs.Select("nobr='" + Row1["nobr"].ToString() + "'", "h_code asc");
                int absrow = (row4.Length > 8) ? 8 : row4.Length;
                for (int i = 0; i < absrow; i++)
                {
                    Row1["Fldat" + (i + 1)] = row4[i]["h_name"].ToString();
                    Row1["Flda" + (i + 1)] = decimal.Parse(row4[i]["tol_hours"].ToString());
                    //if (salary_pa1)
                    //{
                    //    if (row4[i]["unit"].ToString().Trim() == "小時")
                    //        Row1["Fldau" + (i + 1)] = "hours";
                    //    else if (row4[i]["unit"].ToString().Trim() == "天")
                    //        Row1["Fldau" + (i + 1)] = "days";
                    //    else if (row4[i]["unit"].ToString().Trim() == "次")
                    //        Row1["Fldau" + (i + 1)] = "times";
                    //}
                    //else
                    //    Row1["Fldau" + (i + 1)] = row4[i]["unit"].ToString();
                    Row1["Fldau" + (i + 1)] = row4[i]["unit"].ToString();
                }

                int _abscn = row4.Length + 1;
                //DataRow row5 = Dt_att.Rows.Find(Row1["nobr"].ToString());
                //if (row5!=null)
                //{                    
                //    Row1["Flda" + _abscn] = int.Parse(row5["tot_hrs"].ToString());
                //    if (salary_pa1)
                //    {
                //        Row1["Fldat" + _abscn] = "Arrive Late";
                //        Row1["Fldau" + _abscn] = "times";
                //    }
                //    else
                //    {
                //        Row1["Fldat" + _abscn] = "遲到";
                //        Row1["Fldau" + _abscn] = "次";
                //    }
                //    _abscn++;
                //}

                object[] _valuep1 = new object[2];
                _valuep1[0] = "PaySlipLate";
                _valuep1[1] = Row1["country"].ToString();
                DataRow rowp1 = DT_PaySlip.Rows.Find(_valuep1);
                DataRow row5 = Dt_att.Rows.Find(Row1["nobr"].ToString());
                if (row5 != null && _abscn < 8)
                {
                    Row1["Flda" + _abscn] = int.Parse(row5["tot_hrs"].ToString());
                    if (salary_pa1)
                    {
                        object[] _valuep = new object[2];
                        _valuep[0] = "PaySlipLate";
                        _valuep[1] = Row1["country"].ToString();
                        DataRow rowp = DT_PaySlip.Rows.Find(_valuep);

                        Row1["Fldat" + _abscn] = (rowp != null) ? rowp["description"].ToString() : "Arrive Late";
                        Row1["Fldau" + _abscn] = (rowp1 != null) ? rowp1["description"].ToString() : "times";
                    }
                    else
                    {
                        Row1["Fldat" + _abscn] = "遲到";
                        Row1["Fldau" + _abscn] = "次";
                    }
                    _abscn++;
                }

                DataRow row6 = Dt_att1.Rows.Find(Row1["nobr"].ToString());
                if (row6 != null && _abscn < 8)
                {
                    Row1["Flda" + _abscn] = int.Parse(row6["tot_hrs"].ToString());
                    if (salary_pa1)
                    {
                        object[] _valuep = new object[2];
                        _valuep[0] = "PaySlipForget";
                        _valuep[1] = Row1["country"].ToString();
                        DataRow rowp = DT_PaySlip.Rows.Find(_valuep);
                        Row1["Fldau" + _abscn] = (rowp1 != null) ? rowp1["description"].ToString() : "times";
                        Row1["Fldat" + _abscn] = (rowp != null) ? rowp["description"].ToString() : "No Attendance Record";
                    }
                    else
                    {
                        Row1["Fldat" + _abscn] = "忘刷";
                        Row1["Fldau" + _abscn] = "次";
                    }
                }

                //DataRow row7 = DT_salbasd1.Rows.Find(Row1["nobr"].ToString());
                //if (row7 != null)
                //    Row1["Fldd1"] = int.Parse(row7["amt"].ToString());
                //DataRow row8 = DT_sala.Rows.Find(Row1["nobr"].ToString());
                //if (row8 != null)
                //    Row1["Fldd2"] = int.Parse(row8["amt"].ToString());

                string _country = Row1["country"].ToString();
                DataRow row9 = DT_wagedz.Rows.Find(Row1["nobr"].ToString());
                if (salary_pa1)
                {
                    object[] _valuep = new object[2];
                    _valuep[0] = "PayTotal";
                    _valuep[1] = Row1["country"].ToString();
                    DataRow rowp = DT_PaySlip.Rows.Find(_valuep);
                    Row1["Flddt3"] = (rowp != null) ? "實發金額" + rowp["description"].ToString() : "實發金額"; //"Total Net Payable"         
                }
                else
                    Row1["Flddt3"] = "實發金額";
                if (row9 != null)
                {
                    Row1["Fldd3"] = int.Parse(row9["totz"].ToString());
                }

                DataRow row10 = DT_wageds.Rows.Find(Row1["nobr"].ToString());
                if (row10 != null)
                {
                    Row1["Flddt4"] = "應稅薪資";
                    Row1["Fldd4"] = int.Parse(row10["tot2"].ToString());
                }

                DataRow row10a = DT_wageds2.Rows.Find(Row1["nobr"].ToString());
                if (row10a != null)
                {
                    Row1["Flddt0"] = "應發薪資";
                    Row1["Fldd0"] = int.Parse(row10a["tot2"].ToString());
                }

                DataRow row11 = DT_rett.Rows.Find(Row1["nobr"].ToString());
                if (row11 != null)
                {
                    if (row11["retchoo"].ToString().Trim() == "0")
                        Row1["Flddt5"] = "暫不選擇";
                    else if (row11["retchoo"].ToString().Trim() == "1")
                        Row1["Flddt5"] = "勞退舊制";
                    else if (row11["retchoo"].ToString().Trim() == "2")
                    {
                        Row1["Flddt5"] = "勞退新制";
                        Row1["Flddt7"] = decimal.Round(nretirerate * 100, 1);
                    }
                    if (decimal.Parse(row11["retrate"].ToString()) != 0) Row1["Flddt8"] = decimal.Round(decimal.Parse(row11["retrate"].ToString()), 1);
                }
                DataRow row12 = DT_ret.Rows.Find(Row1["nobr"].ToString());
                if (row12 != null)
                    Row1["Fldd7"] = int.Parse(row12["comp"].ToString());
                DataRow row13 = DT_reta.Rows.Find(Row1["nobr"].ToString());
                if (row13 != null)
                {
                    Row1["r_amt"] = int.Parse(row13["r_amt"].ToString());
                    Row1["h_amt"] = int.Parse(row13["h_amt"].ToString());
                    Row1["l_amt"] = int.Parse(row13["l_amt"].ToString());
                    //if (!row13.IsNull("fa_cnt")) Row1["fa_cnt"] = int.Parse(row13["fa_cnt"].ToString());
                }
                DataRow row14 = DT_ret1.Rows.Find(Row1["nobr"].ToString());
                if (row14 != null)
                    Row1["Fldd8"] = int.Parse(row14["amt"].ToString()) * (-1);
                if (!Row1.IsNull("Fldd7"))
                    Row1["Fldd9"] = int.Parse(Row1["Fldd7"].ToString());
                if (!Row1.IsNull("Fldd8"))
                    Row1["Fldd9"] = int.Parse(Row1["Fldd8"].ToString());
                if (!Row1.IsNull("Fldd7") && !Row1.IsNull("Fldd8"))
                    Row1["Fldd9"] = int.Parse(Row1["Fldd7"].ToString()) + int.Parse(Row1["Fldd8"].ToString());

                //DataRow[] row15 = DT_ot.Select("nobr='" + Row1["nobr"].ToString() + "' and othrs>0", "rate asc");
                //int rowcnt =1;
                //int rowcount = (row15.Length > 5) ? 5 : row15.Length;
                //for (int i = 0; i < rowcount; i++)
                //{
                //    if (decimal.Parse(row15[i]["othrs"].ToString()) > 0)
                //    {
                //        if (salary_pa1)
                //            Row1["Fldet" + rowcnt] = row15[i]["rate"].ToString() + " Times";
                //        else
                //            Row1["Fldet" + rowcnt] = row15[i]["rate"].ToString() + " 倍";
                //        Row1["Flde" + rowcnt] = decimal.Parse(row15[i]["othrs"].ToString());
                //        rowcnt = rowcnt + 1;
                //    }
                //}
                object[] _valuec = new object[2];
                _valuec[0] = "PaySlipOTRate";
                _valuec[1] = Row1["country"].ToString();
                DataRow rowc = DT_PaySlip.Rows.Find(_valuec);
                string _otrate = (rowc != null) ? rowc["description"].ToString() : "";
                DataRow[] row15 = DT_ot.Select("nobr='" + Row1["nobr"].ToString() + "' and othrs>0", "rate asc");
                int rowcnt = 1;
                int rowcount = (row15.Length > 5) ? 5 : row15.Length;
                for (int i = 0; i < rowcount; i++)
                {
                    if (decimal.Parse(row15[i]["othrs"].ToString()) > 0)
                    {
                        if (salary_pa1)
                        {
                            Row1["Fldet" + rowcnt] = (decimal.Parse(row15[i]["rate"].ToString()) > 10) ? row15[i]["rate"].ToString() : row15[i]["rate"].ToString() + " " + _otrate;
                            Row1["Fldeu" + rowcnt] = row15[i]["unit"].ToString();
                        }
                        else
                            Row1["Fldet" + rowcnt] = (decimal.Parse(row15[i]["rate"].ToString()) > 10) ? row15[i]["rate"].ToString() : row15[i]["rate"].ToString() + " 倍";
                        Row1["Flde" + rowcnt] = decimal.Parse(row15[i]["othrs"].ToString());
                        rowcnt = rowcnt + 1;
                    }
                }

                DataRow row16 = DT_abs3.Rows.Find(Row1["nobr"].ToString());
                if (row16 != null)
                {
                    Row1["leave_hrs"] = decimal.Parse(row16["leave_hrs"].ToString());
                    Row1["leave_unit"] = row16["leave_unit"].ToString();
                    Row1["rest_hrs"] = decimal.Parse(row16["rest_hrs"].ToString());
                }


                //DataRow row16 = DT_yret.Rows.Find(Row1["nobr"].ToString());
                //if (row16 != null)
                //    Row1["yret"] = int.Parse(row16["amt"].ToString());
                //DataRow row17 = DT_yertcomp.Rows.Find(Row1["nobr"].ToString());
                //if (row17 != null)
                //    Row1["yretcomp"] = int.Parse(row17["comp"].ToString());
                //DataRow row18 = DT_ytax.Rows.Find(Row1["nobr"].ToString());
                //if (row18 != null)
                //    Row1["ytax"] = int.Parse(row18["amt"].ToString());
                //DataRow row19 = DT_ysalary.Rows.Find(Row1["nobr"].ToString());
                //if (row19 != null)
                //    Row1["ysalary"] = int.Parse(row19["amt"].ToString());

            }

        }




        static string GetFullLenStr(string str, int len)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());

            string emptyStr = "".PadRight(len - bytes.Length, ' ');
            string ss = str.Trim() + emptyStr;
            return ss;
        }


        public static DataTable Get_Ota(string nobr_b, string nobr_e, string yymm, bool labchedk)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr,a.bdate,a.ot_hrs,c.rote_disp as rote,a.nop_w_100,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_100,a.nop_h_133";
            sqlCmd += ",a.nop_h_167,a.nop_h_200,a.not_w_100,a.not_w_133,a.not_w_167,a.not_w_200,a.not_h_133,a.not_h_167,a.not_h_200";
            sqlCmd += ",a.tot_w_100,a.tot_w_133,a.tot_w_167,a.tot_w_200,f.Lanaguage as country";
            if (labchedk)
                sqlCmd += " from ot_b a ,attend b,rote c ";
            else
                sqlCmd += " from ot a ,attend b,rote c ";
            sqlCmd += ",ViewEmployeeLanaguage f";
            sqlCmd += " where a.nobr=b.nobr and a.bdate=b.adate and b.rote=c.rote and a.nobr=f.EmployeeId";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}' and a.fix_amt=0 and a.salary>10", yymm);
            //if (!labchedk)
            //{
            //    sqlCmd += " and not exists  (select f.nobr,f.bdate,f.btime from ot_b f where a.nobr=f.nobr and a.bdate=f.bdate and a.btime=f.btime)";
            //}
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_Ot1(string nobr_b, string nobr_e, string yymm)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr, sum(a.not_w_133+a.tot_w_133) as ot_133,";
            sqlCmd += "sum(a.not_w_167+a.tot_w_167) as ot_167,";
            sqlCmd += "sum(a.not_h_200+a.tot_h_200+a.not_h_167+a.not_h_133) as ot_200,";
            sqlCmd += "sum(a.not_h_200+a.tot_h_200) as ot_200_h";
            sqlCmd += string.Format(@" from ot a, otrcd b where a.otrcd=b.otrcd and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}' and a.fix_amt=0", yymm);
            sqlCmd += " group by a.nobr";
            return Sql.GetDataTable(sqlCmd);
        }


        public static void Get_Ot(DataTable DT_ot, DataTable Dt_ota, DataTable DT_PaySlip)
        {
            DataTable rq_chk = new DataTable();
            rq_chk.Columns.Add("nobr", typeof(string));
            rq_chk.Columns.Add("bdate", typeof(DateTime));
            rq_chk.Columns.Add("rate", typeof(decimal));
            rq_chk.Columns.Add("othrs", typeof(decimal));

            foreach (DataRow Row in Dt_ota.Rows)
            {
                string aa = "";
                if (DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd") == "20190810")
                    aa = "dd";

                object[] _valuec = new object[2];
                _valuec[0] = "PaySlipHrs";
                _valuec[1] = Row["country"].ToString();
                DataRow rowc = DT_PaySlip.Rows.Find(_valuec);

                if (decimal.Parse(Row["nop_w_100"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_100"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_100"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_100"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_100"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_w_133"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_133"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_133"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_133"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_133"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_w_167"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_167"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_167"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_167"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_167"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_w_200"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_200"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_200"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_200"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_200"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_h_133"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_133"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_133"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_133"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_133"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_h_167"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_167"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_167"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_167"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_167"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
                if (decimal.Parse(Row["nop_h_200"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_200"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_200"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_200"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_200"].ToString());
                        aRow["unit"] = (rowc != null) ? rowc["description"].ToString() : "";
                        DT_ot.Rows.Add(aRow);
                    }

                }
            }

            //JBHR.Reports.ReportClass.Export(rq_chk, "rq_chk");
        }

        public static DataTable Get_AllWaged(string nobr_b, string nobr_e, string yy, string yymm)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select nobr,yymm,seq,sal_code,amt from waged";
            sqlCmd += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and left(yymm,4)='{0}' ", yy);
            sqlCmd += string.Format(@" and yymm <='{0}'", yymm);
            sqlCmd += " order by nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static void Get_AllWaged1(DataTable DT_rq_ysalary, DataTable DT_rq_ytax, DataTable DT_rq_yret, DataTable DT_waged, DataTable DT_wage, DataTable DT_salcode, DataTable DT_base, string taxcode, string retsalcode)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_wage.Rows.Find(_value);
                DataRow row1 = DT_salcode.Rows.Find(Row["sal_code"].ToString());
                DataRow row4 = DT_base.Rows.Find(Row["nobr"].ToString());
                if (row != null && row1 != null && row4 != null)
                {
                    Row["flag"] = row1["flag"].ToString();
                    Row["salattr"] = row1["salattr"].ToString();
                    if (row1["flag"].ToString() == "-")
                        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                    else
                        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));

                    if (Row["sal_code"].ToString().Trim() == taxcode.Trim())
                    {
                        DataRow row2 = DT_rq_ytax.Rows.Find(Row["nobr"].ToString());
                        if (row2 != null)
                            row2["amt"] = int.Parse(row2["amt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                        else
                        {
                            DataRow aRow = DT_rq_ytax.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                            DT_rq_ytax.Rows.Add(aRow);
                        }
                    }

                    if (Row["sal_code"].ToString().Trim() == retsalcode)
                    {
                        DataRow row5 = DT_rq_yret.Rows.Find(Row["nobr"].ToString());
                        if (row5 != null)
                            row5["amt"] = int.Parse(row5["amt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                        else
                        {
                            DataRow aRow2 = DT_rq_yret.NewRow();
                            aRow2["nobr"] = Row["nobr"].ToString();
                            aRow2["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                            DT_rq_yret.Rows.Add(aRow2);
                        }
                    }
                }
                else
                    Row.Delete();
            }
            DT_waged.AcceptChanges();

            DataRow[] SRow = DT_waged.Select("salattr <='F'");
            foreach (DataRow Row1 in SRow)
            {
                DataRow row3 = DT_rq_ysalary.Rows.Find(Row1["nobr"].ToString());
                if (row3 != null)
                    row3["amt"] = int.Parse(row3["amt"].ToString()) + int.Parse(Row1["amt"].ToString());
                else
                {
                    DataRow aRow1 = DT_rq_ysalary.NewRow();
                    aRow1["nobr"] = Row1["nobr"].ToString();
                    aRow1["amt"] = int.Parse(Row1["amt"].ToString());
                    DT_rq_ysalary.Rows.Add(aRow1);
                }
            }

        }

        public static void Get_AllRetComp(DataTable DT_rq_yretcomp, DataTable DT_yexplab)
        {
            foreach (DataRow Row in DT_yexplab.Rows)
            {
                Row["comp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["comp"].ToString()));
                DataRow row = DT_rq_yretcomp.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["comp"] = int.Parse(row["comp"].ToString()) + int.Parse(Row["comp"].ToString());
                else
                {
                    DataRow aRow = DT_rq_yretcomp.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["comp"] = int.Parse(Row["comp"].ToString());
                    DT_rq_yretcomp.Rows.Add(aRow);
                }
            }
        }

        public static DataTable Get_AllWage(string nobr_b, string nobr_e, string yy, string yymm)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select nobr,yymm,seq from wage";
            sqlCmd += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and left(yymm,4)='{0}' ", yy);
            sqlCmd += string.Format(@" and yymm <='{0}'", yymm);
            sqlCmd += " order by nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_Reta(string nobr_b, string nobr_e, string date_b, string date_e, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            //string sqlCmd = "select distinct a.nobr,a.in_date,a.r_amt,a.h_amt,a.l_amt from inslab a,basetts b";   
            //sqlCmd+=" where a.nobr=b.nobr";
            //sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            //sqlCmd += string.Format(@" and ( '{0}' between a.in_date and a.out_date ", date_e);
            //sqlCmd += string.Format(@" or a.out_date between '{0}' and '{1}')", date_b, date_e);
            //sqlCmd += " and a.fa_idno=''";
            ////sqlCmd += " and b.oudt between  a.in_date and a.out_date";
            //sqlCmd += workadr;
            //sqlCmd += " order by nobr";
            string sqlCmd = "select distinct a.nobr,a.in_date,a.r_amt,a.h_amt,a.l_amt from inslab a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += " and a.nobr+Convert(char(10),a.in_date,112)+a.fa_idno in ";
            sqlCmd += " (select nobr+Convert(char(10),max(in_date),112)+e.fa_idno from inslab e";
            sqlCmd += string.Format(@" where e.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and e.in_date<= '{0}' and e.out_date >='{1}' ", date_e, date_b);
            sqlCmd += " and e.fa_idno='' group by e.nobr,e.fa_idno) ";
            //sqlCmd += " and b.oudt between  a.in_date and a.out_date";
            sqlCmd += workadr;
            sqlCmd += " order by a.nobr";
            DataTable rq_inslab = Sql.GetDataTable(sqlCmd);
            rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };

            //string sqlCmd1 = "select distinct nobr,in_date,r_amt,h_amt,l_amt from inslab ";
            //sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd1 += string.Format(@"  and in_date between '{0}' and '{1}'", date_b, date_e);
            //sqlCmd1 += " and code='3' and not exists(select * from inslab a where inslab.nobr=a.nobr ";
            //sqlCmd1 += " and dateadd(d,-1,inslab.in_date) between  a.in_date and a.out_date )";
            //DataTable rq_inslab1 = Sql.GetDataTable(sqlCmd1);

            //foreach (DataRow Row in rq_inslab1.Rows)
            //{
            //    DataRow row = rq_inslab.Rows.Find(Row["nobr"].ToString());
            //    if (row==null)
            //        rq_inslab.ImportRow(Row);
            //}
            return rq_inslab;
        }

        public static DataTable Get_RetCountFamailyCnt(string nobr_b, string nobr_e, string date_b, string date_e, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            //string sqlCmd = "select distinct a.nobr,count(a.nobr) as cnt from inslab a,basetts b";
            //sqlCmd += " where a.nobr=b.nobr";
            //sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            //sqlCmd += string.Format(@" and ( '{0}' between a.in_date and a.out_date ", date_e);
            //sqlCmd += string.Format(@" or a.out_date between '{0}' and '{1}')", date_b, date_e);
            //sqlCmd += " and a.fa_idno<>''";
            ////sqlCmd += " and b.oudt between  a.in_date and a.out_date";
            //sqlCmd += workadr;
            //sqlCmd += " group by a.nobr";
            //DataTable rq_inslab = Sql.GetDataTable(sqlCmd);
            //rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };

            string sqlCmd = "select distinct a.nobr,count(a.nobr) as cnt from inslab a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += " and a.nobr+Convert(char(10),a.in_date,112)+a.fa_idno in ";
            sqlCmd += " (select nobr+Convert(char(10),max(in_date),112)+e.fa_idno from inslab e";
            sqlCmd += string.Format(@" where e.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and e.in_date<= '{0}' and e.out_date >='{1}' ", date_e, date_b);
            sqlCmd += " and e.fa_idno<>'' group by e.nobr,e.fa_idno) ";
            sqlCmd += workadr;
            sqlCmd += " group by a.nobr";
            DataTable rq_inslab = Sql.GetDataTable(sqlCmd);
            rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };

            ////當月加保退保
            //string sqlCmd1 = "select nobr,count(nobr) as cnt from inslab ";
            //sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd1 += string.Format(@"  and in_date between '{0}' and '{1}'", date_b, date_e);
            //sqlCmd1 += " and code='3' and not exists(select * from inslab a where inslab.nobr=a.nobr ";
            //sqlCmd1 += " and dateadd(d,-1,inslab.in_date) between  a.in_date and a.out_date )";
            //sqlCmd1 += " and fa_idno<>''";
            //sqlCmd1 += " group by nobr";
            //DataTable rq_inslab1 = Sql.GetDataTable(sqlCmd1);
            //foreach (DataRow Row in rq_inslab1.Rows)
            //{
            //    DataRow row = rq_inslab.Rows.Find(Row["nobr"].ToString());
            //    if (row == null)
            //        rq_inslab.ImportRow(Row);
            //}
            return rq_inslab;
        }


        public static DataTable Get_AllRet(string nobr_b, string nobr_e, string yy, string yymm)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr,a.comp from explab a";
            sqlCmd += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and left(a.yymm,4)='{0}'", yy);
            sqlCmd += string.Format(@" and a.yymm <='{0}'", yymm);
            sqlCmd += " and a.insur_type='4'";
            sqlCmd += " order by nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_Ret(string nobr_b, string nobr_e, string date_b, string yymm, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr,a.comp,b.retrate,b.retchoo from explab a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}'", yymm);
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
            sqlCmd += " and a.insur_type='4'";
            sqlCmd += workadr;
            sqlCmd += " order by nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static void Get_Ret1(DataTable DT_ret1, DataTable DT_waged, string retsalcode)
        {
            DataRow[] row_waged = DT_waged.Select("sal_code='" + retsalcode + "'");
            foreach (DataRow Row in row_waged)
            {
                DataRow row = DT_ret1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_ret1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_ret1.Rows.Add(aRow);
                }
            }
        }

        public static DataTable Get_Rett(string nobr_b, string nobr_e, string date_e, string yymm, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select distinct a.nobr,b.retrate,b.retchoo from wage a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}'", yymm);
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += workadr;
            sqlCmd += " order by a.nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_Salbasd(string nobr_b, string nobr_e, string date_e, string yymm, string seq, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr,c.amt from wage a,basetts b,salbasd c";
            sqlCmd += " where a.nobr=b.nobr and a.nobr=c.nobr";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}' and a.seq='{1}'", yymm, seq);
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += string.Format(@" and '{0}' between c.adate and c.ddate", date_e);
            sqlCmd += workadr;
            sqlCmd += " order by a.nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static void Get_Salbasd1(DataTable DT_salbasd1, DataTable DT_salbasd)
        {
            foreach (DataRow Row in DT_salbasd.Rows)
            {
                Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                DataRow row = DT_salbasd1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_salbasd1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_salbasd1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_Sala(DataTable DT_sala, DataTable DT_waged)
        {
            DataRow[] row_waged = DT_waged.Select("salattr='D' or salattr='J' or salattr='M' or salattr='N'");
            foreach (DataRow Row in row_waged)
            {
                int _amt = int.Parse(Row["amt"].ToString());
                if (Row["flag"].ToString().Trim() == "-")
                    _amt = _amt * (-1);
                DataRow row = DT_sala.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + _amt;
                else
                {
                    DataRow aRow = DT_sala.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = _amt;
                    DT_sala.Rows.Add(aRow);
                }
            }
        }

        public static DataTable Get_Attend(string nobr_b, string nobr_e, string attdate_b, string attdate_e)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select nobr,adate,rote,late_mins,forget from attend";
            sqlCmd += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and adate between '{0}' and '{1}'", attdate_b, attdate_e);
            sqlCmd += " and (late_mins >0 or forget > 0)";
            sqlCmd += " order by nobr,adate";
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_LateMins(string nobr_b, string nobr_e, string attdate_b, string attdate_e)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select nobr,count(nobr) as cnt from attend";
            sqlCmd += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and adate between '{0}' and '{1}'", attdate_b, attdate_e);
            sqlCmd += " and late_mins >0 ";
            sqlCmd += " group by nobr";
            return Sql.GetDataTable(sqlCmd);
        }

        public static DataTable Get_AttBase(string nobr_b, string nobr_e, string attdate_e, string workadr)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select nobr from basetts";
            sqlCmd += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and '{0}' between adate and ddate", attdate_e);
            sqlCmd += " and fulatt!=1";
            sqlCmd += workadr;
            return Sql.GetDataTable(sqlCmd);
        }

        public static void Get_NAtt(DataTable DT_att, DataTable DT_att1, DataTable DT_attend, DataTable DT_attbase)
        {
            foreach (DataRow Row in DT_attend.Rows)
            {
                DataRow row = DT_attbase.Rows.Find(Row["nobr"].ToString());
                if (row != null && decimal.Parse(Row["late_mins"].ToString()) > 0)
                {
                    DataRow row1 = DT_att.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                        row1["tot_hrs"] = int.Parse(row1["tot_hrs"].ToString()) + 1;
                    else
                    {
                        DataRow aRow = DT_att.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["h_code"] = "Z0";
                        aRow["tot_hrs"] = 1;
                        DT_att.Rows.Add(aRow);
                    }
                }

                if (row != null && decimal.Parse(Row["forget"].ToString()) > 0)
                {
                    DataRow row2 = DT_att1.Rows.Find(Row["nobr"].ToString());
                    if (row2 != null)
                        row2["tot_hrs"] = int.Parse(row2["tot_hrs"].ToString()) + 1;
                    else
                    {
                        DataRow aRow1 = DT_att1.NewRow();
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["h_code"] = "Z1";
                        aRow1["tot_hrs"] = 1;
                        DT_att1.Rows.Add(aRow1);
                    }
                }
            }
        }

        public static DataTable Get_Abs1(string nobr_b, string nobr_e, string yymm, DataTable DT_PaySlip)
        {
            //and b.att=1判斷是否只顯示影響全勤
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            //string sqlCmd = "select a.nobr,b.h_code_disp as h_code,b.unit,b.h_ename as h_name,sum(a.tol_hours) as tol_hours";
            //sqlCmd += "  from abs a,hcode b where a.h_code =b.h_code ";
            //sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd += string.Format(@" and a.yymm='{0}'", yymm);
            ////sqlCmd += " and  b.year_rest in ('0','2','4') ";
            ////sqlCmd += " and a.h_code in ('A','B','B1','B2','C','I','K','D','F','E','A','J','J1','J2','J3','J4','E','E1','E2','N','B1','C1','L','M','O','T')";
            ////sqlCmd += " and a.syscreate=0 and b.not_del=0";
            //sqlCmd += " and b.not_del=0";
            //sqlCmd += " group by a.nobr,b.h_code_disp,b.unit,b.h_ename";
            //多國語系假別名稱
            DataTable rq_hcodelang = Sql.GetDataTable("select code,language,display_name from mtlng where category='HCODE' order by language,code");
            rq_hcodelang.PrimaryKey = new DataColumn[] { rq_hcodelang.Columns["code"], rq_hcodelang.Columns["language"] };

            //and b.att=1判斷是否只顯示影響全勤

            string sqlCmd = "select a.nobr,c.Lanaguage as country,b.h_code,b.unit,b.h_name,sum(a.tol_hours) as tol_hours";//,d.language
            sqlCmd += "  from abs a,ViewEmployeeLanaguage c,hcode b";
            //sqlCmd += " left outer join mtlng d on b.h_code=d.code and d.category='HCODE'";
            sqlCmd += "  where a.h_code =b.h_code and a.nobr=c.EmployeeId";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}'", yymm);
            sqlCmd += " and b.not_del=0";
            sqlCmd += " group by a.nobr,c.Lanaguage,b.h_code,b.unit,b.h_name";
            DataTable rq_abs = Sql.GetDataTable(sqlCmd);
            foreach (DataRow Row in rq_abs.Rows)
            {
                string _unit = (Row["unit"].ToString().Trim() == "天") ? "PaySlipDays" : "PaySlipHrs";
                object[] _value = new object[2];
                _value[0] = _unit;
                _value[1] = Row["country"].ToString();
                DataRow row = DT_PaySlip.Rows.Find(_value);
                if (row != null)
                {
                    Row["unit"] = row["description"].ToString();
                }
                else
                {
                    if (Row["unit"].ToString().Trim() == "小時")
                        Row["unit"] = "hours";
                    else if (Row["unit"].ToString().Trim() == "天")
                        Row["unit"] = "days";
                }

                _value[0] = Row["h_code"].ToString();
                DataRow row1 = rq_hcodelang.Rows.Find(_value);
                Row["h_name"] = (row1 != null) ? Row["h_name"].ToString() + row1["display_name"].ToString() : Row["h_name"].ToString();
            }
            return rq_abs;
        }

        public static DataTable Get_Abs2(string nobr_b, string nobr_e, string yymm)
        {
            //and b.att=1判斷是否只顯示影響全勤
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select a.nobr,b.h_code_disp as h_code,b.unit,b.h_name,sum(a.tol_hours) as tol_hours";
            //增加判斷篩掉得假資料
            sqlCmd += "  from abs a,hcode b where a.h_code =b.h_code and b.flag = '-' ";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and a.yymm='{0}'", yymm);
            //sqlCmd += " and  b.year_rest in ('0','2','4')";
            //sqlCmd += " and a.h_code in ('A','B','B1','B2','C','I','K','D','F','E','A','J','J1','J2','J3','J4','E','E1','E2','N','B1','C1','L','M','O','T')";
            //sqlCmd += " and a.syscreate=0 and b.not_del=0";
            sqlCmd += " and b.not_del=0";
            sqlCmd += " group by a.nobr,b.h_code_disp,b.unit,b.h_name";
            return Sql.GetDataTable(sqlCmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AnnualLeave_Type"></param>
        /// <param name="CompensatoryLeave_Type"></param>
        /// <param name="nobr_b"></param>
        /// <param name="nobr_e"></param>
        /// <param name="attdate_e"></param>
        /// <param name="DT_wage"></param>
        /// <param name="CompId"></param>
        /// <param name="loginuser"></param>
        /// <returns></returns>
        public static DataTable Get_Abs3(string AnnualLeave_Type, string CompensatoryLeave_Type
            , string nobr_b, string nobr_e, string attdate_e
            , DataTable DT_wage, string CompId, string loginuser
            , string emp_b, string emp_e, string dept_b, string dept_e, string depts_b, string depts_e, string comp_b, string comp_e
            , string user, string comp, bool isadmin)
        {
            //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            //string AnnualHcodeType = AppConfig.GetConfig("Remain_AnnualType").Value;
            //string RestHcodeType = AppConfig.GetConfig("Remain_RestType").Value;
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

            //DataTable rq_hcode = Sql.GetDataTable("select htype,unit from hcode where htype in ('" + AnnualHcodeType + "','" + RestHcodeType + "') and flag='+' group by htype,unit");
            DataTable rq_hcode = Sql.GetDataTable(" SELECT htype,unit FROM HCODE WHERE DBO.GetCodeFilter('HCODE', HCODE.H_CODE, '" + loginuser + "', '" + CompId + "', 1)=1 AND htype in ('" + AnnualLeave_Type + "','" + CompensatoryLeave_Type + "') and flag='+' group by htype,unit");
            rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["htype"] };

            DataTable rq_abs1 = new DataTable();
            rq_abs1.Columns.Add("nobr", typeof(string));
            rq_abs1.Columns.Add("leave_hrs", typeof(decimal));
            rq_abs1.Columns.Add("rest_hrs", typeof(decimal));
            rq_abs1.Columns.Add("leave_unit", typeof(string));
            rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };

            //string sqlCmd = "select a.nobr,b.htype,sum(a.balance) as tol_hours";
            //sqlCmd += "  from abs a inner join hcode b on a.h_code =b.h_code ";
            //sqlCmd += " where 1 = 1 ";
            //sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            ////sqlCmd += string.Format(@" and a.bdate between '{0}' and '{1}'", attdate_b, attdate_e);
            //sqlCmd += string.Format(@" and '{0}' between a.bdate and a.edate", attdate_e);
            //sqlCmd += string.Format(@" and b.htype in ('{0}','{1}')  and b.flag='+'", AnnualLeave_Type, CompensatoryLeave_Type);
            //sqlCmd += " group by a.nobr,b.htype";
            //DataTable rq_abs = Sql.GetDataTable(sqlCmd);

            string sqlCmd = "select distinct a.nobr ";
            sqlCmd += "  from abs a inner join hcode b on a.h_code =b.h_code ";
            sqlCmd += " where 1 = 1 ";
            sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            //sqlCmd += string.Format(@" and a.bdate between '{0}' and '{1}'", attdate_b, attdate_e);
            sqlCmd += string.Format(@" and '{0}' between a.bdate and a.edate", attdate_e);
            sqlCmd += string.Format(@" and b.htype in ('{0}','{1}')  and b.flag='+'", AnnualLeave_Type, CompensatoryLeave_Type);
            DataTable rq_abs = Sql.GetDataTable(sqlCmd);

            #region 特休剩餘時數
            //string attdate_e, string type
            //, string nobr_b, string nobr_e
            //, string empcd_b, string empcd_e
            //, string dept_b, string dept_e
            //, string depts_b, string depts_e
            //, string comp_b, string comp_e
            //, string user, string comp, bool admin)
            DataTable Leave_DT = GetTolHours(attdate_e, AnnualLeave_Type, nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, user, comp, isadmin);
            Leave_DT.PrimaryKey = new DataColumn[] { Leave_DT.Columns["NOBR"] };

            #endregion

            #region 補休剩餘時數

            DataTable Rest_DT = GetTolHours(attdate_e, CompensatoryLeave_Type, nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, user, comp, isadmin);
            Rest_DT.PrimaryKey = new DataColumn[] { Rest_DT.Columns["NOBR"] };

            #endregion

            foreach (DataRow Row in rq_abs.Rows)
            {

                DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                DataRow row_leave = Leave_DT.Rows.Find(Row["nobr"].ToString());
                DataRow row_rest = Rest_DT.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    string unit = "時數";
                    DataRow row2 = rq_hcode.Rows.Find(AnnualLeave_Type);
                    DataRow aRow = rq_abs1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["leave_hrs"] = 0;
                    aRow["rest_hrs"] = 0;
                    aRow["leave_unit"] = unit;
                    //aRow["rest_unit"] = unit;
                        if (row_leave != null)
                            aRow["leave_hrs"] = decimal.Parse(row_leave["Check_Balance"].ToString());
                        aRow["leave_unit"] = (row2 != null) ? row2["unit"].ToString() : "";
                    if(row_rest != null)
                        aRow["rest_hrs"] = decimal.Parse(row_rest["Check_Balance"].ToString());
                    
                    rq_abs1.Rows.Add(aRow);
                }
            }


            foreach (DataRow Row in DT_wage.Rows)
            {
                DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    //if (salary_pa1)
                    //{
                    //    string _unit = (row["leave_unit"].ToString().Trim() == "天") ? "PaySlipDays" : "PaySlipHrs";
                    //    object[] _value = new object[2];
                    //    _value[0] = _unit;
                    //    _value[1] = Row["Lanaguage"].ToString();
                    //    DataRow row1 = DT_PaySlip.Rows.Find(_value);
                    //    if (row1 != null)
                    //    {
                    //        row["leave_unit"] = row1["description"].ToString();
                    //    }
                    //    else
                    //    {
                    //        if (row["leave_unit"].ToString().Trim() == "天")
                    //            row["leave_unit"] = "days";
                    //        else
                    //            row["leave_unit"] = "hours";
                    //    }
                    //}
                    if (row["leave_unit"].ToString().Trim() == "天")
                        row["leave_unit"] = "天數";
                    else
                        row["leave_unit"] = "時數";
                }
                else
                {

                    //if (salary_pa1)
                    //{
                    //    string _unit = "PaySlipHrs";
                    //    object[] _value = new object[2];
                    //    _value[0] = _unit;
                    //    _value[1] = Row["Lanaguage"].ToString();
                    //    DataRow row1 = DT_PaySlip.Rows.Find(_value);
                    //    if (row1!=null) unit1 = row1["description"].ToString();
                    //}

                    DataRow aRow = rq_abs1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["leave_hrs"] = 0;
                    aRow["rest_hrs"] = 0;
                    aRow["leave_unit"] = "時數";
                    aRow["rest_hrs"] = 0;
                    rq_abs1.Rows.Add(aRow);
                }

            }
            return rq_abs1;
        }

        public static void Get_Abs(DataTable DT_abs, DataTable DT_abs1, DataTable DT_base, bool prn_noemail)
        {
            foreach (DataRow Row in DT_abs1.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (prn_noemail)
                    {
                        if (row["email"].ToString().Trim() == "")
                            DT_abs.ImportRow(Row);
                    }
                    else
                        DT_abs.ImportRow(Row);
                }
            }
        }

        public static void Get_Report8A(DataTable DT_zz42, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_nobr = Row["nobr"].ToString();
                string str_acccd = Row["acccd"].ToString();
                object[] _value = new object[2];
                _value[0] = str_nobr;
                _value[1] = str_acccd;
                DataRow row2 = DT_zz42.Rows.Find(_value);

                if (row2 != null)
                    row2["amt"] = decimal.Parse(row2["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_zz42.NewRow();
                    aRow["nobr"] = str_nobr;
                    aRow["acccd"] = str_acccd;
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    DT_zz42.Rows.Add(aRow);
                }
            }
        }

        public static void Get_Report8B(DataTable DT_zz421, DataTable DT_waged)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_acccd = Row["acccd"].ToString();
                string str_accname = Row["accname"].ToString();
                DataRow row1 = DT_zz421.Rows.Find(str_acccd);
                if (row1 == null)
                {
                    DataRow aRow = DT_zz421.NewRow();
                    aRow["code1"] = "0000";
                    aRow["acccd"] = str_acccd;
                    aRow["sal_name"] = str_accname.PadLeft(8, '_');
                    DT_zz421.Rows.Add(aRow);
                }
            }
        }

        public static void Get_Report8C(DataTable DT_zz4211, DataTable DT_zz421)
        {
            DataRow[] Srow = DT_zz421.Select("", "code1,acccd asc");
            foreach (DataRow Row in Srow)
            {
                string str_acccd = Row["acccd"].ToString();
                DataRow row = DT_zz4211.Rows.Find(str_acccd);
                if (row == null)
                {
                    DataRow aRow = DT_zz4211.NewRow();
                    aRow["code1"] = Row["code1"].ToString();
                    aRow["acccd"] = Row["acccd"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    DT_zz4211.Rows.Add(aRow);
                }
            }
        }

        public static void Get_Report8D(DataTable DT_zz42ta, DataTable DT_zz42tb, DataTable DT_zz4211, DataTable DT_zz42, DataTable DT_base)
        {
            double result;
            CultureInfo MyCultureInfo = new CultureInfo("en-GB");
            Hashtable ht = new Hashtable();
            DataTable zz42gtt = new DataTable("zz42gtt");
            zz42gtt.Columns.Add("nobr", typeof(string));
            zz42gtt.PrimaryKey = new DataColumn[] { zz42gtt.Columns["nobr"] };
            for (int i = 0; i < DT_zz4211.Rows.Count; i++)
            {
                if (!Double.TryParse(DT_zz4211.Rows[i][1].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                {
                    zz42gtt.Columns.Add("C_" + DT_zz4211.Rows[i][1].ToString().Trim(), typeof(decimal));
                }
                else
                {
                    zz42gtt.Columns.Add(DT_zz4211.Rows[i][1].ToString().Trim(), typeof(decimal));
                }
                ht.Add("Fld" + (i + 1), DT_zz4211.Rows[i][2].ToString());
            }
            for (int i = 0; i < DT_zz42.Rows.Count; i++)
            {
                string strdd = "";
                DataRow dr = zz42gtt.Rows.Find(DT_zz42.Rows[i]["nobr"].ToString());
                if (dr == null)
                {//new
                    DataRow newRow = zz42gtt.NewRow();
                    newRow["nobr"] = DT_zz42.Rows[i]["nobr"].ToString();
                    //if(ds.Tables["rq_abs2"].Rows[i]["h_code"].ToString().IndexOf("W")>=0)
                    if (!Double.TryParse(DT_zz42.Rows[i]["acccd"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                    {
                        newRow["C_" + DT_zz42.Rows[i]["acccd"].ToString().Trim()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                    }
                    else
                    {
                        newRow[DT_zz42.Rows[i]["acccd"].ToString().Trim()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                    }
                    zz42gtt.Rows.Add(newRow);
                }
                else
                {//update
                    DataRow newRow = dr;

                    if (!Double.TryParse(DT_zz42.Rows[i]["acccd"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                    {
                        strdd = DT_zz42.Rows[i]["acccd"].ToString().Trim();
                        newRow["C_" + DT_zz42.Rows[i]["acccd"].ToString().Trim()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                    }
                    else
                    {
                        newRow[DT_zz42.Rows[i]["acccd"].ToString().Trim()] = Convert.ToDecimal(DT_zz42.Rows[i]["amt"].ToString());
                    }

                }
            }
            DataRow newRow2 = DT_zz42ta.NewRow();
            for (int i = 0; i < ht.Count; i++)
            {
                newRow2["Fld" + (i + 1)] = ht["Fld" + (i + 1)].ToString();
            }

            DT_zz42ta.Rows.Add(newRow2);


            for (int i = 0; i < zz42gtt.Rows.Count; i++)
            {
                string str_nobr = zz42gtt.Rows[i]["nobr"].ToString();
                DataRow row8 = DT_base.Rows.Find(str_nobr);
                if (row8 != null)
                {
                    DataRow newRow = DT_zz42tb.NewRow();
                    newRow["Nobr"] = row8["nobr"].ToString();
                    newRow["Name_c"] = row8["name_c"].ToString();
                    newRow["Dept"] = row8["dept"].ToString();
                    newRow["D_name"] = row8["d_name"].ToString();
                    for (int j = 1; j < zz42gtt.Columns.Count; j++)
                    {
                        //							newRow["Fld"+j] =ds.Tables["zz23d"].Rows[i][ds.Tables["zz23d"].Columns[j].ColumnName].ToString();
                        if (zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString().Length == 0)
                        {
                            newRow["Fld" + j] = 0;
                        }
                        else
                        {
                            newRow["Fld" + j] = decimal.Parse(zz42gtt.Rows[i][zz42gtt.Columns[j].ColumnName].ToString());
                        }

                    }
                    for (int k = zz42gtt.Columns.Count; k < 36; k++)
                    {
                        newRow["Fld" + k] = 0;
                    }
                    DT_zz42tb.Rows.Add(newRow);
                }
            }
        }

        public static void Get_Report8E(DataTable DT_42td, DataTable DT_42tb, DataTable DT_base)
        {
            int _count = 0;
            for (int i = 0; i < DT_42tb.Columns.Count - 4; i++)
            {
                if (DT_42tb.Rows[0]["Fld" + (i + 1)].ToString() != "")
                {
                    _count++;
                }
                else
                    break;

            }
            for (int i = 0; i < DT_42tb.Rows.Count; i++)
            {
                string str_nobr = DT_42tb.Rows[i]["nobr"].ToString();
                string str_depts = "";
                DataRow row47 = DT_base.Rows.Find(str_nobr);
                if (row47 != null)
                {
                    str_depts = row47["depts"].ToString();
                    object[] _value = new object[2];
                    _value[0] = row47["dept"].ToString();
                    _value[1] = str_nobr;
                    DataRow row48 = DT_42td.Rows.Find(_value);
                    if (row48 == null)
                    {
                        DataRow aRow = DT_42td.NewRow();
                        aRow["mark"] = "";
                        aRow["nobr"] = row47["nobr"].ToString();
                        aRow["name_c"] = row47["name_c"].ToString();
                        aRow["idno"] = row47["idno"].ToString();
                        aRow["dept"] = row47["dept"].ToString();
                        aRow["dept1"] = str_depts.Substring(3, 2) + str_depts.Substring(1, 2);
                        aRow["d_name"] = row47["d_name"].ToString();
                        aRow["aadate"] = DateTime.Parse(row47["adate"].ToString());
                        for (int j = 1; j < _count; j++)
                        {
                            decimal _tttt = decimal.Parse(DT_42tb.Rows[i]["Fld" + j].ToString());
                            aRow["Fld" + j] = 0;
                            aRow["Fld" + j] = decimal.Parse(DT_42tb.Rows[i]["Fld" + j].ToString());
                        }
                        DT_42td.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void Get_Report17(string Temporary_Empcd, DataTable DT_zz421d, DataTable DT_waged, DataTable DT_base, string date_b, string year, string month, string nobr_b, string nobr_e, string yymm, string lcstr2, string CompId, string retsalcode, string nottaxsalcode, string tottaxsalcode)
        {
            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            //string nottaxsalcode = ""; string tottaxsalcode = "";
            //string sqlUsys3 = "select notaxsalcode,totaxsalcode from u_sys3 where comp='" + CompId + "'";
            //DataTable rq_usys3 = Sql.GetDataTable(sqlUsys3);
            //if (rq_usys3.Rows.Count > 0) nottaxsalcode = rq_usys3.Rows[0]["notaxsalcode"].ToString();
            //if (rq_usys3.Rows.Count > 0) tottaxsalcode = rq_usys3.Rows[0]["totaxsalcode"].ToString();
            DataTable rq_wageots = new DataTable();
            rq_wageots.Columns.Add("comp", typeof(string));
            rq_wageots.Columns.Add("compname", typeof(string));
            rq_wageots.Columns.Add("di", typeof(string));
            rq_wageots.Columns.Add("sex", typeof(string));
            rq_wageots.Columns.Add("amt", typeof(int));
            DataColumn[] _key = new DataColumn[3];
            _key[0] = rq_wageots.Columns["comp"];
            _key[1] = rq_wageots.Columns["di"];
            _key[2] = rq_wageots.Columns["sex"];
            rq_wageots.PrimaryKey = _key;

            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (row["di"].ToString().Trim() == "S")
                        row["di"] = "I";
                    object[] _value = new object[3];
                    _value[0] = row["comp"].ToString();
                    _value[1] = row["di"].ToString().Trim();
                    _value[2] = row["sex"].ToString();
                    DataRow row1 = rq_wageots.Rows.Find(_value);
                    if (row1 != null)
                    {
                        if (Row["sal_code"].ToString().Trim() == nottaxsalcode || Row["sal_code"].ToString().Trim() == tottaxsalcode)
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        if (Row["sal_code"].ToString().Trim() == nottaxsalcode || Row["sal_code"].ToString().Trim() == tottaxsalcode)
                        {
                            DataRow aRow = rq_wageots.NewRow();
                            aRow["comp"] = row["comp"].ToString();
                            aRow["compname"] = row["compname"].ToString();
                            aRow["di"] = row["di"].ToString().Trim();
                            aRow["sex"] = row["sex"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            rq_wageots.Rows.Add(aRow);
                        }
                    }
                }
            }

            //取得加班工時
            string SqlOt = "select nobr,ot_hrs,rest_hrs from ot";
            SqlOt += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            SqlOt += string.Format(@" and yymm='{0}'", yymm);
            DataTable rq_ot = Sql.GetDataTable(SqlOt);

            DataTable rq_ots = new DataTable();
            rq_ots.Columns.Add("comp", typeof(string));
            rq_ots.Columns.Add("di", typeof(string));
            rq_ots.Columns.Add("sex", typeof(string));
            rq_ots.Columns.Add("ot_hrs", typeof(decimal));
            rq_ots.Columns.Add("rest_hrs", typeof(decimal));
            DataColumn[] _key1 = new DataColumn[3];
            _key1[0] = rq_ots.Columns["comp"];
            _key1[1] = rq_ots.Columns["di"];
            _key1[2] = rq_ots.Columns["sex"];
            rq_ots.PrimaryKey = _key1;
            
            string mdateb = ""; string mdatee = "";
            mdateb = JBHR.Reports.ReportClass.GetAttBDate(year, month);
            mdatee = JBHR.Reports.ReportClass.GetAttEDate(year, month);
            //if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
            //{
            //    mdateb = DateTime.Parse(Convert.ToString(int.Parse(year) + 1911) + "/" + month + "/19").AddMonths(-1).ToString("yyyy/MM/dd");
            //    mdatee = DateTime.Parse(Convert.ToString(int.Parse(year) + 1911) + "/" + month + "/18").ToString("yyyy/MM/dd");
            //}
            //else
            //{
            //    mdateb = DateTime.Parse(year + "/" + month + "/19").AddMonths(-1).ToString("yyyy/MM/dd");
            //    mdatee = DateTime.Parse(year + "/" + month + "/18").ToString("yyyy/MM/dd");
            //}

            string SqlAttend = "select a.nobr,sum(b.wk_hrs) as wk_hrs from attend a,rote b where a.rote=b.rote";
            SqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", mdateb, mdatee);
            SqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            SqlAttend += " group by a.nobr";
            DataTable rq_attned = Sql.GetDataTable(SqlAttend);
            DataTable rq_attends = new DataTable();
            rq_attends.Columns.Add("comp", typeof(string));
            rq_attends.Columns.Add("count", typeof(int));
            rq_attends.Columns.Add("di", typeof(string));
            rq_attends.Columns.Add("sex", typeof(string));
            rq_attends.Columns.Add("wk_hrs", typeof(decimal));
            DataColumn[] _key2 = new DataColumn[3];
            _key2[0] = rq_attends.Columns["comp"];
            _key2[1] = rq_attends.Columns["di"];
            _key2[2] = rq_attends.Columns["sex"];
            rq_attends.PrimaryKey = _key2;
            
            //取得實發薪資
            DataTable rq_cc = new DataTable();
            rq_cc.Columns.Add("comp", typeof(string));
            rq_cc.Columns.Add("compname", typeof(string));
            rq_cc.Columns.Add("nobr", typeof(string));
            rq_cc.Columns.Add("di", typeof(string));
            rq_cc.Columns.Add("sex", typeof(string));
            rq_cc.Columns.Add("amt", typeof(decimal));
            rq_cc.PrimaryKey = new DataColumn[] { rq_cc.Columns["comp"], rq_cc.Columns["nobr"] };
            DataTable rq_cc1 = new DataTable();
            rq_cc1 = rq_cc.Clone();
            rq_cc1.TableName = "rq_cc1";

            //經常員工
            DataTable rq_cc2 = new DataTable();
            rq_cc2.Columns.Add("comp", typeof(string));
            rq_cc2.Columns.Add("compname", typeof(string));
            rq_cc2.Columns.Add("nobr", typeof(string));
            rq_cc2.Columns.Add("di", typeof(string));
            rq_cc2.Columns.Add("sex", typeof(string));
            rq_cc2.Columns.Add("empcd", typeof(string));
            rq_cc2.Columns.Add("amt", typeof(string));
            rq_cc2.PrimaryKey = new DataColumn[] { rq_cc2.Columns["comp"], rq_cc2.Columns["nobr"] };

            lcstr2 = lcstr2;
            DataTable rq_base1 = JBHR.Reports.ZZ42Class.Get_base3(lcstr2, date_b, nobr_b, nobr_e);
            rq_base1.PrimaryKey = new DataColumn[] { rq_base1.Columns["nobr"] };

            DataRow[] Owaged = DT_waged.Select("sal_code <>'" + retsalcode + "' and sal_code <>'" + nottaxsalcode + "' and sal_code <>'" + tottaxsalcode + "' and (type='1' or type='2')");
            foreach (DataRow Row in Owaged)
            {
                DataRow row = rq_base1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (row["di"].ToString().Trim() == "S")
                        row["di"] = "I";
                    object[] _value = new object[2];
                    _value[0] = row["comp"].ToString();
                    _value[1] = row["nobr"].ToString();
                    if (bool.Parse(Row["notfreq"].ToString()))
                    {

                        DataRow row1 = rq_cc.Rows.Find(_value);
                        if (row1 != null)
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = rq_cc.NewRow();
                            aRow["comp"] = row["comp"].ToString();
                            aRow["compname"] = row["compname"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["di"] = row["di"].ToString().Trim();
                            aRow["sex"] = row["sex"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            rq_cc.Rows.Add(aRow);
                        }
                    }
                    if (!bool.Parse(Row["notfreq"].ToString()))
                    {
                        DataRow row2 = rq_cc1.Rows.Find(_value);
                        if (row2 != null)
                            row2["amt"] = int.Parse(row2["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow1 = rq_cc1.NewRow();
                            aRow1["comp"] = row["comp"].ToString();
                            aRow1["compname"] = row["compname"].ToString();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["di"] = row["di"].ToString().Trim();
                            aRow1["sex"] = row["sex"].ToString();
                            aRow1["amt"] = int.Parse(Row["amt"].ToString());
                            rq_cc1.Rows.Add(aRow1);
                        }
                    }
                    DataRow row3 = rq_cc2.Rows.Find(_value);
                    if (row3 != null)
                        row3["amt"] = int.Parse(row3["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow2 = rq_cc2.NewRow();
                        aRow2["comp"] = row["comp"].ToString();
                        aRow2["compname"] = row["compname"].ToString();
                        aRow2["nobr"] = Row["nobr"].ToString();
                        aRow2["di"] = row["di"].ToString().Trim();
                        aRow2["sex"] = row["sex"].ToString();
                        aRow2["empcd"] = row["empcd"].ToString();
                        aRow2["amt"] = int.Parse(Row["amt"].ToString());
                        rq_cc2.Rows.Add(aRow2);
                    }
                }
            }
            //非經常性薪資
            DataTable rq_zz421d = new DataTable();
            rq_zz421d.Columns.Add("comp", typeof(string));
            rq_zz421d.Columns.Add("compname", typeof(string));
            rq_zz421d.Columns.Add("di", typeof(string));
            rq_zz421d.Columns.Add("sex", typeof(string));
            rq_zz421d.Columns.Add("amt", typeof(int));
            rq_zz421d.Columns.Add("cnt", typeof(int));
            DataColumn[] _key3 = new DataColumn[3];
            _key3[0] = rq_zz421d.Columns["comp"];
            _key3[1] = rq_zz421d.Columns["di"];
            _key3[2] = rq_zz421d.Columns["sex"];
            rq_zz421d.PrimaryKey = _key3;

            DataTable rq_zz421d1 = new DataTable();
            rq_zz421d1 = rq_zz421d.Clone();
            rq_zz421d1.TableName = "rq_zz421d1";
            foreach (DataRow Row in rq_cc1.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["di"].ToString();
                _value[2] = Row["sex"].ToString();
                DataRow row = rq_zz421d.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                }
                else
                {
                    DataRow aRow = rq_zz421d.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["sex"] = Row["sex"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    aRow["cnt"] = 1;
                    rq_zz421d.Rows.Add(aRow);
                }
            }

            //經常性薪資
            foreach (DataRow Row in rq_cc.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["di"].ToString();
                _value[2] = Row["sex"].ToString();
                DataRow row = rq_zz421d1.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                }
                else
                {
                    DataRow aRow = rq_zz421d1.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["sex"] = Row["sex"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    aRow["cnt"] = 1;
                    rq_zz421d1.Rows.Add(aRow);
                }
            }

            //經常員工
            DataTable rq_zz421da = new DataTable();
            rq_zz421da.Columns.Add("comp", typeof(string));
            rq_zz421da.Columns.Add("compname", typeof(string));
            rq_zz421da.Columns.Add("di", typeof(string));
            rq_zz421da.Columns.Add("sex", typeof(string));
            rq_zz421da.Columns.Add("cnt", typeof(int));
            DataColumn[] _key4 = new DataColumn[3];
            _key4[0] = rq_zz421da.Columns["comp"];
            _key4[1] = rq_zz421da.Columns["di"];
            _key4[2] = rq_zz421da.Columns["sex"];
            rq_zz421da.PrimaryKey = _key4;
            //臨時員工
            DataTable rq_zz421db = new DataTable();
            rq_zz421db = rq_zz421da.Clone();
            rq_zz421db.TableName = "rq_zz421db";
            foreach (DataRow Row in rq_cc2.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["di"].ToString().Trim();
                _value[2] = Row["sex"].ToString();
                if (Row["empcd"].ToString().Trim() == Temporary_Empcd)
                {
                    DataRow row = rq_zz421db.Rows.Find(_value);
                    if (row != null)
                    {
                        row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = rq_zz421db.NewRow();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["di"] = Row["di"].ToString().Trim();
                        aRow["sex"] = Row["sex"].ToString();
                        aRow["cnt"] = 1;
                        rq_zz421db.Rows.Add(aRow);
                    }
                }
                else
                {
                    DataRow row = rq_zz421da.Rows.Find(_value);
                    if (row != null)
                    {
                        row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = rq_zz421da.NewRow();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["di"] = Row["di"].ToString().Trim();
                        aRow["sex"] = Row["sex"].ToString();
                        aRow["cnt"] = 1;
                        rq_zz421da.Rows.Add(aRow);
                    }
                }
            }

            rq_cc2.PrimaryKey = new DataColumn[] { rq_cc2.Columns["nobr"] };
            foreach (DataRow Row in rq_attned.Rows)
            {
                DataRow row = rq_cc2.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    object[] _vlaue = new object[3];
                    _vlaue[0] = row["comp"].ToString();
                    _vlaue[1] = row["di"].ToString().Trim();
                    _vlaue[2] = row["sex"].ToString();
                    DataRow row1 = rq_attends.Rows.Find(_vlaue);
                    if (row1 != null)
                    {
                        row1["wk_hrs"] = decimal.Parse(row1["wk_hrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                        row1["count"] = int.Parse(row1["count"].ToString()) + 1;
                    }

                    else
                    {
                        DataRow aRow = rq_attends.NewRow();
                        aRow["comp"] = row["comp"].ToString();
                        aRow["di"] = row["di"].ToString().Trim();
                        aRow["sex"] = row["sex"].ToString();
                        aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                        aRow["count"] = 1;
                        rq_attends.Rows.Add(aRow);
                    }
                }
            }

            foreach (DataRow Row in rq_ot.Rows)
            {
                DataRow row = rq_cc2.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    object[] _value1 = new object[3];
                    _value1[0] = row["comp"].ToString();
                    _value1[1] = row["di"].ToString().Trim();
                    _value1[2] = row["sex"].ToString();
                    DataRow row1 = rq_ots.Rows.Find(_value1);
                    if (row1 != null)
                    {
                        row1["ot_hrs"] = decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                        row1["rest_hrs"] = decimal.Parse(row1["rest_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_ots.NewRow();
                        aRow["comp"] = row["comp"].ToString();
                        aRow["di"] = row["di"].ToString().Trim();
                        aRow["sex"] = row["sex"].ToString();
                        aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                        aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                        rq_ots.Rows.Add(aRow);
                    }
                }
            }

            rq_cc = null;

            rq_cc1 = null;
            rq_cc2 = null;
            string _dateb = ""; string _datee = "";
            _dateb = JBHR.Reports.ReportClass.GetSalBDate(year, month);
            _datee = JBHR.Reports.ReportClass.GetSalEDate(year, month);
            //if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
            //{
            //    _dateb = DateTime.Parse(Convert.ToString(int.Parse(year) + 1911) + "/" + month + "/01").ToString("yyyy/MM/dd");
            //    _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}
            //else
            //{
            //    _dateb = DateTime.Parse(year + "/" + month + "/01").ToString("yyyy/MM/dd");
            //    _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}

            DataTable rq_zz421df1 = new DataTable();
            rq_zz421df1.Columns.Add("comp", typeof(string));
            rq_zz421df1.Columns.Add("cnt", typeof(int));
            rq_zz421df1.PrimaryKey = new DataColumn[] { rq_zz421df1.Columns["comp"] };
            DataTable rq_zz421df2 = new DataTable();
            rq_zz421df2 = rq_zz421df1.Clone();
            rq_zz421df2.TableName = "rq_zz421df2";
            DataTable rq_zz421df3 = new DataTable();
            rq_zz421df3 = rq_zz421df1.Clone();
            rq_zz421df3.TableName = "rq_zz421df3";
            DataTable rq_zz421df4 = new DataTable();
            rq_zz421df4 = rq_zz421df1.Clone();
            rq_zz421df4.TableName = "rq_zz421df4";
            //新進
            DataRow[] zz421df_row = DT_base.Select("indt >='" + _dateb + "' and indt <='" + _datee + "'");
            foreach (DataRow Row in zz421df_row)
            {
                DataRow row = rq_zz421df1.Rows.Find(Row["comp"].ToString());
                if (row != null)
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                else
                {
                    DataRow aRow = rq_zz421df1.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["cnt"] = 1;
                    rq_zz421df1.Rows.Add(aRow);
                }
            }

            DataRow[] zz421df1_row = DT_base.Select("adate >='" + _dateb + "' and adate <='" + _datee + "'");
            foreach (DataRow Row in zz421df1_row)
            {
                if (Row["ttscode"].ToString().Trim() == "4")
                {
                    DataRow row1 = rq_zz421df2.Rows.Find(Row["comp"].ToString());
                    if (row1 != null)
                        row1["cnt"] = int.Parse(row1["cnt"].ToString()) + 1;
                    else
                    {
                        DataRow aRow1 = rq_zz421df2.NewRow();
                        aRow1["comp"] = Row["comp"].ToString();
                        aRow1["cnt"] = 1;
                        rq_zz421df2.Rows.Add(aRow1);
                    }
                }

                if (Row["ttscode"].ToString().Trim() == "5")
                {
                    DataRow row3 = rq_zz421df4.Rows.Find(Row["comp"].ToString());
                    if (row3 != null)
                        row3["cnt"] = int.Parse(row3["cnt"].ToString()) + 1;
                    else
                    {
                        DataRow aRow3 = rq_zz421df4.NewRow();
                        aRow3["comp"] = Row["comp"].ToString();
                        aRow3["cnt"] = 1;
                        rq_zz421df4.Rows.Add(aRow3);
                    }
                }
            }

            //本月離職人員
            _datee = DateTime.Parse(_datee).AddDays(1).ToString("yyyy/MM/dd");
            DataRow[] zz421df2_row = DT_base.Select("adate >='" + _dateb + "' and adate <='" + _datee + "' and ttscode='2'");
            foreach (DataRow Row in zz421df2_row)
            {
                DataRow row2 = rq_zz421df3.Rows.Find(Row["comp"].ToString());
                if (row2 != null)
                    row2["cnt"] = int.Parse(row2["cnt"].ToString()) + 1;
                else
                {
                    DataRow aRow2 = rq_zz421df3.NewRow();
                    aRow2["comp"] = Row["comp"].ToString();
                    aRow2["cnt"] = 1;
                    rq_zz421df3.Rows.Add(aRow2);
                }
            }

            foreach (DataRow Row in rq_zz421d.Rows)
            {
                string _di = ""; string _sex = "";
                if (Row["di"].ToString().Trim() == "I")
                    _di = "間接 ";
                if (Row["di"].ToString().Trim() == "D")
                    _di = "直接 ";
                if (Row["sex"].ToString().Trim() == "M")
                    _sex = "男";
                if (Row["sex"].ToString().Trim() == "F")
                    _sex = "女";
                object[] _value = new object[3];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["di"].ToString();
                _value[2] = Row["sex"].ToString();
                DataRow row = rq_zz421da.Rows.Find(_value);
                DataRow row1 = rq_zz421db.Rows.Find(_value);
                DataRow row2 = rq_attends.Rows.Find(_value);
                DataRow row3 = rq_ots.Rows.Find(_value);
                DataRow row4 = rq_wageots.Rows.Find(_value);
                DataRow row5 = rq_zz421d1.Rows.Find(_value);
                DataRow row6 = rq_zz421df1.Rows.Find(Row["comp"].ToString());
                DataRow row7 = rq_zz421df2.Rows.Find(Row["comp"].ToString());
                DataRow row8 = rq_zz421df3.Rows.Find(Row["comp"].ToString());
                DataRow row9 = rq_zz421df4.Rows.Find(Row["comp"].ToString());

                DataRow aRow = DT_zz421d.NewRow();
                aRow["comp"] = Row["comp"].ToString();
                aRow["compname"] = Row["compname"].ToString();
                aRow["item"] = _di + _sex;
                aRow["cnt"] = int.Parse(Row["cnt"].ToString());
                aRow["amt"] = int.Parse(Row["amt"].ToString());
                aRow["cnt1"] = (row != null) ? int.Parse(row["cnt"].ToString()) : 0;
                aRow["cnt2"] = (row1 != null) ? int.Parse(row1["cnt"].ToString()) : 0;
                aRow["wk_hrs"] = (row2 != null) ? decimal.Parse(row2["wk_hrs"].ToString()) : 0;
                aRow["ot_hrs"] = (row3 != null) ? decimal.Parse(row3["ot_hrs"].ToString()) : 0;
                aRow["rest_hrs"] = (row3 != null) ? decimal.Parse(row3["rest_hrs"].ToString()) : 0;
                aRow["otamt"] = (row4 != null) ? int.Parse(row4["amt"].ToString()) : 0;
                aRow["otheramt"] = (row5 != null) ? int.Parse(row5["amt"].ToString()) : 0;
                aRow["new_cnt"] = (row6 != null) ? int.Parse(row6["cnt"].ToString()) : 0;
                aRow["recall_cnt"] = (row7 != null) ? int.Parse(row7["cnt"].ToString()) : 0;
                aRow["out_cnt"] = (row8 != null) ? int.Parse(row8["cnt"].ToString()) : 0;
                aRow["other_cnt"] = (row9 != null) ? int.Parse(row9["cnt"].ToString()) : 0;
                DT_zz421d.Rows.Add(aRow);
            }
            rq_zz421da = null;
            rq_zz421db = null;
            rq_attends = null;
            rq_ots = null;
            rq_wageots = null;
            rq_zz421d1 = null;
            rq_zz421df1 = null;
            rq_zz421df2 = null;
            rq_zz421df3 = null;
            rq_zz421df4 = null;
            rq_base1 = null;
        }

        public static void ExPort1(DataTable DT_42td, DataTable DT_42ta, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            //ExporDt.Columns.Add("英文姓名", typeof(string));
            //ExporDt.Columns.Add("職等名稱", typeof(string));
            //ExporDt.Columns.Add("職級名稱", typeof(string));
            //ExporDt.Columns.Add("年資", typeof(string));
            ExporDt.Columns.Add("雇主勞保負擔", typeof(int));
            ExporDt.Columns.Add("雇主健保負擔", typeof(int));
            ExporDt.Columns.Add("雇主勞退負擔", typeof(int));
            //ExporDt.Columns.Add("稅率", typeof(decimal));
            //ExporDt.Columns.Add("居留起始", typeof(string));
            //ExporDt.Columns.Add("居留到期", typeof(string));
            //ExporDt.Columns.Add("滿183天", typeof(string));
            //ExporDt.Columns.Add("類別", typeof(string));
            //ExporDt.Columns.Add("退休金制度", typeof(string));
            //ExporDt.Columns.Add("到職日", typeof(DateTime));
            //ExporDt.Columns.Add("加入新制日期", typeof(DateTime));
            //ExporDt.Columns.Add("開始提撥日", typeof(DateTime));
            //ExporDt.Columns.Add("郵件", typeof(string));
            //ExporDt.Columns.Add("備註", typeof(string));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }


            foreach (DataRow Row01 in DT_42td.Rows)
            {
                string AAD = Row01["nobr"].ToString();
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                //aRow["英文姓名"] = Row01["name_e"].ToString();
                //aRow["職等名稱"] = Row01["jobl_name"].ToString();
                //aRow["職級名稱"] = Row01["jobo_name"].ToString();
                //aRow["年資"] = decimal.Parse(Row01["wk_yrs"].ToString()).ToYearMonthString();
                aRow["雇主勞保負擔"] = int.Parse(Row01["comp_lamt"].ToString());
                aRow["雇主健保負擔"] = int.Parse(Row01["comp_hamt"].ToString());
                aRow["雇主勞退負擔"] = int.Parse(Row01["comp_ramt"].ToString());
                //aRow["到職日"] = DateTime.Parse(Row01["indt"].ToString());
                //aRow["稅率"] = decimal.Parse(Row01["taxrate"].ToString());
                //if (!Row01.IsNull("tax_date")) aRow["居留起始"] = DateTime.Parse(Row01["tax_date"].ToString());
                //if (!Row01.IsNull("tax_edate")) aRow["居留到期"] = DateTime.Parse(Row01["tax_edate"].ToString());
                //aRow["滿183天"] = Row01["stay183"].ToString();
                //if (Convert.ToInt32(DateTime.Parse(Row01["indt"].ToString()).ToString("yyyyMMdd")) >= 20050701)
                //    aRow["類別"] = "3";
                //else
                //    aRow["類別"] = "2";
                //if (Row01["retchoo"].ToString().Trim() == "舊制")
                //    aRow["類別"] = "1";               
                //else if (Row01["retchoo"].ToString().Trim() == "暫不選擇")
                //    aRow["類別"] = "4";

                //aRow["退休金制度"] = Row01["retchoo"].ToString();
                //if (!Row01.IsNull("retdate")) aRow["加入新制日期"] = DateTime.Parse(Row01["retdate"].ToString());
                //if (!Row01.IsNull("retdate1")) aRow["開始提撥日"] = DateTime.Parse(Row01["retdate1"].ToString());
                //aRow["郵件"] = Row01["email"].ToString();
                //aRow["備註"] = Row01["note"].ToString();
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export1(ExporDt, FileName);
        }

        public static void ExPort3(DataTable DT_42td1, DataTable DT_42ta, string FileName, bool sumdi)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (sumdi)
            {
                ExporDt.Columns.Add("類別", typeof(string));
                ExporDt.Columns.Add("人數", typeof(int));
            }
            ExporDt.Columns.Add("雇主勞保負擔", typeof(int));
            ExporDt.Columns.Add("雇主健保負擔", typeof(int));
            ExporDt.Columns.Add("雇主勞退負擔", typeof(int));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_42td1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                if (sumdi)
                {
                    aRow["類別"] = Row01["diname"].ToString();
                    aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                }
                aRow["雇主勞保負擔"] = int.Parse(Row01["comp_lamt"].ToString());
                aRow["雇主健保負擔"] = int.Parse(Row01["comp_hamt"].ToString());
                aRow["雇主勞退負擔"] = int.Parse(Row01["comp_ramt"].ToString());
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort5(DataTable DT1, string FileName, string date_t)
        {
            DataTable ExporDt = new DataTable();
            //ExporDt.Columns.Add("銀行名稱", typeof(string));
            //ExporDt.Columns.Add("轉帳", typeof(string));
            //ExporDt.Columns.Add("轉帳日期", typeof(string));
            //ExporDt.Columns.Add("統一編號", typeof(string));
            ExporDt.Columns.Add("編號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("身份證號", typeof(string));
            ExporDt.Columns.Add("轉帳帳號", typeof(string));
            ExporDt.Columns.Add("轉帳金額", typeof(int));

            DataRow[] SRow = DT1.Select("", "bankname,comp,nobr asc");
            int _i = 1;
            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow = ExporDt.NewRow();
                //aRow["銀行名稱"] = Row01["bankname"].ToString();
                //aRow["轉帳"] = Row01["type"].ToString();
                //aRow["轉帳日期"] = date_t;
                //aRow["統一編號"] = Row01["compid"].ToString();
                aRow["編號"] = _i;
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["身份證號"] = Row01["idno"].ToString();
                aRow["轉帳帳號"] = Row01["account_no"].ToString();
                aRow["轉帳金額"] = int.Parse(Row01["tt"].ToString());
                ExporDt.Rows.Add(aRow);
                _i += 1;
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        /// <summary>
        /// 清展專用 - 轉賬明細表
        /// </summary>
        /// <param name="DT1"></param>
        /// <param name="FileName"></param>
        /// <param name="date_t"></param>
        public static void ExPort_HISS(DataTable DT1, string FileName, string date_t, DataTable DT_Base)
        {
            DataTable ExporDt = new DataTable();
            //ExporDt.Columns.Add("銀行名稱", typeof(string));
            //ExporDt.Columns.Add("轉帳", typeof(string));
            //ExporDt.Columns.Add("轉帳日期", typeof(string));
            //ExporDt.Columns.Add("統一編號", typeof(string));
            ExporDt.Columns.Add("序號", typeof(string));
            ExporDt.Columns.Add("匯款日", typeof(string));
            ExporDt.Columns.Add("客戶代號", typeof(string));
            ExporDt.Columns.Add("客戶名稱", typeof(string));
            ExporDt.Columns.Add("轉帳金額", typeof(int));
            ExporDt.Columns.Add("備註", typeof(string));
            ExporDt.Columns.Add("收款人名稱", typeof(string));
            ExporDt.Columns.Add("收款人銀行名稱", typeof(string));
            ExporDt.Columns.Add("收款人銀行代碼", typeof(string));
            ExporDt.Columns.Add("收款人帳號", typeof(string));
            ExporDt.Columns.Add("收款人統編/身份證號", typeof(string));
            ExporDt.Columns.Add("收款人傳真", typeof(string));
            ExporDt.Columns.Add("收款人EMail", typeof(string));
            ExporDt.Columns.Add("DEPT_SORT", typeof(string));
            ExporDt.Columns.Add("NOBR_SORT", typeof(string));

            DataRow[] SRow = DT1.Select("", "bankname,comp,nobr asc");
            int _i = 1;
            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow = ExporDt.NewRow();
                DataRow row_base = DT_Base.Rows.Find(Row01["nobr"].ToString());
                //aRow["銀行名稱"] = Row01["bankname"].ToString();
                //aRow["轉帳"] = Row01["type"].ToString();
                //aRow["轉帳日期"] = date_t;
                //aRow["統一編號"] = Row01["compid"].ToString();
                aRow["序號"] = _i;
                aRow["匯款日"] = AD_Year_To_TW_Year(Row01["ADATE"].ToString().Trim());
                aRow["客戶代號"] = Row01["nobr"].ToString();
                aRow["客戶名稱"] = Row01["name_c"].ToString();
                aRow["轉帳金額"] = int.Parse(Row01["tt"].ToString());
                aRow["備註"] = Row01["NOTE"].ToString();
                aRow["收款人名稱"] = Row01["name_c"].ToString();
                aRow["收款人銀行名稱"] = Row01["bankname"].ToString();
                aRow["收款人銀行代碼"] = Row01["bankno"].ToString();
                aRow["收款人帳號"] = Row01["account_no"].ToString();
                aRow["收款人統編/身份證號"] = Row01["idno"].ToString();
                aRow["收款人傳真"] = Row01["FAX"].ToString();
                aRow["收款人EMail"] = Row01["EMAIL"].ToString();
                aRow["DEPT_SORT"] = row_base["dept"].ToString();
                aRow["NOBR_SORT"] = Row01["nobr"].ToString();

                ExporDt.Rows.Add(aRow);
                _i += 1;
            }

            DataView resortDT = ExporDt.DefaultView;
            resortDT.Sort = "DEPT_SORT, NOBR_SORT";
            DataTable Final_ExportDt = resortDT.ToTable();

            Final_ExportDt.Columns.Remove("DEPT_SORT");
            Final_ExportDt.Columns.Remove("NOBR_SORT");

            int seq = 1;
            foreach (DataRow resort_seq in Final_ExportDt.Rows)
            {
                resort_seq["序號"] = seq;
                seq += 1;
            }
            Final_ExportDt.AcceptChanges();

            JBHR.Reports.ReportClass.Export(Final_ExportDt, FileName);
        }

        /// <summary>
        /// 日期西元年份轉成民國年份
        /// Added By Daniel Chih - 2021/04/28
        /// </summary>
        /// <param name="AD_Date"></param>
        /// <returns></returns>
        public static string AD_Year_To_TW_Year(string AD_Date)
        {
            //取得西元年份
            DateTime AD_Year_Date = DateTime.Parse(AD_Date);
            //轉換年份計算，並轉換日期格式
            string TW_Year_Date = AD_Year_Date.AddYears(-1911).ToString("yyy/MM/dd");
            //回傳民國年份
            return TW_Year_Date;
        }

        public static void ExPort6(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("金額", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["金額"] = int.Parse(Row01["tt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort8(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("直接", typeof(int));
            ExporDt.Columns.Add("間接", typeof(int));
            ExporDt.Columns.Add("研發", typeof(int));
            ExporDt.Columns.Add("總計", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["直接"] = int.Parse(Row01["dd"].ToString());
                aRow["間接"] = int.Parse(Row01["di"].ToString());
                aRow["研發"] = int.Parse(Row01["ds"].ToString());
                aRow["總計"] = int.Parse(Row01["all"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort10(DataTable DT_4215t, DataTable DT_42ta, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("類別代碼", typeof(string));
            ExporDt.Columns.Add("類別名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4215t.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["類別代碼"] = Row01["code"].ToString();
                aRow["類別名稱"] = Row01["code_name"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort11(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("薪資區隔", typeof(string));
            ExporDt.Columns.Add("<=43,900", typeof(int));
            ExporDt.Columns.Add("43,901-100,000", typeof(int));
            ExporDt.Columns.Add("100,001-110,000", typeof(int));
            ExporDt.Columns.Add("110,001-140,000", typeof(int));
            ExporDt.Columns.Add("140,000-170,000", typeof(int));
            ExporDt.Columns.Add("170,001-230,000", typeof(int));
            ExporDt.Columns.Add("230,000-500,000", typeof(int));
            ExporDt.Columns.Add("500,001-1000,000", typeof(int));
            ExporDt.Columns.Add(">1000,000", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["薪資區隔"] = "薪資總額";
                aRow["<=43,900"] = int.Parse(Row01["a"].ToString());
                aRow["43,901-100,000"] = int.Parse(Row01["b"].ToString());
                aRow["100,001-110,000"] = int.Parse(Row01["c"].ToString());
                aRow["110,001-140,000"] = int.Parse(Row01["d"].ToString());
                aRow["140,000-170,000"] = int.Parse(Row01["e"].ToString());
                aRow["170,001-230,000"] = int.Parse(Row01["f"].ToString());
                aRow["230,000-500,000"] = int.Parse(Row01["g"].ToString());
                aRow["500,001-1000,000"] = int.Parse(Row01["h"].ToString());
                aRow[">1000,000"] = int.Parse(Row01["i"].ToString());
                ExporDt.Rows.Add(aRow);
                DataRow aRow1 = ExporDt.NewRow();
                aRow1["薪資區隔"] = "人數";
                aRow1["<=43,900"] = int.Parse(Row01["a_cnt"].ToString());
                aRow1["43,901-100,000"] = int.Parse(Row01["b_cnt"].ToString());
                aRow1["100,001-110,000"] = int.Parse(Row01["c_cnt"].ToString());
                aRow1["110,001-140,000"] = int.Parse(Row01["d_cnt"].ToString());
                aRow1["140,000-170,000"] = int.Parse(Row01["e_cnt"].ToString());
                aRow1["170,001-230,000"] = int.Parse(Row01["f_cnt"].ToString());
                aRow1["230,000-500,000"] = int.Parse(Row01["g_cnt"].ToString());
                aRow1["500,001-1000,000"] = int.Parse(Row01["h_cnt"].ToString());
                aRow1[">1000,000"] = int.Parse(Row01["i_cnt"].ToString());
                ExporDt.Rows.Add(aRow1);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort12(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("薪資", typeof(int));
            ExporDt.Columns.Add("提撥金額", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["薪資"] = int.Parse(Row01["amt"].ToString());
                aRow["提撥金額"] = int.Parse(Row01["retiretamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort13(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司名稱", typeof(string));
            ExporDt.Columns.Add("項目", typeof(string));
            ExporDt.Columns.Add("總人數", typeof(int));
            ExporDt.Columns.Add("經常人數", typeof(int));
            ExporDt.Columns.Add("臨時人數", typeof(int));
            ExporDt.Columns.Add("正常工時", typeof(int));
            ExporDt.Columns.Add("加班工時", typeof(int));
            ExporDt.Columns.Add("補休工時", typeof(int));
            ExporDt.Columns.Add("經常性薪資", typeof(int));
            ExporDt.Columns.Add("加班費", typeof(int));
            ExporDt.Columns.Add("其他", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司名稱"] = Row01["compname"].ToString();
                aRow["項目"] = Row01["item"].ToString();
                aRow["總人數"] = int.Parse(Row01["cnt"].ToString());
                aRow["經常人數"] = int.Parse(Row01["cnt1"].ToString());
                aRow["臨時人數"] = int.Parse(Row01["cnt2"].ToString());
                aRow["正常工時"] = decimal.Parse(Row01["wk_hrs"].ToString());
                aRow["加班工時"] = decimal.Parse(Row01["ot_hrs"].ToString());
                aRow["補休工時"] = decimal.Parse(Row01["rest_hrs"].ToString());
                aRow["經常性薪資"] = int.Parse(Row01["amt"].ToString());
                aRow["加班費"] = int.Parse(Row01["otamt"].ToString());
                aRow["其他"] = int.Parse(Row01["otheramt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort14(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("項目", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("經常性薪資", typeof(int));
            ExporDt.Columns.Add("加班費", typeof(int));

            foreach (DataRow Row01 in DT1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["項目"] = Row01["job"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                aRow["經常性薪資"] = int.Parse(Row01["amt"].ToString());
                aRow["加班費"] = int.Parse(Row01["otamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort15(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("應扣稅額", typeof(int));
            ExporDt.Columns.Add("免課薪資", typeof(int));
            ExporDt.Columns.Add("免課稅額", typeof(int));
            ExporDt.Columns.Add("合計", typeof(int));

            DataRow[] Orow = DT1.Select("", "dept,nobr asc");
            foreach (DataRow Row01 in Orow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["應稅薪資"] = decimal.Round(decimal.Parse(Row01["amt"].ToString()), 0);
                aRow["應扣稅額"] = decimal.Round(decimal.Parse(Row01["taxamt"].ToString()), 0);
                aRow["免課薪資"] = decimal.Round(decimal.Parse(Row01["amt1"].ToString()), 0);
                aRow["免課薪資"] = decimal.Round(decimal.Parse(Row01["notaxamt"].ToString()), 0);
                aRow["合計"] = decimal.Round(decimal.Parse(Row01["tolamt"].ToString()), 0);
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort16(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("職等", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("勞保費用", typeof(int));
            ExporDt.Columns.Add("健保費用", typeof(int));
            ExporDt.Columns.Add("團保費用", typeof(int));
            ExporDt.Columns.Add("退休金", typeof(int));
            ExporDt.Columns.Add("福利金", typeof(int));
            ExporDt.Columns.Add("伙食費", typeof(int));
            ExporDt.Columns.Add("合計", typeof(int));

            DataRow[] Orow = DT1.Select("", "comp,dept,jobl_name asc");
            foreach (DataRow Row01 in Orow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["職等"] = Row01["jobl_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["勞保費用"] = int.Parse(Row01["lab_amt"].ToString());
                aRow["健保費用"] = int.Parse(Row01["hel_amt"].ToString());
                aRow["團保費用"] = int.Parse(Row01["grp_amt"].ToString());
                aRow["退休金"] = int.Parse(Row01["ret_amt"].ToString());
                aRow["福利金"] = int.Parse(Row01["wel_amt"].ToString());
                aRow["伙食費"] = int.Parse(Row01["eat_amt"].ToString());
                aRow["合計"] = int.Parse(Row01["tol_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
        public static void ExPort17(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員別", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("應扣稅額", typeof(int));
            ExporDt.Columns.Add("免課薪資", typeof(int));
            ExporDt.Columns.Add("免課稅額", typeof(int));
            ExporDt.Columns.Add("合計", typeof(int));

            DataRow[] Orow = DT1.Select("", "count_ma,nobr asc");
            foreach (DataRow Row01 in Orow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員別"] = (bool.Parse(Row01["count_ma"].ToString())) ? "外籍勞工" : "本國員工";
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["應稅薪資"] = decimal.Round(decimal.Parse(Row01["amt"].ToString()), 0);
                aRow["應扣稅額"] = decimal.Round(decimal.Parse(Row01["taxamt"].ToString()), 0);
                aRow["免課薪資"] = decimal.Round(decimal.Parse(Row01["amt1"].ToString()), 0);
                aRow["免課薪資"] = decimal.Round(decimal.Parse(Row01["notaxamt"].ToString()), 0);
                aRow["合計"] = decimal.Round(decimal.Parse(Row01["tolamt"].ToString()), 0);
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
        public static void ExPort19(DataTable DT1, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司別", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            ExporDt.Columns.Add("勞保費用", typeof(int));
            ExporDt.Columns.Add("健保費用", typeof(int));
            ExporDt.Columns.Add("團保費用", typeof(int));
            ExporDt.Columns.Add("退休金", typeof(int));
            ExporDt.Columns.Add("福利金", typeof(int));
            ExporDt.Columns.Add("伙食費", typeof(int));
            ExporDt.Columns.Add("合計", typeof(int));
            DataRow[] Orow = DT1.Select("", "comp asc");
            foreach (DataRow Row01 in Orow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司別"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();
                aRow["勞保費用"] = int.Parse(Row01["lab_amt"].ToString());
                aRow["健保費用"] = int.Parse(Row01["hel_amt"].ToString());
                aRow["團保費用"] = int.Parse(Row01["grp_amt"].ToString());
                aRow["退休金"] = int.Parse(Row01["ret_amt"].ToString());
                aRow["福利金"] = int.Parse(Row01["wel_amt"].ToString());
                aRow["伙食費"] = int.Parse(Row01["eat_amt"].ToString());
                aRow["合計"] = int.Parse(Row01["tol_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static DataTable GetTolHours(string attdate_e, string type
            , string nobr_b, string nobr_e
            , string empcd_b, string empcd_e
            , string dept_b, string dept_e
            , string depts_b, string depts_e
            , string comp_b, string comp_e
            , string user, string comp, bool isadmin
            )
        {
            var dbHR = new HrDBDataContext();

            var GetTable = (from a in dbHR.ABS
                                //inner join
                            join b in dbHR.BASETTS on a.NOBR equals b.NOBR

                            join c in dbHR.HCODE on a.H_CODE equals c.H_CODE

                            join d in dbHR.DEPT on b.DEPT equals d.D_NO

                            join ds in dbHR.DEPTS on b.DEPTS equals ds.D_NO

                            let CheckTakens = (from aa in dbHR.ABSD
                                               join bb in dbHR.ABS on aa.ABSSUBTRACT equals bb.Guid
                                               where 1 == 1
                                               && aa.ABSADD == a.Guid
                                               && (DateTime.Compare(bb.BDATE, DateTime.Parse(attdate_e)) <= 0)
                                               select new { USEHOUR = aa.USEHOUR }
                            )
                            where 1 == 1
                            &&
                            //員編起迄
                            (string.Compare(a.NOBR, nobr_b) >= 0) && (string.Compare(a.NOBR, nobr_e) <= 0)
                            &&
                            //員別起迄
                            (string.Compare(b.EMPCD, empcd_b) >= 0) && (string.Compare(b.EMPCD, empcd_e) <= 0)
                            &&
                            //編制部門起迄
                            (string.Compare(d.D_NO_DISP, dept_b) >= 0) && (string.Compare(d.D_NO_DISP, dept_e) <= 0)
                            &&
                            //成本部門起迄
                            (string.Compare(ds.D_NO_DISP, depts_b) >= 0) && (string.Compare(ds.D_NO_DISP, depts_e) <= 0)
                            &&
                            //假別種類
                            c.HTYPE == type
                            &&
                            //正負
                            c.FLAG == "+"
                            &&
                            //公司別
                            (string.Compare(b.COMP, comp_b) >= 0) && (string.Compare(b.COMP, comp_e) <= 0)
                            &&
                            //起迄日期
                            (DateTime.Compare(DateTime.Parse(attdate_e), a.BDATE) >= 0) && (DateTime.Compare(DateTime.Parse(attdate_e), a.EDATE) <= 0)
                            &&
                            //權限
                            (from p in dbHR.UserReadDataGroupList(user, comp, isadmin) select p.DATAGROUP).Contains(b.SALADR)
                            &&
                            //異動截止日
                            (DateTime.Compare(DateTime.Parse(attdate_e), b.ADATE) >= 0) && (DateTime.Compare(DateTime.Parse(attdate_e), b.DDATE.Value) <= 0)

                            //&&
                            select new
                            {
                                //員工編號
                                a.NOBR,
                                //得假
                                a.TOL_HOURS,
                                //已請
                                a.LeaveHours,
                                //剩餘
                                a.Balance,
                                //GUID
                                a.Guid,
                                //排除後已請
                                CHECK_HOURS = CheckTakens.Any() ?
                                    CheckTakens.Select(s => s.USEHOUR).Sum(s => s) : 0
                            });

            //Group
            var GroupData = GetTable
                        .GroupBy(g => g.NOBR)
                        .Select(s => new
                        {
                                //員工編號
                                NOBR = s.Key,
                                //得假
                                TOL_HOURS = s.Sum(g => g.TOL_HOURS),
                                //已請
                                LeaveHours = s.Sum(g => g.LeaveHours),
                                //剩餘
                                Balance = s.Sum(g => g.Balance),
                                //排除後已請
                                CheckHours = s.Sum(g => g.CHECK_HOURS),
                                //排除後剩餘
                                Check_Balance = s.Sum(g => g.TOL_HOURS) - s.Sum(g => g.CHECK_HOURS),
                        }).ToList();


            return GroupData.CopyToDataTable();
        }
    }
}
