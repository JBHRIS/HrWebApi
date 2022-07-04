using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class AttendRangeEntryDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendDate { get; set; }
        public string OffTime2 { get; set; }
    }
}
