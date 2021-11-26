using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ProcessCheck
    {
        public int auto { get; set; }
        public int? ProcessNode_auto { get; set; }
        public string Role_idDefault { get; set; }
        public string Emp_idDefault { get; set; }
        public string Role_idAgent { get; set; }
        public string Emp_idAgent { get; set; }
        public string Role_idReal { get; set; }
        public string Emp_idReal { get; set; }
        public DateTime? adate { get; set; }
        public bool? isMain { get; set; }
    }
}
