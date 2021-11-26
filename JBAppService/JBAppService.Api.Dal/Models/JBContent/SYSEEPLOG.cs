using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYSEEPLOG
    {
        public string CONNID { get; set; }
        public int LOGID { get; set; }
        public string LOGSTYLE { get; set; }
        public DateTime LOGDATETIME { get; set; }
        public string DOMAINID { get; set; }
        public string USERID { get; set; }
        public string LOGTYPE { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string COMPUTERIP { get; set; }
        public string COMPUTERNAME { get; set; }
        public int? EXECUTIONTIME { get; set; }
    }
}
