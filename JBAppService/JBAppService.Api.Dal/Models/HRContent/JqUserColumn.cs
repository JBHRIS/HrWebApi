using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JqUserColumn
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public int Sort { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DisplayName { get; set; }
        public bool Display { get; set; }
        public string DataType { get; set; }
        public bool PrimaryKey { get; set; }
        public string Format { get; set; }
        public string Memo { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
        public string System { get; set; }
        public string UserId { get; set; }
        public int GroupIndex { get; set; }
        public int OrderByIndex { get; set; }
        public string TopSummaryOption { get; set; }
        public string TopSummaryFormatString { get; set; }
        public string BottomSummaryOption { get; set; }
        public string BottomSummaryFormatString { get; set; }
    }
}
