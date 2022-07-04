using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JbHrOtrcd
    {
        public string SOtrCode { get; set; }
        public string SOtrName { get; set; }
        public bool? BDisplay { get; set; }
        public int ISort { get; set; }
        public bool BNoCalc { get; set; }
    }
}
