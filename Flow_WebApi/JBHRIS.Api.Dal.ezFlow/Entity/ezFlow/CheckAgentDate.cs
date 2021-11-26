using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class CheckAgentDate
    {
        public int auto { get; set; }
        public string Role_idSource { get; set; }
        public string Emp_idSource { get; set; }
        public string Emp_idTarget { get; set; }
        public string Guid { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public bool IsValid { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
