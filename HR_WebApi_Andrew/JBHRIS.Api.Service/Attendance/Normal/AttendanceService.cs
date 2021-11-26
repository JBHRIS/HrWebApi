using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AttendanceService : IAttendanceService
    {
        public List<AttendanceDto> GetAttendance(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public List<string> GetPeopleAbnormal(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public List<string> GetPeopleWork(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }

        public List<RoteDto> GetRote()
        {
            throw new NotImplementedException();
        }

        public List<RoteChangeDto> GetRoteChange(AttendanceRoteEntry attendanceEntry)
        {
            throw new NotImplementedException();
        }
    }
}
