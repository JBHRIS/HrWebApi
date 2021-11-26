using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrDeptm
    {
        public string SDeptCode { get; set; }
        public string SDeptName { get; set; }
        public string SDeptTree { get; set; }
        public string SDeptParent { get; set; }
        public string SDeptPathCode { get; set; }
        public string SDeptPathName { get; set; }
        public string SNobr { get; set; }
    }
}
