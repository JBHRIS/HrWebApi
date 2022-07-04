using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysApiVoidBlackList
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string ApiVoidCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
