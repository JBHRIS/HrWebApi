using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class SystemColumn
    {
        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TablesCode { get; set; }
        public bool IsKey { get; set; }
        public bool IsSensitive { get; set; }
        public bool NeedMask { get; set; }
        public string DefaultValue { get; set; }
        public bool CheckCode { get; set; }
        public string Related { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowNull { get; set; }
        public bool AllowEmpty { get; set; }
        public bool AllowExport { get; set; }
        public bool AllowSort { get; set; }
        public string ColumnTypeCode { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
