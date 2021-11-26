using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    public class UserdataVdb
    {
    }

    public class UserdataConditions : DataConditions
    {
    }

    public class UserdataApiRow : StandardDataBaseApiRow
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public List<string> DepartmentExtra { get; set; }
        public string DepartmentName { get; set; }
        public string JobName { get; set; }
        public List<string> DataGroups { get; set; }
        public List<string> Role { get; set; }
        public string Connection { get; set; }
        public UserdataApiRow()
        {
            DepartmentExtra = new List<string>();
        }
    }

    public class UserdataRow: StandardDataRow
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string CompanyCode { get; set; }
        public string DeptName { get; set; }
        public string JobName { get; set; }
        public string Dept { get; set; }
        public string Connection { get; set; }
        public List<string> DeptCode { get; set; }
        public List<string> ListDataGroupsCode { get; set; }
        public List<string> Role { get; set; }
    }
}
