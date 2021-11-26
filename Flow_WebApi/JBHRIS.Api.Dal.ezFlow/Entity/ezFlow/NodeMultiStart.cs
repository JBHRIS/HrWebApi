using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeMultiStart
    {
        public int auto { get; set; }
        public string FlowNode_id { get; set; }
        public string FlowTree_idSub { get; set; }
        public bool? isFinish { get; set; }
    }
}
