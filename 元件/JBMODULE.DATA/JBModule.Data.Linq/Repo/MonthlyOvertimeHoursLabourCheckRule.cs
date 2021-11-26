using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBTools.Extend;
namespace JBModule.Data.Repo
{
    public class MonthlyOvertimeHoursLabourCheckRule : ILabourCheckRule
    {

        #region ILabourCheckRule 成員

        public List<Linq.OT_B> ValidateOT(List<Linq.OT_B> Source)
        {
            if (Source.Count == 0) return Source;
            decimal MonthlyOvertimeMaxHours = Convert.ToDecimal(Parameters["MonthlyOvertimeMaxHours"]);
            bool PersonMaxOT_hrs = Convert.ToBoolean(Parameters["PersonMaxOT_hrs"]);
            DateTime Ddate = Convert.ToDateTime (Parameters["Ddate"]); //截止日期
            string HolidayListStr = Parameters.ContainsKey("HolidayList") ? Parameters["HolidayList"].ToString() : "00, 0X";
            List<string> HolidayList = HolidayListStr.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList() ;
            decimal HolidayMaxWK_hrs = Parameters.ContainsKey("HolidayMaxWK_hrs") ? Convert.ToDecimal(Parameters["HolidayMaxWK_hrs"]) : 8;
            List<string> empList1 = Source.GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();

            foreach (var empList in empList1.Split(1000))
            {
                var CheckWorkDays = (from a in db.ATTEND
                                     join b in db.OT on new { a.NOBR, a.ADATE } equals new { b.NOBR, ADATE = b.BDATE }
                                     where empList.Contains(a.NOBR) && b.YYMM == Source.First().YYMM
                                     select new
                                     {
                                         a.NOBR,
                                         a.ADATE,
                                         a.ROTE,
                                         IsHoliday = HolidayList.Contains(a.ROTE)
                                     }).ToList();

                var POT_hrs = (from a in db.SALDIVOT
                               where Ddate >= a.ADATE && Ddate <= a.DDATE
                               && empList.Contains(a.NOBR)
                               select a).ToList();
                foreach (var emp in empList)
                {
                    var checkWorkDaysOfEmp = CheckWorkDays.Where(p => p.NOBR == emp).ToList();
                    if (PersonMaxOT_hrs) //以每人節金時數
                    {
                        int i = POT_hrs.Where(xp => xp.NOBR == emp).Count();
                        MonthlyOvertimeMaxHours = i == 0 ? MonthlyOvertimeMaxHours : POT_hrs.Where(xp => xp.NOBR == emp).Select(xp => xp.OT_HRS).FirstOrDefault();
                    }
                    var randomList = GetRandomDateList(emp, Source.First().YYMM);//取得亂數天數
                    decimal totalOvertimeHours = Source.Where(p =>
                    p.NOBR == emp && checkWorkDaysOfEmp.Any(pp =>
                        pp.ADATE == p.BDATE)).Sum(p => checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE && pp.IsHoliday) ?
                            (p.TOT_HOURS >= HolidayMaxWK_hrs ? p.TOT_HOURS - HolidayMaxWK_hrs : 0) : p.TOT_HOURS);//個人總時數(篩選平假日)
                    if (totalOvertimeHours < MonthlyOvertimeMaxHours) continue;//未超過，直接跑下一個

                    foreach (var day in randomList)
                    {
                        Source.RemoveAll(p => p.NOBR == emp && p.BDATE.Day == day);//移除符合條件資料
                        totalOvertimeHours = Source.Where(p => p.NOBR == emp && checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE)).Sum(p => checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE && pp.IsHoliday) ? (p.TOT_HOURS >= HolidayMaxWK_hrs ? p.TOT_HOURS - HolidayMaxWK_hrs : 0) : p.TOT_HOURS);//個人總時數(篩選平假日)
                        if (totalOvertimeHours < MonthlyOvertimeMaxHours) break;//未超過，跳出迴圈(下一個工號)
                    }
                } 
            }
            return Source;
        }

        public List<Linq.OT_B> ValidatePersonOT_Hrs(List<Linq.OT_B> Source,bool Ot_hrsByNobr)
        {
            if (Source.Count == 0) return Source;
            decimal MonthlyOvertimeMaxHours = Convert.ToDecimal(Parameters["MonthlyOvertimeMaxHours"]);

            List<string> empList = Source.GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            var CheckWorkDays = (from a in db.ATTEND
                                 join b in db.OT on new { a.NOBR, a.ADATE } equals new { b.NOBR, ADATE = b.BDATE }
                                 where empList.Contains(a.NOBR) && b.YYMM == Source.First().YYMM
                                 select new
                                 {
                                     a.NOBR,
                                     a.ADATE,
                                     a.ROTE,
                                     IsHoliday = new string[] { "00", "0Z" }.Contains(a.ROTE)
                                 }).ToList();
            foreach (var emp in empList)
            {
                var checkWorkDaysOfEmp = CheckWorkDays.Where(p => p.NOBR == emp).ToList();
                var randomList = GetRandomDateList(emp, Source.First().YYMM);//取得亂數天數
                decimal totalOvertimeHours = Source.Where(p =>
                p.NOBR == emp && checkWorkDaysOfEmp.Any(pp =>
                    pp.ADATE == p.BDATE)).Sum(p => checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE && pp.IsHoliday) ?
                        (p.TOT_HOURS >= 8 ? p.TOT_HOURS - 8 : 0) : p.TOT_HOURS);//個人總時數(篩選平假日)
                if (totalOvertimeHours < MonthlyOvertimeMaxHours) continue;//未超過，直接跑下一個

                foreach (var day in randomList)
                {
                    Source.RemoveAll(p => p.NOBR == emp && p.BDATE.Day == day);//移除符合條件資料
                    totalOvertimeHours = Source.Where(p => p.NOBR == emp && checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE)).Sum(p => checkWorkDaysOfEmp.Any(pp => pp.ADATE == p.BDATE && pp.IsHoliday) ? (p.TOT_HOURS >= 8 ? p.TOT_HOURS - 8 : 0) : p.TOT_HOURS);//個人總時數(篩選平假日)
                    if (totalOvertimeHours < MonthlyOvertimeMaxHours) break;//未超過，跳出迴圈(下一個工號)
                }
            }
            return Source;
        }



        List<int> GetRandomDateList(string EmployeeID, string YYMM)
        {
            List<int> CheckDateSequence = new List<int>();
            //Random rm = new Random((Convert.ToInt32(EmployeeID) + Convert.ToInt32(YYMM));
            Random rm = new Random();

            while (CheckDateSequence.Count() < 31)
            {
                int i = rm.Next(1, 32);
                if (!CheckDateSequence.Contains(i))
                    CheckDateSequence.Add(i);
            }
            return CheckDateSequence;
        }
        #endregion

        #region ILabourCheckRule 成員


        public Dictionary<string, object> Parameters { get; set; }

        #endregion
    }
}
