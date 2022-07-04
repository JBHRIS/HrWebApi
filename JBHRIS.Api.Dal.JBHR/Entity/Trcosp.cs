using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trcosp
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public string Course { get; set; }
        public bool Close { get; set; }
        public decimal AtHrs { get; set; }
        public string TrMemo { get; set; }
        public string Prove { get; set; }
        public bool TrRepo { get; set; }
        public DateTime? TrAsdate { get; set; }
        public string Applyno { get; set; }
        public string Receiver { get; set; }
        public string Kavl { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public decimal? StHrs { get; set; }
    }
}
