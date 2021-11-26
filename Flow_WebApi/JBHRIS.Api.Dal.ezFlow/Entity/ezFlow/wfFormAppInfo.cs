using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormAppInfo
    {
        public int iAutoKey { get; set; }
        public string sProcessID { get; set; }
        public int idProcess { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public string sState { get; set; }
        public string sInfo { get; set; }
        public string sGuid { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
