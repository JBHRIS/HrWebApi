using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UPrg
    {
        public string Prog { get; set; }
        public string ProgName { get; set; }
        public string System { get; set; }
        public bool Root { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
