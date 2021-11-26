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
    public partial class ZZ72_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, year, ser_nob, ser_noe, ordertype, reporttype, username;
        bool exportexcel;
        public ZZ72_Report(string nobrb, string nobre, string _year, string sernob, string sernoe, string _ordertype, string _reporttype, bool _exportexcel, string _username)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year = _year; ser_nob = sernob;
            ser_noe = sernoe; ordertype = _ordertype; reporttype = _reporttype;
            exportexcel = _exportexcel; username = _username;
        }

        private void ZZ72_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string date_b = Convert.ToString(Convert.ToInt32(year) + 1911) + "/12/31";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select * from tyrtax ";
                sqlCmd += string.Format(@" where year='{0}'", year);
                sqlCmd += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and series between '{0}' and '{1}'", ser_nob, ser_noe);
                sqlCmd += ordertype;
                DataTable rq_yrtax = SqlConn.GetDataTable(sqlCmd);
                if (rq_yrtax.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_yrtax.Rows)
                {
                    ds.Tables["zz51"].ImportRow(Row);
                }
                rq_yrtax = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz51"]);
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz71.rdlc";
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    }
                    else
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz511.rdlc";
                        DataTable rq_sys1 = SqlConn.GetDataTable("select company,compaddr,compman from u_sys1");
                        string companya = ""; string compaddr = ""; string compman = "";
                        if (rq_sys1.Rows.Count > 0)
                        {
                            companya = rq_sys1.Rows[0]["company"].ToString();
                            compaddr = rq_sys1.Rows[0]["compaddr"].ToString();
                            compman = rq_sys1.Rows[0]["compman"].ToString();
                        }
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", companya) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compaddr", compaddr) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compman", compman) });
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz51", ds.Tables["zz51"]));
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
            ExporDt.Columns.Add("流水編號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("格式", typeof(string));
            ExporDt.Columns.Add("給付總額", typeof(int));
            ExporDt.Columns.Add("扣繳稅額", typeof(int));
            ExporDt.Columns.Add("實付總額", typeof(int));
            ExporDt.Columns.Add("退休金", typeof(int));
            ExporDt.Columns.Add("戶籍地址", typeof(string));
            ExporDt.Columns.Add("所得代號", typeof(string));
            ExporDt.Columns.Add("機關", typeof(string));
            ExporDt.Columns.Add("媒體", typeof(string));
            ExporDt.Columns.Add("統編", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();                
                aRow["流水編號"] = Row01["series"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["身分證號"] = Row01["id"].ToString();
                aRow["格式"] = Row01["format"].ToString();
                aRow["給付總額"] = int.Parse(Row01["tot_amt"].ToString());
                aRow["扣繳稅額"] = int.Parse(Row01["tax_amt"].ToString());
                aRow["實付總額"] = int.Parse(Row01["rel_amt"].ToString());
                aRow["退休金"] = int.Parse(Row01["ret_amt"].ToString());
                aRow["戶籍地址"] = Row01["addr_2"].ToString();
                aRow["所得代號"] = Row01["acc_no"].ToString();
                aRow["機關"] = Row01["f0103"].ToString();
                aRow["媒體"] = Row01["f0407"].ToString();
                aRow["統編"] = Row01["id1"].ToString() + " " + Row01["mark"].ToString() + " " + Row01["idcode"].ToString() + " " + Row01["err_mark"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
