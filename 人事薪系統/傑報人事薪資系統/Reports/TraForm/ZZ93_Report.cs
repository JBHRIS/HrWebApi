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
    public partial class ZZ93_Report : JBControls.JBForm
    {
        TraDataSet ds = new TraDataSet();
        string nobr_b, nobr_e, comp_b, comp_e, dept_b, dept_e, subcode_b, subcode_e, date_b, date_e, type_data, compname;
        bool exportexcel;
        public ZZ93_Report(string nobrb, string nobre, string compb, string compe, string deptb, string depte, string subcodeb, string subcodee, string dateb, string datee, string typedata, bool _exportexcel, string _compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; comp_b = compb; comp_e = compe;
            subcode_b = subcodeb; subcode_e = subcodee; date_b = dateb;
            date_e = datee; type_data = typedata; exportexcel = _exportexcel;
            dept_b = deptb; dept_e = depte; compname = _compname;
        }

        private void ZZ93_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);               
                sqlCmd += type_data;               
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select  c.nobr as idno,a.course,a.date_b,a.date_e,a.tr_hrs,b.tr_type_disp as tr_type,a.cos_fee,a.tr_inout,a.tr_teach";
                sqlCmd1 += ",f.tr_comp_name as tr_comp,'' as prove,c.applyno,c.close_,a.aborad,c.tr_repo";
                sqlCmd1 += " from trcosp c, trcosc a";
                sqlCmd1 += " left outer join trtype b on a.tr_type=b.tr_type";
                sqlCmd1 += " left outer join trcompy f on a.tr_comp=f.tr_comp";
                sqlCmd1 += string.Format(@" where a.guid=c.course and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.date_b between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += string.Format(@" and b.tr_type_disp between '{0}' and '{1}'", subcode_b, subcode_e);
                DataTable rq_trcosf = SqlConn.GetDataTable(sqlCmd1);
                DataTable rq_zz93 = new DataTable();
                rq_zz93 = ds.Tables["zz93"].Clone();
                foreach (DataRow Row in rq_trcosf.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["idno"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz93.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString().Trim();
                        aRow["idno"] = Row["idno"].ToString().Trim();
                        aRow["name_c"] = row["name_c"].ToString().Trim();
                        aRow["course"] = Row["course"].ToString().Trim();
                        aRow["date_b"] = DateTime.Parse(Row["date_b"].ToString());
                        aRow["date_e"] = DateTime.Parse(Row["date_e"].ToString());
                        aRow["tr_hrs"] = decimal.Parse(Row["tr_hrs"].ToString());                        
                        aRow["tr_type"] = Row["tr_type"].ToString();
                        aRow["cos_fee"] = decimal.Round(decimal.Parse(Row["cos_fee"].ToString()), 0);
                        aRow["tr_inout"] = Row["tr_inout"].ToString().Trim();
                        aRow["tr_teach"] = Row["tr_teach"].ToString().Trim();
                        aRow["tr_comp"] = Row["tr_comp"].ToString().Trim();
                        aRow["prove"] = Row["prove"].ToString().Trim();
                        aRow["applyno"] = Row["applyno"].ToString().Trim();
                        aRow["close_"] = bool.Parse(Row["close_"].ToString().Trim());
                        aRow["aborad"] = bool.Parse(Row["aborad"].ToString().Trim());
                        aRow["tr_repo"] = bool.Parse(Row["tr_repo"].ToString().Trim());
                        //aRow["abs"] = bool.Parse(Row["abs"].ToString().Trim());
                        rq_zz93.Rows.Add(aRow);
                    }
                }

                if (rq_zz93.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataRow[] SRow = rq_zz93.Select("", "course asc");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz93"].ImportRow(Row);
                }
                rq_base = null; rq_trcosf = null; rq_zz93 = null;               

                if (exportexcel)
                {
                    Export(ds.Tables["zz93"]);
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
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "TraReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz93.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", compname) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("TraDataSet_zz93", ds.Tables["zz93"]));
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
            //ExporDt.Columns.Add("部門代碼", typeof(string));
            //ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("類別", typeof(string));           
            ExporDt.Columns.Add("開訓日期", typeof(DateTime));
            ExporDt.Columns.Add("結訓日期", typeof(DateTime));
            ExporDt.Columns.Add("課程", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("上課時數", typeof(decimal));          
            ExporDt.Columns.Add("上課費用", typeof(int));
            ExporDt.Columns.Add("結訓", typeof(string));
            ExporDt.Columns.Add("國外", typeof(string));
            //ExporDt.Columns.Add("請假", typeof(string));
            ExporDt.Columns.Add("訓練型式", typeof(string));
            ExporDt.Columns.Add("講師", typeof(string));
            ExporDt.Columns.Add("訓練機構", typeof(string));
            ExporDt.Columns.Add("完成評核", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                //aRow["部門代碼"] = Row01["dept"].ToString();
                //aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["類別"] = Row01["tr_type"].ToString();
                aRow["開訓日期"] = DateTime.Parse(Row01["date_b"].ToString());
                aRow["結訓日期"] = DateTime.Parse(Row01["date_e"].ToString());
                aRow["課程"] = Row01["course"].ToString();
                aRow["員工編號"] = Row01["idno"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["上課時數"] = decimal.Parse(Row01["tr_hrs"].ToString());
                aRow["上課費用"] = int.Parse(Row01["cos_fee"].ToString());
                aRow["結訓"] = (bool.Parse(Row01["close_"].ToString())) ? "是" : "否";
                aRow["國外"] = (bool.Parse(Row01["aborad"].ToString())) ? "是" : "否";
                //aRow["請假"] = (bool.Parse(Row01["abs"].ToString())) ? "是" : "否";
                aRow["訓練型式"] = Row01["tr_inout"].ToString();
                aRow["講師"] = Row01["tr_teach"].ToString();
                aRow["訓練機構"] = Row01["tr_comp"].ToString();
                //aRow["證照"] = Row01["prove"].ToString();
                aRow["完成評核"] = (bool.Parse(Row01["tr_repo"].ToString())) ? "V" : "";
                ExporDt.Rows.Add(aRow);
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
