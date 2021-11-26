using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Rotechg
    {
        public DateTime Adate { get; set; }
        public string Nobr { get; set; }
        public string Rote { get; set; }
        public string Code { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public int Autokey { get; set; }

        public virtual Attend Attend { get; set; }
    }
}
