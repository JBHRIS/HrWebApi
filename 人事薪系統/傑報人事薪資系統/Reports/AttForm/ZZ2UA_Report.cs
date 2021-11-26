using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Globalization;


namespace JBHR.Reports.AttForm
{
    public partial class ZZ2UA_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, emp_b, emp_e, date_b, date_e, meno, reporttype, type_data, username, workadr, comp_name, CompId;
        bool exportexcel, checkB;
        DataTable rq_monot = new DataTable();
        string Errorlog = string.Empty;
        public ZZ2UA_Report(string _nobrb, string _nobre, string _deptb, string _depte, string _empb, string _empe, string _dateb, string _datee, string _reporttype, string _typedata, bool _exportexcel, string _username, string _workadr, string compname, string _CompId, bool _checkB)
        {
            InitializeComponent();
            nobr_b = _nobrb; nobr_e = _nobre; dept_b = _deptb; dept_e = _depte;
            emp_b = _empb; emp_e = _empe; date_b = _dateb; date_e = _datee;
            reporttype = _reporttype; type_data = _typedata; exportexcel = _exportexcel;
            username = _username; workadr = _workadr; comp_name = compname; CompId = _CompId;
            checkB = _checkB;
        }

        private void ZZ2UA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("CN2UA", MainForm.COMPANY);
                //公出不扣出勤時數
                string Disinclude_Hcode = AppConfig.GetConfig("Disinclude_Hcode").Value;

                //夜班班別
                string student_NightRote = AppConfig.GetConfig("student_NightRote").Value;

