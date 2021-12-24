using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.AnnualBonus.HunyaCustom.Repository
{
    public class Hunya_ABYearEndAppraisalDto
    {
        public string EmployeeID { get; set; }
        public int YYYY { get; set; }
        public decimal ABSocre { get; set; }
        public string ABLevelCode { get; set; }
        public string RealLevelCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public Guid GID { get; set; }
    }
}
