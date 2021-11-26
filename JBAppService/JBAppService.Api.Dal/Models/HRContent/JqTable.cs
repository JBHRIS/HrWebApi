using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JqTable
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }
        public string Memo { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
