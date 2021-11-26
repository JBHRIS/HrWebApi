using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Repair
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal OtHrs { get; set; }
        public string Yymm { get; set; }
        public string Reason { get; set; }
        public string Place { get; set; }
        public string Works { get; set; }
        public string Improve { get; set; }
        public string KeyMan { get; set; }
        public decimal TrAmt { get; set; }
        public decimal ViAmt { get; set; }
        public decimal TotAmt { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
