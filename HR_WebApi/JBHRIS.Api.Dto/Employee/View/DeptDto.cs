using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.View
{
    public class DeptDto
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameE { get; set; }
        public string DepartmentParentId { get; set; }
        public string DepartmentManager { get; set; }
        public string DepartmentIdDisplay { get; set; }
        public string DepartmentLevel { get; set; }
        public string DirectorEmployeeId { get; set; }
        public string DirectorEmployeeName { get; set; }
    }
}