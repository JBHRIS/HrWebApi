using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class BonusDeptAmt
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Dept { get; set; }
        public string GroupId { get; set; }
        public decimal? Amt { get; set; }
    }
}
