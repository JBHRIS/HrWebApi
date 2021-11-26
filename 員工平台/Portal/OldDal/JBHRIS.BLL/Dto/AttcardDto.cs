using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AttcardDto
    {
        public string EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool OnTimeForget { get; set; }
        public bool OffTimeForget { get; set; }
        //public List<Tuple<DateTime?, DateTime?>> CardTimes { get; set; }
        public bool CantModify { get; set; }
        public string CreateMan { get; set; }
    }
}
