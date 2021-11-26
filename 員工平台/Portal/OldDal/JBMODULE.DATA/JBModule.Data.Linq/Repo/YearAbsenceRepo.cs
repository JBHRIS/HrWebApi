using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class YearAbsenceRepo
    {
        public YearAbsenceRepo()
        {

        }
        JBModule.Data.ApplicationConfigSettings AppConfig;
        public List<SpecialLeaveOfYear> GetYearAbsenceDetail(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd, DateTime DDate)
        {
            List<SpecialLeaveOfYear> SpecialLeaveOfYearList = new List<SpecialLeaveOfYear>();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var chkComp = from a in db.BASE
                          where EmployeeList.Contains(a.NOBR)
                          let CompGroup = db.GetCompGroupByNobr(a.NOBR, DateEnd)
                          group new { a.NOBR, CompGroup } by CompGroup;
            //AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);

            DateTime d1, d2;
            d1 = DateTime.Now;
            foreach (var gp in chkComp)
            {
                //設定參數
                AppConfig = new ApplicationConfigSettings("FRM4O", gp.Key);
                List<string> FullHcodeList = new List<string>();
                List<string> HalfHcodeList = new List<string>();
                List<string> FullHcodeListD = new List<string>();
                string FullHcode1 = AppConfig.GetConfig("FullHcode1").GetString("");
                string FullHcode2 = AppConfig.GetConfig("FullHcode2").GetString("");
                string FullHcode3 = AppConfig.GetConfig("FullHcode3").GetString("");
                string FullHcode4 = AppConfig.GetConfig("FullHcode4").GetString("");
                string FullHcode5 = AppConfig.GetConfig("FullHcode5").GetString("");
                string FullHcode6 = AppConfig.GetConfig("FullHcode6").GetString("");

                string HalfHcode1 = AppConfig.GetConfig("HalfHcode1").GetString("");
                string HalfHcode2 = AppConfig.GetConfig("HalfHcode2").GetString("");

                FullHcodeList.Add(FullHcode1);
                FullHcodeList.Add(FullHcode2);
                FullHcodeList.Add(FullHcode3);
                FullHcodeList.Add(FullHcode4);
                FullHcodeList.Add(FullHcode5);
                FullHcodeList.Add(FullHcode6);

                HalfHcodeList.Add(HalfHcode1);
                HalfHcodeList.Add(HalfHcode2);

                FullHcodeListD.Add(AppConfig.GetConfig("FullHcode1").GetString(""));
                FullHcodeListD.Add(AppConfig.GetConfig("HcodeForBonus").GetString(""));
                string h_code = AppConfig.GetConfig("HcodeForBonus").GetString("");
                if (!GetHcode().ContainsKey(h_code))
                    throw new Exception("找不到特休代金的沖假代碼，請確認設定是否正確");

                string sal_codeBonus = AppConfig.GetConfig("SalcodeBonus").GetString("");
                string sal_codeDisCount = AppConfig.GetConfig("SalcodeDiscount").GetString("");


                List<string> listYearRest = new List<string>();
                listYearRest.Add("1");

                var absSQL = from abs in db.ABS
                             join basetts in db.BASETTS on abs.NOBR equals basetts.NOBR
                             join hcode in db.HCODE on abs.H_CODE equals hcode.H_CODE
                             where DDate >= basetts.ADATE && DDate <= basetts.DDATE.Value//以異動截止日為準
                             && EmployeeList.Contains(abs.NOBR)
                             && listYearRest.Contains(hcode.YEAR_REST)//假別年補休特性為1
                             && abs.BDATE >= DateBegin && abs.BDATE <= DateEnd//先取出得假的失效日在設定區間內                         
                             //&& !basetts.NOSPEC//未選取不計算特休代金
                             //&& db.GetFilterByNobr(abs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//前端條件去控制
                             select new { abs.NOBR, abs.H_CODE, abs.BDATE, abs.EDATE, abs.TOL_HOURS, hcode.YEAR_REST };
                var FullAbsSQL = (from abs in db.ABS
                                  join basetts in db.BASETTS on abs.NOBR equals basetts.NOBR
                                  join hcode in db.HCODE on abs.H_CODE equals hcode.H_CODE
                                  where DDate >= basetts.ADATE && DDate <= basetts.DDATE.Value//以異動截止日為準
                                  && EmployeeList.Contains(abs.NOBR)
                                  && (FullHcodeList.Contains(abs.H_CODE))
                                  && (basetts.DI != "I" || FullHcodeListD.Contains(abs.H_CODE))//如果是直接人員，就只看第一個假別
                                  && abs.BDATE >= DateBegin && abs.BDATE <= DateEnd//先取出得假的失效日在設定區間內                         
                                  //&& !basetts.NOSPEC//未選取不計算特休代金
                                  //&& db.GetFilterByNobr(abs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                  select new { abs.NOBR, abs.H_CODE, abs.BDATE, abs.EDATE, abs.TOL_HOURS, hcode.YEAR_REST }).ToList();
                var HalfAbsSQL = (from abs in db.ABS
                                  join basetts in db.BASETTS on abs.NOBR equals basetts.NOBR
                                  join hcode in db.HCODE on abs.H_CODE equals hcode.H_CODE
                                  where DDate >= basetts.ADATE && DDate <= basetts.DDATE.Value//以異動截止日為準
                                  && EmployeeList.Contains(abs.NOBR)
                                  && (HalfHcodeList.Contains(abs.H_CODE))
                                  && (basetts.DI == "I")//如果是間接人員才要算事病假
                                  && abs.BDATE >= DateBegin && abs.BDATE <= DateEnd//先取出得假的失效日在設定區間內                         
                                  //&& !basetts.NOSPEC//未選取不計算特休代金
                                  //&& db.GetFilterByNobr(abs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                  select new { abs.NOBR, abs.H_CODE, abs.BDATE, abs.EDATE, abs.TOL_HOURS, hcode.YEAR_REST }).ToList();

                var LeaveEmployeeList = (from a in db.BASETTS
                                         join b in db.DEPT on a.DEPT equals b.D_NO
                                         join c in db.JOBL on a.JOBL equals c.JOBL1
                                         where EmployeeList.Contains(a.NOBR)
                                         && DDate <= a.DDATE.Value
                                         select new { a.NOBR, a.BASE.NAME_C, INDT = a.INDT.Value, a.OUDT, a.DI }).Distinct().ToList();
                absSQL = from a in absSQL where LeaveEmployeeList.Select(p => p.NOBR).Contains(a.NOBR) select a;

                //var amtSQL = (from salbasd in db.SALBASD
                //              join salcode in db.SALCODE on salbasd.SAL_CODE equals salcode.SAL_CODE
                //              //join bs in db.BASE on salbasd.NOBR equals bs.NOBR
                //              where DateEnd >= salbasd.ADATE && DateEnd <= salbasd.DDATE
                //              && salcode.ABSPAY//該薪資科目設定為不休假獎金                         
                //              select new { salbasd.NOBR, salbasd.ADATE, salbasd.SAL_CODE, salbasd.AMT }).ToList();
                var SQL = (from a in absSQL
                           join c in db.BASE on a.NOBR equals c.NOBR
                           join d in db.BASETTS on a.NOBR equals d.NOBR
                           where DateEnd >= d.ADATE && DateEnd <= d.DDATE.Value
                           select new { a.NOBR, a.BDATE, a.TOL_HOURS, a.H_CODE }).ToList();
                var BonusSalcodeList = from a in db.SALCODE
                                       join b in db.SALATTR on a.SAL_ATTR equals b.SALATTR1
                                       where new string[] { sal_codeBonus, sal_codeDisCount }.Contains(a.SAL_CODE)
                                       select new { a.SAL_CODE, b.FLAG };

                foreach (var it in LeaveEmployeeList)
                {
                    var GetABS = from a in SQL where a.NOBR == it.NOBR select a;
                    var UseAbsFull = from a in FullAbsSQL where a.NOBR == it.NOBR select a;
                    var UseAbsHalf = from a in HalfAbsSQL where a.NOBR == it.NOBR select a;
                    //var SalbasdOfNobr = from a in amtSQL where a.NOBR == it.NOBR select a;


                    //用來運算代金時數
                    decimal plusHrs = 0;
                    //用來運算沖假時數
                    decimal truePlusHrs//得假時間加總計算
                        = GetABS.Sum(p => p.TOL_HOURS);//+
                    plusHrs = truePlusHrs;

                    var minusFullSQL = from a in UseAbsFull
                                       join b in db.HCODE on a.H_CODE equals b.H_CODE
                                       where a.NOBR == it.NOBR
                                       select a;//依得假的區間來找
                    decimal minusFullHrs = minusFullSQL.Any() ? minusFullSQL.Sum(p => p.TOL_HOURS) : 0;//-
                    var minusHalfSQL = from a in UseAbsHalf
                                       join b in db.HCODE on a.H_CODE equals b.H_CODE
                                       where a.NOBR == it.NOBR
                                       select a;//依得假的區間來找
                    decimal minusHalfHrs = minusHalfSQL.Any() ? minusHalfSQL.Sum(p => p.TOL_HOURS) : 0;//-
                    decimal minusHrs = minusFullHrs + (minusHalfHrs / 2);
                    decimal absHrs = minusFullHrs + minusHalfHrs;

                    decimal Hrs = truePlusHrs - minusHrs;//剩餘
                    decimal Hrs1 = plusHrs - minusHrs;//剩餘

                    SpecialLeaveOfYear rs = new SpecialLeaveOfYear();
                    rs.NOBR = it.NOBR;
                    rs.DI = it.DI;
                    rs.TOL_HOURS = Hrs1;
                    rs.GET_HOURS = plusHrs;
                    rs.NAME_C = it.NAME_C;
                    rs.INDT = it.INDT;
                    //rs.OUDT = it.OUDT.Value;

                    rs.FullHours1 = 0;
                    var fh1 = from a in UseAbsFull where a.H_CODE == FullHcode1 select a;
                    if (fh1.Any())
                    {
                        rs.FullHours1 = fh1.Sum(p => p.TOL_HOURS);
                    }
                    rs.FullHours2 = 0;
                    var fh2 = from a in UseAbsFull where a.H_CODE == FullHcode2 select a;
                    if (fh2.Any())
                    {
                        rs.FullHours2 = fh2.Sum(p => p.TOL_HOURS);
                    }
                    rs.FullHours3 = 0;
                    var fh3 = from a in UseAbsFull where a.H_CODE == FullHcode3 select a;
                    if (fh3.Any())
                    {
                        rs.FullHours3 = fh3.Sum(p => p.TOL_HOURS);
                    }
                    rs.FullHours4 = 0;
                    var fh4 = from a in UseAbsFull where a.H_CODE == FullHcode4 select a;
                    if (fh4.Any())
                    {
                        rs.FullHours4 = fh4.Sum(p => p.TOL_HOURS);
                    }
                    rs.FullHours5 = 0;
                    var fh5 = from a in UseAbsFull where a.H_CODE == FullHcode5 select a;
                    if (fh5.Any())
                    {
                        rs.FullHours5 = fh5.Sum(p => p.TOL_HOURS);
                    }
                    rs.FullHours6 = 0;
                    var fh6 = from a in UseAbsFull where a.H_CODE == FullHcode6 select a;
                    if (fh6.Any())
                    {
                        rs.FullHours1 = fh6.Sum(p => p.TOL_HOURS);
                    }

                    rs.HalfHours1 = 0;
                    var hh1 = from a in UseAbsHalf where a.H_CODE == HalfHcode1 select a;
                    if (hh1.Any())
                    {
                        rs.HalfHours1 = hh1.Sum(p => p.TOL_HOURS);
                    }
                    rs.HalfHours2 = 0;
                    var hh2 = from a in UseAbsHalf where a.H_CODE == HalfHcode2 select a;
                    if (hh2.Any())
                    {
                        rs.HalfHours2 = hh2.Sum(p => p.TOL_HOURS);
                    }

                    rs.ABS_HOURS = rs.FullHours2 + rs.FullHours3 + rs.FullHours4 + rs.FullHours5 + rs.FullHours6 + rs.HalfHours1 + rs.HalfHours2;
                    rs.LEAVE_HOURS = rs.GET_HOURS - rs.FullHours1;
                    if (rs.DI == "D") rs.TOL_HOURS = rs.LEAVE_HOURS;//直接人員等於特休剩餘時數
                    SpecialLeaveOfYearList.Add(rs);
                }
            }
            return SpecialLeaveOfYearList;
        }
        Dictionary<string, string> GetHcode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      //where db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.H_CODE_DISP
                      select new { Key = a.H_CODE, Value = a.H_CODE_DISP + "-" + a.H_NAME };
            var lst = sql.AsEnumerable().ToDictionary(p => p.Key, p => p.Value);
            return lst;
        }
    }
    public class SpecialLeaveOfYear
    {
        public string NOBR;
        public string NAME_C;
        public string DI;
        public DateTime INDT;
        //public DateTime OUDT;
        public decimal GET_HOURS;
        public decimal LEAVE_HOURS;
        public decimal ABS_HOURS;
        public decimal FullHours1;
        public decimal FullHours2;
        public decimal FullHours3;
        public decimal FullHours4;
        public decimal FullHours5;
        public decimal FullHours6;
        public decimal HalfHours1;
        public decimal HalfHours2;
        public decimal TOL_HOURS;
    }
}
