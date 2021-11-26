using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Schl
    {
        public string Nobr { get; set; }
        public string Educcode { get; set; }
        public DateTime Adate { get; set; }
        public bool Ok { get; set; }
        public string Schl1 { get; set; }
        public string Subj { get; set; }
        public DateTime DateB { get; set; }
        public DateTime DateE { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Subjcode { get; set; }
        public int? SchlId { get; set; }

        public virtual Base NobrNavigation { get; set; }
    }
}
