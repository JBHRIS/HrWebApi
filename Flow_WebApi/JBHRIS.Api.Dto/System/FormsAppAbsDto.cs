using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class FormsAppAbsDto
    {
        
    }
    public class FormsAppAbsUseDto
    {
        public string EmpId { get; set; }
        public string ProcessId { get; set; }
        public decimal Use { get; set; }
        public string Unit { get; set; }
        public string HCode { get; set; }
        public string HName { get; set; }
    }
}
