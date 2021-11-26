using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class MonthlyOvertimeHoursLabourCheckRule : ILabourCheckRule
    {

        #region ILabourCheckRule 成員

        public List<Linq.OT_B> ValidateOT(List<Linq.OT_B> Source)
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
