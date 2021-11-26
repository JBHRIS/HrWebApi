/* ======================================================================================================
 * 功能名稱：各期薪資報表
 * 功能代號：ZZ46
 * 功能路徑：報表列印 > 薪資 > 各期薪資報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ46_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/15    Daniel Chih    Ver 1.0.01     1. 修改非主管人員的判斷條件
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/15
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

namespace JBHR.Reports.SalForm
{
    public partial class ZZ46_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, dept_b, dept_e, comp_b, comp_e, date_b, comp_name, CompId;
        string reporttype, yymm_b, yymm_e, work_b, work_e, emp_b, emp_e, workadr, workadr1, username, MedianMon;
        bool exportexcel;
        string ErrorMessage = string.Empty;
        public ZZ46_Report(string nobrb, string nobre, string yearb, string yeare, string _mb, string _me, string _seb, string _see, string deptb, string depte, string compb, string compe, string workb, string worke, string empb, string empe, string _typedata, string _reporttype, bool _excelexport, string dateb, string _workadr, string _MedianMon, string _username, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb;   nobr_e = nobre;    year_b = yearb; year_e = yeare; month_b = _mb;
            month_e = _me;  seq_b = _seb; seq_e = _see;dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe;type_data = _typedata; reporttype = _reporttype;
            exportexcel = _excelexport; date_b = dateb; workadr = _workadr;
            work_b = workb; work_e = worke; username = _username; CompId = _CompId;
            yymm_b = year_b + month_b; yymm_e = year_e + month_e; comp_name = compname;
            emp_b = empb; emp_e = empe; MedianMon = _MedianMon;
            //date_b = Convert.ToString(Convert.ToDecimal(year_e) + 1911) + "/" + Convert.ToString(month_e) + "/25";
            //_date = DateTime.Parse(Convert.ToString(decimal.Parse(year_e) + 1911) + "/" + month_e + "/" + "01").AddMonths(1).AddDays(-1);
        }

        private void ZZ46_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_e = JBHR.Reports.ReportClass.GetSalEDate(year_e, month_e);
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.oudt,a.idno,a.addr2";
                sqlCmd += ",b.tax_date,b.tax_edate,c.nobr as mang,e.job_disp as job ,e.job_name";
                sqlCmd += "  from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                //if (workadr != "") sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                //發薪主檔
                string sqlCmd1 = "select nobr,yymm,seq,adate,bankno,account_no,cash,comp,wk_days,note,format from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += string.Format(@" and saladr between '{0}' and '{1}'", work_b, work_e);
                sqlCmd1 += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd1 += string.Format(@" and adate<='{0}' ", date_b);
                sqlCmd1 += workadr;
                sqlCmd1 += " and format <> space(2)";
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _kye = new DataColumn[3];
                _kye[0] = rq_wage.Columns["nobr"];
                _kye[1] = rq_wage.Columns["yymm"];
                _kye[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _kye;

                //發薪明細
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd2 += " and sal_code <> ''";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("d_ename", typeof(string));
                rq_waged.Columns.Add("job", typeof(string));
                rq_waged.Columns.Add("job_name", typeof(string));
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("note", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("tax", typeof(bool));
                rq_waged.Columns.Add("format", typeof(string));
                rq_waged.Columns.Add("adate", typeof(DateTime));
                rq_waged.Columns.Add("tax_date", typeof(DateTime));
                rq_waged.Columns.Add("tax_edate", typeof(DateTime));
                rq_waged.Columns.Add("indt", typeof(DateTime));
                rq_waged.Columns.Add("oudt", typeof(DateTime));
                rq_waged.Columns.Add("notfreq", typeof(bool));
                rq_waged.Columns.Add("mang", typeof(bool));
                rq_waged.Columns.Add("sal_mang", typeof(bool));

                //薪資代碼
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,a.sal_name,a.forcash,a.notfreq,b.salattr,b.flag,b.tax";
                sqlCmd3 += " from salcode a,salattr b";
                sqlCmd3 += " where a.sal_attr=b.salattr";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["d_ename"] = row["d_ename"].ToString();
                        Row["comp"] = row1["comp"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["note"] = row1["note"].ToString();
                        Row["format"] = row1["format"].ToString();
                        Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                        if (!row.IsNull("tax_date")) Row["tax_date"] = DateTime.Parse(row["tax_date"].ToString());
                        if (!row.IsNull("tax_edate")) Row["tax_edate"] = DateTime.Parse(row["tax_edate"].ToString());
                        if (!row.IsNull("indt")) Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        if (!row.IsNull("oudt")) Row["oudt"] = DateTime.Parse(row["oudt"].ToString());

                        if(row["nobr"].ToString() == row["mang"].ToString())
                        {
                            Row["mang"] = bool.Parse("true".ToString().Trim());
                        }
                        else
                        {
                            Row["mang"] = bool.Parse("false".ToString().Trim());
                        }

                        //Row["mang"] = (row.IsNull("mang")) ? bool.Parse("false") : bool.Parse(row["mang"].ToString());
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["flag"] = row2["flag"].ToString();
                            Row["tax"] = bool.Parse(row2["tax"].ToString());
                            Row["notfreq"] = bool.Parse(row2["notfreq"].ToString());
                            Row["sal_mang"] =bool.Parse("False") ;//bool.Parse(row2["manga"].ToString())
                        }
                        else
                        {
                            string ErrorSalcode = "無" + Row["sal_code"].ToString() + "薪資代碼或與會計科目未關聯";
                            MessageBox.Show(ErrorSalcode, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorSalcode);
                            this.Close();
                            return;
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));

                        string ErrorAmt = Row["nobr"].ToString() + " " + Row["name_c"].ToString() + " " + Row["sal_name"].ToString() + " " + Row["amt"].ToString() + " 金額有小數點";
                        int value = 0;
                        if (!int.TryParse(Row["amt"].ToString(), out value))
                        {
                            MessageBox.Show(ErrorAmt, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorAmt);
                            this.Close();
                            return;
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_waged.AcceptChanges();
                //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz46td"], "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");   

               
               
                switch (reporttype)
                {
                    case "0":
                    case "1":
                    case "2":
                        //求得應稅合計金額
                        DataTable rq_wages1 = new DataTable();
                        rq_wages1.Columns.Add("nobr", typeof(string));
                        rq_wages1.Columns.Add("yymm", typeof(string));
                        rq_wages1.Columns.Add("seq", typeof(string));
                        rq_wages1.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ46Class.GetWageds1(rq_wages1, rq_waged);
                        
                        //求得應發合計金額
                        DataTable rq_sys41 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                        string retsalcode = "";
                        if (rq_sys41.Rows.Count > 0)
                        {
                            DataRow row1 = rq_salcode.Rows.Find(rq_sys41.Rows[0]["retsalcode"].ToString());
                            if (row1 != null)
                                retsalcode = row1["sal_code_disp"].ToString();
                        }
                        DataTable rq_wages2 = new DataTable();
                        rq_wages2.Columns.Add("nobr", typeof(string));
                        rq_wages2.Columns.Add("yymm", typeof(string));
                        rq_wages2.Columns.Add("seq", typeof(string));
                        rq_wages2.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ46Class.GetWageds2(rq_wages2, rq_waged, retsalcode);
                        
                        //求得合計金額
                        DataTable rq_wagesz = new DataTable();
                        rq_wagesz.Columns.Add("nobr", typeof(string));
                        rq_wagesz.Columns.Add("yymm", typeof(string));
                        rq_wagesz.Columns.Add("seq", typeof(string));
                        rq_wagesz.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ46Class.GetWagedsz(rq_wagesz, rq_waged);

                        //公司負擔金額
                        string sqlExplab = "select nobr,sal_yymm,insur_type,comp from explab ";
                        sqlExplab += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlExplab += string.Format(@" and sal_yymm between '{0}' and '{1}' and fa_idno=''", yymm_b, yymm_e);
                        DataTable rq_explab1 = SqlConn.GetDataTable(sqlExplab);
                        DataTable rq_explab = new DataTable();
                        rq_explab.Columns.Add("nobr", typeof(string));
                        rq_explab.Columns.Add("yymm", typeof(string));
                        rq_explab.Columns.Add("h_amt", typeof(int));
                        rq_explab.Columns.Add("l_amt", typeof(int));
                        rq_explab.Columns.Add("r_amt", typeof(int));
                        rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"], rq_explab.Columns["yymm"] };
                        JBHR.Reports.SalForm.ZZ46Class.Get_Eplab(rq_explab, rq_explab1);


                        //產生橫向表頭
                        DataTable rq_zz46t = new DataTable();                        
                        rq_zz46t.Columns.Add("sal_code", typeof(string));
                        rq_zz46t.Columns.Add("sal_name", typeof(string));
                        rq_zz46t.PrimaryKey = new DataColumn[] { rq_zz46t.Columns["sal_code"] };
                        JBHR.Reports.SalForm.ZZ46Class.GetZz46t(rq_zz46t, rq_waged, ds.Tables["zz46ta"]);
                        if (reporttype=="2")
                            JBHR.Reports.SalForm.ZZ46Class.GetZz46td1(ds.Tables["zz46td"], ds.Tables["zz46ta"], rq_waged, rq_wages1, rq_wages2, rq_wagesz, rq_explab);
                        else
                            JBHR.Reports.SalForm.ZZ46Class.GetZz46td(ds.Tables["zz46td"], ds.Tables["zz46ta"], rq_waged, rq_wages1, rq_wages2, rq_wagesz, rq_explab);
                        rq_explab = null;rq_explab1=null;
                        
                        if (ds.Tables["zz46td"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                    case "3":
                        DataTable rq_sys4 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                        DataTable rq_sys9 = SqlConn.GetDataTable("select taxsalcode from u_sys9 where comp='" + CompId + "'");           
                        string retsalcode1 = "";string taxsalcode1="";
                        if (rq_sys4.Rows.Count > 0)
                        {
                            DataRow row1 = rq_salcode.Rows.Find(rq_sys4.Rows[0]["retsalcode"].ToString());
                            if (row1 != null)
                                retsalcode1 = row1["sal_code_disp"].ToString().Trim();
                        }

                        if (rq_sys9.Rows.Count > 0)
                        {
                            DataRow row1 = rq_salcode.Rows.Find(rq_sys9.Rows[0]["taxsalcode"].ToString());
                            if (row1 != null)
                                taxsalcode1 = row1["sal_code_disp"].ToString().Trim();
                        }
                        JBHR.Reports.SalForm.ZZ46Class.GetZz463(ds.Tables["zz463"], rq_waged, rq_base, retsalcode1, taxsalcode1);
                        if (ds.Tables["zz463"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        DataTable rq_sys91 = SqlConn.GetDataTable("select taxsalcode from u_sys9 where comp='" + CompId + "'");
                        string taxsalcode2 = "";
                        if (rq_sys91.Rows.Count > 0)
                        {
                            DataRow row1 = rq_salcode.Rows.Find(rq_sys91.Rows[0]["taxsalcode"].ToString());
                            if (row1 != null)
                                taxsalcode2 = row1["sal_code_disp"].ToString().Trim();
                        }
                        DataTable rq_comp = SqlConn.GetDataTable("select comp,compname from comp");
                        rq_comp.PrimaryKey = new DataColumn[] { rq_comp.Columns["comp"] };
                        string sqlCmd4 = "select distinct yymm,seq,meno from lock_wage";
                        sqlCmd4 += string.Format(@" where yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                        sqlCmd4 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                        sqlCmd4 += workadr;
                        DataTable rq_lock = SqlConn.GetDataTable(sqlCmd4);
                        rq_lock.PrimaryKey = new DataColumn[] { rq_lock.Columns["yymm"], rq_lock.Columns["seq"] };
                        JBHR.Reports.SalForm.ZZ46Class.GetZz464(ds.Tables["zz464"], rq_waged, taxsalcode2, rq_lock, rq_comp);
                                           
                        if (ds.Tables["zz464"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        if (reporttype == "5")
                        {
                            JBHR.Reports.SalForm.ZZ46Class.GetZz464a(ds.Tables["zz464a"], ds.Tables["zz464"]);
                            ds.Tables.Remove("zz464");
                        }
                        if (reporttype == "7")
                        {
                            JBHR.Reports.SalForm.ZZ46Class.GetZz464b(ds.Tables["zz464b"], ds.Tables["zz464"]);
                            ds.Tables.Remove("zz464");
                        }
                        break;
                    case "8":
                        JBHR.Reports.SalForm.ZZ46Class.GetZz466(ds.Tables["zz465"], rq_waged, MedianMon);
                        if (ds.Tables["zz465"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;  
                    default:
                        break;
                }
                rq_base = null; rq_salcode = null; rq_wage = null; rq_waged = null;

                if (exportexcel)
                {
                    switch (reporttype)
                    { 
                        case "0":
                        case "2":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort1(ds.Tables["zz46td"], ds.Tables["zz46ta"], this.Name,reporttype);
                            break;
                        case "1":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort2(ds.Tables["zz46td"], ds.Tables["zz46ta"], this.Name, reporttype);
                            break;
                        case "3":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort4(ds.Tables["zz463"], this.Name);
                            break;
                        case "4":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort5(ds.Tables["zz464"], this.Name);
                            break;
                        case "5":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort6(ds.Tables["zz464a"], this.Name);
                            break;
                        case "6":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort7(ds.Tables["zz464"], this.Name);
                            break;
                        case "7":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort8(ds.Tables["zz464b"], this.Name);
                            break;
                        case "8":
                            JBHR.Reports.SalForm.ZZ46Class.ExPort9(ds.Tables["zz465"], this.Name);
                            break;
                        default:
                            break;
                    }
                    //if (reporttype=="0")
                    //    Export(ds.Tables["zz45"]);
                    //else
                    //    Export1(ds.Tables["zz451"]);
                    this.Close();
                }
                else
                {
                    //string company = "";
                    //DataTable rq_sys = ReportClass.GetU_Sys();
                    //if (rq_sys.Rows.Count > 0)
                    //    company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");

                    switch (reporttype)
                    { 
                        case "0":
                        case "1":
                        case "2":
                            if (reporttype=="0")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz461.rdlc";
                            else if (reporttype == "1")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz462.rdlc";
                            else  if (reporttype == "2")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz463.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year_b) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz46ta", ds.Tables["zz46ta"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz46td", ds.Tables["zz46td"]));
                            break;
                        case "3":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz464.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYb", year_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYe", year_e) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqb", seq_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqe", seq_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz463", ds.Tables["zz463"]));
                            break;
                        case "4":
                        case "6":
                            if (reporttype=="4")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz465.rdlc";
                            else
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz467.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqb", seq_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqe", seq_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz464", ds.Tables["zz464"]));
                            break;
                        case "5":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz466.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqb", seq_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqe", seq_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz464a", ds.Tables["zz464a"]));
                            break;
                        case "7":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz468.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmb", yymm_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmme", yymm_e) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqb", seq_b) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seqe", seq_e) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz464b", ds.Tables["zz464b"]));
                            break;
                        default:
                            break;
                    }

                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }
                
               
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }


    }
}
