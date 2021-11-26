using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class IdColumnsData
    {
        public string IAutoKey { get; set; }
        public string IpTablesSCode { get; set; }
        public string SCode { get; set; }
        public string SName { get; set; }
        public string SSourceCode { get; set; }
        public string STargetCode { get; set; }
        public bool? BEmptyOrNull { get; set; }
        public bool? BEmptyToNull { get; set; }
        public bool? BPk { get; set; }
        public bool? BFk { get; set; }
        public int? SFkcode { get; set; }
        public string ImportTypeSCode { get; set; }
        public string ReplaceSCode { get; set; }
        public short? IColumnOrder { get; set; }
        public short IColumnLength { get; set; }
        public string ColumnTypeSCode { get; set; }
        public string ValueSCode { get; set; }
        public int? SSetValue { get; set; }
        public string SpecialSet { get; set; }
        public string SpecialIf { get; set; }
        public string SNote { get; set; }
        public short? ISort { get; set; }
        public string SKeyMan { get; set; }
        public DateTime DKeyDate { get; set; }
    }
}
