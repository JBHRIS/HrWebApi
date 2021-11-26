using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsSelfwork
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public int? ApprId { get; set; }
        public decimal? Num { get; set; }
        public DateTime? Keydate { get; set; }
        public bool? MangCheck { get; set; }
    }
}
