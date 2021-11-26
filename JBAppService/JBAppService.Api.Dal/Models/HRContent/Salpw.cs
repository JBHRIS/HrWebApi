using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Salpw
    {
        public int AutoKey { get; set; }
        public string Nobr { get; set; }
        public string Pw { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
