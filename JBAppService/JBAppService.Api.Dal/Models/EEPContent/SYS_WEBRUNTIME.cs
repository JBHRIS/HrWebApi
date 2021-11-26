using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_WEBRUNTIME
    {
        public string PAGENAME { get; set; }
        public string PAGETYPE { get; set; }
        public byte[] CONTENT { get; set; }
        public string USERID { get; set; }
        public string SOLUTIONID { get; set; }
    }
}
