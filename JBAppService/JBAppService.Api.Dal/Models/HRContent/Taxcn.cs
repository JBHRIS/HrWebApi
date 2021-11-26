using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Taxcn
    {
        public string TaxCode { get; set; }
        public string TaxName { get; set; }
        public decimal Discount { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
