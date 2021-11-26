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
    public partial class ZZ2Z_Report4 : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type;
        string responsibility_b, responsibility_e;
        bool exportexcel;
        public ZZ2Z_Report4(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, string reporttype, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            report_type = reporttype;  exportexcel = _exportexcel; comp_name = compname;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
        }

        private void ZZ2Z_Report4_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,c.d_no_disp as dept,f.rotet_disp as rotet,c.d_name,a.sex,e.jobl_disp as jobl";
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
                sqlBase += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //出勤資料
                string sqlAttend = "select a.nobr,a.adate,b.rote_disp as rote,b.rotename,b.on_time,b.off_time,a.late_mins,a.e_mins,";
                sqlAttend += "a.abs,a.forget,a.night_hrs,a.foodamt,a.nigamt,datename(dw,a.adate) as dw,a.att_hrs,a.specamt";
                sqlAttend += ",dbo.GetContinuousWorkDay(nobr,adate) as wday";
                sqlAttend += " from attend a,rote b";
                sqlAttend += string.Format(@" where a.rote=b.rote and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " and (a.late_mins>0 or a.e_mins>0 or a.forget>0 or abs=1)";
                sqlAttend += " order by a.nobr,a.adate";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                if (rq_attend.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataTable rq_zz2z4 = new DataTable();
                rq_zz2z4 = ds.Tables["zz2z4"].Clone();
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz2z4.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["late_mins"] = decimal.Round(decimal.Parse(Row["late_mins"].ToString()), 0);
                        aRow["e_mins"] = decimal.Round(decimal.Parse(Row["e_mins"].ToString()), 0);
                        aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                        aRow["abs"] = (bool.Parse(Row["abs"].ToString())) ? 1 : 0;
                        rq_zz2z4.Rows.Add(aRow);
                    }
                }
                if (report_type == "5")
                {                   
                    DataRow[] SRow = rq_zz2z4.Select("", "dept,nobr asc");
                    foreach (DataRow Row in SRow)
                    {
                        ds.Tables["zz2z4"].ImportRow(Row);
                    }
                    
                }
                else
                {
                    ds.Tables["zz2z4"].PrimaryKey = new DataColumn[] { ds.Tables["zz2z4"].Columns["nobr"] };
                    DataRow[] SRow1 = rq_zz2z4.Select("", "dept,nobr asc");
                    foreach (DataRow Row in SRow1)
                    {
                        DataRow row1 = ds.Tables["zz2z4"].Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            row1["late_mins"] = int.Parse(row1["late_mins"].ToString()) + decimal.Round(decimal.Parse(Row["late_mins"].ToString()), 0);
                            row1["e_mins"] = int.Parse(row1["e_mins"].ToString()) + decimal.Round(decimal.Parse(Row["e_mins"].ToString()), 0);
                            row1["forget"] = int.Parse(row1["forget"].ToString()) + decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            row1["abs"] = int.Parse(row1["abs"].ToString()) + int.Parse(Row["abs"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz2z4"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow["late_mins"] = decimal.Round(decimal.Parse(Row["late_mins"].ToString()), 0);
                            aRow["e_mins"] = decimal.Round(decimal.Parse(Row["e_mins"].ToString()), 0);
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            aRow["abs"] = int.Parse(Row["abs"].ToString());
                            ds.Tables["zz2z4"].Rows.Add(aRow);
                        }
                    }
                }
                rq_attend = null; rq_base = null; rq_zz2z4 = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz2z4"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _rptpath = jb.module.GetReportDirector(Application.StartupPath, "attendreport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "5")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z8.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z9.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z4", ds.Tables["zz2z4"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.Percent;
                    RptViewer.ZoomPercent = 100;
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            if (report_type == "5") ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            ExporDt.Columns.Add("遲到(分)", typeof(int));
            ExporDt.Columns.Add("早退(分)", typeof(int));
            ExporDt.Columns.Add("忘刷(次)", typeof(int));
            ExporDt.Columns.Add("曠職(次)", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();             
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                if (report_type == "5") aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["遲到(分)"] = int.Parse(Row["late_mins"].ToString());
                aRow["早退(分)"] = int.Parse(Row["e_mins"].ToString());
                aRow["忘刷(次)"] = int.Parse(Row["forget"].ToString());
                aRow["曠職(次)"] = int.Parse(Row["abs"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
