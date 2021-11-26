using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrAbs
    {
        public string SNobr { get; set; }
        public DateTime DDateB { get; set; }
        public DateTime DDateE { get; set; }
        public string STimeB { get; set; }
        public string STimeE { get; set; }
        public string SHoliCode { get; set; }
        public decimal ITolHours { get; set; }
        public string SYymm { get; set; }
        public string SAname { get; set; }
        public string SSerNo { get; set; }
    }
}
