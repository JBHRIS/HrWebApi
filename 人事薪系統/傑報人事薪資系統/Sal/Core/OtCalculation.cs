using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHR.Sal;
using JBHR.Sal.Core.OvertTime;
namespace JBHR.Sal.Core
{
    public class OtCalculation : JBModule.Message.ReportStatus
    {
        TimeSpan ts;
        //int year;
        //int month;
        string yymm, nobr_b, nobr_e, dept_b, dept_e, seq;
        //DateTime DateB;
        //DateTime DateE;
        decimal NoTaxHours;
        public List<Sal.WAGED> WagedList = new List<WAGED>();
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        List<JBModule.Data.Linq.OTRATECD_ROTE> OTRATECD_ROTEList = new List<JBModule.Data.Linq.OTRATECD_ROTE>();
        public JBModule.Data.ApplicationConfigSettings acg = null;
        public Guid guid = Guid.Empty;
        public OtCalculation(string NobrB, string NobrE, string DeptB, string DeptE, string YYMM, string Seq)
        {
            nobr_b = NobrB;
            nobr_e = NobrE;
            dept_b = DeptB;
            dept_e = DeptE;
            yymm = YYMM;
            seq = Seq;
        }
        public bool Run()
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4B", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("AvgWorkDays", "平均月出勤天數", "22"
                , "設定輪班津貼、環境津貼、夜班伙食等，在計算加班費基礎時，以日給額乘上平均出勤天數作為加班基礎", "TextBox"
                , "", "String");
            acg = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
            bool DailyHrsMaxSW = acg.GetConfig("DailyHrsMaxSW").GetString("False") == "True" ? true : false;
            DateTime d1, d2;
            d1 = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //CodeMDDataContext cdc = new CodeMDDataContext();
            OTRATECD_ROTEList = db.OTRATECD_ROTE.ToList();
            object[] parms = new object[] { yymm, nobr_b, nobr_e, dept_b, dept_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            try
            {
                //將指定範圍內的資料歸零
                this.Report(Resources.Sal.StatusOfInit + ".", 0);
                db.ExecuteCommand("UPDATE OT SET NOT_EXP=0,TOT_EXP=0,REST_EXP=0,"
                                + " NOT_W_100=0,NOP_W_100=0, "
                                + " NOT_W_133=0,NOT_W_167=0,NOT_W_200=0,"
                                + " NOT_H_133=0,NOT_H_167=0,NOT_H_200=0,"
                                + " TOT_W_133=0,TOT_W_167=0,TOT_W_200=0,"
                                + " TOT_W_100=0,TOP_W_100=0 "
                                + " WHERE YYMM={0}"// AND NOTMODI=0"//如果設定為不可修改就略過計算
                                + " AND EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE OT.BDATE BETWEEN A.ADATE AND A.DDATE "
                                //+ " AND dbo.GetFilterByNobr(OT.NOBR,{5},{6},{7})=1"
                                + " AND exists(select 1 from BASETTS x where x.NOBR=OT.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({5},{6},{7})))"
                                + " AND A.NOBR BETWEEN {1} AND {2} AND B.D_NO_DISP BETWEEN {3} AND {4} AND A.NOBR=OT.NOBR)", parms);
                                //+ " AND NOBR IN "
                                //+ " (SELECT A.NOBR FROM BASETTS B,OT A WHERE A.NOBR BETWEEN {1} AND {2}"
                                //+ " AND B.DEPT BETWEEN {3} AND {4} "
                                //+ " AND A.NOBR=B.NOBR AND A.YYMM={0}"
                                //+ " AND A.BDATE BETWEEN B.ADATE AND B.DDATE GROUP BY A.NOBR)  "
            }
            catch (Exception ex)
            {
                //MessageBox.Show(Resources.Sal.errOtResetZero, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Report(Resources.Sal.errOtResetZero, 0);
                return false;
            }
            var otSQL = from a in db.OT
                            //join b in db.SALBASD on a.NOBR equals b.NOBR
                            //join c in db.SALCODE on b.SAL_CODE equals c.SAL_CODE
                        join d in db.BASETTS on a.NOBR equals d.NOBR
                        join e in db.DEPT on d.DEPT equals e.D_NO
                        //join x in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals x.NOBR
                        //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                        where
                        //c.OT && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE && !a.NOTMODI
                        //&& c.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE//不含全勤
                        (d.NOBR.CompareTo(nobr_b) >= 0) && (d.NOBR.CompareTo(nobr_e) <= 0)
                        && (e.D_NO_DISP.CompareTo(dept_b) >= 0) && (e.D_NO_DISP.CompareTo(dept_e) <= 0)
                        && a.BDATE >= d.ADATE && a.BDATE <= d.DDATE.Value
                        //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                        && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                        select a;
            SalaryDate sd = new SalaryDate(yymm);
            var salbasdSQL = from a in db.SALBASD
                             join b in db.SALCODE on a.SAL_CODE equals b.SAL_CODE
                             join d in db.BASETTS on a.NOBR equals d.NOBR
                             join e in db.DEPT on d.DEPT equals e.D_NO
                             //join x in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals x.NOBR
                             //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                             where b.OT //&& b.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE//不含全勤 
                                 && (d.NOBR.CompareTo(nobr_b) >= 0) && (d.NOBR.CompareTo(nobr_e) <= 0)
                             && (e.D_NO_DISP.CompareTo(dept_b) >= 0) && (e.D_NO_DISP.CompareTo(dept_e) <= 0)
                             && sd.LastDayOfSalary >= d.ADATE && sd.LastDayOfSalary <= d.DDATE.Value
                             && !b.SALBASD1
                             //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                             select new { a.NOBR, a.SAL_CODE, a.ADATE, a.DDATE, a.AMT };
            var salbasdList = salbasdSQL.Select(p => new { p.NOBR, p.SAL_CODE, p.ADATE, p.DDATE, AMT = JBModule.Data.CDecryp.Number(p.AMT) }).ToList();
            //pc.Write("      以及當天的出勤資料、有無設定其他加班比率(特殊假日)、班別資料、加班原因等相關聯的資料");
            var RV_OT = (from a in otSQL
                         join c in db.BASE on a.NOBR equals c.NOBR
                         join b in db.BASETTS on a.NOBR equals b.NOBR
                         join dept in db.DEPT on b.DEPT equals dept.D_NO
                         join f in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { f.NOBR, f.ADATE.Date }
                         join d in db.ROTE on f.ROTE equals d.ROTE1//取出勤的班別
                         join g in db.HOL_DAY on new { b.HOLI_CODE, a.BDATE.Date, ROTE = a.OT_ROTE } equals new { g.HOLI_CODE, g.ADATE.Date, g.ROTE } into ag
                         from hd in ag.DefaultIfEmpty()
                         join h in db.ROTET on b.ROTET equals h.ROTET1
                         where a.BDATE >= b.ADATE && a.BDATE <= b.DDATE
                             && a.YYMM == yymm
                         //&& a.SYSCREAT//系統計算
                         orderby a.NOBR, a.BDATE, a.BTIME
                         select new
                         {
                             ot = a,
                             c.SEX,
                             c.COUNT_MA,
                             TOT_HOURS1 = a.OT_HRS,
                             b.HOLI_CODE,
                             b.SALADR,
                             b.SALTP,
                             OT_ROTE = (a.OT_ROTE == null || a.OT_ROTE.Trim().Length == 0) ? f.ROTE : a.OT_ROTE,//避免加班班別沒填
                             //ROTE = d,
                             AttRote = f.ROTE,//出勤班別用來判斷當天是不是
                             WKHrs = d.WK_HRS,
                             //OTRATE_CODE = hd.OTRATECD != null ? hd.OTRATECD : a.Key.OTRATE_CODE,
                             SYS_OT = a.SYS_OT,
                             NOFOOD = a.NOFOOD,
                             DefaultOtrateCode = b.CALOT,
                             HolDayOtrateCode = hd != null ? hd.OTRATECD : "",
                             NIGHTAMT = h.NIGHTAMT != null ? h.NIGHTAMT.Value : 0
                         }).ToList();
            SalaryDate previousSalaryDate = sd.GetPrevSalaryDate();
            var RV_OT1 = (from a in db.OT
                          join c in db.BASE on a.NOBR equals c.NOBR
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join dept in db.DEPT on b.DEPT equals dept.D_NO
                          join f in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { f.NOBR, f.ADATE.Date }
                          where a.BDATE >= b.ADATE && a.BDATE <= b.DDATE
                              && a.YYMM == previousSalaryDate.YYMM
                          && (b.NOBR.CompareTo(nobr_b) >= 0) && (b.NOBR.CompareTo(nobr_e) <= 0)
                          && (dept.D_NO_DISP.CompareTo(dept_b) >= 0) && (dept.D_NO_DISP.CompareTo(dept_e) <= 0)
                          && (from ot in db.OT where ot.NOBR == a.NOBR && ot.BDATE == a.BDATE && ot.YYMM == yymm select 1).Any()
                          orderby a.NOBR, a.BDATE, a.BTIME
                          select new { a.NOBR, a.BDATE, a.OT_HRS }
                         ).ToList();
            var SalcodeList = db.SALCODE.ToList();
            var salbasd1List = (from a in WagedList
                                join b in SalcodeList on a.SAL_CODE equals b.SAL_CODE
                                where a.YYMM == yymm && a.SEQ == seq
                                && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                                && b.SALBASD1 && b.OT
                                select new { SALBASD1 = a, SALCODE = b }).ToList();

