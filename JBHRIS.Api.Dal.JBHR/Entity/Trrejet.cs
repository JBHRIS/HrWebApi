using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trrejet
    {
        public string Idno { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Coscode { get; set; }
        public string Rejcd { get; set; }
        public DateTime RejDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Send { get; set; }
    }
}
