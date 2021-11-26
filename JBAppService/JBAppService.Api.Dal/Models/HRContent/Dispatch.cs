using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Dispatch
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public string Saladr { get; set; }
        public string Dept { get; set; }
        public string Depts { get; set; }
        public string YymmB { get; set; }
        public decimal AmtApply { get; set; }
        public decimal AmtPay { get; set; }
        public decimal AmtTax { get; set; }
        public decimal AmtCharity { get; set; }
        public string Currency { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
