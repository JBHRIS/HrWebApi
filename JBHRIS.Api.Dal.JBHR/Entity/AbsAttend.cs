using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AbsAttend
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public decimal WkHrs { get; set; }
    }
}
