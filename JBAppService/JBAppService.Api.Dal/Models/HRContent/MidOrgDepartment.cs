using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class MidOrgDepartment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Groupid { get; set; }
        public string Unitid { get; set; }
        public string Parentid { get; set; }
        public string Departmanagers { get; set; }
        public string IsEnable { get; set; }
        public int IsDeleted { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
