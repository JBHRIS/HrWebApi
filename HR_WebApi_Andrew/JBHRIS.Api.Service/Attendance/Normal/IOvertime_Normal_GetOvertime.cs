using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IOvertime_Normal_GetOvertime
    {
        List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry);
    }
}