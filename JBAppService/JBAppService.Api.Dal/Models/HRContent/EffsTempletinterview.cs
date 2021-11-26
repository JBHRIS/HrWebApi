using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsTempletinterview
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string InterviewId { get; set; }
        public int? Order { get; set; }
    }
}
