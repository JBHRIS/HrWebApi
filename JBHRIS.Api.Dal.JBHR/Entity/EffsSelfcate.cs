using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsSelfcate
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string CateId { get; set; }
        public decimal? Num { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool? MangCheck { get; set; }
        public decimal? Rate { get; set; }
        public string O1 { get; set; }
        public string O2 { get; set; }
        public string O3 { get; set; }
        public string O4 { get; set; }
        public string O5 { get; set; }
    }
}
