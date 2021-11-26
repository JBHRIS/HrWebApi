using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class CalcSalaryMsgDto
    {
        public string Nobr { get; set; }
        public string Name { get; set; }
        public decimal Amt { get; set; }
        public string Salcode { get; set; }
        public string SalName { get; set; }
        public string Yymm { get; set; }
        public string Function { get; set; }
    }
}
