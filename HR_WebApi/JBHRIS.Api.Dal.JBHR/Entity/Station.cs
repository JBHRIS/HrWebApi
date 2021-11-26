using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Station
    {
        public string Code { get; set; }
        public string StationName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int? Amt { get; set; }
        public string CodeDisp { get; set; }
    }
}
