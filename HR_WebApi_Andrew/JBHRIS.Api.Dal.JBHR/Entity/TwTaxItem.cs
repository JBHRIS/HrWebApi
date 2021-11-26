using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class TwTaxItem
    {
        public int Auto { get; set; }
        public int Pid { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public decimal DAmt { get; set; }
        public string TrType { get; set; }
        public string Format { get; set; }
        public string Memo { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string InaId { get; set; }
        public string Taxno { get; set; }
        public int Subcode { get; set; }
        public string Forsub { get; set; }
        public string Comp { get; set; }
        public decimal SupAmt { get; set; }
        public bool Import { get; set; }
        public decimal RetAmt { get; set; }
        public bool IsFile { get; set; }
    }
}
