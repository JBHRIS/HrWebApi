using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System
{
    public class UpdateLoginLimitConfigDto
    {
        public int MaxFaildLoginCount { get; set; }
        public int LockAccountSecond { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
