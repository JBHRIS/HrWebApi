using JBModule.Data.Linq;
using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class DailyOvertimeHoursLabourCheckRule : ILabourCheckRule
    {

        public Dictionary<string, object> Parameters { get; set; }

        public List<OT_B> ValidateOT(List<OT_B> Source)
        {
            if (Source.Count == 0) return Source;
            DateTime Ddate = Convert.ToDateTime(Parameters["Ddate"]); //截止日期
            string HolidayListStr = Parameters.ContainsKey("HolidayList") ? Parameters["HolidayList"].ToString() : "00, 0Z";
            List<string> HolidayList = HolidayListStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            decimal HolidayMaxWK_hrs = Parameters.ContainsKey("HolidayMaxWK_hrs") ? Convert.ToDecimal(Parameters["HolidayMaxWK_hrs"]) : 8;
            decimal DaylyMaxOT_hrs = Parameters.ContainsKey("DaylyMaxOT_hrs") ? Convert.ToDecimal(Parameters["DaylyMaxOT_hrs"]) : 4;
            List<string> empList1 = Source.GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();

            foreach (var empList in empList1.Split(1000))
            {
                var CheckWorkDays = (from a in db.ATTEND
                                     join b in db.OT on new { a.NOBR, a.ADATE } equals new { b.NOBR, ADATE = b.BDATE }
                                     join r in db.ROTE on a.ROTE_H equals r.ROTE1
                                     where empList.Contains(a.NOBR) && b.YYMM == Source.First().YYMM
                                     select new
                                     {
                                         a.NOBR,
                                         a.ADATE,
                                         a.ROTE,
                                         IsHoliday = HolidayList.Contains(a.ROTE),
                                         ROTE_H = r
                                     }).ToList();

                foreach (var emp in empList)
                {
                    var checkWorkDaysOfEmp = CheckWorkDays.Where(p => p.NOBR == emp).ToList();
                    foreach (var checkWorkDay in checkWorkDaysOfEmp)
                    {
                        var oT_BList_Early = Source.Where(p => p.NOBR == checkWorkDay.NOBR && p.BDATE == checkWorkDay.ADATE && checkWorkDay.ROTE_H.ON_TIME.CompareTo(p.BTIME) > 0).OrderBy(p => p.BTIME);
                        var oT_BList_Late = Source.Where(p => p.NOBR == checkWorkDay.NOBR && p.BDATE == checkWorkDay.ADATE && checkWorkDay.ROTE_H.ON_TIME.CompareTo(p.BTIME) <= 0).OrderBy(p => p.ETIME);
                        decimal Early_Hrs = oT_BList_Early.Any() ? oT_BList_Early.Sum(p => p.TOT_HOURS) : 0;
                        decimal Late_Hrs = oT_BList_Late.Any() ? oT_BList_Late.Sum(p => p.TOT_HOURS) : 0;
                        if (checkWorkDay.IsHoliday)
                        {
                            var oT_BLList_Holiday = Source.Where(p => p.NOBR == checkWorkDay.NOBR && p.BDATE == checkWorkDay.ADATE).OrderBy(p => p.BTIME);
                            if (oT_BLList_Holiday.Any() && oT_BLList_Holiday.Sum(p => p.TOT_HOURS) > HolidayMaxWK_hrs + DaylyMaxOT_hrs)
                            {
                                var Diff_hrs = oT_BLList_Holiday.Sum(p => p.TOT_HOURS) - (HolidayMaxWK_hrs + DaylyMaxOT_hrs);
                                oT_BList_Early = oT_BLList_Holiday.Where(p => checkWorkDay.ROTE_H.ON_TIME.CompareTo(p.BTIME) > 0).OrderBy(p => p.BTIME);
                                oT_BList_Late = oT_BLList_Holiday.Where(p => checkWorkDay.ROTE_H.ON_TIME.CompareTo(p.BTIME) <= 0).OrderBy(p => p.ETIME);
                                int ON_TimeTs = TimeStrTranToTimeSpan(checkWorkDay.ROTE_H.ON_TIME);
                                int OFF_TimeTs = TimeStrTranToTimeSpan(checkWorkDay.ROTE_H.OFF_TIME);
                                foreach (var ot_b in oT_BList_Early)
                                {
                                    if (Diff_hrs < 0)
                                        break;
                                    int BtimeTS = TimeStrTranToTimeSpan(ot_b.BTIME);
                                    int Buffer_hrs = (ON_TimeTs - BtimeTS) / 60;
                                    if (Diff_hrs > Buffer_hrs)
                                    {
                                        Diff_hrs = Diff_hrs - Buffer_hrs;
                                        ot_b.TOT_HOURS = ot_b.TOT_HOURS - Buffer_hrs;
                                    }
                                    else
                                    {
                                        BtimeTS = BtimeTS + (int)(Diff_hrs * 60);
                                        ot_b.BTIME = TimeSpanTranToTimeStr(BtimeTS);
                                        UpdateOT_B_Hrs(ot_b, Diff_hrs);
                                        Diff_hrs = 0;
                                    }
                                }

                                foreach (var ot_b in oT_BList_Late)
                                {
                                    if (Diff_hrs < 0)
                                        break;
                                    int EtimeTS = TimeStrTranToTimeSpan(ot_b.ETIME);
                                    //int Buffer_hrs = (EtimeTS - OFF_TimeTs) / 60;
                                    if (Diff_hrs > ot_b.TOT_HOURS)
                                    {
                                        Diff_hrs = Diff_hrs - ot_b.TOT_HOURS;
                                        Source.Remove(ot_b);
                                    }
                                    else
                                    {
                                        EtimeTS = EtimeTS - (int)(Diff_hrs * 60);
                                        ot_b.ETIME = TimeSpanTranToTimeStr(EtimeTS);
                                        UpdateOT_B_Hrs(ot_b, Diff_hrs);
                                        Diff_hrs = 0;
                                    }
                                }
                            }
                        }
                        else if (Early_Hrs + Late_Hrs > (checkWorkDay.ROTE == "0X" ? DaylyMaxOT_hrs + 8 : DaylyMaxOT_hrs))
                        {
                            decimal Diff_hrs = (Early_Hrs + Late_Hrs) - DaylyMaxOT_hrs;
                            foreach (var ot_b in oT_BList_Early)
                            {
                                if (Diff_hrs <= 0)
                                    break;
                                else if (Diff_hrs >= ot_b.TOT_HOURS)
                                {
                                    Diff_hrs = Diff_hrs - ot_b.TOT_HOURS;
                                    Source.Remove(ot_b);
                                }
                                else
                                {
                                    int BtimeTS = TimeStrTranToTimeSpan(ot_b.BTIME);
                                    BtimeTS = BtimeTS + (int)(Diff_hrs * 60);
                                    ot_b.BTIME = TimeSpanTranToTimeStr(BtimeTS);
                                    UpdateOT_B_Hrs(ot_b, Diff_hrs);
                                    Diff_hrs = 0;
                                }
                            }
                            foreach (var ot_b in oT_BList_Late)
                            {
                                if (Diff_hrs <= 0)
                                    break;
                                else if (Diff_hrs >= ot_b.TOT_HOURS)
                                {
                                    Diff_hrs = Diff_hrs - ot_b.TOT_HOURS;
                                    Source.Remove(ot_b);
                                }
                                else
                                {
                                    int EtimeTS = TimeStrTranToTimeSpan(ot_b.ETIME);
                                    EtimeTS = EtimeTS - (int)(Diff_hrs * 60);
                                    ot_b.ETIME = TimeSpanTranToTimeStr(EtimeTS);
                                    UpdateOT_B_Hrs(ot_b, Diff_hrs);
                                    Diff_hrs = 0;
                                }
                            }
                        }
                    }
                }
            }
            return Source;
        }

        private static void UpdateOT_B_Hrs(OT_B ot_b, decimal Diff_hrs)
        {
            decimal tempInt = ot_b.OT_HRS - Diff_hrs;
            ot_b.OT_HRS = tempInt >= 0 ? tempInt : 0;
            ot_b.REST_HRS = tempInt <= 0 ? ot_b.REST_HRS + tempInt : ot_b.REST_HRS;
            ot_b.TOT_HOURS = ot_b.OT_HRS + ot_b.REST_HRS;
        }

        private int TimeStrTranToTimeSpan(string TimeStr)
        {
            int Result = 0;
            Result = int.Parse(TimeStr) / 100 * 60 + int.Parse(TimeStr) % 100;
            return Result;
        }
        private string TimeSpanTranToTimeStr(int TimeSpan)
        {
            string Result = "0000";
            Result = (TimeSpan / 60 * 100 + TimeSpan % 60).ToString("0000");
            return Result;
        }

    }
}
