using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Effect
    {
        public string Apcd { get; set; }
        public string Apcdname { get; set; }
        public decimal Effb { get; set; }
        public decimal Effe { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
