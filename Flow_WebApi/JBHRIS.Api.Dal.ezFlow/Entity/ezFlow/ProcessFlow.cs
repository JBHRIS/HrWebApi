using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessFlow
    {
        public int id { get; set; }
        public int? ProcessNode_auto { get; set; }
        public string FlowTree_id { get; set; }
        public DateTime? adate { get; set; }
        public string Role_id { get; set; }
        public string Emp_id { get; set; }
        public bool? isFinish { get; set; }
        public bool? isError { get; set; }
        public bool? isCancel { get; set; }
        public bool? isMultiFlow { get; set; }
    }
}
