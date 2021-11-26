using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UpBaseRecord
    {
        public int Id { get; set; }
        public string Nobr { get; set; }
        public string NameC { get; set; }
        public string Updescr { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
