using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class InslabCn
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string TtsCode { get; set; }
        public string InsurCnCode { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string InsCnComp { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Note { get; set; }
        public decimal Amt { get; set; }
        public decimal? SelfRate { get; set; }
        public decimal? CompRate { get; set; }

        public virtual InsCnComp InsCnCompNavigation { get; set; }
        public virtual InsurCnCode InsurCnCodeNavigation { get; set; }
        public virtual Base NobrNavigation { get; set; }
    }
}
