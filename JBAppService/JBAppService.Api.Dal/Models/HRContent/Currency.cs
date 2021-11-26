using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Currency
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
