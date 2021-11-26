using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tratt
    {
        public string Coscode { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Idno { get; set; }
        public string Selcode { get; set; }
        public int Atthrs { get; set; }
        public decimal Abshrs { get; set; }
        public decimal Score { get; set; }
        public bool Cosclose { get; set; }
        public bool Sharefee { get; set; }
        public bool Abs { get; set; }
        public string Note { get; set; }
        public bool Homework { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int Fee { get; set; }
        public bool Onlinesign { get; set; }
        public string Expect { get; set; }
        public DateTime TrAsdate { get; set; }
        public int LatNo { get; set; }
        public int EarNo { get; set; }
        public bool Abs1 { get; set; }
    }
}
