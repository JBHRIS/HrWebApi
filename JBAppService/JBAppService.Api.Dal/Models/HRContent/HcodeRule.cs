using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class HcodeRule
    {
        public string Code { get; set; }
        public string Interval { get; set; }
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
        public string Custom { get; set; }
        public string Note { get; set; }
    }
}
