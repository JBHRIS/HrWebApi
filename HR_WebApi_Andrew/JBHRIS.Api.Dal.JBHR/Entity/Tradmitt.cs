using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tradmitt
    {
        public string TrNo { get; set; }
        public string TrName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Old { get; set; }
        public string Dept { get; set; }
    }
}
