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
    public partial class ZZ2C_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string dept_b, dept_e, h_codeb, h_codee, date_b, emp_b, emp_e, comp_b, comp_e, rote_b, rote_e, data_report, comp_name;
        bool exportexcel;
        decimal basetime;
        public ZZ2C_Report(string deptb, string depte, string hcodeb, string hcodee, string empb, string empe, string compb, string compe, string roteb, string rotee, string dateb, bool export_excel, decimal _basetime, string datareport, string compname)
        {
            InitializeComponent();
            dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe; emp_b = empb; emp_e = empe;
            rote_b = roteb; rote_e = rotee; h_codeb = hcodeb; h_codee = hcodee; comp_name = compname;
            date_b = dateb; exportexcel = export_excel; basetime = _basetime; data_report = datareport;
        }

        private void ZZ2C_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,b.d_no_disp as dept,b.d_name,b.d_ename,c.rotet_disp as rote,c.rotetname";
                sqlCmd += ",b.pns,b.pns as pns2";
                sqlCmd += " from basetts a";
                sqlCmd += " left outer join dept b on a.dept=b.d_no";
                sqlCmd += " left outer join rotet c on a.rotet=c.rotet";
                sqlCmd += string.Format(" where '{0}' between a.adate and a.ddate", date_b);
                sqlCmd += string.Format(@" and b.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and a.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and a.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += " and a.ttscode in ('1','4','6')";
                sqlCmd += data_report;
                sqlCmd += " order by b.d_no_disp";
                DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd);
                rq_basetts.PrimaryKey = new DataColumn[] { rq_basetts.Columns["nobr"] };

                DataTable rq_cdept = new DataTable();
                rq_cdept.Columns.Add("dept", typeof(string));
                rq_cdept.Columns.Add("rote", typeof(string));
                rq_cdept.Columns.Add("rotetname", typeof(string));
                rq_cdept.Columns.Add("d_name", typeof(string));
                rq_cdept.Columns.Add("d_ename", typeof(string));
                rq_cdept.Columns.Add("plann", typeof(decimal));
                rq_cdept.Columns.Add("nown", typeof(decimal));
                rq_cdept.PrimaryKey = new DataColumn[] { rq_cdept.Columns["dept"], rq_cdept.Columns["rote"] };
                //foreach (DataRow Row in rq_basetts.Rows)
                //{                    
                //    //string _rote = "";
                //    //if (!Row.IsNull("rote"))
                //    //{
                //    //    if (Row["rote"].ToString().Substring(0, 1) == "B" || Row["rote"].ToString().Substring(0, 1) == "C")
                //    //        _rote = "夜";
                //    //    else
                //    //        _rote = "日";
                //    //}
                //    object[] _value = new object[2];
                //    _value[0] = Row["dept"].ToString();
                //    _value[1] = Row["rote"].ToString();
                //    DataRow row = rq_cdept.Rows.Find(_value);
                //    if (row != null)
                //    {
                //        row["nown"] = decimal.Parse(row["nown"].ToString()) + 1;
                //    }
                //    else
                //    {
                //        DataRow aRow = rq_cdept.NewRow();
                //        aRow["dept"] = Row["dept"].ToString();
                //        aRow["d_name"] = Row["d_name"].ToString();
                //        aRow["d_ename"] = Row["d_ename"].ToString();
                //        aRow["plann"] = decimal.Parse(Row["pns"].ToString());
                //        aRow["nown"] = 1;
                //        aRow["rote"] = Row["rote"].ToString();
                //        aRow["rotetname"] = Row["rotetname"].ToString();
                //        rq_cdept.Rows.Add(aRow);
                //    }
                //}

                string sqlCmd1 = "select a.nobr,a.adate,b.rote_disp as rote,b.rotename,a.late_mins,a.e_mins,a.abs,b.wk_hrs";
                sqlCmd1 += "  from attend a,rote b where a.rote=b.rote ";
                sqlCmd1 += string.Format(@" and  a.adate='{0}'", date_b);
                sqlCmd1 += string.Format(@" and b.rote_disp between '{0}' and '{1}'", rote_b, rote_e);
                DataTable rq_attend = SqlConn.GetDataTable(sqlCmd1);
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"], rq_attend.Columns["adate"] };
                DataTable rq_attenda = new DataTable();
                rq_attenda.Columns.Add("dept", typeof(string));
                rq_attenda.Columns.Add("rote", typeof(string));
                rq_attenda.Columns.Add("sn1", typeof(decimal));
                rq_attenda.Columns.Add("fn1", typeof(decimal));
                rq_attenda.Columns.Add("en1", typeof(decimal));
                rq_attenda.Columns.Add("ln1", typeof(decimal));
                rq_attenda.Columns.Add("an1", typeof(decimal));
                rq_attenda.PrimaryKey = new DataColumn[] { rq_attenda.Columns["dept"], rq_attenda.Columns["rote"] };
                
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow rowb = rq_basetts.Rows.Find(Row["nobr"].ToString());
                    if (rowb != null)
                    {
                        string _today = DateTime.Now.ToString("yyyyMMdd");
                        string _adate = DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd");
                        if (!CodeFunction.GetHolidayRoteList().Contains(Row["rote"].ToString().Trim()))
                        {
                            string _rote = Row["rote"].ToString();
                            //if (!Row.IsNull("rote"))
                            //{
                            //    if (Row["rote"].ToString().Substring(0, 1) == "B" || Row["rote"].ToString().Substring(0, 1) == "C")
                            //        _rote = "夜";
                            //    else
                            //        _rote = "日";
                            //}
                            object[] _value = new object[2];
                            _value[0] = rowb["dept"].ToString();
                            _value[1] = _rote;
                            DataRow row = rq_attenda.Rows.Find(_value);
                            if (row != null)
                            {
                                row["sn1"] = decimal.Parse(row["sn1"].ToString()) + 1;
                                row["fn1"] = decimal.Parse(row["fn1"].ToString()) + 1;
                                if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                                    row["en1"] = decimal.Parse(row["en1"].ToString()) + 1;

                                if (decimal.Parse(Row["e_mins"].ToString()) > 0 && _today == _adate)
                                    row["ln1"] = decimal.Parse(row["ln1"].ToString()) + 1;

                                if (bool.Parse(Row["abs"].ToString()))
                                {
                                    row["an1"] = decimal.Parse(row["an1"].ToString()) + 1;
                                    row["fn1"] = decimal.Parse(row["fn1"].ToString()) - 1;
                                }
                            }
                            else
                            {
                                DataRow aRow = rq_attenda.NewRow();
                                aRow["dept"] = rowb["dept"].ToString();
                                aRow["sn1"] = 1;
                                aRow["fn1"] = 1;
                                aRow["rote"] = _rote;
                                if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                                    aRow["en1"] = 1;
                                else
                                    aRow["en1"] = 0;
                                if (decimal.Parse(Row["e_mins"].ToString()) > 0 && _today == _adate)
                                    aRow["ln1"] = 1;
                                else
                                    aRow["ln1"] = 0;
                                if (bool.Parse(Row["abs"].ToString()))
                                {
                                    aRow["an1"] = 1;
                                    aRow["fn1"] = decimal.Parse(aRow["fn1"].ToString()) - 1;
                                }
                                else
                                    aRow["an1"] = 0;
                                rq_attenda.Rows.Add(aRow);
                            }
                        }

                        object[] _value1 = new object[2];
                        _value1[0] = rowb["dept"].ToString();
                        _value1[1] = Row["rote"].ToString();
                        DataRow row2 = rq_cdept.Rows.Find(_value1);
                        if (row2 != null)
                        {
                            row2["nown"] = decimal.Parse(row2["nown"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = rq_cdept.NewRow();
                            aRow["dept"] = rowb["dept"].ToString();
                            aRow["d_name"] = rowb["d_name"].ToString();
                            aRow["d_ename"] = rowb["d_ename"].ToString();
                            aRow["plann"] = decimal.Parse(rowb["pns"].ToString());
                            aRow["nown"] = 1;
                            aRow["rote"] = Row["rote"].ToString();
                            aRow["rotetname"] = Row["rotename"].ToString();
                            rq_cdept.Rows.Add(aRow);
                        }
                    }
                }

                string sqlCmd2 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,b.unit,a.tol_hours from abs a,hcode b ";
                sqlCmd2 += " where a.h_code=b.h_code";
                sqlCmd2 += string.Format(@" and a.bdate='{0}'", date_b);
                sqlCmd2 += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);
                //sqlCmd2 += string.Format(@" and a.tol_hours >= {0}", basetime);
                //sqlCmd2 += " and b.year_rest not in ('1','3')";
                sqlCmd2 += " and b.not_del=0 and b.flag='-'";
                DataTable rq_abs = SqlConn.GetDataTable(sqlCmd2);
                DataTable rq_cabs = new DataTable();
                rq_cabs.Columns.Add("dept", typeof(string));
                rq_cabs.Columns.Add("rote", typeof(string));
                rq_cabs.Columns.Add("h_code", typeof(string));
                rq_cabs.Columns.Add("abscn", typeof(decimal));
                rq_cabs.PrimaryKey = new DataColumn[] { rq_cabs.Columns["dept"], rq_cabs.Columns["rote"], rq_cabs.Columns["h_code"] };
                string[] holicodes = new string[] { "00", "0X", "0Z" };
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_basetts.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        object[] _value1 = new object[2];
                        _value1[0] = Row["nobr"].ToString();
                        _value1[1] = DateTime.Parse(Row["bdate"].ToString());
                        DataRow row2 = rq_attend.Rows.Find(_value1);
                        decimal tol_hours = decimal.Parse(Row["tol_hours"].ToString());
                        string _rote = (row2 == null) ? "" : row2["rote"].ToString();
                        if (!holicodes.Contains(_rote) && row2 != null && Row["unit"].ToString().Trim() == "天")
                        {
                            tol_hours = tol_hours * decimal.Parse(row2["wk_hrs"].ToString());
                        }
                        //string _rote =row["rote"].ToString();
                        //if (row["rote"].ToString().Substring(0, 1) == "B" || row["rote"].ToString().Substring(0, 1) == "C")
                        //    _rote = "夜";
                        //else
                        //    _rote = "日";
                        if (tol_hours >= basetime)
                        {
                            object[] _value = new object[3];
                            _value[0] = row["dept"].ToString();
                            _value[1] = _rote;
                            _value[2] = Row["h_code"].ToString();
                            DataRow row1 = rq_cabs.Rows.Find(_value);
                            if (row1 != null)
                                row1["abscn"] = decimal.Parse(row1["abscn"].ToString()) + 1;
                            else
                            {
                                DataRow aRow = rq_cabs.NewRow();
                                aRow["dept"] = row["dept"].ToString();
                                aRow["rote"] = _rote;
                                aRow["h_code"] = Row["h_code"].ToString();
                                aRow["abscn"] = 1;
                                rq_cabs.Rows.Add(aRow);
                            }
                        }
                    }
                }

                DataTable rq_hcode = new DataTable();
                rq_hcode.Columns.Add("h_code", typeof(string));
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_code"] };
                DataRow aRowh = rq_hcode.NewRow();
                aRowh["h_code"] = "00001";
                aRowh["h_name"] = "計劃人數";
                rq_hcode.Rows.Add(aRowh);
                DataRow aRowh1 = rq_hcode.NewRow();
                aRowh1["h_code"] = "00002";
                aRowh1["h_name"] = "現有人數";
                rq_hcode.Rows.Add(aRowh1);
                DataRow aRowh2 = rq_hcode.NewRow();
                aRowh2["h_code"] = "00003";
                aRowh2["h_name"] = "應到人數";
                rq_hcode.Rows.Add(aRowh2);
                DataRow aRowh3 = rq_hcode.NewRow();
                aRowh3["h_code"] = "00004";
                aRowh3["h_name"] = "實到人數";
                rq_hcode.Rows.Add(aRowh3);
                DataRow aRowh4 = rq_hcode.NewRow();
                aRowh4["h_code"] = "00005";
                aRowh4["h_name"] = "出席率";
                rq_hcode.Rows.Add(aRowh4);
                DataRow aRowh5 = rq_hcode.NewRow();
                aRowh5["h_code"] = "00006";
                aRowh5["h_name"] = "遲到人數";
                rq_hcode.Rows.Add(aRowh5);
                DataRow aRowh6 = rq_hcode.NewRow();
                aRowh6["h_code"] = "00007";
                aRowh6["h_name"] = "早退人數";
                rq_hcode.Rows.Add(aRowh6);
                DataRow aRowh7 = rq_hcode.NewRow();
                aRowh7["h_code"] = "00008";
                aRowh7["h_name"] = "曠職人數";
                rq_hcode.Rows.Add(aRowh7);
                DataRow[] Hrow = rq_abs.Select("", "h_code asc");
                foreach (DataRow Row in Hrow)
                {
                    DataRow row = rq_hcode.Rows.Find(Row["h_code"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_hcode.NewRow();
                        aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        rq_hcode.Rows.Add(aRow);
                    }
                }

                DataRow HaRow = ds.Tables["zz2ct"].NewRow();
                for (int i = 0; i < rq_hcode.Rows.Count; i++)
                {
                    HaRow["Fld" + (i + 1)] = rq_hcode.Rows[i]["h_name"].ToString();
                }
                ds.Tables["zz2ct"].Rows.Add(HaRow);

                foreach (DataRow Row in rq_cdept.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["rote"].ToString();

                    DataRow row = rq_attenda.Rows.Find(_value);

                    DataRow aRow = ds.Tables["zz2cd"].NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["rote"] = Row["rote"].ToString();
                    aRow["rotetname"] = Row["rotetname"].ToString();
                    aRow["Fld1"] = decimal.Parse(Row["plann"].ToString());
                    aRow["Fld2"] = decimal.Parse(Row["nown"].ToString());
                    aRow["Fld3"] = 0;
                    aRow["Fld4"] = 0;
                    aRow["Fld5"] = 0;
                    aRow["Fld6"] = 0;
                    aRow["Fld7"] = 0;
                    aRow["Fld8"] = 0;
                    if (row != null)
                    {
                        aRow["Fld3"] = decimal.Parse(row["sn1"].ToString());
                        aRow["Fld4"] = decimal.Parse(row["fn1"].ToString());
                        if (decimal.Parse(row["sn1"].ToString()) == 0 || decimal.Parse(row["fn1"].ToString()) == 0)
                            aRow["Fld5"] = 0;
                        else
                            aRow["Fld5"] = decimal.Round(decimal.Parse(row["fn1"].ToString()) / decimal.Parse(row["sn1"].ToString()), 2);
                        aRow["Fld6"] = decimal.Parse(row["en1"].ToString());
                        aRow["Fld7"] = decimal.Parse(row["ln1"].ToString());
                        aRow["Fld8"] = decimal.Parse(row["an1"].ToString());
                    }
                    for (int i = 8; i < rq_hcode.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        object[] _value1 = new object[3];
                        _value1[0] = Row["dept"].ToString();
                        _value1[1] = Row["rote"].ToString();
                        _value1[2] = rq_hcode.Rows[i]["h_code"].ToString();
                        DataRow row1 = rq_cabs.Rows.Find(_value1);
                        if (row1 != null)
                        {
                            aRow["Fld" + (i + 1)] = decimal.Parse(row1["abscn"].ToString());
                            aRow["Fld4"] = decimal.Parse(aRow["Fld4"].ToString()) - decimal.Parse(aRow["Fld" + (i + 1)].ToString());
                            if (decimal.Parse(aRow["Fld4"].ToString()) == 0 || decimal.Parse(aRow["Fld3"].ToString()) == 0)
                                aRow["Fld5"] = 0;
                            else
                                aRow["Fld5"] = decimal.Round(decimal.Parse(aRow["Fld4"].ToString()) / decimal.Parse(aRow["Fld3"].ToString()), 2);
                        }
                    }
                    ds.Tables["zz2cd"].Rows.Add(aRow);
                }
                if (ds.Tables["zz2cd"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_basetts = null;
                rq_attend = null;
                rq_attenda = null;
                rq_abs = null;
                rq_cabs = null;
                rq_cdept = null;
                rq_hcode = null;

                if (exportexcel)
                {                   
                    Export(ds.Tables["zz2cd"], ds.Tables["zz2ct"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2c.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2cd", ds.Tables["zz2cd"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2ct", ds.Tables["zz2ct"]));
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

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));            
            ExporDt.Columns.Add("班別代碼", typeof(string));
            ExporDt.Columns.Add("班別", typeof(string));
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
                aRow["班別代碼"] = Row["rote"].ToString();
                aRow["班別"] = Row["rotetname"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row["Fld" +( i+1)].ToString());
                    else
                        break;
                }                

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

    }
}
