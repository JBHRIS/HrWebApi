using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsTempletlearnplan
    {
        public int AutoKey { get; set; }
        public string TempletId { get; set; }
        public string LearnplanId { get; set; }
        public int? Order { get; set; }
    }
}
