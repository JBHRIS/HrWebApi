using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.TraForm
{
    public partial class ZZ91_Report : JBControls.JBForm
    {
        TraDataSet ds = new TraDataSet();
        string nobr_b, nobr_e, comp_b, comp_e, dept_b, dept_e, jobl_b, jobl_e, jobs_b, jobs_e, subcode_b, subcode_e, date_b, date_e, type_data, compname;
        bool exportexcel, incu_out;
        public ZZ91_Report(string nobrb, string nobre, string compb, string compe, string deptb, string depte, string joblb, string joble, string jobsb, string jobse, string subcodeb, string subcodee, string dateb, string datee, string typedata, bool _exportexcel, bool incuout, string _compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; comp_b = compb; comp_e = compe; jobl_b = joblb; jobl_e = joble;
            jobs_b = jobsb; jobs_e = jobse; subcode_b = subcodeb; subcode_e = subcodee; date_b = dateb;
            date_e = datee; type_data = typedata; exportexcel = _exportexcel; incu_out = incuout;
            dept_b = deptb; dept_e = depte; compname = _compname;
        }

        private void ZZ91_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";                
                sqlCmd += " left outer join jobl d on b.jobl=d.jobl";
                sqlCmd += " left outer join jobs e on b.jobs=e.jobs";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and d.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlCmd += string.Format(@" and e.jobs_disp between '{0}' and '{1}'", jobs_b, jobs_e);
                sqlCmd += type_data;
                if (!incu_out) sqlCmd += " and b.ttscode in ('1','4','6')";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select  c.nobr as idno,a.course,a.date_b,a.date_e,c.st_hrs as tr_hrs,b.tr_type_disp as tr_type,c.at_hrs,a.cos_fee,";
                sqlCmd1 += "a.tr_inout,a.tr_teach,f.tr_comp_name as tr_comp,'' as prove,c.applyno,a.tr_iso";
                sqlCmd1 += " from trcosp c, trcosc a ";
                sqlCmd1 += " left outer join trtype b on a.tr_type=b.tr_type";
                sqlCmd1 += " left outer join trcompy f on a.tr_comp=f.tr_comp";
                sqlCmd1 += "  where a.guid=c.course ";
                sqlCmd1 += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.date_b between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" and b.tr_type_disp between '{0}' and '{1}'", subcode_b, subcode_e);
                DataTable rq_trcosf = SqlConn.GetDataTable(sqlCmd1);
                DataTable rq_zz91 = new DataTable();
                rq_zz91 = ds.Tables["zz91"].Clone();
                foreach (DataRow Row in rq_trcosf.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["idno"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz91.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString().Trim();
                        aRow["idno"] = Row["idno"].ToString().Trim();
                        aRow["name_c"] = row["name_c"].ToString().Trim();
                        aRow["course"] = Row["course"].ToString().Trim();
                        aRow["date_b"] = DateTime.Parse(Row["date_b"].ToString());
                        aRow["date_e"] = DateTime.Parse(Row["date_e"].ToString());
                        aRow["tr_hrs"] = decimal.Parse(Row["tr_hrs"].ToString());
                        aRow["at_hrs"] = decimal.Parse(Row["at_hrs"].ToString());
                        aRow["tr_type"] = Row["tr_type"].ToString();
                        aRow["cos_fee"] = decimal.Round(decimal.Parse(Row["cos_fee"].ToString()),0);
                        aRow["tr_inout"] = Row["tr_inout"].ToString().Trim();
                        aRow["tr_teach"] = Row["tr_teach"].ToString().Trim();
                        aRow["tr_comp"] = Row["tr_comp"].ToString().Trim();
                        aRow["prove"] = Row["prove"].ToString().Trim();
                        aRow["applyno"] = Row["applyno"].ToString().Trim();
                        aRow["tr_iso"] = Row["tr_iso"].ToString().Trim();
                        rq_zz91.Rows.Add(aRow);
                    }
                }

                if (rq_zz91.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataRow[] SRow = rq_zz91.Select("", "dept,idno asc");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz91"].ImportRow(Row);
                }
                rq_base = null; rq_trcosf = null; rq_zz91 = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz91"]);                    
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
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "TraReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz91.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", compname) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("TraDataSet_zz91", ds.Tables["zz91"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("課程", typeof(string));
            ExporDt.Columns.Add("開訓日期", typeof(DateTime));
            ExporDt.Columns.Add("結訓日期", typeof(DateTime));
            ExporDt.Columns.Add("類別", typeof(string));
            ExporDt.Columns.Add("上課時數", typeof(decimal));
            ExporDt.Columns.Add("缺課時數", typeof(decimal));
            ExporDt.Columns.Add("上課費用", typeof(int));
            ExporDt.Columns.Add("訓練型式", typeof(string));
            ExporDt.Columns.Add("講師", typeof(string));
            ExporDt.Columns.Add("訓練機構", typeof(string));
            //ExporDt.Columns.Add("證照", typeof(string));
            ExporDt.Columns.Add("申請編號", typeof(string));
            ExporDt.Columns.Add("ISO", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["idno"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["課程"] = Row01["course"].ToString();
                aRow["開訓日期"] = DateTime.Parse(Row01["date_b"].ToString());
                aRow["結訓日期"] = DateTime.Parse(Row01["date_e"].ToString());
                aRow["上課時數"] = decimal.Parse(Row01["tr_hrs"].ToString());
                aRow["缺課時數"] = decimal.Parse(Row01["at_hrs"].ToString());
                aRow["類別"] = Row01["tr_type"].ToString();
                aRow["上課費用"] = int.Parse(Row01["cos_fee"].ToString());
                aRow["訓練型式"] = Row01["tr_inout"].ToString();
                aRow["講師"] = Row01["tr_teach"].ToString();
                aRow["訓練機構"] = Row01["tr_comp"].ToString();
                //aRow["證照"] = Row01["prove"].ToString();
                aRow["申請編號"] = Row01["applyno"].ToString();
                aRow["ISO"] = Row01["tr_iso"].ToString();                
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}

