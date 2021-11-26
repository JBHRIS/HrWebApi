using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class AppRegistryKey_Bind
    {
        public int AutoKey { get; set; }
        public string Name { get; set; }
        public string Nobr { get; set; }
        public string APP_RegistryKey { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? Status { get; set; }
    }
}
