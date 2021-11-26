using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsTrMangCheck
    {
        public int AutoKey { get; set; }
        public int? TrYear { get; set; }
        public int? TrSeq { get; set; }
        public int? MangYear { get; set; }
        public int? MangSeq { get; set; }
    }
}
