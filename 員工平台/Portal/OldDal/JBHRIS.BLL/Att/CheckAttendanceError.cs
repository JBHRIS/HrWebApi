using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class CheckAttendanceError
    {
        public string HolidayCode = "00";
        /// <summary>
        /// 判斷異常
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public virtual bool CheckError(Dto.AttendanceInfoDto attendance)
        {
            bool IsError = false;
            IsError = checkError(attendance);
            if (attendance.FlexibleMins > 0 && attendance.LateMinutes > 0)
            {
                int mins = attendance.LateMinutes;
                if (attendance.LateMinutes < attendance.FlexibleMins)
                {
                    mins = attendance.LateMinutes;
                }
                var newWorkTimes = new List<Tuple<DateTime, DateTime>>();
                foreach (var it in attendance.WorkTimes)
                {
                    //it.Item1 = it.Item1.AddMinutes(mins);
                    //it.Item2 = it.Item2.AddMinutes(mins);
                    var r = new Tuple<DateTime, DateTime>(it.Item1.AddMinutes(mins), it.Item2.AddMinutes(mins));
                    newWorkTimes.Add(r);
                }
                attendance.WorkTimes = newWorkTimes;
                IsError = checkError(attendance);
            }
            return IsError;
        }
        bool checkError(Dto.AttendanceInfoDto attendance)
        {
            bool IsError = false;
            int i = 0;
            var attTimes = attendance.CardTimes.Select(p => new Tuple<DateTime, DateTime>(p.BeginTime.Value, p.EndTime == null ? p.BeginTime.Value : p.EndTime.Value)).ToList().Union(attendance.AbsTimes).ToList();
            var attTimesFixed = ReBindAttend(attTimes);
            var OriginalWorktimes = GetAbsenteeismList(attendance.WorkTimes, attendance.RestTimes);
            var FixWorktimes = GetAbsenteeismList(OriginalWorktimes.Union(attendance.OverTimes).ToList(), attendance.AbsTimes.Union(attTimesFixed).ToList());//AttError.WorkTimes已經扣過RestTimes,所以只處理AbsTimes
            if (attendance.RoteCode == HolidayCode)//假日判斷
            {
                FixWorktimes = GetAbsenteeismList(attendance.WorkTimes.Union(attendance.OverTimes).ToList(), attendance.AbsTimes.Union(attendance.OtRestTimes).ToList());
            }

            var AbsenteeismTimes = GetAbsenteeismList(FixWorktimes, attendance.CardTimes.Where(pp => pp.BeginTime != null && pp.EndTime != null).Select(pp => new Tuple<DateTime, DateTime>(pp.BeginTime.Value, pp.EndTime.Value)).ToList());

            var FixOvertimes = GetAbsenteeismList(attendance.OverTimes, attendance.OtRestTimes);
            i = 0;
            foreach (var it in FixOvertimes)//無完整加班刷卡
            {
                i++;
                if (it.Item1 == it.Item2) continue;
                var chkWorkTimes = attendance.CardTimes.Where(p => p.EndTime != null && p.BeginTime <= it.Item1 && p.EndTime >= it.Item2);
                if (!chkWorkTimes.Any())
                {
                    IsError = true;
                    attendance.Remark += string.Format("無完整加班刷卡({0});", i);
                    break;
                }
            }
            attendance.LateMinutes = 0;
            attendance.EarilyMinutes = 0;
            attendance.Absenteeism = false;
            if (attendance.CheckError)
            {
                if (FixWorktimes.Any())//遲到早退判斷
                    foreach (var it in AbsenteeismTimes)
                    {
                        if (FixWorktimes.First().Item1 == it.Item1)
                        {
                            JBTools.Intersection its = new JBTools.Intersection();
                            its.Inert(it.Item1, it.Item2);
                            if (attendance.CardList.Where(p => p.CardTime <= it.Item1).Any())
                                attendance.EarilyMinutes += Convert.ToInt32(its.GetMinutes());
                            else
                                attendance.LateMinutes += Convert.ToInt32(its.GetMinutes());
                        }
                        else if (FixWorktimes.Last().Item2 == it.Item2)
                        {
                            JBTools.Intersection its = new JBTools.Intersection();
                            its.Inert(it.Item1, it.Item2);
                            if (!attendance.CardList.Where(p => p.CardTime <= it.Item1).Any())
                                attendance.LateMinutes += Convert.ToInt32(its.GetMinutes());
                            else
                                attendance.EarilyMinutes += Convert.ToInt32(its.GetMinutes());
                        }
                        else//其餘都算遲到
                        {
                            var AbsenteeismWorkTimes = FixWorktimes.Where(p => p.Item1 < it.Item2 && p.Item2 > it.Item1);
                            if (AbsenteeismWorkTimes.Any() && AbsenteeismWorkTimes.First().Item1 != it.Item1)//不是從班別開始時間就缺曠的話,就算早退
                            {
                                JBTools.Intersection its = new JBTools.Intersection();
                                its.Inert(it.Item1, it.Item2);
                                attendance.EarilyMinutes += Convert.ToInt32(its.GetMinutes());
                            }
                            else
                            {
                                JBTools.Intersection its = new JBTools.Intersection();
                                its.Inert(it.Item1, it.Item2);
                                attendance.EarilyMinutes += Convert.ToInt32(its.GetMinutes());
                            }
                        }
                    }
                //var mergerWorktimes = ReBindAttend(attendance.WorkTimes.Union(attendance.OverTimes).ToList());

                //var checkRepeatCard = ReBindAttend(FixWorktimes.Union(FixOvertimes).ToList());

                //if (attendance.LateMinutes > 30 || attendance.EarilyMinutes > 30)
                //    attendance.Absenteeism = true;
                if (attendance.RoteCode != "00" && !attendance.CardList.Any() && !attendance.AbsTimes.Any())
                {
                    attendance.Absenteeism = true;
                    attendance.LateMinutes = 0;
                    attendance.EarilyMinutes = 0;
                }
            }
            if (attendance.Absenteeism || attendance.LateMinutes > 0 || attendance.EarilyMinutes > 0)
                IsError = true;
            return IsError;
        }

        private List<Tuple<DateTime, DateTime>> GetAbsenteeismList(List<Tuple<DateTime, DateTime>> AcceptInterval, List<Tuple<DateTime, DateTime>> SkipInterval)
        {
            return JBTools.DataTransform.GetAbsenteeismList(AcceptInterval, SkipInterval);
        }

        private List<Tuple<DateTime, DateTime>> ReBindAttend(List<Tuple<DateTime, DateTime>> attTimes)
        {
            return JBTools.DataTransform.ReBindAttend(attTimes);
        }
    }
}
