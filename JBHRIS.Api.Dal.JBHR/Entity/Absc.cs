using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Absc
    {
        public int Ak { get; set; }
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Yymm { get; set; }
        public string Note { get; set; }
        public string AName { get; set; }
        public string Serno { get; set; }
        public string Guid { get; set; }
    }
}
