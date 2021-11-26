using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsGroupitem
    {
        public int AutoKey { get; set; }
        public string EffsgroupId { get; set; }
        public string Jobl { get; set; }
        public int? DeptOrder { get; set; }
    }
}