                //學生加班時數
                decimal student_othrs = (AppConfig.GetConfig("Student_Othrs").Value == string.Empty) ? 0 : decimal.Parse(AppConfig.GetConfig("Student_Othrs").Value);

                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.count_ma,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += ",d.d_no_disp as depts,d.d_name as ds_name,e.job_disp as job,e.job_name,b.comp,b.indt,b.rotet";
                sqlCmd += ",datediff(d,a.birdt,getdate())/365.24 as age";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += type_data;
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlRote = "select rote,wk_hrs from rote";
                DataTable rq_rote = SqlConn.GetDataTable(sqlRote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

                System.Globalization.GregorianCalendar gc = new GregorianCalendar();
                int wk = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                int wk1 = gc.GetWeekOfYear(Convert.ToDateTime("2015/01/01"), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                int wk2 = gc.GetWeekOfYear(Convert.ToDateTime("2015/01/05"), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                int wk3 = gc.GetWeekOfYear(Convert.ToDateTime("2015/01/05"), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                int wk4 = gc.GetWeekOfYear(Convert.ToDateTime("2015/01/05"), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                int wk5 = gc.GetWeekOfYear(Convert.ToDateTime("2020/03/02"), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                int wk6 = gc.GetWeekOfYear(Convert.ToDateTime("2020/03/09"), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                int wk7 = gc.GetWeekOfYear(Convert.ToDateTime("2020/03/16"), CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday);


                int wkb = gc.GetWeekOfYear(Convert.ToDateTime(date_b), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                int wke = gc.GetWeekOfYear(Convert.ToDateTime(date_e), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                DataTable cn2utd = new DataTable();
                cn2utd.Columns.Add("nobr", typeof(string));
                cn2utd.Columns.Add("name_c", typeof(string));
                cn2utd.Columns.Add("dept", typeof(string));
                cn2utd.Columns.Add("d_name", typeof(string));
                cn2utd.Columns.Add("indt", typeof(DateTime));
                cn2utd.Columns.Add("wkinjob", typeof(decimal));
                cn2utd.Columns.Add("wkoutjob", typeof(decimal));
                cn2utd.Columns.Add("weekcnt", typeof(decimal));
                cn2utd.Columns.Add("wkrel", typeof(decimal));
                cn2utd.Columns.Add("monothrs", typeof(decimal));
                cn2utd.Columns.Add("monconsecutive", typeof(decimal));
                cn2utd.Columns.Add("student_cnt", typeof(decimal));
                cn2utd.Columns.Add("student_nigt", typeof(decimal));
                cn2utd.Columns.Add("student_overot", typeof(decimal));
                DataTable rv_cn2utd = new DataTable();
                rv_cn2utd.Columns.Add("Category", typeof(string));
                rv_cn2utd.Columns.Add("EICC noncompliance Risk level definition", typeof(string));
                rv_cn2utd.Columns.Add("Items", typeof(string));
                rv_cn2utd.Columns.Add("type", typeof(string));
                //rv_cn2utd.Columns.Add("TurnoverRate", typeof(decimal));
                //rv_cn2utd.Columns.Add("TotalLabor", typeof(decimal));
                //rv_cn2utd.Columns.Add("relwk84", typeof(decimal));
                //rv_cn2utd.Columns.Add("relwk84/72", typeof(decimal));
                //rv_cn2utd.Columns.Add("relwk72/60", typeof(decimal));
                //rv_cn2utd.Columns.Add("relwk60/64", typeof(decimal));
                //rv_cn2utd.Columns.Add("relwk60", typeof(decimal));
                //rv_cn2utd.Columns.Add("Maxconsecutive", typeof(decimal));
                //rv_cn2utd.Columns.Add("consecutive24", typeof(decimal));
                //rv_cn2utd.Columns.Add("consecutive24/12", typeof(decimal));
                //rv_cn2utd.Columns.Add("consecutive12/6", typeof(decimal));
                //rv_cn2utd.Columns.Add("OT36", typeof(decimal));
                //rv_cn2utd.Columns.Add("Student", typeof(decimal));
                //rv_cn2utd.Columns.Add("StudentNight", typeof(decimal));
                //rv_cn2utd.Columns.Add("StudentOT", typeof(decimal));

                //跨年度計算週數
                int wky = 0;

                DataTable cn2uta = new DataTable();
                if (DateTime.Parse(date_b).Year == DateTime.Parse(date_e).Year)
                {
                    for (int i = 1; i <= wke - wkb + 1; i++)
                    {
                        cn2uta.Columns.Add("Fld" + i.ToString(), typeof(string));
                        //cn2utd.Columns.Add("Fld" + i.ToString(), typeof(decimal));
                        rv_cn2utd.Columns.Add("Fld" + i.ToString(), typeof(decimal));
                    }
                }
                else
                {
                    wke = 0;
                    int _year = DateTime.Parse(date_e).Year - DateTime.Parse(date_b).Year;
                    int _wkb = gc.GetWeekOfYear(Convert.ToDateTime(date_b), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                    for (int j = 0; j <= _year; j++)
                    {
                        string _datee = Convert.ToString((DateTime.Parse(date_b).Year + j)) + "/12/31";
                        if (int.Parse(DateTime.Parse(_datee).ToString("yyyyMMdd")) > int.Parse(DateTime.Parse(date_e).ToString("yyyyMMdd")))
                            _datee = date_e;
                        int _wke = gc.GetWeekOfYear(Convert.ToDateTime(_datee), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        wky += _wke - _wkb;
                        string _dateb = Convert.ToString((DateTime.Parse(date_b).Year + 1)) + "/01/01";
                        _wkb = gc.GetWeekOfYear(Convert.ToDateTime(_dateb), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                        if (_wkb == _wke || _wkb == 52)
                            _wkb = 1;
                        wke += (j == 0) ? wkb + _wke - wkb : _wke - _wkb + 1;

                    }
                    int wkcnt = (wky + _year + 1 > 110) ? 110 : wky + _year + 1;
                    for (int i = 1; i <= wkcnt; i++)
                    {
                        cn2uta.Columns.Add("Fld" + i.ToString(), typeof(string));
                        ////cn2utd.Columns.Add("Fld" + i.ToString(), typeof(decimal));
                        rv_cn2utd.Columns.Add("Fld" + i.ToString(), typeof(decimal));
                    }
                    //wke = wkb + wk + _year + 1;
                }

                cn2utd.PrimaryKey = new DataColumn[] { cn2utd.Columns["nobr"], cn2utd.Columns["weekcnt"] };
                rv_cn2utd.PrimaryKey = new DataColumn[] { rv_cn2utd.Columns["type"] };


                string[] weekname = new string[] { "Sunday", "Saturday", "Friday", "Thursday", "Wednesday", "Tuesday", "Monday" };

                DateTime NextDTb = Convert.ToDateTime(date_b);
                DateTime NextDTe = Convert.ToDateTime(date_b);
                DateTime NextMonb = Convert.ToDateTime(date_b);
                DateTime NextMone = Convert.ToDateTime(date_b);
                string dateb = date_b;
                string datee = string.Empty;

                //一個月出勤/加班资料
                DataTable rq_consecutive = new DataTable();
                rq_consecutive.Columns.Add("nobr", typeof(string));
                rq_consecutive.Columns.Add("wkdays", typeof(decimal));
                rq_consecutive.PrimaryKey = new DataColumn[] { rq_consecutive.Columns["nobr"] };

                //未滿18學生
                DataTable rq_student = new DataTable();
                rq_student.Columns.Add("nobr", typeof(string));
                rq_student.Columns.Add("nightrote", typeof(decimal));
                rq_student.PrimaryKey = new DataColumn[] { rq_student.Columns["nobr"] };

                //部门工时控管汇总表
                DataTable cn2u2 = new DataTable();
                cn2u2 = ds.Tables["cn2u2"].Clone();

                //產生表頭
                decimal Moninjob = 0;//整個月人數加總
                decimal MonCnt = 1; //月週數
                decimal P_Moninjob = 0;//整個月人數加總
                decimal P_MonCnt = 1; //月週數
                int _body = 1; int monb = 0; int mone = 0;
                string attdate_b = date_b;
                string attdate_e = date_e;
                bool nextmon = default(bool);
                //string moninterval = string.Empty;
                DataRow addcnzzta = cn2uta.NewRow();
                for (int i = wkb; i <= wke; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (weekname[j].ToString() == NextDTe.DayOfWeek.ToString())
                        {
                            NextDTb = (j == 0) ? NextDTe.AddDays(7) : NextDTe.AddDays(j);
                            NextDTe = NextDTb.AddDays(1);
                            //if (NextDTe.Month == 3)
                            //    monb = 3;
                            if (DateTime.Parse(dateb).ToString("yyyyMMdd") == NextMone.ToString("yyyyMMdd")) //Convert.ToDecimal(NextDTb.ToString("yyyyMMdd")) >= Convert.ToDecimal(NextMone.ToString("yyyyMMdd"))   NextDTb.Month == NextMone.Month
                            {
                                NextMonb = NextMone.AddDays(27);
                                if (NextDTb.Month == 2 && NextDTb.Day >= 28)
                                    NextMonb = NextMonb.AddDays(7);
                                else if (NextDTb.Month != 2 && NextMonb.Day >= 29)
                                    NextMonb = NextMonb.AddDays(7);
                                //moninterval += NextMone.ToString("yyyyMMdd") + "~" + NextMonb.ToString("yyyyMMdd") + ";";
                                NextMone = NextMonb.AddDays(1);
                                attdate_e = NextMonb.ToString("yyyy/MM/dd");
                                nextmon = bool.Parse("True");
                            }
                            else
                            {
                                nextmon = default(bool);
                            }
                            break;
                        }
                    }

                    //datee = (i < wke) ? NextDTb.ToString("yyyy/MM/dd") : date_e;
                    if (i < wke)
                    {
                        datee = NextDTb.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        datee = date_e;
                        attdate_e = date_e;
                    }
                    int nwk = gc.GetWeekOfYear(Convert.ToDateTime(dateb), CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);

                    //在職人數
                    string sqlCmd1 = "select b.nobr,a.name_c,a.name_e";
                    sqlCmd1 += " from base a,basetts b";
                    sqlCmd1 += " left outer join dept c on b.dept=c.d_no";
                    sqlCmd1 += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", datee);
                    sqlCmd1 += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd1 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                    sqlCmd1 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                    sqlCmd1 += " and b.ttscode in ('1','4','6')";
                    sqlCmd1 += type_data;
                    sqlCmd1 += workadr;
                    DataTable rq_injob = SqlConn.GetDataTable(sqlCmd1);
                    rq_injob.PrimaryKey = new DataColumn[] { rq_injob.Columns["nobr"] };

                    //離職人數
                    string sqlCmd2 = "select b.nobr,a.name_c,a.name_e";
                    sqlCmd2 += " from base a,basetts b";
                    sqlCmd2 += " left outer join dept c on b.dept=c.d_no";
                    sqlCmd2 += string.Format(@" where a.nobr=b.nobr and b.oudt between '{0}' and '{1}'", dateb, datee);
                    sqlCmd2 += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd2 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                    sqlCmd2 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                    sqlCmd2 += type_data;
                    sqlCmd2 += workadr;
                    DataTable rq_outjob = SqlConn.GetDataTable(sqlCmd2);
                    rq_outjob.PrimaryKey = new DataColumn[] { rq_outjob.Columns["nobr"] };

                    //出勤資料
                    string sqlAttend = "select a.nobr,sum(b.wk_hrs) as wk_hrs";
                    sqlAttend += " from attend a,rote b";
                    sqlAttend += " where a.rote=b.rote";
                    sqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", dateb, datee);
                    sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlAttend += " group by a.nobr";
                    DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                    rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"] };


                    //請假日期
                    string sqlAbs = "select a.nobr,a.tol_hours,a.h_code,b.h_name,b.unit,b.year_rest,c.rote,b.flag";
                    sqlAbs += " from attend c ,abs a ";
                    sqlAbs += " left outer join hcode b on a.h_code=b.h_code";
                    sqlAbs += " where a.nobr=c.nobr and a.bdate=c.adate";
                    sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", dateb, datee);
                    sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlAbs += " and b.flag='-' and b.mang=0";
                    DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs);

                    DataTable rq_abs = new DataTable();
                    rq_abs.Columns.Add("nobr", typeof(string));
                    rq_abs.Columns.Add("tol_hours", typeof(decimal));
                    rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"] };
                    foreach (DataRow Row in rq_abs1.Rows)
                    {
                        if (!Disinclude_Hcode.Contains(Row["h_code"].ToString()))    //公出不扣出勤時數
                        {
                            Row["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * (-1);
                            DataRow row = rq_abs.Rows.Find(Row["nobr"].ToString());
                            DataRow row2 = rq_rote.Rows.Find(Row["rote"].ToString());
                            if (Row["unit"].ToString().Trim() == "天")
                            {
                                if (row2 != null)
                                {
                                    Row["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row2["wk_hrs"].ToString());
                                }
                            }

                            if (row != null)
                            {
                                row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                            }
                            else
                            {
                                DataRow aRrow = rq_abs.NewRow();
                                aRrow["nobr"] = Row["nobr"].ToString();
                                aRrow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                                rq_abs.Rows.Add(aRrow);
                            }
                        }
                    }
                    rq_abs1 = null;
                    //加班資料
                    string sqlOt = "select a.nobr,sum(a.ot_hrs+a.rest_hrs) as ot_hrs";
                    //sqlOt += ",dbo.ottypecn(a.NOBR,a.BDATE,b.ROTE,a.OT_ROTE,a.OTRATE_CODE) as type";
                    if (checkB)
                        sqlOt += " from ot_b a ";
                    else
                        sqlOt += " from ot a ";
                    sqlOt += " left outer join attend b on  a.nobr=b.nobr and a.bdate=b.adate";
                    sqlOt += string.Format(@" where a.bdate between '{0}' and '{1}'", dateb, datee);
                    sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlOt += " group by a.nobr";
                    DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                    //DataTable rq_ot = new DataTable();
                    //rq_ot.Columns.Add("nobr", typeof(string));
                    //rq_ot.Columns.Add("ot_hrs", typeof(decimal));
                    //rq_ot.Columns.Add("weekhrs", typeof(decimal));
                    //rq_ot.Columns.Add("holihrs", typeof(decimal));
                    rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };


                    if (nextmon)    //整個月
                    {
                        if (Convert.ToDecimal(DateTime.Parse(attdate_e).ToString("yyyyMMdd")) > Convert.ToDecimal(DateTime.Parse(date_e).ToString("yyyyMMdd")))
                            attdate_e = date_e;
                        rq_consecutive.Clear();
                        string sqlAttend1 = "select a.nobr,dbo.GetContinuousWorkDay(a.nobr,a.adate) as cnt";
                        sqlAttend1 += " from attend a";
                        sqlAttend1 += string.Format(@" where  a.adate between '{0}' and '{1}'", attdate_b, attdate_e);
                        sqlAttend1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlAttend1 += " order by a.nobr,a.adate";
                        DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend1);

                        foreach (DataRow Row in rq_attend1.Select("cnt>0"))
                        {
                            DataRow row = rq_consecutive.Rows.Find(Row["nobr"].ToString());
                            if (row != null)
                            {
                                if (decimal.Parse(Row["cnt"].ToString()) > decimal.Parse(row["wkdays"].ToString()))
                                    row["wkdays"] = decimal.Parse(Row["cnt"].ToString());
                            }
                            else
                            {
                                DataRow aRow = rq_consecutive.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["wkdays"] = decimal.Parse(Row["cnt"].ToString());
                                rq_consecutive.Rows.Add(aRow);
                            }
                        }
                        rq_attend1 = null;

                        //加班資料
                        rq_monot.Clear();
                        string sqlOta = "select a.nobr,sum(a.ot_hrs+a.rest_hrs) as ot_hrs";
                        if (checkB)
                            sqlOta += " from ot_b a ";
                        else
                            sqlOta += " from ot a ";
                        sqlOta += " left outer join attend b on  a.nobr=b.nobr and a.bdate=b.adate";
                        sqlOta += string.Format(@" where a.bdate between '{0}' and '{1}'", attdate_b, attdate_e);
                        sqlOta += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlOta += " group by a.nobr";
                        rq_monot = SqlConn.GetDataTable(sqlOta);
                        rq_monot.PrimaryKey = new DataColumn[] { rq_monot.Columns["nobr"] };

                        //未滿18歲學生
                        rq_student.Clear();
                        string sqlAttend2 = "select a.nobr,a.rote";
                        sqlAttend2 += " from base b,attend a";
                        sqlAttend2 += " left outer join rote c on a.rote=c.rote";
                        sqlAttend2 += " where a.nobr=b.nobr";
                        sqlAttend2 += string.Format(@" and a.adate between '{0}' and '{1}'", attdate_b, attdate_e);
                        sqlAttend2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlAttend2 += string.Format(@" and datediff(d,b.birdt,'{0}')/365.24<18", attdate_e);
                        sqlAttend2 += " order by a.nobr,a.adate";
                        DataTable rq_attend2 = SqlConn.GetDataTable(sqlAttend2);

                        foreach (DataRow Row in rq_attend2.Rows)
                        {
                            DataRow row = rq_student.Rows.Find(Row["nobr"].ToString());
                            string _rote = Row["rote"].ToString();
                            if (row != null)
                            {
                                if (student_NightRote.Contains(_rote))
                                    row["nightrote"] = 1;
                            }
                            else
                            {
                                DataRow aRow1 = rq_student.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["nightrote"] = (student_NightRote.Contains(_rote)) ? 1 : 0;
                                rq_student.Rows.Add(aRow1);
                            }
                        }
                        rq_attend2 = null;
                        P_Moninjob = Moninjob;
                        Moninjob = rq_injob.Rows.Count;
                    }
                    else
                    {
                        Moninjob += rq_injob.Rows.Count;
                        MonCnt += 1;
                        //P_Moninjob = 0;
                        //P_MonCnt = 0;
                    }

                    decimal injob = rq_injob.Rows.Count; //在職人數
                    decimal outjob = rq_outjob.Rows.Count; //離職人數
                    int attcnt = 0;
                    foreach (DataRow Row in rq_attend.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        DataRow row2 = rq_abs.Rows.Find(Row["nobr"].ToString());
                        DataRow row3 = rq_ot.Rows.Find(Row["nobr"].ToString());
                        DataRow row4 = rq_injob.Rows.Find(Row["nobr"].ToString());
                        DataRow row5 = rq_outjob.Rows.Find(Row["nobr"].ToString());
                        DataRow row6 = rq_consecutive.Rows.Find(Row["nobr"].ToString());
                        DataRow row7 = rq_monot.Rows.Find(Row["nobr"].ToString());
                        DataRow row8 = rq_student.Rows.Find(Row["nobr"].ToString());
                        decimal othrs = (row3 == null) ? 0 : decimal.Parse(row3["ot_hrs"].ToString());
                        decimal abshrs = (row2 == null) ? 0 : decimal.Parse(row2["tol_hours"].ToString());
                        if (row != null)
                        {
                            attcnt += 1;
                            if (attcnt == 1)
                            {
                                DataRow row30 = rv_cn2utd.Rows.Find("TurnoverRate");
                                if (row30 != null)
                                {
                                    row30["Fld" + _body.ToString()] = Math.Round(outjob / injob, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    DataRow aRow1 = rv_cn2utd.NewRow();
                                    aRow1["Category"] = "Turnover";
                                    aRow1["EICC noncompliance Risk level definition"] = "";
                                    aRow1["Items"] = "turnover rate";
                                    aRow1["type"] = "TurnoverRate";
                                    aRow1["Fld" + _body.ToString()] = Math.Round(outjob / injob, 2, MidpointRounding.AwayFromZero);
                                    rv_cn2utd.Rows.Add(aRow1);
                                }

                                DataRow row31 = rv_cn2utd.Rows.Find("TotalLabor");
                                if (row31 != null)
                                {
                                    row31["Fld" + _body.ToString()] = rq_injob.Rows.Count;
                                }
                                else
                                {
                                    DataRow aRow1 = rv_cn2utd.NewRow();
                                    aRow1["Category"] = "Turnover";
                                    aRow1["EICC noncompliance Risk level definition"] = "";
                                    aRow1["Items"] = "Total labor";
                                    aRow1["type"] = "TotalLabor";
                                    aRow1["Fld" + _body.ToString()] = rq_injob.Rows.Count;
                                    rv_cn2utd.Rows.Add(aRow1);
                                }
                            }
                            //if (row4 != null) injob += 1;
                            //if (row5 != null) outjob += 1;
                            decimal wkhrs = decimal.Parse(Row["wk_hrs"].ToString()) + othrs + abshrs;

                            DataRow row32 = rv_cn2utd.Rows.Find("relwk84");
                            if (row32 != null)
                            {
                                if (row32.IsNull("Fld" + _body.ToString())) row32["Fld" + _body.ToString()] = 0;
                                if (wkhrs > 84) row32["Fld" + _body.ToString()] = decimal.Parse(row32["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC Working Hour Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "Priority";
                                aRow1["Items"] = "WWH >84h(%)";
                                aRow1["type"] = "relwk84";
                                aRow1["Fld" + _body.ToString()] = (wkhrs > 84) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row33 = rv_cn2utd.Rows.Find("relwk84/72");
                            if (row33 != null)
                            {
                                if (row33.IsNull("Fld" + _body.ToString())) row33["Fld" + _body.ToString()] = 0;
                                if (wkhrs > 72 && wkhrs <= 84) row33["Fld" + _body.ToString()] = decimal.Parse(row33["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC Working Hour Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 1% ≤ Minor ≤ 5% 2) 5% < Major ≤ 15% 3) Priority>15%: ";
                                aRow1["Items"] = "84 h ≥ WWH > 72h (%)";
                                aRow1["type"] = "relwk84/72";
                                aRow1["Fld" + _body.ToString()] = (wkhrs > 72 && wkhrs <= 84) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row34 = rv_cn2utd.Rows.Find("relwk72/60");
                            if (row34 != null)
                            {
                                if (row34.IsNull("Fld" + _body.ToString())) row34["Fld" + _body.ToString()] = 0;
                                if (wkhrs > 60 && wkhrs <= 72) row34["Fld" + _body.ToString()] = decimal.Parse(row34["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC Working Hour Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 1% ≤ Minor ≤ 5% 2) 5% < Major ≤ 15% 3) 15% < Major ≤ 40% 4) Priority >40% ";
                                aRow1["Items"] = "72 h ≥ WWH > 60h (%)";
                                aRow1["type"] = "relwk72/60";
                                aRow1["Fld" + _body.ToString()] = (wkhrs > 60 && wkhrs <= 72) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row35 = rv_cn2utd.Rows.Find("relwk60/49");
                            if (row35 != null)
                            {
                                if (row35.IsNull("Fld" + _body.ToString())) row35["Fld" + _body.ToString()] = 0;
                                if (wkhrs > 49 && wkhrs <= 60) row35["Fld" + _body.ToString()] = decimal.Parse(row35["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC Working Hour Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 1% ≤ Minor ≤ 40% 2) Major >40% ";
                                aRow1["Items"] = "60 h ≥ WWH > 49h (%)";
                                aRow1["type"] = "relwk60/49";
                                aRow1["Fld" + _body.ToString()] = (wkhrs > 49 && wkhrs <= 60) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row36 = rv_cn2utd.Rows.Find("relwk60");
                            if (row36 != null)
                            {
                                if (row36.IsNull("Fld" + _body.ToString())) row36["Fld" + _body.ToString()] = 0;
                                if (wkhrs > 60) row36["Fld" + _body.ToString()] = decimal.Parse(row36["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC Working Hour Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "";
                                aRow1["Items"] = "% over 60hrs";
                                aRow1["type"] = "relwk60";
                                aRow1["Fld" + _body.ToString()] = (wkhrs > 60) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            decimal wkdays = (row6 != null) ? decimal.Parse(row6["wkdays"].ToString()) : 0;
                            DataRow row37 = rv_cn2utd.Rows.Find("Maxconsecutive");
                            if (row37 != null)
                            {
                                if (row37.IsNull("Fld" + _body.ToString())) row37["Fld" + _body.ToString()] = 0;
                                if (wkdays >= decimal.Parse(row37["Fld" + _body.ToString()].ToString())) row37["Fld" + _body.ToString()] = wkdays;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC CWD Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "Max consecutive days";
                                aRow1["Items"] = "Maxconsecutive";
                                aRow1["type"] = "Maxconsecutive";
                                aRow1["Fld" + _body.ToString()] = wkdays;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row38 = rv_cn2utd.Rows.Find("consecutive24");
                            if (row38 != null)
                            {
                                if (row38.IsNull("Fld" + _body.ToString())) row38["Fld" + _body.ToString()] = 0;
                                if (wkdays >= 24) row38["Fld" + _body.ToString()] = decimal.Parse(row38["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC CWD Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) Priority>0%";
                                aRow1["Items"] = "≥24 consecutive days(%)";
                                aRow1["type"] = "consecutive24";
                                aRow1["Fld" + _body.ToString()] = (wkdays >= 24) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row39 = rv_cn2utd.Rows.Find("consecutive24/12");
                            if (row39 != null)
                            {
                                if (row39.IsNull("Fld" + _body.ToString())) row39["Fld" + _body.ToString()] = 0;
                                if (wkdays > 12 && wkdays < 24) row39["Fld" + _body.ToString()] = decimal.Parse(row39["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC CWD Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 0<Minor < 5% 2) 5% ≤ Major ≤ 40% 3) Priority >40% ";
                                aRow1["Items"] = ">12 to < 24 consecutive days(%)";
                                aRow1["type"] = "consecutive24/12";
                                aRow1["Fld" + _body.ToString()] = (wkdays > 12 && wkdays < 24) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row40 = rv_cn2utd.Rows.Find("consecutive12/6");
                            if (row40 != null)
                            {
                                if (row40.IsNull("Fld" + _body.ToString())) row40["Fld" + _body.ToString()] = 0;
                                if (wkdays > 6 && wkdays <= 12) row40["Fld" + _body.ToString()] = decimal.Parse(row40["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "EICC CWD Compliance";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 0%< Minor ≤ 40% 2) Major >40% ";
                                aRow1["Items"] = ">6 to ≤12 consecutive Days(%)";
                                aRow1["type"] = "consecutive12/6";
                                aRow1["Fld" + _body.ToString()] = (wkdays > 6 && wkdays <= 12) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            decimal monot = (row7 != null) ? decimal.Parse(row7["ot_hrs"].ToString()) : 0;
                            DataRow row41 = rv_cn2utd.Rows.Find("OT36");
                            if (row41 != null)
                            {
                                if (row41.IsNull("Fld" + _body.ToString())) row41["Fld" + _body.ToString()] = 0;
                                if (monot > 36) row41["Fld" + _body.ToString()] = decimal.Parse(row41["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "Local Labor Law Working Hour";
                                aRow1["EICC noncompliance Risk level definition"] = "1) 1% ≤ Minor ≤ 40% 2) Major >40% ";
                                aRow1["Items"] = "Monthly OT hours> 36 hours(%)";
                                aRow1["type"] = "OT36";
                                aRow1["Fld" + _body.ToString()] = (monot > 6 && monot <= 21) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }


                            decimal nightrote = (row8 != null) ? decimal.Parse(row8["nightrote"].ToString()) : 0;
                            decimal studentoverot = (row8 != null && monot >= student_othrs) ? 1 : 0;

                            DataRow row42 = rv_cn2utd.Rows.Find("Student");
                            if (row42 != null)
                            {
                                if (row42.IsNull("Fld" + _body.ToString())) row42["Fld" + _body.ToString()] = 0;
                                if (row8 != null) row42["Fld" + _body.ToString()] = decimal.Parse(row42["Fld" + _body.ToString()].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "Student Worker";
                                aRow1["EICC noncompliance Risk level definition"] = "1) Major >10%";
                                aRow1["Items"] = "Student worker(%)";
                                aRow1["type"] = "Student";
                                aRow1["Fld" + _body.ToString()] = (row8 != null) ? 1 : 0;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row43 = rv_cn2utd.Rows.Find("StudentNight");
                            if (row43 != null)
                            {
                                if (row43.IsNull("Fld" + _body.ToString())) row43["Fld" + _body.ToString()] = 0;
                                row43["Fld" + _body.ToString()] = decimal.Parse(row43["Fld" + _body.ToString()].ToString()) + nightrote;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "Student Worker";
                                aRow1["EICC noncompliance Risk level definition"] = "1) Priority >0% ";
                                aRow1["Items"] = "Night shift (%)";
                                aRow1["type"] = "StudentNight";
                                aRow1["Fld" + _body.ToString()] = nightrote;
                                rv_cn2utd.Rows.Add(aRow1);
                            }

                            DataRow row44 = rv_cn2utd.Rows.Find("StudentOT");
                            if (row44 != null)
                            {
                                if (row44.IsNull("Fld" + _body.ToString())) row44["Fld" + _body.ToString()] = 0;
                                row44["Fld" + _body.ToString()] = decimal.Parse(row44["Fld" + _body.ToString()].ToString()) + studentoverot;
                            }
                            else
                            {
                                DataRow aRow1 = rv_cn2utd.NewRow();
                                aRow1["Category"] = "Student Worker";
                                aRow1["EICC noncompliance Risk level definition"] = "1) Major >0% ";
                                aRow1["Items"] = "monthly over time>0 Hours (%) ";
                                aRow1["type"] = "StudentOT";
                                aRow1["Fld" + _body.ToString()] = studentoverot;
                                rv_cn2utd.Rows.Add(aRow1);
                            }
                        }
                    }

                    //每週資料計算百分比
                    DataRow row50 = rv_cn2utd.Rows.Find("relwk84");
                    DataRow row51 = rv_cn2utd.Rows.Find("relwk84/72");
                    DataRow row52 = rv_cn2utd.Rows.Find("relwk72/60");
                    DataRow row53 = rv_cn2utd.Rows.Find("relwk60/49");
                    DataRow row54 = rv_cn2utd.Rows.Find("relwk60");
                    decimal greatersixty = 0;
                    if (row50 != null)
                    {
                        decimal relwk = (row50.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row50["Fld" + _body.ToString()].ToString()) / injob, 2, MidpointRounding.AwayFromZero);
                        row50["Fld" + _body.ToString()] = relwk;
                        greatersixty += relwk;
                    }
                    if (row51 != null)
                    {
                        decimal relwk = (row51.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row51["Fld" + _body.ToString()].ToString()) / injob, 2, MidpointRounding.AwayFromZero);
                        row51["Fld" + _body.ToString()] = relwk;
                        greatersixty += relwk;
                    }
                    if (row52 != null)
                    {
                        decimal relwk = (row52.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row52["Fld" + _body.ToString()].ToString()) / injob, 2, MidpointRounding.AwayFromZero);
                        row52["Fld" + _body.ToString()] = relwk;
                        greatersixty += relwk;
                    }
                    if (row53 != null)
                    {
                        decimal relwk = (row53.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row53["Fld" + _body.ToString()].ToString()) / injob, 2, MidpointRounding.AwayFromZero);
                        row53["Fld" + _body.ToString()] = relwk;
                    }
                    if (row54 != null)
                    {
                        row54["Fld" + _body.ToString()] = greatersixty;
                    }

                    //整月資料計算百分比
                    DataRow row60 = rv_cn2utd.Rows.Find("consecutive24");
                    DataRow row61 = rv_cn2utd.Rows.Find("consecutive24/12");
                    DataRow row62 = rv_cn2utd.Rows.Find("consecutive12/6");
                    DataRow row63 = rv_cn2utd.Rows.Find("OT36");
                    DataRow row64 = rv_cn2utd.Rows.Find("Student");
                    DataRow row65 = rv_cn2utd.Rows.Find("StudentNight");
                    DataRow row66 = rv_cn2utd.Rows.Find("StudentOT");
                    if (nextmon && i != wkb)
                    {
                        //P_Moninjob = Moninjob;
                        //P_MonCnt = MonCnt;
                        decimal MonCnt1 = _body - P_MonCnt;

                        for (decimal j = P_MonCnt; j < _body; j++)
                        {
                            row60["Fld" + j.ToString()] = (row60.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row60["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row61["Fld" + j.ToString()] = (row61.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row61["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row62["Fld" + j.ToString()] = (row62.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row62["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row63["Fld" + j.ToString()] = (row63.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row63["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row64["Fld" + j.ToString()] = (row64.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row64["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row65["Fld" + j.ToString()] = (row65.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row65["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            row66["Fld" + j.ToString()] = (row66.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row66["Fld" + j.ToString()].ToString()) / (P_Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                        }
                        if (i == wke)
                        {
                            row60["Fld" + _body.ToString()] = (row60.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row60["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row61["Fld" + _body.ToString()] = (row61.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row61["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row62["Fld" + _body.ToString()] = (row62.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row62["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row63["Fld" + _body.ToString()] = (row63.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row63["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row64["Fld" + _body.ToString()] = (row64.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row64["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row65["Fld" + _body.ToString()] = (row65.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row65["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                            row66["Fld" + _body.ToString()] = (row66.IsNull("Fld" + _body.ToString())) ? 0 : Math.Round(decimal.Parse(row66["Fld" + _body.ToString()].ToString()) / (Moninjob / MonCnt), 2, MidpointRounding.AwayFromZero);
                        }
                        P_MonCnt = _body;
                    }
                    else
                    {
                        //P_Moninjob = Moninjob;
                        //P_MonCnt = MonCnt;
                        decimal MonCnt1 = _body - P_MonCnt;
                        if (i == wke)
                        {
                            for (decimal j = P_MonCnt; j <= _body; j++)
                            {
                                row60["Fld" + j.ToString()] = (row60.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row60["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row61["Fld" + j.ToString()] = (row61.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row61["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row62["Fld" + j.ToString()] = (row62.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row62["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row63["Fld" + j.ToString()] = (row63.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row63["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row64["Fld" + j.ToString()] = (row64.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row64["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row65["Fld" + j.ToString()] = (row65.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row65["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                                row66["Fld" + j.ToString()] = (row66.IsNull("Fld" + j.ToString())) ? 0 : Math.Round(decimal.Parse(row66["Fld" + j.ToString()].ToString()) / (Moninjob / MonCnt1), 2, MidpointRounding.AwayFromZero);
                            }
                        }
                    }

                    addcnzzta["Fld" + _body.ToString()] = "第" + nwk.ToString() + "週 " + dateb + " ~ " + datee;


                    dateb = NextDTe.ToString("yyyy/MM/dd");
                    attdate_b = NextMone.ToString("yyyy/MM/dd");
                    _body++;
                    rq_abs = null; rq_abs1 = null; rq_attend = null; rq_ot = null; rq_injob = null; rq_outjob = null;
                }
                rq_consecutive = null; rq_student = null; rq_monot = null;
                cn2uta.Rows.Add(addcnzzta);  //表頭
                //JBHR.Reports.ReportClass.Export(rv_cn2utd, "rv_cn2utd");
                //JBHR.Reports.ReportClass.Export(cn2uta, "cn2uta");

                //DataRow [] SRow = cn2utd.Select("", "dept,nobr asc");


                //    夜班比率(%)=上夜班学生工总人数/学生工总人数 或 上夜班未成年工总人数/未成年工总人数


                //if (reporttype == "0")
                //{
                //    ds.Tables["cnzz2uta"].Merge(cn2uta);
                //    foreach (DataRow Row in SRow)
                //    {
                //        ds.Tables["cnzz2utd"].ImportRow(Row);
                //    }
                //}


                rq_base = null;
                if (exportexcel)
                {
                    if (reporttype == "0")
                    {
                        //Export(ds.Tables["cnzz2utd"], ds.Tables["cnzz2uta"]);
                        Export(rv_cn2utd, cn2uta);
                    }

                    //else if (reporttype == "1")
                    //    Export1(ds.Tables["cn2u1"]);
                    //else if (reporttype == "2")
                    //    Export2(ds.Tables["cn2u2"]);
                    //else if (reporttype == "3")
                    //    Export3(ds.Tables["cn2u3"]);
                    this.Close();
                }

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Errorlog + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        void Export(DataTable DT, DataTable DT_cn2uta)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("Category", typeof(string));
            ExporDt.Columns.Add("EICC noncompliance Risk level definition", typeof(string));
            ExporDt.Columns.Add("Items", typeof(string));
            for (int i = 0; i < DT_cn2uta.Columns.Count; i++)
            {
                if (DT_cn2uta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_cn2uta.Rows[0][i].ToString().Trim(), typeof(decimal));
                }
                else
                    break;
            }
            //DataRow[] SRow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                //aRow["部门代码"] = Row["dept"].ToString();
                aRow["Category"] = Row["Category"].ToString();
                aRow["EICC noncompliance Risk level definition"] = Row["EICC noncompliance Risk level definition"].ToString();
                aRow["Items"] = Row["Items"].ToString();
                for (int i = 0; i < DT_cn2uta.Columns.Count; i++)
                {
                    if (DT_cn2uta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_cn2uta.Rows[0][i].ToString().Trim()] = (Row.IsNull("Fld" + (i + 1))) ? 0 : decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }


            DataRow aRow1 = ExporDt.NewRow();
            aRow1["Category"] = "Dispatched Worker";
            aRow1["EICC noncompliance Risk level definition"] = "1) if Dispatched worker ratio >10% ";
            aRow1["Items"] = "New hired dispatched worker #";
            DataRow aRow2 = ExporDt.NewRow();
            aRow2["Category"] = "Dispatched Worker";
            aRow2["EICC noncompliance Risk level definition"] = "1) if Dispatched worker ratio >10% ";
            aRow2["Items"] = "Dispatched worker(%)";
            DataRow aRow3 = ExporDt.NewRow();
            aRow3["Category"] = "Young Worker";
            aRow3["EICC noncompliance Risk level definition"] = "1) Major >20%";
            aRow3["Items"] = "Young worker(%)";
            DataRow aRow4 = ExporDt.NewRow();
            aRow4["Category"] = "Young Worker";
            aRow4["EICC noncompliance Risk level definition"] = "1) Priority >0% ";
            aRow4["Items"] = "Night shift (%)";
            DataRow aRow5 = ExporDt.NewRow();
            aRow5["Category"] = "Young Worker";
            aRow5["EICC noncompliance Risk level definition"] = "1) Major>0% ";
            aRow5["Items"] = "monthly over time>0 Hours (%) ";
            DataRow aRow6 = ExporDt.NewRow();
            aRow6["Category"] = "Foreign Worker";
            aRow6["EICC noncompliance Risk level definition"] = "";
            aRow6["Items"] = "Forein worker(%)";


            for (int i = 0; i < DT_cn2uta.Columns.Count; i++)
            {
                if (DT_cn2uta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                {
                    aRow1[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                    aRow2[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                    aRow3[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                    aRow4[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                    aRow5[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                    aRow6[DT_cn2uta.Rows[0][i].ToString().Trim()] = 0;
                }
                else
                    break;
            }
            ExporDt.Rows.Add(aRow1);
            ExporDt.Rows.Add(aRow2);
            ExporDt.Rows.Add(aRow3);
            ExporDt.Rows.Add(aRow4);
            ExporDt.Rows.Add(aRow5);
            ExporDt.Rows.Add(aRow6);

            DT = null;
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
