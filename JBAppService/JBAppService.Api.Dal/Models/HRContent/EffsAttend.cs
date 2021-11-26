using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsAttend
    {
        public int AutoKey { get; set; }
        public int Yy { get; set; }
        public int Seq { get; set; }
        public string Desc { get; set; }
        public DateTime Keydate { get; set; }
        public DateTime StdDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public int? NYy { get; set; }
        public int? NSeq { get; set; }
        public int? SYy { get; set; }
        public int? SSeq { get; set; }
    }
}
