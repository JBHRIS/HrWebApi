using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class GetPeopleByDeptEntry
    {
        public List<string> deptList { get; set; }
        public DateTime checkDate { get; set; }
    }
}
