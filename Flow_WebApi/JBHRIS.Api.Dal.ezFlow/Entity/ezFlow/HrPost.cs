using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class HrPost
    {
        public int auto { get; set; }
        public string caption { get; set; }
        public string content { get; set; }
        public DateTime? adate { get; set; }
        public string Emp_id { get; set; }
    }
}
