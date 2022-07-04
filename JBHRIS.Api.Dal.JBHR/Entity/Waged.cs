using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Waged
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
    }
}