            //Sal.Core.SalaryDate sd = new SalaryDate(yymm);
            var roteBonus = (from a in db.BASETTS
                             join b in db.ROTET on a.ROTET equals b.ROTET1
                             join c in db.STATION on a.STATION equals c.Code
                             join d in db.ROTE on b.R1 equals d.ROTE1
                             join f in db.DEPT on a.DEPT equals f.D_NO
                             //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                             //where db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             where a.ADATE <= sd.LastDayOfAttend && a.DDATE.Value >= sd.FirstDayOfAttend
                             && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && f.D_NO_DISP.CompareTo(dept_b) >= 0 && f.D_NO_DISP.CompareTo(dept_e) <= 0
                             && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                             select new
                             {
                                 a.NOBR,
                                 a.ADATE,
                                 a.DDATE,
                                 a.ROTET,
                                 d.ROTE1,
                                 a.STATION,
                                 NIGHTAMT = b.NIGHTAMT != null ? b.NIGHTAMT.Value : 0,
                                 FOODAMT = b.FOODAMT != null ? b.FOODAMT.Value : 0,
                                 StationAmt = c.AMT != null ? c.AMT.Value : 0,
                                 NightAmtOfRote = d.NIGHTAMT
                             }).ToList();

            var GP_OT = from o in RV_OT group o by o.ot.NOBR into gp orderby gp.Key select gp;

