using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysPageToRoleDto
    {
        public string PageCode { get; set; }
        public string PageName { get; set; }
        public List<SysRoleDto> HaveRole { get; set; }
    }
}
