using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsApprtts
    {
        public int AutoKey { get; set; }
        public int EffSApprid { get; set; }
        public string Works { get; set; }
        public string Standard { get; set; }
        public string Rate { get; set; }
        public string Appr { get; set; }
        public string Bespeak { get; set; }
        public string Reality { get; set; }
        public DateTime? Keydate { get; set; }
        public string Original { get; set; }
        public string Type { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Ddate { get; set; }
    }
}
