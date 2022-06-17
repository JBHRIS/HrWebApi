using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SecurityLogs
    {
        public Guid Id { get; set; }
        public string Nobr { get; set; }
        public string Action { get; set; }
        public string ClientIpAddress { get; set; }
        public string BrowserInfo { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
