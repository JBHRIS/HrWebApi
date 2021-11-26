using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class HolDay
    {
        public DateTime Adate { get; set; }
        public string Atype { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string HoliCode { get; set; }
        public string Rote { get; set; }
        public string Otratecd { get; set; }
    }
}
