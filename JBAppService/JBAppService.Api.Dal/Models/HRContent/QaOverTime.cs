using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class QaOverTime
    {
        public string Nobr { get; set; }
        public DateTime OtBdate { get; set; }
        public string OtBtime { get; set; }
        public string OtEtime { get; set; }
        public decimal OtTotalhrs { get; set; }
        public decimal OtHrs { get; set; }
        public decimal RestHrs { get; set; }
        public string OtType { get; set; }
    }
}
