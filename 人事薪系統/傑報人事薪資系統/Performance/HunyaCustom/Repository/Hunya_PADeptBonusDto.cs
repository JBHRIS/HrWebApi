using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Performance.HunyaCustom.Repository
{
    public class Hunya_PADeptBonusDto
    {
        public string PADept { get; set; }
        public string YYMM_B { get; set; }
        public string YYMM_E { get; set; }
        public decimal PABasicBonus { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public Guid GID { get; set; }
    }
}
