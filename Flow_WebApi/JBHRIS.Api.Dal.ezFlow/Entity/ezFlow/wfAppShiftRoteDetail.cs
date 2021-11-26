using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppShiftRoteDetail
    {
        public int iAutoKey { get; set; }
        public string sShiftRoteKey { get; set; }
        public string sKey { get; set; }
        public DateTime dShiftRoteDate { get; set; }
        public int iRoteID1 { get; set; }
        public string sRote1 { get; set; }
        public string sRoteName1 { get; set; }
        public int iRoteID2 { get; set; }
        public string sRote2 { get; set; }
        public string sRoteName2 { get; set; }
    }
}
