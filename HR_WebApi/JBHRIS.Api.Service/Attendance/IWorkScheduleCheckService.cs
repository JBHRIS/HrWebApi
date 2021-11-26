using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance
{
    public interface IWorkScheduleCheckService
    {
        ApiResult<List<WorkScheduleIssueDto>> Check(WorkScheduleCheckEntry workScheduleCheckEntry);
        List<ScheduleTypeDto> GetScheduleTypeList();
        Dictionary<string, List<WorkScheduleDto>> GetWorkScheduleList(WorkschedulecheckEntry workschedulecheckEntry);
        ApiResult<List<WorkScheduleIssueDto>> CheckWithQuery(WorkScheduleCheckEntry workScheduleCheckEntry);
    }
}
