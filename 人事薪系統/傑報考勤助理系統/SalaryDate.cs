using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class SalaryDate
    {
        int iYear = 0;
        int iMonth = 0;
        int SalEndDay = MainForm.SalaryConfig.SALMONTH.Value;
        int AttEndDay = MainForm.SalaryConfig.ATTMONTH.Value;
        /// <summary>
        /// 計薪年月
        /// </summary>
        /// <param name="yymm"></param>
        public SalaryDate(string yymm)
        {//MEMO: 2010/04/30 修改成西元年
            string sYear = yymm.Substring(0, 4);//2010/04/30 yymm.Substring(0, 3)改成抓西元年
            string sMonth = yymm.Substring(4, 2);//yymm.Substring(3, 2)
            iYear = int.Parse(sYear);//int.Parse(sYear) + 1911;
            iMonth = int.Parse(sMonth);
        }
        public SalaryDate(DateTime date)
        {
            if (date.Day > AttEndDay) date = date.AddMonths(1);
            iYear = date.Year;
            iMonth = date.Month;
        }
        public SalaryDate(int Year, int Month)
        {
            iYear = Year;
            iMonth = Month;
        }
        public SalaryDate GetPrevSalaryDate()
        {
            DateTime date = this.FirstDayOfMonth;
            date = date.AddMonths(-1);
            SalaryDate pd = new SalaryDate(date.ToString("yyyyMM"));
            return pd;
        }
        public SalaryDate GetNextSalaryDate()
        {
            DateTime date = this.FirstDayOfMonth;
            date = date.AddMonths(1);
            SalaryDate pd = new SalaryDate(date.ToString("yyyyMM"));
            return pd;
        }
        public static string GetSaladr(string Nobr, DateTime date)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.BASETTS where date >= a.ADATE && date <= a.DDATE.Value select a;
            if (sql.Any())
                return sql.First().SALADR;
            return "";
        }
        public static bool CheckAttendLock(DateTime date, string Saladr)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.DATA_PA where a.DATA_PASS == date && a.SALADR == Saladr select a;
            return sql.Any();
        }
        public static string GetUnLockYYMM(DateTime date, string Saladr)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.DATA_PA where a.DATA_PASS >= date && a.SALADR == Saladr select a;
            var gg = from a in sql.ToList() orderby a.DATA_PASS select new SalaryDate(a.DATA_PASS).YYMM;
            var orderList = gg.Distinct();
            SalaryDate sd = new SalaryDate(date);
            sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有這筆計薪年月，就在往下個月
                sd = sd.GetNextSalaryDate();
            return sd.YYMM;

        }
        public static bool IsLockedYYMM(DateTime date, string Saladr)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.DATA_PASS where a.DATA_PASS1 >= date && a.SALADR == Saladr select a;
            var gg = from a in sql.ToList() orderby a.DATA_PASS1 select new SalaryDate(a.DATA_PASS1).YYMM;
            var orderList = gg.Distinct();
            SalaryDate sd = new SalaryDate(date);
            sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有這筆計薪年月，就在往下個月
                return true;
            return false;

        }
        public string YYMM
        {
            get { return (iYear).ToString("0000") + iMonth.ToString("00"); }//MEMO: 2010/04/30 修改成西元年
        }
        public int Year
        {
            get { return iYear; }
        }
        public int Month
        {
            get { return iMonth; }
        }
        public DateTime FirstDayOfMonth
        {
            get
            {
                return new DateTime(iYear, iMonth, 1);
            }
        }
        public DateTime LastDayOfMonth
        {
            get
            {
                int dd = DateTime.DaysInMonth(iYear, iMonth);
                return new DateTime(iYear, iMonth, dd);
            }
        }
        public int TotalMonthDays
        {
            get
            {
                TimeSpan ts = LastDayOfSalary - FirstDayOfSalary;
                return Convert.ToInt32(ts.TotalDays) + 1;
            }
        }
        public DateTime FirstDayOfSalary
        {
            get
            {
                return LastDayOfSalary.AddDays(1).AddMonths(-1);
            }
        }
        public DateTime LastDayOfSalary
        {
            get
            {
                int days = DateTime.DaysInMonth(Year, Month);
                DateTime d2 = new DateTime(Year, Month, SalEndDay > days ? days : SalEndDay);
                return d2;
            }
        }
        public DateTime FirstDayOfAttend
        {
            get
            {
                return LastDayOfAttend.AddDays(1).AddMonths(-1);
            }
        }
        public DateTime LastDayOfAttend
        {
            get
            {
                int days = DateTime.DaysInMonth(Year, Month);
                DateTime d2 = new DateTime(Year, Month, AttEndDay > days ? days : AttEndDay);
                return d2;
            }
        }

        public int TotalSalaryDays
        {
            get
            {
                TimeSpan ts = LastDayOfSalary - FirstDayOfSalary;
                return Convert.ToInt32(ts.TotalDays) + 1;
            }
        }
        public string strYear
        {
            get
            {
                string ss = iYear.ToString("0000");
                return ss;
            }
        }
        public string strMonth
        {
            get
            {
                string ss = iMonth.ToString("00");
                return ss;
            }
        }



        public static string DateString(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }
        public static string DateString()
        {
            return DateString(DateTime.Now.Date);
        }

        public static string YearString()
        {
            return YearString(DateTime.Now.Date);

        }
        public static string YearString(DateTime date)
        {
            return date.Year.ToString("0000");
        }

        public static string MonthString()
        {
            return MonthString(DateTime.Now.Date);
        }
        public static string MonthString(DateTime date)
        {
            return date.Month.ToString("00");
        }

        public static string YymmString()
        {
            return YymmString(DateTime.Now.Date);
        }
        public static string YymmString(DateTime date)
        {
            SalaryDate sd = new SalaryDate(date);
            return sd.YYMM;
        }
        public static string MonthDayString(DateTime date)
        {
            return date.ToString("MMdd");
        }
        public static string MonthDayString()
        {
            return MonthDayString(DateTime.Now.Date);
        }
    }
}
