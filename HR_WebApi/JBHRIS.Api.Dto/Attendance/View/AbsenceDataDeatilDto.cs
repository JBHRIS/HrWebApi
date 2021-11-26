using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Attendance.View
{
    public class AbsenceDataDeatilDto
    {
        public string Nobr { get; set; }
        public DateTime ADate { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string HCode { get; set; }
        public string HType { get; set; }
        public decimal Total { get; set; }
        public bool Che { get; set; } //檢查剩餘時數
        public decimal AbsUnit { get; set; } //間格數
        public decimal Minnum { get; set; } //最小數
        public decimal WorkHours { get; set; } //當日工作時數
        public string Unit { get; set; }
        public string Note { get; set; }
    }
}
