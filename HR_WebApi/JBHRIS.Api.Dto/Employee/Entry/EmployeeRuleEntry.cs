using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class EmployeeRuleEntry
    {
        public string EmployeeId { get; set; }
        public string RuleType { get; set; }
        public DateTime CheckDate { get; set; }
    }
}
