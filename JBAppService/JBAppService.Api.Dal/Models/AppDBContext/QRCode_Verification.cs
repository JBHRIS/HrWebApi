using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class QRCode_Verification
    {
        public int AutoKey { get; set; }
        public string GUID { get; set; }
        public string QRCode { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? Status { get; set; }
    }
}
