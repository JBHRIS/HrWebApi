using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.EEPContent
{
    public partial class SYS_SDQUEUE
    {
        public int ID { get; set; }
        public string USERID { get; set; }
        public string PAGETYPE { get; set; }
        public DateTime? CREATETIME { get; set; }
        public DateTime? FINISHTIME { get; set; }
        public bool FINISHFLAG { get; set; }
        public byte[] DOCUMENT { get; set; }
        public string FILENAME { get; set; }
        public string PRINTSETTING { get; set; }
    }
}
