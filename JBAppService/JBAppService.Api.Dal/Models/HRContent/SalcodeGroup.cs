using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class SalcodeGroup
    {
        public string SalcodeGroup1 { get; set; }
        public string SalcodeGroupName { get; set; }
        public int Sort { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Edate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
