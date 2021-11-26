using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormCode
    {
        public int iAutoKey { get; set; }
        public string sCategory { get; set; }
        public string sCode { get; set; }
        public string sName { get; set; }
        public string sContent { get; set; }
        public int iOrder { get; set; }
        public bool bDisplay { get; set; }
        public string sKeyMan { get; set; }
        public DateTime? dKeyDate { get; set; }
    }
}
