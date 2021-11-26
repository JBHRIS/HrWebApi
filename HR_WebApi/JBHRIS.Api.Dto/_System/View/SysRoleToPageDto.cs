using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysRoleToPageDto
    {
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public List<SysMenuDto> HavePage { get; set; }
    }
    
}
