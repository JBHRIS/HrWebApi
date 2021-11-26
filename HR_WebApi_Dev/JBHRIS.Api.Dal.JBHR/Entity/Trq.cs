using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trq
    {
        public int Autokey { get; set; }
        public string Trqcode { get; set; }
        public string Trqname { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Content { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
