using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Depts
    {
        public string DNo { get; set; }
        public string DName { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string DrAcno { get; set; }
        public string CrAcno { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Ddate { get; set; }
        public string OldDept { get; set; }
        public string Subs { get; set; }
        public string DNoDisp { get; set; }
        public string ICode { get; set; }
        public string DCode { get; set; }
        public string Note { get; set; }
        public int? Sort { get; set; }
        public string Orderid { get; set; }
    }
}
