using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.MT.Vdb
{
    public class mtVdb
    {
    }

    public class TextValueRow
    {
        public string Text { set; get; }
        public string Value { set; get; }
    }

    public class MonthRow
    {
        public int Group { set; get; }
        public int Month { set; get; }
        public DateTime DateA { set; get; }
        public DateTime DateD { set; get; }
        public int Sort { set; get; }
    }

    public class TwoDateTime
    {
        public DateTime DateA { set; get; }
        public DateTime DateD { set; get; }
    }
}
