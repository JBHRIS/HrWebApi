using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Insgrf
    {
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
