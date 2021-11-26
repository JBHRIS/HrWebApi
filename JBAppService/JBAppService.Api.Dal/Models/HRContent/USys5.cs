using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class USys5
    {
        public string Comp { get; set; }
        public string Hsalcode { get; set; }
        public string Healthoversalcode { get; set; }
        public string Healthrepairsalcode { get; set; }
        public decimal? Empfamilycnt { get; set; }
        public decimal? Compersoncnt { get; set; }
        public decimal? Heacomprate { get; set; }
        public string Supplehinslabsalcode { get; set; }
        public decimal? Suppleinslabrate { get; set; }
        public decimal? Bonusyearratemax { get; set; }
    }
}
