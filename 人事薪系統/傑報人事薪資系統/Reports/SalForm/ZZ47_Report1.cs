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
    public partial class ZZ47_Report1 : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, date_b, date_e, salcode_b, salcode_e, work_b, work_e, reporttype;
        string type_data, ttstype, depttype, workadr;
        bool tts_salary, tts_salary1, exportexcel, mangsuper;
        public ZZ47_Report1(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string dateb, string datee, string salcodeb, string salcodee, string workb, string worke, string typedata, string _ttstype, string _depttype, string _workadr, bool ttssalary, bool ttssalary1, bool _exportexcel, bool _mangsuper, string _reporttype)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb; depts_e = deptse; date_b = dateb;
            date_e = datee; salcode_b = salcodeb; salcode_e = salcodee; work_b = workb; work_e = worke; type_data = typedata;
            ttstype = _ttstype; depttype = _depttype; workadr = _workadr; tts_salary = ttssalary; tts_salary1 = ttssalary1;
            exportexcel = _exportexcel; mangsuper = _mangsuper; reporttype = _reporttype;
        }

        private void ZZ47_Report1_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,d.job_disp as job,d.job_name,b.jobl,e.job_name as jobl_name,";
                sqlCmd += "b.dept,c.d_name,b.depts,f.d_name as ds_name";
                sqlCmd += " from base a,basetts b ";
                sqlCmd += " left outer join dept c on b.dept =c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " left outer join jobl e on b.jobl=e.jobl";
                sqlCmd += " left outer join depts f on b.depts =f.d_no";              
                sqlCmd += string.Format(@" where a.nobr=b.nobr and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.indt not between '{0}' and '{1}'", date_b, date_e);
                if (depttype == "1") sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                if (depttype == "2") sqlCmd += string.Format(@" and b.depts between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += type_data;
                if (ttstype == "0") sqlCmd += " and b.ttscode in ('1','4','6')";
                if (workadr != "") sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.adate,a.sal_code,b.sal_ename,a.amt,a.meno from salbasd a,salcode b";
                sqlCmd1 += " where a.sal_code=b.sal_code";
                sqlCmd1 += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.sal_code between '{0}' and '{1}'", salcode_b, salcode_e);                
                sqlCmd1 += " and a.amt<>10 order by a.nobr,a.adate,a.sal_code";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                rq_salbasd.Columns.Add("bamt", typeof(int));
                rq_salbasd.Columns.Add("name_c", typeof(string));
                rq_salbasd.Columns.Add("name_e", typeof(string));
                rq_salbasd.Columns.Add("dept", typeof(string));
                rq_salbasd.Columns.Add("d_name", typeof(string));
                rq_salbasd.Columns.Add("depts", typeof(string));
                rq_salbasd.Columns.Add("ds_name", typeof(string));
                rq_salbasd.Columns.Add("job", typeof(string));
                rq_salbasd.Columns.Add("job_name", typeof(string));                
                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        string _adate = DateTime.Parse(Row["adate"].ToString()).AddDays(-1).ToString("yyyy/MM/dd");
                        string sqlCmd2 = "select nobr,amt from salbasd";
                        sqlCmd2 += string.Format(@" where nobr='{0}' and sal_code='{1}'", Row["nobr"].ToString(), Row["sal_code"].ToString());
                        sqlCmd2 += string.Format(@" and '{0}' between adate and ddate", _adate);
                        DataTable rq_salbasd1 = SqlConn.GetDataTable(sqlCmd2);

                        if (rq_salbasd1.Rows.Count > 0)
                            Row["bamt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(rq_salbasd1.Rows[0]["amt"].ToString()));
                        rq_salbasd1 = null;
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["ds_name"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();                       
                    }
                    else
                        Row.Delete();
                }
                rq_salbasd.AcceptChanges();

                DataRow[] SRow = rq_salbasd.Select("", "adate,dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow aRow = ds.Tables["zz471"].NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["sal_name"] = Row["sal_ename"].ToString();
                    aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    aRow["bamt"] = (Row.IsNull("bamt")) ? 0 : int.Parse(Row["bamt"].ToString());
                    aRow["adjamt"] = int.Parse(aRow["amt"].ToString()) - int.Parse(aRow["bamt"].ToString());
                    aRow["note"] = Row["meno"].ToString();
                    ds.Tables["zz471"].Rows.Add(aRow);
                }
                rq_base = null; rq_salbasd = null;
                if (ds.Tables["zz471"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }   
                if (exportexcel)
                {
                    Export(ds.Tables["zz471"]);
                    this.Close();
                }
                else
                {
                    string company = ""; string JBVersion = "";
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        JBVersion += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz471.rdlc";
                        
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz471", ds.Tables["zz471"]));                    
                        
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
            ExporDt.Columns.Add("Date", typeof(DateTime));
            ExporDt.Columns.Add("Effective Date", typeof(string));
            ExporDt.Columns.Add("Emp.ID", typeof(string));
            ExporDt.Columns.Add("Name-C", typeof(string));
            ExporDt.Columns.Add("Name-E", typeof(string));
            ExporDt.Columns.Add("Dept", typeof(string));
            ExporDt.Columns.Add("Position", typeof(string));            
            ExporDt.Columns.Add("Oracle#", typeof(string));
            //ExporDt.Columns.Add("SalaryName", typeof(string));
            ExporDt.Columns.Add("Befor Salary", typeof(int));
            ExporDt.Columns.Add("Total AdjustAmt", typeof(int));
            ExporDt.Columns.Add("After Salary", typeof(int));
            ExporDt.Columns.Add("Remarks Column", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Date"] = DateTime.Parse(Row01["adate"].ToString());
                aRow["Effective Date"] = Convert.ToString(DateTime.Parse(Row01["adate"].ToString()).Year) + "/" + Convert.ToString(DateTime.Parse(Row01["adate"].ToString()).Month);
                aRow["Emp.ID"] = Row01["nobr"].ToString();
                aRow["Name-C"] = Row01["name_c"].ToString();
                aRow["Name-E"] = Row01["name_e"].ToString();
                aRow["Dept"] = Row01["Dept"].ToString() + Row01["d_name"].ToString();
                aRow["Position"] = Row01["job"].ToString() + Row01["job_name"].ToString();
                aRow["Oracle#"] = Row01["depts"].ToString();
                //aRow["SalaryName"] = Row01["sal_name"].ToString();
                aRow["Befor Salary"] = int.Parse(Row01["bamt"].ToString());
                aRow["Total AdjustAmt"] = int.Parse(Row01["amt"].ToString());
                aRow["After Salary"] = int.Parse(Row01["Adjamt"].ToString());
                aRow["Remarks Column"] = Row01["Note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
