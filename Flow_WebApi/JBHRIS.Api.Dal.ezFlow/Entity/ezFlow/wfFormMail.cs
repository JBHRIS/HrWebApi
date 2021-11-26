using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormMail
    {
        public int iAutoKey { get; set; }
        public string sKey { get; set; }
        public string sFormCode { get; set; }
        public string sCode { get; set; }
        public string sName { get; set; }
        public string sSubject { get; set; }
        public string sBody { get; set; }
        public string sNote { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
