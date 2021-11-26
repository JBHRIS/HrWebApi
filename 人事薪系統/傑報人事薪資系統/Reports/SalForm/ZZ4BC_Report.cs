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
    public partial class ZZ4BC_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, depts_b, depts_e, comp_b, comp_e, date_b, comp_name, CompId;
        string reporttype, yymm_b, yymm_e, work_b, work_e, emp_b, emp_e, workadr, workadr1, username, MedianMon;
        bool exportexcel;
        string ErrorMessage = string.Empty;
        public ZZ4BC_Report(string nobrb, string nobre, string yearb, string yeare, string _mb, string _me, string _seb, string _see, string deptsb, string deptse, string _typedata, bool _excelexport, string dateb, string _workadr)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year_b = yearb; year_e = yeare; month_b = _mb;
            month_e = _me; seq_b = _seb; seq_e = _see; depts_b = deptsb; depts_e = deptse;
            yymm_b = year_b + month_b; yymm_e = year_e + month_e; type_data = _typedata;
            exportexcel = _excelexport; date_b = dateb; workadr = _workadr;
        }

        private void ZZ4BC_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4BC", MainForm.COMPANY);

                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_e = JBHR.Reports.ReportClass.GetSalEDate(year_e, month_e);
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,b.indt,b.oudt,a.idno";
                sqlCmd += ",e.job_disp as job ,e.job_name,b.retdate,b.noret,b.di,b.retchoo";
                sqlCmd += "  from base a,basetts b";                
                sqlCmd += " left outer join depts c on b.depts=c.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                //薪資代碼
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,a.sal_name,a.forcash,a.notfreq,b.salattr,b.flag,b.tax,a.retire";
                sqlCmd3 += " from salcode a,salattr b";
                sqlCmd3 += " where a.sal_attr=b.salattr ";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //勞退
                DataTable rq_sys41 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + MainForm.COMPANY + "'");
                string retsalcode = "";
                if (rq_sys41.Rows.Count > 0)
                {
                    DataRow row1 = rq_salcode.Rows.Find(rq_sys41.Rows[0]["retsalcode"].ToString());
                    if (row1 != null)
                        retsalcode = row1["sal_code_disp"].ToString();
                }
                //發薪主檔
                string sqlCmd1 = "select nobr,yymm,seq,comp from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                //sqlCmd1 += string.Format(@" and saladr between '{0}' and '{1}'", work_b, work_e);
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
                sqlCmd2 += " and sal_code <> '' and amt<>10";
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
                rq_waged.Columns.Add("job", typeof(string));
                rq_waged.Columns.Add("job_name", typeof(string));
                rq_waged.Columns.Add("retdate", typeof(DateTime));                
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("tax", typeof(bool));                
                rq_waged.Columns.Add("indt", typeof(DateTime));
                rq_waged.Columns.Add("oudt", typeof(DateTime));
                rq_waged.Columns.Add("retire", typeof(bool));
                rq_waged.Columns.Add("birdt", typeof(DateTime));
                rq_waged.Columns.Add("retchoo", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("noret", typeof(bool));

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
                        //Row["comp"] = row1["comp"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());                        
                        if (!row.IsNull("retdate")) Row["retdate"] = DateTime.Parse(row["retdate"].ToString());
                        if (!row.IsNull("oudt")) Row["oudt"] = DateTime.Parse(row["oudt"].ToString());
                        Row["di"] = row["di"].ToString();
                        Row["retchoo"] = (!row.IsNull("retchoo")) ? row["retchoo"].ToString() : "";
                        Row["noret"] = bool.Parse(row["noret"].ToString());
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["flag"] = row2["flag"].ToString();
                            Row["tax"] = bool.Parse(row2["tax"].ToString());
                            Row["retire"] = bool.Parse(row2["retire"].ToString());
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

                //提撥比率
                DataTable rq_usys4 = SqlConn.GetDataTable("select ljobper,ljobper1,retirerate,retirerate1 from u_sys4 where comp='" + MainForm.COMPANY + "'");
                decimal ljobper = 0; decimal ljobper1 = 0; decimal retirerate = 0; decimal retirerate1 = 0;
                if (rq_usys4.Rows.Count > 0)
                {
                    ljobper = decimal.Parse(rq_usys4.Rows[0]["ljobper"].ToString());
                    ljobper1 = decimal.Parse(rq_usys4.Rows[0]["ljobper1"].ToString());
                    retirerate = decimal.Parse(rq_usys4.Rows[0]["retirerate"].ToString());
                    retirerate1 = decimal.Parse(rq_usys4.Rows[0]["retirerate1"].ToString());
                }

                //伙食代碼
                string foodcode = AppConfig.GetConfig("FoodCode").Value;
                DataTable rq_zz4bc = new DataTable();
                rq_zz4bc.Columns.Add("dept", typeof(string));
                rq_zz4bc.Columns.Add("d_name", typeof(string));
                rq_zz4bc.Columns.Add("nobr", typeof(string));
                rq_zz4bc.Columns.Add("name_c", typeof(string));
                rq_zz4bc.Columns.Add("yymm", typeof(string));
                rq_zz4bc.Columns.Add("amt", typeof(int));
                rq_zz4bc.Columns.Add("oldamt", typeof(int));
                rq_zz4bc.Columns.Add("foodamt", typeof(int));
                rq_zz4bc.Columns.Add("di", typeof(string));
                rq_zz4bc.Columns.Add("rate", typeof(decimal));
                rq_zz4bc.PrimaryKey = new DataColumn[] { rq_zz4bc.Columns["nobr"], rq_zz4bc.Columns["yymm"] };
                foreach(DataRow Row in rq_waged.Select("salattr<='L'","dept,nobr,yymm asc"))
                {
                    bool noret = bool.Parse(Row["noret"].ToString());
                    bool retire = bool.Parse(Row["retire"].ToString());
                    string salattr = Row["salattr"].ToString();
                    decimal indt = Convert.ToDecimal(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd"));
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    DataRow row = rq_zz4bc.Rows.Find(_value);
                    if (row!=null)
                    {                        
                        if (foodcode.Contains(Row["sal_code"].ToString()))
                            row["foodamt"] = int.Parse(row["foodamt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                            row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        if (retire && !noret && indt<20050701) row["oldamt"] = int.Parse(row["oldamt"].ToString()) + int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_zz4bc.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["di"] = Row["di"].ToString();
                        aRow["amt"] = (foodcode.Contains(Row["sal_code"].ToString())) ? 0 : int.Parse(Row["amt"].ToString());
                        aRow["foodamt"] = (foodcode.Contains(Row["sal_code"].ToString())) ? int.Parse(Row["amt"].ToString()) : 0;
                        if (Row["di"].ToString() == "I")
                            aRow["rate"] = retirerate;
                        else if (Row["di"].ToString() == "D")
                            aRow["rate"] = retirerate1;
                        aRow["oldamt"] = (retire && !noret && indt<20050701) ? int.Parse(Row["amt"].ToString()) : 0;
                        rq_zz4bc.Rows.Add(aRow);
                    }
                }

                //勞健保費用
                string sqlCmd5 = "select nobr,yymm,insur_type,comp from explab ";
                sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);                
                DataTable rq_explab1 = SqlConn.GetDataTable(sqlCmd5);
                DataTable rq_explab = new DataTable();
                rq_explab.Columns.Add("nobr", typeof(string));
                rq_explab.Columns.Add("yymm", typeof(string));
                rq_explab.Columns.Add("lamt", typeof(int));
                rq_explab.Columns.Add("hamt", typeof(int));
                rq_explab.Columns.Add("ramt", typeof(int));
                rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"], rq_explab.Columns["yymm"] };

                foreach(DataRow Row in rq_explab1.Rows)
                {
                    Row["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                    string insurtype = Row["insur_type"].ToString();
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    DataRow row = rq_explab.Rows.Find(_value);
                    if (row!=null)
                    {
                        if (insurtype == "1")
                            row["lamt"] = int.Parse(row["lamt"].ToString()) + int.Parse(Row["comp"].ToString());
                        else if (insurtype == "2")
                            row["hamt"] = int.Parse(row["hamt"].ToString()) + int.Parse(Row["comp"].ToString());
                        else if (insurtype == "4")
                            row["ramt"] = int.Parse(row["ramt"].ToString()) + int.Parse(Row["comp"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_explab.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["lamt"] = 0;
                        aRow["hamt"] = 0;
                        aRow["ramt"] = 0;
                        if (insurtype == "1")
                            aRow["lamt"] =  int.Parse(Row["comp"].ToString());
                        else if (insurtype == "2")
                            aRow["hamt"] =  int.Parse(Row["comp"].ToString());
                        else if (insurtype == "4")
                            aRow["ramt"] = int.Parse(Row["comp"].ToString());
                        rq_explab.Rows.Add(aRow);
                    }
                }

                ds.Tables["zz4bc"].PrimaryKey = new DataColumn[] { ds.Tables["zz4bc"].Columns["nobr"], ds.Tables["zz4bc"].Columns["yymm"] };
                foreach(DataRow Row in rq_zz4bc.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    DataRow row = rq_explab.Rows.Find(_value);
                    DataRow aRow = ds.Tables["zz4bc"].NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    aRow["oldramt"] = Math.Round(decimal.Parse(Row["oldamt"].ToString()) * decimal.Parse(Row["rate"].ToString()), 2, MidpointRounding.AwayFromZero);
                    aRow["foodamt"] = int.Parse(Row["foodamt"].ToString());
                    if (row != null)
                    {
                        aRow["lamt"] = int.Parse(row["lamt"].ToString());
                        aRow["hamt"] = int.Parse(row["hamt"].ToString());
                        aRow["ramt"] = int.Parse(row["ramt"].ToString());
                    }
                    else
                    {
                        aRow["lamt"] = 0;
                        aRow["hamt"] = 0;
                        aRow["ramt"] = 0;
                    }
                    ds.Tables["zz4bc"].Rows.Add(aRow);
                }
                if (ds.Tables["zz4bc"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                } 
                if (exportexcel)
                {
                    Export(ds.Tables["zz4bc"]);
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
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4bc.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", MainForm.COMPANY_NAME) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMMB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMME", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQB", seq_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQE", seq_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4bc", ds.Tables["zz4bc"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                } 
                rq_base = null; rq_explab = null; rq_explab = null; rq_explab1 = null; rq_salcode = null; rq_sys41 = null; rq_usys4 = null;
                rq_wage = null; rq_waged = null; rq_zz4bc = null;
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));            
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("計薪年月", typeof(string));            
            ExporDt.Columns.Add("薪資", typeof(int));
            ExporDt.Columns.Add("伙食費", typeof(int));
            ExporDt.Columns.Add("健保費", typeof(int));
            ExporDt.Columns.Add("勞保費", typeof(int));
            ExporDt.Columns.Add("退休金(新制)", typeof(int));
            ExporDt.Columns.Add("退休金(舊制)", typeof(int));

            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();                
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["計薪年月"] = Row01["yymm"].ToString();                
                aRow["薪資"] = int.Parse(Row01["amt"].ToString());
                aRow["伙食費"] = int.Parse(Row01["foodamt"].ToString());
                aRow["健保費"] = int.Parse(Row01["hamt"].ToString());
                aRow["勞保費"] = int.Parse(Row01["lamt"].ToString());
                aRow["退休金(新制)"] = int.Parse(Row01["ramt"].ToString());
                aRow["退休金(舊制)"] = int.Parse(Row01["oldramt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
