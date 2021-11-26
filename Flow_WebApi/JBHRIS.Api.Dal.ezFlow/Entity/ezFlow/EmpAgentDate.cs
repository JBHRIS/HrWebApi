using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class EmpAgentDate
    {
        public int auto { get; set; }
        public string Emp_id { get; set; }
        public DateTime dateB { get; set; }
        public DateTime dateE { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool IsValid { get; set; }
    }
}
