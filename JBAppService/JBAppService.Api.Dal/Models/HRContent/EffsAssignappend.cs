using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsAssignappend
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Mangnobr { get; set; }
        public string Mangdept { get; set; }
        public string Mangjob { get; set; }
        public string Assignnobr { get; set; }
        public DateTime? Keydate { get; set; }
        public int? Extendday { get; set; }
    }
}
