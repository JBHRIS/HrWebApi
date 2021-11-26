using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Apgpit
    {
        public string Apgrpcd { get; set; }
        public string Itemcd { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public decimal Rate { get; set; }
    }
}
