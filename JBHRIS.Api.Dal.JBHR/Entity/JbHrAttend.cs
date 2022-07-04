using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JbHrAttend
    {
        public string SNobr { get; set; }
        public DateTime DAdate { get; set; }
        public string SRoteCode { get; set; }
        public decimal ILateMins { get; set; }
        public decimal IEmins { get; set; }
        public bool BAbs { get; set; }
        public decimal IForget { get; set; }
    }
}
