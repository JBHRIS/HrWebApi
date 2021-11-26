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
    public partial class ZZ4X_Report : JBControls.JBForm
    {
        string date_b, tts_type, type_data, emp_b, emp_e,reporttype;
        bool exportexcel;
        SalDataSet ds = new SalDataSet();
        public ZZ4X_Report(string empb, string empe, string dateb, string ttstype, string typedata,bool _exportexcel)
        {
            InitializeComponent();
            date_b = dateb; tts_type = ttstype; type_data = typedata;
            emp_b = empb; emp_e = empe; exportexcel = _exportexcel;
        }

        private void ZZ4X_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd1 = "select b.nobr,a.name_c,b.depts,c.d_name from base a,basetts b";
                sqlCmd1 += " left outer join depts c on b.depts=c.d_no";
                sqlCmd1 += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd1 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                if (tts_type == "0") sqlCmd1 += " and b.ttscode in ('1','4','6')";
                sqlCmd1 += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd1);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd2 = "select a.nobr,a.sal_code,a.amt from salbasd a,salcode b";
                sqlCmd2 += " where a.sal_code=b.sal_code ";
                sqlCmd2 += string.Format(@" and '{0}' between a.adate and a.ddate", date_b);
                sqlCmd2 += " and b.yearpay=1";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd2);                

                DataTable rq_nobr = new DataTable();
                rq_nobr.Columns.Add("nobr", typeof(string));
                rq_nobr.Columns.Add("depts", typeof(string));
                rq_nobr.Columns.Add("amt", typeof(int));
                rq_nobr.PrimaryKey = new DataColumn[] { rq_nobr.Columns["nobr"] };

                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    int dd = int.Parse(Row["amt"].ToString());
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1 = rq_nobr.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = rq_nobr.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["depts"] = row["depts"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            rq_nobr.Rows.Add(aRow);
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_salbasd.AcceptChanges();

                ds.Tables["zz4x"].PrimaryKey = new DataColumn[] { ds.Tables["zz4x"].Columns["depts"] };
                DataRow[] SRow = rq_nobr.Select("", "depts asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow row = ds.Tables["zz4x"].Rows.Find(Row["depts"].ToString());
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = ds.Tables["zz4x"].NewRow();
                        aRow["depts"] = Row["depts"].ToString();
                        //aRow["ds_name"] = Row["ds_name"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        ds.Tables["zz4x"].Rows.Add(aRow);
                    }

                }

                //直接匯出Excel
                //DataTable rq_depts = new DataTable();
                //rq_depts.Columns.Add("depts", typeof(string));
                //rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["depts"] };
                //DataRow[] SRow = rq_nobr.Select("", "depts asc");
                //foreach (DataRow Row in SRow)
                //{ 
                //    DataRow row=rq_depts.Rows.Find(Row["depts"].ToString());
                //    if (row == null)
                //    {
                //        DataRow aRow = rq_depts.NewRow();
                //        aRow["depts"] = Row["depts"].ToString();
                //        rq_depts.Rows.Add(aRow);
                //    }
                //}

                //DataTable rq_zz4x = new DataTable();
                ////rq_zz4x.Columns.Add("depts", typeof(string));               
                //for (int i = 0; i < rq_depts.Rows.Count; i++)
                //{
                //    rq_zz4x.Columns.Add(rq_depts.Rows[i]["depts"].ToString().Trim(), typeof(int));
                //}
                //rq_zz4x.Columns.Add("總計", typeof(int));
                ////rq_zz4x.PrimaryKey = new DataColumn[] { rq_zz4x.Columns["depts"] };

                //int _i = 0;
                //foreach (DataRow Row in rq_nobr.Rows)
                //{
                //    //DataRow row = rq_zz4x.Rows.Find(Row["depts"].ToString().Trim());
                //    if (_i!=0)
                //    {
                //        for (int i = 0; i < rq_depts.Rows.Count; i++)
                //        {
                //            if (Row["depts"].ToString().Trim() == rq_depts.Rows[i]["depts"].ToString().Trim())
                //            {
                //                rq_zz4x.Rows[0][rq_depts.Rows[i]["depts"].ToString().Trim()] = int.Parse(rq_zz4x.Rows[0][rq_depts.Rows[i]["depts"].ToString().Trim()].ToString()) + Math.Round(decimal.Parse(Row["amt"].ToString()) / 12, MidpointRounding.AwayFromZero);
                //                rq_zz4x.Rows[0]["總計"] = int.Parse(rq_zz4x.Rows[0]["總計"].ToString()) + Math.Round(decimal.Parse(Row["amt"].ToString()) / 12, MidpointRounding.AwayFromZero);
                //                break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        DataRow aRow = rq_zz4x.NewRow();                        
                //        for (int i = 0; i < rq_depts.Rows.Count; i++)
                //        {
                //            aRow[rq_depts.Rows[i]["depts"].ToString().Trim()] = 0;
                //            if (Row["depts"].ToString().Trim() == rq_depts.Rows[i]["depts"].ToString().Trim())
                //            {
                //                aRow[rq_depts.Rows[i]["depts"].ToString().Trim()] = Math.Round(decimal.Parse(Row["amt"].ToString()) / 12, MidpointRounding.AwayFromZero);
                //                aRow["總計"] = Math.Round(decimal.Parse(Row["amt"].ToString()) / 12, MidpointRounding.AwayFromZero);
                //            }
                //        }
                //        rq_zz4x.Rows.Add(aRow);
                //    }
                //    _i++;
                //}

                //rq_base = null; rq_depts = null; rq_nobr = null; rq_salbasd = null;
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_zz4x, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                //this.Close();

                if (exportexcel)
                {
                    Export(ds.Tables["zz4x"]);
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
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4x.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4x", ds.Tables["zz4x"]));
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
            ExporDt.Columns.Add("Oracle#", typeof(string));
            ExporDt.Columns.Add("Amount", typeof(string));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["Oracle#"] = Row["depts"].ToString();
                aRow["Amount"] = int.Parse(Row["amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
