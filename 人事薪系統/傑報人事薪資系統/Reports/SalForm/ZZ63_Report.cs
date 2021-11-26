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
    public partial class ZZ63_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, yymm_b, yymm_e, seq_b, seq_e, wcode_b, wcode_e, type_data, username, comp_name, CompId;
        bool exportexcel,zone;
        public ZZ63_Report(string nobrb, string nobre, string deptb, string depte, string yymmb, string yymme, string seqb, string seqe, string wcodeb, string wcodee, string typedata, string _username, bool _exportexcel, bool _zone, string compname, string _CompId)
        {
            InitializeComponent();
             nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; yymm_b = yymmb; yymm_e = yymme;
            seq_b = seqb; seq_e = seqe; type_data = typedata; wcode_b = wcodeb; wcode_e = wcodee;
            exportexcel = _exportexcel; username = _username; zone = _zone; comp_name = compname;
            CompId = _CompId;
        }

        private void ZZ63_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_sys2 = SqlConn.GetDataTable("select welsalcode from u_sys2 where comp='" + CompId + "'");
                string welsalcode = (rq_sys2.Rows.Count > 0) ? rq_sys2.Rows[0]["welsalcode"].ToString() : "";

                string sqlCmd = "select a.nobr,a.amt from waged a,wage c";
                sqlCmd += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and a.sal_code='{0}'", welsalcode);
                sqlCmd += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd += string.Format(@" and a.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd += " and a.nobr=c.nobr and a.yymm=c.yymm and a.seq=c.seq";
                sqlCmd += type_data;
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd);
                DataTable rq_wageda = new DataTable();
                rq_wageda.Columns.Add("nobr", typeof(string));
                rq_wageda.Columns.Add("amt", typeof(int));
                rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_wageda.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + Convert.ToInt32(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())));
                    else
                    {
                        DataRow aRow = rq_wageda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["amt"] = Convert.ToInt32(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())));
                        rq_wageda.Rows.Add(aRow);
                    }
                }
                rq_waged = null;

                string date_b = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Substring(0, 4), yymm_e.Substring(4, 2));
                string sqlCmd1 = "select c.nobr,a.name_c,a.name_e,d.d_no_disp as dept,d.d_name,d.d_ename,c.amt,c.d_amt from base a,welf c,basetts b";
                sqlCmd1 += " left outer join dept d on b.dept=d.d_no";
                sqlCmd1 += " where a.nobr=c.nobr and a.nobr=b.nobr ";
                sqlCmd1 += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd1 += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and c.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and c.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += string.Format(@" and c.sal_code between '{0}' and '{1}'", wcode_b, wcode_e);
                sqlCmd1 += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd1 += type_data;
                DataTable rq_welf = SqlConn.GetDataTable(sqlCmd1);
                if (rq_welf.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataTable rq_zz63 = new DataTable();
                rq_zz63 = ds.Tables["zz63"].Clone();
                rq_zz63.TableName = "rq_zz63";
                rq_zz63.PrimaryKey = new DataColumn[] { rq_zz63.Columns["nobr"] };
               
                foreach (DataRow Row in rq_welf.Rows)
                {
                    int _amt = 0;
                    DataRow row = rq_wageda.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        _amt = int.Parse(row["amt"].ToString());
                    DataRow row1 = rq_zz63.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        row1["amt"] = int.Parse(row1["amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                        row1["d_amt"] = int.Parse(row1["d_amt"].ToString()) + decimal.Round(decimal.Parse(Row["d_amt"].ToString()), 0);
                    }
                    else
                    {
                        DataRow aRow = rq_zz63.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["d_ename"] = Row["d_ename"].ToString();
                        aRow["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                        aRow["d_amt"] = decimal.Round(decimal.Parse(Row["d_amt"].ToString()), 0);
                        aRow["bamt"] = _amt;
                        aRow["camt"] = 0;
                        rq_zz63.Rows.Add(aRow);
                    }
                }
                foreach (DataRow Row in rq_zz63.Rows)
                {
                    Row["camt"] = int.Parse(Row["amt"].ToString()) - int.Parse(Row["bamt"].ToString());
                    if (zone)
                    {
                        if (int.Parse(Row["camt"].ToString()) >= 1000)
                            ds.Tables["zz63"].ImportRow(Row);
                    }
                    else
                        ds.Tables["zz63"].ImportRow(Row);
                    
                }
                rq_zz63 = null;
                rq_sys2 = null;
                rq_wageda = null;
                rq_welf = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz63"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz63.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmmE", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqB", seq_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SeqE", seq_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz63", ds.Tables["zz63"]));
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
            ExporDt.Columns.Add("計薪代扣金額", typeof(int));           
            ExporDt.Columns.Add("福利金金額", typeof(int));
            ExporDt.Columns.Add("福利金稅額", typeof(int));
            ExporDt.Columns.Add("福利金金額1", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代號"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["計薪代扣金額"] = int.Parse(Row01["bamt"].ToString());
                aRow["福利金金額"] = int.Parse(Row01["amt"].ToString());
                aRow["福利金稅額"] = int.Parse(Row01["d_amt"].ToString());
                aRow["福利金金額1"] = int.Parse(Row01["camt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
