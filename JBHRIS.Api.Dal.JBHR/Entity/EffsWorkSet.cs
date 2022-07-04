using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsWorkSet
    {
        public int AutoKey { get; set; }
        public string Yy { get; set; }
        public string Seq { get; set; }
        public string Name { get; set; }
        public bool? Isopen { get; set; }
    }
}
