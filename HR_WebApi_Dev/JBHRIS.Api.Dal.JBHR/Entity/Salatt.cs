using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Salatt
    {
        public int Auto { get; set; }
        public string Source { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Rote { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string CalcType { get; set; }
    }
}
