using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FormsAppInfo
    {
        public int AutoKey { get; set; }
        public string ProcessId { get; set; }
        public int idProcess { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime? DateB { get; set; }
        public string SignState { get; set; }
        public string Info { get; set; }
        public string InfoSign { get; set; }
        public string InfoMail { get; set; }
        public string Code { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
