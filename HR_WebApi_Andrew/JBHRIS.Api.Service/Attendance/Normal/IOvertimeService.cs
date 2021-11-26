using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IOvertimeService
    {
        List<OvertimeDto> GetOvertime(AttendanceEntry attendanceEntry);
        List<string> GetPeopleOvertime(AttendanceEntry attendanceEntry);
        List<OvertimeTypeDto> GetOvertimeType();
        List<OvertimeReasonDto> GetOvertimeReason();
    }
}