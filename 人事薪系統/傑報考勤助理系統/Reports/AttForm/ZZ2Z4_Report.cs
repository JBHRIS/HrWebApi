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
    public partial class ZZ2Z4_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        bool exportexcel;
        public ZZ2Z4_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string datareport, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel; comp_name = compname;
        }

        private void ZZ2Z4_Report_Load(object sender, EventArgs e)
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
                //sqlBase += " and b.ttscode in ('1','4','6')";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //出勤資料
                string sqlAttend = "select a.nobr,a.adate,a.late_mins,a.forget,b.rote_disp as rote";
                sqlAttend += " from attend a,rote b";
                sqlAttend += string.Format(@" where a.rote=b.rote and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);                
                sqlAttend += " order by a.nobr";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);

                //加班時數
                string SqlOt = "select nobr,bdate,ot_hrs";
                SqlOt += " from ot";
                SqlOt += string.Format(@" where  nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                SqlOt += string.Format(@" and bdate between '{0}' and '{1}'", date_b, date_e);
                SqlOt+=" and ot_hrs>0";
                DataTable rq_ot = SqlConn.GetDataTable(SqlOt);
                ds.Tables["zz2z4"].PrimaryKey = new DataColumn[] { ds.Tables["zz2z4"].Columns["nobr"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow[] row2 = rq_ot.Select("nobr='" + Row["nobr"].ToString() + "' and bdate='" + DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd") + "'");
                        DataRow row1 = ds.Tables["zz2z4"].Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                            {
                                row1["late_mins"] = decimal.Parse(row1["late_mins"].ToString()) + decimal.Parse(Row["late_mins"].ToString());
                                row1["late_times"] = int.Parse(row1["late_times"].ToString()) + 1;
                            }
                            row1["forget"] = int.Parse(row1["forget"].ToString()) + decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                                
                            foreach (DataRow Row1 in row2)
                            {
                                if (Row["rote"].ToString().Trim() == "00")
                                    row1["holothrs"] = decimal.Parse(row1["holothrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                                else
                                    row1["wkothrs"] = decimal.Parse(row1["wkothrs"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz2z4"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["late_mins"] = 0;
                            aRow["late_times"] = 0;
                            aRow["forget"] = 0;
                            aRow["holothrs"] = 0;
                            aRow["wkothrs"] = 0;
                            if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                            {
                                aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                                aRow["late_times"] = 1;
                            }
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                                
                            foreach (DataRow Row1 in row2)
                            {
                                if (Row["rote"].ToString().Trim() == "00")
                                    aRow["holothrs"] =  decimal.Parse(Row1["ot_hrs"].ToString());
                                else
                                    aRow["wkothrs"] =  decimal.Parse(Row1["ot_hrs"].ToString());
                            }
                            ds.Tables["zz2z4"].Rows.Add(aRow);
                        }
                    }                   
                }

                rq_attend = null; rq_base = null; rq_ot = null;
                if (ds.Tables["zz2z4"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz2z4"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z9.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z4", ds.Tables["zz2z4"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("平時加班時數", typeof(decimal));
            ExporDt.Columns.Add("假日加班時數", typeof(decimal));
            ExporDt.Columns.Add("遲到分鐘數", typeof(decimal));
            ExporDt.Columns.Add("遲到次數", typeof(int));
            ExporDt.Columns.Add("未刷卡次數", typeof(int));
           
            
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();              
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["平時加班時數"] = decimal.Parse(Row["wkothrs"].ToString());
                aRow["假日加班時數"] = decimal.Parse(Row["holothrs"].ToString());
                aRow["遲到分鐘數"] = decimal.Parse(Row["late_mins"].ToString());
                aRow["遲到次數"] = int.Parse(Row["late_times"].ToString());
                aRow["未刷卡次數"] = int.Parse(Row["forget"].ToString());
               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
