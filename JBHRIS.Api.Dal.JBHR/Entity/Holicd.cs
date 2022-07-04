using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Holicd
    {
        public string HoliCode { get; set; }
        public string HoliName { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public bool Noset { get; set; }
        public string DateCode { get; set; }
        public string HoliCodeDisp { get; set; }
    }
}
