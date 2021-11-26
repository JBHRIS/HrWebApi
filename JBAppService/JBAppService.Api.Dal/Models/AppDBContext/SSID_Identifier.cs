using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class SSID_Identifier
    {
        public int AutoKey { get; set; }
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? Status { get; set; }
    }
}
