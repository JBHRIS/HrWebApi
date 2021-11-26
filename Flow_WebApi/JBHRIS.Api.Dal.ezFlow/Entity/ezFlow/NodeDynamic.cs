using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class NodeDynamic
    {
        public string FlowNode_id { get; set; }
        public string apName { get; set; }
        public string tableName { get; set; }
        public string fdRole { get; set; }
        public string fdEmp { get; set; }
        public bool? isNextNodeAutoSign { get; set; }
    }
}
