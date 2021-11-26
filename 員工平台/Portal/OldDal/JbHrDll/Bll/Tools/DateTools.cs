using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Tools
{
    public class DateTools
    {
        /// <summary>
        /// 得到本周第一天(以星期天為第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDaySun(DateTime datetime)
        {
            //星期天為第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周第一天(以星期一為第一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekFirstDayMon(DateTime datetime)
        {
            //星期一為第一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因為是以星期一為第一天，所以要判斷weeknow等於0時，要向前推6天。
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>
        /// 得到本周最後一天(以星期六為最後一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySat(DateTime datetime)
        {
            //星期六為最後一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最後一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 得到本周最後一天(以星期天為最後一天)
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime GetWeekLastDaySun(DateTime datetime)
        {
            //星期天為最後一天
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最後一天
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 取得星期幾
        /// </summary>
        /// <param name="today">日期</param>
        /// <returns>string</returns>
        public static string GetDayOfWeekDayName(DateTime today)
        {
            string result = "";

            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                result = "星期一";
            }
            else if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                result = "星期二";
            }
            else if (today.DayOfWeek == DayOfWeek.Wednesday)
            {
                result = "星期三";
            }
            else if (today.DayOfWeek == DayOfWeek.Thursday)
            {
                result = "星期四";
            }
            else if (today.DayOfWeek == DayOfWeek.Friday)
            {
                result = "星期五";
            }
            else if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                result = "星期六";
            }
            else if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                result = "星期日";
            }

            return result;
        }
    }
}