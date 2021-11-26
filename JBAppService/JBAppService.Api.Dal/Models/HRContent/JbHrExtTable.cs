using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrExtTable
    {
        public string STableName { get; set; }
        public string SKeyColumnName { get; set; }
        public string SKeyColumnValue { get; set; }
        public string SColumnName { get; set; }
        public string SColumnValue { get; set; }
        public string SColumnDesc { get; set; }
    }
}
