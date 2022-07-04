using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysDefault
    {
        public int IAutoKey { get; set; }
        public string SName { get; set; }
        public string SCategory { get; set; }
        public string SKey { get; set; }
        public string SValue { get; set; }
        public string SType { get; set; }
        public int IOrder { get; set; }
        public string SKeyMan { get; set; }
        public DateTime? DKeyDate { get; set; }
    }
}
