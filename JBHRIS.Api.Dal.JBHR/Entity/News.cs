using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class News
    {
        public int IAutoKey { get; set; }
        public string NewsId { get; set; }
        public string NewsHead { get; set; }
        public string NewsBody { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDeadline { get; set; }
        public bool IsOn { get; set; }
        public string Newsfileid { get; set; }
        public DateTime? LatestSendMailDate { get; set; }
        public long Sort { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
