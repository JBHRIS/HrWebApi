using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ154_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, out_code, type_data, username;
        decimal outday;
        bool exportexcel;
        public ZZ154_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string _outcode, decimal _outday, bool _exportexcel, string typedata, string _username)
        {
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; username = _username;
            outday = _outday; exportexcel = _exportexcel; type_data = typedata; out_code = _outcode;
            InitializeComponent();
        }

        private void ZZ154_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string _adate = DateTime.Parse(date_b).AddDays(-1).ToString("yyyy/MM/dd");
                string sqlCmd = "select a.dept,c.d_name,a.nobr,b.name_c,b.name_e,a.outcd,d.outname,a.meno,";
                sqlCmd += "a.depts,e.job_disp as job,e.job_name,a.jobs,f.job_name as jobs_name,";
                sqlCmd += "g.work_addr,a.is_selfout,a.indt,a.oudt";
                sqlCmd += " from base b,basetts a";
                sqlCmd += " left outer join dept c on c.d_no=a.dept";
                sqlCmd += " left outer join outcd d on a.outcd=d.outcd";
                sqlCmd += " left outer join job e on a.job=e.job";
                sqlCmd += " left outer join jobs f on a.jobs=f.jobs";
                sqlCmd += " left outer join workcd g on a.workcd=g.work_code";
                sqlCmd += " where a.nobr=b.nobr";
                //sqlCmd += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd += string.Format(@" and a.oudt between '{0}' and '{1}'", date_b, date_e);
                sqlCmd += string.Format(@" and a.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and a.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and a.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += type_data;
                sqlCmd += " and a.ttscode='2'";
                DataTable rq_zz153s1 = SqlConn.GetDataTable(sqlCmd);
                foreach (DataRow Row in rq_zz153s1.Rows)
                {
                    ds.Tables["zz154"].ImportRow(Row);
                }
                if (ds.Tables["zz154"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["zz154"]);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");

                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz154.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_zz154", ds.Tables["zz154"]));
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
            ExporDt.Columns.Add("職類名稱", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("到職日", typeof(DateTime));
            ExporDt.Columns.Add("工作地名稱", typeof(string));
            ExporDt.Columns.Add("編制部門", typeof(string));
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("職稱名稱", typeof(string));
            ExporDt.Columns.Add("離職日", typeof(DateTime));
            ExporDt.Columns.Add("離職原因", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            ExporDt.Columns.Add("自願/非自願", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["職類名稱"] = Row["jobs_name"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["到職日"] = DateTime.Parse(Row["indt"].ToString()).ToString("yyyy/MM/dd");
                aRow["工作地名稱"] = Row["work_addr"].ToString();
                aRow["編制部門"] = Row["d_name"].ToString();
                aRow["成本部門"] = Row["depts"].ToString();
                aRow["職稱名稱"] = Row["job_name"].ToString();
                aRow["離職日"] = DateTime.Parse(Row["oudt"].ToString()).ToString("yyyy/MM/dd");
                aRow["離職原因"] = Row["outname"].ToString();
                aRow["備註"] = Row["meno"].ToString();
                aRow["自願/非自願"] = (bool.Parse(Row["is_selfout"].ToString())) ? "自願" : "非自願";
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
