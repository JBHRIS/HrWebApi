using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Yrformat
    {
        public string MFormat { get; set; }
        public string MFmtName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public decimal Fixrate { get; set; }
        public decimal Supplemin { get; set; }
        public decimal Supplemax { get; set; }
        public string Incometype { get; set; }
    }
}
