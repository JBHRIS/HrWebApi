using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class AbsCalculation : JBModule.Message.ReportStatus
    {
        string NobrB, NobrE, DeptB, DeptE, YYMM, SEQ;
        DateTime DateB, DateE;
        static decimal year_days = 365.24M;
        TimeSpan ts;
        public bool CreateAbs = true;
        public List<Sal.WAGED> WagedList = new List<WAGED>();
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        public Guid guid = Guid.Empty;
        List<JBModule.Data.Linq.SALABS> salabsList = null;
        string DI = "";
        public AbsCalculation(string nobr_b, string nobr_e, string dept_b, string dept_e, string yymm, DateTime date_b, DateTime date_e, string seq)
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4C", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("DI", "請假直間接", ""
                , "設定請假計算時要計算直接或是間接人員(D-直接,I-間接)", "TextBox"
                , "", "String");
            NobrB = nobr_b;
            NobrE = nobr_e;
            DeptB = dept_b;
            DeptE = dept_e;
            YYMM = yymm;
            DateB = date_b;
            DateE = date_e;
            SEQ = seq;
            DI = AppConfig.GetConfig("DI").GetString();
        }
        void AddSalabs(JBModule.Data.Linq.SALABS salabs, decimal MaxDiscount)
        {
            if (salabs.AMT == 10) return;
            if (string.IsNullOrWhiteSpace(salabs.SAL_CODE.Trim())) return;
            var sql = from a in salabsList
                      where a.NOBR == salabs.NOBR && a.ADATE == salabs.ADATE
                      //&& a.BTIME == salabs.BTIME 
                      && a.SAL_CODE == salabs.SAL_CODE
                      && a.MLSSALCODE == salabs.MLSSALCODE
                      select a;
            if (sql.Any())
            {
                decimal amt = JBModule.Data.CDecryp.Number(sql.First().AMT) + JBModule.Data.CDecryp.Number(salabs.AMT);
                decimal value = JBModule.Data.CDecryp.Number(salabs.AMT);
                if (amt > MaxDiscount)
                {
                    value = Math.Round(MaxDiscount - JBModule.Data.CDecryp.Number(sql.First().AMT), MidpointRounding.AwayFromZero);
                }
                if (sql.First().BTIME == salabs.BTIME)
                    sql.First().AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(sql.First().AMT) + JBModule.Data.CDecryp.Number(value));
                else
                {
                    salabs.AMT = JBModule.Data.CEncrypt.Number(value);
                    salabsList.Add(salabs);
                }
            }
            else salabsList.Add(salabs);
        }
        void AddSalabs(JBModule.Data.Linq.SALABS salabs)
        {
            AddSalabs(salabs, decimal.MaxValue);
        }
        public void Run()
        {
            DateTime d1, d2;
            d1 = DateTime.Now;
            salabsList = new List<JBModule.Data.Linq.SALABS>();
            param p = new param();
            p.DateB = DateB;
            p.DateE = DateE;
            p.NOBRB = NobrB;
            p.NOBRE = NobrE;
            p.DEPTB = DeptB;
            p.DEPTE = DeptE;
            p.YYMM = YYMM;

            this.Report(0, Resources.Sal.StatusOfInit + ".");
            ////刪除舊資料
            Delete(p.YYMM, p.NOBRB, p.NOBRE, p.DEPTB, p.DEPTE, p.DateB, p.DateE);

            //FRM4CERM.FRM4CDataClassesDataContext db = new JBHR.Sal.FRM4CERM.FRM4CDataClassesDataContext();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //以最後一個月份做為基準日期
            string yy2, mm2;

            if (p.YYMM.Trim().Length == 5)
            {
                yy2 = p.YYMM.Trim().Substring(0, 3);
                mm2 = p.YYMM.Trim().Substring(3, 2);
            }
            else
            {
                yy2 = p.YYMM.Trim().Substring(0, 4);
                mm2 = p.YYMM.Trim().Substring(4, 2);
            }

            string date2;
            if (Convert.ToInt32(yy2) < 1912)
            {
                date2 = (Convert.ToInt32(yy2) + 1911).ToString() + "/" + mm2 + "/" + DateTime.DaysInMonth(Convert.ToInt32(yy2), Convert.ToInt32(mm2)).ToString();
            }
            else
            {
                date2 = yy2 + "/" + mm2 + "/" + DateTime.DaysInMonth(Convert.ToInt32(yy2), Convert.ToInt32(mm2)).ToString();
            }


            //if (CreateAbs)
            //{

            //    var sql2 = from a in db.ATTEND
            //               join b in db.BASETTS on a.NOBR equals b.NOBR
            //               where p.DateE >= b.ADATE && p.DateE <= b.DDATE.Value
            //              && a.NOBR.CompareTo(p.NOBRB) >= 0 && a.NOBR.CompareTo(p.NOBRE) <= 0
            //              && b.DEPT.CompareTo(p.DEPTB) >= 0 && b.DEPT.CompareTo(p.DEPTE) <= 0
            //              && a.ADATE >= p.DateB && a.ADATE <= p.DateE
            //              && (a.LATE_MINS>0 || a.E_MINS>0 || a.ABS)//有異常的部分
            //              && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //               orderby a.ADATE
            //               group a by a.NOBR;
            //    int total = sql2.Count();
            //    int cc = 0;
            //    foreach (var gp in sql2)
            //    {
            //        cc++;
            //        this.Report(cc * 100 / total, "正在執行..產生" + gp.Key + "的請假資料");
            //        //Dictionary<DateTime, decimal> LateData = new Dictionary<DateTime, decimal>();
            //        //Dictionary<DateTime, decimal> ForgetEarilyData = new Dictionary<DateTime, decimal>();
            //        int CurrentLateMins = 0;
            //        int CurrentEarilyTime = 0;
            //        foreach (var it in gp)
            //        {
            //            CurrentLateMins += Convert.ToInt32(it.LATE_MINS);//累計遲到
            //            CurrentEarilyTime += Convert.ToInt32(it.E_MINS);//累計早退
            //            if (it.LATE_MINS >= 0)//遲到
            //            {
            //                string time_b = it.ROTE1.ON_TIME;
            //                string time_e = it.ROTE1.OFF_TIME;
            //                if (it.ATTCARD.Any())
            //                    time_e = it.ATTCARD.First().T2;
            //                JBTools.
            //                JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
            //                abs.NOBR = it.NOBR;
            //                abs.A_NAME = "";
            //                abs.BDATE = it.ADATE;
            //                abs.BTIME = "";
            //                abs.EDATE = it.ADATE;
            //                abs.ETIME = "";
            //                abs.H_CODE = "B";
            //                abs.KEY_DATE = DateTime.Now;
            //                abs.KEY_MAN = MainForm.USER_NAME;
            //                abs.NOTE = "(系統產生)遲到未請假扣曠職" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
            //                abs.NOTEDIT = false;
            //                abs.SERNO = "";
            //                abs.SYSCREATE = false;
            //                abs.SYSCREATE1 = true;
            //                abs.TOL_DAY = 0;
            //                abs.TOL_HOURS = 1;
            //                abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
            //                db.ABS.InsertOnSubmit(abs);
            //                CurrentLateMins = 0;
            //            }
            //            if (it.E_MINS >= 0)//早退
            //            {
            //                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
            //                    abs.NOBR = it.NOBR;
            //                    abs.A_NAME = "";
            //                    abs.BDATE = it.ADATE;
            //                    abs.BTIME = "0000";
            //                    abs.EDATE = it.ADATE;
            //                    abs.ETIME = "0000";
            //                    abs.H_CODE = "B";
            //                    abs.KEY_DATE = DateTime.Now;
            //                    abs.KEY_MAN = MainForm.USER_NAME;
            //                    abs.NOTE = "(系統產生)忘刷早退扣事假" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
            //                    abs.NOTEDIT = false;
            //                    abs.SERNO = "";
            //                    abs.SYSCREATE = false;
            //                    abs.SYSCREATE1 = true;
            //                    abs.TOL_DAY = 0;
            //                    abs.TOL_HOURS = i;
            //                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
            //                    db.ABS.InsertOnSubmit(abs);
            //                CurrentEarilyTime = j;
            //            }
            //            if (it.ABS )//曠職
            //            {
            //                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
            //                    abs.NOBR = it.NOBR;
            //                    abs.A_NAME = "";
            //                    abs.BDATE = it.ADATE;
            //                    abs.BTIME = "0000";
            //                    abs.EDATE = it.ADATE;
            //                    abs.ETIME = "0000";
            //                    abs.H_CODE = "B";
            //                    abs.KEY_DATE = DateTime.Now;
            //                    abs.KEY_MAN = MainForm.USER_NAME;
            //                    abs.NOTE = "(系統產生)忘刷早退扣事假" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
            //                    abs.NOTEDIT = false;
            //                    abs.SERNO = "";
            //                    abs.SYSCREATE = false;
            //                    abs.SYSCREATE1 = true;
            //                    abs.TOL_DAY = 0;
            //                    abs.TOL_HOURS = i;
            //                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
            //                    db.ABS.InsertOnSubmit(abs);
            //            }

            //        }

            //    }
            //}


            var ABSGROUP_Full = (from abs in db.ABS
                                 join hcodes in db.HCODES on abs.H_CODE equals hcodes.H_CODE into rh
                                 from rHcodes in rh.DefaultIfEmpty()
                                 join attend in db.ATTEND on new { abs.NOBR, abs.BDATE.Date } equals new { attend.NOBR, attend.ADATE.Date }
                                 join rote in db.ROTE on attend.ROTE equals rote.ROTE1
                                 join hcode in db.HCODE on abs.H_CODE equals hcode.H_CODE
                                 join basetts in db.BASETTS on abs.NOBR equals basetts.NOBR
                                 join baserow in db.BASE on abs.NOBR equals baserow.NOBR
                                 join d in db.DEPT on basetts.DEPT equals d.D_NO
                                 //join wrnt in db.WriteRuleNobrTable.Where(wp => wp.GUID == guid) on abs.NOBR equals wrnt.EMPID
                                 where abs.BDATE >= basetts.ADATE && abs.BDATE <= basetts.DDATE
                                 && basetts.NOBR.CompareTo(p.NOBRB) >= 0 && basetts.NOBR.CompareTo(p.NOBRE) <= 0
                                 && d.D_NO_DISP.CompareTo(p.DEPTB) >= 0 && d.D_NO_DISP.CompareTo(p.DEPTE) <= 0
                                 && abs.YYMM == p.YYMM
                                 //&& db.GetFilterByNobr(abs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                 && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(q => q.DATAGROUP).Contains(basetts.SALADR)
                                 && !basetts.CALABS//必須沒有勾選[不計算請假]
                                                   //&& !basetts.NOWAGE
                                  && (DI.Trim().Length == 0 || basetts.DI == DI)//如果有設定di時，只抓直接或是間接
                                 select new
                                 {
                                     abs,
                                     abs.NOBR,
                                     abs.BDATE,
                                     abs.BTIME,
                                     abs.H_CODE,
                                     abs.TOL_HOURS,
                                     abs.YYMM,
                                     RATE = rHcodes == null ? 0 : rHcodes.RATE,
                                     SAL_CODE = rHcodes == null ? "" : rHcodes.SAL_CODE,
                                     MLSSALCODE = rHcodes == null ? "" : rHcodes.MLSSALCODE,
                                     //AMT = salbasdRow != null ? salbasdRow.AMT : 0,
                                     basetts.INDT,
                                     HCODESRATE = rHcodes == null ? null : rHcodes.HCODESRATE,
                                     basetts.WK_YRS,
                                     baserow.COUNT_MA,
                                     HCODE = hcode,
                                     rote.WK_HRS,
                                     //salcode.SOS_ID
                                 }).ToList();
            var ABSGROUP = ABSGROUP_Full.GroupBy(x => x.abs.NOBR);

            var salbasdList = (from a in db.SALBASD
                               join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                               //join wrnt in db.WriteRuleNobrTable.Where(wp => wp.GUID == guid) on a.NOBR equals wrnt.EMPID
                               where a.NOBR.CompareTo(p.NOBRB) >= 0 && a.NOBR.CompareTo(p.NOBRE) <= 0
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && (from bts in db.BASETTS
                                   where bts.NOBR == a.NOBR
                                   && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                   && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                   select 1).Any()
                               && b.SOS_ID == "1"//系統計算
                               && !b.SALBASD1//未勾選才抓全薪
                               select new { SALBASD = a, SALCODE = b }).ToList();
            var SalcodeList = db.SALCODE.ToList();
            var salbasd1List = (from a in WagedList
                                join b in SalcodeList on a.SAL_CODE equals b.SAL_CODE
                                where a.YYMM == p.YYMM && a.SEQ == SEQ
                                && a.NOBR.CompareTo(p.NOBRB) >= 0 && a.NOBR.CompareTo(p.NOBRE) <= 0
                                && b.SALBASD1
                                select new { SALBASD1 = a, SALCODE = b }).ToList();
            decimal count = 0;
            decimal t = ABSGROUP.Count();
            foreach (var NOBRABS in ABSGROUP)
            {
                count++;
                int rr = Convert.ToInt32(decimal.Ceiling(Convert.ToDecimal(count / t * 100)));
                if (rr > 0 && rr % 2 == 0)
                {
                    this.Report(rr, "請假扣款計算：" + Resources.Sal.StatusComputing + NOBRABS.Key.ToString());
                }
                DateTime CheckSameDate = new DateTime(1900, 1, 1);
                foreach (var gp in NOBRABS)
                {
                    string sUnit = gp.HCODE.UNIT;
                    gp.abs.NOTEDIT = true;
                    decimal rate1, abs_hrs, amt1;//, amt2, amt3;
                    rate1 = gp.RATE;
                    abs_hrs = gp.TOL_HOURS;
                    amt1 = 0;

                    var salbasdOfNobrSalcode = salbasdList.Where(q => q.SALBASD.NOBR == gp.abs.NOBR && q.SALBASD.SAL_CODE == gp.SAL_CODE && gp.BDATE >= q.SALBASD.ADATE && gp.BDATE <= q.SALBASD.DDATE);

                    decimal dayAmt = decimal.MaxValue;
                    if (salbasdOfNobrSalcode.Any())
                    {
                        decimal DivBaseDay, DivBaseHours;
                        DivBaseDay = 30;
                        DivBaseHours = 240;
                        decimal DayHours = gp.WK_HRS;
                        //if (DayHours == 0) continue;//避免選到假日或是設定錯誤，不會提醒直接略過
                        if (DayHours == 0)
                            DayHours = 8;

                        if (gp.HCODESRATE != null && gp.HCODESRATE.Any())//符合特殊條件
                        {
                            decimal AbsHrs = gp.abs.TOL_HOURS;
                            if (sUnit == "天") AbsHrs = AbsHrs * DayHours;
                            var sql = from row in gp.HCODESRATE
                                      where AbsHrs >= row.YEAR_B && AbsHrs <= row.YEAR_E//判斷特殊條件時數對應比例
                                      orderby row.YEAR_B
                                      select row;
                            if (sql.Any())
                            {
                                rate1 = sql.First().RATE;//使用設定倍率
                                abs_hrs = DayHours;//強迫算一天
                                sUnit = "小時";
                                dayAmt = dayAmt - 1;
                            }
                        }
                        if (sUnit == "天")
                            amt1 = GetAmtByDay(salbasdOfNobrSalcode.Select(pp => pp.SALBASD).ToList(), SalcodeList) * abs_hrs * rate1;
                        else
                            amt1 = GetAmtByHour(salbasdOfNobrSalcode.Select(pp => pp.SALBASD).ToList(), SalcodeList) * abs_hrs * rate1;
                        dayAmt = GetAmtByDay(salbasdOfNobrSalcode.Select(pp => pp.SALBASD).ToList(), SalcodeList);
                    }
                    var salbasd1OfNobrSalcode = salbasd1List.Where(q => q.SALBASD1.NOBR == gp.abs.NOBR && q.SALBASD1.SAL_CODE == gp.SAL_CODE);
                    if (salbasd1OfNobrSalcode.Any())
                    {
                        if (gp.HCODE.UNIT == "天")
                            amt1 = GetAmtByDay1(salbasd1OfNobrSalcode.Select(pp => pp.SALBASD1).ToList(), SalcodeList) * abs_hrs * rate1;
                        else
                            amt1 = GetAmtByHour1(salbasd1OfNobrSalcode.Select(pp => pp.SALBASD1).ToList(), SalcodeList) * abs_hrs * rate1;
                    }
                    decimal total_amt = Math.Round(amt1, MidpointRounding.AwayFromZero);

                    JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                    salabs.YYMM = gp.YYMM;
                    salabs.NOBR = gp.NOBR.Trim();
                    salabs.ADATE = gp.BDATE;
                    salabs.BTIME = gp.BTIME;
                    salabs.H_CODE = gp.H_CODE.Trim();
                    salabs.SAL_CODE = gp.SAL_CODE.Trim();
                    salabs.AMT = JBModule.Data.CEncrypt.Number(total_amt);
                    salabs.ADJ_CODE = "11";
                    salabs.MLSSALCODE = gp.MLSSALCODE.Trim();
                    salabs.SALSEQ = "";
                    salabs.KEY_MAN = MainForm.USER_NAME;
                    salabs.KEY_DATE = DateTime.Now;
                    //db.SALABS.InsertOnSubmit(salabs);
                    AddSalabs(salabs, dayAmt);
                }
            }
            List<string> year_restList = new List<string>();
            year_restList.Add("1");
            year_restList.Add("3");
            year_restList.Add("5");
            var sql1_full = (from a in db.ABS
                             join b in db.BASETTS on a.NOBR equals b.NOBR
                             join c in db.HCODE on a.H_CODE equals c.H_CODE
                             join d in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { d.NOBR, d.ADATE.Date }
                             join f in db.ROTE on d.ROTE equals f.ROTE1
                             join b1 in db.BASETTS on a.NOBR equals b1.NOBR
                             join g in db.STATION on b1.STATION equals g.Code into bg
                             from st in bg.DefaultIfEmpty()
                             join h in db.DEPT on b.DEPT equals h.D_NO
                             join i in db.ROTET on b1.ROTET equals i.ROTET1
                             //join wrnt in db.WriteRuleNobrTable.Where(wp => wp.GUID == guid) on a.NOBR equals wrnt.EMPID
                             where DateE.CompareTo(b.ADATE) >= 0 && DateE.CompareTo(b.DDATE.Value) <= 0
                             && b.NOBR.CompareTo(p.NOBRB) >= 0 && b.NOBR.CompareTo(p.NOBRE) <= 0
                             && h.D_NO_DISP.CompareTo(p.DEPTB) >= 0 && h.D_NO_DISP.CompareTo(p.DEPTE) <= 0
                             && a.YYMM == p.YYMM
                             && !b.NOWAGE
                             && !year_restList.Contains(c.YEAR_REST)
                             && a.BDATE >= b1.ADATE && a.BDATE <= b1.DDATE.Value
                             //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(q => q.DATAGROUP).Contains(b.SALADR)
                             select new { ABS = a, BASETTS = b, HCODE = c, ATTEND = d, ROTE = f, StationAmt = st.AMT != null ? st.AMT.Value : 0, NightFoodOfDay = i.FOODAMT1 != null ? i.FOODAMT1.Value : 0, FOODSALCODE = i.FOODSALCODE != null ? i.FOODSALCODE : "" }).ToList();
            var sql1 = sql1_full.GroupBy(x => new { x.ABS.NOBR, x.ABS.BDATE, x.ROTE });

            string delete_cmd = "DELETE SALABS WHERE "
                + " EXISTS(SELECT * FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO"
                + " WHERE A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND SALABS.NOBR=A.NOBR )"
                + " AND YYMM={4} AND SAL_CODE IN ({5},{6})"
                //+ " AND dbo.GetFilterByNobr(SALABS.NOBR,{7},{8},{9})=1";
                + " AND exists(select 1 from BASETTS x where x.NOBR=SALABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({7},{8},{9})))";
            object[] PARMS = new object[] { p.NOBRB, p.NOBRE, p.DEPTB, p.DEPTE, p.YYMM, MainForm.SalaryConfig.EATSALCODE, MainForm.OvertimeConfig.OTFOODSALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            db.ExecuteCommand(delete_cmd, PARMS);
            var salcodeData = db.SALCODE.ToList();
            foreach (var gp in sql1)
            {
                foreach (var itm in gp)//每天可能多筆
                {
                    //decimal nightamt = itm.ROTE.NIGHTAMT;
                    decimal foodamt = itm.ATTEND.NIGAMT;
                    if (foodamt == 0) continue;//如果沒有金額就不用考慮扣款

                    //if (itm.ROTE.WK_HRS > 0 && itm.HCODE.EF_NIGHT)//如果會影響輪班津貼
                    //{
                    //    decimal discount = Math.Round(itm.ABS.TOL_HOURS / itm.ROTE.WK_HRS * nightamt, MidpointRounding.AwayFromZero);
                    //    if (itm.HCODE.UNIT == "天") discount = Math.Round(itm.ABS.TOL_HOURS * nightamt, MidpointRounding.AwayFromZero);
                    //    JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                    //    salabs.ADATE = itm.ATTEND.ADATE;
                    //    salabs.ADJ_CODE = "";
                    //    salabs.AMT = JBModule.Data.CEncrypt.Number(discount);
                    //    salabs.BTIME = itm.ABS.BTIME;
                    //    salabs.H_CODE = itm.ABS.H_CODE;
                    //    salabs.KEY_DATE = DateTime.Now;
                    //    salabs.KEY_MAN = MainForm.USER_NAME;
                    //    salabs.MLSSALCODE = MainForm.OvertimeConfig.OTFOODSALCODE;
                    //    salabs.NOBR = itm.ATTEND.NOBR;
                    //    salabs.SAL_CODE = MainForm.OvertimeConfig.OTFOODSALCODE;
                    //    salabs.SALSEQ = "";
                    //    salabs.YYMM = p.YYMM;

                    //    if (salabs.AMT != 10)
                    //        //salabsList.Add(salabs);
                    //        AddSalabs(salabs);
                    //}
                    if (itm.ROTE.WK_HRS > 0 && itm.HCODE.EF_NIGHT)//如果會影響輪班津貼
                    {
                        decimal discount = Math.Round(foodamt, MidpointRounding.AwayFromZero);
                        decimal wkHrs = itm.ROTE.WK_HRS - itm.ROTE.MO_HRS;
                        if (itm.HCODE.UNIT == "天") discount = Math.Round(itm.ABS.TOL_HOURS * foodamt, MidpointRounding.AwayFromZero);
                        else discount = Math.Round(itm.ABS.TOL_HOURS * foodamt / wkHrs, MidpointRounding.AwayFromZero);
                        JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                        salabs.ADATE = itm.ATTEND.ADATE;
                        salabs.ADJ_CODE = "";
                        salabs.AMT = JBModule.Data.CEncrypt.Number(discount);
                        salabs.BTIME = itm.ABS.BTIME;
                        salabs.H_CODE = itm.ABS.H_CODE;
                        salabs.KEY_DATE = DateTime.Now;
                        salabs.KEY_MAN = MainForm.USER_NAME;
                        salabs.MLSSALCODE = MainForm.OvertimeConfig.OTFOODSALCODE;
                        salabs.NOBR = itm.ATTEND.NOBR;
                        salabs.SAL_CODE = MainForm.OvertimeConfig.OTFOODSALCODE;
                        salabs.SALSEQ = "";
                        salabs.YYMM = p.YYMM;

                        if (salabs.AMT != 10)
                            //salabsList.Add(salabs);
                            AddSalabs(salabs);
                    }
                }


                foreach (var itm in gp)//每天可能多筆
                {
                    decimal specamt = itm.ROTE.SPECAMT;

                    if (specamt == 0) continue;//如果沒有金額就不用考慮扣款

                    if (itm.ROTE.WK_HRS > 0)//時薪所有假別都會影響
                    {
                        decimal discount = Math.Round(itm.ABS.TOL_HOURS / itm.ROTE.WK_HRS * specamt, MidpointRounding.AwayFromZero);
                        if (itm.HCODE.UNIT == "天") discount = Math.Round(itm.ABS.TOL_HOURS * specamt, MidpointRounding.AwayFromZero);
                        JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                        salabs.ADATE = itm.ATTEND.ADATE;
                        salabs.ADJ_CODE = "";
                        salabs.AMT = JBModule.Data.CEncrypt.Number(discount);
                        salabs.BTIME = itm.ABS.BTIME;
                        salabs.H_CODE = itm.ABS.H_CODE;
                        salabs.KEY_DATE = DateTime.Now;
                        salabs.KEY_MAN = MainForm.USER_NAME;
                        salabs.MLSSALCODE = MainForm.SalaryConfig.ONDUTYSALCODE;
                        salabs.NOBR = itm.ATTEND.NOBR;
                        salabs.SAL_CODE = MainForm.SalaryConfig.ONDUTYSALCODE;
                        salabs.SALSEQ = "";
                        salabs.YYMM = p.YYMM;

                        if (salabs.AMT != 10)
                            //salabsList.Add(salabs);
                            AddSalabs(salabs);
                    }
                }

                foreach (var itm in gp)//每天可能多筆
                {
                    decimal stationamt = itm.StationAmt;

                    if (stationamt == 0) continue;//如果沒有金額就不用考慮扣款

                    if (itm.ROTE.WK_HRS > 0 && itm.HCODE.STATION != null && itm.HCODE.STATION.Value)//時薪所有假別都會影響
                    {
                        decimal discount = Math.Round(itm.ABS.TOL_HOURS / itm.ROTE.WK_HRS * stationamt, MidpointRounding.AwayFromZero);
                        if (itm.HCODE.UNIT == "天") discount = Math.Round(itm.ABS.TOL_HOURS * stationamt, MidpointRounding.AwayFromZero);
                        JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                        salabs.ADATE = itm.ATTEND.ADATE;
                        salabs.ADJ_CODE = "";
                        salabs.AMT = JBModule.Data.CEncrypt.Number(discount);
                        salabs.BTIME = itm.ABS.BTIME;
                        salabs.H_CODE = itm.ABS.H_CODE;
                        salabs.KEY_DATE = DateTime.Now;
                        salabs.KEY_MAN = MainForm.USER_NAME;
                        salabs.MLSSALCODE = MainForm.SalaryConfig.EMPSALCODE;
                        salabs.NOBR = itm.ATTEND.NOBR;
                        salabs.SAL_CODE = MainForm.SalaryConfig.EMPSALCODE;
                        salabs.SALSEQ = "";
                        salabs.YYMM = p.YYMM;

                        if (salabs.AMT != 10)
                            //salabsList.Add(salabs);
                            AddSalabs(salabs);
                    }
                }

                foreach (var itm in gp.GroupBy(qq => qq.ATTEND.ADATE))//每天可能多筆(夜班伙食)
                {
                    decimal NightFoodOfDay = itm.First().NightFoodOfDay;

                    if (NightFoodOfDay == 0) continue;//如果沒有金額就不用考慮扣款

                    if (itm.First().ROTE.WK_HRS > 0)//所有假別都會影響
                    {
                        var salrow = salcodeData.Where(pp => pp.SAL_CODE == itm.First().FOODSALCODE);
                        if (salrow.Any())
                        {
                            decimal abs_hrs = itm.Sum(qq => qq.HCODE.UNIT == "天" ? qq.ABS.TOL_HOURS * qq.ROTE.WK_HRS : qq.ABS.TOL_HOURS);
                            if (itm.First().HCODE.UNIT == "天") abs_hrs = abs_hrs * itm.First().ROTE.WK_HRS;
                            if (salrow.First().HRS <= abs_hrs)
                            {
                                //decimal discount = Math.Round(itm.ABS.TOL_HOURS / itm.ROTE.WK_HRS * NightFoodOfDay, MidpointRounding.AwayFromZero);
                                //if (itm.HCODE.UNIT == "天") discount = Math.Round(itm.ABS.TOL_HOURS * NightFoodOfDay, MidpointRounding.AwayFromZero);
                                JBModule.Data.Linq.SALABS salabs = new JBModule.Data.Linq.SALABS();
                                salabs.ADATE = itm.Last().ATTEND.ADATE;//算到最後那筆身上
                                salabs.ADJ_CODE = "";
                                salabs.AMT = JBModule.Data.CEncrypt.Number(NightFoodOfDay);
                                salabs.BTIME = itm.Last().ABS.BTIME;
                                salabs.H_CODE = itm.Last().ABS.H_CODE;
                                salabs.KEY_DATE = DateTime.Now;
                                salabs.KEY_MAN = MainForm.USER_NAME;
                                salabs.MLSSALCODE = itm.Last().FOODSALCODE;
                                salabs.NOBR = itm.First().ATTEND.NOBR;
                                salabs.SAL_CODE = itm.Last().FOODSALCODE;
                                salabs.SALSEQ = "";
                                salabs.YYMM = p.YYMM;

                                if (salabs.AMT != 10)
                                    //salabsList.Add(salabs);
                                    AddSalabs(salabs);
                            }
                        }
                    }
                }
            }

            this.Report("計算請假扣款：寫入資料庫", 95);
            db.SALABS.InsertAllOnSubmit(salabsList);

            this.Report(100, Resources.Sal.StatusWriteToDB);
            db.SubmitChanges();
            //db1.SALABS.InsertAllOnSubmit(salabsList);
            //db1.SubmitChanges();
            d2 = DateTime.Now;
            ts = d2 - d1;
            this.Report(100, Resources.Sal.StatusFinish);
        }

        private decimal GetAmtByDay(List<JBModule.Data.Linq.SALBASD> salbasdList, List<JBModule.Data.Linq.SALCODE> salcodeList)
        {
            decimal amt = 0;
            foreach (var sal in salbasdList)
            {
                var salcode = salcodeList.SingleOrDefault(p => p.SAL_CODE.ToUpper().Trim() == sal.SAL_CODE.ToUpper().Trim());
                if (salcode != null)
                {
                    if (salcode.CAL_FREQ == "1")//月
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 30M;
                    else if (salcode.CAL_FREQ == "2")//日
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                    else if (salcode.CAL_FREQ == "21")//日(月曆天)
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                    else if (salcode.CAL_FREQ == "3")//時
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) * 8M;
                }
            }
            return amt;
        }
        private decimal GetAmtByDay1(List<WAGED> salbasdList, List<JBModule.Data.Linq.SALCODE> salcodeList)
        {
            decimal amt = 0;
            foreach (var sal in salbasdList)
            {
                var salcode = salcodeList.SingleOrDefault(p => p.SAL_CODE.ToUpper().Trim() == sal.SAL_CODE.ToUpper().Trim());
                if (salcode != null)
                {
                    if (salcode.CAL_FREQ == "1")//月
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 30M;
                    else if (salcode.CAL_FREQ == "2")//日
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                    else if (salcode.CAL_FREQ == "21")//日(月曆天)
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                    else if (salcode.CAL_FREQ == "3")//時
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) * 8M;
                }
            }
            return amt;
        }
        private decimal GetAmtByHour(List<JBModule.Data.Linq.SALBASD> salbasdList, List<JBModule.Data.Linq.SALCODE> salcodeList)
        {
            decimal amt = 0;
            foreach (var sal in salbasdList)
            {
                var salcode = salcodeList.SingleOrDefault(p => p.SAL_CODE.ToUpper().Trim() == sal.SAL_CODE.ToUpper().Trim());
                if (salcode != null)
                {
                    if (salcode.CAL_FREQ == "1")//月
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 240M;
                    else if (salcode.CAL_FREQ == "2")//日
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 8M;
                    else if (salcode.CAL_FREQ == "21")//日(月曆天)
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 8M;
                    else if (salcode.CAL_FREQ == "3")//時
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                }
            }
            return amt;
        }
        private decimal GetAmtByHour1(List<WAGED> salbasdList, List<JBModule.Data.Linq.SALCODE> salcodeList)
        {
            decimal amt = 0;
            foreach (var sal in salbasdList)
            {
                var salcode = salcodeList.SingleOrDefault(p => p.SAL_CODE.ToUpper().Trim() == sal.SAL_CODE.ToUpper().Trim());
                if (salcode != null)
                {
                    if (salcode.CAL_FREQ == "1")//月
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 240M;
                    else if (salcode.CAL_FREQ == "2")//日
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 8M;
                    else if (salcode.CAL_FREQ == "21")//日(月曆天)
                        amt += JBModule.Data.CDecryp.Number(sal.AMT) / 8M;
                    else if (salcode.CAL_FREQ == "3")//時
                        amt += JBModule.Data.CDecryp.Number(sal.AMT);
                }
            }
            return amt;
        }
        void Delete(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e, DateTime date_b, DateTime date_e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            SalaryDate sd = new SalaryDate(yymm);
            //string DeleteSystemCreateCmd = "DELETE ABS WHERE ABS.NOBR BETWEEN {0} AND {1} AND EXISTS(SELECT * FROM BASETTS A WHERE A.NOBR=ABS.NOBR AND {5} BETWEEN A.ADATE AND A.DDATE AND A.DEPT BETWEEN {2} AND {3}) AND SYSCREATE1=1 AND ABS.BDATE BETWEEN {4} AND {5}"
            //    + " AND dbo.GetFilterByNobr(SALABS.NOBR,{6},{7},{8})=1";
            //this.Report(100, "正在執行..刪除自動產生的請假資料");
            //int i = db.ExecuteCommand(DeleteSystemCreateCmd, new object[] { nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN });

            object[] parms = new object[] { nobr_b, nobr_e, dept_b, dept_e, yymm, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            int i = db.ExecuteCommand("DELETE SALABS "
                                   + " WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN A.ADATE AND A.DDATE "
                                   + " AND A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND A.NOBR=SALABS.NOBR)"
                                   //+ " AND dbo.GetFilterByNobr(SALABS.NOBR,{5},{6},{7})=1"
                                   + " AND exists(select 1 from BASETTS x where x.NOBR=SALABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({5},{6},{7})))"
                                   + " AND SALABS.YYMM={4}", parms);
        }
    }
    class param
    {
        public string YYMM;
        public string NOBRB, NOBRE;
        public string DEPTB, DEPTE;
        public DateTime DateB, DateE;
    }
}
