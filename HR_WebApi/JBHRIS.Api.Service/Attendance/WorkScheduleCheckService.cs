using JBHRIS.Api.Dal.Attendance;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;


namespace JBHRIS.Api.Service.Attendance
{
    public class WorkScheduleCheckService : IWorkScheduleCheckService
    {
        private IWorkScheduleFactory _workScheduleFacotry;
        private IWorkscheduleCheck_ScheduleTypeRepository _workscheduleCheck_ScheduleTypeRepository;
        private ICalendarHolidayRepository _calendarHolidayRepository;
        private ILogger _logger;

        public WorkScheduleCheckService(IWorkScheduleFactory workScheduleFacotry, IWorkscheduleCheck_ScheduleTypeRepository workscheduleCheck_ScheduleTypeRepository, ICalendarHolidayRepository calendarHolidayRepository, NLog.ILogger logger)
        {
            _workScheduleFacotry = workScheduleFacotry;
            _workscheduleCheck_ScheduleTypeRepository = workscheduleCheck_ScheduleTypeRepository;
            _calendarHolidayRepository = calendarHolidayRepository;
            _logger = logger;
        }
        public ApiResult<List<WorkScheduleIssueDto>> Check(WorkScheduleCheckEntry workScheduleCheckEntry)
        {
            ApiResult<List<WorkScheduleIssueDto>> apiResult = new ApiResult<List<WorkScheduleIssueDto>>();
            apiResult.State = true;
            apiResult.Result = new List<WorkScheduleIssueDto>();
            try
            {
                foreach (var checkType in workScheduleCheckEntry.CheckTypes)
                {
                    var checker = _workScheduleFacotry.Create(checkType);
                    var checkResult = checker.Check(checkType, workScheduleCheckEntry.workScheduleCheck);
                    if (checkResult.workScheduleIssues.Any())
                    {
                        apiResult.State = false;
                        apiResult.Result.AddRange(checkResult.workScheduleIssues);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
            return apiResult;
        }

        public ApiResult<List<WorkScheduleIssueDto>> CheckWithQuery(WorkScheduleCheckEntry workScheduleCheckEntry)
        {
            _logger.Debug("WorkScheduleCheckService.CheckWithQuery輸入條件 => " + JsonConvert.SerializeObject(workScheduleCheckEntry));
            var cloneEntry = JsonConvert.DeserializeObject<WorkScheduleCheckEntry>(JsonConvert.SerializeObject(workScheduleCheckEntry));
            cloneEntry.workScheduleCheck.WorkSchedules.Clear();
            var scheduleTypes = GetScheduleTypeList();
            var workEntry = new WorkschedulecheckEntry
            {
                DateBegin = workScheduleCheckEntry.workScheduleCheck.BeginCheckDate,
                DateEnd = workScheduleCheckEntry.workScheduleCheck.EndCheckDate,
                EmployeeList = new List<string> { workScheduleCheckEntry.workScheduleCheck.EmployeeId },
            };
            var workSchedules = GetWorkScheduleList(workEntry);
            var calendarHolidays = GetCalendarHolidays(workEntry);

            //設定撈取的參考資料
            cloneEntry.workScheduleCheck.ScheduleTypes = scheduleTypes;
            if (workSchedules.Any())
                cloneEntry.workScheduleCheck.WorkSchedules = workSchedules.First().Value;
            if (calendarHolidays.Any())
                cloneEntry.workScheduleCheck.CalendarHolidays = calendarHolidays.First().Value;
            //補上使用者輸入資料，存在就變更班別
            foreach (var att in workScheduleCheckEntry.workScheduleCheck.WorkSchedules)
            {
                if (att.ScheduleType.Trim().Length == 0) continue;
                var ExistAtt = cloneEntry.workScheduleCheck.WorkSchedules.SingleOrDefault(p => p.AttendanceDate == att.AttendanceDate);
                if (ExistAtt == null)
                {
                    var clonAtt = JsonConvert.DeserializeObject<WorkScheduleDto>(JsonConvert.SerializeObject(att));
                    cloneEntry.workScheduleCheck.WorkSchedules.Add(clonAtt);//新增
                }
                else
                {
                    ExistAtt.ScheduleType = att.ScheduleType;//置換
                }
            }

            return Check(cloneEntry);
        }

        private Dictionary<string, List<CalendarHolidayDto>> GetCalendarHolidays(WorkschedulecheckEntry workEntry)
        {
            return _calendarHolidayRepository.GetCalendarHolidayList(workEntry);
        }

        public List<ScheduleTypeDto> GetScheduleTypeList()
        {
            return _workscheduleCheck_ScheduleTypeRepository.GetScheduleTypeList();
        }

        public Dictionary<string, List<WorkScheduleDto>> GetWorkScheduleList(WorkschedulecheckEntry workschedulecheckEntry)
        {
            return _workscheduleCheck_ScheduleTypeRepository.GetWorkScheduleList(workschedulecheckEntry);
        }
    }
}
