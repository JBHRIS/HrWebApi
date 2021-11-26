using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Foodwage
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public string Dept { get; set; }
        public DateTime Adate { get; set; }
        public string Ontime { get; set; }
        public decimal Amt { get; set; }
        public decimal Amt2 { get; set; }
        public bool Sys { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public string T1 { get; set; }
    }
}
