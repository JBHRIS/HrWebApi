using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QQuestionaryM
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SContent { get; set; }
        public string SHeader { get; set; }
        public string SFooter { get; set; }
        public string SKeyMan { get; set; }
        public DateTime? DKeyDate { get; set; }
    }
}
