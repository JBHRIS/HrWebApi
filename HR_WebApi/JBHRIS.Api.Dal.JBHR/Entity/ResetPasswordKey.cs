using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ResetPasswordKey
    {
        public string ResetKey { get; set; }
        public string Nobr { get; set; }
        public DateTime DeadLineTime { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
