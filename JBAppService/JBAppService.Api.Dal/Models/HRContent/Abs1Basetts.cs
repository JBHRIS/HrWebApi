using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Abs1Basetts
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public DateTime Edate { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public string HCode { get; set; }
        public string HName { get; set; }
        public bool Mang { get; set; }
        public decimal TolHours { get; set; }
        public string Unit { get; set; }
        public string Saladr { get; set; }
    }
}
