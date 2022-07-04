using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class USys3
    {
        public string Comp { get; set; }
        public string Notaxsalcode { get; set; }
        public string Totaxsalcode { get; set; }
        public string Otfoodsalcode { get; set; }
        public string Otfoodsalcode1 { get; set; }
        public string Ottrasalcode { get; set; }
        public decimal? Malemaxhrs { get; set; }
        public decimal? Femalemaxhrs { get; set; }
        public decimal? Otunit { get; set; }
    }
}
