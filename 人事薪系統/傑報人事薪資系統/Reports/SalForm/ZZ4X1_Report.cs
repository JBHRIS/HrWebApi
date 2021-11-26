using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4X1_Report : JBControls.JBForm
    {
        JBModule.Data.ApplicationConfigSettings Acg = null;
        SalDataSet ds = new SalDataSet();
        string depts_b, depts_e, emp_b, emp_e, nobr_b, nobr_e, date_b, date_e,date_t,year, type_data, username;
        bool exportexcel;
       

        public ZZ4X1_Report(string deptsb, string deptse, string empb, string empe, string nobrb, string nobre, string dateb, string datee,string datet,string _year, string typedata, string _username, bool _exportexcel)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; date_t = datet; depts_b = deptsb; depts_e = deptse; nobr_b = nobrb; nobr_e = nobre; username = _username; type_data = typedata;
            emp_b = empb; emp_e = empe; exportexcel = _exportexcel; year = _year;
        }

        private void ZZ4X1_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string nextyear = Convert.ToString(int.Parse(year) + 1);
                string preyear = Convert.ToString(int.Parse(year) - 1);
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                //員工基本資料
                string sqlCmd1 = "select b.nobr,a.name_c,b.indt,c.d_no_disp as dept,c.d_name";
                sqlCmd1 += " from base a,basetts b";
                sqlCmd1 += " left outer join dept c on b.depts=c.d_no";
                sqlCmd1 += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_t);
                sqlCmd1 += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd1 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd1 += " and b.ttscode in ('1','4','6')";
                sqlCmd1 += type_data;
                sqlCmd1 += " order by depts";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd1);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //特休計算類型
                string holicaltype ="1";    //1=>勞基法到職日,2=>年度統一
                DataTable rq_sys8 = SqlConn.GetDataTable("select specialcaltype from u_sys8 where comp='" + MainForm.COMPANY + "' ");
                if (rq_sys8.Rows.Count > 0) holicaltype = rq_sys8.Rows[0][0].ToString();
                rq_sys8 = null;

                //特休得假、扣假                
                string sqlAbs = "select a.nobr,a.bdate,a.edate,a.btime,a.etime,tol_hours,yymm,balance"; //,guid
                sqlAbs += ",b.htype,b.h_code_disp as h_code,b.h_name,b.flag,b.unit,datename(dw,a.bdate) as dw,c.type_name";
                sqlAbs += " from abs a,hcode b";
                sqlAbs += " left outer join hcodetype c on b.htype=c.htype";
                sqlAbs += " where a.h_code =b.h_code";
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                //sqlAbs += string.Format(@" and year(a.bdate) between  {0} and {1} ", preyear, nextyear);
                if (holicaltype == "1")
                    sqlAbs += string.Format(@" and year(a.bdate) between  {0} and {1}", preyear, int.Parse(year));
                else
                    sqlAbs += string.Format(@" and year(a.bdate) =  {0} ", int.Parse(year));

                sqlAbs += "  and b.htype='1' and b.flag='+' and a.tol_hours>0";
                sqlAbs += " order by  a.nobr,a.bdate";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);

                //預估特休得假
                Acg = new JBModule.Data.ApplicationConfigSettings("FRM2I", MainForm.COMPANY);
                string LeaveCode = Acg.GetConfig("LeaveCode").GetString();
                string hname = string.Empty;
                string flag = string.Empty;
                string htype = string.Empty;
                string type_name = string.Empty;
                DataTable rq_hcode = SqlConn.GetDataTable("select h_code_disp,a.h_name,a.flag,a.htype,b.type_name from hcode a,hcodetype b  where a.htype=b.htype and a.h_code='" + LeaveCode + "'");
                if (rq_hcode.Rows.Count > 0)
                {
                    LeaveCode = rq_hcode.Rows[0]["h_code_disp"].ToString();
                    flag = rq_hcode.Rows[0]["flag"].ToString();
                    htype = rq_hcode.Rows[0]["htype"].ToString();
                    type_name = rq_hcode.Rows[0]["type_name"].ToString();
                    hname = rq_hcode.Rows[0]["h_name"].ToString();
                }
                rq_hcode = null;

                string sqlAbs1 = "select a.nobr,a.adate as bdate,a.ddate as edate,'' as btime,'' as  etime,a.get_days as tol_hours,'' as yymm,a.get_days as balance"; //,guid
                sqlAbs1 += string.Format(@",'{0}' as htype,'{1}' as h_code,'{2}' as h_name,'{3}' as flag", htype, LeaveCode, hname, flag);
                sqlAbs1 += ",a.unit,datename(dw,a.adate) as dw";
                sqlAbs1 += string.Format(",'{0}' as type_name", type_name);
                sqlAbs1 += " from year_holiday a";
                sqlAbs1 += string.Format(@" where a.nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlAbs1 += string.Format(@" and year(a.adate) =  {0} ", nextyear);
                sqlAbs1 += " and a.get_days>0";
                sqlAbs1 += " order by  a.nobr,a.adate";
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs1);
                rq_abs.Merge(rq_abs1);
                
                //基本薪
                string sqlCmd3 = "select a.nobr,a.amt from salbasd a ";
                sqlCmd3 += string.Format(@" where '{0}' between a.adate and a.ddate", date_t);
                sqlCmd3+=string.Format(@" and  a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd3 += " and a.sal_code not in ('A04','A05','A06','A07')";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd3);
                DataTable rq_salbasds = new DataTable();
                rq_salbasds.Columns.Add("nobr", typeof(string));
                rq_salbasds.Columns.Add("amt", typeof(int));
                rq_salbasds.PrimaryKey = new DataColumn[] { rq_salbasds.Columns["nobr"] };
                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    DataRow row = rq_salbasds.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    else
                    {
                        DataRow aRow = rq_salbasds.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        rq_salbasds.Rows.Add(aRow);
                    }
                }

                ds.Tables["zz4x1"].PrimaryKey = new DataColumn[] { ds.Tables["zz4x1"].Columns["nobr"] };
                DataTable zz4x1 = new DataTable();
                zz4x1 = ds.Tables["zz4x1"].Clone();
                //zz4x1.Columns.Add("hramt", typeof(decimal));
                zz4x1.Columns.Add("row", typeof(int));
                foreach (DataRow Row in rq_abs.Select("","nobr,bdate asc"))
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    int _bdate=DateTime.Parse(Row["bdate"].ToString()).Year ;
                    int _edate = Convert.ToInt32(DateTime.Parse(Row["edate"].ToString()).ToString("yyyyMMdd"));
                    int _bdate1 = Convert.ToInt32(DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd"));
                    
                    if (row != null)
                    {
                        string MMdd = DateTime.Parse(row["indt"].ToString()).ToString("MMdd");
                        int _indt = Convert.ToInt32(year + MMdd);
                        int _datee = Convert.ToInt32(DateTime.Parse(date_e).ToString("yyyyMMdd"));
                        decimal _balance = 0;
                        if (_datee>_bdate1 && _datee< _edate)
                            _balance=decimal.Parse(Row["balance"].ToString());
                        DataRow row1 = zz4x1.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            decimal _per = decimal.Parse(row1["per"].ToString());
                            int _nextyear = DateTime.Parse(row1["nextdate"].ToString()).Year;
                            if (_bdate >= _nextyear - 1 && _bdate < _nextyear)
                            {
                                row1["thisbalance"] = decimal.Parse(row1["thisbalance"].ToString()) + _balance;
                                row1["tolhrs"] = decimal.Parse(row1["tolhrs"].ToString()) +decimal.Parse(Row["balance"].ToString());
                                //row1["ratiohrs"] = Math.Round(decimal.Parse(row1["tolhrs"].ToString()) * _per, 2, MidpointRounding.AwayFromZero);
                                row1["tolhrs"] = decimal.Parse(row1["tolhrs"].ToString());
                            }
                            else  if (_bdate== _nextyear )
                            {
                                row1["nextgethrs"] = decimal.Parse(row1["nextgethrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                                if (decimal.Parse(row1["nextgethrs"].ToString())>0) row1["ratiohrs"] = Math.Round(decimal.Parse(row1["nextgethrs"].ToString()) * _per, 2, MidpointRounding.AwayFromZero);
                                row1["tolhrs"] = decimal.Parse(row1["thisbalance"].ToString()) + decimal.Parse(row1["ratiohrs"].ToString());
                            }                            

                            row1["amt"] = (decimal.Parse(row1["hramt"].ToString()) == 0 || decimal.Parse(row1["tolhrs"].ToString()) <= 0) ? 0 : Math.Round(decimal.Parse(row1["tolhrs"].ToString()) * decimal.Parse(row1["hramt"].ToString()), MidpointRounding.AwayFromZero);
                           

                        }
                        else
                        {
                            DataRow row2 = rq_salbasds.Rows.Find(Row["nobr"].ToString());
                            DataRow aRow = zz4x1.NewRow();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                            aRow["baseamt"] = (row2 != null) ? int.Parse(row2["amt"].ToString()) : 0;
                            aRow["hramt"] = (row2 != null) ? decimal.Parse(row2["amt"].ToString()) / 240M : 0; 
                            aRow["thisbalance"] = 0;
                            aRow["nextgethrs"] = 0;
                            aRow["per"] = 0;
                            aRow["ratiohrs"] = 0;
                            aRow["tolhrs"] = 0;
                            aRow["amt"] = 0;
                            string thisindt = "";
                            if (_indt < _datee )
                            {
                                aRow["nextdate"] = DateTime.Parse(row["indt"].ToString()).ToString(nextyear + "/MM/dd");
                                //if (decimal.Parse(Row["tol_hours"].ToString()) == decimal.Parse(Row["balance"].ToString())) 
                                //    aRow["nextgethrs"] = decimal.Parse(Row["tol_hours"].ToString());
                                //aRow["days"] = ((TimeSpan)(DateTime.Parse(aRow["nextdate"].ToString())-DateTime.Parse(date_b) )).Days + 1;
                                thisindt = DateTime.Parse(row["indt"].ToString()).ToString(year + "/MM/dd");
                                aRow["days"] = ((TimeSpan)(DateTime.Parse(date_e) - DateTime.Parse(thisindt))).Days + 1;
                            }
                            else
                            {
                                aRow["nextdate"] = DateTime.Parse(row["indt"].ToString()).ToString(year + "/MM/dd");
                                //aRow["days"] = ((TimeSpan)(DateTime.Parse(aRow["nextdate"].ToString()) - DateTime.Parse(date_b))).Days + 1;
                                thisindt = DateTime.Parse(row["indt"].ToString()).ToString(preyear + "/MM/dd");
                                aRow["days"] = ((TimeSpan)(DateTime.Parse(date_e) - DateTime.Parse(thisindt))).Days + 1;
                            }
                            int _nextyear = DateTime.Parse(aRow["nextdate"].ToString()).Year;
                            if (_bdate>=_nextyear-1 && _bdate<_nextyear)
                            {
                                //aRow["thisbalance"] = (_bdate==Convert.ToInt32( year)) ? decimal.Parse(Row["balance"].ToString()) : 0;
                                aRow["thisbalance"] = _balance;
                                aRow["nextgethrs"] = 0;
                                
                                aRow["ratiohrs"] = 0;
                                aRow["tolhrs"] = decimal.Parse(aRow["thisbalance"].ToString()) + decimal.Parse(aRow["ratiohrs"].ToString());
                                aRow["amt"] = (decimal.Parse(aRow["hramt"].ToString()) == 0 || decimal.Parse(aRow["tolhrs"].ToString()) <= 0) ? 0 : Math.Round(decimal.Parse(aRow["tolhrs"].ToString()) * decimal.Parse(aRow["hramt"].ToString()), MidpointRounding.AwayFromZero);
                                aRow["row"] = 1;
                                
                            }
                            aRow["per"] = decimal.Parse(aRow["days"].ToString()) / 365M;
                            zz4x1.Rows.Add(aRow);
                        }
                    }
                }
                if (zz4x1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataRow[] Srow = zz4x1.Select("", "dept,nobr asc");
                foreach(DataRow Row in Srow)
                {
                    ds.Tables["zz4x1"].ImportRow(Row);
                }
                rq_abs = null; rq_base = null; rq_salbasd = null; rq_salbasds = null; zz4x1 = null;
               
                if (exportexcel)
                {
                    Export(ds.Tables["zz4x1"]);
                    this.Close();
                }
                else
                {
                    string company = ""; string JBVersion = "";
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        JBVersion += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4x1.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4x1", ds.Tables["zz4x1"]));
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
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("本薪", typeof(int));
            ExporDt.Columns.Add("未休完", typeof(decimal));
            ExporDt.Columns.Add(date_b+"距離天數", typeof(int));
            ExporDt.Columns.Add("次年特休起始日", typeof(DateTime));
            ExporDt.Columns.Add("未產生特休", typeof(decimal));
            ExporDt.Columns.Add("依比率計算特休", typeof(decimal));
            ExporDt.Columns.Add("合計特休", typeof(decimal));
            ExporDt.Columns.Add("未休假金額", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["本薪"] = int.Parse(Row["baseamt"].ToString());
                aRow["未休完"] = decimal.Parse(Row["thisbalance"].ToString());
                aRow[date_b + "距離天數"] = int.Parse(Row["days"].ToString());
                aRow["次年特休起始日"] = DateTime.Parse(Row["nextdate"].ToString());
                aRow["未產生特休"] = decimal.Parse(Row["nextgethrs"].ToString());
                aRow["依比率計算特休"] = decimal.Parse(Row["ratiohrs"].ToString());
                aRow["合計特休"] = decimal.Parse(Row["tolhrs"].ToString());
                aRow["未休假金額"] = int.Parse(Row["amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
