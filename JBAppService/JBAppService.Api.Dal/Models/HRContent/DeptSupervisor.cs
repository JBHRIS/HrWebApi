using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class DeptSupervisor
    {
        public int AutoKey { get; set; }
        public string DNo { get; set; }
        public string SupervisorNobr { get; set; }
        public bool? AddOrDel { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
