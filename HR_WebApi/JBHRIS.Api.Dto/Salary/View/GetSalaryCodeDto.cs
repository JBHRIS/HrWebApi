using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetSalaryCodeDto
    {
        public string SalCode1 { get; set; }
        public string SalCodeDisp { get; set; }
        public string SalName { get; set; }
        public string SalAttr { get; set; }
        public int Sort { get; set; }
    }
}
