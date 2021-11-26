using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowLink
    {
        public string id { get; set; }
        public string FlowTree_id { get; set; }
        public string name { get; set; }
        public string linkType { get; set; }
        public string linkStyle { get; set; }
        public string FlowNode_idSource { get; set; }
        public string FlowNode_idTarget { get; set; }
        public string FlowNode_ArrowSource { get; set; }
        public string FlowNode_ArrowTarget { get; set; }
    }
}
