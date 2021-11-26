using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll.Bas.Vdb
{
    public class ExchangeVdb
    {
    }

    public class ExchangeRow
    {
        public string From { get; set; }
        public string To { get; set; }
        public string YYMM { get; set; }
        public string Seq { get; set; }
        public decimal Rate { get; set; }
    }
}