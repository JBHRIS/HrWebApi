using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tyrtax
    {
        public string F0103 { get; set; }
        public string F0407 { get; set; }
        public string Series { get; set; }
        public string Mark { get; set; }
        public string Format { get; set; }
        public string Id { get; set; }
        public string Idcode { get; set; }
        public string Id1 { get; set; }
        public decimal TotAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal RelAmt { get; set; }
        public string AccNo { get; set; }
        public string Blank1 { get; set; }
        public string ErrMark { get; set; }
        public string Year { get; set; }
        public string NameC { get; set; }
        public string Addr2 { get; set; }
        public string Date { get; set; }
        public string Nobr { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string YearB { get; set; }
        public string YearE { get; set; }
        public string Taxtype { get; set; }
        public bool Nomodi { get; set; }
        public decimal RetAmt { get; set; }
    }
}
