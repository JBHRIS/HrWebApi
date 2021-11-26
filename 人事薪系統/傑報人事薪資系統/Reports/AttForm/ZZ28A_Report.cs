/* ======================================================================================================
 * 功能名稱：出勤工時月報表
 * 功能代號：ZZ28A
 * 功能路徑：報表列印 > 出勤 > 出勤工時月報表
 * 檔案路徑：\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ28A_Report.cs
 * 功能用途：
 * 
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/09    Daniel Chih    Ver 1.0.01     1. 增加條件判斷：薪資群組
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/09
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

namespace JBHR.Reports.AttForm
{
    public partial class ZZ28A_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, job_b, job_e, comp_b, comp_e, date_b, date_e, report_type, type_data, comp_name;
        string saladr_b, saladr_e, type_data1;
        bool exportexcel;
        public ZZ28A_Report(string nobrb, string nobre, string deptb, string depte, string jobb, string jobe, string compb, string compe, string saladrb, string saladre, string dateb, string datee, string typedata, string typedata1, bool export_excel, string reporttype, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; job_b = jobb; job_e = jobe; comp_b = compb; comp_e = compe;
            date_b = dateb; date_e = datee; comp_b = compb; comp_e = compe; exportexcel = export_excel; type_data = typedata; report_type = reporttype;
            saladr_b = saladrb; saladr_e = saladre; comp_name = compname; type_data1 = typedata1;
        }

        private void ZZ28A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                //每日出勤工時
                string CmdAttRote = "select a.nobr,a.adate,c.wk_hrs from attend a,basetts b,base d ,rote c";
                CmdAttRote += " where a.nobr=b.nobr and a.nobr=d.nobr and a.rote=c.rote";
                CmdAttRote += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);
                CmdAttRote += type_data1;
                CmdAttRote += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_rote = SqlConn.GetDataTable(CmdAttRote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["nobr"], rq_rote.Columns["adate"] };

                //出勤
                string sqlAttend = "select b.nobr,b.name_c,b.name_e,b.dept,b.job,b.di,sum(b.wk_hrs) as wk_hrs,0000.00 as tol_hours";
                sqlAttend += ",0000.00 as ot_hrs,0000.00 as rest_hrs";
                sqlAttend += " from attendbasetts b ";
                sqlAttend += " left outer join dept c on b.dept=c.d_no";
                sqlAttend += " left outer join job d on b.job=d.job ";
                sqlAttend += string.Format(@" where b.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlAttend += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlAttend += string.Format(@" and d.job_disp between '{0}' and '{1}'", job_b, job_e);
                //加入【薪資群組】的條件判斷 - Added By Daniel Chih - 2021/03/09
                sqlAttend += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlAttend += type_data;
                sqlAttend += " group by b.nobr,b.name_c,b.name_e,b.dept,b.job,b.di";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                rq_attend.Columns.Add("d_name", typeof(string));
                rq_attend.Columns.Add("job_name", typeof(string));

                //請假
                string sqlAbs = "select b.nobr,b.name_c,b.name_e,b.dept,b.job,b.di,0000.00 as wk_hrs,b.tol_hours";
                sqlAbs += ",0000.00 as ot_hrs,0000.00 as rest_hrs,b.unit,b.rotet,b.bdate";
                sqlAbs += " from absbasetts b";
                sqlAbs += " left outer join dept c on b.dept=c.d_no";
                sqlAbs += " left outer join job d on b.job=d.job ";
                sqlAbs += string.Format(@" where b.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlAbs += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlAbs += string.Format(@" and d.job_disp between '{0}' and '{1}'", job_b, job_e);
                //加入【薪資群組】的條件判斷 - Added By Daniel Chih - 2021/03/09
                sqlAbs += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlAbs += type_data;
                sqlAbs += " and b.flag='-' and b.htype<>'0' and mang <> 1";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);

                //string sqlRote = "select rote,wk_hrs from rote";
                //DataTable rq_rote = SqlConn.GetDataTable(sqlRote);
                //rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

                foreach (DataRow Row in rq_abs.Rows)
                {
                    //DataRow row1 = rq_rote.Rows.Find(Row["rotet"].ToString());
                    Object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["bdate"].ToString();
                    DataRow row1 = rq_rote.Rows.Find(_value);
                    if (row1 != null && Row["unit"].ToString().Trim() == "天")
                        Row["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row1["wk_hrs"].ToString());

                    rq_attend.ImportRow(Row);
                }
                
                rq_abs = null;
                rq_rote = null;

                //加班
                string sqlOt = "select b.nobr,b.name_c,b.name_e,b.dept,b.job,b.di,0000.00 as wk_hrs,0000.00 as tol_hours";
                sqlOt += ",sum(b.ot_hrs) as ot_hrs,sum(b.rest_hrs) as rest_hrs  ";
                sqlOt += " from otbasetts b";
                sqlOt += " left outer join dept c on b.dept=c.d_no";
                sqlOt += " left outer join job d on b.job=d.job ";
                sqlOt += string.Format(@" where b.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlOt += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlOt += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlOt += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlOt += string.Format(@" and d.job_disp between '{0}' and '{1}'", job_b, job_e);
                //加入【薪資群組】的條件判斷 - Added By Daniel Chih - 2021/03/09
                sqlOt += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlOt += type_data;
                sqlOt += " group by b.nobr,b.name_c,b.name_e,b.dept,b.job,b.di";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                foreach (DataRow Row in rq_ot.Rows)
                {
                    rq_attend.ImportRow(Row);
                }
                rq_ot = null;

                string sqlDept = "select d_no,d_no_disp,d_name,d_ename from dept";
                DataTable rq_dept = SqlConn.GetDataTable(sqlDept);
                rq_dept.PrimaryKey = new DataColumn[] { rq_dept.Columns["d_no"] };

                string sqlJob = "select job,job_disp,job_name from job";
                DataTable rq_job = SqlConn.GetDataTable(sqlJob);
                rq_job.PrimaryKey = new DataColumn[] { rq_job.Columns["job"] };

                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_dept.Rows.Find(Row["dept"].ToString());
                    DataRow row1 = rq_job.Rows.Find(Row["job"].ToString());
                    if (row != null)
                    {
                        Row["dept"] = row["d_no_disp"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                    }

                    if (row1 != null)
                    {
                        Row["job"] = row1["job_disp"].ToString();
                        Row["job_name"] = row1["job_name"].ToString();
                    }
                }


                if (report_type == "1")
                {
                    ds.Tables["zz28a"].PrimaryKey = new DataColumn[] { ds.Tables["zz28a"].Columns["nobr"] };
                    DataRow[] rowo = rq_attend.Select("", "dept,nobr asc");
                    foreach (DataRow Row in rowo)
                    {
                        //DataRow row = rq_dept.Rows.Find(Row["dept"].ToString());
                        //DataRow row1 = rq_job.Rows.Find(Row["job"].ToString());
                        DataRow row2 = ds.Tables["zz28a"].Rows.Find(Row["nobr"].ToString());
                        if (row2 != null)
                        {
                            row2["wk_hrs"] = decimal.Parse(row2["wk_hrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                            row2["tol_hours"] = decimal.Round(decimal.Parse(row2["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString()), 2);
                            row2["ot_hrs"] = decimal.Round(decimal.Parse(row2["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                            row2["allhrs"] = decimal.Round(decimal.Parse(row2["wk_hrs"].ToString()) + decimal.Parse(row2["ot_hrs"].ToString()) - decimal.Parse(row2["tol_hours"].ToString()), 2);
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz28a"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            //aRow["d_ename"] = row["d_ename"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();                            
                            //aRow["job"] = Row["job"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                            aRow["job"] = Row["job"].ToString();                           
                            aRow["di"] = Row["di"].ToString();
                            aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                            aRow["tol_hours"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2);
                            aRow["ot_hrs"] = decimal.Round(decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                            aRow["allhrs"] = decimal.Round(decimal.Parse(aRow["wk_hrs"].ToString()) + decimal.Parse(aRow["ot_hrs"].ToString()) - decimal.Parse(aRow["tol_hours"].ToString()), 2);
                            ds.Tables["zz28a"].Rows.Add(aRow);
                        }
                    }

                    if (ds.Tables["zz28a"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (report_type == "2")
                {
                    ds.Tables["zz28a1"].PrimaryKey = new DataColumn[] { ds.Tables["zz28a1"].Columns["dept"] };
                    DataRow[] rowo = rq_attend.Select("", "dept asc");
                    decimal _wkhrs = 0; decimal _tolhrs = 0; decimal _othrs = 0;
                    foreach (DataRow Row in rowo)
                    {
                        _wkhrs = _wkhrs + decimal.Parse(Row["wk_hrs"].ToString());
                        _tolhrs = _tolhrs + decimal.Parse(Row["tol_hours"].ToString());
                        _othrs = _othrs + decimal.Parse(Row["ot_hrs"].ToString());
                        DataRow row = rq_dept.Rows.Find(Row["dept"].ToString());
                        DataRow row1 = ds.Tables["zz28a1"].Rows.Find(Row["dept"].ToString());
                        if (row1 != null)
                        {
                            row1["wk_hrs"] = decimal.Parse(row1["wk_hrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                            row1["tol_hours"] = decimal.Round(decimal.Parse(row1["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString()), 2);
                            row1["ot_hrs"] = decimal.Round(decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                            row1["allhrs"] = decimal.Parse(row1["wk_hrs"].ToString()) + decimal.Parse(row1["ot_hrs"].ToString()) - decimal.Parse(row1["tol_hours"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz28a1"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();                           
                            aRow["d_name"] = Row["d_name"].ToString();                            
                            //aRow["job_name"] = Row["job_name"].ToString();
                            //aRow["job"] = Row["job"].ToString();
                            aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                            aRow["tol_hours"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2);
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                            aRow["allhrs"] = decimal.Round(decimal.Parse(aRow["wk_hrs"].ToString()) + decimal.Parse(aRow["ot_hrs"].ToString()) - decimal.Parse(aRow["tol_hours"].ToString()), 2);
                            ds.Tables["zz28a1"].Rows.Add(aRow);
                        }
                    }
                    foreach (DataRow Row1 in ds.Tables["zz28a1"].Rows)
                    {
                        Row1["wk_pr"] = (decimal.Parse(Row1["wk_hrs"].ToString()) == 0 || _wkhrs == 0) ? 0 : decimal.Round((decimal.Parse(Row1["wk_hrs"].ToString()) / _wkhrs) * 100, 2);
                        Row1["ot_pr"] = (decimal.Parse(Row1["ot_hrs"].ToString()) == 0 || _othrs == 0) ? 0 : decimal.Round((decimal.Parse(Row1["ot_hrs"].ToString()) / _othrs) * 100, 2);
                        Row1["tol_pr"] = (decimal.Parse(Row1["tol_hours"].ToString())==0 || _tolhrs==0) ? 0: decimal.Round((decimal.Parse(Row1["tol_hours"].ToString()) / _tolhrs) * 100, 2);
                        Row1["all_pr"] = (decimal.Parse(Row1["allhrs"].ToString()) == 0 || (_wkhrs + _othrs - _tolhrs) == 0) ? 0 : decimal.Round((decimal.Parse(Row1["allhrs"].ToString()) / (_wkhrs + _othrs - _tolhrs)) * 100, 2);
                    }

                    if (ds.Tables["zz28a1"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (report_type == "3")
                {
                    ds.Tables["zz28a2"].PrimaryKey = new DataColumn[] { ds.Tables["zz28a2"].Columns["dept"] };
                    DataRow[] rowo = rq_attend.Select("", "dept asc");

                    foreach (DataRow Row in rowo)
                    {
                        if (Row["di"].ToString().Trim() == "D" || Row["di"].ToString().Trim() == "I")
                        {
                            //DataRow row = rq_dept.Rows.Find(Row["dept"].ToString());
                            DataRow row1 = ds.Tables["zz28a2"].Rows.Find(Row["dept"].ToString());
                            if (row1 != null)
                            {
                                if (Row["di"].ToString().Trim() == "D")
                                {
                                    row1["d_wkhrs"] = decimal.Parse(row1["d_wkhrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                                    row1["d_tolhrs"] = decimal.Round(decimal.Parse(row1["d_tolhrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString()), 2);
                                    row1["d_othrs"] = decimal.Round(decimal.Parse(row1["d_othrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                                    row1["d_allhrs"] = decimal.Round(decimal.Parse(row1["d_wkhrs"].ToString()) + decimal.Parse(row1["d_othrs"].ToString()) - decimal.Parse(row1["d_tolhrs"].ToString()), 2);
                                }
                                else if (Row["di"].ToString().Trim() == "I")
                                {
                                    row1["i_wkhrs"] = decimal.Parse(row1["i_wkhrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                                    row1["i_tolhrs"] = decimal.Round(decimal.Parse(row1["i_tolhrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString()), 2);
                                    row1["i_othrs"] = decimal.Round(decimal.Parse(row1["i_othrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                                    row1["i_allhrs"] = decimal.Round(decimal.Parse(row1["i_wkhrs"].ToString()) + decimal.Parse(row1["i_othrs"].ToString()) - decimal.Parse(row1["i_tolhrs"].ToString()), 2);
                                }
                                row1["allhrs"] = decimal.Parse(row1["d_allhrs"].ToString()) + decimal.Parse(row1["i_allhrs"].ToString());

                            }
                            else
                            {
                                DataRow aRow = ds.Tables["zz28a2"].NewRow();
                                aRow["dept"] = Row["dept"].ToString();                                
                                aRow["d_name"] = Row["d_name"].ToString();                               
                                aRow["d_wkhrs"] = 0;
                                aRow["d_tolhrs"] = 0;
                                aRow["d_othrs"] = 0;
                                aRow["i_wkhrs"] = 0;
                                aRow["i_tolhrs"] = 0;
                                aRow["i_othrs"] = 0;
                                aRow["d_allhrs"] = 0;
                                aRow["i_allhrs"] = 0;
                                aRow["allhrs"] = 0;
                                if (Row["di"].ToString().Trim() == "D")
                                {
                                    aRow["d_wkhrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                                    aRow["d_tolhrs"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2);
                                    aRow["d_othrs"] = decimal.Round(decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                                    aRow["d_allhrs"] = decimal.Round(decimal.Parse(Row["wk_hrs"].ToString()) + decimal.Parse(aRow["d_othrs"].ToString()) - decimal.Parse(aRow["d_tolhrs"].ToString()), 2);
                                }
                                else if (Row["di"].ToString().Trim() == "I")
                                {
                                    aRow["i_wkhrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                                    aRow["i_tolhrs"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2);
                                    aRow["i_othrs"] = decimal.Round(decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()), 2);
                                    aRow["i_allhrs"] = decimal.Round(decimal.Parse(Row["wk_hrs"].ToString()) + decimal.Parse(aRow["i_othrs"].ToString()) - decimal.Parse(aRow["i_tolhrs"].ToString()), 2);
                                }
                                aRow["allhrs"] = decimal.Round(decimal.Parse(Row["wk_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString()) - decimal.Parse(Row["tol_hours"].ToString()), 2);
                                ds.Tables["zz28a2"].Rows.Add(aRow);
                            }
                        }
                    }

                    if (ds.Tables["zz28a2"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                rq_attend = null; rq_dept = null; rq_job = null;

                if (exportexcel)
                {
                    if (report_type == "1")
                        Export(ds.Tables["zz28a"]);
                    else if (report_type == "2")
                        Export(ds.Tables["zz28a1"]);
                    else if (report_type == "3")
                        Export(ds.Tables["zz28a2"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz28a.rdlc";
                    else if (report_type == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz28a1.rdlc";
                    else if (report_type == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz28a2.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (report_type == "1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz28a", ds.Tables["zz28a"]));
                    else if (report_type == "2")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz28a1", ds.Tables["zz28a1"]));
                    else if (report_type == "3")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz28a2", ds.Tables["zz28a2"]));
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
            if (report_type == "1")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string)); 
                ExporDt.Columns.Add("部門名稱", typeof(string)); 
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("直間接", typeof(string));
                ExporDt.Columns.Add("職稱代碼", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("出勤工時", typeof(Decimal));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("請假時數", typeof(Decimal));
                ExporDt.Columns.Add("總計時數", typeof(Decimal));

                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["直間接"] = Row["di"].ToString();
                    aRow["職稱代碼"] = Row["job"].ToString();
                    aRow["職稱"] = Row["job_name"].ToString();
                    aRow["出勤工時"] = decimal.Parse(Row["wk_hrs"].ToString());
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["總計時數"] = decimal.Parse(Row["allhrs"].ToString());
                    ExporDt.Rows.Add(aRow);
                }
            }
            else if (report_type == "2")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("出勤工時", typeof(Decimal));
                ExporDt.Columns.Add("出勤百分比", typeof(Decimal));
                ExporDt.Columns.Add("加班時數", typeof(decimal));
                ExporDt.Columns.Add("加班百分比", typeof(decimal));
                ExporDt.Columns.Add("請假時數", typeof(Decimal));
                ExporDt.Columns.Add("請假百分比", typeof(Decimal));
                ExporDt.Columns.Add("總計工時", typeof(Decimal));
                ExporDt.Columns.Add("總計百分比", typeof(Decimal));

                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();                    
                    aRow["出勤工時"] = decimal.Parse(Row["wk_hrs"].ToString());
                    aRow["出勤百分比"] = decimal.Parse(Row["wk_pr"].ToString());
                    aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                    aRow["加班百分比"] = decimal.Parse(Row["ot_pr"].ToString());
                    aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["請假百分比"] = decimal.Parse(Row["tol_pr"].ToString());
                    aRow["總計工時"] = decimal.Parse(Row["allhrs"].ToString());
                    aRow["總計百分比"] = decimal.Parse(Row["all_pr"].ToString());
                    ExporDt.Rows.Add(aRow);
                }
            }
            else if (report_type == "3")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));                
                ExporDt.Columns.Add("應計直接", typeof(decimal));
                ExporDt.Columns.Add("應計間接", typeof(decimal));
                ExporDt.Columns.Add("應計小計", typeof(decimal));
                ExporDt.Columns.Add("請假直接", typeof(decimal));
                ExporDt.Columns.Add("請假間接", typeof(decimal));
                ExporDt.Columns.Add("請假小計", typeof(decimal));
                ExporDt.Columns.Add("加班直接", typeof(decimal));
                ExporDt.Columns.Add("加班間接", typeof(decimal));
                ExporDt.Columns.Add("加班小計", typeof(decimal));
                ExporDt.Columns.Add("實際直接", typeof(decimal));
                ExporDt.Columns.Add("實際間接", typeof(decimal));
                ExporDt.Columns.Add("實際小計", typeof(decimal));
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();                    
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();                    
                    aRow["應計直接"] = decimal.Parse(Row["d_wkhrs"].ToString());
                    aRow["應計間接"] = decimal.Parse(Row["i_wkhrs"].ToString());
                    aRow["應計小計"] = decimal.Parse(Row["d_wkhrs"].ToString()) + decimal.Parse(Row["i_wkhrs"].ToString());
                    aRow["請假直接"] = decimal.Parse(Row["d_tolhrs"].ToString());
                    aRow["請假間接"] = decimal.Parse(Row["i_tolhrs"].ToString());
                    aRow["請假小計"] = decimal.Parse(Row["d_tolhrs"].ToString()) + decimal.Parse(Row["i_tolhrs"].ToString());
                    aRow["加班直接"] = decimal.Parse(Row["d_othrs"].ToString());
                    aRow["加班間接"] = decimal.Parse(Row["i_othrs"].ToString());
                    aRow["加班小計"] = decimal.Parse(Row["d_othrs"].ToString()) + decimal.Parse(Row["i_othrs"].ToString());
                    aRow["實際直接"] = decimal.Parse(Row["d_allhrs"].ToString());
                    aRow["實際間接"] = decimal.Parse(Row["i_allhrs"].ToString());
                    aRow["實際小計"] = decimal.Parse(Row["allhrs"].ToString());
                    ExporDt.Rows.Add(aRow);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
