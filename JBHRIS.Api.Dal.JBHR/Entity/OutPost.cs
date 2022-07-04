using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class OutPost
    {
        public string Code { get; set; }
        public string OutPostName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string CodeDisp { get; set; }
    }
}
