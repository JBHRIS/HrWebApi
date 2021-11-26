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
    public partial class ZZ2Z3_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        bool exportexcel;
        public ZZ2Z3_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string datareport, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel;comp_name = compname;
        }

        private void ZZ2Z3_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");               
                string sqlBase = "select b.nobr,a.name_c,c.d_no_disp as dept,f.rotet_disp as rotet,c.d_name,a.sex,e.jobl_disp as jobl";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join dept c on b.dept=c.d_no";
                sqlBase += " left outer join depts d on b.depts=d.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " left outer join rotet f on  b.rotet=f.rotet";
                sqlBase += " where a.nobr=b.nobr ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlBase += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);              
                sqlBase += data_report;
                sqlBase += " and b.ttscode in ('1','4','6')";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);              

                //出勤資料
                string sqlAttend = "select a.nobr,a.late_mins,a.forget";
                sqlAttend += " from attend a,rote b";
                sqlAttend += string.Format(@" where a.rote=b.rote and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " and (a.late_mins>0 or a.forget>0)";
                sqlAttend += " order by a.nobr";
                DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend);
                DataTable rq_attend = new DataTable();
                rq_attend.Columns.Add("nobr", typeof(string));
                rq_attend.Columns.Add("latecnt", typeof(int));
                rq_attend.Columns.Add("forgetcnt", typeof(int));
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"] };
                foreach (DataRow Row in rq_attend1.Rows)
                {
                    DataRow row = rq_attend.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                            row["latecnt"] = int.Parse(row["latecnt"].ToString()) + 1;
                        row["forgetcnt"] = int.Parse(row["forgetcnt"].ToString()) + decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            
                    }
                    else
                    {
                        DataRow aRow = rq_attend.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["latecnt"] = (decimal.Parse(Row["late_mins"].ToString()) > 0) ? 1 : 0;
                        aRow["forgetcnt"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                        rq_attend.Rows.Add(aRow);
                    }
                }

                //事假、病假請假次數
                string sqlAbs = "select a.nobr,b.h_code_disp,count(b.h_code_disp) as cnt from abs a,hcode b";
                sqlAbs += " where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += " and b.h_code_disp between '04' and '08'";
                //sqlAbs += " and (b.h_code_disp='CA01' or b.h_code_disp='BA01') ";
                sqlAbs += " group by a.nobr,b.h_code_disp ";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                
                DataTable rq_abs1 = new DataTable();
                rq_abs1.Columns.Add("nobr", typeof(string));
                rq_abs1.Columns.Add("person", typeof(int));
                rq_abs1.Columns.Add("sick", typeof(int));
                rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (Row["h_code_disp"].ToString().Trim() == "04" || Row["h_code_disp"].ToString().Trim() == "05")
                            row["person"] = int.Parse(Row["cnt"].ToString());
                        else if (Row["h_code_disp"].ToString().Trim() == "06" || Row["h_code_disp"].ToString().Trim() == "07" || Row["h_code_disp"].ToString().Trim() == "08")
                            row["sick"] = int.Parse(Row["cnt"].ToString());                       
                    }
                    else
                    {
                        DataRow aRow = rq_abs1.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        if (Row["h_code_disp"].ToString().Trim() == "04" || Row["h_code_disp"].ToString().Trim() == "05")
                            aRow["person"] = int.Parse(Row["cnt"].ToString());
                        else if (Row["h_code_disp"].ToString().Trim() == "06" || Row["h_code_disp"].ToString().Trim() == "07" || Row["h_code_disp"].ToString().Trim() == "08")
                            aRow["sick"] = int.Parse(Row["cnt"].ToString());
                       
                        rq_abs1.Rows.Add(aRow);
                    }
                }

                int _rowcnt = 1; string _nobr = ""; string _name = "";
                foreach (DataRow Row in rq_base.Rows)
                {
                    DataRow row = rq_attend.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_abs1.Rows.Find(Row["nobr"].ToString());
                    DataRow aRow1 = ds.Tables["zz2z3"].NewRow();
                    aRow1["rowcnt"] = _rowcnt;
                    aRow1["nobr"] = Row["nobr"].ToString();
                    aRow1["name_c"] = Row["name_c"].ToString();
                    aRow1["nobr1"] = "";
                    aRow1["name_c1"] = "";
                    aRow1["late"] = (row != null) ? int.Parse(row["latecnt"].ToString()) : 0;
                    aRow1["forget"] = (row != null) ? int.Parse(row["forgetcnt"].ToString()) : 0;
                    if (row1 != null)
                    {
                        aRow1["person"] = (!row1.IsNull("person")) ? int.Parse(row1["person"].ToString()) : 0;
                        aRow1["sick"] = (!row1.IsNull("sick")) ? int.Parse(row1["sick"].ToString()) : 0;
                    }
                    else
                    {
                        aRow1["person"] = 0;
                        aRow1["sick"] = 0;
                    }
                    aRow1["score"] = 100 - (decimal.Parse(aRow1["late"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow1["forget"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow1["person"].ToString()) * Convert.ToDecimal(0.4)) - (decimal.Parse(aRow1["sick"].ToString()) * Convert.ToDecimal(0.2));
                    ds.Tables["zz2z3"].Rows.Add(aRow1);

                    _rowcnt += 1;
                }
                //foreach (DataRow Row in rq_base.Rows)
                //{
                //    DataRow row = rq_attend.Rows.Find(Row["nobr"].ToString());
                //    DataRow row1 = rq_abs1.Rows.Find(Row["nobr"].ToString());                    
                //    if (decimal.Remainder(_rowcnt, 2) == 0)
                //    {
                //        DataRow row2 = rq_attend.Rows.Find(_nobr);
                //        DataRow row3 = rq_abs1.Rows.Find(_nobr);       
                //        DataRow aRow = ds.Tables["zz2z3"].NewRow();
                //        aRow["rowcnt"] = _rowcnt-1;
                //        aRow["nobr"] = _nobr;
                //        aRow["name_c"] =_name;
                //        aRow["late"] = (row2 != null) ? int.Parse(row2["latecnt"].ToString()) : 0;
                //        aRow["forget"] = (row2 != null) ? int.Parse(row2["forgetcnt"].ToString()) : 0;
                //        if (row3 != null)
                //        {
                //            aRow["person"] = (!row3.IsNull("person")) ? int.Parse(row3["person"].ToString()) : 0;
                //            aRow["sick"] =  (!row3.IsNull("sick")) ?int.Parse(row3["sick"].ToString()) :0 ;
                //        }
                //        else
                //        {
                //            aRow["person"] = 0;
                //            aRow["sick"] = 0;
                //        }
                //        aRow["score"] = 100 - (decimal.Parse(aRow["late"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow["forget"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow["person"].ToString()) * Convert.ToDecimal(0.4)) - (decimal.Parse(aRow["sick"].ToString()) * Convert.ToDecimal(0.2));
                //        aRow["rowcnt1"] = _rowcnt ;
                //        aRow["nobr1"] = Row["nobr"].ToString();
                //        aRow["name_c1"] = Row["name_c"].ToString();
                //        aRow["late1"] = (row != null) ? int.Parse(row["latecnt"].ToString()) : 0;
                //        aRow["forget1"] = (row != null) ? int.Parse(row["forgetcnt"].ToString()) : 0;
                //        if (row1 != null)
                //        {
                //            aRow["person1"] =(!row1.IsNull("person")) ? int.Parse(row1["person"].ToString()) :0 ;
                //            aRow["sick1"] = (!row1.IsNull("sick")) ? int.Parse(row1["sick"].ToString()) : 0;
                //        }
                //        else
                //        {
                //            aRow["person1"] = 0;
                //            aRow["sick1"] = 0;
                //        }
                //        aRow["score1"] = 100 - (decimal.Parse(aRow["late1"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow["forget1"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow["person1"].ToString()) * Convert.ToDecimal(0.4)) - (decimal.Parse(aRow["sick1"].ToString()) * Convert.ToDecimal(0.2));
                //        ds.Tables["zz2z3"].Rows.Add(aRow);
                //    }
                //    else if (_rowcnt == rq_base.Rows.Count)
                //    {                       
                //        DataRow aRow1 = ds.Tables["zz2z3"].NewRow();
                //        aRow1["rowcnt"] = _rowcnt;
                //        aRow1["nobr"] = Row["nobr"].ToString();
                //        aRow1["name_c"] = Row["name_c"].ToString();
                //        aRow1["nobr1"] = "";
                //        aRow1["name_c1"] = "";
                //        aRow1["late"] = (row != null) ? int.Parse(row["latecnt"].ToString()) : 0;
                //        aRow1["forget"] = (row != null) ? int.Parse(row["forgetcnt"].ToString()) : 0;
                //        if (row1 != null)
                //        {
                //            aRow1["person"] = (!row1.IsNull("person")) ? int.Parse(row1["person"].ToString()) : 0;
                //            aRow1["sick"] = (!row1.IsNull("sick")) ? int.Parse(row1["sick"].ToString()) : 0;
                //        }
                //        else
                //        {
                //            aRow1["person"] = 0;
                //            aRow1["sick"] = 0;
                //        }
                //        aRow1["score"] = 100 - (decimal.Parse(aRow1["late"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow1["forget"].ToString()) * Convert.ToDecimal(0.2)) - (decimal.Parse(aRow1["person"].ToString()) * Convert.ToDecimal(0.4)) - (decimal.Parse(aRow1["sick"].ToString()) * Convert.ToDecimal(0.2));                        
                //        ds.Tables["zz2z3"].Rows.Add(aRow1);
                //    }
                //    _nobr = Row["nobr"].ToString();
                //    _name = Row["name_c"].ToString();

                //    _rowcnt += 1;
                //}
                rq_abs = null; rq_abs1 = null; rq_attend = null; rq_base = null; rq_attend1 = null;
                if (ds.Tables["zz2z3"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2z3"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z8.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z3", ds.Tables["zz2z3"]));                  
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
            ExporDt.Columns.Add("序號", typeof(int));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("遲到", typeof(int));
            ExporDt.Columns.Add("忘刷", typeof(int));
            ExporDt.Columns.Add("事假", typeof(int));
            ExporDt.Columns.Add("病假", typeof(int));
            ExporDt.Columns.Add("總分", typeof(decimal));
            //ExporDt.Columns.Add("序號1", typeof(int));
            //ExporDt.Columns.Add("員工編號1", typeof(string));
            //ExporDt.Columns.Add("員工姓名1", typeof(string));
            //ExporDt.Columns.Add("遲到1", typeof(int));
            //ExporDt.Columns.Add("忘刷1", typeof(int));
            //ExporDt.Columns.Add("事假1", typeof(int));
            //ExporDt.Columns.Add("病假1", typeof(int));
            //ExporDt.Columns.Add("總分1", typeof(decimal));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["序號"] = Row["rowcnt"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["遲到"] = int.Parse(Row["late"].ToString());
                aRow["忘刷"] = int.Parse(Row["forget"].ToString());
                aRow["事假"] =int.Parse( Row["person"].ToString());
                aRow["病假"] =int.Parse( Row["sick"].ToString());
                aRow["總分"] = decimal.Parse(Row["score"].ToString());
                //if (!Row.IsNull("rowcnt1"))
                //{
                //    aRow["序號1"] = Row["rowcnt1"].ToString();
                //    aRow["員工編號1"] = Row["nobr1"].ToString();
                //    aRow["員工姓名1"] = Row["name_c1"].ToString();
                //    aRow["遲到1"] = int.Parse(Row["late1"].ToString());
                //    aRow["忘刷1"] = int.Parse(Row["forget1"].ToString());
                //    aRow["事假1"] = int.Parse(Row["person1"].ToString());
                //    aRow["病假1"] = int.Parse(Row["sick1"].ToString());
                //    aRow["總分1"] = decimal.Parse(Row["score1"].ToString());
                //}
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
