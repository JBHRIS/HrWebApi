using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AbsEntitleCondition
    {
        public List<string> EmployeeList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public List<string> HolidayCodeList { get; set; }
    }
}
