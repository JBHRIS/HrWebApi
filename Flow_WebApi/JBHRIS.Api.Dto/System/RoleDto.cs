using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class RoleDto
    {
        public string RoleID { get; set; }

        public string ParentID { get; set; }

        public string DeptID { get; set; }

        public string PostDeptID { get; set; }

        public DateTime? DateB { get; set; }

        public DateTime? DateE { get; set; }

        public string EmpID { get; set; }

        public bool mgDefault { get; set; }

        public bool deptMg { get; set; }

        public int Sort { get; set; }
    }
    public class RoleRow
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
