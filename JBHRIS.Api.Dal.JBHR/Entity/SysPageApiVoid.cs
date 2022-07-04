using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysPageApiVoid
    {
        public int AutoKey { get; set; }
        public string PageCode { get; set; }
        public string ApiVoidCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyName { get; set; }
    }
}
