using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class WageB
    {
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Bankno { get; set; }
        public string AccountNo { get; set; }
        public decimal WkDays { get; set; }
        public bool Cash { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public string Format { get; set; }
        public decimal Taxrate { get; set; }
        public string Saladr { get; set; }
        public string Comp { get; set; }
        public DateTime? AttDateb { get; set; }
        public DateTime? AttDatee { get; set; }
    }
}
