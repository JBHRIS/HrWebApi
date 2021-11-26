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
    public partial class ZZ2D_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, yymm_b, yymm_e, data_report, comp_name;
        bool exportexcel;
        public ZZ2D_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string dateb, string yymmb, string yymme, bool _exportexcel, string datareport, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; date_b = dateb; yymm_b = yymmb; yymm_e = yymme;
            comp_b = compb; comp_e = compe; dept_b = deptb; dept_e = depte;
            exportexcel = _exportexcel; data_report = datareport; comp_name = compname;
        }

        private void ZZ2D_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select d.*,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += " from base a,basetts b,dept c,tmtable d";               
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no and a.nobr =d.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and d.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += data_report;
                sqlCmd += " order by c.d_no_disp,d.yymm,a.nobr";
                DataTable rq_zz2d = SqlConn.GetDataTable(sqlCmd);

                DataTable rq_rote = SqlConn.GetDataTable("select rote,rote_disp from rote");
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };
                if (rq_zz2d.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_zz2d.Rows)
                {
                    for (int i = 1; i < 32; i++)
                    {
                        DataRow row = rq_rote.Rows.Find(Row["D" + i].ToString());
                        if (row!=null)
                            Row["D" + i] = row["rote_disp"].ToString();
                    }                       
                    ds.Tables["zz2d"].ImportRow(Row);
                }
                rq_zz2d = null;

                if (exportexcel)
                {                    
                    Export(ds.Tables["zz2d"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");                   
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2d.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", yymm_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2d", ds.Tables["zz2d"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.Percent;
                    RptViewer.ZoomPercent = 100;

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
            ExporDt.Columns.Add("年月", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            for (int i = 1; i < 32; i++)
            {
                ExporDt.Columns.Add("D" + i, typeof(string));
            }

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["年月"] = Row["yymm"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                for (int i = 1; i < 32; i++)
                {
                    aRow["D" + i] = Row["D" + i].ToString();
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
