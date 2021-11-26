using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Master
    {
        public string Nobr { get; set; }
        public string Master1 { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string RelishCode { get; set; }
        public string Relish { get; set; }
        public string Corporation { get; set; }
        public string Language { get; set; }
        public int MasterId { get; set; }
        public string Memo { get; set; }
    }
}
