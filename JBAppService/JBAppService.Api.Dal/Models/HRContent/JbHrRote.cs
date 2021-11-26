using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrRote
    {
        public DateTime DAdate { get; set; }
        public string SName { get; set; }
        public string SRoteCode { get; set; }
        public string SRoteName { get; set; }
        public string SOnTime { get; set; }
        public string SOffTime { get; set; }
        public decimal IWkHrs { get; set; }
        public decimal IDkHrs { get; set; }
        public decimal IMoHrs { get; set; }
        public string SOffTime2 { get; set; }
        public decimal IAlllates { get; set; }
        public string SOtBegin { get; set; }
        public decimal IAlllates1 { get; set; }
        public string SResBtime { get; set; }
        public string SResEtime { get; set; }
        public string SResB1time { get; set; }
        public string SResE1time { get; set; }
        public string SResB2time { get; set; }
        public string SResE2time { get; set; }
        public string SResB3time { get; set; }
        public string SResE3time { get; set; }
        public string SResB4time { get; set; }
        public string SResE4time { get; set; }
        public string SAttEnd { get; set; }
        public decimal IYrrestHrs { get; set; }
        public int ISort { get; set; }
    }
}
