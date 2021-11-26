using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Taxcnlvl
    {
        public string Taxcode { get; set; }
        public int Year { get; set; }
        public decimal AmtB { get; set; }
        public decimal AmtE { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxDiscount { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
