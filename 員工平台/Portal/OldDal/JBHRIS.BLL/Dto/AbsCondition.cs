using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class AbsCondition
    {
        public AbsCondition()
        {
            EmployeeList = new List<string>();
            HolidayCodeList = new List<string>();
        }
        public List<string> EmployeeList { get; set; }
        public List<string> HolidayCodeList { get; set; }
        public bool CheckByTime { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public bool CheckByYYMM { get; set; }
        public string YYMMBegin { get; set; }
        public string YYMMEnd { get; set; }
    }
}
