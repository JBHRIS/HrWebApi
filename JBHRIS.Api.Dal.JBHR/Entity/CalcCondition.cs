using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class CalcCondition
    {
        public int Auto { get; set; }
        public string Source { get; set; }
        public string Code { get; set; }
        public string CondType { get; set; }
        public string Condition { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
