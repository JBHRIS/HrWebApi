using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowControlCode
    {
        public int Autokey { get; set; }
        public string Form { get; set; }
        public string FCode { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }
}
