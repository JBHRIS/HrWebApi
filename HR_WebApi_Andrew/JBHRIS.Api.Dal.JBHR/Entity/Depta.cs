using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Depta
    {
        public string DNo { get; set; }
        public string DName { get; set; }
        public string DEname { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string OldDept { get; set; }
        public string DeptGroup { get; set; }
        public string DeptTree { get; set; }
        public string Nobr { get; set; }
        public string Email { get; set; }
        public string Mangemail { get; set; }
        public DateTime? Adate { get; set; }
        public DateTime? Ddate { get; set; }
        public string DNoDisp { get; set; }
        public string SignGroup { get; set; }
        public string DeptCate { get; set; }
    }
}
