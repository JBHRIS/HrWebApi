using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class JobVdb
    {
    }

    public class JobRow
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Tree { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
    }
}