using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_ROLES_AGENT
    {
        public string ROLE_ID { get; set; }
        public string AGENT { get; set; }
        public string FLOW_DESC { get; set; }
        public string START_DATE { get; set; }
        public string START_TIME { get; set; }
        public string END_DATE { get; set; }
        public string END_TIME { get; set; }
        public string PAR_AGENT { get; set; }
        public string REMARK { get; set; }
    }
}