            var roteList = (from a in db.ROTE select a).ToList();
            var roteHoliList = (from a in roteList where a.ON_TIME.Trim().Length == 0 && a.OFF_TIME.Trim().Length == 0 && a.WK_HRS == 0 select a.ROTE1).ToList();
            var RoteBonusList = (from a in db.ROTE_BONUS select a).ToList();

            string tmpNobr = "";
            //List<JBModule.Data.Linq.SALBASD> dtSalbasd = null;
            OverTime overtime = null;
            OTRATECD otrcd = null;
            DateTime tmpDate = new DateTime(9999, 12, 31);
            decimal TodayOtHrs = 0;
            decimal total_count = GP_OT.Count();
            decimal current_count = 0;
            //var RangeSetSQL = (from a in smd.RANGE_SET where a.PID == 0 select a).ToList();
            foreach (var gp in GP_OT)
            {
                current_count++;
                tmpNobr = gp.Key;
                TodayOtHrs = 0;
                tmpDate = new DateTime(9999, 12, 31);

                overtime = new OverTime(tmpNobr);
                overtime.OTRATECD_ROTEList = OTRATECD_ROTEList;
                int percentage = Convert.ToInt32(current_count / total_count * 100);
                //BW.ReportProgress(percentage, Resources.Sal.StatusComputing + gp.Key.ToString());
                this.Report("加班費計算：" + Resources.Sal.StatusComputing + gp.Key.ToString(), percentage);
                NoTaxHours = overtime.NoTaxHours;
                var dt1 = from a in salbasd1List
                          where a.SALBASD1.NOBR == gp.Key
                          && a.SALBASD1.YYMM == yymm
                          && a.SALCODE.OT//只抓影響加班的變動薪資
                          //&& !dtSalbasd.Select(p => p.SAL_CODE).Contains(a.SALBASD1.SAL_CODE)20130130改為排除變動薪資有的部分
                          select a;//取加班時間的有效薪資科目(未解密)   
                decimal monthDays = 30;//推算時將基底整平對使用者來說較直觀//Convert.ToInt32((sd.LastDayOfSalary - sd.FirstDayOfSalary).TotalDays) + 1;
                decimal amt1 = dt1.Sum(p => JBModule.Data.CDecryp.Number(p.SALBASD1.AMT) * (p.SALCODE.CAL_FREQ.Trim() == "3" ? 240M : p.SALCODE.CAL_FREQ.Trim() == "2" ? 30M : p.SALCODE.CAL_FREQ.Trim() == "21" ? monthDays : 1M));
                decimal amt1_Hrs = dt1.Sum(p => JBModule.Data.CDecryp.Number(p.SALBASD1.AMT) / (p.SALCODE.CAL_FREQ.Trim() == "3" ? 1M : p.SALCODE.CAL_FREQ.Trim() == "2" ? 8M : p.SALCODE.CAL_FREQ.Trim() == "21" ? 8M : 240M));
                decimal DayBonus = 0, DayOtHrs = 0;//20120627 統計每天累積的時數跟餐費
                DateTime ChkDate = new DateTime(9999, 12, 31);

                JBTools.Intersection itsMon = new JBTools.Intersection();
                itsMon.Inert(sd.FirstDayOfAttend, sd.LastDayOfAttend);
                int MonthDays = itsMon.GetDays();
                var roteBonusOfNobr = from a in roteBonus where a.NOBR == gp.Key select a;
                decimal RoteMonthAmt = 0, RoteDayAmt = 0, StationAmt = 0, FoodAmt = 0;
                decimal NoTaxHoursOfWDay = 0;
                foreach (var rBonus in roteBonusOfNobr)
                {
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(sd.FirstDayOfAttend, sd.LastDayOfAttend);
                    its.Inert(rBonus.ADATE, rBonus.DDATE.Value);
                    int Days = its.GetDays();
                    decimal roteMonthyAmt = Convert.ToDecimal(rBonus.NIGHTAMT * Days) / Convert.ToDecimal(MonthDays);
                    RoteMonthAmt += roteMonthyAmt;

                    decimal roteDayAmt = Convert.ToDecimal(rBonus.NightAmtOfRote * Days) / Convert.ToDecimal(MonthDays);
                    RoteDayAmt += roteDayAmt;

                    decimal stationAmt = Convert.ToDecimal(rBonus.StationAmt * Days) / Convert.ToDecimal(MonthDays);
                    StationAmt += stationAmt;

                    decimal foodAmt = Convert.ToDecimal(rBonus.FOODAMT * Days) / Convert.ToDecimal(MonthDays);
                    FoodAmt += foodAmt;
                }
                decimal RoteBonusAmt = Math.Round(RoteMonthAmt, MidpointRounding.AwayFromZero)
                    + Math.Round((RoteDayAmt * AppConfig.GetConfig("AvgWorkDays").GetDecimal()), MidpointRounding.AwayFromZero)
                    + Math.Round((StationAmt * AppConfig.GetConfig("AvgWorkDays").GetDecimal()), MidpointRounding.AwayFromZero)
                    + Math.Round(FoodAmt, MidpointRounding.AwayFromZero);
                foreach (var r in gp)
                {
                    var OTRATE_CODE = r.DefaultOtrateCode;//沒有指定的情況下，使用異動資料中設定
                    if (!r.COUNT_MA && r.HolDayOtrateCode.Trim().Length > 0)//如果有設定其他加班比率
                        OTRATE_CODE = r.HolDayOtrateCode.Trim();
                    if (r.ot.OTRATE_CODE.Trim().Length > 0)//如果加班資料上面有指定
                        OTRATE_CODE = r.ot.OTRATE_CODE.Trim();
                    otrcd = SalaryVar.GetOtRateCode(OTRATE_CODE);//取得加班比率設定
                    OtTaxRate otr = new OtTaxRate(r.AttRote, r.ot.SYS_OT || r.SYS_OT || r.DefaultOtrateCode != OTRATE_CODE, DailyHrsMaxSW);
                    if (tmpDate != r.ot.BDATE)
                    {
                        otr.DailyMaxHrs = new string[] { "00", "0X", "0Z" }.Contains(r.AttRote) ? otr.DailyMaxHrs : otr.DailyMaxHrs - r.WKHrs;
                        tmpDate = r.ot.BDATE;
                        var Ottemp = RV_OT1.Where(p => p.NOBR == tmpNobr && p.BDATE == tmpDate);
                        TodayOtHrs = Ottemp.Any() ? Ottemp.Sum(p => p.OT_HRS) : 0;//0;//不同天，就歸零(以依照日期排序)    
                        NoTaxHoursOfWDay = otr.DailyMaxHrs <= 0 ? 0 : otr.DailyMaxHrs - TodayOtHrs > 0 ? otr.DailyMaxHrs - TodayOtHrs : 0;
                    }
                    otr.DailyMaxHrs = NoTaxHoursOfWDay;
                    //拆比率
                    overtime.SetOtRate(r.ot, otrcd, TodayOtHrs, r.AttRote, r.SYS_OT);
                    TodayOtHrs += r.ot.REST_HRS;
                    TodayOtHrs += r.ot.OT_HRS;

                    JBModule.Data.Linq.OT ot = r.ot;
                    //拆應免稅
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.WOT_133);
                    ot.NOT_W_133 += otr.Not_Hours;
                    ot.TOT_W_133 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.WOT_166);
                    ot.NOT_W_167 += otr.Not_Hours;
                    ot.TOT_W_167 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.WOT_200);
                    ot.NOT_W_200 += otr.Not_Hours;
                    ot.TOT_W_200 += otr.Tot_Hours;

