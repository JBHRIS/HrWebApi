using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AbsExt
    {
        public string Nobr { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Hcode { get; set; }
        public string HName { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public decimal TolHours { get; set; }
        public decimal ExtHours { get; set; }
        public decimal CashHours { get; set; }
        public decimal Amt { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public int Sno { get; set; }
        public bool Syscreat { get; set; }
        public bool Ntrans { get; set; }
        public bool Ptrans { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
    }
}
