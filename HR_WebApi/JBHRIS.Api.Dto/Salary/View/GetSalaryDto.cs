using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetSalaryDto
    {
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Seq { get; set; }
        public DateTime Adate { get; set; }
        public DateTime SalDateB { get; set; }
        public DateTime SalDateE { get; set; }
        public DateTime? AttDateB { get; set; }
        public DateTime? AttDateE { get; set; }
        public string SalCode { get; set; }
        public string SalName { get; set; }
        public string SalAttr { get; set; }
        public decimal Amt { get; set; }
        public string AttrName { get; set; }
        public int? Sort { get; set; }
        public string Flag { get; set; }//-:扣項,(+ or ''):加項
        public string Type { get; set; }//1:發,2:扣,3.代
        public bool Tax { get; set; }//true:應稅
        public string Note { get; set; }
    }
}
