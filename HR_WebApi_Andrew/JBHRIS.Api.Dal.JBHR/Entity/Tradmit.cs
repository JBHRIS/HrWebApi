using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tradmit
    {
        public string Nobr { get; set; }
        public DateTime TrDate { get; set; }
        public string TrNo { get; set; }
        public string TrCheck { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Old { get; set; }
    }
}
