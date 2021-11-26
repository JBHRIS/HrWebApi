using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class CheckAgentDept
    {
        public int auto { get; set; }
        public string CheckAgent_Guid { get; set; }
        public string Dept_id { get; set; }
        public bool? IsAllSub { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
