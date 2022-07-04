using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetEmployeSalAttEndDayDto
    {
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Saladr { get; set; }
        public string Comp { get; set; }
        public int AttEndDay { get; set; }
        public int SalEndDay { get; set; }
        public string GroupName { get; set; }
    }
}
