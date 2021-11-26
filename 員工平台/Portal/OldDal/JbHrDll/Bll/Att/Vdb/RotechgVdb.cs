using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    public class RotechgVdb
    {

    }

    public class RotechgRow
    {
        public string Nobr { set; get; }
        public string Name { set; get; }
        public DateTime DateA { set; get; }
        public string RoteCode { set; get; }
        public string Code { set; get; }
        public string Serno { set; get; }
        public string KeyMan { set; get; }
        public DateTime keyDate { set; get; }
    }

    public class DateRoteRow
    {
        public string Nobr { get; set; }
        public DateTime DateB { get; set; }
        public string RoteCode { get; set; }
        public List<string> ExcludeRoteCode { get; set; }
    }
}