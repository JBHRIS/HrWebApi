using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessNode
    {
        public int auto { get; set; }
        public int? ProcessNode_idPrior { get; set; }
        public int? ProcessFlow_id { get; set; }
        public string FlowNode_id { get; set; }
        public DateTime? adate { get; set; }
        public bool? isFinish { get; set; }
        public bool? isMulti { get; set; }
        public int? SignSort { get; set; }
        public decimal? ManageLevel { get; set; }
    }
}
