using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsMangappend
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Mangnobr { get; set; }
        public string Mangdept { get; set; }
        public string Mangjob { get; set; }
        public string Apptype { get; set; }
        public DateTime? Appstddate { get; set; }
        public DateTime? Appenddate { get; set; }
        public bool? Appendfinish { get; set; }
    }
}
