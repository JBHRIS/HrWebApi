using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsSelfinterview
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Interid { get; set; }
        public string Note { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? MangCheck { get; set; }
    }
}
