using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JqCondition
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public int Sort { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Comparison { get; set; }
        public string Value { get; set; }
        public string Value1 { get; set; }
        public string QueryType { get; set; }
        public string CustomQuery { get; set; }
        public string UserId { get; set; }
        public string Memo { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
