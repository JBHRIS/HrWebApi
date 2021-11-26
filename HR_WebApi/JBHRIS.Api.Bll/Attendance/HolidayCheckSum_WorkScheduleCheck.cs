using JBHRIS.Api.Dto.Attendance;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Bll.Attendance
{
    public class HolidayCheckSum_WorkScheduleCheck : IWorkScheduleCheck
    {
        private string workDayAttendType = "";//上班日為空白，反之為假日出勤班別
        private ILogger _logger;
        public HolidayCheckSum_WorkScheduleCheck()
        {
            _logger = NLog.LogManager.GetLogger("");
        }
        public HolidayCheckSum_WorkScheduleCheck(ILogger logger)
        {
            _logger = logger;
        }
        public WorkScheduleCheckResult Check(string CheckType, WorkScheduleCheckDto workScheduleCheck)
        {
            _logger.Debug("HolidayCheckSum_WorkScheduleCheck.Check輸入條件 => " + JsonConvert.SerializeObject(workScheduleCheck));
            WorkScheduleCheckResult result = new WorkScheduleCheckResult();
            result.State = true;
            result.workScheduleIssues = new List<WorkScheduleIssueDto>();
            if (workScheduleCheck == null)
            {
                result.State = false;
                _logger.Warn("workScheduleCheck未設定");
                return result;
            }
            List<string> holidayTypeList = new List<string> { "NationalHoliday", "Holiday", "Offday" };

            DateTime BeginCheckDate = new DateTime(workScheduleCheck.BeginCheckDate.Year, workScheduleCheck.BeginCheckDate.Month, 1);
            DateTime EndCheckDate = new DateTime(workScheduleCheck.EndCheckDate.Year, workScheduleCheck.EndCheckDate.Month, DateTime.DaysInMonth(workScheduleCheck.EndCheckDate.Year, workScheduleCheck.EndCheckDate.Month));
            DateTime firstDateOfSchedule = workScheduleCheck.WorkSchedules.Where(p => p.AttendanceDate >= BeginCheckDate).OrderBy(p => p.AttendanceDate).FirstOrDefault().AttendanceDate;
            DateTime lastDateOfSchedule = workScheduleCheck.WorkSchedules.Where(p => p.AttendanceDate <= EndCheckDate).OrderByDescending(p => p.AttendanceDate).FirstOrDefault().AttendanceDate;
            int CalendarHolidayDays = workScheduleCheck.CalendarHolidays.Where(p => p.AttendanceDate >= firstDateOfSchedule && p.AttendanceDate <= lastDateOfSchedule && holidayTypeList.Contains(p.HolidayType)).Count();
            int scheduleHolidayDays = workScheduleCheck.WorkSchedules.Where(p => workScheduleCheck.ScheduleTypes.Any(pp => pp.AttenType != "" && pp.Code == p.ScheduleType)//假日
            && p.AttendanceDate >= firstDateOfSchedule && p.AttendanceDate <= lastDateOfSchedule && p.ScheduleType != workDayAttendType).Count();
            if (CalendarHolidayDays != scheduleHolidayDays)
            {
                result.State = false;
                result.workScheduleIssues.Add(new WorkScheduleIssueDto
                {
                    IssueDate = BeginCheckDate,
                    CheckType = CheckType,
                    ErrorCode = "HW",
                    ErrorMessage = string.Format("{2}~{3}排休天數異常，行事曆{0}天，實際排班{1}天", CalendarHolidayDays, scheduleHolidayDays, firstDateOfSchedule.ToString("yyyy/MM/dd"), lastDateOfSchedule.ToString("yyyy/MM/dd")),
                });
            }
            return result;
        }
    }
}
