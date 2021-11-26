using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QTitle
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SFraction1 { get; set; }
        public string SFraction2 { get; set; }
        public string SFraction3 { get; set; }
        public string SFraction4 { get; set; }
        public string SFraction5 { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
