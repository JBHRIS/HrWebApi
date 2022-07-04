using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysMoudleByApiVoid
    {
        public string MoudleId { get; set; }
        public string ApiId { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
