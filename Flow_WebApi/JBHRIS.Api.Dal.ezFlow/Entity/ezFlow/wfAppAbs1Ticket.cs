using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAbs1Ticket
    {
        public int iAutoKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public DateTime dDateTimeB { get; set; }
        public DateTime? dDateTimeE { get; set; }
        public DateTime dDateB { get; set; }
        public DateTime? dDateE { get; set; }
        public string sTimeB { get; set; }
        public string sTimeE { get; set; }
        public string sFlightB { get; set; }
        public string sFlightE { get; set; }
        public string sLocationB { get; set; }
        public string sLocationNoteB { get; set; }
        public string sLocationE { get; set; }
        public string sLocationNoteE { get; set; }
        public string sTicketSeqCode { get; set; }
        public string sTicketSeqName { get; set; }
        public string sTicketSeqNote { get; set; }
        public bool bNotify { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public DateTime? dDate { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
