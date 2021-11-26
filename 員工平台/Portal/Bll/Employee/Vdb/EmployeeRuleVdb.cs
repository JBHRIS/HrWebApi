using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class EmployeeRuleVdb
    {
    }
    public class EmployeeRuleConditions : DataConditions
    {
        public string employeeId { get; set; }
        public string ruleType { get; set; }
        public DateTime checkDate { get; set; }
    }
    public class EmployeeRuleApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public int auto { get; set; }
            public string nobr { get; set; }
            public string ruleType { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public string value { get; set; }
            public string remark { get; set; }
            public DateTime keyDate { get; set; }
            public string keyMan { get; set; }
        }
        public List<Result> result { get; set; }
    }
    public class EmployeeRuleRow
    {
        public int auto { get; set; }
        public string nobr { get; set; }
        public string ruleType { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public string value { get; set; }
        public string remark { get; set; }
        public DateTime keyDate { get; set; }
        public string keyMan { get; set; }
    }
}
