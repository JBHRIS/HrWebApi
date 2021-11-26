using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessID
    {
        public int value { get; set; }
        public Guid key { get; set; }
        public DateTime genDatetime { get; set; }
    }
}
