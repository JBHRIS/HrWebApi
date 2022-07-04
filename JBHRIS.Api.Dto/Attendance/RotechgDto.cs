using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class RotechgDto
    {
        public DateTime Adate { get; set; }
        public string Nobr { get; set; }
        public string Rote { get; set; }
        public string Code { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public int Autokey { get; set; }
    }
}
