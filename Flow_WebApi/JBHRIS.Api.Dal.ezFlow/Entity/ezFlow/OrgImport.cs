using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class OrgImport
    {
        public int iAutoKey { get; set; }
        public bool? bSyncLoginID { get; set; }
        public string sFrontLoginID { get; set; }
        public bool? bFullImport { get; set; }
        public string sDeptTopCode { get; set; }
        public bool? bRoleTopEmpty { get; set; }
        public bool? bSyncLoginPW { get; set; }
        public bool? bLevel { get; set; }
        public bool? bTest { get; set; }
        public string sTestMail { get; set; }
        public bool? bFixBug { get; set; }
    }
}
