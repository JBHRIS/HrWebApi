using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Frm83
    {
        public string Yymm { get; set; }
        public string Nobr { get; set; }
        public decimal Effscore { get; set; }
        public string Efflvl { get; set; }
        public bool Import { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Efftype { get; set; }
        public int Autokey { get; set; }
        public string NameC { get; set; }
        public string DeptName { get; set; }
        public string DNo { get; set; }
    }
}
