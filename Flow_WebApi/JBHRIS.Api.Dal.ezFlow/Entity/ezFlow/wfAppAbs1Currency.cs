using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAbs1Currency
    {
        public int iAutoKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public decimal iRate { get; set; }
        public string sCurrencyCode { get; set; }
        public string sCurrencyName { get; set; }
        public decimal iAmount { get; set; }
        public decimal iAmountReal { get; set; }
        public bool bSign { get; set; }
        public string sState { get; set; }
        public DateTime? dDate { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
