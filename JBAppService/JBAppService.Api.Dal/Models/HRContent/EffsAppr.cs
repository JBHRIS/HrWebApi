using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsAppr
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string Works { get; set; }
        public string Standard { get; set; }
        public string Rate { get; set; }
        public string Appr { get; set; }
        public string Bespeak { get; set; }
        public string Reality { get; set; }
        public bool? MangCheck { get; set; }
        public DateTime? MangcheckDate { get; set; }
        public string Mangname { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? Included { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
    }
}
