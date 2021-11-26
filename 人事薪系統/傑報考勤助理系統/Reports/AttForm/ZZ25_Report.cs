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
    public partial class ZZ25_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string in_out, date_type, jobl_b, jobl_e, username, saladr_b, saladr_e, comp_name;
        string nobr_b, nobr_e, dept_b, dept_e, job_b, job_e, work_b, work_e, comp_b, comp_e, date_b, date_e, date_n, reporttype, _date, type_data;
        bool exportexcel;
        public ZZ25_Report(string nobrb, string nobre, string deptb, string depte, string jobb, string jobe, string joblb, string joble, string workb, string worke, string compb, string compe, string saladrb, string saladre, string dateb, string datee, string daten, string _reporttype, string _date1, string typedata, string inout, bool _exportexcel, string datetype, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; job_b = jobb;
            job_e = jobe; work_b = workb; work_e = worke; comp_b = compb; comp_e = compe;
            date_b = dateb; date_e = datee;
            date_n = daten; reporttype = _reporttype; saladr_b = saladrb; saladr_e = saladre;
            _date = _date1; type_data = typedata; in_out = inout; exportexcel = _exportexcel;
            date_type = datetype; jobl_b = joblb; jobl_e = joble; username = _username;
            comp_name = compname;
        }

        private void ZZ25_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,d.jobl_disp as jobl,d.job_name";
                sqlCmd += ",c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.cindt ";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join jobl d on  b.jobl=d.jobl";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and e.job_disp between '{0}' and '{1}'", job_b, job_e);
                sqlCmd += string.Format(@" and d.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlCmd += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlCmd += type_data;
                sqlCmd += in_out;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,a.tol_hours,b.unit,b.year_rest ";
                sqlCmd1 += " from abs a,hcode b where a.h_code=b.h_code";
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd1 += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);
                sqlCmd1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_n);
                sqlCmd1 += " and b.year_rest in('1','2')";
                sqlCmd1 += " order by a.nobr,a.bdate";
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd1);
                if (date_type == "1")
                {
                    string sqlCmd2 = "select a.nobr,a.bdate,a.edate,b.h_code_disp as h_code,b.h_name,a.tol_hours from abs a,hcode b";
                    sqlCmd2 += " where a.h_code=b.h_code";
                    sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    //sqlCmd2 += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);
                    sqlCmd2 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_n);
                    sqlCmd2 += " and b.year_rest='1'";
                    DataTable rq_absw = SqlConn.GetDataTable(sqlCmd2);
                    foreach (DataRow Row in rq_abs.Rows)
                    {
                        string _bdate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                        DataRow[] row = rq_absw.Select("nobr='" + Row["nobr"].ToString() + "' and '" + _bdate + "'> bdate and '" + _bdate + "' <edate");
                        if (row.Length < 1)
                            Row.Delete();
                    }
                    rq_abs.AcceptChanges();
                    rq_absw = null;
                }
                foreach (DataRow Row in rq_abs.Rows)
                {                               
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = ds.Tables["zz25"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["h_code"] = Row["h_code"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["jobl"] = row["jobl"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        aRow["cindt"] = DateTime.Parse(row["cindt"].ToString());
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["unit"] = Row["unit"].ToString();
                        if (Row["year_rest"].ToString() == "1")
                        {
                            aRow["h_code1"] = Row["h_code"].ToString();
                            aRow["h_name1"] = Row["h_name"].ToString();
                            aRow["tol_hours1"] = decimal.Parse(Row["tol_hours"].ToString());
                        }
                        else if (Row["year_rest"].ToString() == "2")
                        {
                            aRow["h_code2"] = Row["h_code"].ToString();
                            aRow["h_name2"] = Row["h_name"].ToString();
                            aRow["tol_hours2"] = decimal.Parse(Row["tol_hours"].ToString());
                        }
                        ds.Tables["zz25"].Rows.Add(aRow);
                    }
                }
                rq_abs = null;
                rq_base = null;

                if (ds.Tables["zz25"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz25"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz25.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz251.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz25", ds.Tables["zz25"]));
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
            DataRow[] DTrow = DT.Select("", "dept,nobr asc");
            if (reporttype == "0")
            {
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("進集團期", typeof(DateTime));
                ExporDt.Columns.Add("差勤日期", typeof(DateTime));
                ExporDt.Columns.Add("得假代碼", typeof(string));
                ExporDt.Columns.Add("得假名稱", typeof(string));
                ExporDt.Columns.Add("得假時數", typeof(decimal));
                ExporDt.Columns.Add("請假代碼", typeof(string));
                ExporDt.Columns.Add("請假名稱", typeof(string));
                ExporDt.Columns.Add("請假時數", typeof(decimal));
                foreach (DataRow Row in DTrow)
                {
                    string _aaa = Row["tol_hours2"].ToString();
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["英文部門名稱"] = Row["d_ename"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["進集團期"] = DateTime.Parse(Row["cindt"].ToString());
                    aRow["差勤日期"] = DateTime.Parse(Row["bdate"].ToString());
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
                    ExporDt.Rows.Add(aRow);
                }
            }
            else
            {
                ExporDt.Columns.Add("職等", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("得假累計", typeof(decimal));
                ExporDt.Columns.Add("請假累計", typeof(decimal));
                ExporDt.Columns.Add("剩餘", typeof(decimal));
                ExporDt.PrimaryKey = new DataColumn[] { ExporDt.Columns["員工編號"] };
                foreach (DataRow Row in DTrow)
                {
                    DataRow row = ExporDt.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (Row["tol_hours1"].ToString() != "")
                            row["得假累計"] = decimal.Parse(row["得假累計"].ToString()) + decimal.Parse(Row["tol_hours1"].ToString());
                        if (Row["tol_hours2"].ToString() != "")
                            row["請假累計"] = decimal.Parse(row["請假累計"].ToString()) + decimal.Parse(Row["tol_hours2"].ToString());
                        row["剩餘"] = decimal.Parse(row["得假累計"].ToString()) - decimal.Parse(row["請假累計"].ToString());
                    }
                    else
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["職等"] = Row["job_name"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["英文部門名稱"] = Row["d_ename"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["英文姓名"] = Row["name_e"].ToString();
                        if (Row["tol_hours1"].ToString() != "")
                            aRow["得假累計"] = decimal.Parse(Row["tol_hours1"].ToString());
                        else
                            aRow["得假累計"] = 0;
                        if (Row["tol_hours2"].ToString() != "")
                            aRow["請假累計"] = decimal.Parse(Row["tol_hours2"].ToString());
                        else
                            aRow["請假累計"] = 0;
                        aRow["剩餘"] = decimal.Parse(aRow["得假累計"].ToString()) - decimal.Parse(aRow["請假累計"].ToString());
                        ExporDt.Rows.Add(aRow);
                    }
                }

            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
