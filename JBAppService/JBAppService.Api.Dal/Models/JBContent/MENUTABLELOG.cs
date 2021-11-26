using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class MENUTABLELOG
    {
        public int LOGID { get; set; }
        public string MENUID { get; set; }
        public string PACKAGE { get; set; }
        public DateTime? PACKAGEDATE { get; set; }
        public DateTime? LASTDATE { get; set; }
        public string OWNER { get; set; }
        public byte[] OLDVERSION { get; set; }
        public string OLDDATE { get; set; }
    }
}
