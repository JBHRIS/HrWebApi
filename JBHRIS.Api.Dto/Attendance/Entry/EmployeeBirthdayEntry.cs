using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class EmployeeBirthdayEntry
    {
        public List<string> employeeList { get; set; }
        public int[] months { get; set; }
    }
}
