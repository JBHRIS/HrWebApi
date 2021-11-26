using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class EmpDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
    public class EmpAttDto : EmpDeptDto
    {
        public bool Card { get; set; }
    }
    public class EmpDeptDto : EmpDto
    {
        public string Dept { get; set; }
        public string DeptName { get; set; }
    }
}
