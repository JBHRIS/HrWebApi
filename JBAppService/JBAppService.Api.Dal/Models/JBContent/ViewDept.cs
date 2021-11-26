using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class ViewDept
    {
        public string Code { get; set; }
        public string DisplayCode { get; set; }
        public string Name { get; set; }
        public int DeptTree { get; set; }
        public string ParentCode { get; set; }
        public string ManagerEmpId { get; set; }
    }
}
