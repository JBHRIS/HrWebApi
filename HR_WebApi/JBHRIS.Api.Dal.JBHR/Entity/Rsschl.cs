using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Rsschl
    {
        public string Empid { get; set; }
        public string Educcode { get; set; }
        public DateTime Adate { get; set; }
        public bool Ok { get; set; }
        public string Schl { get; set; }
        public string Subj { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
