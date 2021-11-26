using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class UserAcprivilege
    {
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public int? AcgroupId { get; set; }
        public bool? IsUseGroup { get; set; }
        public int? TimeZone1 { get; set; }
        public int? TimeZone2 { get; set; }
        public int? TimeZone3 { get; set; }
        public int? Verifystyle { get; set; }
    }
}
