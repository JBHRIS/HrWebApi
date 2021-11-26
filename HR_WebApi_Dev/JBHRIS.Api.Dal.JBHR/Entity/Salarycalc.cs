using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Salarycalc
    {
        public Guid Guid { get; set; }
        public string Source { get; set; }
        public string Userid { get; set; }
        public DateTime? Timeb { get; set; }
        public DateTime? Timee { get; set; }
    }
}
