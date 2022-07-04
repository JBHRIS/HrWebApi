using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsTempletinterview
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string InterviewId { get; set; }
        public int? Order { get; set; }
    }
}
