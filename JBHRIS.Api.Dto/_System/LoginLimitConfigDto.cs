using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System
{
    public class LoginLimitConfigDto
    {
        public int MaxFaildLoginCount { get; set; }
        public int LockAccountSecond { get; set; }
    }
}
