using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class ApplicationInfo
    {
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationCategory { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public string Remark { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
