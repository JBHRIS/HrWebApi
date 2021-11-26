using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeEnd
    {
        public string FlowNode_id { get; set; }
        public bool? isMailStarter { get; set; }
        public bool? isMailAllMang { get; set; }
    }
}
