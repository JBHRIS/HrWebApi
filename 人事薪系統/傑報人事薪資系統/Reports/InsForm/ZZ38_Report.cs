/* ======================================================================================================
 * 功能名稱：勞健團保勞退代扣
 * 功能代號：ZZ38
 * 功能路徑：報表列印 > 保險 > 勞健團保勞退代扣
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\InsForm\ZZ38_Report.cs
 * 功能用途：
 *  用於產出勞健團保勞退代扣資料
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/12    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：只列印有發薪者
 *                                             2. 新增條件欄位：只列印無發薪者
 *                                             3. 重新調整視窗畫面與控制項位置
 * 2021/01/20    Daniel Chih    Ver 1.0.02     1. 修改：勾選【只列印無發薪者資料】時撈不出資料的問題
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/01/12
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.InsForm
{
    public partial class ZZ38_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, depts_b, depts_e, date_b, date_e, yy_b, yy_e, seq_b, seq_e, sno_b, sno_e,emp_b,emp_e, reporttype, typedata, comp_name, CompId;
        bool checkbox_print_with_salary_only, checkbox_print_without_salary_only, exportexcel;
        public ZZ38_Report(string nobrb, string nobre, string deptsb, string deptse, string dateb, string datee, string yyb, string yye
            , string seqb, string seqe, string snob, string snoe, string empb, string empe, string _reporttype, string _typedata
            , bool _checkbox_print_with_salary_only, bool _checkbox_print_without_salary_only, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb; depts_e = deptse; yy_b = yyb; yy_e = yye;
            seq_b = seqb; seq_e = seqe; sno_b = snob; sno_e = snoe; reporttype = _reporttype;
            checkbox_print_with_salary_only = _checkbox_print_with_salary_only; checkbox_print_without_salary_only = _checkbox_print_without_salary_only;
             exportexcel = _exportexcel; typedata = _typedata; date_b = dateb; date_e = datee;
            comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
        }

        private void ZZ38_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as depts,c.d_name as ds_name,b.di,a.idno";
                sqlCmd += ",d.d_no_disp as dept,d.d_name,b.indt";

                sqlCmd += " from base a inner join basetts b on a.nobr=b.nobr ";

                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);

                //只列印有發薪者
                if (checkbox_print_with_salary_only)
                {
                    sqlCmd += string.Format(@" INNER JOIN WAGE E ON B.NOBR = E.NOBR AND E.YYMM BETWEEN '{0}' AND '{1}' AND E.SEQ BETWEEN '{2}' AND '{3}' ", yy_b, yy_e, seq_b, seq_e);
                }
                //只列印無發薪者
                if (checkbox_print_without_salary_only)
                {
                    sqlCmd += " INNER JOIN EXPLAB F ON B.NOBR = F.NOBR ";
                    sqlCmd += string.Format(@" AND F.NOBR NOT IN(SELECT NOBR FROM WAGE WHERE YYMM BETWEEN '{0}' AND '{1}' AND SEQ BETWEEN '{2}' AND '{3}') ", yy_b, yy_e, seq_b, seq_e);
                }

                sqlCmd += " left outer join depts c on b.depts=c.d_no";
                sqlCmd += " left outer join dept d on b.dept=d.d_no";
                sqlCmd += " where 1=1 ";
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += typedata;
                sqlCmd += " GROUP BY B.NOBR,A.NAME_C,A.NAME_E,C.D_NO_DISP,C.D_NAME,B.DI,A.IDNO,D.D_NO_DISP,D.D_NAME,B.INDT ";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,b.s_no_disp as s_no,a.fa_idno,a.exp,a.comp, a.insur_type,a.jobamt,a.fundamt from explab a";
                sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd1 += " and a.insur_type in ('1','2','4')";
                DataTable rq_explab = SqlConn.GetDataTable(sqlCmd1);
                string sqlCmd2 = "select a.nobr,b.s_no_disp as s_no,a.fa_idno,a.exp,a.comp, a.insur_type,a.jobamt,a.fundamt from explab a";
                sqlCmd2 += " left outer join inscomp b on a.s_no=b.s_no";
                sqlCmd2 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and a.yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd2 += " and a.insur_type='3'";
                DataTable rq_explab2 = SqlConn.GetDataTable(sqlCmd2);
                rq_explab.Merge(rq_explab2);
                rq_explab.Columns.Add("indt", typeof(string));
                rq_explab.Columns.Add("name_c", typeof(string));
                rq_explab.Columns.Add("name_e", typeof(string));
                rq_explab.Columns.Add("depts", typeof(string));
                rq_explab.Columns.Add("ds_name", typeof(string));
                rq_explab.Columns.Add("dept", typeof(string));
                rq_explab.Columns.Add("d_name", typeof(string));
                rq_explab.Columns.Add("idno", typeof(string));
                rq_explab.Columns.Add("di", typeof(string));
                rq_explab.Columns.Add("h_amt", typeof(int));
                rq_explab.Columns.Add("l_amt", typeof(int));
                rq_explab.Columns.Add("r_amt", typeof(int));

                //string sqlCmd3 = "select nobr,fa_idno,h_amt,l_amt,r_amt";
                //sqlCmd3 += " from inslab where nobr+fa_idno+convert(char,in_date,112) in";
                //sqlCmd3 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                //sqlCmd3 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd3 += string.Format(@" and in_date<='{0}'", date_e);
                //sqlCmd3 += " group by nobr,fa_idno)";
                //sqlCmd3 += string.Format(@" and s_no between '{0}' and '{1}'", sno_b, sno_e);
                //sqlCmd3 += " order by nobr";
                string sqlCmd3 = "select a.nobr,a.fa_idno,a.h_amt,a.l_amt,a.r_amt";
                sqlCmd3 += " from inscomp b,inslab a";
                sqlCmd3 += " left outer join larcode c on a.lrate_code=c.rate_code";
                sqlCmd3 += " where a.s_no=b.s_no";
                sqlCmd3 += " and a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
                sqlCmd3 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab  ";
                sqlCmd3 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd3 += string.Format(@" and in_date<='{0}'", date_e);
                sqlCmd3 += " group by nobr,fa_idno)";
                sqlCmd3 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd3 += " order by a.nobr ";
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd3);
                rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"], rq_inslab.Columns["fa_idno"] };

                foreach (DataRow Row in rq_explab.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["idno"].ToString();
                    DataRow row1 = rq_inslab.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["ds_name"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["idno"] = row["idno"].ToString();
                        Row["di"] = row["di"].ToString();
                        Row["fundamt"] = (decimal.Parse(Row["fundamt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["fundamt"].ToString()));
                        Row["jobamt"] = (decimal.Parse(Row["jobamt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["jobamt"].ToString()));
                        Row["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["exp"].ToString()));
                        Row["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                        Row["h_amt"] = (row1 == null) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["h_amt"].ToString()));
                        Row["l_amt"] = (row1 == null) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["l_amt"].ToString()));
                        Row["r_amt"] = (row1 == null) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1["r_amt"].ToString()));
                    }
                    else
                        Row.Delete();
                }
                rq_explab.AcceptChanges();
                
                if (rq_explab.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                ds.Tables["zz38"].PrimaryKey = new DataColumn[] { ds.Tables["zz38"].Columns["nobr"] };
                DataRow[] SRow;
                if (reporttype == "0" || reporttype == "2")
                    SRow = rq_explab.Select("", "depts,nobr asc");
                else
                    SRow = rq_explab.Select("", "dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow row1 = ds.Tables["zz38"].Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        if (Row["insur_type"].ToString().Trim() == "1")
                        {
                            row1["l_exp"] = int.Parse(row1["l_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row1["l_exp1"] = int.Parse(row1["l_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "2")
                        {
                            row1["h_exp"] = int.Parse(row1["h_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row1["h_exp1"] = int.Parse(row1["h_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "3")
                        {
                            row1["g_exp"] = int.Parse(row1["g_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row1["g_exp1"] = int.Parse(row1["g_exp1"].ToString()) + Math.Round(decimal.Parse(Row["comp"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        else if (Row["insur_type"].ToString().Trim() == "4")
                        {
                            row1["r_exp"] = int.Parse(row1["r_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row1["r_exp1"] = int.Parse(row1["r_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        row1["fundamt"] = int.Parse(row1["fundamt"].ToString()) + int.Parse(Row["fundamt"].ToString());
                        row1["jobamt"] = int.Parse(row1["jobamt"].ToString()) + int.Parse(Row["jobamt"].ToString());
                        if (Row["fa_idno"].ToString().Trim() != "") row1["fano"] = int.Parse(row1["fano"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz38"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["ds_name"] = Row["ds_name"].ToString();
                        aRow["di"] = Row["di"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["idno"] = Row["idno"].ToString();
                        aRow["s_no"] = Row["s_no"].ToString();
                        aRow["l_exp"] = 0;
                        aRow["l_exp1"] = 0;
                        aRow["h_exp"] = 0;
                        aRow["h_exp1"] = 0;
                        aRow["g_exp"] = 0;
                        aRow["g_exp1"] = 0;
                        aRow["r_exp"] = 0;
                        aRow["r_exp1"] = 0;
                        if (Row["insur_type"].ToString().Trim() == "1")
                        {
                            aRow["l_exp"] = int.Parse(Row["exp"].ToString());
                            aRow["l_exp1"] = int.Parse(Row["comp"].ToString())- int.Parse(Row["jobamt"].ToString())- int.Parse(Row["fundamt"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "2")
                        {
                            aRow["h_exp"] = int.Parse(Row["exp"].ToString());
                            aRow["h_exp1"] = int.Parse(Row["comp"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "3")
                        {
                            aRow["g_exp"] = int.Parse(Row["exp"].ToString());
                            aRow["g_exp1"] = Math.Round(decimal.Parse(Row["comp"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        else if (Row["insur_type"].ToString().Trim() == "4")
                        {
                            aRow["r_exp"] = int.Parse(Row["exp"].ToString());
                            aRow["r_exp1"] = int.Parse(Row["comp"].ToString());
                        }
                        aRow["fundamt"] = int.Parse(Row["fundamt"].ToString());
                        aRow["jobamt"] = int.Parse(Row["jobamt"].ToString());
                        aRow["fano"] = 0;
                        aRow["h_amt"] = int.Parse(Row["h_amt"].ToString());
                        aRow["l_amt"] = int.Parse(Row["l_amt"].ToString());
                        aRow["r_amt"] = int.Parse(Row["r_amt"].ToString());
                        ds.Tables["zz38"].Rows.Add(aRow);
                    }
                }

                //年節提撥比率
                DataTable rq_sys4 = SqlConn.GetDataTable("select ljobper,ljobper1,retirerate,retirerate1 from u_sys4 where comp='" + CompId + "'");
                decimal ljobper = 0; decimal ljobper1 = 0; decimal retirerate = 0; decimal retirerate1 = 0;
                if (rq_sys4.Rows.Count > 0)
                {
                    ljobper = decimal.Parse(rq_sys4.Rows[0]["ljobper"].ToString());
                    ljobper1 = decimal.Parse(rq_sys4.Rows[0]["ljobper1"].ToString());
                    retirerate = decimal.Parse(rq_sys4.Rows[0]["retirerate"].ToString());
                    retirerate1 = decimal.Parse(rq_sys4.Rows[0]["retirerate1"].ToString());
                }

                if (reporttype == "1" || reporttype == "3")
                {                    
                    //基本薪資
                    string SqlCmd2 = "select a.nobr,a.sal_code,a.amt";
                    SqlCmd2 += "  from salbasd a, salcode b where a.sal_code=b.sal_code";
                    SqlCmd2 += string.Format(@" and '{0}' between adate and ddate", date_e);
                    SqlCmd2 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    SqlCmd2 += " and (amt<>10 or amt<> 0 and b.oldretire=1)";
                    DataTable rq_salbasda = SqlConn.GetDataTable(SqlCmd2);
                    DataTable rq_salbasd = new DataTable();
                    rq_salbasd.Columns.Add("nobr", typeof(string));
                    rq_salbasd.Columns.Add("amt", typeof(int));
                    rq_salbasd.PrimaryKey = new DataColumn[] { rq_salbasd.Columns["nobr"] };

                    foreach (DataRow Row in rq_salbasda.Rows)
                    {
                        DataRow row = rq_salbasd.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                            row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        else
                        {
                            DataRow aRow = rq_salbasd.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            rq_salbasd.Rows.Add(aRow);
                        }
                    }

                    foreach (DataRow Row in ds.Tables["zz38"].Rows)
                    {
                        DataRow row2 = rq_salbasd.Rows.Find(Row["nobr"].ToString());                       
                        Row["totalret"] = (row2 != null) ? int.Parse(row2["amt"].ToString()) : 0;
                        Row["oldret"] =0;
                        if (Convert.ToInt32(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd")) < 20050701)
                        {
                            if (Row["di"].ToString().Trim() == "D")
                                Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate1, MidpointRounding.AwayFromZero);
                            else if (Row["di"].ToString().Trim() == "I")
                                Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate, MidpointRounding.AwayFromZero);
                            else
                                Row["oldret"] = int.Parse(Row["totalret"].ToString());
                        }

                        Row["totalbonus"] = (row2 != null) ? int.Parse(row2["amt"].ToString()) : 0;
                        if (Row["di"].ToString().Trim() == "D")
                            Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper1, MidpointRounding.AwayFromZero);
                        else if (Row["di"].ToString().Trim() == "I")
                            Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper, MidpointRounding.AwayFromZero);
                        else
                            Row["bonus"] = int.Parse(Row["totalbonus"].ToString());
                        //Row["fundamt"] = int.Parse(Row["fundamt"].ToString());
                    }
                }

                if (reporttype == "2" || reporttype == "3")
                {
                    ds.Tables["zz381"].PrimaryKey = new DataColumn[] { ds.Tables["zz381"].Columns["depts"], ds.Tables["zz381"].Columns["di"] };
                    DataRow[] ORow = ds.Tables["zz38"].Select("", "depts,di asc");
                    foreach (DataRow Row in ORow)
                    {
                        string str_di = "";
                        if (Row["di"].ToString().Trim() == "D")
                            str_di = "直接";
                        else if (Row["di"].ToString().Trim() == "I")
                            str_di = "間接";
                        //else if (Row["di"].ToString().Trim() == "S")
                        //    str_di = "研發";
                        object[] _value = new object[2];
                        _value[0] = Row["depts"].ToString();
                        _value[1] = str_di;
                        DataRow row = ds.Tables["zz381"].Rows.Find(_value);
                        if (row != null)
                        {
                            row["l_exp"] = int.Parse(row["l_exp"].ToString()) + int.Parse(Row["l_exp"].ToString());
                            row["h_exp"] = int.Parse(row["h_exp"].ToString()) + int.Parse(Row["h_exp"].ToString());
                            row["g_exp"] = int.Parse(row["g_exp"].ToString()) + int.Parse(Row["g_exp"].ToString());
                            row["r_exp"] = int.Parse(row["r_exp"].ToString()) + int.Parse(Row["r_exp"].ToString());
                            row["l_exp1"] = int.Parse(row["l_exp1"].ToString()) + int.Parse(Row["l_exp1"].ToString());
                            row["h_exp1"] = int.Parse(row["h_exp1"].ToString()) + int.Parse(Row["h_exp1"].ToString());
                            row["g_exp1"] = int.Parse(row["g_exp1"].ToString()) + int.Parse(Row["g_exp1"].ToString());
                            row["r_exp1"] = int.Parse(row["r_exp1"].ToString()) + int.Parse(Row["r_exp1"].ToString());
                            row["fa_no"] = int.Parse(row["fa_no"].ToString()) + 1;
                            row["jobamt"] = int.Parse(row["jobamt"].ToString()) + int.Parse(Row["jobamt"].ToString());
                            row["fundamt"] = int.Parse(row["fundamt"].ToString()) + int.Parse(Row["fundamt"].ToString());
                            if (reporttype == "3")
                            {
                                row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                row["totalret"] = int.Parse(row["totalret"].ToString()) + int.Parse(Row["totalret"].ToString());
                                row["oldret"] = int.Parse(row["oldret"].ToString()) + int.Parse(Row["oldret"].ToString());
                                //if (Row["di"].ToString().Trim() == "D")
                                //    row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate1, MidpointRounding.AwayFromZero);
                                //else if (Row["di"].ToString().Trim() == "I")
                                //    row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate, MidpointRounding.AwayFromZero);
                                //else
                                //    row["oldret"] = int.Parse(Row["totalret"].ToString());

                                row["totalbonus"] = int.Parse(row["totalbonus"].ToString()) + int.Parse(Row["totalbonus"].ToString());
                                //if (Row["di"].ToString().Trim() == "D")
                                //    row["bonus"] = Math.Round(decimal.Parse(row["totalbonus"].ToString()) * ljobper1, MidpointRounding.AwayFromZero);
                                //else if (Row["di"].ToString().Trim() == "I")
                                //    row["bonus"] = Math.Round(decimal.Parse(row["totalbonus"].ToString()) * ljobper, MidpointRounding.AwayFromZero);
                                //else
                                //    row["bonus"] = int.Parse(row["totalbonus"].ToString());
                                row["bonus"] = int.Parse(row["bonus"].ToString()) + int.Parse(Row["bonus"].ToString());
                            }
                            row["h_amt"] = int.Parse(row["h_amt"].ToString()) + int.Parse(Row["h_amt"].ToString());
                            row["l_amt"] = int.Parse(row["l_amt"].ToString()) + int.Parse(Row["l_amt"].ToString());
                            row["r_amt"] = int.Parse(row["r_amt"].ToString()) + int.Parse(Row["r_amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz381"].NewRow();
                            aRow["depts"] = Row["depts"].ToString();
                            aRow["ds_name"] = Row["ds_name"].ToString();
                            aRow["di"] = str_di;
                            aRow["fa_no"] = 1;
                            aRow["l_exp"] = int.Parse(Row["l_exp"].ToString());
                            aRow["h_exp"] = int.Parse(Row["h_exp"].ToString());
                            aRow["g_exp"] = int.Parse(Row["g_exp"].ToString());
                            aRow["r_exp"] = int.Parse(Row["r_exp"].ToString());
                            aRow["l_exp1"] = int.Parse(Row["l_exp1"].ToString());
                            aRow["h_exp1"] = int.Parse(Row["h_exp1"].ToString());
                            aRow["g_exp1"] = int.Parse(Row["g_exp1"].ToString());
                            aRow["r_exp1"] = int.Parse(Row["r_exp1"].ToString());
                            aRow["fundamt"] = int.Parse(Row["fundamt"].ToString());
                            aRow["jobamt"] = int.Parse(Row["jobamt"].ToString());                            
                            if (reporttype == "3")
                            {
                                aRow["totalret"] = int.Parse(Row["totalret"].ToString());
                                aRow["oldret"] =  int.Parse(Row["oldret"].ToString());
                                //if (Row["di"].ToString().Trim() == "D")
                                //    aRow["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate1, MidpointRounding.AwayFromZero);
                                //else if (Row["di"].ToString().Trim() == "I")
                                //    aRow["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate, MidpointRounding.AwayFromZero);
                                //else
                                //    aRow["oldret"] = int.Parse(Row["totalret"].ToString());

                                aRow["totalbonus"] = int.Parse(Row["totalbonus"].ToString());
                                //if (Row["di"].ToString().Trim() == "D")
                                //    aRow["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper1, MidpointRounding.AwayFromZero);
                                //else if (Row["di"].ToString().Trim() == "I")
                                //    aRow["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper, MidpointRounding.AwayFromZero);
                                //else
                                //    aRow["bonus"] = int.Parse(Row["totalbonus"].ToString());
                                aRow["bonus"] = int.Parse(Row["bonus"].ToString());
                                aRow["cnt"] = 1;
                            }
                            aRow["h_amt"] = int.Parse(Row["h_amt"].ToString());
                            aRow["l_amt"] = int.Parse(Row["l_amt"].ToString());
                            aRow["r_amt"] = int.Parse(Row["r_amt"].ToString());
                            ds.Tables["zz381"].Rows.Add(aRow);
                        }
                    }
                    ds.Tables.Remove("zz38");
                }
                


                rq_base = null; rq_explab = null;
                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz38"]);
                    else if (reporttype == "1")
                        Export2(ds.Tables["zz38"]);
                    else if (reporttype == "2")
                        Export1(ds.Tables["zz381"]);
                    else if (reporttype == "3")
                        Export3(ds.Tables["zz381"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    //JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "", "*.rdlc");
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz38.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz382.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz381.rdlc";
                    else if (reporttype == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz383.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype == "0" || reporttype == "1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz38", ds.Tables["zz38"]));
                    else if (reporttype == "2" || reporttype == "3")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz381", ds.Tables["zz381"]));                  
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
        }

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("健保投保金額", typeof(int));
            ExporDt.Columns.Add("勞保投保金額", typeof(int));
            ExporDt.Columns.Add("勞退投保金額", typeof(int));
            ExporDt.Columns.Add("個人負擔勞保", typeof(int));
            ExporDt.Columns.Add("個人負擔健保", typeof(int));
            ExporDt.Columns.Add("個人負擔團保", typeof(int));
            ExporDt.Columns.Add("個人負擔勞退", typeof(int));
            ExporDt.Columns.Add("公司負擔勞保", typeof(int));
            ExporDt.Columns.Add("公司負擔健保", typeof(int));
            ExporDt.Columns.Add("公司負擔團保", typeof(int));
            ExporDt.Columns.Add("公司負擔勞退", typeof(int));
            ExporDt.Columns.Add("職業災害", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            ExporDt.Columns.Add("眷屬人數", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["ds_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["身分證號"] = Row01["idno"].ToString();
                aRow["單位"] = Row01["s_no"].ToString();
                aRow["健保投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow["勞保投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow["勞退投保金額"] = int.Parse(Row01["r_amt"].ToString());
                aRow["個人負擔勞保"] = int.Parse(Row01["l_exp"].ToString());
                aRow["個人負擔健保"] = int.Parse(Row01["h_exp"].ToString());
                aRow["個人負擔團保"] = int.Parse(Row01["g_exp"].ToString());
                aRow["個人負擔勞退"] = int.Parse(Row01["r_exp"].ToString());
                aRow["公司負擔勞保"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["公司負擔健保"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["公司負擔團保"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["公司負擔勞退"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());
                aRow["職業災害"] = int.Parse(Row01["jobamt"].ToString());
                aRow["眷屬人數"] = int.Parse(Row01["fano"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("健保投保金額", typeof(int));
            ExporDt.Columns.Add("勞保投保金額", typeof(int));
            ExporDt.Columns.Add("勞退投保金額", typeof(int));
            ExporDt.Columns.Add("個人負擔勞保", typeof(int));
            ExporDt.Columns.Add("個人負擔健保", typeof(int));
            ExporDt.Columns.Add("個人負擔團保", typeof(int));
            ExporDt.Columns.Add("個人負擔勞退", typeof(int));
            ExporDt.Columns.Add("公司負擔勞保", typeof(int));
            ExporDt.Columns.Add("公司負擔健保", typeof(int));
            ExporDt.Columns.Add("公司負擔團保", typeof(int));
            ExporDt.Columns.Add("公司負擔勞退", typeof(int));
            ExporDt.Columns.Add("職業災害", typeof(int));            
            ExporDt.Columns.Add("墊償基金", typeof(int));            
            
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["ds_name"].ToString();
                aRow["直間接"] = Row01["di"].ToString();
                aRow["人數"] = int.Parse(Row01["fa_no"].ToString());
                aRow["健保投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow["勞保投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow["勞退投保金額"] = int.Parse(Row01["r_amt"].ToString());
                aRow["個人負擔勞保"] = int.Parse(Row01["l_exp"].ToString());
                aRow["個人負擔健保"] = int.Parse(Row01["h_exp"].ToString());
                aRow["個人負擔團保"] = int.Parse(Row01["g_exp"].ToString());
                aRow["個人負擔勞退"] = int.Parse(Row01["r_exp"].ToString());
                aRow["公司負擔勞保"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["公司負擔健保"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["公司負擔團保"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["公司負擔勞退"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["職業災害"] = int.Parse(Row01["jobamt"].ToString());                
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());                
                ExporDt.Rows.Add(aRow);                
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export2(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本部門名稱", typeof(string));
            ExporDt.Columns.Add("勞保費公司", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            ExporDt.Columns.Add("勞保費個人", typeof(int));
            ExporDt.Columns.Add("勞保費總計", typeof(int));
            ExporDt.Columns.Add("健保費公司", typeof(int));
            ExporDt.Columns.Add("健保費個人", typeof(int));
            ExporDt.Columns.Add("健保費總計", typeof(int));
            ExporDt.Columns.Add("團保費公司", typeof(int));
            ExporDt.Columns.Add("團保費個人", typeof(int));
            ExporDt.Columns.Add("團保費總計", typeof(int));
            ExporDt.Columns.Add("退休金公司", typeof(int));
            ExporDt.Columns.Add("退休金個人", typeof(int));
            ExporDt.Columns.Add("退休金總計", typeof(int));           
            ExporDt.Columns.Add("退休金/舊制", typeof(int));            
            ExporDt.Columns.Add("年節公司提撥", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["編制部門"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["成本部門名稱"] = Row01["ds_name"].ToString();                
                aRow["勞保費公司"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());
                aRow["勞保費個人"] = int.Parse(Row01["l_exp"].ToString());
                aRow["勞保費總計"] = int.Parse(aRow["勞保費公司"].ToString()) + int.Parse(aRow["墊償基金"].ToString()) + int.Parse(aRow["勞保費個人"].ToString());
                aRow["健保費公司"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["健保費個人"] = int.Parse(Row01["h_exp"].ToString());
                aRow["健保費總計"] = int.Parse(aRow["健保費公司"].ToString()) + int.Parse(aRow["健保費個人"].ToString());
                aRow["團保費公司"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["團保費個人"] = int.Parse(Row01["g_exp"].ToString());
                aRow["團保費總計"] = int.Parse(aRow["團保費公司"].ToString()) + int.Parse(aRow["團保費個人"].ToString());
                aRow["退休金公司"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["退休金個人"] = int.Parse(Row01["r_exp"].ToString());
                aRow["退休金總計"] = int.Parse(aRow["退休金公司"].ToString()) + int.Parse(aRow["退休金個人"].ToString());
                aRow["退休金/舊制"] = int.Parse(Row01["oldret"].ToString());
                aRow["年節公司提撥"] = int.Parse(Row01["bonus"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }


        void Export3(DataTable DT)
        {
            DataTable ExporDt = new DataTable();           
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本部門名稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("項目", typeof(string));
            ExporDt.Columns.Add("勞保費公司", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            ExporDt.Columns.Add("勞保費個人", typeof(int));
            ExporDt.Columns.Add("勞保費總計", typeof(int));
            ExporDt.Columns.Add("健保費公司", typeof(int));
            ExporDt.Columns.Add("健保費個人", typeof(int));
            ExporDt.Columns.Add("健保費總計", typeof(int));
            ExporDt.Columns.Add("團保費公司", typeof(int));
            ExporDt.Columns.Add("團保費個人", typeof(int));
            ExporDt.Columns.Add("團保費總計", typeof(int));
            ExporDt.Columns.Add("退休金公司", typeof(int));
            ExporDt.Columns.Add("退休金個人", typeof(int));
            ExporDt.Columns.Add("退休金總計", typeof(int));
            ExporDt.Columns.Add("退休金/舊制", typeof(int));
            ExporDt.Columns.Add("年節公司提撥", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();                
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["成本部門名稱"] = Row01["ds_name"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                aRow["項目"] = Row01["di"].ToString();                
                aRow["勞保費公司"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());
                aRow["勞保費個人"] = int.Parse(Row01["l_exp"].ToString());
                aRow["勞保費總計"] = int.Parse(aRow["勞保費公司"].ToString()) + int.Parse(aRow["墊償基金"].ToString()) + int.Parse(aRow["勞保費個人"].ToString());
                aRow["健保費公司"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["健保費個人"] = int.Parse(Row01["h_exp"].ToString());
                aRow["健保費總計"] = int.Parse(aRow["健保費公司"].ToString()) + int.Parse(aRow["健保費個人"].ToString());
                aRow["團保費公司"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["團保費個人"] = int.Parse(Row01["g_exp"].ToString());
                aRow["團保費總計"] = int.Parse(aRow["團保費公司"].ToString()) + int.Parse(aRow["團保費個人"].ToString());
                aRow["退休金公司"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["退休金個人"] = int.Parse(Row01["r_exp"].ToString());
                aRow["退休金總計"] = int.Parse(aRow["退休金公司"].ToString()) + int.Parse(aRow["退休金個人"].ToString());
                aRow["退休金/舊制"] = int.Parse(Row01["oldret"].ToString());
                aRow["年節公司提撥"] = int.Parse(Row01["bonus"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

    }
}
