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
    public partial class ZZ14_Report : JBControls.JBForm
    {      
        empdata ds = new empdata();
        string nobr_b, nobr_e, date_b, date_e, dept_b, dept_e, comp_b, comp_e, report_type, username, workadr, comp_name;
        bool exportexcel;
        public ZZ14_Report(string nobrb, string nobre, string dateb, string datee, string deptb, string depte, string compb, string compe, string reporttype, bool _exportexcel, string _username, string _workadr, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe; date_b = dateb; date_e = datee;
            report_type = reporttype; exportexcel = _exportexcel; username = _username;
            workadr = _workadr; comp_name = compname;
        }

        private void ZZ14_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "SELECT A.*,B.DESCR,C.NAME_C,C.NAME_E,E.d_no_disp AS DEPT,E.D_NAME" +
                        ",G.JOBL_DISP AS JOBL,F.JOB_DISP AS JOB,F.JOB_NAME,C.COUNT_MA,B.AWARD_CODE_DISP " +
                        "FROM AWARD A,AWARDCD B,BASE C,DEPT E,BASETTS D" +
                        " LEFT OUTER JOIN JOB F ON D.JOB=F.JOB " +
                        " LEFT OUTER JOIN JOBL G ON D.JOBL=G.JOBL"+
                        " WHERE A.AWARD_CODE=B.AWARD_CODE" +
                        " AND A.NOBR=C.NOBR" +
                        " AND D.JOB = F.JOB" +
                        " AND A.NOBR=D.NOBR" +
                        " AND '" + date_e + "' BETWEEN D.ADATE AND D.DDATE" +
                        " AND D.DEPT=E.D_NO" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND E.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND D.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " " + workadr + ""+
                        " ORDER BY D.DEPT,A.NOBR,A.ADATE";
                DataTable rq_zz14s1 = SqlConn.GetDataTable(sqlCmd);

                if (rq_zz14s1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (report_type == "1")
                {
                    ds.Tables["rq_zz14s1"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz14s1"].Columns["dept"], ds.Tables["rq_zz14s1"].Columns["nobr"] };
                    for (int i = 0; i < rq_zz14s1.Rows.Count; i++)
                    {
                        rq_zz14s1.Rows[i]["award_code"] = rq_zz14s1.Rows[i]["award_code_disp"].ToString();
                        object[] _value1 = new object[2];
                        _value1[0] = rq_zz14s1.Rows[i]["dept"].ToString();
                        _value1[1] = rq_zz14s1.Rows[i]["nobr"].ToString();
                        DataRow row = ds.Tables["rq_zz14s1"].Rows.Find(_value1);
                        
                        if (row != null)
                        {
                            row["award1"] = decimal.Parse(row["award1"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["award1"].ToString());
                            row["award2"] = decimal.Parse(row["award2"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["award2"].ToString());
                            row["award3"] = decimal.Parse(row["award3"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["award3"].ToString());
                            row["award4"] = decimal.Round(decimal.Parse(row["award4"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["award4"].ToString()), 0);
                            row["fault1"] = decimal.Parse(row["fault1"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["fault1"].ToString());
                            row["fault2"] = decimal.Parse(row["fault2"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["fault2"].ToString());
                            row["fault3"] = decimal.Parse(row["fault3"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["fault3"].ToString());
                            row["fault4"] = decimal.Parse(row["fault4"].ToString()) + decimal.Parse(rq_zz14s1.Rows[i]["fault4"].ToString());
                        }
                        else
                        {
                            ds.Tables["rq_zz14s1"].ImportRow(rq_zz14s1.Rows[i]);
                        }
                    }
                }
                else
                {
                    foreach (DataRow Row in rq_zz14s1.Rows)
                    {
                        Row["award_code"] = Row["award_code_disp"].ToString();
                        ds.Tables["rq_zz14s1"].ImportRow(Row);
                    }
                }

               rq_zz14s1 = null;
                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz14s1"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    if (report_type == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz14.rdlc";
                    else if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz141.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz14s1", ds.Tables["rq_zz14s1"]));
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
            DataRow[] RowDt;
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            if (report_type == "0")
            {
                ExporDt.Columns.Add("獎懲日期", typeof(DateTime));
                ExporDt.Columns.Add("獎懲原因", typeof(string));
                RowDt = DT.Select("", "dept,nobr asc");
            }
            else
                RowDt = DT.Select("", "dept asc");
            ExporDt.Columns.Add("大功", typeof(int));
            ExporDt.Columns.Add("小功", typeof(int));
            ExporDt.Columns.Add("嘉獎", typeof(int));
            ExporDt.Columns.Add("獎金", typeof(int));
            ExporDt.Columns.Add("晉升", typeof(string));
            ExporDt.Columns.Add("大過", typeof(int));
            ExporDt.Columns.Add("小過", typeof(int));
            ExporDt.Columns.Add("申誡", typeof(int));
            ExporDt.Columns.Add("警告", typeof(int));
            if (report_type == "0")
                ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row in RowDt)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                if (report_type == "0")
                {
                    aRow["獎懲日期"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["獎懲原因"] = Row["award_code"].ToString() + " " + Row["descr"].ToString();
                }
               
                aRow["大功"] = (decimal.Parse(Row["award1"].ToString()) <1) ? 0 : decimal.Round(decimal.Parse(Row["award1"].ToString()), 0);
                aRow["小功"] = (decimal.Parse(Row["award2"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["award2"].ToString()), 0);
                aRow["嘉獎"] = (decimal.Parse(Row["award3"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["award3"].ToString()), 0);
                aRow["獎金"] = (decimal.Parse(Row["award4"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["award4"].ToString()), 0);
                aRow["晉升"] = (bool.Parse(Row["award5"].ToString())) ? "是" : "否";
                aRow["大過"] = (decimal.Parse(Row["fault1"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["fault1"].ToString()), 0);
                aRow["小過"] = (decimal.Parse(Row["fault2"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["fault2"].ToString()), 0);
                aRow["申誡"] = (decimal.Parse(Row["fault3"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["fault3"].ToString()), 0);
                aRow["警告"] = (decimal.Parse(Row["fault4"].ToString()) < 1) ? 0 : decimal.Round(decimal.Parse(Row["fault4"].ToString()), 0);
                if (report_type == "0")
                    aRow["備註"] = Row["note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
