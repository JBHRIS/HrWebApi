using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetPayslipTitleDto
    {
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
