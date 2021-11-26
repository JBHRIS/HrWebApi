using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Harcode
    {
        public string RateCode { get; set; }
        public string RateName { get; set; }
        public decimal Selfcharge { get; set; }
        public decimal Compcharge { get; set; }
        public decimal Partial { get; set; }
        public decimal FixAmt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public DateTime Adate { get; set; }
        public decimal Nopaytop { get; set; }
    }
}
