using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class AbsAllow
    {
        public string EmployeeID;
        public DateTime DateBegin;
        public DateTime DateEnd;
        public decimal Value;
        public AbsenceUnit Unit;
        public static AbsenceUnit ConvertStringToAbsUnit(string sUnit)
        {
            AbsenceUnit result = AbsenceUnit.Hour;
            if (sUnit.Trim() == "天")
                result = AbsenceUnit.Day;
            return result;
        }

        public enum AbsenceUnit
        {
            /// <summary>
            /// 天
            /// </summary>
            Day=1,
            /// <summary>
            /// 小時
            /// </summary>
            Hour=8,
        }
    }
    public class AbsAllowGenCondition
    {
        public string EmployeeId;
        public DateTime DateBegin;
        public decimal Interval;
        public IntervalType Interval_Type;
        public decimal AbsValue;
        public JBModule.Data.Dto.AbsAllow.AbsenceUnit eUnit;
        public enum IntervalType
        {
            Year,
            Month,
            Day,
            YearEnd,
            MonthEnd,            
        }
    }
}
