using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CancelLeaveApplyDto
    {
        public string EmployeeId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        /// <summary>
        /// 銷假時數
        /// </summary>
        public decimal Taken { get; set; }
        public string Guid { get; set; }
        public string YYMM { get; set; }

    }
}
