using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class EmpConfiguration
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string SettingValue { get; set; }
        public string SettingItem { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
