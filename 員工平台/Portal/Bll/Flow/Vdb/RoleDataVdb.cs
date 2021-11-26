using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class RoleDataVdb
    {
    }
    public class RoleDataConditions : DataConditions
    {
        public string idEmp { get; set; }
        public string idRole { get; set; }
    }
    public class RoleDataApiRow : StandardDataBaseApiRow
    {
        public class result
        {
            public string RoleId { get; set; }
            public string RoleName { get; set; }
            public string EmpId { get; set; }
            public string EmpName { get; set; }
            public string DeptId { get; set; }
            public string DeptName { get; set; }
            public string PosId { get; set; }
            public string PosName { get; set; }
            public bool Manage { get; set; }
        }
        public List<result> Result { get; set; }
    }
    public class RoleDataRow
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptId { get; set; }
        public string DeptName { get; set; }
        public string PosId { get; set; }
        public string PosName { get; set; }
        public bool Manage { get; set; }
    }
}
