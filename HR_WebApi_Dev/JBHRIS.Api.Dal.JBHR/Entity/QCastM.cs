using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QCastM
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SContent { get; set; }
        public int IOrder { get; set; }
        public string SCate { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
