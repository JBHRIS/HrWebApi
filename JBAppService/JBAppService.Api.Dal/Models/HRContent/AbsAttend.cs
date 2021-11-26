using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AbsAttend
    {
        public string Nobr { get; set; }
        public DateTime Bdate { get; set; }
        public string HCode { get; set; }
        public decimal TolHours { get; set; }
        public decimal WkHrs { get; set; }
    }
}
