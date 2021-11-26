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
    public partial class ZZ153_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, out_code, type_data, username, comp_name;
        decimal outday;
        bool exportexcel;

        public ZZ153_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string _outcode, decimal _outday, bool _exportexcel, string typedata, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; username = _username;
            outday = _outday; exportexcel = _exportexcel; type_data = typedata; out_code = _outcode;
            comp_name = compname;
        }

        private void ZZ153_Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable rq_zz153s1 = new DataTable();
                rq_zz153s1 = ds.Tables["rq_zz153s1"].Clone();
                rq_zz153s1.TableName = "rq_zz153s1";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string _adate = DateTime.Parse(date_b).AddDays(-1).ToString("yyyy/MM/dd");
                string sqlCmd = "select c.d_no_disp as dept,c.d_name,a.nobr,b.name_c,b.name_e,a.outcd,d.outname,a.meno  from base b,basetts a" +
                    " left outer join dept c on c.d_no=a.dept" +
                    " left outer join outcd d on a.outcd=d.outcd" +
                    " where a.nobr=b.nobr" +
                     " " + type_data + "" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    //" AND A.ADATE BETWEEN '" + _adate + "'AND '" + date_e + "'" +
                    " and A.OUDT BETWEEN '" + date_b + "'AND '" + date_e + "'" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                    
                    " and a.ttscode ='2'";
                rq_zz153s1 = SqlConn.GetDataTable(sqlCmd);
                foreach (DataRow Row in rq_zz153s1.Rows)
                {
                    ds.Tables["rq_zz153s1"].ImportRow(Row);
                }
                rq_zz153s1 = null;
                decimal _acnt = 0;
                DataTable OutDt = new DataTable();
                OutDt.Columns.Add("outcd", typeof(string));
                OutDt.Columns.Add("cnt", typeof(int));
                OutDt.PrimaryKey = new DataColumn[] { OutDt.Columns["outcd"] };
                foreach (DataRow Row in ds.Tables["rq_zz153s1"].Rows)
                {
                    DataRow row = OutDt.Rows.Find(Row["outcd"].ToString());
                    if (row != null)
                        row["cnt"] = decimal.Parse(row["cnt"].ToString()) + 1;
                    else
                    {
                        DataRow aRow = OutDt.NewRow();
                        aRow["outcd"] = Row["outcd"].ToString();
                        aRow["cnt"] = 1;
                        OutDt.Rows.Add(aRow);
                    }
                    _acnt++;
                }

                foreach (DataRow Row in ds.Tables["rq_zz153s1"].Rows)
                {
                    DataRow row = OutDt.Rows.Find(Row["outcd"].ToString());
                    if (row != null)
                        Row["no"] = int.Parse(row["cnt"].ToString());
                    decimal _no = int.Parse(Row["no"].ToString());
                    decimal _per = _no / _acnt;
                    if (int.Parse(Row["no"].ToString()) > 0)
                        Row["per"] = decimal.Round(_per * 100, 2);
                    else
                        Row["per"] = 0;
                }
                if (ds.Tables["rq_zz153s1"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz153s1"]);
                    this.Close();
                }
                else
                {                  
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz153.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz153s1", ds.Tables["rq_zz153s1"]));
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
            ExporDt.Columns.Add("離職原因", typeof(string));
            ExporDt.Columns.Add("件數", typeof(int));
            ExporDt.Columns.Add("原因比率", typeof(decimal));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["離職原因"] = Row["outname"].ToString();
                aRow["件數"] = int.Parse(Row["no"].ToString());
                aRow["原因比率"] = decimal.Parse(Row["per"].ToString());
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["備註"] = Row["meno"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
