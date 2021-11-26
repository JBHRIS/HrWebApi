using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
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
