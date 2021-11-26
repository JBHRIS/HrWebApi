using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AbsEntitleDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string HolidayCode { get; set; }
        public string HolidayName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal Entitle { get; set; }
        public Decimal Taken { get; set; }
        public Decimal Balance { get; set; }
        public string Remark { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? PayDate { get; set; }
        public string ID { get; set; }
    }
}
