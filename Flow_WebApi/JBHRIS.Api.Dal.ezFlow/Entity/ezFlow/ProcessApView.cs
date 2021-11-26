using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessApView
    {
        public int auto { get; set; }
        public int? ProcessFlow_id { get; set; }
        public string Role_id { get; set; }
        public string Emp_id { get; set; }
        public string tag1 { get; set; }
        public string tag2 { get; set; }
        public string tag3 { get; set; }
    }
}
