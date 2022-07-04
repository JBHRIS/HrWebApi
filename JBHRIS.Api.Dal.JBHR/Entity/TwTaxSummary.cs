using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class TwTaxSummary
    {
        public int Auto { get; set; }
        public int Pid { get; set; }
        public string Nobr { get; set; }
        public decimal Amt { get; set; }
        public decimal DAmt { get; set; }
        public string Format { get; set; }
        public string Memo { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Taxno { get; set; }
        public int Subcode { get; set; }
        public string Forsub { get; set; }
        public string Comp { get; set; }
        public decimal SupAmt { get; set; }
        public bool Import { get; set; }
        public decimal RetAmt { get; set; }
        public bool IsFile { get; set; }
        public string Post2 { get; set; }
        public string Addr2 { get; set; }
        public string NameC { get; set; }
        public string Id { get; set; }
        public string Series { get; set; }
        public string Idcode { get; set; }
        public string Id1 { get; set; }
        public string F0103 { get; set; }
        public string F0407 { get; set; }
        public string Error { get; set; }
    }
}
