using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class RoleVdb
    {
    }
    public class RoleConditions : DataConditions
    {
        public List<string> EmpId { get; set; }
    }
    public class RoleApiRow : StandardDataBaseApiRow
    {
        public class result
        {
            public string RoleID { get; set; }
            public string ParentID { get; set; }
            public string DeptID { get; set; }
            public string PostDeptID { get; set; }
            public DateTime DateB { get; set; }
            public DateTime DateE { get; set; }
            public string EmpID { get; set; }
            public bool mgDefault { get; set; }
            public bool deptMg { get; set; }
            public int Sort { get; set; }
        }
        public List<result> Result { get; set; }
    }
    public class RoleRow
    {
        public string RoleID { get; set; }
        public string ParentID { get; set; }
        public string DeptID { get; set; }
        public string PostDeptID { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public string EmpID { get; set; }
        public bool mgDefault { get; set; }
        public bool deptMg { get; set; }
        public int Sort { get; set; }
    }
}
