using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Onduty
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Yymm { get; set; }
    }
}
