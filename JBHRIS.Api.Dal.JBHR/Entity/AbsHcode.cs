using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AbsHcode
    {
        public string Nobr { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public string Yymm { get; set; }
        public decimal TolDay { get; set; }
        public bool Syscreate { get; set; }
        public string HName { get; set; }
        public string YearRest { get; set; }
        public bool Att { get; set; }
        public DateTime Bdate { get; set; }
        public string Unit { get; set; }
        public string HEname { get; set; }
    }
}
