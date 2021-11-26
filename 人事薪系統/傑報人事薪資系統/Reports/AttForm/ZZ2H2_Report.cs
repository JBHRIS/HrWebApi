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
    public partial class ZZ2H2_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, data_report, report_type, comp_name;
        bool exportexcel;
        public ZZ2H2_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _compb, string _compe, string _dateb, string _datee, string _typedata, bool _exportexcel, string reporttype, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; date_b = _dateb;  date_e = _datee;
            dept_b = _deptb; dept_e = _depte; comp_b = _compb;  comp_e = _compe;
            data_report = _typedata; exportexcel = _exportexcel; report_type = reporttype;
            comp_name = compname;
        } 

        private void ZZ2H2_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name";
                sqlBase += ",c.d_ename,d.job_disp as job,d.job_name,c.dept_tree";
                sqlBase += " from base a,basetts b,dept c,job d ";
                sqlBase += " where a.nobr=b.nobr and b.dept=c.d_no and b.job=d.job";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += data_report;
                sqlBase += " order by a.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlAttend = "";
                if (report_type == "1")
                {
                    sqlAttend = "select nobr,sum(forget) as forget from attend";
                    sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                    sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlAttend += " and forget <> 0 group by nobr order by forget desc";
                }
                else
                {
                    sqlAttend = "select nobr,sum(late_mins) as late_mins,count(late_mins) as la_no from attend";
                    sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                    sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlAttend += " and late_mins <> 0 group by nobr order by la_no desc";
                }
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);

                DataTable rq_order = new DataTable();
                int _i = 1;
                if (report_type == "1")
                {
                    rq_order.Columns.Add("forget", typeof(decimal));
                    rq_order.Columns.Add("position", typeof(int));
                    rq_order.PrimaryKey = new DataColumn[] { rq_order.Columns["forget"] };
                    foreach (DataRow Row in rq_attend.Rows)
                    {
                        DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            DataRow row = rq_order.Rows.Find(decimal.Parse(Row["forget"].ToString()));
                            if (row == null)
                            {
                                DataRow aRow = rq_order.NewRow();
                                aRow["forget"] = decimal.Parse(Row["forget"].ToString());
                                aRow["position"] = _i;
                                rq_order.Rows.Add(aRow);
                                _i++;
                            }
                        }
                        else
                            Row.Delete();
                    }
                }
                else
                {
                    rq_order.Columns.Add("la_no", typeof(int));
                    rq_order.Columns.Add("position", typeof(int));
                    rq_order.PrimaryKey = new DataColumn[] { rq_order.Columns["la_no"] };
                    foreach (DataRow Row in rq_attend.Rows)
                    {
                        DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            DataRow row = rq_order.Rows.Find(decimal.Parse(Row["la_no"].ToString()));
                            if (row == null)
                            {
                                DataRow aRow = rq_order.NewRow();
                                aRow["la_no"] = int.Parse(Row["la_no"].ToString());
                                aRow["position"] = _i;
                                rq_order.Rows.Add(aRow);
                                _i++;
                            }
                        }
                        else
                            Row.Delete();
                    }
                }
                rq_attend.AcceptChanges();

                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1;
                        DataRow aRow;
                        if (report_type == "1")
                        {
                            row1 = rq_order.Rows.Find(decimal.Parse(Row["forget"].ToString()));
                            aRow = ds.Tables["zz2h2"].NewRow();
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 2);
                        }
                        else
                        {
                            row1 = rq_order.Rows.Find(int.Parse(Row["la_no"].ToString()));
                            aRow = ds.Tables["zz2h3"].NewRow();
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["la_no"] = int.Parse(Row["la_no"].ToString());
                        }
                        DataRow row2 = rq_depttree.Rows.Find(row["dept_tree"].ToString());
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["dept_tree"] = (row2 != null) ? row2["d_no_disp"].ToString().Trim() + " " + row2["d_name"].ToString() : "";
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();

                        if (row1 != null)
                            aRow["position"] = int.Parse(row1["position"].ToString());
                        if (report_type == "1")
                            ds.Tables["zz2h2"].Rows.Add(aRow);
                        else
                            ds.Tables["zz2h3"].Rows.Add(aRow);
                    }
                }

                if (report_type == "1")
                {
                    if (ds.Tables["zz2h2"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    if (ds.Tables["zz2h3"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }

                if (exportexcel)
                {                   
                    if (report_type == "1")
                        Export(ds.Tables["zz2h2"]);
                    else
                        Export(ds.Tables["zz2h3"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h2.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h3.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (report_type == "1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h2", ds.Tables["zz2h2"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h3", ds.Tables["zz2h3"]));
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
            ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            if (report_type == "1")
            {
                ExporDt.Columns.Add("忘刷次數", typeof(decimal));
                ExporDt.Columns.Add("名次", typeof(int));
            }
            else
            {
                ExporDt.Columns.Add("遲到分鐘數", typeof(decimal));
                ExporDt.Columns.Add("遲到次數", typeof(int));
                ExporDt.Columns.Add("名次", typeof(int));
            }

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["報表分析群組"] = Row["dept_tree"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                if (report_type == "1")
                {
                    aRow["忘刷次數"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                    aRow["名次"] = int.Parse(Row["position"].ToString());
                }
                else
                {
                    aRow["遲到分鐘數"] = decimal.Parse(Row["late_mins"].ToString());
                    aRow["遲到次數"] = int.Parse(Row["la_no"].ToString());
                    aRow["名次"] = int.Parse(Row["position"].ToString());
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
