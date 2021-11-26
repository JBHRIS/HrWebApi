using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JbHrReason
    {
        public string SReasonCode { get; set; }
        public string SReasonName { get; set; }
        public bool BAtt { get; set; }
        public int ISort { get; set; }
    }
}
