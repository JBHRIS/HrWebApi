using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Trdud
    {
        public string Idenno { get; set; }
        public string Tranty { get; set; }
        public string Toiden { get; set; }
        public DateTime Effdat { get; set; }
        public DateTime Duedat { get; set; }
        public string Creusr { get; set; }
        public DateTime Credat { get; set; }
        public string Updusr { get; set; }
        public DateTime Upddat { get; set; }
    }
}
