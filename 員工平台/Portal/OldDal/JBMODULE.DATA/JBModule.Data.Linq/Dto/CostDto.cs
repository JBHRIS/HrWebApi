using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class CostDto
    {
        public string NOBR { get; set; }
        public string DEPTS { get; set; }
        public decimal RATE { get; set; }
        public DateTime CADATE { get; set; }
        public DateTime CDDATE { get; set; }
        public string KEY_MAN { get; set; }
        public DateTime KEY_DATE { get; set; }
    }
}
