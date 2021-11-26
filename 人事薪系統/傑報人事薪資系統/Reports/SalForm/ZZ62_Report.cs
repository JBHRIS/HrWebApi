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
    public partial class ZZ62_Report : JBControls.JBForm
    {
         SalDataSet ds = new SalDataSet();
         string nobr_b, nobr_e, dept_b, dept_e, yymm_b, yymm_e, seq_b, seq_e, wcode_b, wcode_e, type_data, username, comp_name;
        bool exportexcel;
        public ZZ62_Report(string nobrb, string nobre, string deptb, string depte, string yymmb, string yymme, string seqb, string seqe, string wcodeb, string wcodee, string typedata, string _username, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; yymm_b = yymmb; yymm_e = yymme;
            seq_b = seqb; seq_e = seqe; type_data = typedata; wcode_b = wcodeb; wcode_e = wcodee;
            exportexcel = _exportexcel; username = _username; comp_name = compname;
        }

        private void ZZ62_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string date_b = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Substring(0, 4), yymm_e.Substring(4, 2));
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select c.nobr,a.name_c,a.name_e,d.d_no_disp as dept,d.d_name,d.d_ename,c.sal_code,c.yymm,c.amt,c.d_amt";
                sqlCmd += " from welf c, base a,basetts b left outer join dept d on b.dept=d.d_no";
                sqlCmd += " where c.nobr=a.nobr and a.nobr=b.nobr";
                sqlCmd += string.Format(@"  and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd += string.Format(@" and c.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and c.sal_code between '{0}' and '{1}'", wcode_b, wcode_e);
                sqlCmd += type_data;
                sqlCmd += " order by c.yymm,c.sal_code";
                DataTable rq_welf = SqlConn.GetDataTable(sqlCmd);
                if (rq_welf.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_welf.Columns.Add("w_name", typeof(string));
                DataTable rq_wcode = SqlConn.GetDataTable("select w_code,w_name from wcode");
                rq_wcode.PrimaryKey = new DataColumn[] { rq_wcode.Columns["w_code"] };
                foreach (DataRow Row in rq_welf.Rows)
                {
                    DataRow row = rq_wcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null) Row["w_name"] = row["w_name"].ToString();
                    ds.Tables["zz62"].ImportRow(Row);
                }
                rq_wcode = null;
                rq_welf = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz62"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz62.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmE", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqB", seq_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqE", seq_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz62", ds.Tables["zz62"]));
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
            ExporDt.Columns.Add("部門代號", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("計薪年月", typeof(string));
            ExporDt.Columns.Add("福利代號", typeof(string));
            ExporDt.Columns.Add("福利名稱", typeof(string));            
            ExporDt.Columns.Add("取得金額", typeof(int));
            ExporDt.Columns.Add("扣繳金額", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代號"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["計薪年月"] = Row01["yymm"].ToString();
                aRow["福利代號"] = Row01["sal_code"].ToString();
                aRow["福利名稱"] = Row01["w_name"].ToString();
                aRow["取得金額"] = int.Parse(Row01["amt"].ToString());
                aRow["扣繳金額"] = int.Parse(Row01["d_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
