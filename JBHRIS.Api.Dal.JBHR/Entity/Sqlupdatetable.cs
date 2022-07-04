using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Sqlupdatetable
    {
        public int Autokey { get; set; }
        public string Filename { get; set; }
        public string Userid { get; set; }
        public DateTime? Timeb { get; set; }
        public DateTime? Timee { get; set; }
        public string Note { get; set; }
    }
}
