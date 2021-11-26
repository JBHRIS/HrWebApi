using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_MESSENGER
    {
        public string USERID { get; set; }
        public string MESSAGE { get; set; }
        public string PARAS { get; set; }
        public string SENDTIME { get; set; }
        public string SENDERID { get; set; }
        public string RECTIME { get; set; }
        public string STATUS { get; set; }
    }
}
