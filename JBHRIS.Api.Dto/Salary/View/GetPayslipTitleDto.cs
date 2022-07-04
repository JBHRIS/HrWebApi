using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetPayslipTitleDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string DeptDispName { get; set; }
        public string JobCode { get; set; }
        public string JobDispName { get; set; }
        public string JobName { get; set; }
        public DateTime Adate { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public DateTime SalDateB { get; set; }
        public DateTime SalDateE { get; set; }
        public DateTime? AttDateB { get; set; }
        public DateTime? AttDateE { get; set; }
        public string Note { get; set; }
    }
}
