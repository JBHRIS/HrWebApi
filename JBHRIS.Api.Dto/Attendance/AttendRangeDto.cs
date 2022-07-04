using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class AttendRangeDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendDate { get; set; }
        public DateTime? GetCardOnTime { get; set; }
        public DateTime? GetCardOffTime { get; set; }
    }
}
