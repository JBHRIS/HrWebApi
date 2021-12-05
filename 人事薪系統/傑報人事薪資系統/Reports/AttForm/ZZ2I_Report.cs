/* ======================================================================================================
 * 功能名稱：個人年度出勤明細
 * 功能代號：ZZ2I
 * 功能路徑：報表列印 > 出勤 > 個人年度出勤明細
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ2I_Report.cs
 * 功能用途：
 *  用於產出個人年度出勤明細
 */
/* 版本記錄：
 * ======================================================================================================
 *    日期           人員               版本              單號              說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/11/18    Daniel Chih        Ver 1.0.01    20211118-DC0492-01    1. 修改特休參考代碼自設定的特休代碼
 * 
 */
/* ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/11/18
 */

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
    public partial class ZZ2I_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, data_report, comp_name, report_type;
        bool exportexcel;
        public ZZ2I_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _dateb, string _datee, bool _exportexcel, string datareport, string reporttype, string compname)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; date_b = _dateb; date_e = _datee; dept_b = _deptb;
            dept_e = _depte; exportexcel = _exportexcel; data_report = datareport;
            comp_name = compname; report_type = reporttype;
        }

        private void ZZ2I_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                //曾留職停薪者
                string sqlBasett = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,b.indt,b.di,a.count_ma,b.ttscode,b.adate,b.ddate";
                sqlBasett += " from base a,basetts b";
                sqlBasett += " left outer join dept c on b.dept=c.d_no";
                sqlBasett += "  where a.nobr=b.nobr";
                sqlBasett += string.Format(@" and b.adate between '{0}' and '{1}'", date_b, date_e);
                sqlBasett += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBasett += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBasett += string.Format(@" and b.indt <='{0}'", date_e);
                sqlBasett += " and b.ddate <> '9999/12/31'";
                sqlBasett += " and b.ttscode='3'";
                sqlBasett += data_report;
                DataTable rq_basetts1 = SqlConn.GetDataTable(sqlBasett);
                rq_basetts1.Columns.Add("day", typeof(int));
                foreach (DataRow Row in rq_basetts1.Rows)
                {
                    int _adate = int.Parse(DateTime.Parse(Row["adate"].ToString()).ToString("yyyyMMdd"));
                    int _dateb = int.Parse(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                    if (_adate < _dateb)
                        Row["adate"] = DateTime.Parse(date_b);
                    Row["day"] = (((TimeSpan)(DateTime.Parse(Row["ddate"].ToString()) - DateTime.Parse(Row["adate"].ToString()))).Days) + 1;
                }
                rq_basetts1.PrimaryKey = new DataColumn[] { rq_basetts1.Columns["nobr"] };

                //如果停薪留職誇年請用本年度開始日計算
                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };
                string sqlBasetts = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,c.dept_tree";
                sqlBasetts += ",d.job_disp as job,d.job_name,b.indt,b.di";
                sqlBasetts += " from base a,basetts b ";
                sqlBasetts += " left outer join dept c on b.dept=c.d_no";
                sqlBasetts += " left outer join job d on b.job=d.job";
                sqlBasetts += " where a.nobr=b.nobr ";
                sqlBasetts += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBasetts += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBasetts += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBasetts += " and b.ttscode in ('1','4','6')";
                sqlBasetts += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBasetts);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //抓取超勤時數
                string sqlAttend = "select distinct nobr,month(adate) as mm from attend";
                sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " order by nobr,mm";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);

                if (rq_attend.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                string sqlAttend1 = "select a.nobr,a.adate,early_mins,delay_mins ";
                sqlAttend1 += " from attend a,rote b where a.rote=b.rote";
                sqlAttend1 += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend1 += " order by a.nobr,a.adate";
                DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend1);
                rq_attend1.Columns.Add("t1", typeof(string));
                rq_attend1.Columns.Add("t2", typeof(string));
                rq_attend1.Columns.Add("over_time", typeof(decimal));

                string sqlAttcard = "select nobr,adate,min(t1) as t1 from attcard";
                sqlAttcard += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttcard += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttcard += " group by nobr,adate order by adate";
                DataTable rq_attcard = SqlConn.GetDataTable(sqlAttcard);
                rq_attcard.Columns.Add("t2", typeof(string));
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };

                string sqlAttcard1 = "select nobr,adate,max(t2) as t2 from attcard";
                sqlAttcard1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttcard1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttcard1 += " group by nobr,adate order by adate";
                DataTable rq_attcard1 = SqlConn.GetDataTable(sqlAttcard1);
                rq_attcard1.PrimaryKey = new DataColumn[] { rq_attcard1.Columns["nobr"], rq_attcard1.Columns["adate"] };
                foreach (DataRow Row in rq_attcard.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_attcard1.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["t2"] = row["t2"].ToString();                        
                    }
                    else
                    {
                        Row["t2"] = "";                       
                    }
                }
                rq_attcard1 = null;
                

                foreach (DataRow Row in rq_attend1.Rows)
                {
                    //object[] _value = new object[2];
                    //_value[0] = Row["nobr"].ToString();
                    //_value[1] = DateTime.Parse(Row["adate"].ToString());
                    //DataRow row = rq_attcard.Rows.Find(_value);
                    //if (row != null)
                    //{
                    //    Row["t1"] = row["t1"].ToString();
                    //    Row["t2"] = row["t2"].ToString();
                    //    if (Row["off_time"].ToString().Trim() == "" && Row["t1"].ToString().Trim() != "")
                    //        Row["off_time"] = row["t1"].ToString();

                    //    decimal _t2 = 0; decimal _offtime = 0;
                    //    if (row["t2"].ToString().Trim() != "")
                    //    {
                    //        string at = row["t2"].ToString().Substring(0, 2);
                    //        string sd = row["t2"].ToString().Substring(2, 2);
                    //        if (row["t2"].ToString().Trim() != "" && row["t2"].ToString().Trim().Length == 4)
                    //            _t2 = Convert.ToDecimal(row["t2"].ToString().Substring(0, 2)) * 60 + Convert.ToDecimal(row["t2"].ToString().Substring(2, 2));
                    //        if (Row["off_time"].ToString().Trim() != "" && Row["off_time"].ToString().Trim().Length == 4)
                    //            _offtime = Convert.ToDecimal(Row["off_time"].ToString().Substring(0, 2)) * 60 + Convert.ToDecimal(Row["off_time"].ToString().Substring(2, 2));
                    //        Row["over_time"] = Math.Round((_t2 - _offtime) / 30, MidpointRounding.AwayFromZero) / 2;
                    //    }
                    //    else
                    //        Row["over_time"] = 0;
                    //}
                    //else
                    //    Row["over_time"] = 0;
                    Row["over_time"] = 0;
                    decimal overtime=0;
                    if (!Row.IsNull("early_mins"))
                    {
                        if (decimal.Parse(Row["early_mins"].ToString()) > 30)
                        {
                            overtime = decimal.Floor(decimal.Parse(Row["early_mins"].ToString()) / 60) * 60;
                            if (decimal.Remainder(decimal.Parse(Row["early_mins"].ToString()), decimal.Parse("60")) >= 30)
                                overtime += 30;
                        }
                    }
                    if (!Row.IsNull("delay_mins"))
                    {
                        if (decimal.Parse(Row["delay_mins"].ToString()) > 30)
                        {
                            overtime = overtime + decimal.Floor(decimal.Parse(Row["delay_mins"].ToString()) / 60) * 60;
                            if (decimal.Remainder(decimal.Parse(Row["delay_mins"].ToString()), decimal.Parse("60")) >= 30)
                                overtime += 30;
                        }
                    }
                    Row["over_time"] = overtime;
                }
                rq_attcard = null;

                DataTable rq_attenda = new DataTable();
                rq_attenda.Columns.Add("nobr", typeof(string));
                rq_attenda.Columns.Add("over_time", typeof(decimal));
                rq_attenda.Columns.Add("mm", typeof(string));
                rq_attenda.Columns.Add("qt", typeof(int));
                rq_attenda.PrimaryKey = new DataColumn[] { rq_attenda.Columns["nobr"], rq_attenda.Columns["mm"] };

                foreach (DataRow Row in rq_attend1.Rows)
                {
                    if (decimal.Parse(Row["over_time"].ToString()) >= Convert.ToDecimal(0.5))
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Convert.ToString(DateTime.Parse(Row["adate"].ToString()).Month);
                        DataRow row = rq_attenda.Rows.Find(_value);
                        if (row != null)
                        {
                            row["over_time"] = decimal.Parse(row["over_time"].ToString()) + decimal.Parse(Row["over_time"].ToString());
                            row["qt"] = int.Parse(row["qt"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = rq_attenda.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["over_time"] = decimal.Parse(Row["over_time"].ToString());
                            aRow["mm"] = Convert.ToString(DateTime.Parse(Row["adate"].ToString()).Month);
                            aRow["qt"] = 1;
                            rq_attenda.Rows.Add(aRow);
                        }
                    }
                }

                //遲到
                string sqlLater = "select nobr,sum(late_mins) as late_mins,count(nobr) as qt,month(adate) as mm";
                sqlLater += string.Format(@" from attend where adate between '{0}' and '{1}'", date_b, date_e);
                sqlLater += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlLater += " and late_mins <> 0 group by nobr,month(adate) ";
                DataTable rq_later = SqlConn.GetDataTable(sqlLater);
                rq_later.PrimaryKey = new DataColumn[] { rq_later.Columns["nobr"], rq_later.Columns["mm"] };


                //忘刷卡
                string sqlForget = "select nobr,sum(forget) as forget,month(adate) as mm from attend";
                sqlForget += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlForget += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlForget += " group by nobr,month(adate)";
                DataTable rq_forget = SqlConn.GetDataTable(sqlForget);
                rq_forget.PrimaryKey = new DataColumn[] { rq_forget.Columns["nobr"], rq_forget.Columns["mm"] };


                //請假得
                string sqlAbsw = "select a.nobr,sum(a.tol_hours) as hrs from abs a,hcode b";
                sqlAbsw += " where a.h_code=b.h_code";
                sqlAbsw += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbsw += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbsw += " and b.flag='+' group by a.nobr";
                DataTable rq_absw = SqlConn.GetDataTable(sqlAbsw);
                rq_absw.PrimaryKey = new DataColumn[] { rq_absw.Columns["nobr"] };

                //需求單號：20211118-DC0492-01：修改特休參考代碼自設定的特休代碼：Modified By Daniel Chih 2021/11/18
                #region 特休
                JBModule.Data.ApplicationConfigSettings AnnualLeaveSettingConfigs = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
                //若未設置Config則讀預設代碼 "1"
                string AnnualLeaveType = AnnualLeaveSettingConfigs.GetConfig("AnnualLeaveTypeCode").GetString("1").Trim();
                #endregion

                //特休得及剩餘
                string sqlAbswa = "select a.nobr,sum(a.tol_hours) as hrs,sum(a.balance) as balance from abs a,hcode b";
                sqlAbswa += " where a.h_code=b.h_code";
                sqlAbswa += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbswa += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //需求單號：20211118-DC0492-01：修改特休參考代碼自設定的特休代碼：Modified By Daniel Chih 2021/11/18
                sqlAbswa += string.Format(@" and b.htype='{0}' and b.flag='+' group by a.nobr", AnnualLeaveType);
                DataTable rq_abswa = SqlConn.GetDataTable(sqlAbswa);
                rq_abswa.PrimaryKey = new DataColumn[] { rq_abswa.Columns["nobr"] };

                //請假時數
                string sqlAbs = "select a.nobr,sum(a.tol_hours) as hrs,b.h_code_disp as h_code,b.h_name,b.htype,";
                sqlAbs += " month(a.bdate) as mm,count(nobr) as qt";
                sqlAbs += " from abs a,hcode b where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += " and b.year_rest not in ('1','3','5')";
                //sqlAbs += " and b.h_name in ('特休假','特休','家庭照顧假','病假','事假','無薪病假','生理假','無薪假')";
                sqlAbs += " and b.flag='-'";
                sqlAbs += " group by a.nobr,b.h_code_disp,b.h_name,b.htype,month(a.bdate)";
                sqlAbs += " order by a.nobr,b.h_code_disp";
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs);

                DataTable rq_absqt = new DataTable();
                rq_absqt.Columns.Add("nobr", typeof(string));
                rq_absqt.Columns.Add("mm", typeof(string));
                rq_absqt.Columns.Add("qt", typeof(int));
                rq_absqt.Columns.Add("hrs", typeof(decimal));
                rq_absqt.PrimaryKey = new DataColumn[] { rq_absqt.Columns["nobr"], rq_absqt.Columns["mm"] };

                //特休扣
                DataTable rq_absd = new DataTable();
                rq_absd.Columns.Add("nobr", typeof(string));
                rq_absd.Columns.Add("hrs", typeof(decimal));
                rq_absd.PrimaryKey = new DataColumn[] { rq_absd.Columns["nobr"] };

                DataTable rq_abs = new DataTable();
                rq_abs.Columns.Add("nobr", typeof(string));
                rq_abs.Columns.Add("mm", typeof(string));
                rq_abs.Columns.Add("h_name", typeof(string));
                rq_abs.Columns.Add("hrs", typeof(decimal));

                foreach (DataRow Row in rq_abs1.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["mm"].ToString();
                    DataRow row = rq_absqt.Rows.Find(_value);
                    if (row != null)
                    {
                        row["qt"] = int.Parse(row["qt"].ToString()) + decimal.Round(decimal.Parse(Row["qt"].ToString()), 2);
                        row["hrs"] = decimal.Parse(row["hrs"].ToString()) + decimal.Parse(Row["hrs"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_absqt.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["mm"] = Row["mm"].ToString();
                        aRow["qt"] = decimal.Round(decimal.Parse(Row["qt"].ToString()), 2);
                        aRow["hrs"] = decimal.Parse(Row["hrs"].ToString());
                        rq_absqt.Rows.Add(aRow);
                    }
                    if (Row["htype"].ToString().Trim() == "1")
                    {
                        DataRow row1 = rq_absd.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                            row1["hrs"] = decimal.Parse(row1["hrs"].ToString()) + decimal.Parse(Row["hrs"].ToString());
                        else
                        {
                            DataRow aRow1 = rq_absd.NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["hrs"] = decimal.Parse(Row["hrs"].ToString());
                            rq_absd.Rows.Add(aRow1);
                        }
                    }
                    DataRow aRow2 = rq_abs.NewRow();
                    aRow2["nobr"] = Row["nobr"].ToString();
                    aRow2["h_name"] = Row["h_name"].ToString();
                    aRow2["mm"] = Row["mm"].ToString();
                    aRow2["hrs"] = decimal.Parse(Row["hrs"].ToString());
                    rq_abs.Rows.Add(aRow2);
                   
                }

                //產生抬頭
                DataTable rq_hcode = new DataTable();
                //rq_hcode.Columns.Add("h_code", typeof(string));
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_name"] };
                DataRow[] rowt = rq_abs1.Select("", "h_code asc");
                
                foreach (DataRow Row in rowt)
                {
                    DataRow row = rq_hcode.Rows.Find(Row["h_name"].ToString());
                    if (row == null)
                    {
                        DataRow aRow = rq_hcode.NewRow();
                        //aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        rq_hcode.Rows.Add(aRow);
                    }
                }

                int sick = 0; int physiologysick = 0;
                DataRow aRowt = ds.Tables["zz2i_t"].NewRow();
                for (int i = 0; i < rq_hcode.Rows.Count; i++)
                {
                    aRowt["Fld" + (i + 1)] = rq_hcode.Rows[i]["h_name"].ToString();
                    if (rq_hcode.Rows[i]["h_name"].ToString().Trim() == "病假")
                        sick = i;
                    else if (rq_hcode.Rows[i]["h_name"].ToString().Trim() == "生理假")
                        physiologysick = i;
                }
                ds.Tables["zz2i_t"].Rows.Add(aRowt);
                
                ds.Tables["zz2i"].PrimaryKey = new DataColumn[] { ds.Tables["zz2i"].Columns["nobr"], ds.Tables["zz2i"].Columns["mm"] };                
                foreach (DataRow Row in rq_attend.Rows)
                {
                    string dd="";
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (Row["nobr"].ToString().Trim() == "10100647")
                            dd = Row["nobr"].ToString();
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["mm"].ToString();
                        DataRow row2 = rq_absw.Rows.Find(Row["nobr"].ToString());
                        DataRow row3 = rq_basetts1.Rows.Find(Row["nobr"].ToString());
                        DataRow row4 = rq_attenda.Rows.Find(_value);
                        DataRow row5 = rq_later.Rows.Find(_value);
                        DataRow row6 = rq_forget.Rows.Find(_value);
                        DataRow[] row7 = rq_abs.Select("nobr='" + Row["nobr"].ToString() + "' and mm='" + Row["mm"].ToString() + "'");
                        DataRow row8 = rq_absd.Rows.Find(Row["nobr"].ToString());
                        DataRow row9 = rq_absqt.Rows.Find(_value);
                        DataRow row10 = rq_abswa.Rows.Find(Row["nobr"].ToString());
                        //DataRow row1 = ds.Tables["zz2i"].Rows.Find(_value);
                        DataRow row1 = rq_depttree.Rows.Find(row["dept_tree"].ToString());

                        DataRow aRow = ds.Tables["zz2i"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["dept_tree"] = (row1 != null) ? row1["d_no_disp"].ToString().Trim() + " " + row1["d_name"].ToString() : "";
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["di"] = row["di"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        aRow["mm"] = Row["mm"].ToString().PadLeft(2, '0');
                        //aRow["tol_hours"] = (row2 != null) ? decimal.Parse(row2["hrs"].ToString()) : 0;
                        aRow["day"] = (row3 != null) ? int.Parse(row3["day"].ToString()) : 0;
                        aRow["over_time"] = (row4 != null) ? decimal.Parse(row4["over_time"].ToString()) : 0;
                        aRow["over_qt"] = (row4 != null) ? int.Parse(row4["qt"].ToString()) : 0;
                        aRow["late_mins"] = (row5 != null) ? decimal.Parse(row5["late_mins"].ToString()) : 0;
                        aRow["late_qt"] = (row5 != null) ? int.Parse(row5["qt"].ToString()) : 0;
                        aRow["forget_qt"] = (row6 != null) ? decimal.Round(decimal.Parse(row6["forget"].ToString()), 0) : 0;
                        for (int i = 0; i < rq_hcode.Rows.Count; i++)
                        {
                            aRow["Fld" + (i + 1)] = 0;
                            for (int j = 0; j < row7.Length; j++)
                            {
                                if (rq_hcode.Rows[i]["h_name"].ToString() == row7[j]["h_name"].ToString())
                                    aRow["Fld" + (i + 1)] = decimal.Parse(row7[j]["hrs"].ToString());
                            }
                        }
                        aRow["abs_dhrs"] = (row8 != null) ? decimal.Parse(row8["hrs"].ToString()) * 8 : 0;
                        aRow["abs_day"] = (row8 != null) ? decimal.Parse(row8["hrs"].ToString()) : 0;
                        aRow["abs_allhrs"] = (row9 != null) ? decimal.Parse(row9["hrs"].ToString()) : 0;
                        aRow["abs_qt"] = (row9 != null) ? int.Parse(row9["qt"].ToString()) : 0;
                        
                        if (row10 != null)
                        {
                            aRow["abs_day"] = decimal.Parse(row10["balance"].ToString());
                            aRow["tol_hours"] = decimal.Parse(row10["hrs"].ToString());
                        }
                        else
                        {
                            aRow["abs_day"] = 0;
                            aRow["tol_hours"] = 0;
                        }
                        aRow["abs_days"] = decimal.Parse(aRow["tol_hours"].ToString()) - decimal.Parse(aRow["abs_day"].ToString());
                        ds.Tables["zz2i"].Rows.Add(aRow);
                    }
                }
                if (ds.Tables["zz2i"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (report_type == "1")
                {
                    ds.Tables["zz2i1"].PrimaryKey = new DataColumn[] { ds.Tables["zz2i1"].Columns["nobr"] };
                    foreach (DataRow Row in ds.Tables["zz2i"].Rows)
                    {                        
                        DataRow row = ds.Tables["zz2i1"].Rows.Find(Row["nobr"].ToString());
                        decimal abshrs = 0;
                        if (row != null)
                        {
                            row["late_mins"] = decimal.Parse(row["late_mins"].ToString()) + decimal.Parse(Row["late_mins"].ToString());
                            //row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                            //row["abs_day"] = decimal.Parse(row["abs_day"].ToString()) + decimal.Parse(Row["abs_day"].ToString());
                            //row["abs_days"] = decimal.Parse(row["abs_days"].ToString()) + decimal.Parse(row["tol_hours"].ToString()) - decimal.Parse(row["abs_day"].ToString());
                            for (int i = 0; i < rq_hcode.Rows.Count; i++)
                            {
                                row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                if (sick != 0 && sick == i)
                                    abshrs = abshrs + (decimal.Parse(Row["Fld" + (i + 1)].ToString()) / 2);
                                else if (physiologysick != 0 && physiologysick == i)
                                    abshrs = abshrs + (decimal.Parse(Row["Fld" + (i + 1)].ToString()) / 2);
                                else
                                    abshrs = abshrs + decimal.Parse(Row["Fld" + (i + 1)].ToString());                                
                            }
                            row["surplushrs"] = decimal.Parse(row["surplushrs"].ToString()) - abshrs;
                            //row["abs_days"] = decimal.Parse(row["tol_hours"].ToString()) - decimal.Parse(row["abs_day"].ToString());

                            row["deductionhrs"] = Math.Round(decimal.Parse(row["surplushrs"].ToString()) - (decimal.Parse(row["late_mins"].ToString()) / 60), 2);
                            row["deductionday"] = Math.Round(decimal.Parse(row["deductionhrs"].ToString()) / 8, 2);
                            
                        }
                        else
                        {
                            decimal _fullyear = ((TimeSpan)(DateTime.Parse(date_e) - DateTime.Parse(Row["indt"].ToString()))).Days + 1;
                            //decimal _indt = Convert.ToDecimal(DateTime.Parse(Row["indt"].ToString()).AddYears(1).ToString("yyyyMMdd"));
                            DataRow row2 = rq_absd.Rows.Find(Row["nobr"].ToString());
                            DataRow aRow = ds.Tables["zz2i1"].NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                            aRow["dept_tree"] = Row["dept_tree"].ToString();                           
                            aRow["di"] = Row["di"].ToString();
                            aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            //aRow["tol_hours"] = ((_fullyear / Convert.ToDecimal(365.24)) >= 1) ? decimal.Parse(Row["tol_hours"].ToString()) : 0;
                            aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                            //aRow["abs_day"] = (row2 != null) ? decimal.Parse(row2["hrs"].ToString()) : 0;
                            //aRow["abs_day"] = (row2 != null) ? decimal.Parse(Row["abs_day"].ToString()) : 0;
                            aRow["abs_day"] = decimal.Parse(Row["abs_day"].ToString());
                            aRow["abs_days"] = decimal.Parse(aRow["tol_hours"].ToString()) - decimal.Parse(aRow["abs_day"].ToString());
                            for (int i = 0; i < rq_hcode.Rows.Count; i++)
                            {
                                aRow["Fld" + (i + 1)] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                                if (sick!=0 && sick == i)
                                    abshrs = abshrs + (decimal.Parse(Row["Fld" + (i + 1)].ToString()) / 2);
                                else if (physiologysick != 0 && physiologysick == i)
                                    abshrs = abshrs + (decimal.Parse(Row["Fld" + (i + 1)].ToString()) / 2);
                                else
                                    abshrs = abshrs + decimal.Parse(Row["Fld" + (i + 1)].ToString());
                            }
                            aRow["surplushrs"] = decimal.Parse(Row["tol_hours"].ToString()) - abshrs;
                            aRow["deductionhrs"] = Math.Round(decimal.Parse(aRow["surplushrs"].ToString()) - (decimal.Parse(Row["late_mins"].ToString()) / 60), 2);
                            aRow["deductionday"] = Math.Round(decimal.Parse(aRow["deductionhrs"].ToString()) / 8, 2);
                            ds.Tables["zz2i1"].Rows.Add(aRow);
                        }                       
                    }
                    ds.Tables.Remove("zz2i");
                   
                }

                rq_abs = null; rq_abs1 = null; rq_absd = null; rq_absqt = null; rq_absw = null; rq_attcard = null; rq_attend = null;
                rq_attend1 = null; rq_attenda = null; rq_base = null; rq_basetts1 = null; rq_forget = null; rq_hcode = null;
                rq_later = null; rq_depttree = null;

                if (exportexcel)
                {
                    if (report_type=="0")
                        Export(ds.Tables["zz2i"], ds.Tables["zz2i_t"]);
                    else                      
                        Export1(ds.Tables["zz2i1"], ds.Tables["zz2i_t"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2i.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2i1.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (report_type == "0")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2i", ds.Tables["zz2i"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2i1", ds.Tables["zz2i1"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2i_t", ds.Tables["zz2i_t"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("特休天數", typeof(int));
            ExporDt.Columns.Add("留職停薪天數", typeof(int));
            ExporDt.Columns.Add("月份", typeof(string));
            ExporDt.Columns.Add("超時分鐘", typeof(decimal));
            ExporDt.Columns.Add("超時次數", typeof(int));
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            ExporDt.Columns.Add("遲到次數", typeof(int));
            ExporDt.Columns.Add("忘刷次數", typeof(int));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("請假次數", typeof(int));
            ExporDt.Columns.Add("請假累計時數", typeof(decimal));
            ExporDt.Columns.Add("請假累計天數", typeof(decimal));
            ExporDt.Columns.Add("剩餘特假天數", typeof(decimal));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            DataRow[] Rowt = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row in Rowt)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["直間接"] = Row["di"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["特休天數"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["留職停薪天數"] = int.Parse(Row["day"].ToString());
                aRow["月份"] = Row["mm"].ToString();
                aRow["超時分鐘"] = decimal.Parse(Row["over_time"].ToString());
                aRow["超時次數"] = int.Parse(Row["over_qt"].ToString());
                aRow["遲到分鐘"] = decimal.Parse(Row["late_mins"].ToString());
                aRow["遲到次數"] = int.Parse(Row["late_qt"].ToString());
                aRow["請假時數"] = decimal.Parse(Row["abs_allhrs"].ToString());
                aRow["請假次數"] = decimal.Round(decimal.Parse(Row["abs_qt"].ToString()), 0);
                aRow["請假累計時數"] = decimal.Parse(Row["abs_allhrs"].ToString());
                aRow["請假累計天數"] = Math.Round(decimal.Parse(Row["abs_allhrs"].ToString())/8, 2);
                aRow["剩餘特假天數"] = decimal.Parse(Row["abs_day"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));            
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("特休應休", typeof(int));
            ExporDt.Columns.Add("特休已休", typeof(decimal));
            ExporDt.Columns.Add("特休未休", typeof(decimal));
            //ExporDt.Columns.Add("剩餘可休", typeof(decimal));            
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            //ExporDt.Columns.Add("折抵後(時)", typeof(decimal));
            //ExporDt.Columns.Add("折抵後(天)", typeof(decimal));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            DataRow[] Rowt = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row in Rowt)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["報表分析群組"] = Row["dept_tree"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["直間接"] = Row["di"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["特休應休"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["特休已休"] = decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(Row["abs_day"].ToString());
                aRow["特休未休"] =  decimal.Parse(Row["abs_day"].ToString());                
                aRow["遲到分鐘"] = decimal.Parse(Row["late_mins"].ToString());
                //aRow["剩餘可休"] = decimal.Parse(Row["surplushrs"].ToString());
                //aRow["折抵後(天)"] = decimal.Parse(Row["deductionday"].ToString());
                //aRow["折抵後(時)"] = decimal.Parse(Row["deductionhrs"].ToString());               
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
