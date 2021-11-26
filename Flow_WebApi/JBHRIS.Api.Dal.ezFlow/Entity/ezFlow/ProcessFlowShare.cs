using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessFlowShare
    {
        public int auto { get; set; }
        public int? ProcessFlow_id { get; set; }
        public string Role_id { get; set; }
        public string Emp_id { get; set; }
        public bool? isStarter { get; set; }
    }
}
