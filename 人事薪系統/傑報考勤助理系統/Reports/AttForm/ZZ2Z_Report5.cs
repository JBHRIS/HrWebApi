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
    public partial class ZZ2Z_Report5 : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        string responsibility_b, responsibility_e;
        bool exportexcel;
        public ZZ2Z_Report5(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, string reporttype, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel; comp_name = compname; CompId = _CompId;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
            report_type = reporttype;
        }

        private void ZZ2Z_Report5_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlBase += ",b.comp,f.rotet_disp as rotet,f.rotetname,e.jobl_disp as jobl,e.job_name as jobl_name";
                sqlBase += ",b.fulatt,b.indt,g.job_disp as job,g.job_name";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join dept c on b.dept=c.d_no";
                sqlBase += " left outer join depts d on b.depts=d.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " left outer join rotet f on  b.rotet=f.rotet";
                sqlBase += " left outer join job g on b.job=g.job";
                sqlBase += " where a.nobr=b.nobr ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlBase += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                //sqlBase += string.Format(@" and b.carcd between '{0}' and '{1}'", responsibility_b, responsibility_e);
                sqlBase += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);               
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlAttend = "select a.nobr,a.adate,a.late_mins,a.e_mins,a.forget,a.abs,a.rel_hrs,a.early_mins,a.delay_mins";
                sqlAttend += ",a.rote,b.rotename,b.wk_hrs";
                sqlAttend += " from attend a,rote b";
                sqlAttend += " where a.rote=b.rote";
                sqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);              
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"], rq_attend.Columns["adate"] };

                //刷卡資料
                string sql_Attcard = "select nobr,adate,min(tt1) as tt1 from attcard";
                sql_Attcard += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sql_Attcard += " group by nobr,adate order by adate";
                DataTable rq_attcard = SqlConn.GetDataTable(sql_Attcard);
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };
                rq_attcard.Columns.Add("tt2", typeof(string));

                string sql_Attcard1 = "select nobr,adate,max(tt2) as tt2 from attcard";
                sql_Attcard1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sql_Attcard1 += " group by nobr,adate order by adate";
                DataTable rq_attcard1 = SqlConn.GetDataTable(sql_Attcard1);
                rq_attcard1.PrimaryKey = new DataColumn[] { rq_attcard1.Columns["nobr"], rq_attcard1.Columns["adate"] };
                foreach (DataRow Row in rq_attcard.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_attcard1.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["tt2"] = row["tt2"].ToString();
                    }
                    else
                    {
                        Row["tt2"] = "";
                    }
                }
                rq_attcard1 = null;

                //請假資料
                string sqlAbs = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,b.unit,a.tol_hours,b.att";
                sqlAbs += " from abs a,hcode b";
                sqlAbs += " where a.h_code=b.h_code";
                //sqlAbs += string.Format(@" and a.yymm between'{0}'  and '{1}'", yymm_b, yymm_e);
                sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += " and b.year_rest not in ('1','3','5')";
                sqlAbs += " and b.flag='-' and b.h_code_disp not like '%W%'";
                sqlAbs += " order by b.h_code_disp";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                //rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["bdate"], rq_abs.Columns["h_name"] };
                DataTable rq_hcode = new DataTable();
                rq_hcode.Columns.Add("h_code", typeof(string));
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_code"] };

                foreach (DataRow Row in rq_abs.Rows)
                {
                    Row["h_name"] = Row["h_name"].ToString().Trim();
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (Row["unit"].ToString().Trim() == "天")
                        {
                            object[] _value = new object[2];
                            _value[0] = Row["nobr"].ToString();
                            _value[1] = DateTime.Parse(Row["bdate"].ToString());
                            DataRow row2 = rq_attend.Rows.Find(_value);
                            if (row2 != null)
                            {
                                Row["tol_hours"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row2["wk_hrs"].ToString()), 2);
                            }
                        }

                        if (bool.Parse(row["fulatt"].ToString()))
                            Row.Delete();
                        else
                        {
                            DataRow row3 = rq_hcode.Rows.Find(Row["h_code"].ToString());
                            if (row3 == null)
                            {
                                DataRow aRow1 = rq_hcode.NewRow();
                                aRow1["h_code"] = Row["h_code"].ToString();
                                aRow1["h_name"] = Row["h_name"].ToString();
                                rq_hcode.Rows.Add(aRow1);
                            }
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_abs.AcceptChanges();

                //產生請假表頭
                DataRow[] rowt = rq_hcode.Select("", "h_code asc");
                DataRow aRowt = ds.Tables["zz2z5_t"].NewRow();
                for (int i = 0; i < rowt.Length; i++)
                {
                    aRowt["Fld" + (i + 1)] = rowt[i]["h_name"].ToString();
                }
                ds.Tables["zz2z5_t"].Rows.Add(aRowt);

                string sqlOt = "select a.nobr,a.bdate,sum(a.ot_hrs) as ot_hrs,sum(a.rest_hrs) as rest_hrs ";
                sqlOt += " from ot a ";
                //sqlOt += string.Format(@"where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlOt += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlOt += " group by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"], rq_ot.Columns["bdate"] };

                DataTable rq_zz2z5 = new DataTable();
                rq_zz2z5 = ds.Tables["zz2z5"].Clone();
                rq_zz2z5.PrimaryKey = new DataColumn[] { rq_zz2z5.Columns["nobr"], rq_zz2z5.Columns["adate"] };
                //ds.Tables["zz2z5"].PrimaryKey = new DataColumn[] { ds.Tables["zz2z5"].Columns["nobr"], ds.Tables["zz2z5"].Columns["adate"] };
                foreach (DataRow Row in rq_attend.Rows)
                {
                    if (Row.IsNull("early_mins"))
                        Row["early_mins"] = 0;
                    if (Row.IsNull("delay_mins"))
                        Row["delay_mins"] = 0;
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row["adate"].ToString());                        
                        DataRow row1 = rq_attcard.Rows.Find(_value);
                        DataRow row2 = rq_ot.Rows.Find(_value);
                        DataRow aRow = rq_zz2z5.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        aRow["rotename"] = Row["rotename"].ToString();
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                        aRow["tt1"] = "";
                        aRow["tt2"] = "";
                        aRow["ot_hrs"] = 0;
                        aRow["rest_hrs"] = 0;
                        aRow["abs_hrs"] = 0;
                        if (row1 != null)
                        {
                            aRow["tt1"] = row1["tt1"].ToString();
                            aRow["tt2"] = row1["tt2"].ToString();
                        }
                        if (row2 != null)
                        {
                            aRow["ot_hrs"] = decimal.Parse(row2["ot_hrs"].ToString());
                            aRow["rest_hrs"] = decimal.Parse(row2["rest_hrs"].ToString());
                        }
                        aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                        aRow["late_no"] = (decimal.Parse(Row["late_mins"].ToString()) > 0) ? 1 : 0;
                        aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                        aRow["e_no"] = (decimal.Parse(Row["e_mins"].ToString()) > 0) ? 1 : 0;
                        aRow["forget"] = decimal.Parse(Row["forget"].ToString());
                        aRow["att_hrs"] = (Row.IsNull("rel_hrs")) ? 0 : decimal.Parse(Row["rel_hrs"].ToString());
                        //aRow["overtime"] = decimal.Parse(Row["early_mins"].ToString()) + decimal.Parse(Row["delay_mins"].ToString());
                        //aRow["overtime"] = (decimal.Parse(aRow["att_hrs"].ToString()) > 0) ? decimal.Parse(aRow["att_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString()) : 0;
                        aRow["overtime"] = decimal.Parse(aRow["att_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString());
                        for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                        {
                            if (ds.Tables["zz2z5_t"].Columns[i].ToString() != "")
                                aRow["Fld" + (i + 1)] = 0;
                            else
                                break;
                        }
                        rq_zz2z5.Rows.Add(aRow);
                    }
                }

                foreach (DataRow Row in rq_abs.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["bdate"].ToString());
                    DataRow row1 = rq_zz2z5.Rows.Find(_value);
                    if (row1 != null)
                    {
                        row1["abs_hrs"] = decimal.Parse(row1["abs_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                        for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                        {
                            if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() != "")
                            {
                                string dd = ds.Tables["zz2z5_t"].Rows[0][i].ToString();
                                if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() == Row["h_name"].ToString())
                                {
                                    row1["Fld" + (i + 1)] = decimal.Parse(Row["tol_hours"].ToString());
                                    break;
                                }
                            }
                            else
                                break;
                        }
                    }
                }
                if (report_type == "8")
                {
                    DataRow[] SRow = rq_zz2z5.Select("", "dept,nobr,adate asc");
                    foreach (DataRow Row in SRow)
                    {
                        //Row["overtime"] = decimal.Round(decimal.Parse(Row["overtime"].ToString()) / 60, 2);
                        ds.Tables["zz2z5"].ImportRow(Row);
                    }
                }
                else if (report_type == "9")
                {
                    DataRow[] SRow = rq_zz2z5.Select("", "dept,nobr asc");
                    ds.Tables["zz2z5"].PrimaryKey = new DataColumn[] { ds.Tables["zz2z5"].Columns["nobr"] };
                    foreach (DataRow Row in SRow)
                    {
                        //Row["overtime"] = decimal.Round(decimal.Parse(Row["overtime"].ToString()) / 60, 2);
                        DataRow row = ds.Tables["zz2z5"].Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["wk_hrs"] = decimal.Parse(row["wk_hrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                            row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                            row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                            row["abs_hrs"] = decimal.Parse(row["abs_hrs"].ToString()) + decimal.Parse(Row["abs_hrs"].ToString());
                            row["late_mins"] = decimal.Parse(row["late_mins"].ToString()) + decimal.Parse(Row["late_mins"].ToString());
                            row["late_no"] = decimal.Parse(row["late_no"].ToString()) + decimal.Parse(Row["late_no"].ToString());
                            row["e_mins"] = decimal.Parse(row["e_mins"].ToString()) + decimal.Parse(Row["e_mins"].ToString());
                            row["e_no"] = decimal.Parse(row["e_no"].ToString()) + decimal.Parse(Row["e_no"].ToString());
                            row["forget"] = decimal.Parse(row["forget"].ToString()) + decimal.Parse(Row["forget"].ToString());
                            row["att_hrs"] = decimal.Parse(row["att_hrs"].ToString()) + decimal.Parse(Row["att_hrs"].ToString());
                            row["overtime"] = decimal.Parse(row["overtime"].ToString()) + decimal.Parse(Row["overtime"].ToString());
                            for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                            {
                                if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() != "")
                                {
                                    row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz2z5"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["job"] = Row["job"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                            aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                            aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                            aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                            aRow["abs_hrs"] = decimal.Parse(Row["abs_hrs"].ToString());
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["late_no"] = decimal.Parse(Row["late_no"].ToString());
                            aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                            aRow["e_no"] = decimal.Parse(Row["e_no"].ToString());
                            aRow["forget"] = decimal.Parse(Row["forget"].ToString());
                            aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                            aRow["overtime"] = decimal.Parse(Row["overtime"].ToString());
                            for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                            {
                                if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() != "")
                                {
                                    aRow["Fld" + (i + 1)] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                }
                                else
                                    break;
                            }
                            ds.Tables["zz2z5"].Rows.Add(aRow);
                        }
                    }
                }
                else
                {
                    DataRow[] SRow = rq_zz2z5.Select("", "dept asc");
                    ds.Tables["zz2z5"].PrimaryKey = new DataColumn[] { ds.Tables["zz2z5"].Columns["dept"] };
                    foreach (DataRow Row in SRow)
                    {
                        //Row["overtime"] = decimal.Round(decimal.Parse(Row["overtime"].ToString()) / 60, 2);
                        DataRow row = ds.Tables["zz2z5"].Rows.Find(Row["dept"].ToString());
                        if (row != null)
                        {
                            row["wk_hrs"] = decimal.Parse(row["wk_hrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                            row["ot_hrs"] = decimal.Parse(row["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                            row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                            row["abs_hrs"] = decimal.Parse(row["abs_hrs"].ToString()) + decimal.Parse(Row["abs_hrs"].ToString());
                            row["late_mins"] = decimal.Parse(row["late_mins"].ToString()) + decimal.Parse(Row["late_mins"].ToString());
                            row["late_no"] = decimal.Parse(row["late_no"].ToString()) + decimal.Parse(Row["late_no"].ToString());
                            row["e_mins"] = decimal.Parse(row["e_mins"].ToString()) + decimal.Parse(Row["e_mins"].ToString());
                            row["e_no"] = decimal.Parse(row["e_no"].ToString()) + decimal.Parse(Row["e_no"].ToString());
                            row["forget"] = decimal.Parse(row["forget"].ToString()) + decimal.Parse(Row["forget"].ToString());
                            row["att_hrs"] = decimal.Parse(row["att_hrs"].ToString()) + decimal.Parse(Row["att_hrs"].ToString());
                            row["overtime"] = decimal.Parse(row["overtime"].ToString()) + decimal.Parse(Row["overtime"].ToString());
                            for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                            {
                                if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() != "")
                                {
                                    row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz2z5"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["wk_hrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                            aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                            aRow["abs_hrs"] = decimal.Parse(Row["abs_hrs"].ToString());
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["late_no"] = decimal.Parse(Row["late_no"].ToString());
                            aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                            aRow["e_no"] = decimal.Parse(Row["e_no"].ToString());
                            aRow["forget"] = decimal.Parse(Row["forget"].ToString());
                            aRow["att_hrs"] = decimal.Parse(Row["att_hrs"].ToString());
                            aRow["overtime"] = decimal.Parse(Row["overtime"].ToString());
                            for (int i = 0; i < ds.Tables["zz2z5_t"].Columns.Count; i++)
                            {
                                if (ds.Tables["zz2z5_t"].Rows[0][i].ToString() != "")
                                {
                                    aRow["Fld" + (i + 1)] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                }
                                else
                                    break;
                            }
                            ds.Tables["zz2z5"].Rows.Add(aRow);
                        }
                    }
                }
                if (ds.Tables["zz2z5"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz2z5"], ds.Tables["zz2z5_t"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type == "8")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z11.rdlc";
                    else if (report_type == "9")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z13.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z12.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z5", ds.Tables["zz2z5"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z5_t", ds.Tables["zz2z5_t"]));
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

        void Export(DataTable DT, DataTable DT1)
        {

            DataTable ExporDt = new DataTable();            
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (report_type == "8")
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("到職日", typeof(DateTime));
                ExporDt.Columns.Add("出勤日期", typeof(DateTime));
                ExporDt.Columns.Add("出勤班別", typeof(string));
            }
            else if (report_type == "9")
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("到職日", typeof(DateTime));
            }
            ExporDt.Columns.Add("應工作時數", typeof(Decimal));
            if (report_type == "8")
            {
                ExporDt.Columns.Add("上班時間", typeof(string));
                ExporDt.Columns.Add("下班時間", typeof(string));
            }            
            ExporDt.Columns.Add("實際工時", typeof(decimal));
            ExporDt.Columns.Add("超時", typeof(decimal));
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            ExporDt.Columns.Add("遲到次數", typeof(int));
            ExporDt.Columns.Add("早退分鐘", typeof(decimal));
            ExporDt.Columns.Add("早退次數", typeof(int));
            ExporDt.Columns.Add("忘刷次數", typeof(int));           
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("加班總時數", typeof(decimal));            
            ExporDt.Columns.Add("請假總時數", typeof(decimal));            
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();               
                if (report_type == "8")
                {
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["職稱"] = Row["job_name"].ToString();                   
                    aRow["到職日"] = DateTime.Parse(Row["indt"].ToString());
                    aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["出勤班別"] = Row["rotename"].ToString();
                }
                else if (report_type == "9")
                {
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["職稱"] = Row["job_name"].ToString();
                    aRow["到職日"] = DateTime.Parse(Row["indt"].ToString());
                }
                aRow["應工作時數"] = (Row.IsNull("wk_hrs")) ? 0 : decimal.Parse(Row["wk_hrs"].ToString());
                if (report_type == "8")
                {
                    aRow["上班時間"] = Row["tt1"].ToString();
                    aRow["下班時間"] = Row["tt2"].ToString();
                }
                aRow["實際工時"] = (Row.IsNull("att_hrs")) ? 0 : decimal.Parse(Row["att_hrs"].ToString());
                aRow["超時"] = (Row.IsNull("overtime")) ? 0 : decimal.Parse(Row["overtime"].ToString());
                aRow["遲到分鐘"] = (Row.IsNull("late_mins")) ? 0 : decimal.Parse(Row["late_mins"].ToString());
                aRow["遲到次數"] = (Row.IsNull("late_no")) ? 0 : int.Parse(Row["late_no"].ToString());
                aRow["早退分鐘"] = (Row.IsNull("e_mins")) ? 0 : decimal.Parse(Row["e_mins"].ToString());
                aRow["早退次數"] = (Row.IsNull("e_no")) ? 0 : int.Parse(Row["e_no"].ToString());
                aRow["忘刷次數"] = (Row.IsNull("forget")) ? 0 : int.Parse(Row["forget"].ToString());
                aRow["加班時數"] = (Row.IsNull("ot_hrs")) ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                aRow["補休時數"] = (Row.IsNull("rest_hrs")) ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                aRow["加班總時數"] = decimal.Parse(aRow["加班時數"].ToString()) + decimal.Parse(aRow["補休時數"].ToString());
                aRow["請假總時數"] = (Row.IsNull("abs_hrs")) ? 0 : decimal.Parse(Row["abs_hrs"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = (Row.IsNull("Fld" + (i + 1))) ? 0 : decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
