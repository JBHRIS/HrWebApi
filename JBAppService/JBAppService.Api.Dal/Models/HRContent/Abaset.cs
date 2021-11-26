using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Abaset
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public decimal Maxhrs { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
