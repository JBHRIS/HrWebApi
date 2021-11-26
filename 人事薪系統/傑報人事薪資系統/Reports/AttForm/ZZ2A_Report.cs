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
    public partial class ZZ2A_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, emp_b, emp_e, indt, report_type, yy, data_report, comp_name;
        public ZZ2A_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string empb, string empe, string _indt, string reporttype, string _yy, string datareport,string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb;
            date_e = datee; emp_b = empb; emp_e = empe; indt = _indt; report_type = reporttype;
            yy = _yy; data_report = datareport; comp_name = compname;
        }

        private void ZZ2A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name,a.idno,b.cindt,b.wk_yrs";
                sqlCmd += " from base a,basetts b ";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", indt);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += report_type;
                sqlCmd += " and b.ttscode in ('1','4','6') order by b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);

                string sqlCmd1 = "select a.nobr,a.bdate,b.h_code_disp as h_code,sum(a.tol_hours) as tol_day from abs a,hcode b";
                sqlCmd1 += " where a.h_code=b.h_code";
                sqlCmd1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += " and a.tol_hours >0 and b.year_rest=1";
                sqlCmd1 += " group by a.nobr,a.bdate,b.h_code_disp";
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[2];
                _key[0] = ds.Tables["zz2a"].Columns["nobr"];
                _key[1] = ds.Tables["zz2a"].Columns["bdate"];
                ds.Tables["zz2a"].PrimaryKey = _key;
                ds.Tables["zz2a"].PrimaryKey = new DataColumn[] { ds.Tables["zz2a"].Columns["nobr"] };

                foreach (DataRow Row in rq_base.Rows)
                {
                    DataRow[] row = rq_abs.Select("nobr='" + Row["nobr"].ToString() + "' and h_code='W'");
                    DataRow[] row1 = rq_abs.Select("nobr='" + Row["nobr"].ToString() + "' and h_code='W1'");
                    DataRow aRow = ds.Tables["zz2a"].NewRow();
                    aRow["yy"] = yy;
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["cindt"] = DateTime.Parse(Row["cindt"].ToString());
                    aRow["wtolday"] = 0;
                    aRow["month"] = "0";
                    aRow["day"] = "0";
                    aRow["bdate"] = DateTime.Parse("1900/01/01");
                    if (row.Length > 0)
                    {
                        aRow["bdate"] = DateTime.Parse(row[0]["bdate"].ToString());
                        aRow["wtolday"] = decimal.Parse(row[0]["tol_day"].ToString());
                        aRow["month"] = Convert.ToString(DateTime.Parse(row[0]["bdate"].ToString()).Month).PadLeft(2, '0');
                        aRow["day"] = Convert.ToString(DateTime.Parse(row[0]["bdate"].ToString()).Day).PadLeft(2, '0');
                    }
                    aRow["w1tolday"] = 0;
                    if (row1.Length > 0)
                        aRow["w1tolday"] = decimal.Parse(row1[0]["tol_day"].ToString());
                    aRow["alltolday"] = decimal.Parse(aRow["wtolday"].ToString()) + decimal.Parse(aRow["w1tolday"].ToString());

                    ds.Tables["zz2a"].Rows.Add(aRow);
                }

                if (ds.Tables["zz2a"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                RptViewer.Visible = true;
                RptViewer.Reset();
                //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");                
                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2a.rdlc";
                RptViewer.LocalReport.DataSources.Clear();
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2a", ds.Tables["zz2a"]));
                RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                RptViewer.ZoomMode = ZoomMode.FullPage;
                //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
