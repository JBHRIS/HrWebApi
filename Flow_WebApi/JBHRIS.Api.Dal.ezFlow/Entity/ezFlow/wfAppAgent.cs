using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfAppAgent
    {
        public int iAutoKey { get; set; }
        public string sNobr { get; set; }
        public string sName { get; set; }
        public string sAgentNobr { get; set; }
        public string sAgentName { get; set; }
        public string sAgentMail { get; set; }
        public string sNote { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
