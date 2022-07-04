using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Relaytable
    {
        public int Ak { get; set; }
        public string Parentkey { get; set; }
        public string Parentsource { get; set; }
        public string Childkey { get; set; }
        public string Childbsource { get; set; }
        public string Createman { get; set; }
        public DateTime Createdate { get; set; }
    }
}
