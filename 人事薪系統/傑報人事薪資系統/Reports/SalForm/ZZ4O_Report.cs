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
    public partial class ZZ4O_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, date_b, comp_name, CompId;
        string reporttype, yymm_b, yymm_e, work_b, work_e, emp_b, emp_e, workadr;
        bool exportexcel;
        string ErrorMessage = string.Empty;
        public ZZ4O_Report(string nobrb, string nobre, string yearb, string yeare, string _mb, string _me, string _seb, string _see, string deptb, string depte, string deptsb, string deptse, string workb, string worke, string empb, string empe, string dateb, string _typedata, bool _excelexport, string _workadr, string _reporttype)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year_b = yearb; year_e = yeare; month_b = _mb;
            month_e = _me; seq_b = _seb; seq_e = _see; dept_b = deptb; dept_e = depte;
            yymm_b = year_b + month_b; yymm_e = year_e + month_e; type_data = _typedata;
            exportexcel = _excelexport; date_b = dateb; workadr = _workadr;
            depts_b = deptsb; depts_e = deptse; emp_b = empb; emp_e = empe;
            reporttype = _reporttype; work_b = workb; work_e = worke;
        }

        private void ZZ4O_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4O", MainForm.COMPANY);

                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_e = JBHR.Reports.ReportClass.GetSalEDate(year_e, month_e);
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.oudt,a.idno";
                sqlCmd += ",e.job_disp as job ,e.job_name,b.retdate,b.noret,f.outname,a.sex,a.birdt,h.name as retchoo";
                sqlCmd += "  from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " left outer join outcd f on b.outcd=f.outcd";
                sqlCmd += " left outer join retchoo h on b.retchoo=h.code";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += " and a.count_ma=0 and b.noret=0";
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                sqlCmd = "select b.nobr,b.oudt,f.outname";
                sqlCmd += "  from base a,basetts b";
                sqlCmd += " left outer join outcd f on b.outcd=f.outcd";                
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and b.oudt='{0}'", date_e);
                sqlCmd += " and a.count_ma=0 and b.noret=0";
                sqlCmd += type_data;
                DataTable rq_oudt = SqlConn.GetDataTable(sqlCmd);
                foreach (DataRow Row in rq_oudt.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row!=null)
                    {
                        Row["oudt"] = DateTime.Parse(Row["oudt"].ToString());
                        Row["outname"] = Row["outname"].ToString();
                    }
                }
                rq_oudt = null;

                int Mon = 0;
                int yyb = DateTime.Parse(year_b + "/" + month_b + "/01").Year;
                int yye = DateTime.Parse(year_e + "/" + month_e + "/01").Year;
                if (yye >= yyb)
                {
                    if (yyb == yye)
                    {
                        Mon = DateTime.Parse(year_e + "/" + month_e + "/01").Month - DateTime.Parse(year_b + "/" + month_b + "/01").Month + 1;
                    }
                    else
                    {
                        Mon = DateTime.Parse(year_e + "/" + month_e + "/01").Month - DateTime.Parse(year_b + "/" + month_b + "/01").Month + ((yye - yyb) * 12);
                        //if (Mon > 12)
                        //{
                        //    MessageBox.Show("超出可顯示範團12個月");
                        //    this.Close();
                        //    return;
                        //}
                    }

                }
                else
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

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
                sqlCmd1 += string.Format(@" and saladr between '{0}' and '{1}'", work_b, work_e);                
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
                sqlCmd2 += " and sal_code <> '' ";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_waged.Columns.Add("idno", typeof(string));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("d_ename", typeof(string));
                rq_waged.Columns.Add("job", typeof(string));
                rq_waged.Columns.Add("job_name", typeof(string));
                rq_waged.Columns.Add("retdate", typeof(DateTime));
                rq_waged.Columns.Add("sex", typeof(string));
                rq_waged.Columns.Add("outname", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("tax", typeof(bool));
                rq_waged.Columns.Add("format", typeof(string));
                rq_waged.Columns.Add("indt", typeof(DateTime));
                rq_waged.Columns.Add("oudt", typeof(DateTime));
                rq_waged.Columns.Add("retire", typeof(bool));
                rq_waged.Columns.Add("birdt", typeof(DateTime));
                rq_waged.Columns.Add("retchoo", typeof(string));
                
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
                        //Row["comp"] = row1["comp"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        Row["birdt"] = DateTime.Parse(row["birdt"].ToString());
                        if (!row.IsNull("retdate")) Row["retdate"] =   DateTime.Parse(row["retdate"].ToString());
                        if (!row.IsNull("oudt")) Row["oudt"] = DateTime.Parse(row["oudt"].ToString());
                        Row["idno"] = row["idno"].ToString();
                        Row["outname"] = row["outname"].ToString();
                        Row["retchoo"] = (!row.IsNull("retchoo")) ? row["retchoo"].ToString() : "";
                        Row["sex"] = (row["sex"].ToString().Trim() == "F") ? "女" : "男";
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

                ds.Tables["zz4o"].PrimaryKey = new DataColumn[] { ds.Tables["zz4o"].Columns["nobr"] };
                if (reporttype=="0")
                {
                    //基本薪資
                    string BasicCode = AppConfig.GetConfig("Basic").Value;
                    string OtCode = AppConfig.GetConfig("OT").Value;
                    string sqlCmd5 = "select nobr,sal_code,amt from salbasd ";
                    sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd5 += string.Format(@" and '{0}' between adate and ddate", date_b);
                    DataTable rq_salbasd1 = SqlConn.GetDataTable(sqlCmd5);
                    DataTable rq_salbasd = new DataTable();
                    rq_salbasd.Columns.Add("nobr", typeof(string));
                    rq_salbasd.Columns.Add("amt", typeof(string));
                    rq_salbasd.PrimaryKey = new DataColumn[] { rq_salbasd.Columns["nobr"] };
                    foreach (DataRow Row in rq_salbasd1.Rows)
                    {
                        DataRow row1 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                        if (row1 != null) Row["sal_code"] = row1["sal_code_disp"].ToString();
                        if (BasicCode.Contains(Row["sal_code"].ToString()))
                        {
                            DataRow row = rq_salbasd.Rows.Find(Row["nobr"].ToString());
                            if (row != null)
                                row["amt"] = int.Parse(Row["amt"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            else
                            {
                                DataRow aRow = rq_salbasd.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                rq_salbasd.Rows.Add(aRow);
                            }
                        }
                    }
                    rq_salbasd1 = null;
                    
                    foreach (DataRow Row in rq_waged.Select("","dept,nobr asc"))
                    {
                        DataRow row = ds.Tables["zz4o"].Rows.Find(Row["nobr"].ToString());
                        if (row!=null)
                        {
                            if (BasicCode.Contains(Row["sal_code"].ToString()))
                            {
                                row["A01Amt"] = int.Parse(row["A01Amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            }
                            else if (bool.Parse(Row["retire"].ToString()))
                            {
                                row["RetireAmt"] = int.Parse(row["RetireAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                                if (int.Parse(row["RetireAmt"].ToString()) != 0)
                                    row["AvgAmt"] = Math.Round(decimal.Parse(row["RetireAmt"].ToString()) / Convert.ToDecimal(Mon), MidpointRounding.AwayFromZero);
                            }
                            if (OtCode.Contains(Row["sal_code"].ToString())) row["OtAmt"] = int.Parse(row["OtAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow row1 = rq_salbasd.Rows.Find(Row["nobr"].ToString());
                            DataRow aRow = ds.Tables["zz4o"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["idno"] = Row["idno"].ToString();
                            aRow["sex"] = Row["sex"].ToString();
                            aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                            aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                            if (!Row.IsNull("retdate")) aRow["retdate"] = DateTime.Parse(Row["retdate"].ToString());
                            aRow["BasicAmt"] = (row1 == null) ? 0 : int.Parse(row1["amt"].ToString());
                            aRow["A01Amt"] = 0;
                            aRow["RetireAmt"] = 0;
                            if (BasicCode.Contains(Row["sal_code"].ToString()))
                            {
                                aRow["A01Amt"] = int.Parse(Row["amt"].ToString());
                            }
                            else if (bool.Parse(Row["retire"].ToString()))
                            {
                                aRow["RetireAmt"] = int.Parse(Row["amt"].ToString());                                
                                aRow["AvgAmt"] = Math.Round(decimal.Parse(row1["amt"].ToString()) / Convert.ToDecimal(Mon), MidpointRounding.AwayFromZero);
                            }
                            aRow["OtAmt"] = (OtCode.Contains(Row["sal_code"].ToString())) ? int.Parse(Row["amt"].ToString()) : 0;
                            aRow["retname"] = string.Empty;
                            aRow["retname"] = Row["retchoo"].ToString();
                            ds.Tables["zz4o"].Rows.Add(aRow);
                        }
                    }
                    //DataTable rq_test = new DataTable();
                    //rq_test.Merge(ds.Tables["zz4o"]);
                    //JBHR.Reports.ReportClass.Export(rq_test, this.Name);
                }
                else
                {
                    foreach (DataRow Row in rq_waged.Select("","oudt,nobr asc"))
                    {
                        DataRow row1 = ds.Tables["zz4o"].Rows.Find(Row["nobr"].ToString());
                        if (row1==null)
                        {
                            if (!Row.IsNull("oudt"))
                            {
                                DataRow aRow = ds.Tables["zz4o"].NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = Row["name_c"].ToString();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["idno"] = Row["idno"].ToString();
                                aRow["sex"] = Row["sex"].ToString();
                                aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                                aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                                aRow["oudt"] = DateTime.Parse(Row["oudt"].ToString());
                                aRow["outname"] = Row["outname"].ToString();
                                ds.Tables["zz4o"].Rows.Add(aRow);
                            }
                        }
                    }                    
                }

                if (ds.Tables["zz4o"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    if (reporttype == "0")
                        Export(ds.Tables["zz4o"]);
                    else
                        Export1(ds.Tables["zz4o"]);
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
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4o.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4o1.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", MainForm.COMPANY_NAME) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", MainForm.USER_NAME) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYB", year_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYE", year_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4o", ds.Tables["zz4o"]));
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

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();            
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("性別", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("新制日期", typeof(DateTime));
            ExporDt.Columns.Add("基本月薪資", typeof(int));
            ExporDt.Columns.Add("基本薪資", typeof(int));
            ExporDt.Columns.Add("經常性", typeof(int));
            ExporDt.Columns.Add("平均經常性", typeof(int));
            ExporDt.Columns.Add("加班費", typeof(int));
            ExporDt.Columns.Add("勞退制度", typeof(string));

            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["身分證號"] = Row01["idno"].ToString();
                aRow["性別"] = Row01["sex"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                if (!Row01.IsNull("retdate")) aRow["新制日期"] = DateTime.Parse(Row01["retdate"].ToString());
                aRow["基本月薪資"] = int.Parse(Row01["BasicAmt"].ToString());
                aRow["基本薪資"] = int.Parse(Row01["A01Amt"].ToString());
                aRow["經常性"] = int.Parse(Row01["RetireAmt"].ToString());
                aRow["平均經常性"] = (Row01.IsNull("AvgAmt")) ? 0 : int.Parse(Row01["AvgAmt"].ToString());
                aRow["加班費"] = int.Parse(Row01["OtAmt"].ToString());
                aRow["勞退制度"] = Row01["retname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));            
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("離職日期", typeof(DateTime));
            ExporDt.Columns.Add("離職原因", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["身分證號"] = Row01["idno"].ToString();               
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                aRow["離職日期"] = DateTime.Parse(Row01["oudt"].ToString());
                aRow["離職原因"] = Row01["outname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
