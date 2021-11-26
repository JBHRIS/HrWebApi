using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QTheme
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SContent { get; set; }
        public string STitleCode { get; set; }
        public int IOrder { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
