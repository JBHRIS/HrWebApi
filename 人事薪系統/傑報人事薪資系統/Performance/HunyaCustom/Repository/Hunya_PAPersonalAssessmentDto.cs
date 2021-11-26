using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Performance.HunyaCustom.Repository
{
    public class Hunya_PAPersonalAssessmentDto
    {
        public string EmployeeID { get; set; }
        public string YYMM{ get; set; }
        public string PALevelCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public Guid GID { get; set; }
    }
}
