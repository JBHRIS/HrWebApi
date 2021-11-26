using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MidOrgPerson
    {
        public string Id { get; set; }
        public string PersonBaseid { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Code { get; set; }
        public string Departmentid { get; set; }
        public string Groupid { get; set; }
        public string Unitid { get; set; }
        public string Jobid { get; set; }
        public string Postid { get; set; }
        public string IsEnable { get; set; }
        public int IsDeleted { get; set; }
        public string IsFinish { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
