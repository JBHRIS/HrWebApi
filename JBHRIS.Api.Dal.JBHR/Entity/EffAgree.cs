using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffAgree
    {
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public DateTime? AgreeDate { get; set; }
        public bool? Agree { get; set; }
        public string AgreeNote { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
    }
}
