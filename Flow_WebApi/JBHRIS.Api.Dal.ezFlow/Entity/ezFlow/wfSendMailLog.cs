using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfSendMailLog
    {
        public int iAutoKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sGuid { get; set; }
        public string sKey1 { get; set; }
        public string sKey2 { get; set; }
        public string sToAddress { get; set; }
        public string sToName { get; set; }
        public string sFromAddress { get; set; }
        public string sFromName { get; set; }
        public string sSubject { get; set; }
        public string sBody { get; set; }
        public bool bNoCal { get; set; }
        public bool bSuccess { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
