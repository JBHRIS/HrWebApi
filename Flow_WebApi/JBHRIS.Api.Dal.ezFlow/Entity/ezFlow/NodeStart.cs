using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeStart
    {
        public string FlowNode_id { get; set; }
        public string virtualPath { get; set; }
        public string viewAp { get; set; }
        public bool? isAuto { get; set; }
        public string tableName { get; set; }
    }
}
