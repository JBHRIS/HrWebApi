using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormAppCode
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sFormName { get; set; }
        public string sCategory { get; set; }
        public string sProcessID { get; set; }
        public int? idProcess { get; set; }
        public string sNobr { get; set; }
        public string sKey { get; set; }
        public string sCode { get; set; }
        public string sName { get; set; }
        public string sContent { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
