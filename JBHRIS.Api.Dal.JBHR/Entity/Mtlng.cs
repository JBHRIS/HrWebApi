using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Mtlng
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string DisplayName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
