using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class HrNoticeFile
    {
        public int iAutoKey { get; set; }
        public int HrNotice_iAutoKey { get; set; }
        public string sServerName { get; set; }
        public string sUploadName { get; set; }
        public string sType { get; set; }
        public int iSize { get; set; }
        public DateTime dDate { get; set; }
        public string sDescription { get; set; }
    }
}
