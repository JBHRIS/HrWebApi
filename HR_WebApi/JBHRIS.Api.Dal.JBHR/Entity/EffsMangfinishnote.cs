using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsMangfinishnote
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Dept { get; set; }
        public string Job { get; set; }
        public DateTime? Keydate { get; set; }
        public string Note { get; set; }
    }
}
