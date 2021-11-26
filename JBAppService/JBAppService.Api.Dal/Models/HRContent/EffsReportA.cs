using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsReportA
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Name { get; set; }
        public string Effsgroup { get; set; }
        public string Templet { get; set; }
        public string Jobl { get; set; }
        public string Job { get; set; }
        public string Dept { get; set; }
        public string Effsdept { get; set; }
        public string Effcate { get; set; }
        public string Effcateitmes { get; set; }
        public decimal? Num { get; set; }
        public string Effsfinally { get; set; }
        public int? Los { get; set; }
        public decimal? Effsfinallynum { get; set; }
        public string Comp { get; set; }
        public string Saladr { get; set; }
    }
}
