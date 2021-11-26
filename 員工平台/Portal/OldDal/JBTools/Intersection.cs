using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace JBTools
{
    public class Intersection
    {
        DateTime TempA, TempB;
        public Intersection()
        {
            TempA = DateTime.MinValue;
            TempB = DateTime.MaxValue;
        }
        public void Inert(DateTime T1, DateTime T2)
        {
            if (TempA < T1) TempA = T1;
            if (TempB > T2) TempB = T2;
        }
        public void Inert(string T1, string T2)
        {
            DateTime TT1, TT2;
            if (T1.Trim().Length > 0)
                TT1 = DateTime.MinValue.AddTime(T1);
            else TT1 = DateTime.MinValue.AddTime("0000");

            if (T2.Trim().Length > 0)
                TT2 = DateTime.MinValue.AddTime(T2);
            else TT2 = DateTime.MinValue.AddTime("4800");

            if (TempA < TT1) TempA = TT1;
            if (TempB > TT2) TempB = TT2;
        }
        public DateTime TimeBegin
        {
            get { return TempA; }
        }
        public DateTime TimeEnd
        {
            get { return TempB; }
        }
        public bool HasIntersection()
        {
            return TempA <= TempB;
        }
        public TimeSpan IntersectionTimeSpan
        {
            get { return TempB - TempA; }
        }
        public int GetDays()
        {
            if (HasIntersection())
                return Convert.ToInt32((TempB.Date - TempA.Date).TotalDays) + 1;
            else return 0;
        }
        public decimal GetHours()
        {
            if (HasIntersection())
                return Convert.ToDecimal(IntersectionTimeSpan.TotalHours);
            else return 0;
        }
        public decimal GetMinutes()
        {
            if (HasIntersection())
                return Convert.ToDecimal(IntersectionTimeSpan.TotalMinutes);
            else return 0;
        }
    }
}
