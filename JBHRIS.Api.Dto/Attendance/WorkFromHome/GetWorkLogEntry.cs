using System;
using System.Collections.Generic;

namespace HR_WebApi.Dto.Attendance
{
    public class GetWorkLogEntry
    {
        public List<string> EmployeeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}