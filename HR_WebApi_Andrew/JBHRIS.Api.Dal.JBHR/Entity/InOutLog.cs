using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class InOutLog
    {
        public int Autokey { get; set; }
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public DateTime InOutTime { get; set; }
        public string DataSource { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
