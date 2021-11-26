using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsMangrate
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public decimal? Arrprate { get; set; }
        public decimal? Caterate { get; set; }
        public string Mangnobr { get; set; }
    }
}
