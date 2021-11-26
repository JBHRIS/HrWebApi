using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowNode
    {
        public string id { get; set; }
        public string FlowTree_id { get; set; }
        public string name { get; set; }
        public string nodeType { get; set; }
        public int? xPos { get; set; }
        public int? yPos { get; set; }
        public bool? Batch { get; set; }
    }
}
