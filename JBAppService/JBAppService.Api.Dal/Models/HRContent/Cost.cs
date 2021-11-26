using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Cost
    {
        public string Nobr { get; set; }
        public string Depts { get; set; }
        public decimal Rate { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime Cadate { get; set; }
        public DateTime Cddate { get; set; }

        public virtual Base NobrNavigation { get; set; }
    }
}
