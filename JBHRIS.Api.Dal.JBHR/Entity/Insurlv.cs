using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Insurlv
    {
        public decimal Amt { get; set; }
        public DateTime EffDatel { get; set; }
        public DateTime LffDatel { get; set; }
        public DateTime EffDateh { get; set; }
        public DateTime LffDateh { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public DateTime EffDater { get; set; }
        public DateTime LffDater { get; set; }
        public decimal EffRate { get; set; }
    }
}
