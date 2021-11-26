using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class OtDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public Decimal TotalHours { get; set; }
        public Decimal OtHours { get; set; }
        public Decimal RestHours { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonDescription { get; set; }
        public string Remark { get; set; }
    }
}
