using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Sal.Vdb
{
    public class SalaryLockVdb
    {
    }

    public class SalaryLockBeginRow
    {
        public DateTime Date { set; get; }
        public string Saladr { set; get; }
    }

    public class SalaryLockAfterRow
    {
        public string Yymm { set; get; }
        public string Seq { set; get; }
        public string Saladr { set; get; }
        public string Meno { set; get; }
    }

    public class SalaryDateBE
    {
        public string Nobr { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
    }

    public class SalaryYymm
    {
        public string Nobr { set; get; }
        public DateTime Date { set; get; }
        public string Yymm { set; get; }
    }

    public class SalaryMonthDay
    {
        public string Comp { set; get; }
        public int Day { set; get; }
        public int AbsDay { set; get; }
        public int OtDay { set; get; }
        public int ATTMOVEMONTH { set; get; }
        public int OTMONTH { get; set; }

    }
}
 