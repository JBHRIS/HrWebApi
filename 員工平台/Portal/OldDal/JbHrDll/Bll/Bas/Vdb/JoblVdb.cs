using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class JoblVdb
    {
    }

    public class JoblRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int Level { get; set; }
    }
}