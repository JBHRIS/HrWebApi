using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Otc
    {
        public int Ak { get; set; }
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal TotHours { get; set; }
        public decimal OtHrs { get; set; }
        public decimal RestHrs { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Note { get; set; }
        public string Yymm { get; set; }
        public string Serno { get; set; }
    }
}
