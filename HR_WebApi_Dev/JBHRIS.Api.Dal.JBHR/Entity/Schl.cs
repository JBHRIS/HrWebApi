using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Schl
    {
        public int Auto { get; set; }
        public string Nobr { get; set; }
        public string Educcode { get; set; }
        public DateTime Adate { get; set; }
        public bool Ok { get; set; }
        public string Schl1 { get; set; }
        public string Subj { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Subjcode { get; set; }
        public int SchlId { get; set; }
        public string DayOrNight { get; set; }
        public string SubjDetail { get; set; }
        public bool Graduated { get; set; }
        public string Memo { get; set; }
    }
}
