using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class EmployeeRuleDto
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public string RuleType { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
