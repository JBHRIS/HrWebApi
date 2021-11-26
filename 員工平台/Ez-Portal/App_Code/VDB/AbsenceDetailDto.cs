using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class AbsenceDetailDto
    {
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public string Dept { get; set; }
        public string HCode { get; set; }
        //public string HCodeDisp;
        public string HName { get; set; }
        public string Unit { get; set; }
        public string YearRest { get; set; }
        public decimal GetHrs { get; set; }
        public decimal AuthorizedHrs { get; set; }
        public decimal AuthorizingHrs { get; set; }
    }
