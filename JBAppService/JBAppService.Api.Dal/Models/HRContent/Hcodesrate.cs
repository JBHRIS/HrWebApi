using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Hcodesrate
    {
        public string HCode { get; set; }
        public string SalCode { get; set; }
        public decimal YearB { get; set; }
        public decimal YearE { get; set; }
        public decimal DayB { get; set; }
        public decimal DayE { get; set; }
        public decimal Rate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
