using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Bas.Vdb
{
    public class PayDocVdb
    {
    }

    public class PayDocRow
    {
        public string Nobr { get; set; }
        public int DocItemCode { get; set; }
        public string DocItemName { get; set; }
        public bool Payed { get; set; }
        public DateTime? PayDate { get; set; }
    }
}
