using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
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
