using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Accounttype
    {
        public string AccountType1 { get; set; }
        public string TypeName { get; set; }
        public string CurrencyType { get; set; }
        public string Memo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
