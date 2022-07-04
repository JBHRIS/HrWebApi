using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Attcard
    {
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string T1 { get; set; }
        public string T2 { get; set; }
        public string Code { get; set; }
        public decimal Ser { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Dd1 { get; set; }
        public string Dd2 { get; set; }
        public bool Lost1 { get; set; }
        public bool Lost2 { get; set; }
        public string Tt1 { get; set; }
        public string Tt2 { get; set; }
        public bool Nomody { get; set; }
    }
}
