using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Frm2p
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal SugHrs { get; set; }
        public decimal AbsHrs { get; set; }
        public decimal Abs1Hrs { get; set; }
        public decimal Abs2Hrs { get; set; }
        public bool Trans { get; set; }
        public string HCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Yymm { get; set; }
        public DateTime Ddate { get; set; }
        public string NameC { get; set; }
        public string HName { get; set; }
    }
}
