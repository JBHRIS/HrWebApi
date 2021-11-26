using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Inscomp
    {
        public string SNo { get; set; }
        public string Insno { get; set; }
        public string Inspo { get; set; }
        public string Insidno { get; set; }
        public string Inssub { get; set; }
        public string Instel { get; set; }
        public string Insname { get; set; }
        public string Insaddr { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Insman { get; set; }
        public string RelMan { get; set; }
        public string RelTel { get; set; }
        public bool Defa { get; set; }
        public string SNoDisp { get; set; }
        public decimal? Jobaccrate { get; set; }
    }
}
