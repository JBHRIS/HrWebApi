using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QBaseS
    {
        public int IAutoKey { get; set; }
        public string SBaseCode { get; set; }
        public string SQuestionaryCode { get; set; }
        public string SCastCode { get; set; }
        public string SCate { get; set; }
        public string SThemeCode { get; set; }
        public int? IFraction { get; set; }
        public string SFraction { get; set; }
    }
}
