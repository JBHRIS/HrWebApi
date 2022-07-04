using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Mailsend
    {
        public string Formname { get; set; }
        public string NobrRec { get; set; }
        public string Formno { get; set; }
        public string Adate { get; set; }
        public string NobrSend { get; set; }
        public string OkStat { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? OkTime { get; set; }
    }
}
