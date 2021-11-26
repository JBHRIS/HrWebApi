using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public interface IAttendanceService
    {
         List<AttendanceDto> GetAttendance(AttendanceRoteEntry attendanceEntry);

         List<RoteChangeDto> GetRoteChange(AttendanceRoteEntry attendanceEntry);

         List<string> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry);

        List<string> GetPeopleWork(AttendanceRoteEntry attendanceEntry);

        List<RoteDto> GetRote();
    }
}