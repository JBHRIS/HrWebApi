using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class SubWork
    {
        public int iAutoKey { get; set; }
        public string sNobr { get; set; }
        public string sSubDept { get; set; }
        public string sSubJob { get; set; }
        public bool bSubMang { get; set; }
        public DateTime dAdate { get; set; }
        public DateTime dDdate { get; set; }
        public int iFlowAuth { get; set; }
        public bool bReplace { get; set; }
        public string sKeyMan { get; set; }
        public DateTime dKeyDate { get; set; }
    }
}
