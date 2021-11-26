using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Performance.Vdb
{
    class PerformanceVdb
    {
    }
      public class BonusRow
    {
        public string EmpId { get; set; }
        public string DeptCode { get; set; }
        public decimal BonusCardinal { get; set; }
        public decimal InWorkSpecific { get; set; }
        public decimal BonusTotal { get; set; }
        public decimal BonusAdjust { get; set; }
        public string Note { get; set; }
    }

    public class BaseRow
    {
        public int AutoKey { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string JobName { get; set; }
        public decimal WorkPerformance { get; set; }
        public decimal MannerEsteem { get; set; }
        public decimal AbilityEsteem { get; set; }
        public decimal Encourage { get; set; }
        public decimal TotalIntegrate { get; set; }
        public string RatingCode { get; set; }
        public string RatingName { get; set; }
        public string PreRatingName { get; set; }
        public decimal PreTotalIntegrate { get; set; }
        public string PrePreRatingName { get; set; }
        public decimal PrePreTotalIntegrate { get; set; }
        public decimal BonusCardinal { get; set; }
        public decimal BonusDeduct { get; set; }
        public decimal BonusMax { get; set; }
        public decimal BonusAdjust { get; set; }
        public decimal BonusReal { get; set; }
        public string Note { get; set; }
    }

    public class DeptBonusInfoRow
    {
        public string Name { get; set; }
        public decimal BonusCardinalSubDept { get; set; }
        public decimal BonusRealSubDept { get; set; }
        public decimal BonusAdjustSubDept { get; set; }
        public int PeopleNumber { get; set; }
    }

}
