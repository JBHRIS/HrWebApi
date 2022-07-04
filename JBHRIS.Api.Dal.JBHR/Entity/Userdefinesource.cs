using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Userdefinesource
    {
        public int Ak { get; set; }
        public Guid Sourceid { get; set; }
        public string Sourcename { get; set; }
        public string Sourcetype { get; set; }
        public string Valuemember { get; set; }
        public string Displaymember { get; set; }
        public string Sourcescript { get; set; }
    }
}
