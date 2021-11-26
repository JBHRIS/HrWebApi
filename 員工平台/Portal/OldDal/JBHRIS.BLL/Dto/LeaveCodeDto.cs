using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class LeaveCodeDto
    {
        public LeaveCodeDto()
        {
            CheckConflict = true;
        }
        public string LeaveCode { get; set; }
        public string LeaveCodeDisp { get; set; }
        public string LeaveName { get; set; }
        public string LeaveType { get; set; }
        public string Unit { get; set; }
        public decimal Min { get; set; }
        public decimal Interval { get; set; }
        public bool IncludeHoliday { get; set; }
        public bool CheckBalance { get; set; }
        public bool CheckConflict { get; set; }
    }
}
