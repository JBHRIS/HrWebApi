using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_ORG
    {
        public string ORG_NO { get; set; }
        public string ORG_DESC { get; set; }
        public string ORG_KIND { get; set; }
        public string UPPER_ORG { get; set; }
        public string ORG_MAN { get; set; }
        public string LEVEL_NO { get; set; }
        public string ORG_TREE { get; set; }
        public string END_ORG { get; set; }
        public string ORG_FULLNAME { get; set; }
    }
}
