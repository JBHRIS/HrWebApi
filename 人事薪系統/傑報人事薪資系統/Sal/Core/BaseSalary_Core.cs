using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class BaseSalary_Core
    {
        public decimal MonthDays, CustomDays, ThirtyDays = 30;//分母
        public decimal OnJobDays, RealWorkDays;//分子
        public decimal WorkHrs;//工時
        public string MonthType, CalcUnit, CalcType;
        public decimal CalculationRule(decimal Amt)
        {
            decimal val = 0;
            if (CalcUnit == "3")//時薪
            {
                val = Amt * WorkHrs;
            }
            else if (CalcUnit == "2")//日薪
            {
                val = Amt * RealWorkDays;
            }
            else if (CalcUnit == "21")//日薪(月曆天)
            {
                val = Amt * OnJobDays;// MonthDays;
            }
            else
            {
                switch (MonthType)
                {
                    case "2":
                        val = BaseRule_MonthDays(Amt);
                        break;
                    case "3":
                        val = BaseRule_ThirtyDays(Amt);
                        break;
                    case "4":
                        val = BaseRule_CustomDays(Amt);
                        break;
                    default:
                        val = BaseRule_ThirtyDays(Amt);//
                        break;
                }
            }
            return val;
        }
        /// <summary>
        /// 月曆天
        /// </summary>
        /// <param name="Amt"></param>
        /// <returns></returns>
        decimal BaseRule_MonthDays(decimal Amt)
        {
            decimal val = Amt * OnJobDays / MonthDays;
            return val;
        }
        /// <summary>
        /// 30天
        /// </summary>
        /// <param name="Amt"></param>
        /// <returns></returns>
        decimal BaseRule_ThirtyDays(decimal Amt)
        {
            decimal val = Amt * OnJobDays / ThirtyDays;
            return val;
        }
        //自訂天
        decimal BaseRule_CustomDays(decimal Amt)
        {
            decimal val = Amt * OnJobDays / CustomDays;
            if (val >= Amt)
                return Amt;//避免分子超過分母
            return val;
        }
        decimal BaseRule_Default(decimal Amt)
        {
            return BaseRule_MonthDays(Amt);
        }
    }
}