                    /////////////////////////
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.HOT_133);
                    ot.NOT_H_133 += otr.Not_Hours;
                    ot.TOT_W_133 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.HOT_166);
                    ot.NOT_H_167 += otr.Not_Hours;
                    ot.TOT_W_167 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, ot.HOT_200);
                    ot.NOT_H_200 += otr.Not_Hours;
                    ot.TOT_W_200 += otr.Tot_Hours;
                    //ot.NOP_H_133 = otrcd.OT133HRATE;
                    //ot.NOP_H_167 = otrcd.OT167HRATE;
                    //ot.NOP_H_200 = otrcd.OT200HRATE;
                    //ot.NOP_W_133 = otrcd.OT133WRATE;
                    //ot.NOP_W_167 = otrcd.OT167WRATE;
                    //ot.NOP_W_200 = otrcd.OT200WRATE;
                    //}
                    NoTaxHoursOfWDay = otr.DailyMaxHrs;
                    if (ChkDate != r.ot.BDATE)//每天重計
                    {
                        DayBonus = 0;
                        DayOtHrs = 0;
                        ChkDate = r.ot.BDATE;
                    }
                    var dtSalbasd = salbasdList.Where(p => p.NOBR == r.ot.NOBR && r.ot.BDATE >= p.ADATE && r.ot.BDATE <= p.DDATE).ToList();
                    var dt = from a in dtSalbasd
                             where r.ot.BDATE >= a.ADATE
                             && r.ot.BDATE <= a.DDATE
                             select a;//取加班時間的有效薪資科目(未解密)   
                    var dts = from a in dt
                              join b in SalcodeList on a.SAL_CODE equals b.SAL_CODE
                              where !b.SALBASD1//未勾選才抓薪資結構
                              select new { a.NOBR, a.SAL_CODE, b.CAL_FREQ, a.AMT };

                    decimal amt = dts.Sum(p => p.AMT * (p.CAL_FREQ.Trim() == "3" ? 240M : p.CAL_FREQ.Trim() == "2" ? 30M : p.CAL_FREQ.Trim() == "21" ? monthDays : 1M));//排除變動薪資要算的
                    decimal amt_Hrs = dts.Sum(p => p.AMT / (p.CAL_FREQ.Trim() == "3" ? 1M : p.CAL_FREQ.Trim() == "2" ? 8M : p.CAL_FREQ.Trim() == "21" ? 8M : 240M));//排除變動薪資要算的
                    decimal amtOfHrs = amt_Hrs + amt1_Hrs + RoteBonusAmt / 240;//時薪
                    //decimal TotalAmt = dt.Sum(p => p.AMT);
                    r.ot.SALARY = JBModule.Data.CEncrypt.Number(amt + amt1 + RoteBonusAmt);

                    decimal not_exp = Math.Round(((r.ot.NOT_H_133 * r.ot.NOP_H_133)
                                    + (r.ot.NOT_H_167 * r.ot.NOP_H_167)
                                    + (r.ot.NOT_H_200 * r.ot.NOP_H_200)
                                    + (r.ot.NOT_W_133 * r.ot.NOP_W_133)
                                    + (r.ot.NOT_W_167 * r.ot.NOP_W_167)
                                    + (r.ot.NOT_W_200 * r.ot.NOP_W_200))
                                    * amtOfHrs, MidpointRounding.AwayFromZero);

                    decimal tot_exp = Math.Round(((r.ot.TOT_W_133 * r.ot.NOP_W_133) + (r.ot.TOT_W_167 * r.ot.NOP_W_167) + (r.ot.TOT_W_200 * r.ot.NOP_W_200)) * amtOfHrs, MidpointRounding.AwayFromZero);
                    string exp_type = "1";
                    if (r.AttRote.Trim().ToUpper() == "0Z")
                        exp_type = otrcd.OTRATE_TYPEH;
                    else if (r.AttRote.Trim().ToUpper() == "0X")
                        exp_type = otrcd.OTRATE_TYPER;
                    else if (r.AttRote.Trim().ToUpper() == "00")
                        exp_type = otrcd.OTRATE_TYPEN;
                    else exp_type = otrcd.OTRATE_TYPEW;

                    if (exp_type == "2")
                    {
                        //由比率判斷決定跑不跑定額
                        not_exp = Math.Round(((r.ot.NOT_H_133 * r.ot.NOP_H_133)
                                    + (r.ot.NOT_H_167 * r.ot.NOP_H_167)
                                    + (r.ot.NOT_H_200 * r.ot.NOP_H_200)
                                    + (r.ot.NOT_W_133 * r.ot.NOP_W_133)
                                    + (r.ot.NOT_W_167 * r.ot.NOP_W_167)
                                    + (r.ot.NOT_W_200 * r.ot.NOP_W_200))
                                    , 0);
                        tot_exp = Math.Round(((r.ot.TOT_W_133 * r.ot.NOP_W_133)
                            + (r.ot.TOT_W_167 * r.ot.NOP_W_167)
                            + (r.ot.TOT_W_200 * r.ot.NOP_W_200)), 0);
                    }

                    r.ot.NOT_EXP = JBModule.Data.CEncrypt.Number(not_exp);
                    r.ot.TOT_EXP = JBModule.Data.CEncrypt.Number(tot_exp);

                    //if (r.EtchingAmt > 0)//因為要判斷整天工時(含加班扣請假)，統一在薪資計算中計算
                    //{
                    //    decimal EtchingHrs = r.ot.TOT_HOURS / 4;
                    //    r.ot.SPECAMT = EtchingHrs * r.EtchingAmt;
                    //}
                    //else r.ot.SPECAMT = 0;
                    string ot_rote = "";
                    ot_rote = r.AttRote;
                    if (roteHoliList.Contains(r.AttRote))
                        ot_rote = r.OT_ROTE;//如果遇到假日加班，就參考加班班別

                    if (roteHoliList.Contains(r.OT_ROTE))//如果是加班班別未輸入且出勤班別為假日，就往前找最近的一個非假日的出勤班別
                    {
                        var att = from a in db.ATTEND
                                  where a.NOBR == r.ot.NOBR && a.ADATE <= r.ot.BDATE
                                  && !roteHoliList.Contains(a.ROTE)
                                  orderby a.ADATE
                                  descending
                                  select a.ROTE;
                        if (att.Any())
                            ot_rote = att.First();//取得加班日以前的第一筆非假日班別
                        else
                        {
                            att = from a in db.ATTEND
                                  where a.NOBR == r.ot.NOBR && a.ADATE >= r.ot.BDATE
                                  && !roteHoliList.Contains(a.ROTE)
                                  orderby a.ADATE
                                  descending
                                  select a.ROTE;
                            if (att.Any())
                                ot_rote = att.First();//取得加班日以後的第一筆非假日班別
                        }
                    }

                    r.ot.OT_FOOD = 10;//預先清空
                    r.ot.OT_FOOD1 = 0;//預先清空

                    r.ot.OT_CAR = 10;
                }
            }
            try
            {
                //BW.ReportProgress(100, Resources.Sal.StatusWriteToDB);
                this.Report(Resources.Sal.StatusWriteToDB, 100);
                db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                {
                    // *********************************************
                    // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                    // **********************************************

                    // 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                    //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                    // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                    //occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                }

                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                db.SubmitChanges();
            }
            d2 = DateTime.Now;
            ts = d2 - d1;
            //BW.ReportProgress(100, Resources.Sal.StatusFinish);
            this.Report(Resources.Sal.StatusFinish, 100);
            return true;
        }
    }
}
