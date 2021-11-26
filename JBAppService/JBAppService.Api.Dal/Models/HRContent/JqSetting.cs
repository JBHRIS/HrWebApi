using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JqSetting
    {
        public int Id { get; set; }
        public string QuerySetting { get; set; }
        public string QueryName { get; set; }
        public string SourceType { get; set; }
        public string ConnectString { get; set; }
        public string Memo { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
        public int Sort { get; set; }
        public int PageSize { get; set; }
        public string CustomerWhere { get; set; }
    }
}
