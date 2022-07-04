using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class DeptaSupervisor
    {
        public int AutoKey { get; set; }
        public string DNo { get; set; }
        public string SupervisorNobr { get; set; }
        public bool? AddOrDel { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
