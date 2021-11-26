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
    public partial class ZZ2EA_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, work_b, work_e, comp_b, comp_e, date_b, date_e, date_t, in_out, report_type, w8, data_type, comp_name;
        bool exportexcel;
        public ZZ2EA_Report(string nobrb, string nobre, string deptb, string depte, string workb, string worke, string compb, string compe, string dateb, string datee, string datet, string inout, bool _exportexcel, string reporttype, string _w8, string datatype, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; work_b = workb;
            work_e = worke; comp_b = compb; comp_e = compe; date_b = dateb; date_e = datee;
            date_t = datet; in_out = inout; exportexcel = _exportexcel; report_type = reporttype;
            w8 = _w8; data_type = datatype; comp_name = compname;
        }

        private void ZZ2EA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,b.indt,c.d_no_disp as dept,c.d_name from base a,basetts b,dept c";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                sqlCmd += data_type;
                sqlCmd += in_out;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.bdate,a.edate,b.h_code_disp as h_code,b.h_name,a.tol_hours,b.year_rest from abs a,hcode b ";
                sqlCmd1 += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += " and a.h_code=b.h_code";
                sqlCmd1 += w8;
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.edate <='{0}'", date_t);
                sqlCmd1 += " and b.year_rest in ('3','4')";
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd1);
                rq_abs.Columns.Add("dept", typeof(string));
                rq_abs.Columns.Add("d_name", typeof(string));
                rq_abs.Columns.Add("name_c", typeof(string));
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                    }
                }

                DataRow[] ARow = rq_abs.Select("", "dept,nobr,bdate,year_rest,h_code asc");

                string _nobr = "";
                string _edate = "";
                foreach (DataRow Row in ARow)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        string str_edate = DateTime.Parse(Row["edate"].ToString()).ToString("yyyyMMdd");
                        DataRow aRow = ds.Tables["zz2ea"].NewRow();
                        string dd = Row["nobr"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        if (Row["nobr"].ToString() == _nobr && str_edate == "19000101")
                            aRow["edate"] = DateTime.Parse(_edate);
                        else
                            aRow["edate"] = DateTime.Parse(Row["edate"].ToString());
                        if (Row["year_rest"].ToString().Trim() == "3")
                        {
                            aRow["h_code1"] = Row["h_code"].ToString();
                            aRow["h_name1"] = Row["h_name"].ToString();
                            aRow["tol_hours1"] = decimal.Parse(Row["tol_hours"].ToString());
                        }
                        if (Row["year_rest"].ToString().Trim() == "4")
                        {
                            aRow["h_code2"] = Row["h_code"].ToString();
                            aRow["h_name2"] = Row["h_name"].ToString();
                            aRow["tol_hours2"] = decimal.Parse(Row["tol_hours"].ToString());
                        }
                        ds.Tables["zz2ea"].Rows.Add(aRow);
                        _nobr = Row["nobr"].ToString();
                        if (str_edate != "19000101")
                            _edate = Row["edate"].ToString();

                    }
                }
                if (ds.Tables["zz2ea"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (report_type == "1")
                {
                    foreach (DataRow Row in ds.Tables["zz2ea"].Rows)
                    {
                        Row["edate"] = DateTime.Parse(Row["edate"].ToString()).AddDays(1);
                    }
                }

                if (exportexcel)
                {                    
                    Export(ds.Tables["zz2ea"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2ea.rdlc";
                    else if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2ea1.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2ea", ds.Tables["zz2ea"]));
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
            if (report_type == "0")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("差勤日期", typeof(DateTime));
                ExporDt.Columns.Add("補休失效日", typeof(DateTime));
                ExporDt.Columns.Add("得假代碼", typeof(string));
                ExporDt.Columns.Add("得假名稱", typeof(string));
                ExporDt.Columns.Add("得假時數", typeof(decimal));
                ExporDt.Columns.Add("得假累計", typeof(decimal));
                ExporDt.Columns.Add("請假代碼", typeof(string));
                ExporDt.Columns.Add("請假名稱", typeof(string));
                ExporDt.Columns.Add("請假時數", typeof(decimal));
                ExporDt.Columns.Add("請假累計", typeof(string));
                ExporDt.Columns.Add("剩餘時數", typeof(decimal));
                string _nobr = "";
                decimal _tohrs1 = 0;
                decimal _tohrs2 = 0;
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["差勤日期"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["補休失效日"] = DateTime.Parse(Row["edate"].ToString());
                    aRow["得假代碼"] = Row["h_code1"].ToString();
                    aRow["得假名稱"] = Row["h_name1"].ToString();
                    if (Row["tol_hours1"].ToString() == "")
                        aRow["得假時數"] = 0;
                    else
                        aRow["得假時數"] = decimal.Parse(Row["tol_hours1"].ToString());

                    aRow["請假代碼"] = Row["h_code2"].ToString();
                    aRow["請假名稱"] = Row["h_name2"].ToString();
                    if (Row["tol_hours2"].ToString() == "")
                        aRow["請假時數"] = 0;
                    else
                        aRow["請假時數"] = decimal.Parse(Row["tol_hours2"].ToString());

                    if (Row["nobr"].ToString() == _nobr)
                    {
                        _tohrs1 = _tohrs1 + decimal.Parse(aRow["得假時數"].ToString());
                        _tohrs2 = _tohrs2 + decimal.Parse(aRow["請假時數"].ToString());
                    }
                    else
                    {
                        _tohrs1 = decimal.Parse(aRow["得假時數"].ToString());
                        _tohrs2 = decimal.Parse(aRow["請假時數"].ToString());
                    }

                    aRow["得假累計"] = _tohrs1;
                    aRow["請假累計"] = _tohrs2;
                    aRow["剩餘時數"] = _tohrs1 - _tohrs2;
                    ExporDt.Rows.Add(aRow);
                    _nobr = Row["nobr"].ToString();

                }
            }
            else
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("得假累計", typeof(decimal));
                ExporDt.Columns.Add("請假累計", typeof(decimal));
                ExporDt.Columns.Add("剩餘時數", typeof(decimal));
                ExporDt.PrimaryKey = new DataColumn[] { ExporDt.Columns["員工編號"] };
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow row = ExporDt.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (Row["tol_hours1"].ToString() != "")
                            row["得假累計"] = decimal.Parse(row["得假累計"].ToString()) + decimal.Parse(Row["tol_hours1"].ToString());
                        if (Row["tol_hours2"].ToString() != "")
                            row["請假累計"] = decimal.Parse(row["請假累計"].ToString()) + decimal.Parse(Row["tol_hours2"].ToString());
                        row["剩餘時數"] = decimal.Parse(row["得假累計"].ToString()) - decimal.Parse(row["請假累計"].ToString());
                    }
                    else
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["部門代碼"] = Row["dept"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        if (Row["tol_hours1"].ToString() == "")
                            aRow["得假累計"] = 0;
                        else
                            aRow["得假累計"] = decimal.Parse(Row["tol_hours1"].ToString());
                        if (Row["tol_hours2"].ToString() == "")
                            aRow["請假累計"] = 0;
                        else
                            aRow["請假累計"] = decimal.Parse(Row["tol_hours2"].ToString());
                        aRow["剩餘時數"] = decimal.Parse(aRow["得假累計"].ToString()) - decimal.Parse(aRow["請假累計"].ToString());
                        ExporDt.Rows.Add(aRow);
                    }
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
