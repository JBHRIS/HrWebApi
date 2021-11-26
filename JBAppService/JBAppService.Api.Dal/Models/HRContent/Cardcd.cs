using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Cardcd
    {
        public Cardcd()
        {
            CardcdDamt = new HashSet<CardcdDamt>();
        }

        public string Cardcd1 { get; set; }
        public string Carddesc { get; set; }
        public bool Att { get; set; }
        public bool Food { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual ICollection<CardcdDamt> CardcdDamt { get; set; }
    }
}
