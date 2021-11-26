using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class SendMailParm
    {
        public int auto { get; set; }
        public int? triggerTimer { get; set; }
        public int? mailSpantime { get; set; }
        public int? mailMaxCount { get; set; }
        public bool? autofix { get; set; }
        public bool? mailMang { get; set; }
        public bool? mailCustom { get; set; }
        public string customEmail { get; set; }
    }
}
