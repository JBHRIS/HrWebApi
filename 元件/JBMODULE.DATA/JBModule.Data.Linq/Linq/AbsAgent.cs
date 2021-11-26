using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class AbsAgent
    {
        public HrDBDataContext dc { get; set; }
        HolidayType _holidayType;
        public List<string> YearRestOfAllow = new List<string>();
        public AbsAgent()
        {
            dc = new HrDBDataContext();
        }
        internal AbsAgent(HrDBDataContext _dc)
        {
            dc = _dc;
            YearRestOfAllow = new List<string>();
            YearRestOfAllow.Add("1");
            YearRestOfAllow.Add("3");
            YearRestOfAllow.Add("5");
            YearRestOfAllow.Add("7");
            YearRestOfAllow.Add("9");
        }
        /// <summary>
        /// 抓取請假得假資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<ABS> GetLeaveAllow(DateTime DDATE, HolidayType holidayType)
        {
            int iYearRest = Convert.ToInt32(holidayType);
            string sYearRest = iYearRest.ToString();
            if (holidayType == HolidayType.None)
                sYearRest = "x";
            return (from c in dc.ABS
                    where c.HCODE.YEAR_REST == sYearRest
                    && (from c1 in dc.ABS
                        where c1.HCODE.YEAR_REST == sYearRest
                        && DDATE >= c1.BDATE && DDATE <= c1.EDATE
                        && c.BDATE >= c1.BDATE && c.BDATE <= c1.EDATE
                        && c.NOBR == c1.NOBR
                        select c1
                    ).Any()
                    select c);
        }
        /// <summary>
        /// 抓取請假得假資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<ABS> GetLeaveAllowByYear(DateTime DDATE, HolidayType holidayType)
        {
            int iYearRest = Convert.ToInt32(holidayType);
            string sYearRest = iYearRest.ToString();
            if (holidayType == HolidayType.None)
                sYearRest = "x";
            return (from c in dc.ABS
                    where c.HCODE.YEAR_REST == sYearRest
                    && c.BDATE.Year == DDATE.Year
                    select c);
        }
        /// <summary>
        /// 抓取請假得假資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<ABS> GetLeaveAllowByYear(DateTime DDATE)
        {
            return (from c in dc.ABS
                    where c.BDATE.Year == DDATE.Year
                    && YearRestOfAllow.Contains(c.HCODE.YEAR_REST)
                    select c);
        }
        /// <summary>
        /// 抓取請假得假資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<ABST> GetLeaveAllowT(DateTime DDATE)
        {
            //int iYearRest = Convert.ToInt32(holidayType);
            //string sYearRest = iYearRest.ToString();
            return (from c in dc.ABST
                    where
                        //c.HCODE.YEAR_REST == sYearRest
                        //&& 
                    (from c1 in dc.ABST
                     where
                         //c1.HCODE.YEAR_REST == sYearRest
                         //&& 
                     DDATE >= c1.BDATE && DDATE <= c1.EDATE
                     && c.BDATE >= c1.BDATE && c.BDATE <= c1.EDATE
                     && c.NOBR == c1.NOBR
                     select c1
                    ).Any()
                    select c);
        }
        public HolidayType GetHoliType(string Hcode)
        {
            var hcodeRows = from a in dc.HCODE where a.H_CODE == Hcode select a;
            if (hcodeRows.Any())
            {
                var rhcode = hcodeRows.First();
                string sYearRest = rhcode.YEAR_REST;
                var hType = GetHoliTypeByYearRest(sYearRest);
                return hType;
            }
            return HolidayType.None;
        }
        public HolidayType GetHoliTypeByYearRest(string YearRest)
        {
            HolidayType hType = HolidayType.None;
            switch (YearRest)
            {
                case "1":
                    hType = HolidayType.SpecialLeave;
                    break;
                case "2":
                    hType = HolidayType.SpecialLeave;
                    break;
                case "3":
                    hType = HolidayType.CompensatoryLeave;
                    break;
                case "4":
                    hType = HolidayType.CompensatoryLeave;
                    break;
                case "5":
                    hType = HolidayType.OptionalLeave;
                    break;
                case "6":
                    hType = HolidayType.OptionalLeave;
                    break;
                default:
                    hType = HolidayType.None;
                    break;
            }
            return hType;
        }
        //public List<string> YearRestOfAllow
        //{
        //    get{
        //        List<string> YearRestOfAllow = new List<string>();
        //        YearRestOfAllow.Add("1");
        //        YearRestOfAllow.Add("3");
        //        YearRestOfAllow.Add("5");
        //        YearRestOfAllow.Add("7");
        //        YearRestOfAllow.Add("9");
        //        return YearRestOfAllow;
        //    }
        //}
        public IQueryable<ABS> GetLeaveUse(DateTime DDATE, HolidayType holidayType)
        {
            int iYearRest = Convert.ToInt32(holidayType);
            string sYearRest = iYearRest.ToString();
            string sYearRest1 = (iYearRest + 1).ToString();
            if (holidayType == HolidayType.None)
                sYearRest = "x";//none不抓資料
            return (from c in dc.ABS
                    where c.HCODE.YEAR_REST == sYearRest1
                    && (from c1 in dc.ABS
                        where c1.HCODE.YEAR_REST == sYearRest
                        && DDATE >= c1.BDATE && DDATE <= c1.EDATE
                        && c.BDATE >= c1.BDATE && c.BDATE <= c1.EDATE
                        && c.NOBR == c1.NOBR
                        select c1
                    ).Any()
                    select c);
        }
        public IQueryable<ABS> GetLeaveUseByYear(DateTime DDATE, HolidayType holidayType)
        {
            int iYearRest = Convert.ToInt32(holidayType);
            string sYearRest = iYearRest.ToString();
            string sYearRest1 = (iYearRest + 1).ToString();
            if (holidayType == HolidayType.None)
                sYearRest = "x";
            return (from c in dc.ABS
                    where c.HCODE.YEAR_REST == sYearRest1
                    && c.BDATE.Year == DDATE.Year
                    select c);
        }
        public IQueryable<ABS> GetLeaveUseByYear(DateTime DDATE)
        {
            return (from c in dc.ABS
                    where  !YearRestOfAllow.Contains(c.HCODE.YEAR_REST)
                    && c.BDATE.Year == DDATE.Year
                    select c);
        }
        public IQueryable<ABS> GetLeaveAllow()
        {
            return (from c in dc.ABS
                    where YearRestOfAllow.Contains(c.HCODE.YEAR_REST)
                    select c);
        }
        public IQueryable<ABS> GetLeaveUse()
        {
            return (from c in dc.ABS
                    where !YearRestOfAllow.Contains(c.HCODE.YEAR_REST)
                    select c);
        }
        public enum HolidayType
        {
            None = 0,
            SpecialLeave = 1,
            CompensatoryLeave = 3,
            OptionalLeave = 5,
        }
    }
}
