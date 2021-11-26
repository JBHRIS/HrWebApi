using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Expsup
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public DateTime PayDate { get; set; }
        public string Format { get; set; }
        public decimal PayAmt { get; set; }
        public decimal SupAmt { get; set; }
        public decimal InsHamt { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public decimal TotalAmt { get; set; }
        public string SNo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Saladr { get; set; }
    }
}
