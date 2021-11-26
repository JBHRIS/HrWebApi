using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowTreePower
    {
        public int auto { get; set; }
        public string FlowTree_id { get; set; }
        public string Dept_path { get; set; }
        public bool? isAllSub { get; set; }
        public int? PosLevel_sorting { get; set; }
    }
}
