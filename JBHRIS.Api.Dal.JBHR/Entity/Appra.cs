using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Appra
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Apgrpcd { get; set; }
        public string Aptype { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public decimal Vt { get; set; }
        public string Vp { get; set; }
        public string Vr { get; set; }
        public decimal Vn { get; set; }
        public decimal Rate { get; set; }
        public decimal Abs { get; set; }
        public decimal Ap { get; set; }
    }
}
