using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysRoleDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdminRole { get; set; }
        public bool? IsVisible { get; set; }
    }
}
