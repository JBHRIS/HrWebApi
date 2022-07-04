using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Spmorganization
    {
        public string UnitId { get; set; }
        public string UnitCname { get; set; }
        public string UnitEname { get; set; }
        public string Cost { get; set; }
        public string BossDept { get; set; }
        public double? Nobr { get; set; }
        public string Manageradid { get; set; }
    }
}
