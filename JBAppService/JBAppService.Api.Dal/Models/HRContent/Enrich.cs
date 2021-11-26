using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Enrich
    {
        public int Autokey { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public string SalCode { get; set; }
        public decimal Amt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Memo { get; set; }
        public string FaIdno { get; set; }
        public bool Import { get; set; }
        public string Serno { get; set; }
    }
}
