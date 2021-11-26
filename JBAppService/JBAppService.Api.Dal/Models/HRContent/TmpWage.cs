using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class TmpWage
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
        public DateTime? AttDateB { get; set; }
        public DateTime? AttDateE { get; set; }
        public decimal? Exchange { get; set; }
        public string Currency { get; set; }
    }
}
