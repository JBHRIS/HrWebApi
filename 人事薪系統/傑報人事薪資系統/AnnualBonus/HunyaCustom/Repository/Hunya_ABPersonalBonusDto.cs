using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.AnnualBonus.HunyaCustom.Repository
{
    public class Hunya_ABPersonalBonusDto
    {
        public string EmployeeID { get; set; }
        public int YYYY { get; set; }
        public decimal DailySalary { get; set; }
        public decimal BonusDays { get; set; }
        public decimal MeritDays { get; set; }
        public decimal BonusRate { get; set; }
        public decimal OnJobDays { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public Guid GID { get; set; }
    }
}
