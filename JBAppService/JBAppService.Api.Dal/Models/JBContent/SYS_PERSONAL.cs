using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_PERSONAL
    {
        public string FORMNAME { get; set; }
        public string COMPNAME { get; set; }
        public string USERID { get; set; }
        public string REMARK { get; set; }
        public string PROPCONTENT { get; set; }
        public DateTime? CREATEDATE { get; set; }
    }
}
