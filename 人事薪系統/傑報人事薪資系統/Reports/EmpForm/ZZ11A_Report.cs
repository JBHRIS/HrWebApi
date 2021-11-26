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
    public partial class ZZ11A_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, nobr_b, nobr_e, dept_b, dept_e, emp_b, emp_e, report_type, data_report, username;     
        bool exportexcel;
        public ZZ11A_Report(string dateb, string datee, string nobrb, string nobre, string deptb, string depte, string empb, string empe, string reporttype, string datareport, string _username, bool _exportexcel)
        {
            InitializeComponent();
             date_b = dateb; date_e = datee; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
             emp_b = empb; emp_e = empe; data_report = datareport;exportexcel = _exportexcel;
             username = _username; report_type = reporttype;
        }

        private void ZZ11A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,a.country,a.birdt,a.sex,a.account_no,b.dept,c.d_name,c.d_ename,";
                sqlCmd += "b.depts,d.d_name as ds_name,b.job,e.job_name,b.jobs,f.job_name as jobs_name,b.indt,b.oudt,b.stoudt";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " left outer join jobs f on b.jobs=f.jobs";                
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (report_type == "0")
                {
                    sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    sqlCmd += " and b.ttscode in ('1','4','6')";
                }
                else if (report_type == "1")
                {
                    sqlCmd += string.Format(@" and b.indt between '{0}' and '{1}'", date_b, date_e);
                    sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                }
                else
                {
                    sqlCmd += string.Format(@" and b.oudt between '{0}' and '{1}'", date_b, date_e);
                    sqlCmd += " and b.ttscode in ('2','5')";
                }
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += " order by b.nobr";                
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);

                DataTable rq_countcd = SqlConn.GetDataTable("select code,descr from countcd");
                rq_countcd.PrimaryKey = new DataColumn[] { rq_countcd.Columns["code"] };
                foreach (DataRow Row in rq_base.Rows)
                {  
                    DataRow aRow = ds.Tables["zz11a"].NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sex"] = Row["sex"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["account_no"] = Row["account_no"].ToString();
                    if (Row.IsNull("country"))
                        aRow["country"] = "";
                    else
                    {
                        DataRow row = rq_countcd.Rows.Find(Row["country"].ToString());
                        aRow["country"] = (row == null) ? "" : row["descr"].ToString();
                    }
                    aRow["birdt"] = DateTime.Parse(Row["birdt"].ToString());
                    aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                    if (report_type == "1")
                    {
                        if (!Row.IsNull("oudt")) aRow["oudt"] = DateTime.Parse(Row["oudt"].ToString());
                    }
                    else if (report_type == "2")
                    {
                        aRow["oudt"] = (Row.IsNull("oudt")) ? DateTime.Parse(Row["stoudt"].ToString()) : DateTime.Parse(Row["oudt"].ToString());
                    }
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();
                    aRow["jobs"] = Row["jobs"].ToString();
                    aRow["jobs_name"] = Row["jobs_name"].ToString();
                    ds.Tables["zz11a"].Rows.Add(aRow);
                }
                if (ds.Tables["zz11a"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_base = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz11a"]);
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
                    if (report_type=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11a1.rdlc";
                    else if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11a2.rdlc";
                    else if (report_type == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11a3.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) }); 
                    if (report_type=="0")
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) }); 
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_zz11a", ds.Tables["zz11a"]));
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
            ExporDt.Columns.Add("Empno", typeof(string));
            ExporDt.Columns.Add("Name", typeof(string));
            ExporDt.Columns.Add("Eng_Name", typeof(string));
            ExporDt.Columns.Add("Sex", typeof(string));
            if (report_type != "0") ExporDt.Columns.Add("Idno", typeof(string));
            if (report_type == "2") ExporDt.Columns.Add("Home", typeof(string));
            if (report_type!="2")   ExporDt.Columns.Add("BirthDate", typeof(DateTime));
            ExporDt.Columns.Add("Hire_Date", typeof(DateTime));
            if (report_type != "0") ExporDt.Columns.Add("Resign_D", typeof(DateTime));
            ExporDt.Columns.Add("Dept", typeof(string));
            ExporDt.Columns.Add("Cost", typeof(string));
            if (report_type != "2") ExporDt.Columns.Add("Cost_Name", typeof(string));
            ExporDt.Columns.Add("Title", typeof(string));
            if (report_type == "1") ExporDt.Columns.Add("Accno", typeof(string));
            ExporDt.Columns.Add("Work", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Empno"] = Row["nobr"].ToString();
                aRow["Name"] = Row["name_c"].ToString();
                aRow["Eng_Name"] = Row["name_e"].ToString();
                aRow["Sex"] = Row["sex"].ToString();
                if (report_type != "0") aRow["Idno"] = Row["idno"].ToString();
                if (report_type == "2") aRow["Home"] = Row["country"].ToString();
                if (report_type != "2") aRow["BirthDate"] = DateTime.Parse(Row["birdt"].ToString());
                aRow["Hire_Date"] = DateTime.Parse(Row["indt"].ToString());
                if (report_type != "0" && !Row.IsNull("oudt")) aRow["Resign_D"] = DateTime.Parse(Row["oudt"].ToString());
                aRow["Dept"] = Row["d_ename"].ToString();
                aRow["Cost"] = Row["depts"].ToString();
                if (report_type != "2") aRow["Cost_Name"] = Row["ds_name"].ToString();
                aRow["Title"] = Row["job_name"].ToString();
                if (report_type == "1") aRow["Accno"] = Row["account_no"].ToString();
                aRow["Work"] = Row["jobs_name"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
