using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att
{
    class Rote
    {
        /// <summary>
        /// 尋找客制班別
        /// </summary>
        /// <param name="dcAttend">ATTEND</param>
        /// <param name="dDate">日期</param>
        /// <param name="sRoteCode">班別</param>
        /// <param name="iDay">起始日期</param>
        /// <returns>string</returns>
        public string GetRoteCode(Dictionary<DateTime, string> dcAttend, DateTime dDate, string sRoteCode = "00", int iDay = -1)
        {
            List<string> arrHoliDay = new List<string>() { "00", "0X", "0Y", "0Z" };

            Dictionary<DateTime, string> rAttend;

            do
            {
                rAttend = dcAttend.Where(p => p.Key.Date == dDate.AddDays(iDay).Date).ToDictionary(p => p.Key, p => p.Value);
                iDay++;
                if (rAttend != null)
                    sRoteCode = rAttend.FirstOrDefault().Value;

            } while (rAttend != null && arrHoliDay.Contains( sRoteCode ));

            return sRoteCode;
        }
    }
}