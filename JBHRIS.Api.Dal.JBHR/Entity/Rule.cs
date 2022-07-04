using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Rule
    {
        public string RuleCode { get; set; }
        public string RuleName { get; set; }
        public bool Isfix { get; set; }
        public bool Israte { get; set; }
        public bool Isfixrate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
