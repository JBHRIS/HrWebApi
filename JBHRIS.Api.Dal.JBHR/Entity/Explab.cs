using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Explab
    {
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public string Yymm { get; set; }
        public decimal Exp { get; set; }
        public decimal Comp { get; set; }
        public bool Notedit { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public DateTime Adate { get; set; }
        public decimal Days { get; set; }
        public string RateCode { get; set; }
        public string InsurType { get; set; }
        public decimal Inscd { get; set; }
        public string SalCode { get; set; }
        public decimal Jobamt { get; set; }
        public decimal Fundamt { get; set; }
        public string SNo { get; set; }
        public string SalYymm { get; set; }
        public string Saladr { get; set; }
    }
}
