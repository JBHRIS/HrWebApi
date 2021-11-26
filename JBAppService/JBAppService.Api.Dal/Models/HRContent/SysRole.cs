using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class SysRole
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsAdminRole { get; set; }
        public bool? IsVisible { get; set; }
    }
}
