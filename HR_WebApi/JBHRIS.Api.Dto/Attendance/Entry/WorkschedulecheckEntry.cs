using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class WorkschedulecheckEntry
    {
        public List<string> EmployeeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}