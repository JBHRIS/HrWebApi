using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_WEBPAGES
    {
        public string PAGENAME { get; set; }
        public string PAGETYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public byte[] CONTENT { get; set; }
        public string USERID { get; set; }
        public string SOLUTIONID { get; set; }
        public byte[] SERVERDLL { get; set; }
        public bool? CHECKOUT { get; set; }
        public DateTime? CHECKOUTDATE { get; set; }
        public string CHECKOUTUSER { get; set; }
    }
}
