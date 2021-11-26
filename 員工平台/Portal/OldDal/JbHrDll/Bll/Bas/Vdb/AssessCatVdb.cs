using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class AssessCatVdb
    {
    }

    public class AssessCatRow
    {
        public int AutoKey { get; set; }
        public string TemplateCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public string ContentAndFraction { get; set; }
    }
}
