using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class AssessVdb
    {
    }

    public class AssessRow
    {
        public int AutoKey { get; set; }
        public string AssessCatCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Fraction { get; set; }
        public int Sort { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
