using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JqForeignKey
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public int ParentId { get; set; }
        public string ParentTable { get; set; }
        public string ParentColumn { get; set; }
        public int ChildId { get; set; }
        public string ChildTable { get; set; }
        public string ChildColumn { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
