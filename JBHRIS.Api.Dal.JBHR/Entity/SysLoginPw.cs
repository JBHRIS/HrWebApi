using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysLoginPw
    {
        public int IAutoKey { get; set; }
        public string SysLoginUserSUserId { get; set; }
        public string SUserPwold { get; set; }
        public string SUserPwnew { get; set; }
        public string SKeyMan { get; set; }
        public DateTime? DKeyDate { get; set; }
    }
}
