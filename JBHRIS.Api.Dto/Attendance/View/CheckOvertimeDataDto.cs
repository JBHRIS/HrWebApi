using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class CheckOvertimeDataDto
    {
        public string EmployeeId { get; set; }
        public decimal TotHours { get; set; }
    }
}
