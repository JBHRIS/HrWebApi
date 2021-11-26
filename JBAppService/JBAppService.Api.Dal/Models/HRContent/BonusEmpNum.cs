using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class BonusEmpNum
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public decimal? Num1 { get; set; }
        public decimal? Num2 { get; set; }
        public decimal? Num3 { get; set; }
    }
}
