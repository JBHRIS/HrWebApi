using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class MailAgentDept
    {
        public int auto { get; set; }
        public string MailkAgent_Guid { get; set; }
        public string Dept_id { get; set; }
        public bool? IsAllSub { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
