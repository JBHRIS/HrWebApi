using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class SysDataStructure
    {
        public string STableName { get; set; }
        public string SColumnsName { get; set; }
        public short? IColumnsLength { get; set; }
        public short? IColumnsOrder { get; set; }
        public string SColumnsType { get; set; }
        public int? IIsNull { get; set; }
    }
}
