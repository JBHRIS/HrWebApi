using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHR.Sal;
using JBHR.Sal.Core.OvertTime;
namespace JBHR.Sal.Core
{
    public class OtCalculation_B : JBModule.Message.ReportStatus
    {
        TimeSpan ts;
        //int year;
        //int month;
        string yymm, nobr_b, nobr_e, dept_b, dept_e, seq;
        //DateTime DateB;
        //DateTime DateE;
        decimal NoTaxHours;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        public List<JBModule.Data.Linq.OT_B> OtData = new List<JBModule.Data.Linq.OT_B>();
        public List<JBModule.Data.Linq.WAGED_B> WagedList = new List<JBModule.Data.Linq.WAGED_B>();
        public OtCalculation_B(string NobrB, string NobrE, string DeptB, string DeptE, string YYMM, string Seq)
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
            AppConfig.CheckParameterAndSetDefault("OtBonusSalode", "加班津貼代碼", "", "指定加班津貼代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("OtNoTaxAwardSalode", "免稅加班獎勵代碼", "", "指定免稅加班獎勵代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("OtTaxAwardSalode", "應稅加班獎勵代碼", "", "指定應稅加班獎勵代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            DateTime d1, d2;
            d1 = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //CodeMDDataContext cdc = new CodeMDDataContext();

            object[] parms = new object[] { yymm, nobr_b, nobr_e, dept_b, dept_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            if (OtData.Count == 0) return true;
            SalaryDate sd = new SalaryDate(this.yymm);
            var BeginDate = OtData.Min(p => p.BDATE);
            var EndDate = OtData.Max(p => p.BDATE);
            var salbasdSQL = (from a in db.SALBASD
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               //join c in db.HOLI on b.HOLI_CODE equals c.HOLI_CODE
                               join d in db.DEPT on b.DEPT equals d.D_NO
                               join e in db.SALCODE on a.SAL_CODE equals e.SAL_CODE
                               where (b.NOBR.CompareTo(nobr_b) >= 0) && (b.NOBR.CompareTo(nobr_e) <= 0)
                               && (d.D_NO_DISP.CompareTo(dept_b) >= 0) && (d.D_NO_DISP.CompareTo(dept_e) <= 0)
                               && b.SALTP != "2"//時薪人員不計
                               && e.OT
                               && sd.LastDayOfMonth >= b.ADATE && sd.LastDayOfMonth <= b.DDATE.Value
                               && a.ADATE <= EndDate && a.DDATE >= BeginDate
                               && !e.ImportSEQ2
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.ADATE, a.DDATE, a.AMT, a.SAL_CODE }).ToList();
            var salbasdList = salbasdSQL.Select(p => new { p.NOBR, p.SAL_CODE, p.ADATE, p.DDATE, AMT = JBModule.Data.CDecryp.Number(p.AMT) }).ToList();
            var AttendList = (from a in db.ATTEND
                              join c in db.BASE on a.NOBR equals c.NOBR
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              join d in db.DEPT on b.DEPT equals d.D_NO
                              where (b.NOBR.CompareTo(nobr_b) >= 0) && (b.NOBR.CompareTo(nobr_e) <= 0)
                              && (d.D_NO_DISP.CompareTo(dept_b) >= 0) && (d.D_NO_DISP.CompareTo(dept_e) <= 0)
                              //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                              && sd.LastDayOfMonth >= b.ADATE && sd.LastDayOfMonth <= b.DDATE.Value
                              && a.ADATE >= BeginDate && a.ADATE <= EndDate
                              select new { a.NOBR, a.ADATE, a.ROTE, c.COUNT_MA, btsADATE = b.ADATE, btsDDATE = b.DDATE, b.HOLI_CODE, b.SALADR, b.SALTP, b.CALOT, b.ROTET }).ToList();

            var SalCodeList = db.SALCODE.ToList();
            var salbasd1List = (from a in WagedList
                                join b in SalCodeList on a.SAL_CODE equals b.SAL_CODE
                                where a.YYMM == yymm && a.SEQ == seq
                                && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                                && b.SALBASD1 && b.OT
                                select new { SALBASD1 = a, SALCODE = b }).ToList();

            //var roteBonus = (from a in db.BASETTS
            //                 join b in db.ROTET on a.ROTET equals b.ROTET1
            //                 join c in db.STATION on a.STATION equals c.Code into ac
            //                 from station in ac.DefaultIfEmpty()
            //                 join d in db.ROTE on b.R1 equals d.ROTE1
            //                 join f in db.DEPT on a.DEPT equals f.D_NO
            //                 where db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //                 && a.ADATE <= sd.LastDayOfAttend && a.DDATE.Value >= sd.FirstDayOfAttend
            //                  && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
            //                 && f.D_NO_DISP.CompareTo(dept_b) >= 0 && f.D_NO_DISP.CompareTo(dept_e) <= 0
            //                 select new
            //                 {
            //                     a.NOBR,
            //                     a.ADATE,
            //                     a.DDATE,
            //                     a.ROTET,
            //                     d.ROTE1,
            //                     a.STATION,
            //                     NIGHTAMT = b.NIGHTAMT != null ? b.NIGHTAMT.Value : 0,
            //                     FOODAMT = b.FOODAMT != null ? b.FOODAMT.Value : 0,
            //                     StationAmt = station != null ? (station.AMT != null ? station.AMT.Value : 0) : 0,//20160427暫時取消
            //                     NightAmtOfRote = d.NIGHTAMT
            //                 }).ToList();

            var ROTEList = db.ROTE.ToList();
            var HOL_DAYList = db.HOL_DAY.ToList();
            var ROTETList = db.ROTET.ToList();
            var RV_OT = (from a in OtData
                         join f in AttendList on new { a.NOBR, a.BDATE.Date } equals new { f.NOBR, f.ADATE.Date }
                         //join c in db.BASE on a.NOBR equals c.NOBR
                         //join b in db.BASETTS on a.NOBR equals b.NOBR
                         //join dept in db.DEPT on b.DEPT equals dept.D_NO
                         //join f in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { f.NOBR, f.ADATE.Date }
                         join d in ROTEList on f.ROTE equals d.ROTE1//取出勤的班別
                         join g in HOL_DAYList on new { f.HOLI_CODE, a.BDATE.Date, ROTE = a.OT_ROTE } equals new { g.HOLI_CODE, g.ADATE.Date, g.ROTE } into ag
                         from hd in ag.DefaultIfEmpty()
                         join h in ROTETList on f.ROTET equals h.ROTET1
                         where a.BDATE >= f.btsADATE && a.BDATE <= f.btsDDATE
                             && a.YYMM == yymm
                         //&& a.SYSCREAT//系統計算
                         orderby a.NOBR, a.BDATE, a.BTIME
                         select new
                         {
                             ot = a,
                             //c.SEX,
                             f.COUNT_MA,
                             TOT_HOURS1 = a.OT_HRS,
                             f.HOLI_CODE,
                             f.SALADR,
                             f.SALTP,
                             OT_ROTE = (a.OT_ROTE == null || a.OT_ROTE.Trim().Length == 0) ? f.ROTE : a.OT_ROTE,//避免加班班別沒填
                             //ROTE = d,
                             AttRote = f.ROTE,//出勤班別用來判斷當天是不是
                             //OTRATE_CODE = hd.OTRATECD != null ? hd.OTRATECD : a.Key.OTRATE_CODE,
                             SYS_OT = a.SYS_OT,
                             NOFOOD = a.NOFOOD,
                             DefaultOtrateCode = f.CALOT,
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
            //var GP_OT = from o in OtData group o by o.NOBR into gp orderby gp.Key select gp;
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
            //var stationList = db.STATION.Select(pp => new { pp.Code, pp.AMT }).ToList();
            //var RangeSetSQL = (from a in smd.RANGE_SET where a.PID == 0 select a).ToList();
            foreach (var gp in GP_OT)
            {
                current_count++;
                tmpNobr = gp.Key;
                TodayOtHrs = 0;
                tmpDate = new DateTime(9999, 12, 31);


                overtime = new OverTime(tmpNobr);
                int percentage = Convert.ToInt32(current_count / total_count * 100);
                //BW.ReportProgress(percentage, Resources.Sal.StatusComputing + gp.Key.ToString());
                this.Report("加班費計算：" + Resources.Sal.StatusComputing + gp.Key.ToString(), percentage);
                NoTaxHours = overtime.NoTaxHours;

                var SalbasdListOfNobr = salbasdList.Where(p => p.NOBR == gp.Key);
                var attendListOfNobr = AttendList.Where(p => p.NOBR == gp.Key);
                foreach (var r in gp)
                {
                    r.ot.NOT_H_133 = 0;
                    r.ot.NOP_H_133 = 0;
                    r.ot.NOT_H_167 = 0;
                    r.ot.NOP_H_167 = 0;
                    r.ot.NOT_H_200 = 0;
                    r.ot.NOP_H_200 = 0;
                    r.ot.NOT_W_133 = 0;
                    r.ot.NOP_W_133 = 0;
                    r.ot.NOT_W_167 = 0;
                    r.ot.NOP_W_167 = 0;
                    r.ot.NOT_W_200 = 0;
                    r.ot.NOP_W_200 = 0;

                    r.ot.TOT_W_133 = 0;
                    r.ot.NOP_W_133 = 0;
                    r.ot.TOT_W_167 = 0;
                    r.ot.NOP_W_167 = 0;
                    r.ot.TOT_W_200 = 0;
                    r.ot.NOP_W_200 = 0;

                    var dtSalbasd = SalbasdListOfNobr.ToList(); 
                    var attendOfNobrDate = attendListOfNobr.SingleOrDefault(p => p.ADATE == r.ot.BDATE);

                    var OTRATE_CODE = r.DefaultOtrateCode;//沒有指定的情況下，使用異動資料中設定
                    if (!r.COUNT_MA && r.HolDayOtrateCode.Trim().Length > 0)//如果有設定其他加班比率
                        OTRATE_CODE = r.HolDayOtrateCode.Trim();
                    if (r.ot.OTRATE_CODE.Trim().Length > 0)//如果加班資料上面有指定
                        OTRATE_CODE = r.ot.OTRATE_CODE.Trim();
                    otrcd = SalaryVar.GetOtRateCode(OTRATE_CODE);//取得加班比率設定
                    //otrcd = SalaryVar.GetOtRateCode(r.OTRATE_CODE);//取得加班比率設定

                    if (tmpDate != r.ot.BDATE)
                    {
                        tmpDate = r.ot.BDATE;
                        var Ottemp = RV_OT1.Where(p => p.NOBR == tmpNobr && p.BDATE == tmpDate);
                        TodayOtHrs = Ottemp.Any() ? Ottemp.Sum(p => p.OT_HRS) : 0;//0;//不同天，就歸零(以依照日期排序)   
                    }
                    overtime.SetOtRate(r.ot, otrcd, TodayOtHrs, attendOfNobrDate.ROTE, r.SYS_OT);
                    TodayOtHrs += r.ot.OT_HRS;

                }
                foreach (var r in gp)//先拆應免稅時間(優先將1.66算到免稅)
                {
                    JBModule.Data.Linq.OT_B OT_B = r.ot;

                    //otrcd = GetOtRateCode(r);//取得加班比率設定
                    var attendOfNobrDate = attendListOfNobr.SingleOrDefault(p => p.ADATE == r.ot.BDATE);
                    //拆應免稅
                    OtTaxRate otr = new OtTaxRate(attendOfNobrDate.ROTE, r.SYS_OT || r.SYS_OT);
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.WOT_133);
                    OT_B.NOT_W_133 += otr.Not_Hours;
                    OT_B.TOT_W_133 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.WOT_166);
                    OT_B.NOT_W_167 += otr.Not_Hours;
                    OT_B.TOT_W_167 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.WOT_200);
                    OT_B.NOT_W_200 += otr.Not_Hours;
                    OT_B.TOT_W_200 += otr.Tot_Hours;

                    /////////////////////////
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.HOT_133);
                    OT_B.NOT_H_133 += otr.Not_Hours;
                    OT_B.TOT_W_133 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.HOT_166);
                    OT_B.NOT_H_167 += otr.Not_Hours;
                    OT_B.TOT_W_167 += otr.Tot_Hours;
                    this.NoTaxHours = otr.SetOtTax(this.NoTaxHours, OT_B.HOT_200);
                    OT_B.NOT_H_200 += otr.Not_Hours;
                    OT_B.TOT_W_200 += otr.Tot_Hours;
                }

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
                //var roteBonusOfNobr = from a in roteBonus where a.NOBR == gp.Key select a;
                decimal RoteMonthAmt = 0, RoteDayAmt = 0, StationAmt = 0, FoodAmt = 0;
                //foreach (var rBonus in roteBonusOfNobr)
                //{
                //    JBTools.Intersection its = new JBTools.Intersection();
                //    its.Inert(sd.FirstDayOfAttend, sd.LastDayOfAttend);
                //    its.Inert(rBonus.ADATE, rBonus.DDATE.Value);
                //    int Days = its.GetDays();
                //    decimal roteMonthyAmt = Convert.ToDecimal(rBonus.NIGHTAMT * Days) / Convert.ToDecimal(MonthDays);
                //    RoteMonthAmt += roteMonthyAmt;

