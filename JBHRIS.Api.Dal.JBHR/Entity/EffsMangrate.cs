using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
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
