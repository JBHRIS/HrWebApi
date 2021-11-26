using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Expcomp
    {
        public string Yymm { get; set; }
        public string SNo { get; set; }
        public decimal LEmp { get; set; }
        public decimal LExp { get; set; }
        public decimal HEmp { get; set; }
        public decimal HExp { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
