using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessException
    {
        public int auto { get; set; }
        public int? ProcessFlow_id { get; set; }
        public int? ProcessNode_auto { get; set; }
        public int? ProcessCheck_auto { get; set; }
        public string errorType { get; set; }
        public string errorMsg { get; set; }
        public DateTime? adate { get; set; }
        public bool? isOK { get; set; }
    }
}
