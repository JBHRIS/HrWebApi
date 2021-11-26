using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Qtpl
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FillerCategory { get; set; }
        public int FillFormSpan { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public bool BeenUsed { get; set; }
        public string HeaderText { get; set; }
        public string FooterText { get; set; }
    }
}
