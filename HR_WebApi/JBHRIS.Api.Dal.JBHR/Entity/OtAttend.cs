using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class OtAttend
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public decimal OtHrs { get; set; }
        public decimal RestHrs { get; set; }
        public string OtRote { get; set; }
        public string Rote { get; set; }
        public decimal WkHrs { get; set; }
        public string Yymm { get; set; }
    }
}
