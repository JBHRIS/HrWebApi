using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Mtdict
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public bool Disp { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
