using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
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
