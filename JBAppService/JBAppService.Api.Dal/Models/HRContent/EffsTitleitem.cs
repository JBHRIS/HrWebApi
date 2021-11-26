using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsTitleitem
    {
        public int AutoKey { get; set; }
        public string TitleId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int? Num { get; set; }
    }
}
