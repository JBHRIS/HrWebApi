using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Exchange
    {
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public decimal Rate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
