/* ======================================================================================================
 * 功能名稱：勞健團保費用分攤
 * 功能代號：ZZ381
 * 功能路徑：報表列印 > 保險 > 勞健團保費用分攤
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\InsForm\ZZ38_Report1.cs
 * 功能用途：
 *  用於產出勞健團保費用分攤資料
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/21    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：只列印有發薪者
 *                                             2. 新增條件欄位：只列印無發薪者
 *                                             3. 重新調整視窗畫面與控制項位置
 * 2021/02/24    Daniel Chih    Ver 1.0.01     1. 增加函式 Waged_Update 用以調整明細分攤資料
 *                                             2. 修改費用計算方式從四捨五入改為小數點後無條件捨去
 *                                             3. 修正 部門彙總 的分攤計算方式
 * 2021/02/25    Daniel Chih    Ver 1.0.03     1. 修改SQL語法，修正無分攤比率的資料被篩掉的問題
 *                                             2. 移除條件欄位：只列印有發薪者
 *                                             3. 移除條件欄位：只列印無發薪者
 * 2021/02/26    Daniel Chih    Ver 1.0.04     1. 移除處理資料前對於 cost 資料表的 join
 * 2021/05/20    Daniel Chih    Ver 1.0.05     1. 修正查詢年月篩選條件以年月迄篩選
 *                                             
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/05/20
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
    public partial class ZZ38_Report1 : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, depts_b, depts_e, date_b, date_e, yy_b, yy_e, seq_b, seq_e, sno_b, sno_e, emp_b, emp_e, reporttype, typedata, comp_name, CompId, saladr;
        bool exportexcel;
        public ZZ38_Report1(string nobrb, string nobre, string deptsb, string deptse, string dateb, string datee, string yyb, string yye, string seqb, string seqe
            , string snob, string snoe, string empb, string empe, string _reporttype, string _typedata, string _saladr
            , bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb; depts_e = deptse; yy_b = yyb; yy_e = yye;
            seq_b = seqb; seq_e = seqe; sno_b = snob; sno_e = snoe; reporttype = _reporttype;
            //checkbox_print_with_salary_only = _checkbox_print_with_salary_only; checkbox_print_without_salary_only = _checkbox_print_without_salary_only;
            exportexcel = _exportexcel; typedata = _typedata; date_b = dateb; date_e = datee; saladr = _saladr;
            comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
        }

        private void ZZ38_Report1_Load(object sender, EventArgs e)
        {
            try
            {
                //先撈出基本資料檔

                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd_Base = "select b.nobr,a.name_c,a.name_e,c.D_NO_DISP as depts,c.d_name as ds_name,b.di,a.idno,";
                sqlCmd_Base += "b.indt,b.nooldret,b.oudt,b.stoudt,b.stdt,b.ttscode,b.adate,d.salmonth";

                sqlCmd_Base += " from base a inner join basetts b on a.nobr=b.nobr ";

                sqlCmd_Base += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);
                sqlCmd_Base += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd_Base += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);

                ////只列印有發薪者
                //if (checkbox_print_with_salary_only)
                //{
                //    sqlCmd_Base += string.Format(@" INNER JOIN WAGE E ON B.NOBR = E.NOBR AND E.YYMM BETWEEN '{0}' AND '{1}' ", yy_b, yy_e);
                //}
                ////只列印無發薪者
                //if (checkbox_print_without_salary_only)
                //{
                //    sqlCmd_Base += " INNER JOIN EXPLAB F ON B.NOBR = F.NOBR ";
                //    sqlCmd_Base += string.Format(@" AND F.NOBR NOT IN(SELECT NOBR FROM WAGE WHERE YYMM BETWEEN '{0}' AND '{1}') ", yy_b, yy_e);
                //}

                //sqlCmd_Base += " left outer join cost co on b.nobr = co.nobr ";
                //sqlCmd_Base += string.Format(@" and '{0}' between co.cadate and co.cddate ", date_b);
                sqlCmd_Base += " left outer join depts c on b.depts=c.d_no";
                //sqlCmd_Base += " left outer join depts cc on co.depts=cc.d_no";
                sqlCmd_Base += " left outer join u_sys2 d on b.comp=d.comp";

                sqlCmd_Base += " where 1 = 1 ";
                //sqlCmd_Base += string.Format(@" and (cc.D_NO_DISP between '{0}' and '{1}' ", depts_b, depts_e);

                sqlCmd_Base += string.Format(@" AND c.D_NO_DISP between '{0}' and '{1}' ", depts_b, depts_e);

                sqlCmd_Base += typedata;
                sqlCmd_Base += " GROUP BY B.NOBR,A.NAME_C,A.NAME_E,C.D_NO_DISP,C.D_NAME,B.DI,A.IDNO,B.INDT,B.NOOLDRET,B.OUDT,B.STOUDT,B.STDT,B.TTSCODE,B.ADATE,D.SALMONTH ";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd_Base);
                rq_base.Columns.Add("saldate", typeof(DateTime));
                rq_base.Columns.Add("wkday", typeof(int));
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"], rq_base.Columns["depts"] };


                foreach (DataRow Row in rq_base.Rows)
                {
                    Row["wkday"] = 30;
                    //Row["saldate"] = DateTime.Parse(yy_e.Substring(0, 4) + "/" + yy_b.Substring(4, 2) + "/01").AddDays(int.Parse(Row["salmonth"].ToString()) - 2).AddMonths(-1);
                    int _day = Convert.ToDateTime(yy_e.Substring(0, 4) + "/" + yy_b.Substring(4, 2) + "/01").AddMonths(1).AddDays(-1).Day;
                    int attday = int.Parse(Row["salmonth"].ToString());
                    if (attday > _day)
                        attday = _day;
                    Row["saldate"] = Convert.ToDateTime(yy_e.Substring(0, 4) + "/" + yy_b.Substring(4, 2) + "/01").AddDays(attday).AddDays(-1).ToString("yyyy/MM/dd");
                    Row["saldate"] = DateTime.Parse(Row["saldate"].ToString()).AddDays(1).AddMonths(-1);

                    if (Row["ttscode"].ToString().Trim() == "2")
                    {
                        if (decimal.Parse(DateTime.Parse(Row["oudt"].ToString()).ToString("yyyyMMdd")) < decimal.Parse(DateTime.Parse(Row["saldate"].ToString()).ToString("yyyyMMdd")))
                            Row["wkday"] = 0;
                        else
                            Row["wkday"] = ((TimeSpan)(DateTime.Parse(Row["oudt"].ToString()) - DateTime.Parse(Row["saldate"].ToString()))).Days + 1;
                    }
                    else if (Row["ttscode"].ToString().Trim() == "3")
                    {
                        if (decimal.Parse(DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd")) < decimal.Parse(DateTime.Parse(Row["saldate"].ToString()).ToString("yyyyMMdd")))
                            Row["wkday"] = 0;
                        else
                            Row["wkday"] = ((TimeSpan)(DateTime.Parse(Row["stdt"].ToString()) - DateTime.Parse(Row["saldate"].ToString()))).Days + 1;
                    }
                    else if (Row["ttscode"].ToString().Trim() == "5")
                    {
                        if (decimal.Parse(DateTime.Parse(Row["stoudt"].ToString()).ToString("yyyyMMdd")) < decimal.Parse(DateTime.Parse(Row["saldate"].ToString()).ToString("yyyyMMdd")))
                            Row["wkday"] = 0;
                        else
                            Row["wkday"] = ((TimeSpan)(DateTime.Parse(Row["stdt"].ToString()) - DateTime.Parse(Row["saldate"].ToString()))).Days + 1;
                    }
                }
                //rq_base.AcceptChanges();

                //勞、健、團、保費代碼
                DataTable rq_sys4 = SqlConn.GetDataTable("select lsalcode,retsalcode,ljobper,ljobper1,retirerate,retirerate1 from u_sys4 where comp='" + CompId + "'");
                DataTable rq_sys5 = SqlConn.GetDataTable("select hsalcode from u_sys5 where comp='" + CompId + "'");
                DataTable rq_sys6 = SqlConn.GetDataTable("select groupsalcd from u_sys6 where comp='" + CompId + "'");
                string lsalcode = ""; string retsalcode = "";
                //年節提撥比率
                decimal ljobper = 0; decimal ljobper1 = 0; decimal retirerate = 0; decimal retirerate1 = 0;
                if (rq_sys4.Rows.Count > 0)
                {
                    lsalcode = rq_sys4.Rows[0]["lsalcode"].ToString();
                    retsalcode = rq_sys4.Rows[0]["retsalcode"].ToString();
                    ljobper = decimal.Parse(rq_sys4.Rows[0]["ljobper"].ToString());
                    ljobper1 = decimal.Parse(rq_sys4.Rows[0]["ljobper1"].ToString());
                    retirerate = decimal.Parse(rq_sys4.Rows[0]["retirerate"].ToString());
                    retirerate1 = decimal.Parse(rq_sys4.Rows[0]["retirerate1"].ToString());
                }
                string hsalcode = (rq_sys5.Rows.Count > 0) ? rq_sys5.Rows[0]["hsalcode"].ToString() : "";
                string groupsalcd = (rq_sys6.Rows.Count > 0) ? rq_sys6.Rows[0]["groupsalcd"].ToString() : "";

                string sqlCmd3 = "select b.nobr,b.sal_code,b.amt,cd.D_NO_DISP AS DEPTS from wage a inner join waged b on a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq ";
                sqlCmd3 += string.Format(@" and b.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd3 += string.Format(@" and b.yymm between '{0}' and '{1}' ", yy_b, yy_e);
                sqlCmd3 += string.Format(@" and b.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd3 += string.Format(@" and (b.sal_code ='{0}' or b.sal_code ='{1}' or b.sal_code ='{2}' or b.sal_code ='{3}') ", lsalcode, retsalcode, hsalcode, groupsalcd);
                sqlCmd3 += " and b.amt <> 10";

                //sqlCmd3 += string.Format(@" left join cost c on a.nobr = c.nobr and '{0}' between c.cadate and c.cddate", date_b);
                sqlCmd3 += string.Format(@" left join basetts d on a.nobr = d.nobr and '{0}' between d.adate and d.ddate", date_b);
                //sqlCmd3 += " left outer join depts cc on c.depts=cc.d_no";
                sqlCmd3 += " left outer join depts cd on d.depts=cd.d_no";

                sqlCmd3 += " where 1=1";
                sqlCmd3 += saladr;
                DataTable rq_waged1 = SqlConn.GetDataTable(sqlCmd3);
                DataTable rq_waged = new DataTable();
                rq_waged = ds.Tables["zz383"].Clone();
                rq_waged.Columns.Add("wkday", typeof(int));
                rq_waged.Columns.Add("chk", typeof(string));
                rq_waged.PrimaryKey = new DataColumn[] { rq_waged.Columns["nobr"] };
                JBHR.Reports.InsForm.ZZ381Class.GetWaged(rq_waged, rq_waged1, rq_base, lsalcode, hsalcode, retsalcode, groupsalcd);

                //基本薪資計算年節及新舊退金提撥
                //string SqlCmd2 = "select a.nobr,a.sal_code,a.amt";
                //SqlCmd2 += "  from salbasd a, salcode b where a.sal_code=b.sal_code";
                //SqlCmd2 += string.Format(@" and '{0}' between adate and ddate", date_b);
                //SqlCmd2 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //SqlCmd2 += " and (amt<>10 or amt<> 0 and b.oldretire=1)";
                //DataTable rq_salbasda = SqlConn.GetDataTable(SqlCmd2);
                string sqlCmd11 = "select nobr,yymm,seq from wage a";
                sqlCmd11 += string.Format(@" where yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd11 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd11 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd11 += saladr;
                sqlCmd11 += " order by nobr";
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd11);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                string sqlCmd12 = "select a.nobr,a.yymm,a.seq,a.sal_code,a.amt,cd.D_NO_DISP AS DEPTS from waged a ";

                //sqlCmd12 += string.Format(@" left join cost c on a.nobr = c.nobr and '{0}' between c.cadate and c.cddate", date_b);
                sqlCmd12 += string.Format(@" left join basetts d on a.nobr = d.nobr and '{0}' between d.adate and d.ddate", date_b);
                //sqlCmd12 += " left outer join depts cc on c.depts=cc.d_no";
                sqlCmd12 += " left outer join depts cd on d.depts=cd.d_no";

                sqlCmd12 += string.Format(@" where a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd12 += string.Format(@" and yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd12 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd12 += " and sal_code<> '' ";
                sqlCmd12 += " GROUP BY a.nobr,a.yymm,a.seq,a.sal_code,a.amt,cd.D_NO_DISP ";
                sqlCmd12 += " order by nobr";
                DataTable rq_salbasda = SqlConn.GetDataTable(sqlCmd12);
                rq_salbasda.Columns.Add("flag", typeof(string));
                rq_salbasda.Columns.Add("retire", typeof(bool));
                rq_salbasda.Columns.Add("yearpay", typeof(bool));

                string sqlCmd13 = "select a.sal_code,a.sal_code_disp,a.sal_name,b.flag,b.salattr,a.retire,a.yearpay";
                sqlCmd13 += " from salcode a,salattr b";
                sqlCmd13 += " where a.sal_attr=b.salattr ";
                sqlCmd13 += " and (a.yearpay='1' or a.retire='1')";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd13);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                foreach (DataRow Row in rq_salbasda.Rows)
                {
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();

                    object[] base_value = new object[2];
                    base_value[0] = Row["nobr"].ToString();
                    base_value[1] = Row["depts"].ToString();
                    DataRow row = rq_base.Rows.Find(base_value);
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null && row2 != null)
                    {
                        if (row2 != null)
                        {

                            Row["flag"] = row2["flag"].ToString();
                            //Row["salattr"] = row2["salattr"].ToString();
                            Row["retire"] = bool.Parse(row2["retire"].ToString());
                            Row["yearpay"] = bool.Parse(row2["yearpay"].ToString());
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    }
                    else
                        Row.Delete();
                }
                rq_salbasda.AcceptChanges();
                //JBHR.Reports.ReportClass.Export(rq_salbasda, this.Name);
                DataTable rq_salbasd = new DataTable();
                rq_salbasd.Columns.Add("nobr", typeof(string));
                rq_salbasd.Columns.Add("totalret", typeof(int));
                rq_salbasd.Columns.Add("totalbonus", typeof(int));
                rq_salbasd.PrimaryKey = new DataColumn[] { rq_salbasd.Columns["nobr"] };

                JBHR.Reports.InsForm.ZZ381Class.GetSalbasd(rq_salbasd, rq_salbasda, rq_waged, rq_base, retirerate1, retirerate, ljobper1, ljobper);


                //抓取公司負擔資料
                string sqlCmd1 = "select a.nobr,b.s_no_disp as s_no,a.fa_idno,a.exp,a.comp, a.insur_type,a.jobamt,a.fundamt";
                //sqlCmd1 += ", ISNULL(cc.D_NO_DISP,cd.D_NO_DISP) AS DEPTS";
                sqlCmd1 += ", cd.D_NO_DISP AS DEPTS";
                sqlCmd1 += " from explab a left outer join inscomp b on a.s_no=b.s_no";

                //sqlCmd1 += string.Format(@" left join cost c on a.nobr = c.nobr and '{0}' between c.cadate and c.cddate", date_b);
                sqlCmd1 += string.Format(@" left join basetts d on a.nobr = d.nobr and '{0}' between d.adate and d.ddate", date_b);
                //sqlCmd1 += " left outer join depts cc on c.depts=cc.d_no";
                sqlCmd1 += " left outer join depts cd on d.depts=cd.d_no";

                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                sqlCmd1 += " and a.insur_type in ('1','2','4')";
                DataTable rq_explab = SqlConn.GetDataTable(sqlCmd1);

                string sqlCmd2 = "select a.nobr,b.s_no_disp as s_no,a.fa_idno,a.exp,a.comp, a.insur_type,a.jobamt,a.fundamt";
                //sqlCmd2 += ", ISNULL(cc.D_NO_DISP,cd.D_NO_DISP) AS DEPTS";
                sqlCmd2 += ", cd.D_NO_DISP AS DEPTS";
                sqlCmd2 += " from explab a left outer join inscomp b on a.s_no=b.s_no";

                //sqlCmd2 += string.Format(@" left join cost c on a.nobr = c.nobr and '{0}' between c.cadate and c.cddate", date_b);
                sqlCmd2 += string.Format(@" left join basetts d on a.nobr = d.nobr and '{0}' between d.adate and d.ddate", date_b);
                //sqlCmd2 += " left outer join depts cc on c.depts=cc.d_no";
                sqlCmd2 += " left outer join depts cd on d.depts=cd.d_no";

                sqlCmd2 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and a.yymm between '{0}' and '{1}'", yy_b, yy_e);
                sqlCmd2 += " and a.insur_type='3'";
                DataTable rq_explab2 = SqlConn.GetDataTable(sqlCmd2);
                rq_explab.Merge(rq_explab2);




                JBHR.Reports.InsForm.ZZ381Class.GetWaged1(rq_waged, rq_explab, rq_salbasd, rq_base);


                DataRow[] Srow = rq_waged.Select("chk='1'", "depts,nobr asc");
                foreach (DataRow Row in Srow)
                {
                    ds.Tables["zz383"].ImportRow(Row);
                }
                if (ds.Tables["zz383"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }



                //設定 costLList 資料內容
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var costLList = (from a in db.COST
                                 where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                                 && a.CADATE <= Convert.ToDateTime(date_b) && a.CDDATE >= Convert.ToDateTime(date_b)
                                 select a).ToList();

                //宣告 Result_Data_Table 用以存取最後要印的資料結果
                DataTable Result_Data_Table = new DataTable();

                //處理資料，將資料塞入 Result_Data_Table
                JBHR.Reports.InsForm.ZZ381Class.Waged_Update(ds.Tables["zz383"], costLList, Result_Data_Table);

                //清空原本資料表
                ds.Tables["zz383"].Clear();
                //將處理過的資料塞回原本資料表
                ds.Tables["zz383"].Merge(Result_Data_Table);

                if (reporttype == "1")
                {

                    rq_waged.Columns.Add("pno", typeof(decimal));

                    //產出【部門彙總】資料內容
                    JBHR.Reports.InsForm.ZZ381Class.Get_Dept_Total(ds.Tables["zz383"], ds.Tables["zz384"]);//rq_waged,
                    DataTable rq_test = new DataTable();
                    rq_test.Merge(ds.Tables["zz384"]);
                    if (ds.Tables["zz384"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }

                rq_base = null; rq_waged = null; rq_waged1 = null; rq_explab = null; rq_salbasd = null;
                rq_explab2 = null; rq_sys4 = null; rq_sys5 = null; rq_sys6 = null; rq_salbasda = null;

                if (exportexcel)
                {
                    if (reporttype == "0")
                    {
                        JBHR.Reports.InsForm.ZZ381Class.Export(ds.Tables["zz383"], this.Name);
                    }
                    else
                    {
                        JBHR.Reports.InsForm.ZZ381Class.Export1(ds.Tables["zz384"], this.Name);
                    }
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
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz384.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz385.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", yy_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", yy_e) });
                    if (reporttype == "0")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz383", ds.Tables["zz383"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz384", ds.Tables["zz384"]));
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
    }
}

