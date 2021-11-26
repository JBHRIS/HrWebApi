using System;
using System.Collections.Generic;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class tempBase
    {
        public string id { get; set; }
        public string pw { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string sex { get; set; }
        public string dept { get; set; }
        public string depts { get; set; }
        public string job { get; set; }
        public string jobl { get; set; }
        public string jobs { get; set; }
        public bool? mang { get; set; }
    }
}
