using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.Attendance
{
    public interface IWorkscheduleCheck_ScheduleTypeRepository
    {
        List<ScheduleTypeDto> GetScheduleTypeList();
        Dictionary<string, List<WorkScheduleDto>> GetWorkScheduleList(WorkschedulecheckEntry workschedulecheckEntry);
    }
}