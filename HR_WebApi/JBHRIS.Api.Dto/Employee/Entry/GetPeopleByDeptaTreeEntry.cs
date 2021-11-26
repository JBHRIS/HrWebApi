using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class GetPeopleByDeptaTreeEntry
    {
        public DateTime checkDate { get; set; }
        public bool InCludeManager { get; set; }
    }
}
