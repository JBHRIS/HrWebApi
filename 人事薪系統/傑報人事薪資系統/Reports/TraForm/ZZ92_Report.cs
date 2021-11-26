using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.TraForm
{
    public partial class ZZ92_Report : JBControls.JBForm
    {
        TraDataSet ds = new TraDataSet();
        string comp_b, comp_e, dept_b, dept_e, subcode_b, subcode_e, date_b, date_e, type_data, report_type, compname;
        bool exportexcel;
        public ZZ92_Report(string compb, string compe, string deptb, string depte, string subcodeb, string subcodee, string dateb, string datee, string typedata, string reporttype, bool _exportexcel, string _compname)
        {
            InitializeComponent();
            comp_b = compb; comp_e = compe; subcode_b = subcodeb; subcode_e = subcodee; date_b = dateb;
            date_e = datee; type_data = typedata; exportexcel = _exportexcel; dept_b = deptb; dept_e = depte;
            report_type = reporttype; compname = _compname;
        }

        private void ZZ92_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");                
                string sqlCmd = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name,";
                sqlCmd += string.Format(@"dbo.gettotalyears(b.nobr,'{0}') as wk_yrs", date_e);
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += type_data;
                sqlCmd += " and b.ttscode in ('1','4','6')";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select c.nobr as idno,count(c.nobr) cnt,sum(c.st_hrs) tr_hrs,sum(a.cos_fee) as cos_fee";
                sqlCmd1 += " from trcosp c, trcosc a ";
                sqlCmd1 += " left outer join trtype b on a.tr_type=b.tr_type";
                sqlCmd1 += "  where a.guid=c.course ";
                sqlCmd1 += string.Format(@" and a.date_b between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" and b.tr_type_disp between '{0}' and '{1}'", subcode_b, subcode_e);
                sqlCmd1 += " group by c.nobr";
                DataTable rq_trcosf = SqlConn.GetDataTable(sqlCmd1);

                DataTable rq_zz92 = new DataTable();
                rq_zz92 = ds.Tables["zz92"].Clone();
                foreach (DataRow Row in rq_trcosf.Rows)
                {
                    DataRow row=rq_base.Rows.Find(Row["idno"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz92.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["idno"] = Row["idno"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["wk_yrs"] = decimal.Parse(row["wk_yrs"].ToString());
                        aRow["tr_hrs"] = decimal.Parse(Row["tr_hrs"].ToString());
                        aRow["cos_fee"] = decimal.Round(decimal.Parse(Row["cos_fee"].ToString()), 0);
                        aRow["cnt"] = int.Parse(Row["cnt"].ToString());
                        rq_zz92.Rows.Add(aRow);
                    }
                }
                if (rq_zz92.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataRow[] SRow;
                if (report_type == "0")
                    SRow = rq_zz92.Select("", "tr_hrs desc");
                else
                    SRow = rq_zz92.Select("", "cos_fee desc");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz92"].ImportRow(Row);
                }
                rq_base = null; rq_trcosf = null; rq_zz92 = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz92"]);
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
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "TraReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz92.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", compname) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("RportType", report_type) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("TraDataSet_zz92", ds.Tables["zz92"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("年資", typeof(decimal));
            ExporDt.Columns.Add("總時數", typeof(decimal));
            ExporDt.Columns.Add("總費用", typeof(int));
            ExporDt.Columns.Add("課程次數", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["idno"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["職稱代碼"] = Row01["job"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["年資"] = decimal.Parse(Row01["wk_yrs"].ToString());
                aRow["總時數"] = decimal.Parse(Row01["tr_hrs"].ToString());
                aRow["總費用"] = int.Parse(Row01["cos_fee"].ToString());
                aRow["課程次數"] = int.Parse(Row01["cnt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
