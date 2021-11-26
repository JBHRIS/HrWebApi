using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.Entry
{
    public class OvertimeApplyDto
    {
        public string EmployeeId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string Type { get; set; }
        public string OvertimeReason { get; set; }
        public string Remark { get; set; }
    }
}
