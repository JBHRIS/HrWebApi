using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetAbsDto
    {
        public string HCode { get; set; }
        public string HName { get; set; }
        public string HCodeUnit { get; set; }
        public bool Mang { get; set; }
        public string Flag { get; set; }
        public decimal TolHours { get; set; }
        public decimal Balance { get; set; }
        public string Htype { get; set; }
        public string HtypeUnit { get; set; }

    }
}
