using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class DiversionShift
    {
        public string DiversionGroup { get; set; }
        public DateTime AttendDate { get; set; }
        public string DiversionAttendType { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
        public Guid Guid { get; set; }
    }
}
