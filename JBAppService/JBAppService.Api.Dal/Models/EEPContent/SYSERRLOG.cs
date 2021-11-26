using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYSERRLOG
    {
        public int ERRID { get; set; }
        public string USERID { get; set; }
        public string MODULENAME { get; set; }
        public string ERRMESSAGE { get; set; }
        public string ERRSTACK { get; set; }
        public string ERRDESCRIP { get; set; }
        public DateTime? ERRDATE { get; set; }
        public byte[] ERRSCREEN { get; set; }
        public string OWNER { get; set; }
        public DateTime? PROCESSDATE { get; set; }
        public string PRODESCRIP { get; set; }
        public string STATUS { get; set; }
    }
}
