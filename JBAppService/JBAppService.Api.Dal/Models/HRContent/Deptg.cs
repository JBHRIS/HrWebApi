using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Deptg
    {
        public string Comp { get; set; }
        public string JobType { get; set; }
        public string DNo { get; set; }
        public string Job { get; set; }
        public decimal Pno { get; set; }
        public DateTime Adate { get; set; }
        public DateTime Ddate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
