using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrDepts
    {
        public string SDeptCode { get; set; }
        public string SDeptName { get; set; }
        public DateTime? DAdate { get; set; }
        public DateTime? DDdate { get; set; }
    }
}
