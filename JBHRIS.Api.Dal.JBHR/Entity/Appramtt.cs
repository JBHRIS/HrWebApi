using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Appramtt
    {
        public string Deptm { get; set; }
        public string Nobr { get; set; }
        public string Yymm { get; set; }
        public string Ser { get; set; }
        public decimal Amt { get; set; }
        public decimal Amt1 { get; set; }
        public decimal Amt2 { get; set; }
        public decimal Amt3 { get; set; }
        public decimal Damt { get; set; }
        public decimal Absamt { get; set; }
        public decimal Abspot { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Di { get; set; }
        public bool Syscreate { get; set; }
    }
}
