using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAbsDetail
    {
        public int iAutoKey { get; set; }
        public string sAbsKey { get; set; }
        public string sKey { get; set; }
        public DateTime dDateTimeB { get; set; }
        public DateTime dDateTimeE { get; set; }
        public DateTime dDateB { get; set; }
        public string sTimeB { get; set; }
        public string sTimeE { get; set; }
        public decimal iUse { get; set; }
        public int iRoteID { get; set; }
    }
}
