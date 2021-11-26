using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysMoudles
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public string KeyMan { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Note { get; set; }
    }
}
