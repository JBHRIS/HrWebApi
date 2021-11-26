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
    public partial class ZZ2H_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, data_report, report_type, comp_name;
        bool exportexcel;
        public ZZ2H_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _compb, string _compe, string _dateb, string _datee, string _typedata, bool _exportexcel, string reporttype, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb;  nobr_e = _nobre; date_b = _dateb; date_e = _datee;
            dept_b = _deptb;  dept_e = _depte; comp_b = _compb; comp_e = _compe;
            data_report = _typedata; exportexcel = _exportexcel;report_type = reporttype;
            comp_name = compname;
        }               

        private void ZZ2H_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };

                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,c.dept_tree";
                sqlBase += ",d.job_disp as job,d.job_name";
                sqlBase += " from base a,basetts b,dept c,job d ";
                sqlBase += " where a.nobr=b.nobr and b.dept=c.d_no and b.job=d.job";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += data_report;
                sqlBase += " order by a.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //加班時數
                String sqlOt;
                if (report_type == "0")
                    sqlOt = "select a.nobr,sum(a.ot_hrs+a.rest_hrs) as ot_hrs from ot a,otrcd b";
                else
                    sqlOt = "select a.nobr,a.bdate,sum(a.ot_hrs+a.rest_hrs) as ot_hrs from ot a,otrcd b";
                sqlOt += " where a.otrcd=b.otrcd";
                sqlOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (report_type == "0")
                    sqlOt += " group by a.nobr";
                else
                    sqlOt += " group by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                if (report_type == "0")
                    rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
                else
                    rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"], rq_ot.Columns["bdate"] };

                string sqlAttend = "select a.nobr,a.adate,b.on_time,b.off_time, early_mins,delay_mins ";
                sqlAttend += " from attend a,rote b where a.rote=b.rote";
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += " order by a.nobr";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                rq_attend.Columns.Add("t1", typeof(string));
                rq_attend.Columns.Add("t2", typeof(string));
                rq_attend.Columns.Add("over_time", typeof(decimal));
                //foreach (DataRow Row in rq_attend.Rows)
                //{
                //    Row["over_time"] = 0;
                //    decimal overtime = 0;
                //    if (!Row.IsNull("early_mins"))
                //    {
                //        if (decimal.Parse(Row["early_mins"].ToString()) > 30)
                //        {
                //            overtime = decimal.Floor(decimal.Parse(Row["early_mins"].ToString()) / 60);
                //            if (decimal.Remainder(decimal.Parse(Row["early_mins"].ToString()), decimal.Parse("60")) >= 30)
                //                overtime += 0.5m;
                //        }
                //    }
                //    if (!Row.IsNull("delay_mins"))
                //    {
                //        if (decimal.Parse(Row["delay_mins"].ToString()) > 30)
                //        {
                //            overtime = overtime + decimal.Floor(decimal.Parse(Row["delay_mins"].ToString()) / 60);
                //            if (decimal.Remainder(decimal.Parse(Row["delay_mins"].ToString()), decimal.Parse("60")) >= 30)
                //                overtime += 0.5m;
                //        }
                        
                //    }
                //    Row["over_time"] = overtime;
                //}

                string sqlAttcard = "select nobr,adate,t1,t2 from attcard";
                sqlAttcard += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttcard += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_attcard = SqlConn.GetDataTable(sqlAttcard);
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"], rq_attcard.Columns["T1"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    string _DDA = DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd");
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    _value[2] = Row["T1"].ToString();
                    DataRow row = rq_attcard.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["t1"] = row["t1"].ToString();
                        Row["t2"] = row["t2"].ToString();
                        if (Row["off_time"].ToString().Trim() == "" && row["t1"].ToString().Trim() != "")
                            Row["off_time"] = row["t1"].ToString();

                        decimal _t2 = 0; decimal _offtime = 0;
                        if (row["t2"].ToString().Trim() != "")
                        {
                            string at = row["t2"].ToString().Substring(0, 2);
                            string sd = row["t2"].ToString().Substring(2, 2);
                            if (row["t2"].ToString().Trim() != "" && row["t2"].ToString().Trim().Length == 4)
                                _t2 = Convert.ToDecimal(row["t2"].ToString().Substring(0, 2)) * 60 + Convert.ToDecimal(row["t2"].ToString().Substring(2, 2));
                            if (Row["off_time"].ToString().Trim() != "" && Row["off_time"].ToString().Trim().Length == 4)
                                _offtime = Convert.ToDecimal(Row["off_time"].ToString().Substring(0, 2)) * 60 + Convert.ToDecimal(Row["off_time"].ToString().Substring(2, 2));
                            Row["over_time"] = Math.Floor((_t2 - _offtime) / 30) / 2;
                        }
                        else
                            Row["over_time"] = 0;
                    }
                    else
                        Row["over_time"] = 0;
                }
                rq_attcard = null;

                DataTable rq_attenda = new DataTable();
                rq_attenda.Columns.Add("nobr", typeof(string));
                rq_attenda.Columns.Add("over_time", typeof(decimal));
                if (report_type == "0")
                    rq_attenda.PrimaryKey = new DataColumn[] { rq_attenda.Columns["nobr"] };
                else
                {
                    rq_attenda.Columns.Add("adate", typeof(DateTime));
                    rq_attenda.PrimaryKey = new DataColumn[] { rq_attenda.Columns["nobr"], rq_attenda.Columns["adate"] };
                }
                foreach (DataRow Row in rq_attend.Rows)
                {
                    decimal _sdfd = decimal.Parse(Row["over_time"].ToString());
                    if (decimal.Parse(Row["over_time"].ToString()) >= Convert.ToDecimal(0.5))
                    {
                        DataRow row = null;
                        if (report_type == "0")
                            row = rq_attenda.Rows.Find(Row["nobr"].ToString());
                        else
                        {
                            object[] _value = new object[2];
                            _value[0] = Row["nobr"].ToString();
                            _value[1] = DateTime.Parse(Row["adate"].ToString());
                        }
                        if (row != null)
                            row["over_time"] = decimal.Parse(row["over_time"].ToString()) + decimal.Parse(Row["over_time"].ToString());
                        else
                        {
                            DataRow aRow = rq_attenda.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            if (report_type == "4")
                                aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                            aRow["over_time"] = decimal.Parse(Row["over_time"].ToString());
                            rq_attenda.Rows.Add(aRow);
                        }
                    }
                }
                rq_attend = null;
                foreach (DataRow Row in rq_attenda.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1;
                        if (report_type == "0")
                            row1 = rq_ot.Rows.Find(Row["nobr"].ToString());
                        else
                        {
                            object[] _value = new object[2];
                            _value[0] = Row["nobr"].ToString();
                            _value[1] = DateTime.Parse(Row["adate"].ToString());
                            row1 = rq_ot.Rows.Find(_value);
                        }
                        DataRow aRow = ds.Tables["zz2h1"].NewRow();
                        DataRow row2 = rq_depttree.Rows.Find(row["dept_tree"].ToString());
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["dept_tree"] = (row2 != null) ? row2["d_no_disp"].ToString().Trim() + " " + row2["d_name"].ToString() : "";
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["over_time"] = decimal.Parse(Row["over_time"].ToString());
                        //DataRow row2 = rq_ot.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                            aRow["ot_hrs"] = decimal.Parse(row1["ot_hrs"].ToString());
                        else
                            aRow["ot_hrs"] = 0;
                        aRow["over_time1"] = decimal.Parse(aRow["over_time"].ToString()) - decimal.Parse(aRow["ot_hrs"].ToString());
                        if (report_type == "4")
                            aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        ds.Tables["zz2h1"].Rows.Add(aRow);
                    }
                }
                rq_attenda = null; rq_depttree = null; rq_base = null; rq_ot = null;

                if (ds.Tables["zz2h1"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2h1"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h1.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h5.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h1", ds.Tables["zz2h1"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            if (report_type=="0")
                ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            if (report_type == "4")
                ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            ExporDt.Columns.Add("超時時數", typeof(decimal));
            ExporDt.Columns.Add("申請時數", typeof(decimal));
            ExporDt.Columns.Add("未申請時數", typeof(decimal));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                if (report_type == "0")
                    aRow["報表分析群組"] = Row["dept_tree"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["超時時數"] = decimal.Parse(Row["over_time"].ToString());
                aRow["申請時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["未申請時數"] = decimal.Parse(Row["over_time1"].ToString());
                if (report_type == "4")
                    aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
