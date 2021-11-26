using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MidOrgGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
        public string Parentid { get; set; }
        public string IsEnable { get; set; }
        public string IsDeleted { get; set; }
        public string UpdateTime { get; set; }
    }
}
