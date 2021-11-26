using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Certifi
    {
        public string Nobr { get; set; }
        public string Comp { get; set; }
        public string Descr { get; set; }
        public string Cont { get; set; }
        public DateTime EffDate { get; set; }
        public DateTime LffDate { get; set; }
        public bool Private { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
