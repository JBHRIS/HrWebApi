using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBHRIS.Api.Dto.Attendance;
using NLog;

namespace JBHRIS.Api.Bll.Attendance
{
    public class ContinuouslyWorking_WorkScheduleCheck : IWorkScheduleCheck
    {
        public ContinuouslyWorking_WorkScheduleCheck()
        {
        }
        int ContinouslyWorkingDaysSet = 7;
        //public ILogger _logger;
        bool IsHoliday(string ScheduleType)
        {
            return new string[] { "0X", "0Z" }.Contains(ScheduleType);//國定假日不可為中斷未七休一用
        }
        public WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if(workScheduleCheck==null)
            {
                result.State = false;
                //_logger.Warn("workScheduleCheck未設定");
                return result;
            }
            var ContinouslyWorkingDays = 0;
            foreach (var WorkSchedule in workScheduleCheck.WorkSchedules.OrderBy(p => p.AttendanceDate))
            {
                ContinouslyWorkingDays++;

                var scheduleType = workScheduleCheck.ScheduleTypes.FirstOrDefault(p => p.Code == WorkSchedule.ScheduleType);
                if (scheduleType != null && IsHoliday(scheduleType.AttenType.Trim()))
                {
                    ContinouslyWorkingDays = 0;
                }

                if (ContinouslyWorkingDays >= ContinouslyWorkingDaysSet)
                {
                    result.State = false;
                    result.workScheduleIssues.Add(new WorkScheduleIssueDto
                    {
                        IssueDate = WorkSchedule.AttendanceDate,
                        CheckType = CheckType,
                        ErrorCode = "CW7",
                        ErrorMessage = string.Format("{1}連續工作第{0}天", ContinouslyWorkingDays, WorkSchedule.AttendanceDate),
                    });
                }
            }
            return result;
        }
    }
}
