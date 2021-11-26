using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class SalaryChangeInfoDto
    {
        public string EmployeeId { get; set; }
        public string SalaryCode { get; set; }
        public DateTime ChageDate { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public string CreateMan { get; set; }
    }
}
