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
    public partial class ZZ4Y_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, year_b, month_b, seq_b, dept_b, dept_e, date_b,date_e;
        string yymm_b, emp_b, emp_e, username, comp_name, CompId;
        bool exportexcel;
        public ZZ4Y_Report(string nobrb, string nobre, string dateb, string datee, string yearb, string _mb, string _seb, string deptb, string depte, string empb, string empe, string _typedata, bool _excelexport, string _username, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; year_b = yearb; month_b = _mb;
            seq_b = _seb; dept_b = deptb; dept_e = depte; emp_b = empb; emp_e = empe;
            type_data = _typedata; exportexcel = _excelexport; date_b = dateb;
            username = _username; yymm_b = year_b + month_b; date_e = datee;
            CompId = _CompId; comp_name = compname;
            
        }

        private void ZZ4Y_Report_Load(object sender, EventArgs e)
        {
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.di,c.d_no_disp as dept,c.d_name,c.d_ename ";
            sqlCmd += " from base a,basetts b ";
            sqlCmd += " left outer join dept c on b.dept=c.d_no";
            sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
            sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
            sqlCmd += type_data;
            DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
            rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

            //出勤資料
            string sqlCmd1 = "select nobr,adate,forget,late_mins,e_mins from attend";
            sqlCmd1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
            sqlCmd1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd1 += " and (forget >0 or late_mins >0 or e_mins>0) order by adate";
            DataTable rq_attend = SqlConn.GetDataTable(sqlCmd1);
            rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"], rq_attend.Columns["adate"] };

            //出勤薪資代碼
            DataTable rq_usys2 = SqlConn.GetDataTable("select attawardsalcode from u_sys2 where comp='" + CompId + "'");
            string attsalcode = (rq_usys2.Rows.Count > 0) ? rq_usys2.Rows[0]["attawardsalcode"].ToString() : "";

            //薪資全勤獎金
            string sqlCmd2 = "select b.nobr,b.amt,a.wk_days from wage a,waged b";
            sqlCmd2+=" where a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq";
            sqlCmd2 += string.Format(@" and a.yymm='{0}' and a.seq='{1}'", yymm_b, seq_b);
            sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd2 += string.Format(@" and b.sal_code='{0}'", attsalcode);
            DataTable rq_wage = SqlConn.GetDataTable(sqlCmd2);
            if (rq_wage.Rows.Count < 1)
            {
                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                return;
            }

            //請假資料
            string sqlCmd3 = "select a.nobr,a.bdate,a.btime,a.etime,b.h_name,a.tol_hours from abs a,hcode b";
            sqlCmd3 += " where a.h_code=b.h_code";
            sqlCmd3 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
            sqlCmd3 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            sqlCmd3 += string.Format(@" and a.yymm='{0}'", yymm_b);
            sqlCmd3 += " and b.att=1 order by a.nobr,a.bdate";
            DataTable rq_abs = SqlConn.GetDataTable(sqlCmd3);
            string nobr1 = ""; string bdate1 = "";
            DataTable rq_zz2y = new DataTable();
            rq_zz2y = ds.Tables["zz4y"].Clone();
            rq_zz2y.TableName = "rq_zz2y";   

            foreach (DataRow Row in rq_wage.Rows)
            {
                Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {                  
                    DataRow[] row1 = rq_abs.Select("nobr='" + Row["nobr"].ToString() + "'");
                    if (row1.Length > 0)
                    {
                        for (int i = 0; i < row1.Length; i++)
                        {
                            string bdate = DateTime.Parse(row1[i]["bdate"].ToString()).ToString("yyyy/MM/dd");
                            string nobr = Row["nobr"].ToString();
                            DataRow aRow = rq_zz2y.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["d_ename"] = row["d_ename"].ToString();
                            if (i == 0)
                            {
                                aRow["amt"] = int.Parse(Row["amt"].ToString());
                                aRow["wk_days"] = decimal.Round(decimal.Parse(Row["wk_days"].ToString()),0);
                            }
                            aRow["bdate"] = DateTime.Parse(row1[i]["bdate"].ToString());
                            aRow["h_name"] = row1[i]["h_name"].ToString();
                            aRow["btime"] = row1[i]["btime"].ToString();
                            aRow["etime"] = row1[i]["etime"].ToString();
                            aRow["tol_hours"] = decimal.Parse(row1[i]["tol_hours"].ToString());
                            if (nobr == nobr1 && bdate == bdate1)
                                aRow["repeat"] = "";
                            else
                                aRow["repeat"] = "*";
                            rq_zz2y.Rows.Add(aRow);
                            bdate1 = DateTime.Parse(row1[i]["bdate"].ToString()).ToString("yyyy/MM/dd");
                            nobr1 = Row["nobr"].ToString();                            
                        }
                    }
                    else
                    {
                        DataRow aRow1 = rq_zz2y.NewRow();
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["name_c"] = row["name_c"].ToString();
                        aRow1["name_e"] = row["name_e"].ToString();
                        aRow1["dept"] = row["dept"].ToString();
                        aRow1["d_name"] = row["d_name"].ToString();
                        aRow1["d_ename"] = row["d_ename"].ToString();
                        aRow1["amt"] = int.Parse(Row["amt"].ToString());
                        aRow1["wk_days"] = decimal.Round(decimal.Parse(Row["wk_days"].ToString()), 0);
                        aRow1["repeat"] = "*";
                        rq_zz2y.Rows.Add(aRow1);
                    }
                }
            }

            foreach (DataRow Row in rq_zz2y.Rows)
            {
                DataRow[] row1 = rq_attend.Select("nobr='" + Row["nobr"].ToString() + "'");
                for (int i = 0; i < row1.Length; i++)
                {                    
                    if (Row.IsNull("bdate"))
                    {                        
                        Row["adate"] = DateTime.Parse(row1[i]["adate"].ToString());
                        if (!row1[i].IsNull("forget")) Row["forget"] = decimal.Round(decimal.Parse(row1[i]["forget"].ToString()), 0);
                        if (!row1[i].IsNull("late_mins")) Row["late_mins"] = decimal.Round(decimal.Parse(row1[i]["late_mins"].ToString()), 0);
                        if (!row1[i].IsNull("e_mins")) Row["e_mins"] = decimal.Round(decimal.Parse(row1[i]["e_mins"].ToString()), 0);                       
                    }
                    else
                    {
                        if (DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd") == DateTime.Parse(row1[i]["adate"].ToString()).ToString("yyyyMMdd"))
                        {
                            if (Row["repeat"].ToString() == "*")
                            {
                                Row["adate"] = DateTime.Parse(row1[i]["adate"].ToString());
                                if (!row1[i].IsNull("forget")) Row["forget"] = decimal.Round(decimal.Parse(row1[i]["forget"].ToString()), 0);
                                if (!row1[i].IsNull("late_mins")) Row["late_mins"] = decimal.Round(decimal.Parse(row1[i]["late_mins"].ToString()), 0);
                                if (!row1[i].IsNull("e_mins")) Row["e_mins"] = decimal.Round(decimal.Parse(row1[i]["e_mins"].ToString()), 0);
                            }
                        }
                        else
                        {
                            DataRow aRow1 = ds.Tables["zz4y"].NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["name_c"] = Row["name_c"].ToString();
                            aRow1["name_e"] = Row["name_e"].ToString();
                            aRow1["dept"] = Row["dept"].ToString();
                            aRow1["d_name"] = Row["d_name"].ToString();
                            aRow1["d_ename"] = Row["d_ename"].ToString();
                            aRow1["adate"] = DateTime.Parse(row1[i]["adate"].ToString());
                            if (!row1[i].IsNull("forget")) aRow1["forget"] = decimal.Round(decimal.Parse(row1[i]["forget"].ToString()), 0);
                            if (!row1[i].IsNull("late_mins")) aRow1["late_mins"] = decimal.Round(decimal.Parse(row1[i]["late_mins"].ToString()), 0);
                            if (!row1[i].IsNull("e_mins")) aRow1["e_mins"] = decimal.Round(decimal.Parse(row1[i]["e_mins"].ToString()), 0);
                            ds.Tables["zz4y"].Rows.Add(aRow1);
                        }
                    }                                     
                }                     
            }

            ds.Tables["zz4y"].Merge(rq_zz2y);
            rq_abs = null; rq_attend = null; rq_base = null;
            rq_usys2 = null; rq_wage = null; rq_zz2y = null;

            if (ds.Tables["zz4y"].Rows.Count < 1)
            {
                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
                return;
            }
            
            if (exportexcel)
            {
                Export(ds.Tables["zz4y"]);
                this.Close();
            }
            else
            {
                string JBVersion = "";
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    JBVersion += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                //DataTable rq_sys = ReportClass.GetU_Sys();
                //if (rq_sys.Rows.Count > 0)
                //    company = rq_sys.Rows[0]["company"].ToString();
                RptViewer.Reset();
                //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4y.rdlc";
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4y", ds.Tables["zz4y"]));
                RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                RptViewer.ZoomMode = ZoomMode.FullPage;
                //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
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
            ExporDt.Columns.Add("全勤獎金", typeof(int));
            ExporDt.Columns.Add("工作天數", typeof(int));
            ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            ExporDt.Columns.Add("忘刷", typeof(int));
            ExporDt.Columns.Add("遲到(分)", typeof(int));
            ExporDt.Columns.Add("早退(分)", typeof(int));
            ExporDt.Columns.Add("請假日期", typeof(DateTime));
            ExporDt.Columns.Add("假別名稱", typeof(string));
            ExporDt.Columns.Add("請起時間", typeof(string));
            ExporDt.Columns.Add("請迄時間", typeof(string));
            ExporDt.Columns.Add("請迄時數", typeof(decimal));
            DataRow[] SRow = DT.Select("", "dept,nobr asc");

            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代號"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                if (!Row01.IsNull("amt")) aRow["全勤獎金"] = int.Parse(Row01["amt"].ToString());
                if (!Row01.IsNull("wk_days")) aRow["工作天數"] = int.Parse(Row01["wk_days"].ToString());
                if (!Row01.IsNull("adate")) aRow["出勤日期"] = DateTime.Parse(Row01["adate"].ToString());
                if (!Row01.IsNull("forget")) aRow["忘刷"] = int.Parse(Row01["forget"].ToString());
                if (!Row01.IsNull("late_mins")) aRow["遲到(分)"] = int.Parse(Row01["late_mins"].ToString());
                if (!Row01.IsNull("e_mins")) aRow["早退(分)"] = int.Parse(Row01["e_mins"].ToString());
                if (!Row01.IsNull("bdate")) aRow["請假日期"] = DateTime.Parse(Row01["bdate"].ToString());
                if (!Row01.IsNull("h_name")) aRow["假別名稱"] = Row01["h_name"].ToString();
                if (!Row01.IsNull("btime")) aRow["請起時間"] = Row01["btime"].ToString();
                if (!Row01.IsNull("etime")) aRow["請迄時間"] = Row01["etime"].ToString();
                if (!Row01.IsNull("tol_hours")) aRow["請迄時數"] = decimal.Parse(Row01["tol_hours"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