                //    decimal roteDayAmt = Convert.ToDecimal(rBonus.NightAmtOfRote * Days) / Convert.ToDecimal(MonthDays);
                //    RoteDayAmt += roteDayAmt;

                //    decimal stationAmt = Convert.ToDecimal(rBonus.StationAmt * Days) / Convert.ToDecimal(MonthDays);
                //    StationAmt += stationAmt;

                //    decimal foodAmt = Convert.ToDecimal(rBonus.FOODAMT * Days) / Convert.ToDecimal(MonthDays);
                //    FoodAmt += foodAmt;
                //}
                decimal RoteBonusAmt = 0;// Math.Round(RoteMonthAmt, MidpointRounding.AwayFromZero)
                //+ Math.Round((RoteDayAmt * AppConfig.GetConfig("AvgWorkDays").GetDecimal()), MidpointRounding.AwayFromZero)
                //+ Math.Round((StationAmt * AppConfig.GetConfig("AvgWorkDays").GetDecimal()), MidpointRounding.AwayFromZero)
                //+ Math.Round(FoodAmt, MidpointRounding.AwayFromZero);
                //計算加班費、津貼、餐費
                foreach (var r in gp)//以人為迴圈
                {
                    var attendOfNobrDate = attendListOfNobr.SingleOrDefault(p => p.ADATE == r.ot.BDATE);
                    if (ChkDate != r.ot.BDATE)//每天重計
                    {
                        DayBonus = 0;
                        DayOtHrs = 0;
                        ChkDate = r.ot.BDATE;
                    }
                    var OTRATE_CODE = r.DefaultOtrateCode;//沒有指定的情況下，使用異動資料中設定
                    if (!r.COUNT_MA && r.HolDayOtrateCode.Trim().Length > 0)//如果有設定其他加班比率
                        OTRATE_CODE = r.HolDayOtrateCode.Trim();
                    if (r.ot.OTRATE_CODE.Trim().Length > 0)//如果加班資料上面有指定
                        OTRATE_CODE = r.ot.OTRATE_CODE.Trim();
                    otrcd = SalaryVar.GetOtRateCode(OTRATE_CODE);//取得加班比率設定
                    //otrcd = SalaryVar.GetOtRateCode(r.OTRATE_CODE);//取得加班比率設定
                    var dtSalbasd = salbasdList.Where(p => p.NOBR == r.ot.NOBR && r.ot.BDATE >= p.ADATE && r.ot.BDATE <= p.DDATE).ToList();
                    var dt = from a in dtSalbasd
                             where r.ot.BDATE >= a.ADATE
                             && r.ot.BDATE <= a.DDATE
                             select a;//取加班時間的有效薪資科目(未解密)   
                    var dts = from a in dt
                              join b in SalCodeList on a.SAL_CODE equals b.SAL_CODE
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
                    decimal not_Bonus = Math.Round(((r.ot.NOT_H_133 * otrcd.OT133HAMT)
                                   + (r.ot.NOT_H_167 * otrcd.OT167HAMT)
                                   + (r.ot.NOT_H_200 * otrcd.OT200HAMT)
                                   + (r.ot.NOT_W_133 * otrcd.OT133WAMT)
                                   + (r.ot.NOT_W_167 * otrcd.OT167WAMT)
                                   + (r.ot.NOT_W_200 * otrcd.OT200WAMT))
                                   , MidpointRounding.AwayFromZero);
                    if (!roteHoliList.Contains(attendOfNobrDate.ROTE))//只給假日
                        not_Bonus = 0;

                    decimal tot_exp = Math.Round(((r.ot.TOT_W_133 * r.ot.NOP_W_133) + (r.ot.TOT_W_167 * r.ot.NOP_W_167) + (r.ot.TOT_W_200 * r.ot.NOP_W_200)) * amtOfHrs, MidpointRounding.AwayFromZero);
                    decimal tot_Bonus = Math.Round(((r.ot.TOT_W_133 * otrcd.OT133WAMT) + (r.ot.TOT_W_167 * otrcd.OT167WAMT)
                        + (r.ot.TOT_W_200 * otrcd.OT200WAMT)), MidpointRounding.AwayFromZero);
                    if (!roteHoliList.Contains(attendOfNobrDate.ROTE))//只給假日
                        tot_Bonus = 0;
                    r.ot.NOT_EXP = JBModule.Data.CEncrypt.Number(not_exp);
                    r.ot.TOT_EXP = JBModule.Data.CEncrypt.Number(tot_exp);
                    if (r.ot.OT_HRS < 1M)//小於一小時不計
                    {
                        not_Bonus = 0;
                        tot_Bonus = 0;
                    }
                    r.ot.OT_FOODH = JBModule.Data.CEncrypt.Number(not_Bonus);
                    r.ot.OT_FOODH1 = JBModule.Data.CEncrypt.Number(tot_Bonus);

                    string ot_rote = "";
                    ot_rote = attendOfNobrDate.ROTE;
                    if (roteHoliList.Contains(attendOfNobrDate.ROTE))
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
                    #region 註解
                    decimal nigamt = 0;
                    //decimal foodamt = 0;
                    //if (r.OT_HRS > 0)
                    //{
                    //    var rotebonusCollection = RoteBonusList.Where(p => p.ROTE == ot_rote);
                    //    foreach (var rr in rotebonusCollection)
                    //    {
                    //        string btime, etime;
                    //        btime = r.BTIME;
                    //        etime = r.ETIME;
                    //        //var ts = TimeSpan(btime, etime);
                    //        if (rr.CHECK5)//僅加班
                    //            if ((rr.CHECK2 && !roteHoliList.Contains(attendOfNobrDate.ROTE)) || (rr.CHECK3 && roteHoliList.Contains(attendOfNobrDate.ROTE)))//平假日判斷
                    //                if (rr.CHECK1)//需做滿(完全包含)
                    //                {
                    //                    if (btime.CompareTo(rr.STR_B) <= 0 && etime.CompareTo(rr.STR_E) >= 0)
                    //                    {
                    //                        if (Convert.ToDecimal(r.OT_HRS) + DayOtHrs >= rr.VALUE1)
                    //                        {
                    //                            if (rr.SAL_CODE == AppConfig.GetConfig("OtBonusSalode").GetString(""))
                    //                                nigamt += rr.VALUE2 * r.TOT_HOURS;//津貼以加班總時數計算
                    //                            break;
                    //                        }
                    //                    }
                    //                    else if (btime.CompareTo(rr.STR_B) <= 0 && etime.CompareTo(rr.STR_B) > 0 && etime.CompareTo(rr.STR_E) < 0
                    //                        && roteList.Where(p => p.ROTE1 == attendOfNobrDate.ROTE).First().ON_TIME == etime)//結束介於設定區間內，
                    //                    {
                    //                        var attcardSQL = from a in db.ATTCARD where a.NOBR == r.NOBR && a.ADATE == r.BDATE select a;
                    //                        if (attcardSQL.Any())//如果符合條件，檢查刷卡時間是否有和加班時間有交集(連續)
                    //                        {
                    //                            var attcard = attcardSQL.First();
                    //                            if (r.ETIME.CompareTo(attcard.T1) >= 0)
                    //                            //加班時間與出勤時間連續
                    //                            {
                    //                                if (Convert.ToDecimal(r.OT_HRS) + DayOtHrs >= rr.VALUE1)
                    //                                {
                    //                                    if (rr.SAL_CODE == AppConfig.GetConfig("OtBonusSalode").GetString(""))
                    //                                        nigamt += rr.VALUE2 * r.TOT_HOURS;//津貼以加班總時數計算
                    //                                    break;
                    //                                }
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                else//只要有交集
                    //                {
                    //                    if (btime.CompareTo(rr.STR_E) < 0 && etime.CompareTo(rr.STR_B) >= 0)
                    //                    {
                    //                        if (r.OT_HRS + DayOtHrs >= rr.VALUE1)
                    //                        {
                    //                            if (rr.SAL_CODE == AppConfig.GetConfig("OtBonusSalode").GetString(""))
                    //                                nigamt += rr.VALUE2 * r.TOT_HOURS;//津貼以加班總時數計算
                    //                            break;
                    //                        }
                    //                    }
                    //                }
                    //    }
                    //}

                    //if (DayBonus <= nigamt)
                    //    nigamt = nigamt - DayBonus;//20120627計算累計時補差異
                    DayOtHrs += r.ot.OT_HRS;
                    r.ot.OT_FOOD = JBModule.Data.CEncrypt.Number(nigamt);
                    //DayBonus += foodamt;
                    #endregion
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
        Dictionary<string, List<EmpOtrateCode>> otrateDictionary = new Dictionary<string, List<EmpOtrateCode>>();
        List<JBModule.Data.Linq.OTRATECD> otrateList;
        private JBModule.Data.Linq.OTRATECD GetOtRateCode(JBModule.Data.Linq.OT_B r)
        {
            if (r.OTRATE_CODE.Trim().Length > 0)
            {
                return GetOtRateCode(r.OTRATE_CODE);
            }
            else
            {
                if(!otrateDictionary.ContainsKey(r.NOBR))
                {
                     JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                     otrateDictionary.Add(r.NOBR, db.BASETTS.Where(p => p.NOBR == r.NOBR).Select(p => new EmpOtrateCode { DateBegin = p.ADATE, DateEnd = p.DDATE.Value, EmployeeId = p.NOBR, OtRateCode = p.CALOT }).ToList());
                }
                var empOtRateList=otrateDictionary[r.NOBR];
                var empOtRate=empOtRateList.SingleOrDefault(p=>r.BDATE>=p.DateBegin && r.BDATE<=p.DateEnd);
                 return GetOtRateCode(empOtRate.OtRateCode);
            }
        }
        JBModule.Data.Linq.OTRATECD GetOtRateCode(string code)
        {
            if (otrateList == null)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                otrateList = db.OTRATECD.ToList();
            }
            var itm = from a in otrateList where a.OTRATE_CODE.Trim() == code select a;
            var ans = itm.FirstOrDefault();
            if (ans == null) throw new Exception("找不到加班比例代碼" + code);
            return ans;
        }
    }
    public class EmpOtrateCode
    {
        public string EmployeeId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string OtRateCode { get; set; }
    }
}

