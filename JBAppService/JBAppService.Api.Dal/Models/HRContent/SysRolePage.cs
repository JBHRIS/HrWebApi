using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class SysRolePage
    {
        public string RoleCode { get; set; }
        public string PageCode { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
