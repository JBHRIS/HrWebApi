using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class AppSettingConfigurationDto
    {
        public int AutoKey { get; set; }
        public string SettingValue { get; set; }
        public string SettingItem { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string Note { get; set; }
    }
}
