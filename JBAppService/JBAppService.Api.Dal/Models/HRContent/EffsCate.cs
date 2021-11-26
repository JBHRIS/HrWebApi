using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsCate
    {
        public string EffcateId { get; set; }
        public string EffcateName { get; set; }
        public string Effcatenote { get; set; }
        public string TypeId { get; set; }
        public int? Rate { get; set; }
    }
}
