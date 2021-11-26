using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class FlowControl
    {
        public int iAutokey { get; set; }
        public string sForm { get; set; }
        public string sFormCode { get; set; }
        public string sValue { get; set; }
        public DateTime? dKeydate { get; set; }
        public string sKeyMan { get; set; }
    }
}
