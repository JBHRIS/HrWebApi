using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsTempletcate
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string EffcateId { get; set; }
        public int Order { get; set; }
        public string TypeId { get; set; }
        public int? Rate { get; set; }
    }
}
