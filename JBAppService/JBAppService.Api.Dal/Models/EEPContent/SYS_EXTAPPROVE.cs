using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_EXTAPPROVE
    {
        public string APPROVEID { get; set; }
        public string GROUPID { get; set; }
        public string MINIMUM { get; set; }
        public string MAXIMUM { get; set; }
        public string ROLEID { get; set; }
    }
}
