using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class UpdateAttendRoteEntry
    {
        public string EmployeeId { get; set; }
        public DateTime AttendDate { get; set; }
        public string RoteCode { get; set; }
    }
}
