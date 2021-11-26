using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysLoginTime
    {
        public int IAutoKey { get; set; }
        public string SysLoginUserSUserId { get; set; }
        public string SLoginIp { get; set; }
        public bool BLoginSuccess { get; set; }
        public string SSessionid { get; set; }
        public DateTime? DLoginTime { get; set; }
        public DateTime? DLogoutTime { get; set; }
    }
}
