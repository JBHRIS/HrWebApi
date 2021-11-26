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
    public partial class ZZ4V_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, year_e, month_b, month_e, seq_b, seq_e, dept_b, dept_e, comp_b, comp_e, date_b, comp_name, CompId;
        string reporttype, yymm_b, yymm_e, work_b, work_e, emp_b, emp_e, workadr,nowage_b,nowage_e;
        bool exportexcel;
        string ErrorMessage = string.Empty;
        public ZZ4V_Report(string nobrb, string nobre, string yearb, string yeare, string _mb, string _me, string _seb, string _see, string deptb, string depte,string nowageb,string nowagee, string _typedata, bool _excelexport, string dateb, string _workadr)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year_b = yearb; year_e = yeare; month_b = _mb;
            month_e = _me; seq_b = _seb; seq_e = _see; dept_b = deptb; dept_e = depte;
            yymm_b = year_b + month_b; yymm_e = year_e + month_e; type_data = _typedata;
            exportexcel = _excelexport; date_b = dateb; workadr = _workadr;
            nowage_b = nowageb; nowage_e = nowagee;
        }

        private void ZZ4V_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_e = JBHR.Reports.ReportClass.GetSalEDate(year_e, month_e);
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.oudt,a.idno";
                sqlCmd += ",e.job_disp as job ,e.job_name,b.retchoo";
                sqlCmd += "  from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);                
                //if (workadr != "") sqlCmd += string.Format(@" and b.saladr='{0}'", workadr);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";

                string sqlCmd1 = "select a.*,b.name from nowage a";
                sqlCmd1 += " left outer join mtcode b on b.category='NOWAGETYPE' and a.type=b.code";
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and a.seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += string.Format(@" and a.type between '{0}' and '{1}'", nowage_b, nowage_e);                
                DataTable rq_nowage = SqlConn.GetDataTable(sqlCmd1);

                DataTable zz4v = new DataTable();
                zz4v = ds.Tables["zz4v"].Clone();
                string strnobr = string.Empty;
                int peramt = 0;
                foreach(DataRow Row in rq_nowage.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row!=null)
                    {
                        DataRow aRow = zz4v.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["typename"] = Row["name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["seq"] = Row["seq"].ToString();
                        aRow["tax_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tax_amt"].ToString()));
                        aRow["per_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["per_amt"].ToString()));
                        aRow["sumperamt"] = peramt;
                        aRow["note"] = Row["note"].ToString();
                        aRow["ok_note"] = Row["ok_note"].ToString();
                        zz4v.Rows.Add(aRow);
                    }
                    strnobr = Row["nobr"].ToString();
                }

                if (zz4v.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach(DataRow Row in zz4v.Select("","dept,nobr asc"))
                {
                    if (Row["nobr"].ToString() == strnobr)
                        peramt += int.Parse(Row["per_amt"].ToString());
                    else
                        peramt = int.Parse(Row["per_amt"].ToString());
                    Row["sumperamt"] = peramt;
                    ds.Tables["zz4v"].ImportRow(Row);
                    strnobr = Row["nobr"].ToString();
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4v"]);
                    this.Close();
                }
                else
                {
                    //string company = "";
                    //DataTable rq_sys = ReportClass.GetU_Sys();
                    //if (rq_sys.Rows.Count > 0)
                    //    company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4v.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", MainForm.COMPANY_NAME) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMMB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMME", yymm_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQB", seq_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQE", seq_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4v", ds.Tables["zz4v"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                } 
            }
             catch (Exception Ex)
             {
                 JBModule.Message.TextLog.WriteLog(Ex);
                 MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 this.Close();
             }
        }

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("狀態", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));            
            ExporDt.Columns.Add("計薪年月", typeof(string));
            ExporDt.Columns.Add("期別", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("實發薪資", typeof(int));
            ExporDt.Columns.Add("薪資小計", typeof(int));
            ExporDt.Columns.Add("備註", typeof(string));
            ExporDt.Columns.Add("實際發放年月", typeof(string));

            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["狀態"] = Row01["typename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["計薪年月"] = Row01["yymm"].ToString();
                aRow["期別"] = Row01["seq"].ToString();
                aRow["應稅薪資"] = int.Parse(Row01["tax_amt"].ToString());
                aRow["實發薪資"] = int.Parse(Row01["per_amt"].ToString());
                aRow["薪資小計"] = int.Parse(Row01["sumperamt"].ToString());
                aRow["備註"] = Row01["note"].ToString();
                aRow["實際發放年月"] = Row01["ok_note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
