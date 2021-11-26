using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class EmployeeJobViewDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string DepartmentName { get; set; }
        public string Job { get; set; }
        public string JobName { get; set; }
    }
}
