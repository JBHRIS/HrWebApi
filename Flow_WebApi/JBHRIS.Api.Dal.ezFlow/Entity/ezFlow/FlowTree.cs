using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowTree
    {
        public string id { get; set; }
        public string FlowGroup_id { get; set; }
        public string name { get; set; }
        public DateTime? dateB { get; set; }
        public DateTime? dateE { get; set; }
        public bool? isVisible { get; set; }
        public string Tpye { get; set; }
        public int? Sort { get; set; }
        public byte[] ViewImage { get; set; }
    }
}
