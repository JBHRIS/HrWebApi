using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsMangFnums
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Sql { get; set; }
        public string Nobr { get; set; }
        public string Mangnobr { get; set; }
        public string Mangdept { get; set; }
        public DateTime? Keydate { get; set; }
        public decimal? Num { get; set; }
        public string O1 { get; set; }
        public string O2 { get; set; }
    }
}
