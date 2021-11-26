using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Larcode
    {
        public string RateCode { get; set; }
        public string RateName { get; set; }
        public decimal Normalrate { get; set; }
        public decimal Losjobrate { get; set; }
        public decimal Jobaccrate { get; set; }
        public decimal Selfcharge { get; set; }
        public decimal Compcharge { get; set; }
        public decimal Partial { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public DateTime Adate { get; set; }
    }
}
