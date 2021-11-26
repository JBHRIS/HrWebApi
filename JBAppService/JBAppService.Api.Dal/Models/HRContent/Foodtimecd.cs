using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Foodtimecd
    {
        public string Code { get; set; }
        public string CodeDisp { get; set; }
        public string CodeName { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal Amt { get; set; }
        public decimal Amt2 { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public int Sort { get; set; }
    }
}
