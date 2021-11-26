using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class InsCnCodeTts
    {
        public string InsurCnCode { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public decimal Amt { get; set; }
        public decimal SelfRate { get; set; }
        public decimal CompRate { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public decimal? SelfValue { get; set; }
        public decimal? CompValue { get; set; }
        public decimal? SelfMaxValue { get; set; }
        public decimal? SelfMinValue { get; set; }
        public decimal? CompMaxValue { get; set; }
        public decimal? CompMinValue { get; set; }
        public decimal? SelfTtsValue { get; set; }
        public decimal? CompTtsValue { get; set; }

        public virtual InsurCnCode InsurCnCodeNavigation { get; set; }
    }
}
