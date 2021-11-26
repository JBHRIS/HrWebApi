using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class AppConfig
    {
        public string Category { get; set; }
        public string Code { get; set; }
        public string Comp { get; set; }
        public string NameP { get; set; }
        public string Value { get; set; }
        public string Note { get; set; }
        public string DataType { get; set; }
        public string ControlType { get; set; }
        public string DataSource { get; set; }
        public int Sort { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
