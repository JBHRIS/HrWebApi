using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class SysVarDto
    {
        public string Url { get; set; }
        public string MailServer { get; set; }
        public string MailId { get; set; }
        public string MailPassword { get; set; }
        public string SenderMail { get; set; }
        public string SenderName { get; set; }
        public string WebServiceURL { get; set; }
        public int MaxKey { get; set; }
        public bool SysClose { get; set; }
    }
}
