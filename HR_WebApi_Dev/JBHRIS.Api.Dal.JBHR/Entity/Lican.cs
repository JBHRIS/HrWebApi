using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Lican
    {
        public string Nobr { get; set; }
        public string Descs { get; set; }
        public string Comp { get; set; }
        public DateTime Mdate { get; set; }
        public bool Owner { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public int LicanId { get; set; }
        public string LicNo { get; set; }
        public string LicNote { get; set; }
        public bool LicPass { get; set; }
        public DateTime Edate { get; set; }
    }
}
