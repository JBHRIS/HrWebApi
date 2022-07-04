using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Tremail
    {
        public string Idno { get; set; }
        public string Interemail { get; set; }
        public string Noteemail { get; set; }
        public bool Dept1mang { get; set; }
        public bool Dept2mang { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string Dept { get; set; }
        public string Dept1 { get; set; }
    }
}
