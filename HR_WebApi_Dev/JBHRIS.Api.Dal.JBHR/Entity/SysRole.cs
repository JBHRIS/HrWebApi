using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class SysRole
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdminRole { get; set; }
        public bool? IsVisible { get; set; }
    }
}
