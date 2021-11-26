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
    public partial class ZZ2H5_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, data_report, comp_name;
        bool exportexcel;
        public ZZ2H5_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _compb, string _compe, string _dateb, string _datee, string _typedata, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; date_b = _dateb; date_e = _datee; dept_b = _deptb;
            dept_e = _depte; comp_b = _compb; comp_e = _compe; data_report = _typedata;
            exportexcel = _exportexcel; comp_name = compname;
        }

        private void ZZ2H5_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.ttscode,b.oudt";
                sqlBase += " from base a,basetts b,dept c";
                sqlBase += " where a.nobr=b.nobr and b.dept=c.d_no ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += data_report;
                sqlBase += " order by a.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                int _datee = Convert.ToInt32(DateTime.Parse(date_e).ToString("yyyyMMdd"));
                foreach (DataRow Row in rq_base.Rows)
                {
                    if (Row["ttscode"].ToString().Trim() == "2")
                    {
                        int oudt = Convert.ToInt32(DateTime.Parse(Row["oudt"].ToString()).ToString("yyyyMMdd"));
                        if (oudt < _datee)
                            Row.Delete();
                    }
                }
                rq_base.AcceptChanges();

                string _dateb1 = Convert.ToString(DateTime.Parse(date_b).Year) + "/01/01";
                string _datee1 = Convert.ToString(DateTime.Parse(date_b).Year) + "/12/31";
                string _datee2 = DateTime.Parse(date_b).AddDays(-1).ToString("yyyy/MM/dd");

                //請假時數得
                string sqlAbsw = "select a.nobr,sum(a.tol_hours) as hrs from abs a,hcode b ";
                sqlAbsw += " where a.h_code=b.h_code";
                sqlAbsw += string.Format(@" and a.bdate between '{0}' and '{1}'", _dateb1, _datee1);
                sqlAbsw += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbsw += " and b.htype in ('1','2') and b.flag='+' group by a.nobr order by a.nobr";
                sqlAbsw += " and b.htype in ('1') and b.flag='+' group by a.nobr order by a.nobr";
                DataTable rq_absw = SqlConn.GetDataTable(sqlAbsw);
                rq_absw.PrimaryKey = new DataColumn[] { rq_absw.Columns["nobr"] };

                //請假期初
                string sqlAbst = "select a.nobr,sum(a.tol_hours) as hrs from abs a,hcode b";
                sqlAbst += " where a.h_code=b.h_code";
                //sqlAbst += string.Format(@" and a.bdate between '{0}' and '{1}'", _dateb1, _datee2);
                sqlAbst += string.Format(@" and a.bdate between '{0}' and '{1}'", _dateb1, date_e);
                sqlAbst += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbst += " and b.htype in ('1','2') and b.flag='-'";
                sqlAbst += " and b.htype in ('1') and b.flag='-' and b.mang <> 1";
                //sqlAbst += " and b.h_code_disp in ('A','B','C','K','B1','C1')";
                sqlAbst += " group by a.nobr";
                DataTable rq_abst = SqlConn.GetDataTable(sqlAbst);
                rq_abst.PrimaryKey = new DataColumn[] { rq_abst.Columns["nobr"] };

                //請假時數
                string sqlAbs = "select nobr,sum(tol_hours) as hrs,count(nobr) as qt from abs a,hcode b";
                sqlAbs += " where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += " and b.h_code_disp in ('A','B','C','K','B1','C1')";
                sqlAbs += " and b.htype in ('2','4','5') and b.flag='-' and b.mang <> 1 ";
                sqlAbs += " group by a.nobr";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"] };

                string sqlAttend = "select nobr,sum(late_mins) as late_mins,count(nobr) as qt from attend";
                sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " and late_mins >0 group by nobr";
                //sqlAttend += " and late_mins between 1 and 60 group by nobr";
                DataTable rq_att = SqlConn.GetDataTable(sqlAttend);
                rq_att.PrimaryKey = new DataColumn[] { rq_att.Columns["nobr"] };

                string sqlAttend1 = "select a.nobr,a.adate,b.on_time,b.off_time ";
                sqlAttend1 += " from attend a,rote b where a.rote=b.rote";
                sqlAttend1 += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend1);
                rq_attend.Columns.Add("t1", typeof(string));
                rq_attend.Columns.Add("t2", typeof(string));
                rq_attend.Columns.Add("over_time", typeof(decimal));

                string sqlAttcard = "select nobr,adate,t1,t2 from attcard";
                sqlAttcard += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttcard += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_attcard = SqlConn.GetDataTable(sqlAttcard);
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };

                foreach (DataRow Row in rq_attend.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
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

                DataTable rq_attendc = new DataTable();
                rq_attendc.Columns.Add("nobr", typeof(string));
                rq_attendc.Columns.Add("over_time", typeof(decimal));
                rq_attendc.PrimaryKey = new DataColumn[] { rq_attendc.Columns["nobr"] };

                foreach (DataRow Row in rq_attend.Rows)
                {
                    if (decimal.Parse(Row["over_time"].ToString()) >= Convert.ToDecimal(0.5))
                    {
                        DataRow row = rq_attendc.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                            row["over_time"] = decimal.Parse(row["over_time"].ToString()) + decimal.Parse(Row["over_time"].ToString());
                        else
                        {
                            DataRow aRow = rq_attendc.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["over_time"] = decimal.Parse(Row["over_time"].ToString());
                            rq_attendc.Rows.Add(aRow);
                        }
                    }
                }
                rq_attend = null;

                foreach (DataRow Row in rq_absw.Rows)
                {
                    DataRow row = rq_abs.Rows.Find(Row["nobr"].ToString());//請假
                    DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_att.Rows.Find(Row["nobr"].ToString());
                    DataRow row3 = rq_attendc.Rows.Find(Row["nobr"].ToString());
                    DataRow row4 = rq_abst.Rows.Find(Row["nobr"].ToString());//請假期初

                    if (row1 != null)
                    {
                        DataRow aRow = ds.Tables["zz2h5"].NewRow();
                        aRow["nobr"] = row1["nobr"].ToString();
                        aRow["name_c"] = row1["name_c"].ToString();
                        aRow["name_e"] = row1["name_e"].ToString();
                        aRow["dept"] = row1["dept"].ToString();
                        aRow["d_name"] = row1["d_name"].ToString();
                        aRow["d_ename"] = row1["d_ename"].ToString();
                        if (row != null)
                        {
                            aRow["abs_hrs"] = decimal.Parse(row["hrs"].ToString());
                            aRow["abs_qt"] = Math.Round(decimal.Parse(row["qt"].ToString()),MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            aRow["abs_hrs"] = 0;
                            aRow["abs_qt"] = 0;
                        }

                        aRow["abs_w"] = decimal.Parse(Row["hrs"].ToString());
                        if (row2 != null)
                        {
                            aRow["late_mins"] = decimal.Parse(row2["late_mins"].ToString());
                            aRow["l_qt"] = decimal.Parse(row2["qt"].ToString());
                        }
                        else
                        {
                            aRow["late_mins"] = 0;
                            aRow["l_qt"] = 0;
                        }
                        aRow["over_day"] = (row3 != null) ? Math.Round(decimal.Parse(row3["over_time"].ToString()) / 8, 1, MidpointRounding.AwayFromZero) : 0;
                        aRow["over_time"] = (row3 != null) ? decimal.Parse(row3["over_time"].ToString()) : 0;
                        aRow["abs_t"] = (row4 != null) ? decimal.Parse(row4["hrs"].ToString()) : 0;
                        aRow["abs_l"] = decimal.Parse(aRow["abs_w"].ToString())  - decimal.Parse(aRow["abs_t"].ToString());

                        ds.Tables["zz2h5"].Rows.Add(aRow);
                    }

                }
                rq_abs = null;
                rq_abst = null;
                rq_absw = null;
                rq_att = null;
                rq_base = null;
                rq_attendc = null;

                if (ds.Tables["zz2h5"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2h5"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2h6.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2h5", ds.Tables["zz2h5"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("超時時數", typeof(decimal));
            ExporDt.Columns.Add("超時天數", typeof(decimal));
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            ExporDt.Columns.Add("遲到次數", typeof(int));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("請假次數", typeof(int));
            ExporDt.Columns.Add("特休(得)", typeof(decimal));
            ExporDt.Columns.Add("請假(累)", typeof(decimal));
            ExporDt.Columns.Add("剩餘時數", typeof(decimal));

            DataRow[] Rowt = DT.Select("", "dept asc");
            foreach (DataRow Row in Rowt)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["超時時數"] = decimal.Parse(Row["over_time"].ToString());
                aRow["超時天數"] = decimal.Parse(Row["over_day"].ToString());
                aRow["遲到分鐘"] = decimal.Parse(Row["late_mins"].ToString());
                aRow["遲到次數"] = decimal.Round(decimal.Parse(Row["l_qt"].ToString()), 0);
                aRow["請假時數"] = decimal.Parse(Row["abs_hrs"].ToString());
                aRow["請假次數"] = decimal.Round(decimal.Parse(Row["abs_qt"].ToString()), 0);
                aRow["特休(得)"] = decimal.Parse(Row["abs_w"].ToString());
                aRow["請假(累)"] = decimal.Parse(Row["abs_t"].ToString());
                aRow["剩餘時數"] = decimal.Parse(Row["abs_l"].ToString());

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
