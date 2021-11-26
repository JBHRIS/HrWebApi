using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class OvertimeDto
    {
        public string EmployeeId { get; set; }
        public DateTime OvertimeDate { get; set; }
        public string BeginTime { get; set; }//48小時制
        public string EndTime { get; set; }//48小時制
        public decimal OvertimeHours { get; set; } //tothours
        public decimal ExpenseHours { get; set; } //othours加班費時數
        public decimal RestHours { get; set; } //resthours補休時數
        public string OvertimeReason { get; set; } //OTRCD
        public string Remark { get; set; }
    }
}
