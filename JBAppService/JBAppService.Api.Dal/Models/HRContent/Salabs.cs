using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Salabs
    {
        public string Yymm { get; set; }
        public string Nobr { get; set; }
        public DateTime Adate { get; set; }
        public string Btime { get; set; }
        public string HCode { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public string AdjCode { get; set; }
        public string Mlssalcode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Salseq { get; set; }

        public virtual Abs Abs { get; set; }
    }
}
