using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Yrinsur
    {
        public string Year { get; set; }
        public string Nobr { get; set; }
        public string FaIdno { get; set; }
        public decimal RelLab { get; set; }
        public decimal RelHel { get; set; }
        public decimal RelGrp { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Equal { get; set; }
        public decimal RelSup { get; set; }
    }
}
