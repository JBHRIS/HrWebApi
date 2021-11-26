using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Appramt
    {
        public string Deptm { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public string Itemcd { get; set; }
        public decimal Vv { get; set; }
        public decimal V1 { get; set; }
        public decimal V2 { get; set; }
        public decimal Rate { get; set; }
        public decimal Amt { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Damt { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Di { get; set; }
    }
}
