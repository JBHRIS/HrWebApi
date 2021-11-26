using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHRIS.Api.Dto.Attendance;

namespace JBHRIS.Api.Bll.Attendance
{
    public class DeformationTimeNW_WorkScheduleCheck : IWorkScheduleCheck
    {
        public DeformationTimeNW_WorkScheduleCheck()
        {

        }
        string Holiday = "0Z";
        string OffDay = "0X";
        public int NWeeksNHolidays_Weeks { set; get; } = 1;
        public int NWeeksNHolidays_Holidays { set; get; } = 1;
        public int NWeeksNHolidaysNOffdays_Weeks { set; get; } = 1;
        public int NWeeksNHolidaysNOffdays_Holidays { set; get; } = 1;
        public int NWeeksNHolidaysNOffdays_Offdays { set; get; } = 1;
        public string Error { set; get; } = "CDT1";

        public virtual WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (workScheduleCheck == null)
            {
                result.State = false;
                //_logger.Warn("workScheduleCheck未設定");
                return result;
            }

            workScheduleCheck.WorkSchedules = workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).ToList();
            var weekGroupNo_WorkSchedules_Holiday = from a in workScheduleCheck.WorkSchedules
                                               select new
                                               {
                                                   WeekGroupNumber = decimal.Floor(Convert.ToInt32((a.AttendanceDate - workScheduleCheck.StartDate).TotalDays)
                                                   / (7 * NWeeksNHolidays_Weeks)),
                                                   WorkSchedule = a,
                                               };
            var weekGroupNo_WorkSchedules_Offday = from a in workScheduleCheck.WorkSchedules
                                               select new
                                               {
                                                   WeekGroupNumber = decimal.Floor(Convert.ToInt32((a.AttendanceDate - workScheduleCheck.StartDate).TotalDays)
                                                   / (7 * NWeeksNHolidaysNOffdays_Weeks)),
                                                   WorkSchedule = a,
                                               };
            var WeekGroupSizeOfHoliday = 7 * NWeeksNHolidays_Weeks;
            var WeekGroupSizeOfOffday = 7 * NWeeksNHolidaysNOffdays_Weeks;

            foreach (var weekGroup in weekGroupNo_WorkSchedules_Holiday.GroupBy(p => p.WeekGroupNumber))
            {
                if (weekGroup.Count() == WeekGroupSizeOfHoliday)//少於基本天數，不判斷
                {
                    var DaysOfHolidays = weekGroup.Count(p => p.WorkSchedule.ScheduleType.Trim().ToUpper() == Holiday);
                    if (DaysOfHolidays != NWeeksNHolidays_Holidays)
                    {
                        result.State = false;
                        result.workScheduleIssues.Add(new WorkScheduleIssueDto
                        {
                            IssueDate = weekGroup.First().WorkSchedule.AttendanceDate,
                            CheckType = CheckType,
                            ErrorCode = string.Format("{0}_{1}", Error, Holiday),//"CDT2",
                            ErrorMessage = string.Format("{3}-{4}已違反{0}週需{1}例假日規定({2})."
                            , NWeeksNHolidays_Weeks
                            , NWeeksNHolidays_Holidays
                            , DaysOfHolidays
                            , weekGroup.First().WorkSchedule.AttendanceDate.ToShortDateString()
                            , weekGroup.Last().WorkSchedule.AttendanceDate.ToShortDateString()),
                        });
                    }
                }
            }

            foreach (var weekGroup in weekGroupNo_WorkSchedules_Offday.GroupBy(p => p.WeekGroupNumber))
            {
                if (weekGroup.Count() == WeekGroupSizeOfOffday)//少於基本天數，不判斷
                {
                    var DaysOfOffdays = weekGroup.Count(p => p.WorkSchedule.ScheduleType.Trim().ToUpper() == OffDay);
                    if (DaysOfOffdays != NWeeksNHolidaysNOffdays_Offdays)
                    {
                        result.State = false;
                        result.workScheduleIssues.Add(new WorkScheduleIssueDto
                        {
                            IssueDate = weekGroup.First().WorkSchedule.AttendanceDate,
                            CheckType = CheckType,
                            ErrorCode = string.Format("{0}_{1}", Error, OffDay),//"CDT2",
                            ErrorMessage = string.Format("{3}-{4}已違反{0}週需{1}休息日規定({2})."
                            , NWeeksNHolidaysNOffdays_Weeks
                            , NWeeksNHolidaysNOffdays_Offdays
                            , DaysOfOffdays
                            , weekGroup.First().WorkSchedule.AttendanceDate.ToShortDateString()
                            , weekGroup.Last().WorkSchedule.AttendanceDate.ToShortDateString()),
                        }); ;
                    }
                }
            }
            //int DaysNWN0ZN00 = NWeeksN0ZN00_Weeks * 7;
            //int Temp0Z = NWeeksN0ZN00_0Z;
            //int Temp00 = NWeeksN0ZN00_00;
            //int DaysNWN0Z = NWeeksN0Z_Weeks * 7;
            //int TempNWN0Z = NWeeksN0Z_0Z;

            //foreach (var WorkSchedule in workScheduleCheck.WorkSchedules)
            //{
            //    var scheduleType = workScheduleCheck.ScheduleTypes.FirstOrDefault(p => p.Code == WorkSchedule.ScheduleType);
            //    if (scheduleType != null && scheduleType.AttenType.Trim() == "0Z")
            //    {
            //        TempNWN0Z--;
            //        Temp0Z--;
            //    }

            //    if (scheduleType != null && scheduleType.AttenType.Trim() == "00")
            //        Temp00--;

            //    DaysNWN0Z--;
            //    DaysNWN0ZN00--;

            //    if (DaysNWN0Z == 0)
            //    {
            //        if (TempNWN0Z > 0 && WorkSchedule.AttendanceDate >= workScheduleCheck.BeginCheckDate && WorkSchedule.AttendanceDate <= workScheduleCheck.EndCheckDate)
            //        {
            //            result.State = false;
            //            result.workScheduleIssues.Add(new WorkScheduleIssueDto
            //            {
            //                IssueDate = WorkSchedule.AttendanceDate,
            //                CheckType = CheckType,
            //                ErrorCode = Error,//"CDT2",
            //                ErrorMessage = string.Format("已違反{0}週需{1}例假日規定.", NWeeksN0Z_Weeks, NWeeksN0Z_0Z),
            //            }); ;
            //        }

            //        DaysNWN0Z = NWeeksN0Z_Weeks * 7;
            //        TempNWN0Z = NWeeksN0Z_0Z;
            //    }

            //    if (DaysNWN0ZN00 == 0)
            //    {
            //        if (Temp00 > 0 || Temp0Z > 0 && WorkSchedule.AttendanceDate >= workScheduleCheck.BeginCheckDate && WorkSchedule.AttendanceDate <= workScheduleCheck.EndCheckDate)
            //        {
            //            result.State = false;
            //            result.workScheduleIssues.Add(new WorkScheduleIssueDto
            //            {
            //                IssueDate = WorkSchedule.AttendanceDate,
            //                CheckType = CheckType,
            //                ErrorCode = Error,//"CDT2",
            //                ErrorMessage = string.Format("已違反{0}週需{1}例{2}休規定.", NWeeksN0ZN00_Weeks, NWeeksN0ZN00_0Z, NWeeksN0ZN00_00),
            //            });
            //        }

            //        DaysNWN0ZN00 = NWeeksN0ZN00_Weeks * 7;
            //        Temp0Z = NWeeksN0ZN00_0Z;
            //        Temp00 = NWeeksN0ZN00_00;
            //    }
            //}
            return result;
        }
    }
}
