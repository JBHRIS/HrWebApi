/* ======================================================================================================
 * 功能名稱：員工出勤明細表
 * 功能代號：ZZ2Z
 * 功能路徑：報表列印 > 出勤 > 員工出勤明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ2Z_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/22    Daniel Chih    Ver 1.0.01     1. 修改tt1與tt2欄位到24小時制的資料顯示內容
 * 2021/04/23    Daniel Chih    Ver 1.0.02     1. B帳不顯示夜班津貼
 * 2021/04/26    Daniel Chih    Ver 1.0.03     1. B帳匯出成Excel問題修正
 * 2021/05/03    Daniel Chih    Ver 1.0.04     1. B帳檢查attcard沒有上班時間時跳過不處理
 * 2021/05/27    Daniel Chih    Ver 1.0.06     1. 修正B帳勞檢資料刷卡下班時間不會回推的問題
 * 2021/06/03    Daniel Chih    Ver 1.0.07     1. 修正B帳勞檢多段加班上下班時間不會回推的問題
 * 2021/07/29    Daniel Chih    Ver 1.0.08     1. 【出勤明細1】增加【單位】欄
 * 2021/08/09    Daniel Chih    Ver 1.0.09     1. 修正勞檢出勤明細表，上班時間錯誤的問題
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/09
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
using System.Collections;


namespace JBHR.Reports.AttForm
{
    public partial class ZZ2Z_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        DataTable rq_ot;
        DataTable rq_ota;
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        string responsibility_b, responsibility_e;
        bool late, ear, abs, abs1, forget, card, forcard, ot_fix, ot1, ot2, exportexcel, labchedk, NoSevenBreak, check_duty, print_page, IntervalHrs;
        int del_cnt = 0;
        //string NIGAMT, FOODAMT, SPECAMT;
        string ErrorMessage = string.Empty;
        public ZZ2Z_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, string reporttype, bool _late, bool _ear, bool _abs, bool _abs1, bool _forget, bool _card, bool _forcard, bool _ot_fix, bool _ot1, bool _ot2, bool _exportexcel, bool _labchedk, bool _NoSevenBreak, bool checkduty, string compname, string _CompId, bool printpage,bool _IntervalHrs)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            report_type = reporttype; late = _late; ear = _ear; abs = _abs; abs1 = _abs1;
            forget = _forget; card = _card; forcard = _forcard; ot_fix = _ot_fix; ot1 = _ot1;
            ot2 = _ot2; exportexcel = _exportexcel; labchedk = _labchedk; comp_name = compname;
            CompId = _CompId; NoSevenBreak = _NoSevenBreak; check_duty = checkduty;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
            print_page = printpage; IntervalHrs = _IntervalHrs;

            if (late)
                del_cnt++;
            if (ear)
                del_cnt++;
            if (abs)
                del_cnt++;
            if (abs1)
                del_cnt++;
            if (ot_fix)
                del_cnt++;
            if (ot1)
                del_cnt++;
            if (ot2)
                del_cnt++;
            if (forget)
                del_cnt++;
            if (forcard)
                del_cnt++;
            if (NoSevenBreak)
                del_cnt++;
            if (IntervalHrs)
                del_cnt++;
        }

        private void ZZ2Z_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string[] AttSalCode = new string[8]; string[] AttSalName = new string[8];
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_AppConfig = SqlConn.GetDataTable("SELECT a.code,a.Value,b.sal_code_disp,b.sal_name FROM AppConfig a left outer join salcode b on a.Value=b.sal_code WHERE a.Category='ZZ2Z' and a.COMP='" + MainForm.COMPANY + "' ");

                DataTable rq_saltitle = new DataTable();
                rq_saltitle.Columns.Add("sal_name", typeof(string));
                rq_saltitle.PrimaryKey = new DataColumn[] { rq_saltitle.Columns["sal_name"] };
                foreach (DataRow Row in rq_AppConfig.Rows)
                {
                    //if (Row["Code"].ToString() == "NIGAMT") NIGAMT = Row["Value"].ToString();
                    //else if (Row["Code"].ToString() == "FOODAMT") FOODAMT = Row["Value"].ToString();
                    //else if (Row["Code"].ToString() == "SPECAMT") SPECAMT = Row["Value"].ToString();
                    //else if (Row["Code"].ToString() == "AttSalCode1") AttSalCode[0] = Row["Value"].ToString(); //AttSalCode1 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode2") AttSalCode[1] = Row["Value"].ToString();//AttSalCode2 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode3") AttSalCode[2] = Row["Value"].ToString();//AttSalCode3 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode4") AttSalCode[3] = Row["Value"].ToString();//AttSalCode4 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode5") AttSalCode[4] = Row["Value"].ToString();//AttSalCode5 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode6") AttSalCode[5] = Row["Value"].ToString();//AttSalCode6 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode7") AttSalCode[6] = Row["Value"].ToString();//AttSalCode7 = Row["Value"].ToString()
                    //else if (Row["Code"].ToString() == "AttSalCode8") AttSalCode[7] = Row["Value"].ToString();//AttSalCode8 = Row["Value"].ToString()

                    if (!Row.IsNull("sal_name"))
                    {
                        DataRow row = rq_saltitle.Rows.Find(Row["sal_name"].ToString());
                        if (row==null)
                        {
                            DataRow aRow = rq_saltitle.NewRow();
                            aRow["sal_name"] = Row["sal_name"].ToString();
                            rq_saltitle.Rows.Add(aRow);
                        }

                    }
                }
                DataTable rq_sys3 = SqlConn.GetDataTable("select malemaxhrs,femalemaxhrs from u_sys3 where comp='" + CompId + "'");
                int otmaxhr = 0;
                int otminhr = 0;
                if (rq_sys3 != null)
                {
                    try
                    {
                        otmaxhr = Convert.ToInt32(rq_sys3.Rows[0]["malemaxhrs"]);
                        otminhr = Convert.ToInt32(rq_sys3.Rows[0]["femalemaxhrs"]);
                    }
                    catch 
                    { 
                    
                    }
                }

                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };

                string sqlBase = "select b.nobr,a.name_c,c.d_no_disp as dept,f.rotet_disp as rotet,c.d_name,a.sex,e.jobl_disp as jobl,c.dept_tree";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join dept c on b.dept=c.d_no";
                sqlBase += " left outer join depts d on b.depts=d.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " left outer join rotet f on  b.rotet=f.rotet";
                sqlBase += " where a.nobr=b.nobr ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlBase += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                //sqlBase += string.Format(@" and b.carcd between '{0}' and '{1}'", responsibility_b, responsibility_e);
                if (card) sqlBase += " and b.card='Y'";
                if (check_duty) sqlBase += " and b.carcd='02'";
                sqlBase += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.Columns.Add("otmaxhr", typeof(decimal));
                rq_base.Columns.Add("otminhr", typeof(int));

                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";
                foreach (DataRow Row in rq_base.Rows)
                {
                    Row["otmaxhr"] = otmaxhr;
                    Row["otminhr"] = otminhr;
                }                

                //出勤資料
                string sqlAttend = "select a.nobr,a.adate,b.rote_disp as rote,b.rotename,b.rote_sname,b.on_time,b.off_time,b.att_end,";
                sqlAttend += "a.late_mins,a.e_mins,a.abs,a.forget,a.night_hrs,a.foodamt,a.nigamt,datename(dw,a.adate) as dw,a.att_hrs,a.specamt";
                sqlAttend += ",dbo.GetContinuousWorkDay(nobr,adate) as wday,0 as change,'' as otb,'' as ote";
                sqlAttend += " from attend a,rote b";
                sqlAttend += string.Format(@" where a.rote=b.rote and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " order by a.nobr,a.adate";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                rq_attend.Columns.Add("cnt", typeof(int));
                rq_attend.Columns.Add("labchedk", typeof(string));
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"], rq_attend.Columns["adate"] };

                //刷卡資料                
                string sql_Attcard = "select nobr,adate,min(t1) as t1,min(tt1) as tt1 from attcard";
                sql_Attcard += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (check_duty) sql_Attcard += " and t1>'0900'";
                sql_Attcard += " group by nobr,adate order by adate";
                DataTable rq_attcard = SqlConn.GetDataTable(sql_Attcard);
                rq_attcard.Columns.Add("t2", typeof(string));
                rq_attcard.Columns.Add("tt2", typeof(string));
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };

                string sql_Attcard1 = "select nobr,adate,max(t2) as t2,max(tt2) as tt2 from attcard";
                sql_Attcard1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);                
                sql_Attcard1 += " group by nobr,adate order by adate";
                DataTable rq_attcard1 = SqlConn.GetDataTable(sql_Attcard1);
                rq_attcard1.PrimaryKey = new DataColumn[] { rq_attcard1.Columns["nobr"], rq_attcard1.Columns["adate"] };
                foreach (DataRow Row in rq_attcard.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_attcard1.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["t2"] = row["t2"].ToString();
                        Row["tt2"] = row["tt2"].ToString();
                    }
                    else
                    {
                        Row["t2"] = "";
                        Row["tt2"] = "";
                    }
                }

                //請假資料
                string sqlAbs = "select nobr,bdate,edate,btime,etime,h_code,h_name,tol_hours,unit from absbasetts";
                sqlAbs += string.Format(@" where bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += " and flag='-' and mang <> 1";
                //sqlAbs += " and year_rest not in ('1','3','5') ";
                sqlAbs += " order by nobr,bdate,btime";
                //判斷and mang <> 1不是系統才會顯示
                //sqlAbs += "  order by nobr,bdate,btime";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                //rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["bdate"] };

                //津貼餐費扣款
                string sqlSalabs = "select nobr,adate,sal_code,amt from salabs";
                sqlSalabs += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlSalabs += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlSalabs += string.Format(@" and mlssalcode='{0}'", MainForm.SalaryConfig.FOODSALCODE);
                DataTable rq_salabs1 = SqlConn.GetDataTable(sqlSalabs);
                DataTable rq_salabs = new DataTable();
                rq_salabs.Columns.Add("nobr", typeof(string));
                rq_salabs.Columns.Add("adate", typeof(DateTime));
                rq_salabs.Columns.Add("amt", typeof(int));
                rq_salabs.PrimaryKey = new DataColumn[] { rq_salabs.Columns["nobr"], rq_salabs.Columns["adate"] };
                foreach (DataRow Row in rq_salabs1.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_salabs.Rows.Find(_value);
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    else
                    {
                        DataRow aRow = rq_salabs.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        rq_salabs.Rows.Add(aRow);
                    }
                }
                
                //取得出差資料
                string sqlAbs1 = "select nobr,bdate,edate,btime,etime,h_code,h_name,tol_hours,unit from abs1basetts";
                sqlAbs1 += string.Format(@" where bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs1 += " order by nobr,bdate,h_code";
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs1);
                DataTable rq_abs1a = new DataTable();
                rq_abs1a.Merge(rq_abs1);
                foreach (DataRow Row in rq_abs1.Rows)
                {
                    int _DB = 1;
                    int _DE = ((TimeSpan)(DateTime.Parse(Row["edate"].ToString()) - DateTime.Parse(Row["bdate"].ToString()))).Days + 1;
                    for (int i = _DB; i <= _DB; i++)
                    {
                        string _dateb = DateTime.Parse(Row["bdate"].ToString()).AddDays(i - 1).ToString("yyyy/MM/dd");
                        DataRow[] row = rq_abs1.Select("bdate = '" + _dateb + "'");
                        if (row.Length ==0)
                        {
                            DataRow aRow = rq_abs1a.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["bdate"] = DateTime.Parse(_dateb);
                            aRow["edate"] = DateTime.Parse(_dateb);
                            aRow["h_code"] = Row["h_code"].ToString();
                            aRow["h_name"] = Row["h_name"].ToString();
                            aRow["btime"] = Row["btime"].ToString();
                            aRow["etime"] = Row["etime"].ToString();
                            rq_abs1a.Rows.Add(aRow);
                        }
                    }
                }
                rq_abs.Merge(rq_abs1a);
                DataTable rq_absj = new DataTable();
                rq_absj = rq_abs.Clone();
                rq_absj.TableName = "rq_absj";
                DataRow[] rowabsj = rq_abs.Select("h_code in ('J1','J2','J3')");
                foreach (DataRow Row in rowabsj)
                {
                    rq_absj.ImportRow(Row);
                }
                rq_absj.PrimaryKey = new DataColumn[] { rq_absj.Columns["nobr"], rq_absj.Columns["bdate"] };

                if (labchedk)
                {
                    string[] holicode = new string[] { "00", "0X", "0Z" };//假日班別

                    string sqlOte = "select nobr,bdate,sum(ot_hrs) as ot_hrs from ot";
                    sqlOte += string.Format(@" where bdate between '{0}' and '{1}'", date_b, date_e);
                    sqlOte += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlOte += " group by nobr,bdate";
                    DataTable rq_ote = SqlConn.GetDataTable(sqlOte);
                    rq_ote.PrimaryKey = new DataColumn[] { rq_ote.Columns["nobr"], rq_ote.Columns["bdate"] };

                    string sqlOtd = "select a.nobr,f.rote_disp as rote,a.bdate,a.ot_hrs,a.btime,a.etime,f.on_time,f.off_time,f.att_end,e.nigamt";
                    sqlOtd += " from ot_b a";
                    sqlOtd += " left outer join attend e on a.nobr=e.nobr and a.bdate=e.adate";
                    sqlOtd += " left outer join rote f on e.rote=f.rote";
                    sqlOtd += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                    //sqlOtd += string.Format(@" where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                    sqlOtd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlOtd += " order by a.nobr,a.bdate,a.btime";
                    DataTable rq_otb = SqlConn.GetDataTable(sqlOtd);

                    //同一個員編的迴圈次數
                    bool start_loop = true;
                    //前一筆員編資料
                    string nobr_before = "";
                    string date_before = "";

                    foreach (DataRow Row in rq_otb.Rows)
                    {
                        if (start_loop)
                        {
                            nobr_before = Row["nobr"].ToString();
                            date_before = Row["bdate"].ToString();
                        }

                        DataRow rowb = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (rowb != null)
                        {
                            bool chantime = true;
                            if (Row.IsNull("rote"))
                            {
                                Row["rote"] = string.Empty;
                                Row["on_time"] = "0000";
                                Row["att_end"] = "0000";

                            }
                            if (!CodeFunction.GetHolidayRoteList().Contains(Row["rote"].ToString().Trim()))
                            {
                                decimal ontime = string.IsNullOrEmpty(Row["on_time"].ToString().Trim())
                                    ? Convert.ToDecimal(Row["btime"].ToString())
                                    : Convert.ToDecimal(Row["on_time"].ToString());
                                decimal offtime = string.IsNullOrEmpty(Row["att_end"].ToString())
                                    ? (string.IsNullOrEmpty(Row["off_time"].ToString().Trim())
                                        ? Convert.ToDecimal(Row["etime"].ToString())
                                        : Convert.ToDecimal(Row["off_time"].ToString())
                                    )
                                    : Convert.ToDecimal(Row["att_end"].ToString());
                                decimal btime = Convert.ToDecimal(Row["btime"].ToString());
                                decimal etime = Convert.ToDecimal(Row["etime"].ToString());
                                if (btime >= ontime && etime <= offtime) //上班區間內加班
                                    chantime = false;
                            }
                            if (chantime)
                            {
                                //刷卡資料
                                string _nobr = Row["nobr"].ToString();
                                string _bdate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                                object[] _value = new object[2];
                                _value[0] = _nobr;
                                _value[1] = DateTime.Parse(Row["bdate"].ToString());
                                DataRow row1 = rq_attcard.Rows.Find(_value);
                                DataRow row2 = rq_attend.Rows.Find(_value);
                                DataRow row3 = rq_ote.Rows.Find(_value);

                                if (row2 != null)
                                {
                                    string absbtime = string.Empty; string absetime = string.Empty;

                                    string tt1 = string.IsNullOrEmpty(Row["on_time"].ToString())
                                        ? Row["btime"].ToString()
                                        : Row["on_time"].ToString();
                                    string t1 = string.IsNullOrEmpty(Row["on_time"].ToString())
                                        ? Row["btime"].ToString()
                                        : Row["on_time"].ToString();
                                    string tt2 = string.IsNullOrEmpty(Row["att_end"].ToString())
                                        ? (string.IsNullOrEmpty(Row["off_time"].ToString())
                                            ? Row["etime"].ToString()
                                            : Row["off_time"].ToString()
                                        )
                                        : Row["att_end"].ToString();
                                    string t2 = string.IsNullOrEmpty(Row["att_end"].ToString())
                                        ? (string.IsNullOrEmpty(Row["off_time"].ToString())
                                            ? Row["etime"].ToString()
                                            : Row["off_time"].ToString()
                                        )
                                        : Row["att_end"].ToString();
                                    string _otbdate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd");

                                    decimal _otbtime = Convert.ToDecimal(_otbdate + Row["btime"].ToString());
                                    decimal _otetime = Convert.ToDecimal(_otbdate + Row["etime"].ToString());
                                    decimal _attontime = Convert.ToDecimal(_otbdate + Row["on_time"].ToString());
                                    decimal _attofftime = string.IsNullOrEmpty(Row["att_end"].ToString()) ? Convert.ToDecimal(_otbdate + Row["off_time"].ToString()) : Convert.ToDecimal(_otbdate + Row["att_end"].ToString());
                                    string at = ""; string sd = "";
                                    decimal _etime = 0;
                                    decimal _etimeh = 0;
                                    decimal _etimes = 0;
                                    string _hstime = "";
                                    decimal _t1 = Convert.ToDecimal(_otbdate + row1["t1"].ToString());
                                    int cardt1 = int.Parse(row1["t1"].ToString());
                                    int cardt2 = int.Parse(row1["t2"].ToString());

                                    int ontime = string.IsNullOrEmpty(Row["on_time"].ToString().Trim())
                                    ? int.Parse(Row["btime"].ToString())
                                    : int.Parse(Row["on_time"].ToString());
                                    int offtime = string.IsNullOrEmpty(Row["att_end"].ToString())
                                        ? (string.IsNullOrEmpty(Row["off_time"].ToString().Trim())
                                            ? int.Parse(Row["etime"].ToString())
                                            : int.Parse(Row["off_time"].ToString())
                                        )
                                        : int.Parse(Row["att_end"].ToString());

                                    int otbtime = int.Parse(Row["btime"].ToString());
                                    int otetime = int.Parse(Row["etime"].ToString());

                                    if (CodeFunction.GetHolidayRoteList().Contains(Row["rote"].ToString().Trim()))
                                    {
                                        row2["change"] = 1;
                                        //Row["foodamt"] = 0;
                                        row2["nigamt"] = 0;
                                        //Row["specamt"] = 0;
                                        row2["att_hrs"] = 0;

                                        if (t1.ToString().Length == 4)
                                        {
                                            at = t1.ToString().Substring(0, 2);
                                            sd = t1.ToString().Substring(2, 2);
                                            _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["t1"]) % 15);
                                            _etimeh = decimal.Floor(_etime / 60);
                                            _etimes = _etime - (_etimeh * 60);
                                            _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                            //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                            if (start_loop)
                                            {
                                                row1["t1"] = _hstime;
                                            }
                                            else if (nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                            {
                                                if (int.Parse(row1["t1"].ToString()) >= int.Parse(_hstime))
                                                {
                                                    row1["t1"] = _hstime;
                                                }
                                            }
                                            else
                                            {
                                                row1["t1"] = _hstime;
                                            }
                                        }
                                        if (tt1.ToString().Length == 4)
                                        {
                                            at = tt1.ToString().Substring(0, 2);
                                            sd = tt1.ToString().Substring(2, 2);
                                            _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["tt1"]) % 15);
                                            _etimeh = decimal.Floor(_etime / 60);
                                            _etimes = _etime - (_etimeh * 60);
                                            if (_etimeh >= 24M)
                                                _etimeh = _etimeh - 24M;
                                            _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                            //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                            if (start_loop)
                                            {
                                                row1["tt1"] = _hstime;
                                            }
                                            else if (nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                            {
                                                if (int.Parse(row1["tt1"].ToString()) >= int.Parse(_hstime))
                                                {
                                                    row1["tt1"] = _hstime;
                                                }
                                            }
                                            else
                                            {
                                                row1["tt1"] = _hstime;
                                            }
                                        }

                                        if (t2.ToString().Length == 4)
                                        {
                                            at = t2.ToString().Substring(0, 2);
                                            sd = t2.ToString().Substring(2, 2);
                                            _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["t2"]) % 15);
                                            _etimeh = decimal.Floor(_etime / 60);
                                            _etimes = _etime - (_etimeh * 60);
                                            _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                            //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                            if (start_loop)
                                            {
                                                row1["t2"] = _hstime;
                                            }
                                            else if (nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                            {
                                                if (int.Parse(row1["t2"].ToString()) <= int.Parse(_hstime))
                                                {
                                                    row1["t2"] = _hstime;
                                                }
                                            }
                                            else
                                            {
                                                row1["t2"] = _hstime;
                                            }
                                        }
                                        if (t2.ToString().Length == 4)
                                        {
                                            at = tt2.ToString().Substring(0, 2);
                                            sd = tt2.ToString().Substring(2, 2);
                                            _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["tt2"]) % 15);
                                            _etimeh = decimal.Floor(_etime / 60);
                                            _etimes = _etime - (_etimeh * 60);
                                            if (_etimeh >= 24M)
                                                _etimeh = _etimeh - 24M;
                                            _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                            //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                            if (start_loop)
                                            {
                                                row1["tt2"] = _hstime;
                                            }
                                            else if (nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                            {
                                                if (int.Parse(row1["tt2"].ToString()) <= int.Parse(_hstime))
                                                {
                                                    row1["tt2"] = _hstime;
                                                }
                                            }
                                            else
                                            {
                                                row1["tt2"] = _hstime;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        decimal othrs = 0;
                                        //若與前一筆資料為同日加班
                                        if (!start_loop && nobr_before == row3["nobr"].ToString() && date_before == row3["bdate"].ToString())
                                        {
                                            othrs = (row3 != null) ? decimal.Parse(Row["ot_hrs"].ToString()) : 0;
                                            row2["att_hrs"] = decimal.Parse(row2["att_hrs"].ToString()) + othrs;
                                        }
                                        else
                                        {
                                            othrs = (row3 != null) ? decimal.Parse(row3["ot_hrs"].ToString()) - decimal.Parse(Row["ot_hrs"].ToString()) : 0;
                                            row2["att_hrs"] = decimal.Parse(row2["att_hrs"].ToString()) - othrs;
                                        }

                                        if (row2 != null && row1 != null)
                                        {
                                            row2["change"] = 1;
                                            //Row["foodamt"] = 0;
                                            //row2["nigamt"] = 0;
                                            //Row["specamt"] = 0;
                                            if (!string.IsNullOrEmpty(row1["t2"].ToString()))
                                            {
                                                DataRow[] absrow = rq_abs.Select("nobr='" + _nobr + "' and bdate='" + _bdate + "'", "btime asc");
                                                for (int i = 0; i < absrow.Length; i++)
                                                {
                                                    if (i == 0)
                                                        absbtime = absrow[i]["btime"].ToString();
                                                    absetime = absrow[i]["etime"].ToString();
                                                }


                                                if (cardt1 < ontime && (ontime - cardt1 > 15) && offtime == otbtime)    //判斷上班卡時間小於上班時間,調整刷卡時間
                                                {
                                                    if (t1.ToString().Length == 4)
                                                    {
                                                        at = t1.ToString().Substring(0, 2);
                                                        sd = t1.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["t1"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["t1"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["on_time"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["t1"].ToString()) >= int.Parse(_hstime))
                                                            {
                                                                row1["t1"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["t1"] = _hstime;
                                                        }
                                                    }
                                                    if (t1.ToString().Length == 4)
                                                    {
                                                        at = tt1.ToString().Substring(0, 2);
                                                        sd = tt1.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["tt1"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        if (_etimeh >= 24M)
                                                            _etimeh = _etimeh - 24M;
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["tt1"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["on_time"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["tt1"].ToString()) >= int.Parse(_hstime))
                                                            {
                                                                row1["tt1"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["tt1"] = _hstime;
                                                        }
                                                    }
                                                }
                                                else if (cardt1 < ontime && (ontime - cardt1 > 15) && cardt1 < otbtime)
                                                {
                                                    if (int.Parse(Row["btime"].ToString()) < int.Parse(Row["on_time"].ToString()))
                                                    {
                                                        t1 = Row["btime"].ToString();
                                                        tt1 = Row["btime"].ToString();
                                                    }
                                                    else
                                                    {
                                                        t1 = Row["on_time"].ToString();
                                                        tt1 = Row["on_time"].ToString();
                                                    }
                                                    if (t1.ToString().Length == 4)
                                                    {
                                                        at = t1.ToString().Substring(0, 2);
                                                        sd = t1.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["t1"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;

                                                        if (start_loop)
                                                        {
                                                            row1["t1"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["on_time"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["t1"].ToString()) >= int.Parse(_hstime))
                                                            {
                                                                row1["t1"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["t1"] = _hstime;
                                                        }
                                                    }
                                                    if (t1.ToString().Length == 4)
                                                    {
                                                        at = tt1.ToString().Substring(0, 2);
                                                        sd = tt1.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["tt1"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        if (_etimeh >= 24M)
                                                            _etimeh = _etimeh - 24M;
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["tt1"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["on_time"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["tt1"].ToString()) >= int.Parse(_hstime))
                                                            {
                                                                row1["tt1"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["tt1"] = _hstime;
                                                        }
                                                    }
                                                }

                                                if (cardt2 > offtime && (cardt2 - offtime > 15) && ontime == otetime)   //判斷下班刷卡時間大於下班時間,調整刷卡時間 
                                                {
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = t2.ToString().Substring(0, 2);
                                                        sd = t2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["t2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["t2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["t2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                    }
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = tt2.ToString().Substring(0, 2);
                                                        sd = tt2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["tt2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        if (_etimeh >= 24M)
                                                            _etimeh = _etimeh - 24M;
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["tt2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["tt2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }
                                                    }
                                                }
                                                else if (cardt2 > offtime && (cardt2 - offtime > 15) && cardt2 > otetime)
                                                {
                                                    t2 = Row["etime"].ToString();
                                                    tt2 = Row["etime"].ToString();
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = t2.ToString().Substring(0, 2);
                                                        sd = t2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["t2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["t2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["t2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                    }
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = tt2.ToString().Substring(0, 2);
                                                        sd = tt2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["tt2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        if (_etimeh >= 24M)
                                                            _etimeh = _etimeh - 24M;
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["tt2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["tt2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }

                                                    }
                                                }
                                                else if (cardt2 > offtime  && cardt2 < otetime)
                                                {
                                                    t2 = Row["etime"].ToString();
                                                    tt2 = Row["etime"].ToString();
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = t2.ToString().Substring(0, 2);
                                                        sd = t2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["t2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["t2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["t2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["t2"] = _hstime;
                                                        }
                                                    }
                                                    if (t2.ToString().Length == 4)
                                                    {
                                                        at = tt2.ToString().Substring(0, 2);
                                                        sd = tt2.ToString().Substring(2, 2);
                                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["tt2"]) % 15);
                                                        _etimeh = decimal.Floor(_etime / 60);
                                                        _etimes = _etime - (_etimeh * 60);
                                                        if (_etimeh >= 24M)
                                                            _etimeh = _etimeh - 24M;
                                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                                        if (start_loop)
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }
                                                        else if (absbtime != Row["att_end"].ToString() && nobr_before == Row["nobr"].ToString() && date_before == Row["bdate"].ToString())
                                                        {
                                                            if (int.Parse(row1["tt2"].ToString()) <= int.Parse(_hstime))
                                                            {
                                                                row1["tt2"] = _hstime;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            row1["tt2"] = _hstime;
                                                        }

                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        nobr_before = Row["nobr"].ToString();
                        date_before = Row["bdate"].ToString();

                        if (start_loop)
                        {
                            start_loop = false;
                        }
                    }
                    DataRow[] SRowAtt = rq_attend.Select("change=0 ");
                    foreach (DataRow Row in SRowAtt)
                    {
                        string rote = Row["rote"].ToString().Trim();
                        //刷卡資料
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row["adate"].ToString());
                        DataRow row1 = rq_attcard.Rows.Find(_value);
                        DataRow row3 = rq_ote.Rows.Find(_value);
                        if (row1 != null)
                        {
                            if (CodeFunction.GetHolidayRoteList().Contains(Row["rote"].ToString().Trim()))
                            {
                                row1["t1"] = "";
                                row1["tt1"] = "";
                                row1["t2"] = "";
                                row1["tt2"] = "";
                                Row["change"] = 1;
                                Row["att_hrs"] = 0;
                            }
                            else if (!string.IsNullOrEmpty(row1["t1"].ToString()) && !string.IsNullOrEmpty(row1["t2"].ToString()))
                            {
                                int offtime = string.IsNullOrEmpty(Row["att_end"].ToString()) ? int.Parse(Row["off_time"].ToString()) : int.Parse(Row["att_end"].ToString());
                                int ontime = int.Parse(Row["on_time"].ToString());
                                int cardt1 = int.Parse(row1["t1"].ToString());
                                int cardt2 = int.Parse(row1["t2"].ToString());
                                string at = ""; string sd = "";
                                decimal _etime = 0;
                                decimal _etimeh = 0;
                                decimal _etimes = 0;
                                string _hstime = "";
                                int _tt2 = Convert.ToInt32(row1["tt2"]) % 15;
                                int _t2 = Convert.ToInt32(row1["t2"]) % 15;
                                string tt1 = Row["on_time"].ToString();
                                string t1 = Row["on_time"].ToString();

                                //string tt2 = Row["att_end"].ToString();
                                //string t2 = Row["att_end"].ToString();

                                //班制下班時間
                                string tt2 = string.IsNullOrEmpty(Row["att_end"].ToString()) ? Row["off_time"].ToString() : Row["att_end"].ToString();
                                string t2 = string.IsNullOrEmpty(Row["att_end"].ToString()) ? Row["off_time"].ToString() : Row["att_end"].ToString();

                                int otb = (string.IsNullOrEmpty(Row["otb"].ToString())) ? 0 : Convert.ToInt32(Row["otb"]);
                                int ote = (string.IsNullOrEmpty(Row["ote"].ToString())) ? 0 : Convert.ToInt32(Row["ote"]);
                                int difon = (otb == 0) ? 0 : ontime - cardt1;
                                int difoff = (otb == 0) ? 0 : cardt2 - offtime;
                                //bool changecard = bool.Parse("fase");

                                if (cardt2 > offtime && (cardt2 - offtime > 15)) // && cardt2!=ote
                                {
                                    if (t2.Length == 4)
                                    {
                                        at = t2.Substring(0, 2);
                                        sd = t2.Substring(2, 2);
                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["t2"]) % 15);
                                        _etimeh = decimal.Floor(_etime / 60);
                                        _etimes = _etime - (_etimeh * 60);
                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                        row1["t2"] = _hstime;
                                    }
                                    if (tt2.Length == 4)
                                    {
                                        at = tt2.Substring(0, 2);
                                        sd = tt2.Substring(2, 2);
                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) + (Convert.ToInt32(row1["tt2"]) % 15);
                                        _etimeh = decimal.Floor(_etime / 60);
                                        _etimes = _etime - (_etimeh * 60);
                                        //若大於24hr則調整成小於24hr顯示格式 - Added By Daniel Chih - 2021/04/22
                                        if (_etimeh >= 24M)
                                            _etimeh = _etimeh - 24M;
                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');

                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                        row1["tt2"] = _hstime;
                                    }
                                    
                                }

                                if (cardt1 < ontime && (ontime - cardt1 > 15)) //&& cardt1 != otb
                                {
                                    if (t1.Length == 4)
                                    {
                                        at = t1.Substring(0, 2);
                                        sd = t1.Substring(2, 2);
                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["t1"]) % 15);
                                        _etimeh = decimal.Floor(_etime / 60);
                                        _etimes = _etime - (_etimeh * 60);
                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                        //row1["t2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                        row1["t1"] = _hstime;
                                    }
                                    if (tt1.Length == 4)
                                    {
                                        at = tt1.Substring(0, 2);
                                        sd = tt1.Substring(2, 2);
                                        _etime = Convert.ToDecimal(at) * 60 + Convert.ToDecimal(sd) - (Convert.ToInt32(row1["tt1"]) % 15);
                                        _etimeh = decimal.Floor(_etime / 60);
                                        _etimes = _etime - (_etimeh * 60);
                                        //若大於24hr則調整成小於24hr顯示格式 - Added By Daniel Chih - 2021/04/22
                                        if (_etimeh >= 24M)
                                            _etimeh = _etimeh - 24M;
                                        _hstime = Convert.ToString(decimal.Round(_etimeh, 0)).PadLeft(2, '0') + Convert.ToString(decimal.Round(_etimes, 0)).PadLeft(2, '0');
                                        //row1["tt2"] = (_etimes < 0) ? _hstime + "-" : _hstime;
                                        row1["tt1"] = _hstime;
                                    }
                                }
                                decimal othrs = (row3 != null) ? decimal.Parse(row3["ot_hrs"].ToString())  : 0;
                                Row["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString()) - othrs;
                            }
                        }
                    }
                    
                    string sqlOta = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs,a.note,a.syscreat,a.syscreat1,a.sys_ot";
                    sqlOta += ",a.nop_w_100,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_100,a.nop_h_133";
                    sqlOta += ",a.nop_h_167,a.nop_h_200,a.not_w_100,a.not_w_133,a.not_w_167,a.not_w_200,a.not_h_133,a.not_h_167,a.not_h_200";
                    sqlOta += ",a.tot_w_100,a.tot_w_133,a.tot_w_167,a.tot_w_200";
                    sqlOta += ",ot_food1,a.ot_foodh";                    
                    sqlOta += " from ot_b a ";
                    sqlOta += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                    sqlOta += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlOta += " order by a.nobr,a.bdate,a.btime";
                    rq_ot = SqlConn.GetDataTable(sqlOta);
                }
                else
                {
                    //加班
                    string sqlOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs,a.note,a.syscreat,a.syscreat1,a.sys_ot";
                    sqlOt += ",a.nop_w_100,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_100,a.nop_h_133";
                    sqlOt += ",a.nop_h_167,a.nop_h_200,a.not_w_100,a.not_w_133,a.not_w_167,a.not_w_200,a.not_h_133,a.not_h_167,a.not_h_200";
                    sqlOt += ",a.tot_w_100,a.tot_w_133,a.tot_w_167,a.tot_w_200";
                    sqlOt += ",ot_food1,a.ot_foodh";
                    sqlOt += string.Format(@"  from ot a where a.bdate between '{0}' and '{1}'", date_b, date_e);
                    sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    //sqlOt += " and  b.display=1";
                    sqlOt += " order by a.nobr,a.bdate,a.btime";
                    rq_ot = SqlConn.GetDataTable(sqlOt);
                }
                for (int i = 1; i <= 10; i++)
                {
                    rq_ot.Columns.Add("Fldt" + i, typeof(decimal));
                    rq_ot.Columns.Add("Fld" + i, typeof(decimal));
                }
                DataTable rq_title = new DataTable();
                rq_title.Columns.Add("rate", typeof(decimal));
                Get_Ot(rq_ot, rq_title);
                int otrow = (rq_title.Rows.Count > 9) ? 9 : rq_title.Rows.Count;

                DataTable rq_salatt1 = new DataTable();
                DataTable rq_salatt = new DataTable();

                rq_salatt.Columns.Add("nobr", typeof(string));
                rq_salatt.Columns.Add("adate", typeof(DateTime));
                rq_salatt.PrimaryKey = new DataColumn[] { rq_salatt.Columns["nobr"], rq_salatt.Columns["adate"] };

                if (labchedk && report_type=="0")
                {
                   
                }
                else
                {
                    //津貼顯示
                    string sqlAalatt = "select a.nobr,a.adate,b.sal_name,sum(a.amt) as amt";
                    sqlAalatt += " from salatt a,salcode b";
                    sqlAalatt += " where a.sal_code=b.sal_code";
                    sqlAalatt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlAalatt += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                    //sqlAalatt += string.Format(" and a.sal_code in ('{0}','{1}','{2}','{3}','{4}')", AttSalCode1, AttSalCode2, AttSalCode3, AttSalCode4, AttSalCode5);
                    sqlAalatt += " group by a.nobr,a.adate,b.sal_name";
                    sqlAalatt += " order by a.nobr,a.adate";

                    rq_salatt1 = SqlConn.GetDataTable(sqlAalatt);


                    //津貼表頭
                    DataRow aRowta = ds.Tables["zz2zta1"].NewRow();
                    for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                    {
                        aRowta["Fldt" + (i + 1)] = rq_saltitle.Rows[i]["sal_name"].ToString();
                        rq_salatt.Columns.Add(rq_saltitle.Rows[i]["sal_name"].ToString(), typeof(int));
                    }
                    ds.Tables["zz2zta1"].Rows.Add(aRowta);

                }


                foreach (DataRow Row in rq_salatt1.Rows)
                {
                    string salname = Row["sal_name"].ToString();
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row1 = rq_attend.Rows.Find(_value);
                    if (row1 != null)
                    {
                        row1["foodamt"] = 0;
                        row1["nigamt"] = 0;
                        row1["specamt"] = 0;
                    }
                    DataRow row2 = rq_attcard.Rows.Find(_value);
                    bool set0 = labchedk && row2 != null && row2["t1"].ToString() == "" && row2["tt1"].ToString() == "" && row2["t2"].ToString() == "" && row2["tt2"].ToString() == "";

                    DataRow row = rq_salatt.Rows.Find(_value);
                    if (row != null)
                    {
                        for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                        {
                            if (salname == rq_saltitle.Rows[i]["sal_name"].ToString())
                            {
                                row[rq_saltitle.Rows[i]["sal_name"].ToString()] = set0 ? 0 : decimal.Parse(row[rq_saltitle.Rows[i]["sal_name"].ToString()].ToString()) + decimal.Parse(Row["amt"].ToString());
                                break;
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow = rq_salatt.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                        {
                            aRow[rq_saltitle.Rows[i]["sal_name"].ToString()] = 0;
                            if (salname == rq_saltitle.Rows[i]["sal_name"].ToString())
                            {
                                aRow[rq_saltitle.Rows[i]["sal_name"].ToString()] = set0 ? 0 : decimal.Parse(Row["amt"].ToString());
                            }
                        }
                        rq_salatt.Rows.Add(aRow);
                    }
                }

                DataTable rq_attendn = new DataTable();
                rq_attendn.Columns.Add("nobr", typeof(string));
                rq_attendn.Columns.Add("night_hrs", typeof(decimal));
                rq_attendn.Columns.Add("foodamt", typeof(int));
                rq_attendn.Columns.Add("nigamt", typeof(decimal));
                rq_attendn.Columns.Add("specamt", typeof(decimal));
                rq_attendn.PrimaryKey = new DataColumn[] { rq_attendn.Columns["nobr"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row1 = rq_salabs.Rows.Find(_value);
                    if (row1 != null)
                    {
                        Row["foodamt"] = decimal.Parse(Row["foodamt"].ToString()) + int.Parse(row1["amt"].ToString());
                    }

                    DataRow row = rq_attendn.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        row["night_hrs"] = decimal.Parse(row["night_hrs"].ToString()) + decimal.Parse(Row["night_hrs"].ToString());
                        row["foodamt"] = int.Parse(row["foodamt"].ToString()) + decimal.Round(decimal.Parse(Row["foodamt"].ToString()), 0);
                        row["nigamt"] = decimal.Parse(row["nigamt"].ToString()) + decimal.Parse(Row["nigamt"].ToString());
                        row["specamt"] = decimal.Parse(row["specamt"].ToString()) + decimal.Parse(Row["specamt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_attendn.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["night_hrs"] = decimal.Parse(Row["night_hrs"].ToString());
                        aRow["foodamt"] = decimal.Round(decimal.Parse(Row["foodamt"].ToString()), 0);
                        aRow["nigamt"] = decimal.Parse(Row["nigamt"].ToString());
                        aRow["specamt"] = decimal.Parse(Row["specamt"].ToString());
                        rq_attendn.Rows.Add(aRow);
                    }

                    
                }

                //計算未七休一名單
                DataTable rq_NoSevenBreak = new DataTable();
                rq_NoSevenBreak.Columns.Add("nobr", typeof(string));
                rq_NoSevenBreak.PrimaryKey = new DataColumn[] { rq_NoSevenBreak.Columns["nobr"] };
                if (NoSevenBreak)
                {
                    foreach (DataRow Row in rq_attend.Rows)
                    {
                        if (int.Parse(Row["wday"].ToString()) > 6)
                        {
                            DataRow row = rq_NoSevenBreak.Rows.Find(Row["nobr"].ToString());
                            if (row == null)
                            {
                                DataRow aRow = rq_NoSevenBreak.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                rq_NoSevenBreak.Rows.Add(aRow);
                            }
                        }
                    }
                }

                //忘刷次數
                DataTable rq_attendf = new DataTable();
                rq_attendf.Columns.Add("nobr", typeof(string));
                rq_attendf.Columns.Add("forget", typeof(int));
                rq_attendf.PrimaryKey = new DataColumn[] { rq_attendf.Columns["nobr"] };

                DataTable zz2z = new DataTable();
                zz2z = ds.Tables["zz2z"].Clone();
                zz2z.TableName = "zz2z";
               
                foreach (DataRow Row in rq_attend.Rows)
                {
                    Row["dw"] = JBHR.Reports.ReportClass.GetDayWeek(DateTime.Parse(Row["adate"].ToString()));
                    if (Row.IsNull("labchedk")) Row["labchedk"] = "0";
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row1 = rq_attcard.Rows.Find(_value);
                    DataRow row2 = rq_salatt.Rows.Find(_value);
                    if (check_duty)
                    {
                        if (row != null && row1 != null)
                        {
                            DataRow row5 = rq_depttree.Rows.Find(row["dept_tree"].ToString());
                            DataRow aRow = zz2z.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["dept_tree"] = (row5 != null) ? row5["d_no_disp"].ToString().Trim() + " " + row5["d_name"].ToString() : "";
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["jobl"] = row["jobl"].ToString();
                            aRow["otmaxhr"] = decimal.Parse(row["otmaxhr"].ToString());
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow["rote"] = Row["rote"].ToString();
                            aRow["rotename"] = Row["rote_sname"].ToString();
                            aRow["on_time"] = Row["on_time"].ToString();
                            aRow["off_time"] = Row["off_time"].ToString();
                            aRow["wday"] = int.Parse(Row["wday"].ToString());
                            aRow["dw"] = Row["dw"].ToString().Substring(2, 1);
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                            aRow["abs"] = bool.Parse(Row["abs"].ToString());
                            aRow["night_hrs"] = decimal.Round(decimal.Parse(Row["night_hrs"].ToString()), 2);
                            aRow["foodamt"] = decimal.Round(decimal.Parse(Row["foodamt"].ToString()), 0);
                            //aRow["foodamt1"] = (Row.IsNull("foodamt1")) ? 0 : decimal.Round(decimal.Parse(Row["foodamt1"].ToString()), 0);
                            aRow["nigamt"] = decimal.Parse(Row["nigamt"].ToString());
                            aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                            aRow["specamt"] = decimal.Parse(Row["specamt"].ToString());
                            aRow["ot_hrs"] = 0;
                            aRow["rest_hrs"] = 0;
                            aRow["tol_hours"] = 0;
                            aRow["del_cnt"] = 0;
                            aRow["not_w_100"] = 0;
                            aRow["tot_w_100"] = 0;
                            aRow["not_w_133"] = 0;
                            aRow["tot_w_133"] = 0;
                            aRow["not_h_133"] = 0;
                            aRow["not_w_167"] = 0;
                            aRow["tot_w_167"] = 0;
                            aRow["not_h_167"] = 0;
                            aRow["not_w_200"] = 0;
                            aRow["tot_w_200"] = 0;
                            aRow["not_h_200"] = 0;
                            //aRow["syscreat"] = bool.Parse("false");
                            //aRow["syscreat1"] = bool.Parse("false");
                            //aRow["sys_ot"] = bool.Parse("false");
                            if (row1 != null && Row["labchedk"].ToString() == "0")
                            {
                                aRow["t1"] = row1["t1"].ToString();
                                aRow["tt1"] = row1["tt1"].ToString();
                                aRow["t2"] = row1["t2"].ToString();
                                aRow["tt2"] = row1["tt2"].ToString();
                            }
                            if (row2!=null)
                            {
                                for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                                {
                                    aRow["att_Fld" + (i + 1)] = int.Parse(row2[rq_saltitle.Rows[i]["sal_name"].ToString()].ToString());                                    
                                }
                            }
                            zz2z.Rows.Add(aRow);
                        }
                    }
                    else
                    {
                        if (row != null)
                        {
                            DataRow row5 = rq_depttree.Rows.Find(row["dept_tree"].ToString());
                            DataRow aRow = zz2z.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["dept_tree"] = (row5 != null) ? row5["d_no_disp"].ToString().Trim() + " " + row5["d_name"].ToString() : "";
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["jobl"] = row["jobl"].ToString();
                            aRow["otmaxhr"] = decimal.Parse(row["otmaxhr"].ToString());
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow["rote"] = Row["rote"].ToString();
                            aRow["rotename"] = Row["rote_sname"].ToString();
                            aRow["on_time"] = Row["on_time"].ToString();
                            aRow["off_time"] = Row["off_time"].ToString();
                            aRow["wday"] = int.Parse(Row["wday"].ToString());
                            aRow["dw"] = Row["dw"].ToString().Substring(2, 1);
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                            aRow["abs"] = bool.Parse(Row["abs"].ToString());
                            aRow["night_hrs"] = decimal.Round(decimal.Parse(Row["night_hrs"].ToString()), 2);
                            aRow["foodamt"] = decimal.Round(decimal.Parse(Row["foodamt"].ToString()), 0);
                            //aRow["foodamt1"] = (Row.IsNull("foodamt1")) ? 0 : decimal.Round(decimal.Parse(Row["foodamt1"].ToString()), 0);
                            aRow["nigamt"] = decimal.Parse(Row["nigamt"].ToString());
                            aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                            aRow["specamt"] = decimal.Parse(Row["specamt"].ToString());
                            aRow["ot_hrs"] = 0;
                            aRow["rest_hrs"] = 0;
                            aRow["tol_hours"] = 0;
                            aRow["del_cnt"] = 0;
                            aRow["not_w_100"] = 0;
                            aRow["tot_w_100"] = 0;
                            aRow["not_w_133"] = 0;
                            aRow["tot_w_133"] = 0;
                            aRow["not_h_133"] = 0;
                            aRow["not_w_167"] = 0;
                            aRow["tot_w_167"] = 0;
                            aRow["not_h_167"] = 0;
                            aRow["not_w_200"] = 0;
                            aRow["tot_w_200"] = 0;
                            aRow["not_h_200"] = 0;
                            //aRow["syscreat"] = bool.Parse("false");
                            //aRow["syscreat1"] = bool.Parse("false");
                            //aRow["sys_ot"] = bool.Parse("false");
                            if (row1 != null && Row["labchedk"].ToString() == "0")
                            {
                                aRow["t1"] = row1["t1"].ToString();
                                aRow["tt1"] = row1["tt1"].ToString();
                                aRow["t2"] = row1["t2"].ToString();
                                aRow["tt2"] = row1["tt2"].ToString();
                            }
                            if (row2 != null)
                            {
                                for (int i = 0; i < rq_saltitle.Rows.Count; i++)
                                {
                                    aRow["att_Fld" + (i + 1)] = int.Parse(row2[rq_saltitle.Rows[i]["sal_name"].ToString()].ToString());
                                }
                            }
                            zz2z.Rows.Add(aRow);
                        }
                    }
                    Row.Delete();
                }
                rq_attend = null;
                rq_base = null;

                if (forget)
                {
                    foreach (DataRow Row in zz2z.Rows)
                    {

                        DataRow row4 = rq_attendf.Rows.Find(Row["nobr"].ToString());
                        if (row4 != null)
                            row4["forget"] = int.Parse(row4["forget"].ToString()) + int.Parse(Row["forget"].ToString());
                        else
                        {
                            DataRow aRow2 = rq_attendf.NewRow();
                            aRow2["nobr"] = Row["nobr"].ToString();
                            aRow2["forget"] = int.Parse(Row["forget"].ToString());
                            rq_attendf.Rows.Add(aRow2);
                        }

                    }
                }
                DataTable listInterval = new DataTable();
                listInterval.Columns.Add("nobr", typeof(string));
                listInterval.Columns.Add("adate_b", typeof(DateTime));
                listInterval.Columns.Add("adate_e", typeof(DateTime));
                listInterval.Columns.Add("diffhrs", typeof(decimal));
                listInterval.PrimaryKey = new DataColumn[] { listInterval.Columns["nobr"], listInterval.Columns["adate_e"] };

                if (IntervalHrs)
                {
                    string nobr1 = string.Empty;
                    string t2 = string.Empty;
                    string adate1 = "00001231";
                    foreach (DataRow Row in zz2z.Rows)
                    {
                        string t1 = Row["t1"].ToString();
                        string nobr = Row["nobr"].ToString();
                        string adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                        if (nobr==nobr1 && adate!=adate1 && t1!="" && t2!="")
                        {
                            DateTime DateA = DateTime.Parse(adate1).AddTime(t2);
                            DateTime DateB = DateTime.Parse(adate).AddTime(t1);
                            TimeSpan ts1 = new TimeSpan(DateA.Ticks);
                            TimeSpan ts2 = new TimeSpan(DateB.Ticks);
                            TimeSpan ts = ts1.Subtract(ts2).Duration();
                            decimal _day = ts.Days;
                            decimal _hrs = (_day * 24M) + ts.Hours;
                            decimal _Min = ts.Minutes;
                            if (_hrs<11)
                            {
                                object[] _value = new object[2];
                                _value[0] = Row["nobr"].ToString();
                                _value[1] = DateTime.Parse(Row["adate"].ToString());
                                DataRow row1 = listInterval.Rows.Find(_value);
                                if (row1==null)
                                {
                                    DataRow aRow = listInterval.NewRow();
                                    aRow["nobr"] = Row["nobr"].ToString();
                                    aRow["adate_b"] = adate1;
                                    aRow["adate_e"] = DateTime.Parse(Row["adate"].ToString());
                                    aRow["diffhrs"] = _hrs;
                                    listInterval.Rows.Add(aRow);
                                }
                            }
                        }
                        t2 = Row["t2"].ToString();
                        nobr1 = Row["nobr"].ToString();
                        adate1 = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                    }
                }
                //JBHR.Reports.ReportClass.Export(listInterval, this.Name);
                //合晶科技計算天數(黛玲要加的)STR
                DataTable rq_countatt = new DataTable();
                rq_countatt.Columns.Add("nobr", typeof(string));
                rq_countatt.Columns.Add("cnt", typeof(int));
                rq_countatt.PrimaryKey = new DataColumn[] { rq_countatt.Columns["nobr"] };

                DataTable rq_countatt1 = new DataTable();
                rq_countatt1.Columns.Add("nobr", typeof(string));
                rq_countatt1.Columns.Add("cnt", typeof(int));
                rq_countatt1.PrimaryKey = new DataColumn[] { rq_countatt1.Columns["nobr"] };

                foreach (DataRow Row in zz2z.Rows)
                {
                    DataRow row = rq_countatt.Rows.Find(Row["nobr"].ToString());
                    if (Row["rote"].ToString().Trim() != "00")
                    {
                        if (row != null)
                            row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                        else
                        {
                            DataRow aRow = rq_countatt.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["cnt"] = 1;
                            rq_countatt.Rows.Add(aRow);
                        }
                    }
                    string _adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                    DataRow[] row1 = rq_ot.Select("nobr='" + Row["nobr"].ToString() + "' and bdate='" + _adate + "'");
                    DataRow row2 = rq_countatt1.Rows.Find(Row["nobr"].ToString());
                    if (row1.Length > 1)
                    {
                        if (row2 != null)
                            row2["cnt"] = int.Parse(row2["cnt"].ToString()) + 1;
                        else
                        {
                            DataRow aRow1 = rq_countatt1.NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["cnt"] = 1;
                            rq_countatt1.Rows.Add(aRow1);
                        }
                    }
                }

                Hashtable ht = new Hashtable();
                DataRow aRowt = ds.Tables["zz2zta"].NewRow();
                for (int t = 0; t < otrow; t++)
                {
                    aRowt["ot_Fldt" + (t + 1)] = rq_title.Rows[t][0].ToString() + "加班";
                    ht.Add(rq_title.Rows[t][0].ToString(), (t + 1));
                }
                ds.Tables["zz2zta"].Rows.Add(aRowt);

                List<DataRow> _aa = new List<DataRow>();
                foreach (DataRow Row in zz2z.Rows)
                {
                    Row["sys_ot"] = bool.Parse("false");
                    string _nobr = Row["nobr"].ToString();
                    string _adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                    DataRow[] row = rq_abs.Select("nobr='" + _nobr + "' and bdate='" + _adate + "'");
                    DataRow[] row1 = rq_ot.Select("nobr='" + _nobr + "' and bdate='" + _adate + "'");
                    decimal _otfoodh = 0;
                    if (row.Length > row1.Length)
                    {
                        for (int i = 0; i < row.Length; i++)
                        {
                            if (Row["h_name"].ToString().Trim() == "")
                            {
                                Row["abs_btime"] = row[i]["btime"].ToString();
                                Row["abs_etime"] = row[i]["etime"].ToString();
                                Row["h_name"] = row[i]["h_name"].ToString();
                                Row["tol_hours"] = decimal.Parse(row[i]["tol_hours"].ToString());
                                Row["unit"] = row[i]["unit"].ToString();
                                if (row1.Length > i)
                                {
                                    Row["ot_btime"] = row1[i]["btime"].ToString();
                                    Row["ot_etime"] = row1[i]["etime"].ToString();
                                    Row["ot_hrs"] = decimal.Parse(row1[i]["ot_hrs"].ToString());
                                    Row["rest_hrs"] = decimal.Parse(row1[i]["rest_hrs"].ToString());
                                    Row["ot_note"] = row1[i]["note"].ToString();
                                    Row["syscreat"] = bool.Parse(row1[i]["syscreat"].ToString());
                                    Row["syscreat1"] = bool.Parse(row1[i]["syscreat1"].ToString());
                                    Row["sys_ot"] = bool.Parse(row1[i]["sys_ot"].ToString());                                   

                                    for (int k = 0; k < otrow; k++)
                                    {
                                        if (!row1[i].IsNull("Fldt" + (k + 1)))
                                        {
                                            //if (rq_title.Rows[k][0].ToString() == row1[i]["Fldt" + (k + 1)].ToString())
                                            //{
                                            //    Row["ot_Fldt" + (k + 1)] = row1[i]["Fldt" + (k + 1)].ToString();
                                            //    Row["ot_Fld" + (k + 1)] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                            //}
                                            string raterow = ht[row1[i]["Fldt" + (k + 1)].ToString()].ToString();
                                            Row["ot_Fldt" + raterow] = row1[i]["Fldt" + (k + 1)].ToString();
                                            Row["ot_Fld" + raterow] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                        }
                                    }                                    
                                    _otfoodh = _otfoodh + decimal.Parse(row1[i]["ot_foodh"].ToString());
                                }
                                Row["foodamt"] = int.Parse(Row["foodamt"].ToString()) + decimal.Round(_otfoodh, 0);
                            }
                            else
                            {
                                DataRow aRow = zz2z.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = Row["name_c"].ToString();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["dept_tree"] = Row["dept_tree"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["jobl"] = Row["jobl"].ToString();
                                aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                                aRow["dw"] = Row["dw"].ToString();
                                aRow["rote"] = Row["rote"].ToString();
                                aRow["rotename"] = Row["rotename"].ToString();
                                aRow["on_time"] = Row["on_time"].ToString();
                                aRow["off_time"] = Row["off_time"].ToString();
                                aRow["wday"] = int.Parse(Row["wday"].ToString());
                                aRow["abs_btime"] = row[i]["btime"].ToString();
                                aRow["abs_etime"] = row[i]["etime"].ToString();
                                aRow["h_name"] = row[i]["h_name"].ToString();
                                aRow["tol_hours"] = (!row[i].IsNull("tol_hours")) ? decimal.Parse(row[i]["tol_hours"].ToString()) : 0;
                                aRow["unit"] = row[i]["unit"].ToString();
                                aRow["night_hrs"] = decimal.Round(decimal.Parse(Row["night_hrs"].ToString()), 2);
                                aRow["foodamt"] = int.Parse(Row["foodamt"].ToString());
                                //aRow["foodamt1"] = (Row.IsNull("foodamt1")) ? 0 : int.Parse(Row["foodamt1"].ToString()); ;
                                aRow["nigamt"] = decimal.Parse(Row["nigamt"].ToString());
                                aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                                aRow["specamt"] = decimal.Parse(Row["specamt"].ToString());
                                aRow["abs"] = bool.Parse(Row["abs"].ToString());
                                aRow["del_cnt"] = 0;
                                aRow["sys_ot"] = bool.Parse("false");
                               
                                if (row1.Length > i)
                                {
                                    aRow["ot_btime"] = row1[i]["btime"].ToString();
                                    aRow["ot_etime"] = row1[i]["etime"].ToString();
                                    aRow["ot_hrs"] = decimal.Parse(row1[i]["ot_hrs"].ToString());
                                    aRow["rest_hrs"] = decimal.Parse(row1[i]["rest_hrs"].ToString());
                                    aRow["ot_note"] = row1[i]["note"].ToString();
                                    aRow["syscreat"] = bool.Parse(row1[i]["syscreat"].ToString());
                                    aRow["syscreat1"] = bool.Parse(row1[i]["syscreat1"].ToString());
                                    aRow["sys_ot"] = bool.Parse(row1[i]["sys_ot"].ToString());                                    
                                    for (int k = 0; k < otrow; k++)
                                    {
                                        if (!row1[i].IsNull("Fldt" + (k + 1)))
                                        {
                                            //if (rq_title.Rows[k][0].ToString() == row1[i]["Fldt" + (k + 1)].ToString())
                                            //{
                                            //    aRow["ot_Fldt" + (k + 1)] = row1[i]["Fldt" + (k + 1)].ToString();
                                            //    aRow["ot_Fld" + (k + 1)] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                            //}
                                            string raterow = ht[row1[i]["Fldt" + (k + 1)].ToString()].ToString();
                                            Row["ot_Fldt" + raterow] = row1[i]["Fldt" + (k + 1)].ToString();
                                            Row["ot_Fld" + raterow] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                        }
                                    }
                                }                      

                                aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                                aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                                aRow["forget"] = int.Parse(Row["forget"].ToString());
                                //zz2z.Rows.Add(aRow);
                                _aa.Add(aRow);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < row1.Length; i++)
                        {
                            _otfoodh = _otfoodh + decimal.Parse(row1[i]["ot_foodh"].ToString());
                            if (Row["ot_btime"].ToString().Trim() == "")
                            {
                                Row["ot_btime"] = row1[i]["btime"].ToString();
                                Row["ot_etime"] = row1[i]["etime"].ToString();
                                Row["ot_hrs"] = decimal.Parse(row1[i]["ot_hrs"].ToString());
                                Row["rest_hrs"] = decimal.Parse(row1[i]["rest_hrs"].ToString());
                                Row["ot_note"] = row1[i]["note"].ToString();
                                Row["syscreat"] = bool.Parse(row1[i]["syscreat"].ToString());
                                Row["syscreat1"] = bool.Parse(row1[i]["syscreat1"].ToString());
                                Row["sys_ot"] = bool.Parse(row1[i]["sys_ot"].ToString());                               
                                for (int k = 0; k < otrow; k++)
                                {
                                    if (!row1[i].IsNull("Fldt" + (k + 1)))
                                    {
                                        //if (rq_title.Rows[k][0].ToString() == row1[i]["Fldt" + (k + 1)].ToString())
                                        //{
                                        //    Row["ot_Fldt" + (k + 1)] = row1[i]["Fldt" + (k + 1)].ToString();
                                        //    Row["ot_Fld" + (k + 1)] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                        //}
                                        string raterow = ht[row1[i]["Fldt" + (k + 1)].ToString()].ToString();
                                        Row["ot_Fldt" + raterow] = row1[i]["Fldt" + (k + 1)].ToString();
                                        Row["ot_Fld" + raterow] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                    }
                                }
                                if (row.Length > i)
                                {
                                    Row["abs_btime"] = row[i]["btime"].ToString();
                                    Row["abs_etime"] = row[i]["etime"].ToString();
                                    Row["h_name"] = row[i]["h_name"].ToString();
                                    Row["tol_hours"] = decimal.Parse(row[i]["tol_hours"].ToString());
                                    Row["unit"] = row[i]["unit"].ToString();
                                }
                            }
                            else
                            {
                                DataRow aRow = zz2z.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = Row["name_c"].ToString();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["dept_tree"] = Row["dept_tree"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["jobl"] = Row["jobl"].ToString();
                                aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                                aRow["dw"] = Row["dw"].ToString();
                                aRow["rote"] = Row["rote"].ToString();
                                aRow["rotename"] = Row["rotename"].ToString();
                                aRow["on_time"] = Row["on_time"].ToString();
                                aRow["off_time"] = Row["off_time"].ToString();
                                aRow["ot_btime"] = row1[i]["btime"].ToString();
                                aRow["ot_etime"] = row1[i]["etime"].ToString();
                                aRow["wday"] = int.Parse(Row["wday"].ToString());
                                aRow["ot_hrs"] = decimal.Parse(row1[i]["ot_hrs"].ToString());
                                aRow["rest_hrs"] = decimal.Parse(row1[i]["rest_hrs"].ToString());
                                aRow["ot_note"] = row1[i]["note"].ToString();
                                aRow["syscreat"] = bool.Parse(row1[i]["syscreat"].ToString());
                                aRow["syscreat1"] = bool.Parse(row1[i]["syscreat1"].ToString());
                                aRow["sys_ot"] = bool.Parse(row1[i]["sys_ot"].ToString());
                               
                                for (int k = 0; k < otrow; k++)
                                {
                                    if (!row1[i].IsNull("Fldt" + (k + 1)))
                                    {
                                        //if (rq_title.Rows[k][0].ToString() == row1[i]["Fldt" + (k + 1)].ToString())
                                        //{
                                        //    Row["ot_Fldt" + (k + 1)] = row1[i]["Fldt" + (k + 1)].ToString();
                                        //    Row["ot_Fld" + (k + 1)] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                        //}
                                        string raterow = ht[row1[i]["Fldt" + (k + 1)].ToString()].ToString();
                                        Row["ot_Fldt" + raterow] = row1[i]["Fldt" + (k + 1)].ToString();
                                        Row["ot_Fld" + raterow] = decimal.Parse(row1[i]["Fld" + (k + 1)].ToString());
                                    }
                                }
                                aRow["del_cnt"] = 0;                               
                                if (row.Length > i)
                                {                                    
                                    aRow["abs_btime"] = row[i]["btime"].ToString();
                                    aRow["abs_etime"] = row[i]["etime"].ToString();
                                    aRow["h_name"] = row[i]["h_name"].ToString();
                                    aRow["tol_hours"] = decimal.Parse(row[i]["tol_hours"].ToString());
                                    aRow["unit"] = row[i]["unit"].ToString();
                                                                        
                                }
                                aRow["nigamt"] = decimal.Parse(Row["nigamt"].ToString());
                                aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                                aRow["abs"] = bool.Parse(Row["abs"].ToString());
                                aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                                aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                                aRow["night_hrs"] = decimal.Round(decimal.Parse(Row["night_hrs"].ToString()), 2);
                                aRow["foodamt"] = int.Parse(Row["foodamt"].ToString());
                                //aRow["foodamt1"] = (Row.IsNull("foodamt1")) ? 0 : int.Parse(Row["foodamt1"].ToString()); ;
                                aRow["forget"] = int.Parse(Row["forget"].ToString());
                                aRow["specamt"] = decimal.Parse(Row["specamt"].ToString());
                                //zz2z.Rows.Add(aRow);
                                _aa.Add(aRow);
                            }
                        }
                        Row["foodamt"] = int.Parse(Row["foodamt"].ToString()) + decimal.Round(_otfoodh, 0);
                    }
                }
                foreach (DataRow itm in _aa)
                {
                    //zz2z.ImportRow(itm);
                    //var row = zz2z.NewRow();
                    DataRow aRow = zz2z.NewRow();
                    aRow["nobr"] = itm["nobr"].ToString();
                    aRow["name_c"] = itm["name_c"].ToString();
                    aRow["dept"] = itm["dept"].ToString();
                    aRow["dept_tree"] = itm["dept_tree"].ToString();
                    aRow["d_name"] = itm["d_name"].ToString();
                    aRow["jobl"] = itm["jobl"].ToString();
                    aRow["adate"] = DateTime.Parse(itm["adate"].ToString());
                    aRow["dw"] = itm["dw"].ToString();
                    aRow["rote"] = itm["rote"].ToString();
                    aRow["rotename"] = itm["rotename"].ToString();
                    aRow["on_time"] = itm["on_time"].ToString();
                    aRow["off_time"] = itm["off_time"].ToString();
                    aRow["abs_btime"] = itm["abs_btime"].ToString();
                    aRow["abs_etime"] = itm["abs_etime"].ToString();
                    aRow["wday"] = int.Parse(itm["wday"].ToString());
                    if (!itm.IsNull("h_name")) aRow["h_name"] = itm["h_name"].ToString();
                    if (!itm.IsNull("tol_hours")) aRow["tol_hours"] = decimal.Parse(itm["tol_hours"].ToString());
                    if (!itm.IsNull("unit")) aRow["unit"] = itm["unit"].ToString();
                    if (!itm.IsNull("night_hrs")) aRow["night_hrs"] = decimal.Round(decimal.Parse(itm["night_hrs"].ToString()), 2);
                    if (!itm.IsNull("foodamt")) aRow["foodamt"] = int.Parse(itm["foodamt"].ToString());
                    //if (!itm.IsNull("foodamt1")) aRow["foodamt1"] = int.Parse(itm["foodamt1"].ToString());
                    if (!itm.IsNull("nigamt")) aRow["nigamt"] = decimal.Parse(itm["nigamt"].ToString());
                    if (!itm.IsNull("specamt")) aRow["specamt"] = decimal.Parse(itm["specamt"].ToString());
                    if (!itm.IsNull("att_hrs")) aRow["att_hrs"] = decimal.Parse(itm["att_hrs"].ToString());
                    if (!itm.IsNull("abs")) aRow["abs"] = bool.Parse(itm["abs"].ToString());
                    aRow["del_cnt"] = int.Parse(itm["del_cnt"].ToString());
                    if (!itm.IsNull("ot_btime")) aRow["ot_btime"] = itm["ot_btime"].ToString();
                    if (!itm.IsNull("ot_etime")) aRow["ot_etime"] = itm["ot_etime"].ToString();
                    if (!itm.IsNull("ot_hrs")) aRow["ot_hrs"] = decimal.Parse(itm["ot_hrs"].ToString());
                    if (!itm.IsNull("rest_hrs")) aRow["rest_hrs"] = decimal.Parse(itm["rest_hrs"].ToString());
                    if (!itm.IsNull("ot_note")) aRow["ot_note"] = itm["ot_note"].ToString();
                    if (!itm.IsNull("syscreat")) aRow["syscreat"] = bool.Parse(itm["syscreat"].ToString());
                    if (!itm.IsNull("syscreat1")) aRow["syscreat1"] = bool.Parse(itm["syscreat1"].ToString());
                    if (!itm.IsNull("sys_ot")) aRow["sys_ot"] = bool.Parse(itm["sys_ot"].ToString());
                   
                    for (int k = 0; k < otrow; k++)
                    {
                        if (!itm.IsNull("ot_Fldt" + (k + 1)))
                        {
                            if (rq_title.Rows[k][0].ToString() == itm["ot_Fldt" + (k + 1)].ToString())
                            {
                                //aRow["ot_Fldt" + (k + 1)] = itm["ot_Fldt" + (k + 1)].ToString();
                                aRow["ot_Fld" + (k + 1)] = decimal.Parse(itm["ot_Fld" + (k + 1)].ToString());
                            }
                        }
                    }
                    aRow["late_mins"] = decimal.Parse(itm["late_mins"].ToString());
                    aRow["e_mins"] = decimal.Parse(itm["e_mins"].ToString());
                    aRow["forget"] = int.Parse(itm["forget"].ToString());
                    zz2z.Rows.Add(aRow);

                    //_aa.Add(aRow);
                }
                           
                rq_abs = null;

                
                rq_ot = null;
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_attendf, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");

               
        
                DataRow[] Orow = zz2z.Select("", "dept,nobr,adate asc");
                string str_nobr1 = "";
                string str_adate1 = "";
                foreach (DataRow Row in Orow)
                {
                    string str_nobr = Row["nobr"].ToString();
                    string str_adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd");
                    DataRow row = rq_countatt.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_countatt1.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        Row["att_no"] = int.Parse(row["cnt"].ToString());
                    if (row1 != null)
                        Row["att1_no"] = int.Parse(row1["cnt"].ToString());
                    string _adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                    if (late)//只列印遲到
                        if (decimal.Parse(Row["late_mins"].ToString()) == 0)
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;

                    if (ear)//只列印早退
                        if (decimal.Parse(Row["e_mins"].ToString()) == 0)
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;

                    if (abs1)//只列印曠職
                        if (!bool.Parse(Row["abs"].ToString()))
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                    if (abs)//只列印請假
                        if (Row["h_name"].ToString().Trim() == "")
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;

                    string _rote = Row["rote"].ToString().Trim();
                    if (ot_fix)//只列印假日班確有固定加班
                    {
                        if (!Row.IsNull("syscreat"))
                        {
                            if (_rote != "00" || !bool.Parse(Row["syscreat"].ToString()) || Row["ot_btime"].ToString() == "")
                                Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                        }
                        else
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                    }
                    if (ot1)//只列印非固定加班
                    {
                        if (Row["ot_btime"].ToString().Trim()!="")//!Row.IsNull("syscreat")
                        {
                            if (bool.Parse(Row["syscreat"].ToString()) || bool.Parse(Row["syscreat1"].ToString()) || Row["ot_btime"].ToString()=="")
                                Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                        }
                        else
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;

                    }
                    if (ot2)//只列印颱風加班
                    {
                        if (!Row.IsNull("sys_ot"))
                        {
                            //if (Row["ot_btime"].ToString().Trim() != "" || !bool.Parse(Row["sys_ot"].ToString()))
                            //    Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                            if (!bool.Parse(Row["sys_ot"].ToString()))
                                Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                        }
                        else
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                    }
                    //if (forget)
                    //{
                    //    if (int.Parse(Row["forget"].ToString()) > 0)
                    //        Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                    //}
                    if (forcard)
                    {
                        if (int.Parse(Row["forget"].ToString()) < 1)
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;
                    }
                    if (IntervalHrs)
                    {
                        DataRow[] SRow3 = listInterval.Select("nobr='" + str_nobr + "' and (adate_b='" + _adate + "' or adate_e='" + _adate + "')");
                        if (SRow3.Length == 0)
                            Row["del_cnt"] = int.Parse(Row["del_cnt"].ToString()) + 1;                   
                    }
                    if (del_cnt == 0)
                    {
                        if (str_nobr == str_nobr1 && str_adate == str_adate1)
                        {
                            Row["late_mins"] = 0;
                            Row["e_mins"] = 0;
                            Row["night_hrs"] = 0;
                            Row["foodamt"] = 0;
                            Row["nigamt"] = 0;
                            Row["specamt"] = 0;
                            Row["att_hrs"] = 0;
                            Row["abs"] = bool.Parse("false");
                        }
                        if (forget)
                        {
                            DataRow row2 = rq_attendf.Rows.Find(Row["nobr"].ToString());
                            if (row2 != null)
                            {
                                if (int.Parse(row2["forget"].ToString()) < 3)
                                    ds.Tables["zz2z"].ImportRow(Row);
                            }
                        }
                        else
                            ds.Tables["zz2z"].ImportRow(Row);
                    }
                    else
                    {
                        if (int.Parse(Row["del_cnt"].ToString()) != del_cnt)
                        {
                            if (str_nobr == str_nobr1 && str_adate == str_adate1)
                            {
                                Row["late_mins"] = 0;
                                Row["e_mins"] = 0;
                                Row["night_hrs"] = 0;
                                Row["foodamt"] = 0;
                                Row["nigamt"] = 0;
                                Row["specamt"] = 0;
                                Row["att_hrs"] = 0;
                                Row["abs"] = bool.Parse("false");
                            }
                            if (forget)
                            {
                                DataRow row2 = rq_attendf.Rows.Find(Row["nobr"].ToString());
                                if (int.Parse(Row["del_cnt"].ToString()) != del_cnt - 1)
                                    ds.Tables["zz2z"].ImportRow(Row);
                                else if (row2 != null)
                                {
                                    if (int.Parse(row2["forget"].ToString()) > 1)
                                        ds.Tables["zz2z"].ImportRow(Row);
                                    //if (int.Parse(row2["forget"].ToString()) > 2 || int.Parse(Row["del_cnt"].ToString()) != del_cnt-1)
                                    //    ds.Tables["zz2z"].ImportRow(Row);
                                }
                            }
                            else if (NoSevenBreak)
                            {
                                DataRow row3 = rq_NoSevenBreak.Rows.Find(Row["nobr"].ToString());
                                if (int.Parse(Row["del_cnt"].ToString()) != del_cnt - 1)
                                    ds.Tables["zz2z"].ImportRow(Row);
                                else if (row3 != null)
                                    ds.Tables["zz2z"].ImportRow(Row);
                            }                           
                            else
                                ds.Tables["zz2z"].ImportRow(Row);
                        }
                    }

                    str_nobr1 = Row["nobr"].ToString();
                    str_adate1 = DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd");
                }
                
                zz2z = null; rowabsj = null; rq_abs1 = null; rq_abs1a = null; rq_absj = null; rq_attcard = null; rq_attendf = null;
                rq_attendn = null; rq_countatt = null; rq_countatt1 = null; rq_salatt = null; rq_salatt1 = null; listInterval = null;
                if (ds.Tables["zz2z"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                //DataClass.Export_Excel(ds.Tables["zz2z"]);
                if (exportexcel)
                {
                    if (report_type == "0")
                        Export(ds.Tables["zz2z"], ds.Tables["zz2zta1"]);
                    else
                        Export(ds.Tables["zz2z"], ds.Tables["zz2zta"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _rptpath = jb.module.GetReportDirector(Application.StartupPath, "attendreport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "0")
                    {
                        if (print_page)
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z-page.rdlc";
                        else
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z.rdlc";
                    }
                    else if (report_type == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z3.rdlc";
                    else if (report_type == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z5.rdlc";
                    else if (report_type == "5")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z6.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (report_type == "0") //|| report_type == "4"
                    {
                        //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NIGAMT", "") });
                        //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("FOODAMT", "") });
                        //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SPECAMT", "") });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2zta1", ds.Tables["zz2zta1"]));
                    }
                    if (report_type == "4")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2zta", ds.Tables["zz2zta"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z", ds.Tables["zz2z"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message +  ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            //if (report_type == "0") ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            if (report_type == "0") ExporDt.Columns.Add("工作天數", typeof(int));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("班別代碼", typeof(string));
            ExporDt.Columns.Add("班別", typeof(string));
            ExporDt.Columns.Add("上班時間", typeof(string));
            ExporDt.Columns.Add("下班時間", typeof(string));
            if (report_type == "0")
            {
                ExporDt.Columns.Add("假別", typeof(string));
                ExporDt.Columns.Add("請起時間", typeof(string));
                ExporDt.Columns.Add("請迄時間", typeof(string));
                ExporDt.Columns.Add("請得假時數", typeof(decimal));
                ExporDt.Columns.Add("單位", typeof(string));
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
                ExporDt.Columns.Add("忘刷", typeof(int));
                ExporDt.Columns.Add("遲到(分)", typeof(decimal));
                ExporDt.Columns.Add("早退(分)", typeof(decimal));
                ExporDt.Columns.Add("曠職", typeof(string));
                ExporDt.Columns.Add("出勤時數", typeof(decimal));
                //ExporDt.Columns.Add("伙食費", typeof(int));               
                //ExporDt.Columns.Add("夜班津貼1", typeof(decimal));
                //ExporDt.Columns.Add("夜班津貼2", typeof(decimal));
                //ExporDt.Columns.Add(NIGAMT, typeof(decimal));
                //ExporDt.Columns.Add(FOODAMT, typeof(int));
                //ExporDt.Columns.Add(SPECAMT, typeof(decimal));
                //ExporDt.Columns.Add("加班原因", typeof(string));

                if (labchedk && report_type == "0")
                {

                }
                else
                {
                    for (int i = 0; i < DT1.Columns.Count; i++)
                    {
                        if (DT1.Rows[0][i].ToString() != "")
                            ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(int));
                        else
                            break;
                    }
                }

                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    //aRow["報表分析群組"] = Row["dept_tree"].ToString();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                    if (report_type == "0") aRow["工作天數"] = int.Parse(Row["wday"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["班別代碼"] = Row["rote"].ToString();
                    aRow["班別"] = Row["rotename"].ToString();
                    aRow["上班時間"] = Row["tt1"].ToString();
                    aRow["下班時間"] = Row["tt2"].ToString();
                    aRow["假別"] = Row.IsNull("h_name") ? "" : Row["h_name"].ToString();
                    aRow["請起時間"] = Row.IsNull("abs_btime") ? "" : Row["abs_btime"].ToString();
                    aRow["請迄時間"] = Row.IsNull("abs_etime") ? "" : Row["abs_etime"].ToString();
                    aRow["請得假時數"] = Row.IsNull("tol_hours") ? 0 : decimal.Parse(Row["tol_hours"].ToString());
                    aRow["單位"] = Row.IsNull("unit") ? "" : Row["unit"].ToString();
                    aRow["加起時間"] = Row.IsNull("ot_btime") ? "" : Row["ot_btime"].ToString();
                    aRow["加迄時間"] = Row.IsNull("ot_etime") ? "" : Row["ot_etime"].ToString();
                    aRow["加班時數"] = Row.IsNull("ot_hrs") ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = Row.IsNull("rest_hrs") ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                    aRow["忘刷"] = Row.IsNull("forget") ? 0 : int.Parse(Row["forget"].ToString());
                    aRow["遲到(分)"] = decimal.Parse(Row["late_mins"].ToString());
                    aRow["早退(分)"] = decimal.Parse(Row["e_mins"].ToString());
                    aRow["曠職"] = (bool.Parse(Row["abs"].ToString())) ? "V" : "";
                    aRow["出勤時數"] = Row.IsNull("att_hrs") ? 0 : decimal.Parse(Row["att_hrs"].ToString());
                    //aRow["伙食費"] = Row.IsNull("foodamt") ? 0 : int.Parse(Row["foodamt"].ToString());                    
                    //aRow["夜班津貼1"] = Row.IsNull("nigamt") ? 0 : decimal.Parse(Row["nigamt"].ToString());
                    //aRow["夜班津貼2"] = Row.IsNull("specamt") ? 0 : decimal.Parse(Row["specamt"].ToString());
                    //aRow[FOODAMT] = Row.IsNull("foodamt") ? 0 : int.Parse(Row["foodamt"].ToString());
                    //aRow[NIGAMT] = Row.IsNull("nigamt") ? 0 : decimal.Parse(Row["nigamt"].ToString());
                    //aRow[SPECAMT] = Row.IsNull("specamt") ? 0 : decimal.Parse(Row["specamt"].ToString());
                    //aRow["加班原因"] = Row.IsNull("ot_note") ? "" : Row["ot_note"].ToString();
                    if (labchedk && report_type == "0")
                    {

                    }
                    else
                    {
                        for (int i = 0; i < DT1.Columns.Count; i++)
                        {
                            if (DT1.Rows[0][i].ToString() != "")
                                aRow[DT1.Rows[0][i].ToString()] = (Row.IsNull("att_Fld" + (i + 1))) ? 0 : int.Parse(Row["att_Fld" + (i + 1)].ToString());

                        }
                    }
                    ExporDt.Rows.Add(aRow);
                }

            }
            else if (report_type == "3")
            {
                ExporDt.Columns.Add("假別", typeof(string));
                ExporDt.Columns.Add("請起時間", typeof(string));
                ExporDt.Columns.Add("請迄時間", typeof(string));
                ExporDt.Columns.Add("請得假時數", typeof(decimal));
                ExporDt.Columns.Add("單位", typeof(string));
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
                ExporDt.Columns.Add("忘刷", typeof(int));
                ExporDt.Columns.Add("遲到(分)", typeof(decimal));
                ExporDt.Columns.Add("早退(分)", typeof(decimal));
                ExporDt.Columns.Add("出勤時數", typeof(decimal));
                ExporDt.Columns.Add("夜班", typeof(decimal));
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["班別代碼"] = Row["rote"].ToString();
                    aRow["班別"] = Row.IsNull("rotename") ? "" : Row["rotename"].ToString();
                    aRow["上班時間"] = Row.IsNull("tt1") ? "" : Row["tt1"].ToString();
                    aRow["下班時間"] = Row.IsNull("tt2") ? "" : Row["tt2"].ToString();
                    aRow["假別"] = Row.IsNull("h_name") ? "" : Row["h_name"].ToString();
                    aRow["請起時間"] = Row.IsNull("abs_btime") ? "" : Row["abs_btime"].ToString();
                    aRow["請迄時間"] = Row.IsNull("abs_etime") ? "" : Row["abs_etime"].ToString();
                    aRow["請得假時數"] = (Row.IsNull("tol_hours")) ? 0 : decimal.Parse(Row["tol_hours"].ToString());
                    aRow["單位"] = Row.IsNull("unit") ? "" : Row["unit"].ToString();
                    aRow["加起時間"] = Row.IsNull("ot_btime") ? "" : Row["ot_btime"].ToString();
                    aRow["加迄時間"] = Row.IsNull("ot_etime") ? "" : Row["ot_etime"].ToString();
                    aRow["加班時數"] = Row.IsNull("ot_hrs") ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = Row.IsNull("rest_hrs") ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                    aRow["忘刷"] = Row.IsNull("forget") ? 0 : int.Parse(Row["forget"].ToString());
                    aRow["遲到(分)"] = (Row.IsNull("late_mins")) ? 0 : decimal.Parse(Row["late_mins"].ToString());
                    aRow["早退(分)"] = (Row.IsNull("e_mins")) ? 0 : decimal.Parse(Row["e_mins"].ToString());
                    aRow["出勤時數"] = (Row.IsNull("att_hrs")) ? 0 : decimal.Round(decimal.Parse(Row["att_hrs"].ToString()), 2);
                    aRow["夜班"] = (Row.IsNull("night_hrs")) ? 0 : decimal.Parse(Row["night_hrs"].ToString());
                    ExporDt.Rows.Add(aRow);
                }

            }
            else if (report_type == "4")
            {
                ExporDt.Columns.Add("加起時間", typeof(string));
                ExporDt.Columns.Add("加迄時間", typeof(string));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("補休時數", typeof(decimal));
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(decimal));
                    else
                        break;
                }
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["班別代碼"] = Row["rote"].ToString();
                    aRow["班別"] = Row.IsNull("rotename") ? "" : Row["rotename"].ToString();
                    aRow["上班時間"] = Row["tt1"].ToString();
                    aRow["下班時間"] = Row["tt2"].ToString();
                    aRow["加起時間"] = Row["ot_btime"].ToString();
                    aRow["加迄時間"] = Row["ot_etime"].ToString();
                    aRow["加班時數"] = Row.IsNull("ot_hrs") ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["補休時數"] = Row.IsNull("rest_hrs") ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                    for (int i = 0; i < DT1.Columns.Count; i++)
                    {
                        if (DT1.Rows[0][i].ToString() != "")
                            aRow[DT1.Rows[0][i].ToString()] = (Row.IsNull("ot_Fld" + (i + 1))) ? 0 : decimal.Parse(Row["ot_Fld" + (i + 1)].ToString());

                    }
                    ExporDt.Rows.Add(aRow);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        public static void Get_Ot(DataTable DT_ota, DataTable DT_title)
        {
            DataTable rq_title = new DataTable();
            rq_title.Columns.Add("rate", typeof(decimal));
            rq_title.PrimaryKey = new DataColumn[] { rq_title.Columns["rate"] };
            DataTable DT_ot = new DataTable();
            DT_ot.Columns.Add("nobr", typeof(string));
            DT_ot.Columns.Add("rate", typeof(decimal));
            DT_ot.Columns.Add("othrs", typeof(decimal));
            DT_ot.PrimaryKey = new DataColumn[] { DT_ot.Columns["nobr"], DT_ot.Columns["rate"] };
            foreach (DataRow Row in DT_ota.Select("", "nobr,bdate asc"))
            {
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
                        DT_ot.Rows.Add(aRow);
                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_w_100"].ToString()));
                    if (row2 == null && decimal.Parse(Row["not_w_100"].ToString()) > 0)
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_w_100"].ToString());
                        rq_title.Rows.Add(aRow1);
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
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_w_133"].ToString()));
                    if (row2 == null && (decimal.Parse(Row["not_w_133"].ToString()) > 0 || decimal.Parse(Row["tot_w_133"].ToString()) > 0))
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_w_133"].ToString());
                        rq_title.Rows.Add(aRow1);
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
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_w_167"].ToString()));
                    if (row2 == null && (decimal.Parse(Row["not_w_167"].ToString()) > 0 || decimal.Parse(Row["tot_w_167"].ToString()) > 0))
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_w_167"].ToString());
                        rq_title.Rows.Add(aRow1);
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
                        aRow["othrs"] = decimal.Parse(Row["not_w_200"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_w_200"].ToString()));
                    if (row2 == null && (decimal.Parse(Row["not_w_200"].ToString()) > 0 || decimal.Parse(Row["tot_w_200"].ToString()) > 0))
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_w_200"].ToString());
                        rq_title.Rows.Add(aRow1);
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
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_h_133"].ToString()));
                    if (row2 == null && decimal.Parse(Row["not_h_133"].ToString()) > 0)
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_h_133"].ToString());
                        rq_title.Rows.Add(aRow1);
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
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_h_167"].ToString()));
                    if (row2 == null && decimal.Parse(Row["not_h_167"].ToString()) > 0)
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_h_167"].ToString());
                        rq_title.Rows.Add(aRow1);
                    }
                }
                if (decimal.Parse(Row["nop_h_200"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_200"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_200"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_200"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_200"].ToString());
                        DT_ot.Rows.Add(aRow);

                    }
                    DataRow row2 = rq_title.Rows.Find(decimal.Parse(Row["nop_h_200"].ToString()));
                    if (row2 == null && decimal.Parse(Row["nop_h_200"].ToString()) > 0)
                    {
                        DataRow aRow1 = rq_title.NewRow();
                        aRow1["rate"] = decimal.Parse(Row["nop_h_200"].ToString());
                        rq_title.Rows.Add(aRow1);
                    }
                }

                int _i = 1;
                foreach (DataRow Row1 in DT_ot.Select("othrs>0", "rate asc"))
                {
                    Row["Fldt" + _i] = Row1["rate"].ToString();
                    Row["Fld" + _i] = decimal.Parse(Row1["othrs"].ToString());
                    _i += 1;
                }
                DT_ot.Clear();
            }

            foreach (DataRow Row in rq_title.Select("", "rate asc"))
            {
                DT_title.ImportRow(Row);
            }
            rq_title = null;
        }
       
    }
}
