using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class MailAgentFlowTree
    {
        public int auto { get; set; }
        public string MailAgent_Guid { get; set; }
        public string FlowTree_id { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
