using System;

namespace Bll.Tools
{
    public static class TimeTrans
    {
        /// <summary>
        /// 轉換時間為分鐘數
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值)</param>
        /// <returns>int</returns>
        public static int ConvertHhMmToMinutes(string sTime)
        {
            if (sTime == null)
                return 0;

            sTime = (sTime.Trim().Length < 4) ? "0000" : sTime;
            return Convert.ToInt32(sTime.Substring(0, 2)) * 60 + int.Parse(sTime.Substring(2, 2));
        }

        /// <summary>
        /// 轉換時間為分鐘數
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值)</param>
        /// <param name="bStart">當轉換時間格式不正確時,預帶之轉換時間bStart = True = "0000"</param>
        /// <returns>int</returns>
        public static int ConvertHhMmToMinutes(string sTime, bool bStart)
        {
            sTime = (sTime.Trim().Length < 4) ? bStart ? "0000" : "2400" : sTime;
            return Convert.ToInt32(sTime.Substring(0, 2)) * 60 + int.Parse(sTime.Substring(2, 2));
        }

        /// <summary>
        /// 轉換分鐘為時間
        /// </summary>
        /// <param name="iMinutes">分鐘數</param>
        /// <returns>string</returns>
        public static string ConvertMinutesToHhMm(int iMinutes)
        {
            return Convert.ToInt32(iMinutes / 60).ToString("00") + (iMinutes % 60).ToString("00");
        }

        /// <summary>
        /// 分割時間字串為小時或分鐘
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值,不足4位時會向前補零)</param>
        /// <param name="bHour">bHour = True = 取得小時</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhOrMm(string sTime, bool bHour)
        {
            sTime = (sTime.Trim().Length < 4) ? sTime.PadLeft(4, char.Parse("0")) : sTime;
            return bHour ? sTime.Substring(0, 2) : sTime.Substring(2, 2);
        }

        /// <summary>
        /// 分割時間字串為標準時間ex: 12 : 30 : 00
        /// </summary>
        /// <param name="sTime">時間(為4為位之數值,不足4位時會向前補零)</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhMmSs(string sTime)
        {
            sTime = (sTime.Trim().Length < 4) ? sTime.PadLeft(4, char.Parse("0")) : sTime;
            return sTime.Substring(0, 2) + ":" + sTime.Substring(2, 2) + ":00";
        }

        /// <summary>
        /// 將日期轉成HHMM
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>string</returns>
        public static string SplitTimeToHhMm(DateTime dDate)
        {
            return dDate.Hour.ToString().PadLeft(2, char.Parse("0")) + dDate.Minute.ToString().PadLeft(2, char.Parse("0"));
        }

        /// <summary>
        /// 取得整月的開始日期或結束日期
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <param name="bStart">bStart = True = 開始日期</param>
        /// <returns>DateTime</returns>
        public static DateTime DateOfStartOrEnd(DateTime dDate, bool bStart)
        {
            int yy = dDate.Year;
            int mm = dDate.Month;
            int dd = bStart ? 1 : DateTime.DaysInMonth(yy, mm);
            return new DateTime(yy, mm, dd);
        }

        /// <summary>
        /// 取得整月的開始日期或結束日期
        /// </summary>
        /// <param name="sYYMM"></param>
        /// <param name="bStart">bStart = True = 開始日期</param>
        /// <returns>DateTime</returns>
        public static DateTime DateOfStartOrEndForOld(string sYYMM, bool bStart)
        {
            sYYMM = sYYMM.Trim().Length == 5 ? sYYMM : (DateTime.Now.Year - 1911).ToString("000") + (DateTime.Now.Month).ToString("00");
            int yy = Convert.ToInt32(sYYMM.Substring(0, 3));
            int mm = Convert.ToInt32(sYYMM.Substring(3));
            int dd = bStart ? 1 : DateTime.DaysInMonth(yy, mm);
            return new DateTime(yy, mm, dd);
        }

        /// <summary>
        /// 取得整月的開始日期或結束日期
        /// </summary>
        /// <param name="sYYMM"></param>
        /// <param name="bStart">bStart = True = 開始日期</param>
        /// <returns>DateTime</returns>
        public static DateTime DateOfStartOrEnd(string sYYMM, bool bStart)
        {
            sYYMM = sYYMM.Trim().Length == 6 ? sYYMM : (DateTime.Now.Year).ToString("0000") + (DateTime.Now.Month).ToString("00");
            int yy = Convert.ToInt32(sYYMM.Substring(0, 4));
            int mm = Convert.ToInt32(sYYMM.Substring(4));
            int dd = bStart ? 1 : DateTime.DaysInMonth(yy, mm);
            return new DateTime(yy, mm, dd);
        }

        /// <summary>
        /// 日期轉換成YYMM
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>string</returns>
        public static string DateToYyMmForOld(DateTime dDate)
        {
            string yyyy = (dDate.Year - 1911).ToString("000");
            string mm = dDate.Month.ToString("00");
            return yyyy + mm;
        }

        /// <summary>
        /// 日期轉換成YYMM
        /// </summary>
        /// <param name="dDate">日期</param>
        /// <returns>string</returns>
        public static string DateToYyMm(DateTime dDate)
        {
            string yyyy = dDate.Year.ToString("0000");
            string mm = dDate.Month.ToString("00");
            return yyyy + mm;
        }

        /// <summary>
        /// YYMM轉換成日期
        /// </summary>
        /// <param name="sYYMM">YYMM</param>
        /// <param name="iDay">日</param>
        /// <returns>DateTime</returns>
        public static DateTime YyMmToDateForOld(string sYYMM, int iDay)
        {
            int yy = Convert.ToInt32(sYYMM.Substring(0, 3));
            int mm = Convert.ToInt32(sYYMM.Substring(3));
            DateTime dDate;
            try
            {
                dDate = new DateTime(yy, mm, iDay);
            }
            catch
            {
                dDate = new DateTime(yy, mm, 1);
            }

            return dDate;
        }

        /// <summary>
        /// yymm直接增減月
        /// </summary>
        /// <param name="YYMM">年月</param>
        /// <param name="Month">月</param>
        /// <returns></returns>
        public static string YyMmAddMonth(string YYMM, int Month)
        {
            int yy = Convert.ToInt32(YYMM.Substring(0, 4));

            int mm = Convert.ToInt32(YYMM.Substring(4));
            DateTime dDate = new DateTime(yy, mm, 1).AddMonths(Month);

            return DateToYyMm(dDate);
        }

        /// <summary>
        /// YYMM轉換成日期
        /// </summary>
        /// <param name="sYYMM">YYMM</param>
        /// <param name="iDay">日</param>
        /// <returns>DateTime</returns>
        public static DateTime YyMmToDate(string sYYMM, int iDay)
        {
            int yy = Convert.ToInt32(sYYMM.Substring(0, 4));
            int mm = Convert.ToInt32(sYYMM.Substring(4));
            DateTime dDate;
            try
            {
                dDate = new DateTime(yy, mm, iDay);
            }
            catch
            {
                dDate = new DateTime(yy, mm, 1);
            }

            return dDate;
        }

        private static string YymmToYyymmForOld(string yymm)
        {
            string yyy = (Convert.ToInt32(yymm.Substring(0, 3)) - 1911).ToString("000") + "年";
            string mm = Convert.ToUInt32(yymm.Substring(3)).ToString("00") + "月";
            string yyymm = yyy + mm;

            return yyymm;
        }

        private static string YymmToYyymm(string yymm)
        {
            string yyy = (Convert.ToInt32(yymm.Substring(0, 4))).ToString() + "年";
            string mm = yymm.Substring(4, 2) + "月";
            string yyymm = yyy + mm;

            return yyymm;
        }
    }
}