using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Otherda
    {
        public string Nobr { get; set; }
        public string Code { get; set; }
        public DateTime Adate { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Amt { get; set; }
        public string Yymm { get; set; }
    }
}
