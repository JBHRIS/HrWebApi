using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MidOrgPersonPart
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string Departmentid { get; set; }
        public string Unitid { get; set; }
        public string Jobid { get; set; }
        public string Postid { get; set; }
        public string IsDeleted { get; set; }
        public string IsFinish { get; set; }
        public string UpdateTime { get; set; }
    }
}
