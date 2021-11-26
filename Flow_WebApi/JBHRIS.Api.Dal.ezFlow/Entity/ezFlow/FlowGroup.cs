using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowGroup
    {
        public string id { get; set; }
        public string idParent { get; set; }
        public string name { get; set; }
        public DateTime? dateB { get; set; }
        public DateTime? dateE { get; set; }
    }
}
