using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.OverTime
{
    class OverTimeReasonVdb
    {
    }
    public class OverTimeReasonConditions : DataConditions
    {
    }
    public class OverTimeReasonApiRow : StandardDataBaseApiRow
    {
        public class result
        {
            public string otrcd1 { get; set; }
            public string otrname { get; set; }
            public DateTime keyDate { get; set; }
            public string keyMan { get; set; }
            public bool? callin { get; set; }
            public bool? display { get; set; }
            public bool? nocalc { get; set; }
            public bool? nofood { get; set; }
            public bool sysOt { get; set; }
            public int? sort { get; set; }
            public string otrcdDisp { get; set; }
        }
        public List<result> Result { get; set; }
    }
    public class OverTimeReasonRow
    {
        public string otrcd1 { get; set; }
        public string otrname { get; set; }
        public DateTime keyDate { get; set; }
        public string keyMan { get; set; }
        public bool? callin { get; set; }
        public bool? display { get; set; }
        public bool? nocalc { get; set; }
        public bool? nofood { get; set; }
        public bool sysOt { get; set; }
        public int? sort { get; set; }
        public string otrcdDisp { get; set; }

    }
}
