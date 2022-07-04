using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Attyear
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public decimal Attno { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
