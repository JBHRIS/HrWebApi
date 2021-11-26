using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessMultiFlow
    {
        public int auto { get; set; }
        public int? ProcessFlow_id { get; set; }
        public int? ProcessNode_auto { get; set; }
        public int? SubProcessFlow_id { get; set; }
        public string SubFlowTree_id { get; set; }
        public string SubInitRole_id { get; set; }
        public string SubInitEmp_id { get; set; }
        public string SubDynamicRole_id { get; set; }
        public string SubDynamicEmp_id { get; set; }
    }
}
