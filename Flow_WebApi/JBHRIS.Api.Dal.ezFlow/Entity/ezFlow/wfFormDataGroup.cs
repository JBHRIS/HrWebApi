using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class wfFormDataGroup
    {
        public int iAutoKey { get; set; }
        public string sFormCode { get; set; }
        public string sDataGroup { get; set; }
        public bool? bMsgManage { get; set; }
        public bool? bFormDisplay { get; set; }
    }
}
