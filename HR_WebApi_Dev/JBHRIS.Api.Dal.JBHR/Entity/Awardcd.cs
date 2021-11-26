using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Awardcd
    {
        public string AwardCode { get; set; }
        public string Descr { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string AwardCodeDisp { get; set; }
    }
}
