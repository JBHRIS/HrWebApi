using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsSelfplan
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Note { get; set; }
        public DateTime? Keydate { get; set; }
        public bool? MangCheck { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
    }
}
