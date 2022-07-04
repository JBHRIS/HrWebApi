using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Exttable
    {
        public int Auto { get; set; }
        public string Tablename { get; set; }
        public string Keycolumnname { get; set; }
        public string Keycolumnvalue { get; set; }
        public string Columnname { get; set; }
        public string Columnvalue { get; set; }
        public string Columndesc { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
