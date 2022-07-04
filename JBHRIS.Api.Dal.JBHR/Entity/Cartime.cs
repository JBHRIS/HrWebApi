using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Cartime
    {
        public string Carcd { get; set; }
        public DateTime Adate { get; set; }
        public string Ontime { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
