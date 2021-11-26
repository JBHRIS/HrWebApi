using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class EffsGroupitem
    {
        public int AutoKey { get; set; }
        public string EffsgroupId { get; set; }
        public string Jobl { get; set; }
        public int? DeptOrder { get; set; }
    }
}
