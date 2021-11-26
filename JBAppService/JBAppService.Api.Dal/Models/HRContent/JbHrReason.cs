using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrReason
    {
        public string SReasonCode { get; set; }
        public string SReasonName { get; set; }
        public bool BAtt { get; set; }
        public int ISort { get; set; }
    }
}
