using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ExpDept
    {
        public string DNo { get; set; }
        public string DNoDisp { get; set; }
        public string DName { get; set; }
        public bool? DSum { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
