using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDUSERS_LOG
    {
        public int ID { get; set; }
        public string USERID { get; set; }
        public string IPADDRESS { get; set; }
        public DateTime LOGINTIME { get; set; }
        public DateTime LOGOUTTIME { get; set; }
    }
}
