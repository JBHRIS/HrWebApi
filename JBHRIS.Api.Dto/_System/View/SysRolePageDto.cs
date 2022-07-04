using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysRolePageDto
    {
        public int AutoKey { get; set; }
        public string RoleCode { get; set; }
        public string PageCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
