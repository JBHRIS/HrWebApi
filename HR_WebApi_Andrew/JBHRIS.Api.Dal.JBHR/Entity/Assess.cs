using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Assess
    {
        public int IAutoKey { get; set; }
        public string AssessCatSCode { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SFraction { get; set; }
        public int SOrder { get; set; }
        public string SKeyMan { get; set; }
        public string DKeyDate { get; set; }
    }
}
