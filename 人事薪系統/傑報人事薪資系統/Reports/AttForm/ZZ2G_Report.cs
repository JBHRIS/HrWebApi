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
    public partial class ZZ2G_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, yymm_b, yymm_e, type_data, date_type, data_report, comp_name, compid;
        bool exportexcel, labcheck;
        public ZZ2G_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string dateb, string datee, string yymmb, string yymme, bool _labcheck, string typedata, string datetype, bool _exportexcel, string datareport, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb;
            comp_e = compe; date_b = dateb; date_e = datee; yymm_b = yymmb; date_type = datetype;
            yymm_e = yymme; labcheck = _labcheck; type_data = typedata; exportexcel = _exportexcel;
            data_report = datareport; comp_name = compname; 
        }
        private void ZZ2G_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_sys3 = JBHR.Reports.ReportClass.GetU_Sys3();
                 string _maxhr="";
                 string _maxhr1="";
                 if (rq_sys3.Rows.Count > 0)
                 {
                     _maxhr = rq_sys3.Rows[0]["malemaxhrs"].ToString();
                     _maxhr1 = rq_sys3.Rows[0]["femalemaxhrs"].ToString();
                 }
                 string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.sex,c.d_no_disp as dept,c.d_name,g.rotet_disp as rotet,";
                 sqlCmd += "c.dept_group,000.00 as otmaxhr,b.adate,b.ttscode,0 as cnt";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join rotet g on b.rotet=g.rotet";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);                
                sqlCmd += data_report;
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                foreach (DataRow Row in rq_base.Rows)
                {
                    int _dateb = int.Parse(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                    int _adate = int.Parse(DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd"));
                    string _tts = Row["ttscode"].ToString().Trim();
                    if (_tts == "2" && _adate < _dateb)
                        Row.Delete();
                    else
                    {
                        if (Row["sex"].ToString().Trim() == "M")
                            Row["otmaxhr"] = decimal.Parse(_maxhr);
                        if (Row["sex"].ToString().Trim() == "F")
                            Row["otmaxhr"] = decimal.Parse(_maxhr1);
                    }
                }
                rq_base.AcceptChanges();
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.bdate,a.ot_hrs,a.fst_hours from ot a";             
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (date_type == "1")
                    sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (date_type == "2")
                    sqlCmd1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_ot = SqlConn.GetDataTable(sqlCmd1);

                DataTable zz2g = new DataTable();
                zz2g.Columns.Add("nobr", typeof(string));
                zz2g.Columns.Add("name_c", typeof(string));
                zz2g.Columns.Add("name_e", typeof(string));
                zz2g.Columns.Add("bdate", typeof(DateTime));
                zz2g.Columns.Add("ot_hrs", typeof(decimal));
                zz2g.Columns.Add("dept", typeof(string));
                zz2g.Columns.Add("d_name", typeof(string));
                zz2g.Columns.Add("dept_group", typeof(string));
                zz2g.Columns.Add("rotet", typeof(string));

                if (labcheck)
                {
                    foreach (DataRow Row in rq_ot.Rows)
                    {
                        if (decimal.Parse(Row["ot_hrs"].ToString()) > 2)
                            Row["ot_hrs"] = 2;
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["cnt"] = 1;
                            if (decimal.Parse(row["otmaxhr"].ToString()) > (decimal.Parse(Row["fst_hours"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString())))
                            {
                                DataRow aRow1 = zz2g.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["name_c"] = row["name_c"].ToString();
                                aRow1["name_e"] = row["name_e"].ToString();
                                aRow1["dept"] = row["dept"].ToString();
                                aRow1["d_name"] = row["d_name"].ToString();
                                aRow1["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                                aRow1["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                                aRow1["rotet"] = row["rotet"].ToString();
                                aRow1["dept_group"] = row["dept_group"].ToString();
                                zz2g.Rows.Add(aRow1);
                            }
                        }
                    }

                    DataRow[] row1 = rq_base.Select("cnt=0");
                    foreach (DataRow Row1 in row1)
                    {
                        DataRow aRow = zz2g.NewRow();
                        aRow["nobr"] = Row1["nobr"].ToString();
                        aRow["name_c"] = Row1["name_c"].ToString();
                        aRow["name_e"] = Row1["name_e"].ToString();
                        aRow["bdate"] = DateTime.Parse("1900/01/01");
                        aRow["dept"] = Row1["dept"].ToString();
                        aRow["d_name"] =Row1["d_name"].ToString();
                        aRow["ot_hrs"] = 0;
                        aRow["rotet"] = Row1["rotet"].ToString();
                        aRow["dept_group"] = Row1["dept_group"].ToString();
                        zz2g.Rows.Add(aRow);
                    }
                   
                }
                else
                {
                    DataColumn[] _key = new DataColumn[3];
                    _key[0] = zz2g.Columns["dept"];
                    _key[1] = zz2g.Columns["nobr"];
                    _key[2] = zz2g.Columns["bdate"];
                    zz2g.PrimaryKey = _key;
                    foreach (DataRow Row in rq_ot.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            row["cnt"] = 1;
                            object[] _value = new object[3];
                            _value[0] = row["dept"].ToString();
                            _value[1] = Row["nobr"].ToString();
                            _value[2] = Row["bdate"].ToString();
                            DataRow row1 = zz2g.Rows.Find(_value);
                            if (row1 != null)
                                row1["ot_hrs"] = decimal.Parse(row1["ot_hrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                            else
                            {
                                DataRow aRow1 = zz2g.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["name_c"] = row["name_c"].ToString();
                                aRow1["name_e"] = row["name_e"].ToString();
                                aRow1["dept"] = row["dept"].ToString();
                                aRow1["d_name"] = row["d_name"].ToString();
                                aRow1["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                                aRow1["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                                aRow1["rotet"] = row["rotet"].ToString();
                                aRow1["dept_group"] = row["dept_group"].ToString();
                                zz2g.Rows.Add(aRow1);
                            }
                        }
                    }
                    DataRow[] row2 = rq_base.Select("cnt=0");
                    foreach (DataRow Row1 in row2)
                    {
                        DataRow aRow = zz2g.NewRow();
                        aRow["nobr"] = Row1["nobr"].ToString();
                        aRow["name_c"] = Row1["name_c"].ToString();
                        aRow["name_e"] = Row1["name_e"].ToString();
                        aRow["bdate"] = DateTime.Parse("1900/01/01");
                        aRow["dept"] = Row1["dept"].ToString();
                        aRow["d_name"] = Row1["d_name"].ToString();
                        aRow["ot_hrs"] = 0;
                        aRow["rotet"] = Row1["rotet"].ToString();
                        aRow["dept_group"] = Row1["dept_group"].ToString();
                        zz2g.Rows.Add(aRow);
                    }                    
                }

                ds.Tables["zz2g"].PrimaryKey = new DataColumn[] { ds.Tables["zz2g"].Columns["dept"], ds.Tables["zz2g"].Columns["nobr"] };
                DataRow[] SRow = zz2g.Select("", "dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = Row["nobr"].ToString();
                    DataRow row = ds.Tables["zz2g"].Rows.Find(_value);
                    if (row != null)
                    {
                        if (DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd") != "19000101")
                        {
                            string _day = Convert.ToString(DateTime.Parse(Row["bdate"].ToString()).Day).PadLeft(2, '0');
                            row["D" + _day] = decimal.Parse(row["D" + _day].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                            row["total"] = decimal.Parse(row["total"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                        }
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz2g"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["dept_group"] = Row["dept_group"].ToString();
                        aRow["d_name"].ToString();
                        for (int i = 1; i < 32; i++)
                        {
                            aRow["D" + i.ToString().PadLeft(2, '0')] = 0;
                        }
                        if (DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd") != "19000101")
                        {
                            string _day = Convert.ToString(DateTime.Parse(Row["bdate"].ToString()).Day).PadLeft(2, '0');
                            aRow["D" + _day] = decimal.Parse(Row["ot_hrs"].ToString());
                        }
                        aRow["total"] = decimal.Parse(Row["ot_hrs"].ToString());
                        ds.Tables["zz2g"].Rows.Add(aRow);
                    }
                }

                if (ds.Tables["zz2g"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2g"]);
                    this.Close();
                }
                else
                {                  
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2g.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });

                    if (date_type == "1")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", yymm_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", yymm_e) });
                    }
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2g", ds.Tables["zz2g"]));
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
            //ExporDt.Columns.Add("班別", typeof(string));
            for (int i = 1; i < 32; i++)
            {
                ExporDt.Columns.Add(i.ToString(), typeof(decimal));
            }
            ExporDt.Columns.Add("合計", typeof(decimal));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                //aRow["班別"] = Row["rot"].ToString();
                for (int i = 1; i < 32; i++)
                {
                    aRow[i.ToString()] = decimal.Parse(Row["D" + i.ToString().PadLeft(2, '0')].ToString());
                }
                aRow["合計"] = decimal.Parse(Row["total"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
