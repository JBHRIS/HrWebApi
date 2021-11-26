using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class SendMailLog
    {
        public int auto { get; set; }
        public string Emp_id { get; set; }
        public int? counter { get; set; }
        public DateTime? adate { get; set; }
    }
}
