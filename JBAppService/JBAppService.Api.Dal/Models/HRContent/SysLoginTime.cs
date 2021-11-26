using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
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
