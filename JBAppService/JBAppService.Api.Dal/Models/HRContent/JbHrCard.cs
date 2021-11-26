using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrCard
    {
        public string SCode { get; set; }
        public string SNobr { get; set; }
        public DateTime DAdate { get; set; }
        public string SOnTime { get; set; }
        public string SReasonCode { get; set; }
        public bool BLos { get; set; }
        public string SMeno { get; set; }
        public string SSerNo { get; set; }
        public string SIp { get; set; }
        public bool BNotTran { get; set; }
    }
}
