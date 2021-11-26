using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsWorkSet
    {
        public int AutoKey { get; set; }
        public string Yy { get; set; }
        public string Seq { get; set; }
        public string Name { get; set; }
        public bool? Isopen { get; set; }
    }
}
