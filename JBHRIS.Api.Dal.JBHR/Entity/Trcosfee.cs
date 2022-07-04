using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trcosfee
    {
        public string Coscode { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Feecode { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public int Amt { get; set; }
        public string Feetype { get; set; }
        public string TcrNo { get; set; }
        public bool Cal { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
