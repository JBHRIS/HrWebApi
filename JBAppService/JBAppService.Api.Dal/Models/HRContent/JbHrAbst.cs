using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrAbst
    {
        public string SNobr { get; set; }
        public DateTime DDateB { get; set; }
        public DateTime DDateE { get; set; }
        public string SHoliCode { get; set; }
        public decimal ITolHours { get; set; }
        public string SAname { get; set; }
        public string ST1code { get; set; }
        public string ST2code { get; set; }
        public string ST3code { get; set; }
    }
}
