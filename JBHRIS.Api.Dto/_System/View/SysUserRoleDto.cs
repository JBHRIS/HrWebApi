using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysUserRoleDto
    {
        public string Nobr { get; set; }
        public List<string> RoleCode { get; set; }
    }
}
