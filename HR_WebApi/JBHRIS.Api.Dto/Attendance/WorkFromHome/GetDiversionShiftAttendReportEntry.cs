using System;
using System.Collections.Generic;

namespace HR_WebApi.Controllers.Attendance
{
    public class GetDiversionShiftAttendReportEntry
    {
        public List<string> EmployeeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}