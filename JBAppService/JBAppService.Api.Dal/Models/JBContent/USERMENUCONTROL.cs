using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class USERMENUCONTROL
    {
        public string USERID { get; set; }
        public string MENUID { get; set; }
        public string CONTROLNAME { get; set; }
        public string TYPE { get; set; }
        public string ENABLED { get; set; }
        public string VISIBLE { get; set; }
        public string ALLOWADD { get; set; }
        public string ALLOWUPDATE { get; set; }
        public string ALLOWDELETE { get; set; }
        public string ALLOWPRINT { get; set; }
    }
}
