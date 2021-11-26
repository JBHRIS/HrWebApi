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
    public partial class ZZ2K_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, date_b, date_e, type_data, username, comp_name;
        bool exportexcel;
        public ZZ2K_Report(string nobrb, string nobre, string empb, string empe, string deptb, string depte, string dateb, string datee, string typedata, string _username, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; emp_b = empb; emp_e = empe; dept_b = deptb; dept_e = depte;
            date_b = dateb; date_e = datee; type_data = typedata; username = _username;
            exportexcel = _exportexcel; comp_name = compname;
        }

        private void ZZ2K_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string CmdBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,d.d_no_disp as depts,d.d_name as ds_name ";
                CmdBase += " from base a,basetts b ";
                CmdBase += " left outer join dept c on b.dept=c.d_no";
                CmdBase += " left outer join depts d on b.depts=d.d_no";
                CmdBase += " where a.nobr=b.nobr";
                CmdBase += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);                
                CmdBase += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);               
                CmdBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);               
                CmdBase += type_data;
                CmdBase += " order by b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(CmdBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string CmdRoteChg = "select a.nobr,a.adate,b.rote_disp as rote,a.code from rotechg a,rote b";
                CmdRoteChg += " where a.rote=b.rote";
                CmdRoteChg += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdRoteChg += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                CmdRoteChg += " order by a.nobr,a.adate";
                DataTable rq_rotechg = SqlConn.GetDataTable(CmdRoteChg);

                DataTable rq_zz2k = new DataTable();
                rq_zz2k = ds.Tables["zz2k"].Clone();

                foreach (DataRow Row in rq_rotechg.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz2k.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["depts"] = row["depts"].ToString();
                        aRow["ds_name"] = row["ds_name"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["rote"] = Row["rote"].ToString();
                        aRow["code"] = Row["code"].ToString();
                        rq_zz2k.Rows.Add(aRow);
                    }
                }

                DataRow [] SRow = rq_zz2k.Select("", "dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz2k"].ImportRow(Row);
                }

                if (ds.Tables["zz2k"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_base = null; rq_rotechg = null; rq_zz2k = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz2k"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");                   
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");

                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2k.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2k", ds.Tables["zz2k"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    RptViewer.ZoomPercent =100;
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
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("成本部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("員工英文姓名", typeof(string));
            ExporDt.Columns.Add("調班時間", typeof(DateTime));
            ExporDt.Columns.Add("班表", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["成本部門"] = Row["depts"].ToString();
                aRow["成本部門名稱"] = Row["ds_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_e"].ToString();
                aRow["員工英文姓名"] = Row["name_c"].ToString();
                aRow["調班時間"] = DateTime.Parse(Row["adate"].ToString());
                aRow["班表"] = Row["rote"].ToString();
                aRow["備註"] = Row["code"].ToString(); 
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
