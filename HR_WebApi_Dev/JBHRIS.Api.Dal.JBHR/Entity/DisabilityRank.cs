using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class DisabilityRank
    {
        public string DisabilityRankCode { get; set; }
        public string DisabilityRankName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
