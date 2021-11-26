using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class GROUPS_LOG
    {
        public int LOG_ID { get; set; }
        public string LOG_STATE { get; set; }
        public string LOG_USER { get; set; }
        public DateTime? LOG_DATE { get; set; }
        public string GROUPID { get; set; }
        public string GROUPNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string MSAD { get; set; }
        public string ISROLE { get; set; }
    }
}
