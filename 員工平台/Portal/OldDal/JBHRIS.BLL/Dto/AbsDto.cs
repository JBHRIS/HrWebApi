using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AbsDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string HolidayCode { get; set; }
        public string HolidayName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public Decimal Taken { get; set; }
        public string YYMM { get; set; }
        public string Remark { get; set; }
        public string SerialNumber { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
        public string ID { get; set; }
    }
}
