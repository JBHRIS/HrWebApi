using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class HolDay
    {
        public DateTime Adate { get; set; }
        public string Atype { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string HoliCode { get; set; }
        public string Rote { get; set; }
        public string Otratecd { get; set; }
    }
}
