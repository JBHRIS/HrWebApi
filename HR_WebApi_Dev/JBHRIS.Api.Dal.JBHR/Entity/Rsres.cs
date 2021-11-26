using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Rsres
    {
        public string Resno { get; set; }
        public string Advuncd { get; set; }
        public string Advtpcd { get; set; }
        public DateTime Advdate { get; set; }
        public DateTime Adedate { get; set; }
        public DateTime Wdvdate { get; set; }
        public DateTime Wdedate { get; set; }
        public decimal Advfee { get; set; }
        public decimal Advqty { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
