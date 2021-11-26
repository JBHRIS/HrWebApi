using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class Role
    {
        public int auto { get; set; }
        public string id { get; set; }
        public string idParent { get; set; }
        public string Dept_id { get; set; }
        public string Pos_id { get; set; }
        public DateTime? dateB { get; set; }
        public DateTime? dateE { get; set; }
        public string Emp_id { get; set; }
        public bool? mgDefault { get; set; }
        public bool? deptMg { get; set; }
        public int? sort { get; set; }
    }
}
