using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class NotifyTemplate
    {
        public int AutoKey { get; set; }
        public string Comp { get; set; }
        public string NotifyType { get; set; }
        public string TargetType { get; set; }
        public string Target { get; set; }
        public int NotifyDay { get; set; }
        public string Memo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
