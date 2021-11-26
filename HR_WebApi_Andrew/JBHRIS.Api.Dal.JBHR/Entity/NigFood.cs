using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class NigFood
    {
        public string Comp { get; set; }
        public string Rote { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal Foodamt { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
