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
        public WorkingInterval_WorkScheduleCheck()
        {

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
            workScheduleCheck.WorkSchedules = workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate).ToList();
            TimeSpan interval = new TimeSpan(24, 0, 0);
            for (int i = 0; i < workScheduleCheck.WorkSchedules.Count; i++)
            {
                WorkScheduleDto work = workScheduleCheck.WorkSchedules[i];
                ScheduleTypeDto stype = workScheduleCheck.ScheduleTypes.Where(p => p.Code == work.ScheduleType).FirstOrDefault();
                WorkScheduleDto prework = new WorkScheduleDto();//= workScheduleCheck.WorkSchedules[i - 1];
                if (i > 0 && workScheduleCheck.WorkSchedules[i - 1].AttendanceDate.AddDays(1) == work.AttendanceDate)
                    prework = workScheduleCheck.WorkSchedules[i - 1];

                if (stype != null && work.AttendanceDate >= workScheduleCheck.StartDate)
                {
                    if (stype.AttenType == "00" || stype.AttenType == "0X" || stype.AttenType == "0Z")
                        interval += new TimeSpan(24, 0, 0);
                    else
                    {
                        interval += String48HRtoTimespan(stype.OnTime);//stype.OnTime;
                        if (prework != null)
                        {
                            if ((decimal)interval.TotalHours < stype.Interval
                                && work.AttendanceDate >= workScheduleCheck.BeginCheckDate && work.AttendanceDate <= workScheduleCheck.EndCheckDate)
                            {
                                result.State = false;
                                result.workScheduleIssues.Add(new WorkScheduleIssueDto
                                {
                                    IssueDate = work.AttendanceDate,
                                    CheckType = CheckType,
                                    ErrorCode = "CIT",
                                    ErrorMessage = string.Format("日期{0}班別{1}與前一日排班的間隔低於{2}小時.", work.AttendanceDate.ToString("yyyy-MM-dd"), stype.Code, stype.Interval),
                                });
                            }
                        }
                        interval = new TimeSpan(24, 0, 0) - String48HRtoTimespan(stype.OffTime); ;//stype.OffTime;
                    }
                }
            }
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
