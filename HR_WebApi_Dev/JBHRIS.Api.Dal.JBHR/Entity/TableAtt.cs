using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class TableAtt
    {
        public string Fieldname { get; set; }
        public string Caption { get; set; }
        public bool Display { get; set; }
        public DateTime? KeyDate { get; set; }
        public string KeyMan { get; set; }
    }
}
