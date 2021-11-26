using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Traskdt
    {
        public string Coscode { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Askcode { get; set; }
        public short L1 { get; set; }
        public short L2 { get; set; }
        public short L3 { get; set; }
        public short L4 { get; set; }
        public short L5 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Note { get; set; }
        public string Valcode { get; set; }
        public string TcrNo { get; set; }
        public decimal Ltot { get; set; }
        public decimal Hrs { get; set; }
        public string Askgrd { get; set; }
    }
}
