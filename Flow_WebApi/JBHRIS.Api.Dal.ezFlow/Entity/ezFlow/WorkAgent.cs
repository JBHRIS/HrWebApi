using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class WorkAgent
    {
        public int auto { get; set; }
        public string Role_idSource { get; set; }
        public string Emp_idSource { get; set; }
        public string Role_idTarget { get; set; }
        public string Emp_idTarget { get; set; }
        public string Guid { get; set; }
    }
}
