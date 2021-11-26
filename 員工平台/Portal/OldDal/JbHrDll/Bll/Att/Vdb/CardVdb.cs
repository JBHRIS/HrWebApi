using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class CardVdb
    {

    }

    public class CardRow
    {
        public string Nobr { set; get; }
        public string Name { set; get; }
        public DateTime DateA { set; get; }
        public string OnTime { set; get; }
        public string CardNo { set; get; }
        public bool NotTran { set; get; }
        public string Reason { set; get; }
        public bool Los { set; get; }
        public string IpAdd { set; get; }
        public string Note { set; get; }
        public string Serno { set; get; }
        public string KeyMan { set; get; }
        public DateTime keyDate { set; get; }
    }
}