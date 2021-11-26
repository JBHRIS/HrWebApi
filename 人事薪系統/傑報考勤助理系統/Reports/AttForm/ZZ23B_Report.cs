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
    public partial class ZZ23B_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string check_rote, type_data, lcstr, str1;
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, htype_b, htype_e, username, comp_name;
        string yymm_b, yymm_e, date_b, date_e, reporttype, saladr_b, saladr_e;
        bool exportexcel;
        public ZZ23B_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string htypeb, string htypee, string saladrb, string saladre, string yymmb, string yymme, string dateb, string datee, string checkrote, string typedata, string _lcstr, string _reporttype, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe;
            htype_b = htypeb; htype_e = htypee; yymm_b = yymmb; yymm_e = yymme; date_b = dateb;
            date_e = datee; reporttype = _reporttype; exportexcel = _exportexcel; check_rote = checkrote;
            type_data = typedata; lcstr = _lcstr; username = _username; saladr_b = saladrb; saladr_e = saladre;
            comp_name = compname;
        }

        private void ZZ23B_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += "  from base a,basetts b,dept c where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,tol_hours,yymm,balance,guid";
                sqlAbs += ",b.htype,b.h_code_disp as h_code,b.h_name,b.flag,b.unit,datename(dw,a.bdate) as dw,c.type_name";
                sqlAbs += " from abs a,hcode b";
                sqlAbs += " left outer join hcodetype c on b.htype=c.htype";
                sqlAbs += " where a.h_code =b.h_code";
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and b.htype between '{0}' and '{1}'", htype_b, htype_e);
                sqlAbs += lcstr;
                sqlAbs += " order by b.h_code_disp";
                DataTable rq_abs=SqlConn.GetDataTable(sqlAbs);
                rq_abs.Columns.Add("dept", typeof(string));
                rq_abs.Columns.Add("d_name", typeof(string));
                rq_abs.Columns.Add("name_c", typeof(string));
                //rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["guid"] };

                //個人假別彙總
                DataTable rq_hode = new DataTable();
                rq_hode.Columns.Add("h_code", typeof(string));
                rq_hode.Columns.Add("h_name", typeof(string));
                rq_hode.PrimaryKey = new DataColumn[] { rq_hode.Columns["h_name"] };
                foreach (DataRow Row in rq_abs.Rows)
                {
                    Row["dw"] = JBHR.Reports.ReportClass.GetDayWeek(DateTime.Parse(Row["bdate"].ToString()));
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["name_c"] = row["name_c"].ToString();

                        if (Row["flag"].ToString().Trim() == "-")
                        {
                            DataRow row1 = rq_hode.Rows.Find(Row["h_name"].ToString().Trim());
                            if (row1 == null)
                            {
                                DataRow aRow = rq_hode.NewRow();
                                aRow["h_code"] = Row["h_code"].ToString();
                                aRow["h_name"] = Row["h_name"].ToString().Trim();
                                rq_hode.Rows.Add(aRow);
                            }
                        }
                    }
                    else
                        Row.Delete();
                }
                int grp = 0;
                rq_abs.AcceptChanges();
                if (rq_abs.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (reporttype == "0" || reporttype == "3")
                {
                    DataRow[] SRow = rq_abs.Select("flag='-'", "dept,nobr,bdate asc");
                    if (reporttype == "0")
                    {
                        foreach (DataRow Row in SRow)
                        {
                            DataRow aRow = ds.Tables["zz23b"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["deduct_date"] = DateTime.Parse(Row["bdate"].ToString());
                            aRow["dw"] = Row["dw"].ToString().Substring(2, 1); ;
                            //aRow["dw"] = JBHR.Reports.ReportClass.GetTransWK(DateTime.Parse(Row["bdate"].ToString()));
                            aRow["deduct_hcode"] = Row["h_code"].ToString();
                            aRow["deduct_hname"] = Row["h_name"].ToString();
                            aRow["deduct_btime"] = Row["btime"].ToString();
                            aRow["deduct_etime"] = Row["etime"].ToString();
                            aRow["deduct_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                            aRow["unit"] = Row["unit"].ToString();
                            ds.Tables["zz23b"].Rows.Add(aRow);
                        }
                        if (ds.Tables["zz23b"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                    }
                    else
                    {
                        ds.Tables["Abssumd"].PrimaryKey = new DataColumn[] { ds.Tables["Abssumd"].Columns["nobr"] };
                        foreach (DataRow Row in SRow)
                        {
                            DataRow row = ds.Tables["Abssumd"].Rows.Find(Row["nobr"].ToString());
                            if (row != null)
                            {
                                for (int i = 0; i < rq_hode.Rows.Count; i++)
                                {
                                    if (Row["h_name"].ToString().Trim() == rq_hode.Rows[i]["h_name"].ToString())
                                    {
                                        row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["Abssumd"].NewRow();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = Row["name_c"].ToString();
                                for (int i = 0; i < rq_hode.Rows.Count; i++)
                                {
                                    aRow["Fld" + (i + 1)] = 0;
                                    if (Row["h_name"].ToString().Trim() == rq_hode.Rows[i]["h_name"].ToString())
                                        aRow["Fld" + (i + 1)] = decimal.Parse(Row["tol_hours"].ToString());
                                }
                                ds.Tables["Abssumd"].Rows.Add(aRow);
                            }
                        }

                        DataRow aRow1 = ds.Tables["Abssumd1"].NewRow();
                        for (int i = 0; i < rq_hode.Rows.Count; i++)
                        {
                            aRow1["Fld" + (i + 1)] = rq_hode.Rows[i]["h_name"].ToString();
                        }
                        ds.Tables["Abssumd1"].Rows.Add(aRow1);
                        if (ds.Tables["Abssumd"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                    }
                    
                }
                else if (reporttype == "1")
                {
                    DataRow[] SRow = rq_abs.Select("flag='+'", "dept,nobr,bdate asc");
                    foreach (DataRow Row in SRow)
                    {
                        decimal _tolhours = decimal.Parse(Row["tol_hours"].ToString());
                        string sqlAbsd = "select b.bdate,datename(dw,b.bdate) as dw,c.h_code_disp as h_code,c.h_name,b.btime,b.etime,a.usehour as tol_hours";
                        sqlAbsd += " from absd a,abs b ";
                        sqlAbsd += " left outer join hcode c on b.h_code=c.h_code";
                        sqlAbsd += string.Format(@" where a.absadd='{0}'", Row["guid"].ToString());
                        sqlAbsd += " and a.abssubtract=b.guid order by b.bdate,b.btime";
                        DataTable rq_absd = SqlConn.GetDataTable(sqlAbsd);
                        grp += 1;
                        if (rq_absd.Rows.Count > 0)
                        {
                            foreach (DataRow Row1 in rq_absd.Rows)
                            {
                                Row1["dw"] = JBHR.Reports.ReportClass.GetDayWeek(DateTime.Parse(Row1["bdate"].ToString()));
                                _tolhours -= decimal.Parse(Row1["tol_hours"].ToString());
                                DataRow aRow = ds.Tables["zz23b"].NewRow();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["nobr"] = Row["nobr"].ToString();                                
                                aRow["name_c"] = Row["name_c"].ToString();
                                aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                                aRow["edate"] = DateTime.Parse(Row["edate"].ToString());
                                //aRow["dw"] = Row["dw"].ToString().Substring(2, 1);
                                //aRow["dw"] = JBHR.Reports.ReportClass.GetTransWK(DateTime.Parse(Row["bdate"].ToString()));
                                aRow["dw"] = Row1["dw"].ToString().Substring(2, 1);
                                aRow["h_code"] = Row["h_code"].ToString();
                                aRow["h_name"] = Row["h_name"].ToString();
                                aRow["btime"] = Row["btime"].ToString();
                                aRow["etime"] = Row["etime"].ToString();
                                aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                                aRow["unit"] = Row["unit"].ToString();
                                aRow["deduct_hcode"] = Row1["h_code"].ToString();
                                aRow["deduct_hname"] = Row1["h_name"].ToString();
                                aRow["deduct_date"] = DateTime.Parse(Row1["bdate"].ToString());
                                aRow["deduct_btime"] = Row1["btime"].ToString();
                                aRow["deduct_etime"] = Row1["etime"].ToString();
                                aRow["deduct_hrs"] = decimal.Parse(Row1["tol_hours"].ToString());
                                aRow["balance"] = decimal.Parse(Row["balance"].ToString());
                                aRow["deduct_balance"] = _tolhours;
                                aRow["grp"] = grp;
                                ds.Tables["zz23b"].Rows.Add(aRow);
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz23b"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();                            
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                            aRow["edate"] = DateTime.Parse(Row["edate"].ToString());
                            aRow["dw"] = Row["dw"].ToString().Substring(2, 1); ;
                            //aRow["dw"] = JBHR.Reports.ReportClass.GetTransWK(DateTime.Parse(Row["bdate"].ToString()));
                            aRow["h_code"] = Row["h_code"].ToString();
                            aRow["h_name"] = Row["h_name"].ToString();
                            aRow["btime"] = Row["btime"].ToString();
                            aRow["etime"] = Row["etime"].ToString();
                            aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                            aRow["unit"] = Row["unit"].ToString();
                            aRow["balance"] = decimal.Parse(Row["balance"].ToString());
                            aRow["grp"] = grp;
                            ds.Tables["zz23b"].Rows.Add(aRow);
                        }
                        rq_absd.Clear();
                    }
                    if (ds.Tables["zz23b"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (reporttype == "2")
                {
                    DataRow[] SRow = rq_abs.Select("flag='-'", "dept,nobr,bdate asc");
                    foreach (DataRow Row in SRow)
                    {
                        string sqlAbsd = "select b.bdate,b.edate,c.h_code_disp as h_code,c.h_name,c.unit,b.tol_hours,b.balance,a.usehour";                       
                        sqlAbsd += " from absd a,abs b";
                        sqlAbsd += " left outer join hcode c on b.h_code=c.h_code";
                        sqlAbsd += string.Format(@" where a.abssubtract='{0}'", Row["guid"].ToString());
                        sqlAbsd += " and a.absadd=b.guid order by b.bdate,b.btime";
                        DataTable rq_absd = SqlConn.GetDataTable(sqlAbsd);
                        grp += 1;
                        if (rq_absd.Rows.Count > 0)
                        {
                            foreach (DataRow Row1 in rq_absd.Rows)
                            {
                                DataRow aRow = ds.Tables["zz23b"].NewRow();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["nobr"] = Row["nobr"].ToString();                                
                                aRow["name_c"] = Row["name_c"].ToString();
                                aRow["bdate"] = DateTime.Parse(Row1["bdate"].ToString());
                                aRow["edate"] = DateTime.Parse(Row1["edate"].ToString());
                                //aRow["dw"] = JBHR.Reports.ReportClass.GetTransWK(DateTime.Parse(Row1["bdate"].ToString()));
                                aRow["dw"] = Row["dw"].ToString().Substring(2, 1); ;
                                aRow["h_code"] = Row1["h_code"].ToString();
                                aRow["h_name"] = Row1["h_name"].ToString();                                
                                aRow["tol_hours"] = decimal.Parse(Row1["tol_hours"].ToString());
                                aRow["usehour"] = decimal.Parse(Row1["usehour"].ToString());
                                aRow["unit"] = Row["unit"].ToString();
                                aRow["deduct_hcode"] = Row["h_code"].ToString();
                                aRow["deduct_hname"] = Row["h_name"].ToString();
                                aRow["deduct_date"] = DateTime.Parse(Row["bdate"].ToString());
                                aRow["deduct_btime"] = Row["btime"].ToString();
                                aRow["deduct_etime"] = Row["etime"].ToString();
                                aRow["deduct_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                                aRow["balance"] = decimal.Parse(Row1["balance"].ToString());
                                aRow["grp"] = grp;
                                ds.Tables["zz23b"].Rows.Add(aRow);
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz23b"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();                            
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["dw"] = Row["dw"].ToString().Substring(2, 1); 
                            //aRow["dw"] = JBHR.Reports.ReportClass.GetTransWK(DateTime.Parse(Row["bdate"].ToString()));
                            aRow["btime"] = Row["btime"].ToString();
                            aRow["etime"] = Row["etime"].ToString();                            
                            aRow["unit"] = Row["unit"].ToString();
                            aRow["deduct_hcode"] = Row["h_code"].ToString();
                            aRow["deduct_hname"] = Row["h_name"].ToString();
                            aRow["deduct_date"] = DateTime.Parse(Row["bdate"].ToString());
                            aRow["deduct_btime"] = Row["btime"].ToString();
                            aRow["deduct_etime"] = Row["etime"].ToString();
                            aRow["deduct_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                            aRow["grp"] = grp;
                            ds.Tables["zz23b"].Rows.Add(aRow);
                        }
                        rq_absd.Clear();
                    }
                    if (ds.Tables["zz23b"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (reporttype == "4")
                {
                    ds.Tables["zz23b1"].PrimaryKey = new DataColumn[] { ds.Tables["zz23b1"].Columns["nobr"],ds.Tables["zz23b1"].Columns["h_code"] };
                    DataRow[] SRow = rq_abs.Select("flag='+'", "dept,nobr,bdate asc");
                    foreach(DataRow Row in SRow)
                    {
                        string sqlAbsd = "select sum(a.usehour) as tol_hours";
                        sqlAbsd += " from absd a,abs b ";
                        sqlAbsd += " left outer join hcode c on b.h_code=c.h_code";
                        sqlAbsd += string.Format(@" where a.absadd='{0}'", Row["guid"].ToString());
                        sqlAbsd += " and a.abssubtract=b.guid ";
                        DataTable rq_absd = SqlConn.GetDataTable(sqlAbsd);
                        if (rq_absd.Rows.Count > 0)
                        {
                            if (rq_absd.Rows[0].IsNull("tol_hours"))
                                rq_absd.Rows[0]["tol_hours"] = 0;
                        }
                            
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["htype"].ToString();
                        DataRow row = ds.Tables["zz23b1"].Rows.Find(_value);
                        if (row!=null)
                        {
                            row["gethrs"] = decimal.Parse(row["gethrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                            if (rq_absd.Rows.Count > 0) row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(rq_absd.Rows[0][0].ToString());
                            row["balance"] = decimal.Parse(row["balance"].ToString()) + decimal.Parse(Row["balance"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz23b1"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["h_code"] = Row["htype"].ToString();
                            aRow["h_name"] = Row["type_name"].ToString();
                            aRow["gethrs"] = decimal.Parse(Row["tol_hours"].ToString());
                            aRow["tol_hours"] = (rq_absd.Rows.Count > 0) ? decimal.Parse(rq_absd.Rows[0]["tol_hours"].ToString()) : 0;
                            aRow["balance"] = decimal.Parse(Row["balance"].ToString());
                            ds.Tables["zz23b1"].Rows.Add(aRow);
                        }
                        
                    }
                    if (ds.Tables["zz23b1"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                
                
                if (exportexcel)
                {       
                    if (reporttype=="0")
                        Export1(ds.Tables["zz23b"]);
                    else if (reporttype == "1")
                        Export2(ds.Tables["zz23b"]);
                    else if (reporttype == "2")
                        Export3(ds.Tables["zz23b"]);
                    else if (reporttype == "3")
                        Export4(ds.Tables["Abssumd"], ds.Tables["Abssumd1"]);
                    else if (reporttype == "4")
                        Export5(ds.Tables["zz23b1"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");

                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23b.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23b1.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23b2.rdlc";
                    else if (reporttype == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz233.rdlc";
                    else if (reporttype == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23b3.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype == "3" )
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_Abssumd", ds.Tables["Abssumd"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_Abssumd1", ds.Tables["Abssumd1"]));
                    }
                    else  if (reporttype == "4" )
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz23b1", ds.Tables["zz23b1"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz23b", ds.Tables["zz23b"]));
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

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("請假假別", typeof(string));
            ExporDt.Columns.Add("請假日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("請起時間", typeof(string));
            ExporDt.Columns.Add("請迄時間", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("單位", typeof(string));
            DataRow[] DTrow = DT.Select("", "dept,nobr,bdate,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["請假假別"] = Row["deduct_hname"].ToString();
                aRow["請假日期"] = DateTime.Parse(Row["deduct_date"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["請起時間"] = Row["deduct_btime"].ToString();
                aRow["請迄時間"] = Row["deduct_etime"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["deduct_hrs"].ToString());
                aRow["單位"] = Row["unit"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export2(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("得假假別", typeof(string));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("得假時數", typeof(decimal));            
            ExporDt.Columns.Add("生效日期", typeof(DateTime));
            ExporDt.Columns.Add("失效日期", typeof(DateTime));
            ExporDt.Columns.Add("請假假別", typeof(string));
            ExporDt.Columns.Add("請假日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("時間起", typeof(string));
            ExporDt.Columns.Add("時間迄", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("剩餘時數", typeof(decimal));
            DataRow[] DTrow = DT.Select("", "dept,nobr,bdate,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["得假假別"] = Row["h_name"].ToString();
                aRow["單位"] = Row["unit"].ToString();
                aRow["得假時數"] = decimal.Parse(Row["tol_hours"].ToString());                
                aRow["生效日期"] = DateTime.Parse(Row["bdate"].ToString());
                aRow["失效日期"] = DateTime.Parse(Row["edate"].ToString());
                if (!Row.IsNull("deduct_date"))
                {
                    aRow["請假假別"] = Row["deduct_hname"].ToString();
                    aRow["請假日期"] = DateTime.Parse(Row["deduct_date"].ToString());
                    aRow["星期"] = Row["dw"].ToString();
                    aRow["時間起"] = Row["deduct_btime"].ToString();
                    aRow["時間迄"] = Row["deduct_etime"].ToString();
                    aRow["請假時數"] = decimal.Parse(Row["deduct_hrs"].ToString());
                    aRow["剩餘時數"] = decimal.Parse(Row["deduct_balance"].ToString());
                }

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export3(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("請假假別", typeof(string));
            ExporDt.Columns.Add("請假日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("請起時間", typeof(string));
            ExporDt.Columns.Add("請迄時間", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("得假假別", typeof(string));
            //ExporDt.Columns.Add("得假時數", typeof(decimal));
            //ExporDt.Columns.Add("剩餘時數", typeof(decimal));
            ExporDt.Columns.Add("沖假時數", typeof(decimal));
            ExporDt.Columns.Add("生效日期", typeof(DateTime));
            ExporDt.Columns.Add("失效日期", typeof(DateTime));
            DataRow[] DTrow = DT.Select("", "dept,nobr,bdate,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["請假假別"] = Row["deduct_hname"].ToString();
                aRow["請假日期"] = DateTime.Parse(Row["deduct_date"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["請起時間"] = Row["deduct_btime"].ToString();
                aRow["請迄時間"] = Row["deduct_etime"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["deduct_hrs"].ToString());
                aRow["單位"] = Row["unit"].ToString();
                if (!Row.IsNull("h_name"))
                {
                    aRow["得假假別"] = Row["h_name"].ToString();
                    //aRow["得假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                    //aRow["剩餘時數"] = decimal.Parse(Row["balance"].ToString());
                    aRow["沖假時數"] = decimal.Parse(Row["usehour"].ToString());
                    aRow["生效日期"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["失效日期"] = DateTime.Parse(Row["edate"].ToString());
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export4(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString(), typeof(decimal));
                else
                    break;
            }

            DataRow[] DTrow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString()] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export5(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("假別", typeof(string));
            //ExporDt.Columns.Add("得假假別", typeof(string));
            ExporDt.Columns.Add("得假時數", typeof(decimal));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("剩餘時數", typeof(decimal));
            DataRow[] DTrow = DT.Select("", "dept,nobr,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["假別"] = Row["h_name"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                //aRow["得假假別"] = Row["h_name"].ToString();
                aRow["得假時數"] = decimal.Parse(Row["gethrs"].ToString());
                aRow["剩餘時數"] = decimal.Parse(Row["balance"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
