using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Cardapp
    {
        public string Nobr { get; set; }
        public string Cardno { get; set; }
        public DateTime Bdate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Temps { get; set; }
        public DateTime Edate { get; set; }
    }
}
