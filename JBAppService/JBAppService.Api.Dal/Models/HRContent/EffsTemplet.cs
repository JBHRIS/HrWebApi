using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsTemplet
    {
        public string TempletId { get; set; }
        public string TempletName { get; set; }
        public bool IsTitle { get; set; }
        public string TitleId { get; set; }
    }
}
