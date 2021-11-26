using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeInit
    {
        public string FlowNode_id { get; set; }
        public string apName { get; set; }
        public bool? isNextNodeAutoSign { get; set; }
    }
}
