using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class WagedSal
    {
        public string Nobr { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public string SalName { get; set; }
        public string Flag { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public bool Tax { get; set; }
        public string Salattr { get; set; }
        public string SalEname { get; set; }
        public string Type { get; set; }
    }
}
