using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class AlarmLog
    {
        public int Id { get; set; }
        public string Operator { get; set; }
        public string EnrollNumber { get; set; }
        public DateTime? LogTime { get; set; }
        public string MachineAlias { get; set; }
        public int? AlarmType { get; set; }
    }
}
