using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDSOLUTIONS
    {
        public string USERID { get; set; }
        public string SOLUTIONID { get; set; }
        public string SOLUTIONNAME { get; set; }
        public string MOUDLEXMLTEXT { get; set; }
        public byte[] SETTING { get; set; }
        public string ALIASOPTIONS { get; set; }
        public byte[] LOGONIMAGE { get; set; }
        public string BGSTARTCOLOR { get; set; }
        public string BGENDCOLOR { get; set; }
        public string THEME { get; set; }
        public string COMPANY { get; set; }
        public int? PAGESAVEOPTION { get; set; }
    }
}
