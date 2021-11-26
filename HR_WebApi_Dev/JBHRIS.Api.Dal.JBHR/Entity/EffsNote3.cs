using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsNote3
    {
        public int AutoKey { get; set; }
        public string Year { get; set; }
        public string Seq { get; set; }
        public string Nobr { get; set; }
        public bool? Chb1 { get; set; }
        public bool? Chb2 { get; set; }
        public bool? Chb3 { get; set; }
        public bool? Chb4 { get; set; }
        public string Amt1 { get; set; }
        public string Amt2 { get; set; }
        public string Jobl { get; set; }
        public string Jobo { get; set; }
        public string AmtOther { get; set; }
        public string Amt3 { get; set; }
        public string Other { get; set; }
        public string Note { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
