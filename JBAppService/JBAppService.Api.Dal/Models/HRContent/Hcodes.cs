using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Hcodes
    {
        public string HCode { get; set; }
        public string SalCode { get; set; }
        public decimal Rate { get; set; }
        public string Mlssalcode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
