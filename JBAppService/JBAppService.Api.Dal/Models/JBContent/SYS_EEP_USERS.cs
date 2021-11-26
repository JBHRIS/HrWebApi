using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_EEP_USERS
    {
        public string USERID { get; set; }
        public string USERNAME { get; set; }
        public string COMPUTER { get; set; }
        public string LOGINTIME { get; set; }
        public string LASTACTIVETIME { get; set; }
        public int? LOGINCOUNT { get; set; }
    }
}
