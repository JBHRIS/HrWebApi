using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class Notice
    {
        public int iAutoKey { get; set; }
        public string sGuid { get; set; }
        public string sTitle { get; set; }
        public string sContent { get; set; }
        public DateTime dDateA { get; set; }
        public DateTime dDateD { get; set; }
        public int iSort { get; set; }
        public string sKeyMan { get; set; }
        public DateTime dKeyDate { get; set; }
    }
}
