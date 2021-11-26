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
    public partial class ZZ2H4_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, data_report, comp_name;
        bool exportexcel;
        public ZZ2H4_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _compb, string _compe, string _dateb, string _datee, string _typedata, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; date_b = _dateb; date_e = _datee; dept_b = _deptb;
            dept_e = _depte; comp_b = _compb; comp_e = _compe; data_report = _typedata;
            exportexcel = _exportexcel; comp_name = compname;
        }               

        private void ZZ2H4_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlBase += ",d.job_disp as job,d.job_name";
                sqlBase += " from base a,basetts b,dept c,job d ";
                sqlBase += " where a.nobr=b.nobr and b.dept=c.d_no and b.job=d.job";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += " and b.ttscode in('1','4','6')";
                sqlBase += data_report;
                sqlBase += " order by a.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //忘刷
                string sqlAttend = "select nobr,sum(forget) as tol_hours,'F' as h_code from attend";
                sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " and forget > 0 group by nobr ";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);

                //遲到
                string sqlAttend1 = "select nobr,sum(late_mins) as tol_hours,'L' as h_code from attend";
                sqlAttend1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend1 += " and late_mins > 0 group by nobr ";
                DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend1);

                foreach (DataRow Row in rq_attend1.Rows)
                {
                    rq_attend.ImportRow(Row);
                }

                string sqlAbs = "select a.nobr,b.h_code_disp as h_code,sum(a.tol_hours) as tol_hours from abs a";
                sqlAbs += " left outer join hcode b on a.h_code=b.h_code";
                sqlAbs += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += " and b.h_code_disp in ('BA01','CA01')"; //BA01事假,CA01病假
                sqlAbs += " group by a.nobr,b.h_code_disp";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                foreach (DataRow Row in rq_abs.Rows)
                {
                    rq_attend.ImportRow(Row);
                }
                //DataClass.Export_Excel(rq_attend);

                DataTable zz2h4 = new DataTable();
                zz2h4 = ds.Tables["zz2h4"].Clone();
                zz2h4.TableName = "zz2h4";
                zz2h4.Columns.Add("all_hrs", typeof(decimal));
                zz2h4.PrimaryKey = new DataColumn[] { zz2h4.Columns["nobr"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = zz2h4.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (row1 != null)
                        {
                            if (Row["h_code"].ToString().Trim() == "BA01")
                                row1["b_hrs"] = decimal.Parse(Row["tol_hours"].ToString()) + decimal.Parse(row1["b_hrs"].ToString());
                            if (Row["h_code"].ToString().Trim() == "CA01")
                                row1["c_hrs"] = decimal.Parse(Row["tol_hours"].ToString()) + decimal.Parse(row1["c_hrs"].ToString());
                            if (Row["h_code"].ToString().Trim() == "L")
                                row1["l_hrs"] = decimal.Parse(Row["tol_hours"].ToString()) + decimal.Parse(row1["l_hrs"].ToString());
                            if (Row["h_code"].ToString().Trim() == "F")
                                row1["f_hrs"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2) + int.Parse(row1["f_hrs"].ToString());
                            else
                                row1["all_hrs"] = decimal.Parse(row1["all_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                        }
                        else
                        {
                            DataRow aRow = zz2h4.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["d_ename"] = row["d_ename"].ToString();
                            aRow["job"] = row["job"].ToString();
                            aRow["job_name"] = row["job_name"].ToString();
                            aRow["b_hrs"] = (Row["h_code"].ToString().Trim() == "BA01") ? decimal.Parse(Row["tol_hours"].ToString()) : 0;
                            aRow["c_hrs"] = (Row["h_code"].ToString().Trim() == "CA01") ? decimal.Parse(Row["tol_hours"].ToString()) : 0;
                            aRow["l_hrs"] = (Row["h_code"].ToString().Trim() == "L") ? decimal.Parse(Row["tol_hours"].ToString()) : 0;
                            aRow["f_hrs"] = (Row["h_code"].ToString().Trim() == "F") ? decimal.Round(decimal.Parse(Row["tol_hours"].ToString()), 2) : 0;
                            if (Row["h_code"].ToString().Trim() != "F")
                                aRow["all_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                            else
                                aRow["all_hrs"] = 0;
                            zz2h4.Rows.Add(aRow);
                        }
                    }
                }
                rq_abs = null;
                rq_attend = null;
                rq_base = null;

                DataRow[] rowt = zz2h4.Select("", "all_hrs desc");
                foreach (DataRow Row in rowt)
                {
                    ds.Tables["zz2h4"].ImportRow(Row);
                }
                zz2h4 = null;
                if (ds.Tables["zz2h4"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2h4"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h4.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h4", ds.Tables["zz2h4"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("事假時數", typeof(decimal));
            ExporDt.Columns.Add("病假時數", typeof(decimal));
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            ExporDt.Columns.Add("忘刷次數", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["事假時數"] = decimal.Parse(Row["b_hrs"].ToString());
                aRow["病假時數"] = decimal.Parse(Row["c_hrs"].ToString());
                aRow["遲到分鐘"] = decimal.Parse(Row["l_hrs"].ToString());
                aRow["忘刷次數"] = decimal.Round(decimal.Parse(Row["f_hrs"].ToString()), 0);
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
