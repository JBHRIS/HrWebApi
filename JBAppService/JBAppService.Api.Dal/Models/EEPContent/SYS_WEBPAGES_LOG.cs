using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_WEBPAGES_LOG
    {
        public string PAGENAME { get; set; }
        public string PAGETYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public byte[] CONTENT { get; set; }
        public string USERID { get; set; }
        public string SOLUTIONID { get; set; }
        public byte[] SERVERDLL { get; set; }
        public DateTime CHECKINDATE { get; set; }
        public int ID { get; set; }
        public string CHECKINUSER { get; set; }
        public string CHECKINDESCRIPTION { get; set; }
    }
}
