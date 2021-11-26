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
    public partial class ZZ2H8_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, data_report, comp_name;
        bool exportexcel;

        public ZZ2H8_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _compb, string _compe, string _dateb, string _datee, string _typedata, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb;  nobr_e = _nobre;  date_b = _dateb; date_e = _datee;  dept_b = _deptb; dept_e = _depte;
            comp_b = _compb; comp_e = _compe; data_report = _typedata; comp_name = compname;
            exportexcel = _exportexcel;
        }

        private void ZZ2H8_Report_Load(object sender, EventArgs e)
        {

            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlBase += ",d.job_disp as job,d.job_name,b.comp";
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

                string sqlCard = "select a.nobr,a.adate, a.ontime,b.descr,a.meno ";
                sqlCard += "from card a  left outer join  cardlosd b on  a.reason=b.code";
                sqlCard += string.Format(@" where a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlCard += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCard += " and a.los=1";
                DataTable rq_card = SqlConn.GetDataTable(sqlCard);
                DataTable zz2h8 = new DataTable();
                zz2h8 = ds.Tables["zz2h8"].Clone();
                zz2h8.TableName = "zz2h8";

                foreach (DataRow Row in rq_card.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = zz2h8.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["comp"] = row["comp"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["ontime"] = Row["ontime"].ToString();
                        aRow["descr"] = Row["descr"].ToString();
                        aRow["meno"] = Row["meno"].ToString();
                        zz2h8.Rows.Add(aRow);
                    }
                }
                if (zz2h8.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataRow[] row2 = zz2h8.Select("", "comp,dept,nobr,adate asc");
                foreach (DataRow Row in row2)
                {
                    ds.Tables["zz2h8"].ImportRow(Row);
                }
                rq_base = null;
                rq_card = null;
                zz2h8 = null;                

                if (exportexcel)
                {
                    Export(ds.Tables["zz2h8"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h8.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h8", ds.Tables["zz2h8"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("忘刷日期", typeof(DateTime));
            ExporDt.Columns.Add("忘刷時間", typeof(string));
            ExporDt.Columns.Add("忘刷原因", typeof(string));
            ExporDt.Columns.Add("忘刷備註", typeof(string));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["忘刷日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["忘刷時間"] = Row["ontime"].ToString();
                aRow["忘刷原因"] = Row["descr"].ToString();
                aRow["忘刷備註"] = Row["meno"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
