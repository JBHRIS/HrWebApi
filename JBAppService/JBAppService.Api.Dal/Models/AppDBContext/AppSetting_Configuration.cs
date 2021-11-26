using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class AppSetting_Configuration
    {
        public int AutoKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingItem { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string Note { get; set; }
        public string Group { get; set; }
    }
}
