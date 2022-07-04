using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class TwTax
    {
        public int Auto { get; set; }
        public string Subject { get; set; }
        public string Yearmonth { get; set; }
        public DateTime Datebegin { get; set; }
        public DateTime Dateend { get; set; }
        public string Remark { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public bool Islock { get; set; }
        public DateTime? Relasedate { get; set; }
    }
}
