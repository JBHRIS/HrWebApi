using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class RobotLog
    {
        public int auto { get; set; }
        public string srvType { get; set; }
        public int? ProcessFlow_id { get; set; }
        public int? ProcessNode_auto { get; set; }
        public int? ProcessCheck_auto { get; set; }
        public int? counter { get; set; }
        public string note { get; set; }
        public DateTime? adate { get; set; }
        public bool? isClose { get; set; }
    }
}
