using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class CheckAgentFlowTree
    {
        public int auto { get; set; }
        public string CheckAgent_Guid { get; set; }
        public string FlowTree_id { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
