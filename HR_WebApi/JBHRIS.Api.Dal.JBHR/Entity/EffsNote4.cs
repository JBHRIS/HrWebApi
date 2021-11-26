using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsNote4
    {
        public int AutoKey { get; set; }
        public string Yy { get; set; }
        public string Seq { get; set; }
        public string Nobr { get; set; }
        public DateTime? Adate { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public decimal? Num1 { get; set; }
        public decimal? Num2 { get; set; }
    }
}
