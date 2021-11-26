using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class HrNotice
    {
        public int iAutoKey { get; set; }
        public string sCaption { get; set; }
        public string sContent { get; set; }
        public DateTime dDateA { get; set; }
        public DateTime dDateD { get; set; }
        public string sKeyMan { get; set; }
        public DateTime dDate { get; set; }
    }
}
