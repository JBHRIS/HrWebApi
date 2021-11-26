using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class WorkAgentPower
    {
        public int auto { get; set; }
        public string WorkAgent_Guid { get; set; }
        public string FlowTree_id { get; set; }
    }
}
