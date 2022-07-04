using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Encodingtable
    {
        public int Autokey { get; set; }
        public int Codepage { get; set; }
        public string Codedsp { get; set; }
        public string Codename { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
