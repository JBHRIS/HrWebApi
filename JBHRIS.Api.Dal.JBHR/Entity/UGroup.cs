using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UGroup
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public string Prog { get; set; }
        public bool? Add { get; set; }
        public bool? Edit { get; set; }
        public bool? Dele { get; set; }
        public bool? Print { get; set; }
        public string System { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
