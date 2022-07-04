using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class DiversionGroup
    {
        public string EmployeeId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiversionGroupType { get; set; }
        public string WorkLocation { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
        public Guid Guid { get; set; }
    }
}
