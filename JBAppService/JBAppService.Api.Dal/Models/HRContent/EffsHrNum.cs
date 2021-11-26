using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsHrNum
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nor { get; set; }
        public decimal? Num1 { get; set; }
        public decimal? Num2 { get; set; }
        public decimal? Num3 { get; set; }
        public decimal? Num4 { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string Note { get; set; }
    }
}
