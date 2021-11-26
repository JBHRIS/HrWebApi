using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Welf
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public decimal DAmt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Format { get; set; }
        public string TrType { get; set; }
        public string Saladr { get; set; }
    }
}
