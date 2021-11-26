using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDALIAS
    {
        public string USERID { get; set; }
        public string ALIASNAME { get; set; }
        public string SYSTEMALIAS { get; set; }
        public string DBNAME { get; set; }
        public bool? SPLIT { get; set; }
    }
}
