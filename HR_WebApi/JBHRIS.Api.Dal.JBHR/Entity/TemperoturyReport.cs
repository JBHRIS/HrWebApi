using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class TemperoturyReport
    {
        public string EmployeeId { get; set; }
        public DateTime AttendDate { get; set; }
        public string ReportType { get; set; }
        public decimal Temperotury { get; set; }
        public string Description { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AutoKey { get; set; }
        public Guid Guid { get; set; }
    }
}
