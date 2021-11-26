using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetSalaryChangeDto
    {
        public string Nobr { get; set; }
        public string SalCode { get; set; }
        public string SalName { get; set; }
        public decimal Amt { get; set; }
    }
}
