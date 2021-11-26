using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AppSettingConfiguration
    {
        public int AutoKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingItem { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string Note { get; set; }
    }
}
