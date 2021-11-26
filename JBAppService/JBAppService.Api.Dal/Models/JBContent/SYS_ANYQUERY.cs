using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_ANYQUERY
    {
        public string QUERYID { get; set; }
        public string USERID { get; set; }
        public string TEMPLATEID { get; set; }
        public string TABLENAME { get; set; }
        public DateTime? LASTDATE { get; set; }
        public string CONTENT { get; set; }
    }
}
