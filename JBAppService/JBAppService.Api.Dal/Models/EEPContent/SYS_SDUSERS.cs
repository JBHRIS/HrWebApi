using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDUSERS
    {
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string GROUPID { get; set; }
        public DateTime? LASTDATE { get; set; }
        public string EMAIL { get; set; }
        public string SYSTYPE { get; set; }
    }
}
