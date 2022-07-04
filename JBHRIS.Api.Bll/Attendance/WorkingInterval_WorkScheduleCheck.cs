using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHRIS.Api.Dto.Attendance;
using NLog;

namespace JBHRIS.Api.Bll.Attendance
{
    public class WorkingInterval_WorkScheduleCheck : IWorkScheduleCheck
    {
        private ILogger _logger;

        public WorkingInterval_WorkScheduleCheck()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public WorkingInterval_WorkScheduleCheck(ILogger logger)
        {
            _logger = logger;
        }
        bool IsHoliday(string ScheduleType)
        {
            return new string[] { "00", "0X", "0Z" }.Contains(ScheduleType);
        }
        ScheduleTypeDto GetScheduleType(string ScheduleType, List<ScheduleTypeDto> scheduleTypeDtos)
        {
            return scheduleTypeDtos.FirstOrDefault(p => p.Code.Trim().ToUpper() == ScheduleType.Trim().ToUpper());
        }
        public WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
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
            //workScheduleCheck.WorkSchedules = workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).ToList();
            WorkScheduleDto preWorkSchedule = null;
            foreach (var workSchedule in workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate))
            {
                _logger.Trace(preWorkSchedule);
                if (preWorkSchedule != null)//比對前一個班之間的休息時間，所以必須要前一個班
                {
                    if (!IsHoliday(preWorkSchedule.ScheduleType))//前一個班是假日也不需要判斷
                    {
                        if (!IsHoliday(workSchedule.ScheduleType))//今天的班是假日也不需要判斷
                        {
                            if (workSchedule.ScheduleType != preWorkSchedule.ScheduleType)//只有換班要判斷
                            {
                                var preScheduleType = GetScheduleType(preWorkSchedule.ScheduleType, workScheduleCheck.ScheduleTypes);
                                var currentScheduleType = GetScheduleType(workSchedule.ScheduleType, workScheduleCheck.ScheduleTypes);
                                var preOffTime = preWorkSchedule.AttendanceDate.AddTime(preScheduleType.OffTime);
                                var currentOntime = workSchedule.AttendanceDate.AddTime(currentScheduleType.OnTime);
                                var restIntervalReal = currentOntime - preOffTime;
                                var restIntervalSet = new TimeSpan(0, Convert.ToInt32(currentScheduleType.Interval * 60), 0);
                                if (restIntervalReal < restIntervalSet)
                                {
                                    result.State = false;
                                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
                                    {
                                        IssueDate = workSchedule.AttendanceDate,
                                        CheckType = CheckType,
                                        ErrorCode = "CIT_LOW_REST",
                                        ErrorMessage = string.Format("日期{0}與前一日排班的間隔低於{1}小時({2}).", workSchedule.AttendanceDate.ToString("yyyy-MM-dd"), currentScheduleType.Interval, Math.Round(restIntervalReal.TotalHours, 1, MidpointRounding.AwayFromZero)),
                                    });
                                }
                            }
                        }
                    }
                }
                preWorkSchedule = workSchedule;
            }
            //TimeSpan interval = new TimeSpan(24, 0, 0);
            //for (int i = 0; i < workScheduleCheck.WorkSchedules.Count; i++)
            //{
            //    WorkScheduleDto work = workScheduleCheck.WorkSchedules[i];
            //    ScheduleTypeDto stype = workScheduleCheck.ScheduleTypes.Where(p => p.Code == work.ScheduleType).FirstOrDefault();
            //    WorkScheduleDto prework = new WorkScheduleDto();//= workScheduleCheck.WorkSchedules[i - 1];
            //    if (i > 0 && workScheduleCheck.WorkSchedules[i - 1].AttendanceDate.AddDays(1) == work.AttendanceDate)
            //        prework = workScheduleCheck.WorkSchedules[i - 1];

            //    if (stype != null && work.AttendanceDate >= workScheduleCheck.BeginCheckDate)
            //    {
            //        if (stype.AttenType == "00" || stype.AttenType == "0X" || stype.AttenType == "0Z")
            //            interval += new TimeSpan(24, 0, 0);
            //        else
            //        {
            //            interval += String48HRtoTimespan(stype.OnTime);//stype.OnTime;
            //            if (prework != null)
            //            {
            //                if ((decimal)interval.TotalHours < stype.Interval
            //                    && work.AttendanceDate >= workScheduleCheck.BeginCheckDate && work.AttendanceDate <= workScheduleCheck.EndCheckDate)
            //                {
            //                    result.State = false;
            //                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
            //                    {
            //                        IssueDate = work.AttendanceDate,
            //                        CheckType = CheckType,
            //                        ErrorCode = "CIT",
            //                        ErrorMessage = string.Format("日期{0}班別{1}與前一日排班的間隔低於{2}小時.", work.AttendanceDate.ToString("yyyy-MM-dd"), stype.Code, stype.Interval),
            //                    });
            //                }
            //            }
            //            interval = new TimeSpan(24, 0, 0) - String48HRtoTimespan(stype.OffTime); ;//stype.OffTime;
            //        }
            //    }
            //}
            return result;
        }

        private TimeSpan String48HRtoTimespan(string TimeString)
        {
            int result = 0;
            TimeSpan timeSpan = new TimeSpan();
            if (int.TryParse(TimeString, out result))
            {
                timeSpan = new TimeSpan(result / 100, result % 100, 0);
            }
            return timeSpan;
        }
    }
}
