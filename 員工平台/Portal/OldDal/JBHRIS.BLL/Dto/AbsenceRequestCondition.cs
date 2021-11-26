using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AbsenceRequestCondition
    {
        public string EmployeeID { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public string LeaveCode { get; set; }
        public string YYMM { get; set; }
        public string SerialNumber { get; set; }
        public string Remark { get; set; }
        public decimal CustomizeTaken { get; set; }

    }
}
