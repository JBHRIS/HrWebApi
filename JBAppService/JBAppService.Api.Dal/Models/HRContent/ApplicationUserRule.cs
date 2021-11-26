using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ApplicationUserRule
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string UserId { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanExport { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
        public string ApplicationType { get; set; }
        public string Tag { get; set; }
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
    }
}
