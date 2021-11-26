using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class View_wfAppAbsAndShiftRote
    {
        public string sFormCode { get; set; }
        public int idProcess { get; set; }
        public long? seqno { get; set; }
        public string employid { get; set; }
        public string sType { get; set; }
        public string sName { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string sState { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
