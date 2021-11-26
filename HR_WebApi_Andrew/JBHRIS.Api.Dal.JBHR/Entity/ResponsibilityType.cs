using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ResponsibilityType
    {
        public string ResponsibilityCode { get; set; }
        public string ResponsibilityName { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
