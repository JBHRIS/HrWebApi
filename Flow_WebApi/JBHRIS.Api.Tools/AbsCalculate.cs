using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Tools.Tool;
using System;
using System.Collections.Generic;
using System.Text;
using static JBHRIS.Api.Dto.FlowMainInte.Vdb.MultiEnum;

namespace JBHRIS.Api.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class AbsCalculate
    {
        /// <summary>
        /// 計算請假
        /// </summary>
        /// <param name="TimeB">開始時間</param>
        /// <param name="TimeE">結束時間</param>
        /// <param name="Unit">假別單位</param>
        /// <param name="ListRoteRest">休息時間</param>
        /// <param name="WorkHour">一天之工作時數</param>
        /// <param name="Min">最小數</param>
        /// <param name="Interval">間隔數</param>
        /// <param name="CalculateWorkTime">計算工作時數</param>
        /// <param name="CalculateRes">計算休息</param>
        /// <param name="Deduct">減彈性分鐘數</param>
        /// <returns>decimal</returns>
        public decimal GetCalculate(string TimeB, string TimeE, HoliDayUnit Unit = HoliDayUnit.Hour, List<RoteRestRow> ListRoteRest = null, decimal WorkHour = 8, decimal Min = 0.5M, decimal Interval = 0.5M, bool CalculateWorkTime = true, bool CalculateRes = true, int Deduct = 0)
        {
            DateTime DateNow = DateTime.Now.Date;
            DateTime DateTimeB = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(TimeB));
            DateTime DateTimeE = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(TimeE));

            int RestMinute = 0;
            TimeSpan ts;

            if (CalculateRes && ListRoteRest != null && ListRoteRest.Count > 0)
            {
                foreach (var rRoteRest in ListRoteRest)
                {
                    DateTime dDateTimeRestB = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRest.TimeB));
                    DateTime dDateTimeRestE = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRest.TimeE));

                    //是否有交集
                    if (DateTimeB < dDateTimeRestE && DateTimeE > dDateTimeRestB)
                    {
                        dDateTimeRestB = ((dDateTimeRestB <= DateTimeB) && (DateTimeB <= dDateTimeRestE)) ? DateTimeB : dDateTimeRestB;
                        dDateTimeRestE = ((dDateTimeRestB <= DateTimeE) && (DateTimeE <= dDateTimeRestE)) ? DateTimeE : dDateTimeRestE;

                        ts = dDateTimeRestE - dDateTimeRestB;
                        RestMinute += Convert.ToInt32(ts.TotalMinutes);
                    }
                }
            }

            int MinMinute = 30;
            int IntervalMinute = 30;

            switch (Unit)
            {
                case MultiEnum.HoliDayUnit.Minute:
                    MinMinute = Convert.ToInt32(Min);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(Interval);  //間隔分鐘
                    break;
                case MultiEnum.HoliDayUnit.Hour:
                    MinMinute = Convert.ToInt32(Min * 60);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(Interval * 60);  //間隔分鐘
                    break;
                case MultiEnum.HoliDayUnit.Day:
                    MinMinute = Convert.ToInt32(WorkHour * Min * 60);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(WorkHour * Interval * 60);  //間隔分鐘
                    break;
                default:
                    break;
            }

            ts = DateTimeE - DateTimeB;
            int Minute = Convert.ToInt32(ts.TotalMinutes);
            Minute = (Minute - RestMinute - Deduct) >= MinMinute ? Minute : MinMinute;
            int ModMinute = Minute == MinMinute ? 0 : Convert.ToInt32((Minute - RestMinute - Deduct) % IntervalMinute);
            if (ModMinute > 0)
                ModMinute = IntervalMinute - ModMinute;
            Minute = (Minute - RestMinute - Deduct) + ModMinute;

            //再判斷一次 是否小於最小單位 2015/12/30 BY MING
            Minute = (Minute >= MinMinute) ? Minute : MinMinute;

            decimal Cal = 0;
            switch (Unit)
            {
                case MultiEnum.HoliDayUnit.Minute:
                    Cal = Minute;
                    Cal = Minute > (WorkHour * 60m) ? (WorkHour * 60m) : Cal;
                    break;
                case MultiEnum.HoliDayUnit.Hour:
                    Cal = Minute / 60M;
                    if (CalculateWorkTime)
                        Cal = Cal > WorkHour ? WorkHour : Cal; //大於工作時數就用工作時數計算
                    break;
                case MultiEnum.HoliDayUnit.Day:
                    Cal = Convert.ToDecimal(Minute / 60M / WorkHour);
                    Cal = Cal > 1 ? 1 : Cal; //大於一天就用一天計算
                    break;
                default:
                    break;
            }

            return Cal;
        }

        /// <summary>
        /// 計算請假
        /// </summary>
        /// <param name="TimeB">開始時間</param>
        /// <param name="TimeE">結束時間</param>
        /// <param name="Unit">假別單位</param>
        /// <param name="ListRoteRest">休息時間</param>
        /// <param name="WorkHour">一天之工作時數</param>
        /// <param name="Min">最小數</param>
        /// <param name="Interval">間隔數</param>
        /// <param name="CalculateWorkTime">計算工作時數</param>
        /// <param name="CalculateRes">計算休息</param>
        /// <param name="Deduct">減彈性分鐘數</param>
        /// <returns>AbsCalculateRow</returns>
        public CalculateRow GetAbsCalculate(string TimeB, string TimeE, HoliDayUnit Unit = HoliDayUnit.Hour, List<RoteRestRow> ListRoteRest = null, decimal WorkHour = 8, decimal Min = 0.5M, decimal Interval = 0.5M, bool CalculateWorkTime = true, bool CalculateRes = true, int Deduct = 0)
        {
            var Vdb = new CalculateRow();

            DateTime DateNow = DateTime.Now.Date;
            DateTime DateTimeB = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(TimeB));
            DateTime DateTimeE = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(TimeE));

            int RestMinute = 0;
            TimeSpan ts;

            if (CalculateRes && ListRoteRest != null && ListRoteRest.Count > 0)
            {
                foreach (var rRoteRest in ListRoteRest)
                {
                    DateTime dDateTimeRestB = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRest.TimeB));
                    DateTime dDateTimeRestE = DateNow.AddMinutes(TimeTrans.ConvertHhMmToMinutes(rRoteRest.TimeE));

                    //是否有交集
                    if (DateTimeB < dDateTimeRestE && DateTimeE > dDateTimeRestB)
                    {
                        dDateTimeRestB = ((dDateTimeRestB <= DateTimeB) && (DateTimeB <= dDateTimeRestE)) ? DateTimeB : dDateTimeRestB;
                        dDateTimeRestE = ((dDateTimeRestB <= DateTimeE) && (DateTimeE <= dDateTimeRestE)) ? DateTimeE : dDateTimeRestE;

                        ts = dDateTimeRestE - dDateTimeRestB;
                        RestMinute += Convert.ToInt32(ts.TotalMinutes);
                    }
                }
            }

            int MinMinute = 30;
            int IntervalMinute = 30;

            switch (Unit)
            {
                case MultiEnum.HoliDayUnit.Minute:
                    MinMinute = Convert.ToInt32(Min);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(Interval);  //間隔分鐘
                    break;
                case MultiEnum.HoliDayUnit.Hour:
                    MinMinute = Convert.ToInt32(Min * 60);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(Interval * 60);  //間隔分鐘
                    break;
                case MultiEnum.HoliDayUnit.Day:
                    MinMinute = Convert.ToInt32(WorkHour * Min * 60);    //最小分鐘
                    IntervalMinute = Convert.ToInt32(WorkHour * Interval * 60);  //間隔分鐘
                    break;
                default:
                    break;
            }

            ts = DateTimeE - DateTimeB;
            int Minute = Convert.ToInt32(ts.TotalMinutes);
            Vdb.Use = Minute;

            int CheckMinute = (Minute - RestMinute - Deduct);

            Vdb.Min = CheckMinute >= MinMinute;
            Vdb.Interval = (CheckMinute % IntervalMinute) == 0;


            Minute = (Minute - RestMinute - Deduct) >= MinMinute ? Minute : MinMinute;
            int ModMinute = Minute == MinMinute ? 0 : Convert.ToInt32((Minute - RestMinute - Deduct) % IntervalMinute);
            if (ModMinute > 0)
                ModMinute = IntervalMinute - ModMinute;
            Minute = (Minute - RestMinute - Deduct) + ModMinute;

            //再判斷一次 是否小於最小單位 2015/12/30 BY MING
            Minute = (Minute >= MinMinute) ? Minute : MinMinute;


            decimal Cal = 0;
            switch (Unit)
            {
                case MultiEnum.HoliDayUnit.Minute:
                    Cal = Minute;
                    Cal = Cal > (WorkHour * 60m) ? (WorkHour * 60m) : Cal;
                    Vdb.Use = Vdb.Use;
                    Vdb.CalAfterUse = Cal;
                    break;
                case MultiEnum.HoliDayUnit.Hour:
                    Cal = Minute / 60M;
                    if (CalculateWorkTime)
                        Cal = Cal > WorkHour ? WorkHour : Cal; //大於工作時數就用工作時數計算

                    Vdb.Use = Vdb.Use / 60M;
                    Vdb.CalAfterUse = Cal;
                    break;
                case MultiEnum.HoliDayUnit.Day:
                    Cal = Convert.ToDecimal(Minute / 60M / WorkHour);
                    Cal = Cal > 1 ? 1 : Cal; //大於一天就用一天計算

                    Vdb.Use = Vdb.Use / 60M / WorkHour;
                    Vdb.CalAfterUse = Cal;
                    break;
                default:
                    break;
            }

            return Vdb;
        }

        /// <summary>
        /// 取得HoliDayUnit的列舉
        /// </summary>
        /// <param name="HoliDayUnit"></param>
        /// <returns>HoliDayUnit</returns>
        public HoliDayUnit GetHoliDayUnitEnum(string HoliDayUnit = "1")
        {
            HoliDayUnit enumHoliDayUnit = MultiEnum.HoliDayUnit.Hour;
            switch (HoliDayUnit)
            {
                case "1":
                    enumHoliDayUnit = MultiEnum.HoliDayUnit.Hour;
                    break;
                case "2":
                    enumHoliDayUnit = MultiEnum.HoliDayUnit.Day;
                    break;
                case "3":
                    enumHoliDayUnit = MultiEnum.HoliDayUnit.Minute;
                    break;
                case "4":
                    enumHoliDayUnit = MultiEnum.HoliDayUnit.Month;
                    break;
                case "5":
                    enumHoliDayUnit = MultiEnum.HoliDayUnit.Year;
                    break;
            }

            return enumHoliDayUnit;
        }

        /// <summary>
        /// 轉換天、小時、分鐘
        /// </summary>
        /// <param name="Use">使用數</param>
        /// <param name="HoliDayUnit">假別單位</param>
        /// <param name="DayWorkHour">一天之時數</param>
        /// <param name="DayWorkMinute">一天之分鐘數</param>
        /// <returns>AbsDayHourMinuteRow</returns>
        public DayHourMinuteRow ConvertTimeUse(decimal Use, int HoliDayUnit = 1, decimal DayWorkHour = 8, int DayWorkMinute = 480)
        {
            HoliDayUnit enumHoliDayUnit = GetHoliDayUnitEnum(HoliDayUnit.ToString());
            return ConvertTimeUse(Use, enumHoliDayUnit, DayWorkHour, DayWorkMinute);
        }

        /// <summary>
        /// 轉換天、小時、分鐘
        /// </summary>
        /// <param name="Use">使用數</param>
        /// <param name="enumHoliDayUnit">假別單位</param>
        /// <param name="DayWorkHour">一天之時數</param>
        /// <param name="DayWorkMinute">一天之分鐘數</param>
        /// <returns>AbsDayHourMinuteRow</returns>
        public DayHourMinuteRow ConvertTimeUse(decimal Use, HoliDayUnit enumHoliDayUnit = HoliDayUnit.Hour, decimal DayWorkHour = 8, int DayWorkMinute = 480)
        {
            var Vdb = new DayHourMinuteRow();
            Vdb.Day = 0;
            Vdb.Hour = 0;
            Vdb.Minute = 0;

            switch (enumHoliDayUnit)
            {
                case HoliDayUnit.Minute:
                    Vdb.Day = (Use / DayWorkMinute) >= 1 ? Convert.ToInt32(Math.Floor(Use / DayWorkMinute)) : 0;
                    if (Vdb.Day > 0)
                        Use -= (Vdb.Day * DayWorkMinute);

                    Vdb.Hour = (Use / 60) >= 1 ? Convert.ToInt32(Math.Floor(Use / 60)) : 0;
                    if (Vdb.Hour > 0)
                        Use -= (Vdb.Hour * 60);

                    Vdb.Minute = Use;
                    break;

                case HoliDayUnit.Hour:
                    Vdb.Day = (Use / DayWorkHour) >= 1 ? Convert.ToInt32(Math.Floor(Use / DayWorkHour)) : 0;
                    if (Vdb.Day > 0)
                        Use -= (Vdb.Day * DayWorkHour);

                    Vdb.Hour = Use;
                    break;
                case HoliDayUnit.Day:
                    Vdb.Day = Use;
                    break;
            }

            return Vdb;
        }
    }
}
