using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysRolePage
    {
        public int AutoKey { get; set; }
        public string RoleCode { get; set; }
        public string PageCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
