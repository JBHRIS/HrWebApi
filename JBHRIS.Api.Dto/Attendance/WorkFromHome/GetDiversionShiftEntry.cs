using System;
using System.Collections.Generic;

namespace HR_WebApi.Dto.Attendance
{
    public class GetDiversionShiftEntry
    {
        public List<string> DiversionGroupList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}