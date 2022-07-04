using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class WorkLog
    {
        public string EmployeeId { get; set; }
        public DateTime AttendDate { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public decimal WorkHours { get; set; }
        public string Workitem { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
        public Guid Guid { get; set; }
    }
}
