using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QType
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SQuestionaryCode { get; set; }
        public string SQuestionaryName { get; set; }
        public DateTime DDateB { get; set; }
        public DateTime DDateE { get; set; }
        public int ITotalFraction { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
