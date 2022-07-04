using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Dept
    {
        public string DNo { get; set; }
        public string DName { get; set; }
        public string DEname { get; set; }
        public decimal? Pns { get; set; }
        public string DeptTree { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string OldDept { get; set; }
        public string NewDept { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Ddate { get; set; }
        public string DeptGroup { get; set; }
        public string Nobr { get; set; }
        public decimal? Amt { get; set; }
        public string Email { get; set; }
        public bool? Res { get; set; }
        public string DNoDisp { get; set; }
    }
}
