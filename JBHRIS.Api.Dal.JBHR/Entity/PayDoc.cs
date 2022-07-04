using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class PayDoc
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public int DocItem { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool Payed { get; set; }
        public DateTime? PayDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string Memo { get; set; }
        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
    }
}
