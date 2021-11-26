using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class SysVar
    {
        public string urlRoot { get; set; }
        public string mailServer { get; set; }
        public string mailID { get; set; }
        public string mailPW { get; set; }
        public string senderMail { get; set; }
        public string senderName { get; set; }
        public int? maxKey { get; set; }
        public string webSrvURL { get; set; }
        public bool? sysClose { get; set; }
    }
}
