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
    public partial class ZZ71_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, yymm_b, yymm_e, seq_b, seq_e, tcode_b, tcode_e, workadr;
        bool exportexcel;
        public ZZ71_Report(string nobrb, string nobre, string yymmb, string yymme, string seqb, string seqe, string tcodeb, string tcodee, string _workadr, bool _exportexcel)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; yymm_b = yymmb; yymm_e = yymme; seq_b = seqb; seq_e = seqe;
            tcode_b = tcodeb; tcode_e = tcodee; exportexcel = _exportexcel; workadr = _workadr;
        }

        private void ZZ71_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,b.yymm,b.sal_code,c.t_name,b.format,b.ina_id,b.taxno,b.amt,b.d_amt ";
                sqlCmd += "  from tbase a,twaged b";
                sqlCmd += " left outer join tcode c on b.sal_code=c.t_code";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd += string.Format(@" and b.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd += string.Format(@" and b.sal_code between '{0}' and '{1}'", tcode_b, tcode_e);
                sqlCmd += workadr;
                sqlCmd += " order by b.yymm,b.sal_code,b.nobr";
                DataTable rq_twaged = SqlConn.GetDataTable(sqlCmd);
                if (rq_twaged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_twaged.Rows)
                {
                    ds.Tables["zz71"].ImportRow(Row);
                }
                rq_twaged = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz71"]);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz71.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmE", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqB", seq_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqE", seq_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz71", ds.Tables["zz71"]));
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
            ExporDt.Columns.Add("所得人編號", typeof(string));
            ExporDt.Columns.Add("所得人名稱", typeof(string));
            ExporDt.Columns.Add("計薪年月", typeof(string));
            ExporDt.Columns.Add("代號", typeof(string));
            ExporDt.Columns.Add("所得名稱", typeof(string));
            ExporDt.Columns.Add("格式", typeof(string));
            ExporDt.Columns.Add("業別", typeof(string));
            ExporDt.Columns.Add("租賃稅籍編號", typeof(string));
            ExporDt.Columns.Add("取得金額", typeof(int));
            ExporDt.Columns.Add("扣繳金額", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["所得人編號"] = Row01["nobr"].ToString();
                aRow["所得人名稱"] = Row01["name_c"].ToString();
                aRow["計薪年月"] = Row01["yymm"].ToString();
                aRow["代號"] = Row01["sal_code"].ToString();
                aRow["所得名稱"] = Row01["t_name"].ToString();
                aRow["格式"] = Row01["format"].ToString();
                aRow["業別"] = Row01["ina_id"].ToString();
                aRow["租賃稅籍編號"] = Row01["tax_no"].ToString();
                aRow["取得金額"] = int.Parse(Row01["amt"].ToString());
                aRow["扣繳金額"] = int.Parse(Row01["d_amt"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
