using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
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
