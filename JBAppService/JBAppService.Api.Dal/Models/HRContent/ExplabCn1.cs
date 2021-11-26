using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ExplabCn1
    {
        public int Autokey { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string InsurType { get; set; }
        public decimal Exp { get; set; }
        public decimal Comp { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public string SalYymm { get; set; }
        public string SNo { get; set; }
        public bool Notedit { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
    }
}
